using BsmBL.Managers;
using BsmCommon.Interfaces.Managers;
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
            
            container.RegisterInstance<IMenusManager>(new MenusManager());
        }

        public void SetMenus(IUnityContainer container)
        {
            IMenusManager manager = container.Resolve<IMenusManager>();
            SingleMenu menuItem = new SingleMenu() { LinkText = "תקציב שעות נוספות" , ControllerName="Budget", ActionName="Index" };
            manager.AddMenu(menuItem);
        }

    }
}