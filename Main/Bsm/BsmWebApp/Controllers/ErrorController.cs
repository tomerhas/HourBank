using BsmWebApp.ViewModels.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BsmWebApp.Controllers
{
    public class ErrorController : Controller
    {
        public ErrorController ()
	    {

	    }

         public ActionResult Index(string error="")
        {

            ErrorViewModel vm = new ErrorViewModel();

            ViewBag.ErrorMessege = "gggggggggggggg";
            //vm.ErrorMessege = error; 
            return View("Error");
            //return  View("Error",vm);
        }
    }
}
      