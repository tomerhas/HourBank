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
            
            ChangesMainViewModel vmResult = InitChangesVm();
            GeneralObject obj = (GeneralObject)Session["GeneralDetails"];
            vmResult.Changes = ChangesShaotNosafot(1, obj.CurYechida.KodYechida, obj.CurMonth);
            Session["ChangesGrid"] = vmResult.Changes;
            return View(vmResult);

          //**  ChangesMainViewModel vm = InitChangesVm();
         
          //**  return View(vm);
        }

        private ChangesMainViewModel InitChangesVm()
        {
           // var months = GetMonthsBackList(6);
            ChangesMainViewModel vm = new ChangesMainViewModel();
           // List<TeurEzor> ezors = GetEzorList();
           // vm.Ezors = new SelectList(ezors, "KOD_EZOR", "TEUR_EZOR");
           //// vm.MitkanBudgetDetail = new Budget();
           // return vm;
            return new ChangesMainViewModel();
        }


        [HttpPost]
        public ActionResult Index(ChangesMainViewModel vm)
        {
            
            ChangesMainViewModel vmResult = InitChangesVm();
            //vmResult.KodEzor = vm.SelectedEzor != null ? int.Parse(vm.SelectedEzor) : 0;
            //vmResult.SelectedEzor = vm.SelectedEzor;

            //var manager = _container.Resolve<IBudgetManager>();
            //if (vm.MitkanName != null)
            //{
            //    var pirteyMitkan = manager.GetYechidaByName(vm.MitkanName);
            //    if (pirteyMitkan != null)
            //        vmResult.KodMitkan = pirteyMitkan.KodYechida;
            //}
            //vmResult.MitkanName = vm.MitkanName;
            //vmResult.SelectedMonth = vm.SelectedMonth;
            //vmResult.Month = DateTime.Parse(vm.SelectedMonth);
            GeneralObject obj = (GeneralObject)Session["GeneralDetails"];
            vmResult.Changes = ChangesShaotNosafot(1, obj.CurYechida.KodYechida, obj.CurMonth);
            Session["ChangesGrid"] = vmResult.Changes;
            return View(vmResult);
        }

        private List<BudgetChangesGrid> ChangesShaotNosafot(int KodEzor, int KodMitkan, DateTime Month)
        {
           var ManagerChange = _container.Resolve<IChangesManager>();
           var Changes = ManagerChange.GetChangesShaotNosafot(KodEzor,  KodMitkan,  Month);
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
            List<BudgetChangesGrid> employees = (List<BudgetChangesGrid>)(Session["ChangesGrid"]);
           
            var listMitkan = employees
                .Where(x => x.Mitkan.ToString().StartsWith(startsWith))
                .Select(x => x.Mitkan).ToList();

            listMitkan.Sort();
            return Json(listMitkan, JsonRequestBehavior.AllowGet);
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