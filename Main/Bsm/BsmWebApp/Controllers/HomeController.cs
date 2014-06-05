﻿using BsmBL.DAL;
using BsmWebApp.ViewModels.Home;
using Egged.Infrastructure.Attribute;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
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
            
        }
        public ActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel();
            vm.Today = DateTime.Now;
            vm.UserName = "Merav";
            return View(vm);
        }

        [MultipleButton(Name="action", Argument="Budget")]
        [HttpPost]
        public ActionResult Index(object a)
        {
            return RedirectToAction("Index", "Budget");
        }

        [MultipleButton(Name = "action", Argument = "Budget2")]
        [HttpPost]
        public ActionResult BlaBla(object a)
        {
            return View("Index");
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