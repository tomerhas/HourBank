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
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BsmWebApp
{
    public class Bootstrapper
    {
        public void InitContainer(IUnityContainer container)
        {
            container.RegisterType<IBudgetManager, BudgetManager>();
            container.RegisterType<ISecurityManager,SecurityManager>();
            container.RegisterType<IGeneralManager,GeneralManager>();
            container.RegisterType<IChangesManager, ChangesManager>();
            
            container.RegisterType<IBudgetDal, BudgetDal>();
            container.RegisterType<IChangesDal, ChangesDal>();

            container.RegisterInstance<IUserInfoCachedItems>(container.Resolve<UserInfoCachedItems>());
            container.RegisterInstance<IMenusManager>(new MenusManager());
            //container.RegisterInstance<ICacheManager>(container.Resolve<NetCacheManager>());


        }

        public void SetMenus(IUnityContainer container)
        {
            SingleMenu menuItem;
            IMenusManager manager = container.Resolve<IMenusManager>();
            menuItem = new SingleMenu() { LinkText = "הפחתה/הוספה שעות נוספות", ControllerName = "Changes", ActionName = "Index" };
            manager.AddMenu(menuItem);
            menuItem = new SingleMenu() { LinkText = "תקציב שעות נוספות" , ControllerName="Budget", ActionName="Index" };
            manager.AddMenu(menuItem);
           
        }

    }
}