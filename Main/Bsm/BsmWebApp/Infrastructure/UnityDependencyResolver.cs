using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BsmWebApp.Infrastructure
{
    /// <summary>
    /// This class is a generic dependency provider resolver that will be used by ASP.MVC to resolve dependecies.
    /// By default asp will try using this provider to resolve items and if not found will use it's own dependency provider
    /// </summary>
    public class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer _container;
        public UnityDependencyResolver(IUnityContainer container)
        {
            _container = container;
        }
        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try 
            {
                return _container.ResolveAll(serviceType);
            }
            catch
            {
                return new List<object>();
            }
        }
    }
}