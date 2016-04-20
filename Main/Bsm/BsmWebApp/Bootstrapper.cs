using BsmBL.DAL;
using BsmBL.Managers;
using BsmCommon.CachedItems;
using BsmCommon.Interfaces.CachedItems;
using BsmCommon.Interfaces.Dal;
using BsmCommon.Interfaces.DAL;
using BsmCommon.Interfaces.Managers;
using CacheInfra.Implement;
using CacheInfra.Interfaces;
using Egged.Infrastructure.Menus.DataModels;
using Egged.Infrastructure.Menus.Interfaces;
using Egged.Infrastructure.Menus.Managers;
using InfrastructureLogs.Logs.Interfaces;
using InfrastructureLogs.Logs.Loggers;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace BsmWebApp
{
    public class Bootstrapper
    {
        public void InitContainer(IUnityContainer container)
        {
            var configFilePath = HostingEnvironment.MapPath("~/bin/log4net.config");
            container.RegisterInstance<ILogger>(new Log4NetLogger("WebServer", configFilePath));

            container.RegisterType<IBudgetManager, BudgetManager>();
            container.RegisterType<ISecurityManager,SecurityManager>();
            container.RegisterType<IGeneralManager,GeneralManager>();
            container.RegisterType<IChangesManager, ChangesManager>();
            
            container.RegisterType<IBudgetDal, BudgetDal>();
            container.RegisterType<IChangesDal, ChangesDal>();
            container.RegisterType<IGeneralDal, GeneralDal>();
            container.RegisterType<IDbLogger, DbLogger>();
            container.RegisterType<ILogManager, LogManager>();

            container.RegisterInstance<IUserInfoCachedItems>(container.Resolve<UserInfoCachedItems>());
            container.RegisterInstance<IMenusManager>(new MenusManager());
            //container.RegisterInstance<ICacheManager>(container.Resolve<NetCacheManager>());


        }

        public void SetMenus(IUnityContainer container)
        {
            SingleMenu menuItem;
            IMenusManager manager = container.Resolve<IMenusManager>();
            menuItem = new SingleMenu() { LinkText = "דף הבית", ControllerName = "Home", ActionName = "Index", MenuType = MenuTypes.HomePage, ImagSrc = "homeImg" };
            manager.AddMenu(menuItem);
            menuItem = new SingleMenu() { LinkText = "ניהול תקציב", ControllerName = "Budget", ActionName = "Index", MenuType = MenuTypes.MamagementHourExtenstions, ImagSrc = "calculatorImg" };
            manager.AddMenu(menuItem);
            menuItem = new SingleMenu() { LinkText = "ניוד תקציב", ControllerName = "Changes", ActionName = "Index", MenuType = MenuTypes.HourChanges, ImagSrc = "changesImg" };
            manager.AddMenu(menuItem);
            
           
        }

    }
}