using BsmBL.Managers;
using BsmCommon.DataModels;
using BsmCommon.DataModels.Profiles;
using BsmCommon.Helpers;
using BsmCommon.Interfaces.CachedItems;
using BsmCommon.Interfaces.Managers;
using BsmWebApp.Infrastructure;
using BsmWebApp.Infrastructure.Security;
using BsmWebApp.ViewModels;
using Egged.Infrastructure.Menus.DataModels;
using Egged.Infrastructure.Menus.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;



namespace BsmWebApp.Controllers
{
   // [SessionExpireFilter]
  //  [PageAuthorizeAttribute]
    public class BaseController : Controller
    {
        protected IUnityContainer _container;

        public MenuTypes SelectdMenu { get; set; }
        protected int _SelectedMitkan { get; set; }

        public BaseController(IUnityContainer container)
        {
            _container = container;
        }

        private void ValidateLoadUsersDefaultInfoToSession()
        {
            if (CurrentUser.MursheBankShaot &&  Session["GeneralDetails"] == null)
            {
                //  vm.SessionEnd = 0;
                GeneralObject obj = new GeneralObject();
                obj.CurYechida = CurrentUser.Yechidot[0];
                obj.CurMonth = DateTime.Parse("01/" + DateTime.Now.ToString("MM/yyyy"));
                Session["GeneralDetails"] = obj;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ValidateLoadUsersDefaultInfoToSession();
            base.OnActionExecuting(filterContext);
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
            base.OnActionExecuted(filterContext);

           // if (filterContext.HttpContext.Session["GeneralDetails"] == null)
           //  filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Session_End" }));

            if (filterContext.HttpContext.Session["GeneralDetails"] != null)
            {
                SetMenus();
            }
        }

     
        public void SetMenus()
        {
            var menus = _container.Resolve<IMenusManager>().GetMenusForRole();
            menus.ForEach(menu =>
            {
                if (menu.MenuType == SelectdMenu)
                    menu.TabClassName = "SelectedTab";
                else
                    menu.TabClassName = "";
            });
           
            LayoutViewModel lvm = new LayoutViewModel(menus);
            lvm.Username = CurrentUser.EmployeeFullName;
           // lvm.MitkanName = CurrentUser.CurYechida.TeurYechida;

            lvm.MitkanName =  ((GeneralObject)Session["GeneralDetails"]).CurYechida;//** CurrentUser.CurYechida;
       //     lvm.NumYechidot = CurrentUser.Yechidot.Count;
            lvm.Yechidot = new SelectList(CurrentUser.Yechidot, "KodYechida", "TeurYechida", lvm.MitkanName.KodYechida); ;
            lvm.LastDateCalc = GatLastTaarichOfCalc();
            ViewBag.LayoutViewModel = lvm;
        }

        //public ActionResult GetGeneralSession()
        //{
        //    return RedirectToAction("Index", "Home", "זמן התחברות הסתיים");
        //    //Session["GeneralDetails"] = null;
        //    //if (Session["GeneralDetails"] == null)
        //    //{

        //    //    return RedirectToAction("Index", "Home", "זמן התחברות הסתיים");
        //    //    return null;
        //    //}
        //    //else
        //    //    return ((GeneralObject)Session["GeneralDetails"]);
        //}
        private string GatLastTaarichOfCalc()
        {
            GeneralObject obG = ((GeneralObject)Session["GeneralDetails"]);
            IGeneralManager Gmanager = _container.Resolve<IGeneralManager>();
            string taarich = Gmanager.GetLastTaarichcalc(obG.CurMonth, obG.CurYechida.KodYechida);//CurrentUser.CurYechida.KodYechida);
            if (taarich != "")
            {
                var date = taarich.Split(' ')[0];
                var shaa = taarich.Split(' ')[1].Split(':');
                return shaa[0] + ":" + shaa[1] + "," + date;
            }
            return "";
        }
       
        public List<MonthHolder> GetMonthsBackList(int kodParam)
        {
           

            var manager = _container.Resolve<IBudgetManager>();
            return manager.GetMonthsBack(kodParam);
        }


        public List<TeurEzor> GetEzorList()
        {
            var manager = _container.Resolve<IGeneralManager>();
            return manager.GetEzors();
        }

        public void ChangeMitkan(int mitkan)
        {
            Yechida yechida = CurrentUser.Yechidot.SingleOrDefault(y => y.KodYechida == mitkan);
            GeneralObject obj = (GeneralObject)Session["GeneralDetails"];
            obj.CurYechida = yechida; ;
            Session["GeneralDetails"] = obj;
        }

        // public ActionResult ChangeMonth(string month,string model) 
        public void ChangeMonth(string month)
        {
            GeneralObject obj = (GeneralObject)Session["GeneralDetails"];
            obj.CurMonth = DateTime.Parse(month);
            Session["GeneralDetails"] = obj;
            // return View();
        }
        
        public JsonResult GetMitkanStartsWith(string taarich, string startsWith)
        {

            IGeneralManager Gmanager = _container.Resolve<IGeneralManager>();
            List<Yechida> yechidot = null;// Gmanager.GetYechidutForUser(DateTime.Parse(taarich), GetYechidatOvedForEzNihuly(), startsWith);
            //List<Yechida> list = new List<Yechida>();
            //foreach (DataRow dr in yechidot.Rows)
            //{
            //    Yechida item = new Yechida();
            //    item.TeurYechida = dr["TeurYechida"].ToString();
            //    item.KodYechida = int.Parse(dr["KodYechida"].ToString());
            //    list.Add(item);
            //}
            //var manager = _container.Resolve<IBudgetManager>();
            //var namelist = manager.GetYechidot(startsWith);

            //return Json(namelist, JsonRequestBehavior.AllowGet);
            return Json(yechidot, JsonRequestBehavior.AllowGet);
        }

        public FilterModel GetFilter()
        {
            FilterModel vm = new FilterModel();

            var months = GetMonthsBackList(6);
            vm.Months = new SelectList(months, "Id", "Val");
            vm.SelectedMonth = months[0].Id;
            //FilterViewModel vm = new FilterViewModel(months);
            //vm.Month = DateTime.Parse(months[0].Id);

            IGeneralManager Gmanager = _container.Resolve<IGeneralManager>();

            var taarich = Gmanager.GetLastDateIdkunBank(((GeneralObject)Session["GeneralDetails"]).CurMonth);
            if (taarich != DateTime.MinValue)
            {
                vm.LastDateIdkunBank = taarich;// Gmanager.GetLastDateIdkunBank(((GeneralObject)Session["GeneralDetails"]).CurMonth);
                vm.LastDateIdkunBankStr = string.Concat("יום ", DateHelper.getDayHeb(vm.LastDateIdkunBank.AddDays(-1)), " ,", vm.LastDateIdkunBank.AddDays(-1).ToShortDateString());

                //if (DateTime.Now <LastDateIdkunBank && CurrentUser.GetSugPeilutHatshaa("Budget") == eSugPeiluHarshaa.Update)
                //    vm.IsMonthToEdit = true;
                TimeSpan span = vm.LastDateIdkunBank - (DateTime.Now.AddDays(-1));
                int numDays = span.Days;
                vm.NumDays = "";
                if (numDays > 1)
                    vm.NumDays = string.Concat("עוד ", numDays, " ימים");
                else if (numDays == 1)
                    vm.NumDays = "היום";
            }
            else
            {
                vm.LastDateIdkunBankStr = "";
                vm.NumDays = "";
            }

            return vm;

        }
      /// <summary>
      /// ////////////////////////////////////////////////////////////////
      /// </summary> 
        public void RecommenceSession()
        {
            //    HomeViewModel vm = new HomeViewModel();
            var user = CurrentUser;
            if (user != null)
            {
               
                GeneralObject obj = Session["GeneralDetails"] as GeneralObject;
                obj.CurYechida = obj.CurYechida;// user.Yechidot[0];
                obj.CurMonth = obj.CurMonth;// DateTime.Parse("01/" + DateTime.Now.ToString("MM/yyyy"));
                Session["GeneralDetails"] = obj;
            }
          //  return RedirectToAction("Index", "Home", new { error = "session end" });
            //   return View(vm);
        }

        public UserInfo CurrentUser
        {
            get 
            {
                var secValidator = _container.Resolve<SecurityValidator>();
                return secValidator.GetOrCreateCurrentUser(HttpContext.User);
            }
           
        } 
	}
}