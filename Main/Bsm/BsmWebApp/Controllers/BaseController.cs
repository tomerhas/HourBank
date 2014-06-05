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
	}
}