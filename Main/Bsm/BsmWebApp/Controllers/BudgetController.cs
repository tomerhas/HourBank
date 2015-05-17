using BsmCommon.DataModels;
using BsmCommon.DataModels.Budgets;
using BsmCommon.DataModels.Employees;
using BsmCommon.Interfaces.Managers;
using BsmWebApp.Infrastructure.Security;
using BsmWebApp.ViewModels.Budgets;
using Kendo.Mvc.UI;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Microsoft.Reporting.WebForms;
using Egged.Infrastructure.Attribute;
using BsmWebApp.ViewModels.Reports;
using System.Configuration;

namespace BsmWebApp.Controllers
{
    public class BudgetController : BaseController
    {
        public BudgetController(IUnityContainer container)
            : base(container)
        {

        }
       // [PageAuthorize("aaa.aspx")]
        public ActionResult Index()
        {         
            BudgetMainViewModel vm = InitBudgetVm();

            return View(vm);
        }

      //[MultipleButton(Name = "action", Argument = "Index")]
        [HttpPost]
        public ActionResult Index(BudgetMainViewModel vm)
        {
            DateTime month = DateTime.Parse(vm.SelectedMonth);

            var manager = _container.Resolve<IBudgetManager>();
            var pirteyMitkan = manager.GetYechidaByName(vm.MitkanName);
            if (pirteyMitkan != null)
            {
                IGeneralManager Gmanager = _container.Resolve<IGeneralManager>();
                long bakasha_id = Gmanager.GetLastBakasha(month);

                BudgetMainViewModel vmResult = GetBudgetDetailForMitkan(pirteyMitkan.KodYechida, month, bakasha_id);
                vmResult.MitkanName = vm.MitkanName;
                vmResult.SelectedMonth = vm.SelectedMonth;
                vmResult.UsersInMitkan = GetEmployeesInMitkan(pirteyMitkan.KodYechida, month,bakasha_id);
                //vmResult.ReportVM = GetReportDetails();
                return View(vmResult);
            }
            else
            {
                BudgetMainViewModel view = InitBudgetVm();

                return View(view);
            }
        }

     
       
       [HttpGet]
        public ActionResult GetReportNochechut(int MisparIshi, string chodesh) //int KodYechida,DateTime chodesh)
        {

            ReportingServicesReportViewModel model = new ReportingServicesReportViewModel(
            "Presence",
            new List<Microsoft.Reporting.WebForms.ReportParameter>()
              { 
                new Microsoft.Reporting.WebForms.ReportParameter("P_MISPAR_ISHI",MisparIshi.ToString(),false) ,
                new Microsoft.Reporting.WebForms.ReportParameter("P_STARTDATE", DateTime.Parse(chodesh).ToShortDateString(),false),
                new Microsoft.Reporting.WebForms.ReportParameter("P_ENDDATE", DateTime.Parse(chodesh).AddMonths(1).AddDays(-1).ToShortDateString(),false)
              });

            ViewBag.ReportViewer = model.ReportViewer;
            ViewBag.NameReport = "דו''ח נוכחות לעובד";
            return View("~/Views/Report/ViewReport.cshtml");
        }

        //[MultipleButton(Name = "action", Argument = "Nochechut")]
        //[HttpPost]
        //public ActionResult GetNochechut(object a)
        // {
        //     ReportingServicesReportViewModel model = new ReportingServicesReportViewModel(
        //     "ReportPath",
        //     new List<Microsoft.Reporting.WebForms.ReportParameter>()
        //      { 
        //        new Microsoft.Reporting.WebForms.ReportParameter("P_MISPAR_ISHI","75757",false) ,
        //        new Microsoft.Reporting.WebForms.ReportParameter("P_STARTDATE", DateTime.Now.AddDays(-1).ToShortDateString(),false),
        //        new Microsoft.Reporting.WebForms.ReportParameter("P_ENDDATE", DateTime.Now.ToShortDateString(),false)
        //      });

        //      return View("ViewReport", model);
        //     //ReportViewer reportViewer = new ReportViewer();
        //    // return View();
        // }

        private UsersInMitkanViewModel GetEmployeesInMitkan(int KodYechida, DateTime month, long bakasha_id)
        {

            //var manager = _container.Resolve<IBudgetManager>();
            //var employees = manager.GetBudgetEmployees(KodYechida, month);
            //UsersInMitkanViewModel vm = new UsersInMitkanViewModel();
            //employees.ForEach(x => vm.Employees.Add(new UserInMitkanVM(x)));
            //return vm;

            var manager = _container.Resolve<IBudgetManager>();
            var employees = manager.GetEmployeeDetails(KodYechida, month, bakasha_id);
            UsersInMitkanViewModel vm = new UsersInMitkanViewModel();
            vm.Employees = employees;
            Session["EmployeesGrid"] = vm.Employees;
           // employees.ForEach(x => vm.Employees.Add(new UserInMitkanVM(x)));
            return vm;
        }
        //private List<MonthHolder> GetMonthsBackList(int kodParam)
        //{
        //    var manager = _container.Resolve<IBudgetManager>();
        //    return manager.GetMonthsBack(kodParam);
        //}

