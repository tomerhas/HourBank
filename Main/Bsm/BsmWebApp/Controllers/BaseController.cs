using BsmBL.Managers;
using BsmCommon.DataModels;
using BsmCommon.DataModels.Profiles;
using BsmCommon.Interfaces.CachedItems;
using BsmCommon.Interfaces.Managers;
using BsmWebApp.Infrastructure.Security;
using BsmWebApp.ViewModels;
using Egged.Infrastructure.Menus.DataModels;
using Egged.Infrastructure.Menus.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BsmWebApp.Controllers
{
  //  [PageAuthorizeAttribute]
    public class BaseController : Controller
    {
        protected IUnityContainer _container;

        public MenuTypes SelectdMenu { get; set; }
        public int SelectedMitkan { get; set; }

        public BaseController(IUnityContainer container)
        {
            _container = container;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            SetMenus();
        }

        private void SetMenus()
        {
            var menus = _container.Resolve<IMenusManager>().GetMenusForRole();
            menus.ForEach(menu =>
            {
                if (menu.MenuType == SelectdMenu)
                    menu.TabClassName = "selectedTab";
                else
                    menu.TabClassName = "";
            });
            LayoutViewModel lvm = new LayoutViewModel(menus);
            lvm.Username = CurrentUser.EmployeeFullName;
            ViewBag.LayoutViewModel = lvm;
        }

      
        
       
        public List<MonthHolder> GetMonthsBackList(int kodParam)
        {
            var manager = _container.Resolve<IBudgetManager>();
            return manager.GetMonthsBack(kodParam);
        }


        public List<TeurEzor> GetEzorList()
        {
           var manager = _container.Resolve<IGeneralManager>();
           return manager.GetEzors();
        }

        public JsonResult GetMitkanStartsWith(string taarich,    string startsWith)
        {

            IGeneralManager Gmanager = _container.Resolve<IGeneralManager>();
            DataTable yechidot = Gmanager.GetYechidutForUser(DateTime.Parse(taarich), GetYechidatOvedForEzNihuly(), startsWith);
            List<Yechida> list = new List<Yechida>();
            foreach(DataRow dr in yechidot.Rows)
            {
                Yechida item= new Yechida();
                item.TeurYechida =dr["TeurYechida"].ToString();
                item.KodYechida = int.Parse(dr["KodYechida"].ToString());
                list.Add(item);
            }
            //var manager = _container.Resolve<IBudgetManager>();
            //var namelist = manager.GetYechidot(startsWith);
           
            //return Json(namelist, JsonRequestBehavior.AllowGet);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public int GetYechidatOvedForEzNihuly()
        {
            int KodYechida;
            if (CurrentUser.HarshaatOved.KodYechidaIchus > 0)
                KodYechida = CurrentUser.HarshaatOved.KodYechidaIchus;
            else KodYechida = CurrentUser.HarshaatOved.KodYechida;

            return KodYechida;
        }

      
      
        public UserInfo CurrentUser
        {
            get 
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    string userName = HttpContext.User.Identity.Name;
                    var cache = _container.Resolve<IUserInfoCachedItems>();
                    UserInfo uf = cache.Get(userName);
                    if (uf == null)
                    {
                        try
                        {
                            var userInfo = _container.Resolve<ISecurityManager>().GetUserInfo(userName);
                            cache.Add(userName, userInfo);
                            return userInfo;
                        }
                        catch (Exception ex)
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return uf;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
	}
}