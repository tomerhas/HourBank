using BsmCommon.DataModels.Profiles;
using BsmCommon.Interfaces.CachedItems;
using BsmCommon.Interfaces.Managers;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace BsmWebApp.Infrastructure.Security
{
    public class SecurityValidator
    {
        private IUnityContainer _container;
        public SecurityValidator(IUnityContainer container)
        {
            _container = container;
        }
        public UserInfo GetOrCreateCurrentUser(IPrincipal principal)
        {
            if (principal.Identity.IsAuthenticated)
            {
                string userName;
                if (ConfigurationManager.AppSettings["DebugModeUserName"].ToLower() == "true")
                    userName = ConfigurationManager.AppSettings["DebugUserName"];
                else userName = principal.Identity.Name;
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
                        EventLog.WriteEntry("kds", "SecurityValidator.GetOrCreateCurrentUser: Error - " + ex.Message);
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