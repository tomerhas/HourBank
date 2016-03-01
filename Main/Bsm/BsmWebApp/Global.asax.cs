using BsmCommon.DataModels.Profiles;
using BsmCommon.Interfaces.CachedItems;
using BsmWebApp.Controllers;
using BsmWebApp.Infrastructure;
using InfrastructureLogs.Logs.DataModels;
using InfrastructureLogs.Logs.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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
            foreach (System.Collections.DictionaryEntry entry in HttpContext.Current.Cache)
            {
                EventLog.WriteEntry("kds", "Application_Start");
                HttpContext.Current.Cache.Remove((string)entry.Key);
            }
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
            container.Resolve<ILogger>().Log("bootstrap initialize containers", Category.Info);

            boot.SetMenus(container);
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
        }

        private void InitServiceLocator(IUnityContainer container)
        {
            UnityServiceLocator sl = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => sl);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            string userName;
             if (ConfigurationSettings.AppSettings["DebugModeUserName"] == "true")
                userName = ConfigurationSettings.AppSettings["DebugUserName"];
             else userName = HttpContext.Current.User.Identity.Name;
        
            var cache = ServiceLocator.Current.GetInstance<IUserInfoCachedItems>();
            UserInfo uf = cache.Get(userName);
            if (uf != null)
                cache.Remove(userName);
           // EventLog.WriteEntry("kds", "Session_start");
        }
     }
        
    
}
