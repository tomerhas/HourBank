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

        public JsonResult GetMitkanStartsWith(string startsWith)
        {
            var manager = _container.Resolve<IBudgetManager>();
            var namelist = manager.GetYechidot(startsWith);
           
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