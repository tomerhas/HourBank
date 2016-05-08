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
          //  Session["GeneralDetails"] = null;
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

        protected void Application_Error()
        {
            ServiceLocator.Current.GetInstance<ILogger>().Log("Entering Global error", Category.Exception);
            HttpContext httpContext = HttpContext.Current;
            if (httpContext != null && httpContext.Error!= null)
            {
                ServiceLocator.Current.GetInstance<ILogger>().Log(AppendInnerExceptions(httpContext.Error,"Global Error ocurred: "), Category.Exception);
            }
            RequestContext requestContext = ((MvcHandler)httpContext.CurrentHandler).RequestContext;
            if (requestContext.HttpContext.Request.IsAjaxRequest())
            {
                httpContext.Response.Clear();
                string controllerName = requestContext.RouteData.GetRequiredString("controller");
                IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
                IController controller = factory.CreateController(requestContext, controllerName);
                ControllerContext controllerContext = new ControllerContext(requestContext, (ControllerBase)controller);

                JsonResult jsonResult = new JsonResult();
                jsonResult.Data = new { success = false, serverError = "500",error= httpContext.Error.ToString() };
                jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                jsonResult.ExecuteResult(controllerContext);
                httpContext.Response.End();
            }
        }

        private string AppendInnerExceptions(Exception ex, string curStr)
        {
            curStr += "; " + ex.Message;
            if (ex.InnerException != null)
            {
                return AppendInnerExceptions(ex.InnerException, curStr);
            }
            else
            {
                return curStr;
            }
        }


    }
}
        
    

