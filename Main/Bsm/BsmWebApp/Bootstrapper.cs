﻿using BsmBL.DAL;
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
            container.RegisterType<IGeneralDal, GeneralDal>();

            container.RegisterInstance<IUserInfoCachedItems>(container.Resolve<UserInfoCachedItems>());
            container.RegisterInstance<IMenusManager>(new MenusManager());
            //container.RegisterInstance<ICacheManager>(container.Resolve<NetCacheManager>());


        }

        public void SetMenus(IUnityContainer container)
        {
            SingleMenu menuItem;
            IMenusManager manager = container.Resolve<IMenusManager>();
            menuItem = new SingleMenu() { LinkText = "דף הבית", ControllerName = "Home", ActionName = "Index", MenuType = MenuTypes.HomePage, ImagSrc = "Content/Images/home.png" };
            manager.AddMenu(menuItem);
            menuItem = new SingleMenu() { LinkText = "ניהול תקציב", ControllerName = "Budget", ActionName = "Index", MenuType = MenuTypes.MamagementHourExtenstions, ImagSrc = "Content/Images/calculator.png" };
            manager.AddMenu(menuItem);
            //menuItem = new SingleMenu() { LinkText = "הפחתה/הוספה שעות נוספות", ControllerName = "Changes", ActionName = "Index", MenuType = MenuTypes.HourChanges, ImagSrc = "~/Content/Images/home.png" };
            //manager.AddMenu(menuItem);
            
           
        }

    }
}