using BsmCommon.DataModels;
using BsmCommon.DataModels.Changes;
using BsmCommon.Interfaces.Managers;
using BsmWebApp.ViewModels.Changes;
using Kendo.Mvc.UI;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using BsmWebApp.Infrastructure.Security;
using Egged.Infrastructure.Menus.DataModels;
using BsmWebApp.ViewModels;
using BsmCommon.Enums;


namespace BsmWebApp.Controllers
{
    public class ChangesController : BaseController
    {
        public ChangesController(IUnityContainer container)
            : base(container)
        {
            SelectdMenu = MenuTypes.HourChanges;
        }
        [PageAuthorize("Changes")]
        public ActionResult Index()
        {

            ChangesMainViewModel vmResult = new ChangesMainViewModel();// InitChangesVm();
        
            vmResult.Filter = GetFilter();
            vmResult.Filter.ShowEzor = true;
            vmResult.Page = "Changes";
            return View(vmResult);

          //**  ChangesMainViewModel vm = InitChangesVm();
         
          //**  return View(vm);
        }

        //private ChangesMainViewModel InitChangesVm()
        //{
        //   // var months = GetMonthsBackList(6);
        //    ChangesMainViewModel vm = new ChangesMainViewModel();
        //   // List<TeurEzor> ezors = GetEzorList();
        //   // vm.Ezors = new SelectList(ezors, "KOD_EZOR", "TEUR_EZOR");
        //   //// vm.MitkanBudgetDetail = new Budget();
        //   // return vm;
        //    return new ChangesMainViewModel();
        //}


        [HttpPost]
        public ActionResult Index(FilterModel vm)
        {

            ChangesMainViewModel vmResult = new ChangesMainViewModel();  //InitChangesVm();

            GeneralObject obj = (GeneralObject)Session["GeneralDetails"];
            vmResult.Changes = GetChangesShaotNosafot(vm.SelectedEzor, obj.CurMonth,CurrentUser.PirteyUser.Isuk, CurrentUser.PirteyUser.YechidaIrgunit);
            Session["ChangesGrid"] = vmResult.Changes;
            vmResult.Filter = GetFilter();
            vmResult.Filter.ShowEzor = true;
            vmResult.Filter.SelectedMonth = vm.SelectedMonth ;

            if (DateTime.Now < vmResult.Filter.LastDateIdkunBank && CurrentUser.GetSugPeilutHatshaa("Changes") == eSugPeiluHarshaa.Update)
                vmResult.IsMonthToEdit = true;
            
            if (vmResult.Changes != null && vmResult.Changes.Count > 0)
            {
                vmResult.ShouldDisplayMessage = 0;
            }
            else
            {
                vmResult.ShouldDisplayMessage = 1;
            }

            return View(vmResult);
        }

        private List<BudgetChangesGrid> GetChangesShaotNosafot(int KodEzor, DateTime Month,int isuk , int KodMitkan)
        {
           var ManagerChange = _container.Resolve<IChangesManager>();
           var Changes = ManagerChange.GetChangesShaotNosafot(KodEzor, Month, isuk, KodMitkan);
           return Changes;
        }

        public ActionResult ChangesMitkanRead([DataSourceRequest]DataSourceRequest request)
        {

            List<BudgetChangesGrid> changes = (List<BudgetChangesGrid>)(Session["ChangesGrid"]);
           // List<BudgetEmployeeGrid> SortedEmployees = employees.OrderBy(o => o.MisparIshi).ToList();
            return Json(changes.ToDataSourceResult(request));
            // var employeesContainer = GetEmployeesInMitkan(KodYechida, month);
            // return Json(employeesContainer.Employees.ToDataSourceResult(request));
        }

        public JsonResult GetMitkanStartWith(string startsWith) //, int kod, DateTime tarrich)
        {
            List<BudgetChangesGrid> changes = (List<BudgetChangesGrid>)(Session["ChangesGrid"]);
           
            var listMitkan = changes
                .Where(x => x.Teur_Yechida.ToString().StartsWith(startsWith))
                .Select(x => x.Teur_Yechida).ToList();

            listMitkan.Sort();
            return Json(listMitkan, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddBudget()
        {
            AddBudgetViewModel vm = new AddBudgetViewModel();
            var ManagerChange = _container.Resolve<IChangesManager>();
            //vm.Yechidot= CurrentUser.Yechidot
            vm.Yechidot = new SelectList(CurrentUser.Yechidot, "KodYechida", "TeurYechida");
            vm.Yechida = CurrentUser.Yechidot[0];
            var bs = ManagerChange.GetBudgetSpecial();
            foreach (BudgetSpecial b in bs)
            {
                b.Description = b.Description + "("+ b.MisparTakziv+")";
            }
            vm.Budgets = new SelectList(bs, "MisparTakziv", "Description");
            vm.budget = bs[0];
            return PartialView("_AddBudget", vm);
        }

        public ActionResult MoveBudget()
        {
            AddBudgetViewModel vm = new AddBudgetViewModel();
            var ManagerChange = _container.Resolve<IChangesManager>();
            //vm.Yechidot= CurrentUser.Yechidot
            vm.Yechidot = new SelectList(CurrentUser.Yechidot, "KodYechida", "TeurYechida");
            vm.Yechida = CurrentUser.Yechidot[0];
         
            return PartialView("_NiyudTakziv", vm);
        }

        public ActionResult RemoveBudget()
        {
            AddBudgetViewModel vm = new AddBudgetViewModel();
            var ManagerChange = _container.Resolve<IChangesManager>();
            //vm.Yechidot= CurrentUser.Yechidot
            vm.Yechidot = new SelectList(CurrentUser.Yechidot, "KodYechida", "TeurYechida");
            vm.Yechida = CurrentUser.Yechidot[0];
           
            return PartialView("_GriatTakziv", vm);
        }
        public ActionResult AddNewBudget()
        {
            return PartialView("_AddNewBudget", null);
        }
        //public ActionResult ChangesShaotNosafotRead([DataSourceRequest]DataSourceRequest request, int KodEzor, int KodYechida, DateTime month)
        //{
        //    var Changes = ChangesShaotNosafot(KodEzor, KodYechida, month);
        //    return Json(Changes.ToDataSourceResult(request));
        //}

        //public ActionResult ChangesShaotNosafotCreate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<BudgetChangesGrid> changes)
        //{
        //    //   var Changes = ChangesShaotNosafot(KodEzor, KodYechida, month);

        //    return Json(changes.ToDataSourceResult(request, ModelState, ch => new BudgetChangesGrid
        //    {
        //        Masad=2,
        //        Reason="fff"             
        //    }));
        //}

        //public ActionResult ChangesShaotNosafotUpdate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<BudgetChangesGrid> changes)
        //{
        //    changes.ToList().ForEach(change =>
        //    {
        //        var val = change.Reason;
        //    });
        //    return Json(changes.ToDataSourceResult(request));
        //}

    }
   
}