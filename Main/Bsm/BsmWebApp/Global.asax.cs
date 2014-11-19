using BsmWebApp.Infrastructure;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BsmWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IUnityContainer container = new UnityContainer();
            Bootstrapper boot = new Bootstrapper();
            boot.InitContainer(container);

            UnityDependencyResolver resolver = new UnityDependencyResolver(container);
            DependencyResolver.SetResolver(resolver);

            InitServiceLocator(container);

            boot.SetMenus(container);
        }

        private void InitServiceLocator(IUnityContainer container)
        {
            UnityServiceLocator sl = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => sl);
        }
    }
}
