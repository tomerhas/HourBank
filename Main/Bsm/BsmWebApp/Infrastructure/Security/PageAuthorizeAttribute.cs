using BsmCommon.Interfaces.CachedItems;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BsmWebApp.Infrastructure.Security
{
    public class PageAuthorizeAttribute : AuthorizeAttribute
    {
        private string _pageName;

        public PageAuthorizeAttribute(string pageName)
        {
            _pageName = pageName;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //If valid - just return, else redirect to error page
             var cache = ServiceLocator.Current.GetInstance<IUserInfoCachedItems>();
             var userName = HttpContext.Current.User.Identity.Name;
             var uf = cache.Get(userName);
            if(uf != null && uf.IsPermittedForMasach(_pageName))
            {
                return;
            }
            else
            {
                //filterContext.Result=new RedirectToRouteResult(new RouteValueDictionary(new {controller="Home", action="Index"}));
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index", error="אינך רשאי לצפות בדף זה, לקבלת הרשאות אנא פנה למנהל המערכת." }));
            }
        }
    }
}