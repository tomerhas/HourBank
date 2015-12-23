using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

//namespace BsmWebApp.Infrastructure.Security
//{
//    public class SessionExpireFilterAttribute
//    {
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Reflection;


namespace  BsmWebApp.Infrastructure.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class DisableSession : Attribute { }

    public class SessionExpireFilterAttribute : System.Web.Mvc.ActionFilterAttribute {


        public override void OnActionExecuting( ActionExecutingContext filterContext ) {

            bool disabled = filterContext.ActionDescriptor.IsDefined(typeof(DisableSession), true) ||
                       filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(DisableSession), true);
            if (disabled)
                return;

            if (filterContext.HttpContext.Session["GeneralDetails"] == null && (filterContext.ActionDescriptor).ActionName != "Session_End")
            {
              
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Session_End" }));
            }

        }
    }
}