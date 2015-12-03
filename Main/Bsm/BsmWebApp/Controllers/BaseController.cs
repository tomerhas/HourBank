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
using System.Configuration;
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
        protected int _SelectedMitkan { get; set; }

        public BaseController(IUnityContainer container)
        {
            _container = container;
            //_SelectedMitkan = SelectedMitkan;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            SetMenus();
        }

        public void SetMenus()
        {
            var menus = _container.Resolve<IMenusManager>().GetMenusForRole();
            menus.ForEach(menu =>
            {
                if (menu.MenuType == SelectdMenu)
                    menu.TabClassName = "SelectedTab";
                else
                    menu.TabClassName = "";
            });
           
            LayoutViewModel lvm = new LayoutViewModel(menus);
            lvm.Username = CurrentUser.EmployeeFullName;
           // lvm.MitkanName = CurrentUser.CurYechida.TeurYechida;
            lvm.MitkanName = CurrentUser.CurYechida;
       //     lvm.NumYechidot = CurrentUser.Yechidot.Count;
            lvm.Yechidot = new SelectList(CurrentUser.Yechidot, "KodYechida", "TeurYechida", lvm.MitkanName.KodYechida); ;
            lvm.LastDateCalc = GatLastTaarichOfCalc();
            ViewBag.LayoutViewModel = lvm;
        }

        private string GatLastTaarichOfCalc()
        {
            IGeneralManager Gmanager = _container.Resolve<IGeneralManager>();
            string taarich = Gmanager.GetLastTaarichcalc(DateTime.Now.Date, CurrentUser.CurYechida.KodYechida);
            var date = taarich.Split(' ')[0];
            var shaa = taarich.Split(' ')[1].Split(':');
            return shaa[0] + ":" + shaa[1] + "," + date;
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

        public JsonResult GetMitkanStartsWith(string taarich, string startsWith)
        {

            IGeneralManager Gmanager = _container.Resolve<IGeneralManager>();
            List<Yechida> yechidot = null;// Gmanager.GetYechidutForUser(DateTime.Parse(taarich), GetYechidatOvedForEzNihuly(), startsWith);
            //List<Yechida> list = new List<Yechida>();
            //foreach (DataRow dr in yechidot.Rows)
            //{
            //    Yechida item = new Yechida();
            //    item.TeurYechida = dr["TeurYechida"].ToString();
            //    item.KodYechida = int.Parse(dr["KodYechida"].ToString());
            //    list.Add(item);
            //}
            //var manager = _container.Resolve<IBudgetManager>();
            //var namelist = manager.GetYechidot(startsWith);

            //return Json(namelist, JsonRequestBehavior.AllowGet);
            return Json(yechidot, JsonRequestBehavior.AllowGet);
        }
      /// <summary>
      /// ////////////////////////////////////////////////////////////////
      /// </summary>
      
        public UserInfo CurrentUser
        {
            get 
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                     string userName;
                     if (ConfigurationSettings.AppSettings["DebugModeUserName"] == "true")
                         userName = ConfigurationSettings.AppSettings["DebugUserName"];
                     else userName = HttpContext.User.Identity.Name;

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