        public ActionResult EmployeesInMitkanRead([DataSourceRequest]DataSourceRequest request, int KodYechida, DateTime month, long bakasha_id)
        {
            var employeesContainer = GetEmployeesInMitkan(KodYechida, month, bakasha_id);
            return Json(employeesContainer.Employees.ToDataSourceResult(request));
        }

        public ActionResult EmployeesInMitkanUpdate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<BudgetEmployeeGrid> employees)
        {
            employees.ToList().ForEach(employee => 
            {
                var val = employee.MichsaCur;
            });
            return Json(employees.ToDataSourceResult(request));
        }
 

        private BudgetMainViewModel GetBudgetDetailForMitkan(int kodMitkan, DateTime dateTime, long bakasha_id)
        {

            Budget mb = _container.Resolve<IBudgetManager>().GetBudget(kodMitkan, dateTime, bakasha_id);
            BudgetMainViewModel vm = InitBudgetVm();
            vm.MitkanBudgetDetail = mb;
            vm.KodMitkan = kodMitkan;
            vm.Month = dateTime;
            vm.BakashaId = bakasha_id;
            vm.IsMitkanBudgetDetailEmpty = false;

            return vm;
        }


        private BudgetMainViewModel InitBudgetVm()
        {
            var months = GetMonthsBackList(6);
            BudgetMainViewModel vm = new BudgetMainViewModel(months);
            vm.MitkanBudgetDetail = new Budget();
            return vm;
        }

        public ActionResult CreateNochechutRdl(int ovedId)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult DispalyChanges(int KodYechida, string chodesh) //int KodYechida,DateTime chodesh)
        {
         
            var manager = _container.Resolve<IChangesManager>();
            var changes = manager.GetBudgetChanges(KodYechida,DateTime.Parse(chodesh));

            BudgetChangesVM vm = new BudgetChangesVM();
            vm.kod_mitkan = KodYechida;
            vm.month = DateTime.Parse(chodesh);
            changes.ForEach(x => vm.BudgetChanges.Add(new BudgetChangeVM(x)));
            //יוצרים פה  viewmodelמודל ומעבירים אותו
              
            //var res = PartialView("_DisplayChangesPopUp");
           // return res;
            return  PartialView("_DisplayChangesPopUp",vm);
        }

        public JsonResult GetMisparIshiWith(string startsWith) //, int kod, DateTime tarrich)
        {
            int inpValidate = -1;
            if (!int.TryParse(startsWith, out inpValidate))
            {
                return Json(new List<int>(), JsonRequestBehavior.AllowGet);
            }

            List<BudgetEmployeeGrid> employees = (List<BudgetEmployeeGrid>)(Session["EmployeesGrid"]);
            var listIds = employees
                .Where(x => x.MisparIshi.ToString().StartsWith(startsWith))
                .Select(x => x.MisparIshi).ToList();
    
            return Json(listIds, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOvdimNameWith(string startsWith)
        {
            var manager = _container.Resolve<IBudgetManager>();
           // var namelist = manager.GetOvdimNameStartWith(startsWith);

            List<BudgetEmployeeGrid> employees = (List<BudgetEmployeeGrid>)(Session["EmployeesGrid"]);
            var namelist = employees
                .Where(x => x.FullName.ToString().StartsWith(startsWith))
                .Select(x => x.FullName).ToList();
    

            return Json(namelist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOvedIdByName(string sName)
        {
            List<BudgetEmployeeGrid> employees = (List<BudgetEmployeeGrid>)(Session["EmployeesGrid"]);
            var listIds = employees
                .Where(x => x.FullName==sName)
                .Select(x => x.MisparIshi).ToList();

            return Json(listIds, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOvedNameById(string id)
        {
            List<BudgetEmployeeGrid> employees = (List<BudgetEmployeeGrid>)(Session["EmployeesGrid"]);
            var listIds = employees
                .Where(x => x.MisparIshi.ToString() == id)
                .Select(x => x.FullName).ToList();

            return Json(listIds, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult GetDashboardData([DataSourceRequest] DataSourceRequest request)
        //{
        //    var manager = _container.Resolve<IBudgetManager>();

        //    var dt = manager.getEmployeeDetails(87783, DateTime.Parse("01/04/2015"), 19009);
        //    string JsonResult = JsonConvert.SerializeObject(dt, Formatting.Indented);
        //    return  Json(JsonResult, JsonRequestBehavior.AllowGet);
        //}
	}
}