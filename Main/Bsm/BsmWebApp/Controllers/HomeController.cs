﻿using BsmBL.DAL;
using BsmCommon.DataModels;
using BsmCommon.DataModels.Profiles;
using BsmCommon.Interfaces.CachedItems;
using BsmWebApp.Infrastructure;
using BsmWebApp.Infrastructure.Security;
using BsmWebApp.ViewModels.Home;
using Egged.Infrastructure.Attribute;
using Egged.Infrastructure.Menus.DataModels;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BsmWebApp.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(IUnityContainer container)
            : base(container)
        {
            SelectdMenu = MenuTypes.HomePage;
            

           // SelectedMitkan = 88468;
        }
     //    [SessionExpireFilter]
    //  [DisableSession]
        public ActionResult Index(string error="")
        {
            
            //This is added to casuse the cache to filled in with user info 
            HomeViewModel vm = new HomeViewModel();
            //var userName = HttpContext.User.Identity.Name;
            //var cache = _container.Resolve<IUserInfoCachedItems>();
            //UserInfo uf = cache.Get(userName);
            //if (uf == null && error != "")
            //    error = "";
            var user = CurrentUser;
            if (user != null)
            {

                if (user.MursheBankShaot)
                {
                    if (error == "session end")
                        ViewBag.SessionEnd = 1;
                    else if (user.HaveHarshaotScreens)
                    {
                        // ViewBag.SessionEnd = 0;
                        //  vm.Error = error;
                        vm.ImgSrc = "~/Content/Images/Lock_Icon.png";
                        vm.Error = error;
                        ViewBag.SessionEnd = 0;
                    }
                    else
                    {
                        ViewBag.Img = "~/Content/Images/Lock_Icon.png";
                        ViewBag.ErrorMessege = "אינך מורשה להיכנס למערכת. לבירור נא פנה למרכז התמיכה בטלפון 2466";
                        return View("Error");
                    }
                    //  vm.SessionEnd = 0;
                    vm.Today = DateTime.Now;
                    vm.UserName = user.EmployeeFullName;
                }
                else
                {
                    ViewBag.Img = "~/Content/Images/Lock_Icon.png";
                    ViewBag.ErrorMessege = "אינך מורשה להיכנס למערכת. לבירור נא פנה למרכז התמיכה בטלפון 2466";
                    return View("Error");
                //    return RedirectToAction("Index", "Error", new { error = " .אינך מורשה לצפות בדף זה. לקבלת הרשאות אנא פנה למנהל מערכת" });
                }

            }
            else 
            {
                ViewBag.Img = "~/Content/Images/alert_icon.png";
                ViewBag.ErrorMessege = ".ארעה שגיאה במערכת. אנא פנה למנהל מערכת";
                return View("Error");
            }
            return View(vm);
        }
      //  [HttpPost]
            //  [DisableSession]
        public ActionResult Session_End()
        {
        //    HomeViewModel vm = new HomeViewModel();
            var user = CurrentUser;
            if (user != null)
            {
         //       vm.SessionEnd = 1;
           //     vm.Today = DateTime.Now;
           //     vm.UserName = user.EmployeeFullName;
                FilterCachedViewModel obj = new FilterCachedViewModel();
                obj.CurYechida = user.Yechidot[0];
                obj.CurMonth = DateTime.Parse("01/" + DateTime.Now.ToString("MM/yyyy"));
                Session["GeneralDetails"] = obj;
            }
           return RedirectToAction("Index", "Home",new{error= "session end"});
         //   return View(vm);
        }
     
        [MultipleButton(Name="action", Argument="Budget")]
        [HttpPost]
        public ActionResult Index(object a)
        {
            return RedirectToAction("Index", "Budget");
        }

        [MultipleButton(Name = "action", Argument = "Changes")]
        [HttpPost]
        public ActionResult IndexChanges(object a)
        {
            return RedirectToAction("Index", "Changes");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Login(int id)
        {
            return View("Login2");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}