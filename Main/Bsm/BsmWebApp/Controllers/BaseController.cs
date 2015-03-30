using BsmBL.Managers;
using BsmCommon.DataModels;
using BsmCommon.DataModels.Profiles;
using BsmCommon.Interfaces.CachedItems;
using BsmCommon.Interfaces.Managers;
using BsmWebApp.Infrastructure.Security;
using BsmWebApp.ViewModels;
using Egged.Infrastructure.Menus.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BsmWebApp.Controllers
{
  //  [PageAuthorizeAttribute]
    public class BaseController : Controller
    {
        protected IUnityContainer _container;
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
            LayoutViewModel lvm = new LayoutViewModel(menus);
            ViewBag.LayoutViewModel = lvm;
            
        }

        public JsonResult GetOvedIdByName(string sName)
        {
            if (string.IsNullOrWhiteSpace(sName))
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
            var manager = _container.Resolve<IBudgetManager>();
            var OvedId = manager.GetOvedIdByName(sName);

            return Json(OvedId, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOvedNameById(string id)
        {
            var manager = _container.Resolve<IBudgetManager>();
            var OvedName = manager.GetOvedNameById(id);

            return Json(OvedName, JsonRequestBehavior.AllowGet);
        }
        
       
        public List<MonthHolder> GetMonthsBackList(int kodParam)
        {
            var manager = _container.Resolve<IBudgetManager>();
            return manager.GetMonthsBack(kodParam);
        }

       
        public List<Ezor> GetEzorList()
        {
           var manager = _container.Resolve<IGeneralManager>();
           return manager.GetEzors();
        }

        public JsonResult GetMitkanStartsWith(string startsWith)
        {
            var manager = _container.Resolve<IBudgetManager>();
            var namelist = manager.GetYechidot(startsWith);
           
            return Json(namelist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMisparIshiWith(string startsWith, int kod, DateTime tarrich)
        {
            int inpValidate = -1;
            if (!int.TryParse(startsWith, out inpValidate))
            {
                return Json(new List<int>(),JsonRequestBehavior.AllowGet);
            }
            var manager = _container.Resolve<IBudgetManager>();
            var employees = manager.GetBudgetEmployees(kod, tarrich);
            var listIds = employees
                .Where(x=>x.MisparIshi.ToString().StartsWith(startsWith))
                .Select(x => x.MisparIshi).ToList();

          //  var manager = _container.Resolve<IBudgetManager>();
           // var namelist = manager.GetOvdimIdStartWith(startsWith);

            return Json(listIds, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOvdimNameWith(string startsWith)
        {
            var manager = _container.Resolve<IBudgetManager>();
            var namelist = manager.GetOvdimNameStartWith(startsWith);

            return Json(namelist, JsonRequestBehavior.AllowGet);
        }
      
        public UserInfo CurrentUser
        {
            get 
            {
                string userName = HttpContext.User.Identity.Name;
                var cache = _container.Resolve<IUserInfoCachedItems>();
                UserInfo uf =  cache.Get(userName);
                if (uf == null)
                {
                    var userInfo = _container.Resolve<ISecurityManager>().GetUserInfo(userName);
                    cache.Add(userName, userInfo);
                    return userInfo;
                }
                else
                {
                    return uf;
                }
            }
        }
	}
}