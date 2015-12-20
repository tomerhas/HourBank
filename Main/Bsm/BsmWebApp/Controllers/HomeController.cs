using BsmBL.DAL;
using BsmCommon.DataModels;
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
        public ActionResult Index(string error="")
        {
            
            //This is added to casuse the cache to filled in with user info 
            HomeViewModel vm = new HomeViewModel();
            var user = CurrentUser;
            if (user != null)
            {
                vm.Error = error;
                vm.Today = DateTime.Now;
                vm.UserName = user.EmployeeFullName;
                GeneralObject obj = new GeneralObject();
                obj.CurYechida = user.Yechidot[0];
                obj.CurMonth = DateTime.Parse("01/" + DateTime.Now.ToString("MM/yyyy"));
                Session["GeneralDetails"] = obj;

            }
            else 
            {
                vm.Error = "User not recognized"; 
            }
            return View(vm);
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