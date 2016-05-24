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
using Egged.Infrastructure.Menus.DataModels;
using BsmCommon.Helpers;
using BsmCommon.UDT;
using BsmWebApp.Infrastructure;
using BsmCommon.Enums;
using InfrastructureLogs.Logs.Interfaces;
using InfrastructureLogs.Logs.DataModels;
using Egged.Infrastructure.Helpers;

namespace BsmWebApp.Controllers
{
    public class BudgetController : BaseController
    {
        public BudgetController(IUnityContainer container)
            : base(container)
        {
            SelectdMenu = MenuTypes.MamagementHourExtenstions;
        }

        [PageAuthorize("Budget")]
        public ActionResult Index()
        {
            
            BudgetMainViewModel vm = InitBudgetVm();
            InitFilterChash();
            return View(vm);
        }

       

        [HttpPost]
        public ActionResult Index(FilterModel vm)
        {
            var x = 0;
            DateTime month = DateTime.Parse(vm.SelectedMonth);
            var objMitkan = ((FilterCachedViewModel)Session["GeneralDetails"]).CurYechida;
            var curMitkan = objMitkan.KodYechida;//**CurrentUser.CurYechida.KodYechida;
            var manager = _container.Resolve<IBudgetManager>();
            if (curMitkan > 0)
            {
                double totalMsToExecute = 0;
                 IGeneralManager Gmanager = _container.Resolve<IGeneralManager>();
               // long bakasha_id = Gmanager.GetLastBakashaOfTeken(month);
                 BudgetMainViewModel vmResult = null;
                 totalMsToExecute = StopwatchHelper.TimedAction<BudgetMainViewModel>(() => GetBudgetDetailForMitkan(curMitkan, month), out vmResult);
                 _container.Resolve<ILogger>().Log(string.Format("BudgetController.Index: Total ms to GetBudgetDetailForMitkan is {0}", totalMsToExecute), Category.Info);
                ////if (bakasha_id != null)
                ////    vmResult.LastBakashaDate = Gmanager.GetZmanBakasha(bakasha_id);
                ////vmResult.MitkanName = vm.MitkanName;
                vmResult.Filter.SelectedMonth = vm.SelectedMonth;
                vmResult.KodMitkan = curMitkan;
                vmResult.MitkanName = objMitkan.TeurYechida;
                vmResult.Month = month;
                UsersInMitkanViewModel res = null;
                totalMsToExecute = StopwatchHelper.TimedAction<UsersInMitkanViewModel>(()=> GetEmployeesInMitkan(curMitkan, month),out res);
                _container.Resolve<ILogger>().Log(string.Format("BudgetController.Index: Total ms to GetEmployeesInMitkan is {0}",totalMsToExecute), Category.Info);
                vmResult.UsersInMitkan = res;
                if (DateTime.Now < vmResult.Filter.LastDateIdkunBank && CurrentUser.GetSugPeilutHatshaa("Budget") == eSugPeiluHarshaa.Update)
                    vmResult.IsMonthToEdit = true;
                if (vmResult.MitkanBudgetDetail !=null && vmResult.UsersInMitkan != null && vmResult.UsersInMitkan.Employees.Count > 0)
                {
                    vmResult.ShouldDisplayMessage = 0;
                }
                else
                {
                    vmResult.ShouldDisplayMessage = 1;
                }
               
                //vmResult.ReportVM = GetReportDetails();
                return View(vmResult);
            }
            else
            {
                BudgetMainViewModel view = InitBudgetVm();

                return View(view);
            }
        }

        private BudgetMainViewModel InitBudgetVm()
        {

            var months = GetMonthsBackList(6);
            BudgetMainViewModel vm = new BudgetMainViewModel();
            vm.MitkanBudgetDetail = new Budget();
           // vm.Month = DateTime.Parse(months[0].Id);

            vm.Filter = GetFilter();
            vm.Month =  DateTime.Parse(vm.Filter.SelectedMonth);
            ////IGeneralManager Gmanager = _container.Resolve<IGeneralManager>();

            ////var taarich = Gmanager.GetLastDateIdkunBank(((FilterCachedViewModel)Session["GeneralDetails"]).CurMonth);
            ////if (taarich != DateTime.MinValue)
            ////{
            ////    vm.LastDateIdkunBank = taarich;// Gmanager.GetLastDateIdkunBank(((FilterCachedViewModel)Session["GeneralDetails"]).CurMonth);
            ////    vm.LastDateIdkunBankStr = string.Concat("יום ", DateHelper.getDayHeb(vm.LastDateIdkunBank.AddDays(-1)), " ,", vm.LastDateIdkunBank.AddDays(-1).ToShortDateString());

            ////    if (DateTime.Now < vm.LastDateIdkunBank && CurrentUser.GetSugPeilutHatshaa("Budget") == eSugPeiluHarshaa.Update)
            ////        vm.IsMonthToEdit = true;
            ////    TimeSpan span = vm.LastDateIdkunBank - (DateTime.Now.AddDays(-1));
            ////    int numDays = span.Days;
            ////    vm.NumDays = "";
            ////    if (numDays > 1)
            ////        vm.NumDays = string.Concat("עוד ", numDays, " ימים");
            ////    else if (numDays == 1)
            ////        vm.NumDays = "היום";
            ////}
            ////else
            ////{
            ////    vm.LastDateIdkunBankStr = "";
            ////    vm.NumDays = "";
            ////}

            return vm;
        }


        private BudgetMainViewModel GetBudgetDetailForMitkan(int kodMitkan, DateTime dateTime)
        {

            Budget mb = _container.Resolve<IBudgetManager>().GetBudgetDetails(kodMitkan, dateTime);
            BudgetMainViewModel vm = InitBudgetVm();
            vm.MitkanBudgetDetail = mb;
            //vm.KodMitkan = kodMitkan;
            //vm.Month = dateTime;
            //vm.BakashaId = bakasha_id;
            if(mb != null)
                vm.IsMitkanBudgetDetailEmpty = false;

            return vm;
        }

        public ActionResult EmployeesInMitkanRead([DataSourceRequest]DataSourceRequest request, int KodYechida, DateTime month)
        {
         
            List<BudgetEmployeeGrid> employees = (List<BudgetEmployeeGrid>)(Session["EmployeesGrid"]);
            List<BudgetEmployeeGrid> SortedEmployees = employees.OrderBy(o => o.MisparIshi).ToList();
            return Json(SortedEmployees.ToDataSourceResult(request));
           // var employeesContainer = GetEmployeesInMitkan(KodYechida, month);
           // return Json(employeesContainer.Employees.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult EmployeesInMitkanUpdate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<BudgetEmployeeGrid> employees ,int KodYechida, DateTime month)
        {
            int meadken;
            try
            {
                meadken = !string.IsNullOrEmpty(CurrentUser.EmployeeNumber) ? int.Parse(CurrentUser.EmployeeNumber) : 0; 

                COLL_BUDGET_EMPLOYEES_MICHSA oCollBudgetMichsa = new COLL_BUDGET_EMPLOYEES_MICHSA();
                employees.ToList().ForEach(employee =>
                {
                    OBJ_BUDGET_EMPLOYEES_MICHSA objBudgetMichsa = new OBJ_BUDGET_EMPLOYEES_MICHSA();
                    objBudgetMichsa.MISPAR_ISHI = employee.MisparIshi;
                    objBudgetMichsa.CHODESH = month;
                    objBudgetMichsa.MICHSA = employee.MichsaCur;
                    objBudgetMichsa.MEADKEN = meadken;
                    oCollBudgetMichsa.Add(objBudgetMichsa);
                    employee.MichsaMakor = employee.MichsaCur;
                });


                var budget = _container.Resolve<IBudgetManager>();
                var code = budget.SaveEmployeeMichsot(KodYechida, meadken, oCollBudgetMichsa);
               

                if (code == 1)
                    ModelState.AddModelError(string.Empty, "ארעה שגיאה בשמירת נתונים, אנא פנה למנהל מערכת");
                else
                {
                    budget.SaveBudgetLeft(KodYechida, month, meadken);
                    ModelState.AddModelError(string.Empty, "הנתונים נשמרו בהצלחה");
                }
               return Json(employees.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
                 }
            catch(Exception ex)
            {

                ModelState.AddModelError(string.Empty, "ארעה שגיאה בשמירת נתונים, אנא פנה למנהל מערכת");
                return Json(employees.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
  
                //return this.Json(new DataSourceResult
                //{ 
                //    Errors = ex.Message
                //});
            }
        }

        private UsersInMitkanViewModel GetEmployeesInMitkan(int KodYechida, DateTime month)
        {

            //var manager = _container.Resolve<IBudgetManager>();
            //var employees = manager.GetBudgetEmployees(KodYechida, month);
            //UsersInMitkanViewModel vm = new UsersInMitkanViewModel();
            //employees.ForEach(x => vm.Employees.Add(new UserInMitkanVM(x)));
            //return vm;

            var manager = _container.Resolve<IBudgetManager>();
            var employees = manager.GetEmployeeDetails(KodYechida, month);
            UsersInMitkanViewModel vm = new UsersInMitkanViewModel();
            vm.Employees = employees;
            Session["EmployeesGrid"] = vm.Employees;
            // employees.ForEach(x => vm.Employees.Add(new UserInMitkanVM(x)));
            return vm;
        }

        public ActionResult GetAllocatedHoursType()
        {
            return PartialView("_AutomaticAllocating", null);
        }

        public ActionResult GetInformationBudget()
        {
            var manager = _container.Resolve<IChangesManager>();
            var budget = _container.Resolve<IBudgetManager>();
            //String.Format("{0:0.0}", decimal.Parse(row["Takziv"].ToString()));
            BudgetChangesVM vm = new BudgetChangesVM();
            List<BudgetChangeVM> list = new List<BudgetChangeVM>();
            
            var curMitkan = ((FilterCachedViewModel)Session["GeneralDetails"]);
            int KodYechida = curMitkan.CurYechida.KodYechida;
            DateTime chodesh=curMitkan.CurMonth;

            vm.Budget = budget.GetBudgetDetails(KodYechida, chodesh);
            vm.YitraPrevMonth = budget.GetBudgetLeftForMitkan(KodYechida, chodesh.AddMonths(-1));
            vm.Budget.BudgetLefiTeken = decimal.Parse(String.Format("{0:0.0}", vm.Budget.BudgetLefiTeken));
            
           var changes = manager.GetBudgetChanges(KodYechida, chodesh);
            changes.ForEach(x => list.Add(new BudgetChangeVM(x)));
            vm.BudgetChanges= list.OrderBy(c => c.BudgetChange.TaarichIdkun).ToList();

            vm.SumChanges =  manager.GetExtensionsBudget(KodYechida, chodesh).Sum(x => x.Amount) - manager.GetReductionsBudget(KodYechida, chodesh).Sum(x => x.Amount);
            if(vm.BudgetChanges.Count>0)
                vm.SachNiyud =  vm.BudgetChanges.Where(b => b.BudgetChange.ToYechida == KodYechida).Sum(x => x.BudgetChange.Val) - vm.BudgetChanges.Where(b => b.BudgetChange.FromYechida == KodYechida).Sum(x => x.BudgetChange.Val);
            return PartialView("_BudgetInformation", vm);
        }
       //[HttpGet]
       // public ActionResult GetReportNochechut(int MisparIshi, string chodesh) //int KodYechida,DateTime chodesh)
       // {

       //     ReportingServicesReportViewModel model = new ReportingServicesReportViewModel(
       //     "Presence",
       //     new List<Microsoft.Reporting.WebForms.ReportParameter>()
       //       { 
       //         new Microsoft.Reporting.WebForms.ReportParameter("P_MISPAR_ISHI",MisparIshi.ToString(),false) ,
       //         new Microsoft.Reporting.WebForms.ReportParameter("P_STARTDATE", DateTime.Parse(chodesh).ToShortDateString(),false),
       //         new Microsoft.Reporting.WebForms.ReportParameter("P_ENDDATE", DateTime.Parse(chodesh).AddMonths(1).AddDays(-1).ToShortDateString(),false)
       //       });

       //     ViewBag.ReportViewer = model.ReportViewer;
       //     ViewBag.NameReport = "דו''ח נוכחות לעובד";
       //     return View("~/Views/Report/ViewReport.cshtml");
       // }

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

     
        //private List<MonthHolder> GetMonthsBackList(int kodParam)
        //{
        //    var manager = _container.Resolve<IBudgetManager>();
        //    return manager.GetMonthsBack(kodParam);
        //}

      
 

    

        /*****************************************************************************/

        //public ActionResult CreateNochechutRdl(int ovedId)
        //{
        //    return RedirectToAction("Index");
        //}




        [HttpGet]
        public PartialViewResult DispalyChanges(int KodYechida, string chodesh) //int KodYechida,DateTime chodesh)
        {
         
            var manager = _container.Resolve<IChangesManager>();
           //** var changes = manager.GetHistory(KodYechida,DateTime.Parse(chodesh));

            BudgetChangesVM vm = new BudgetChangesVM();
            vm.ChangesHistory = manager.GetHistory(KodYechida, DateTime.Parse(chodesh)); 
          //  vm.kod_mitkan = KodYechida;
          //  vm.month = DateTime.Parse(chodesh);
           //** changes.ForEach(x => vm.BudgetChanges.Add(new BudgetChangeVM(x)));
            //יוצרים פה  viewmodelמודל ומעבירים אותו
              
            //var res = PartialView("_DisplayChangesPopUp");
           // return res;
            return  PartialView("_DisplayChangesPopUp",vm);
        }

        public JsonResult GetMisparIshiWith(string str) //, int kod, DateTime tarrich)
        {
            int inpValidate = -1;
            List<BudgetEmployeeGrid> employees = (List<BudgetEmployeeGrid>)(Session["EmployeesGrid"]);
            if (!int.TryParse(str, out inpValidate))
            {
                var namelist = employees
                    .Where(x => x.FullName.ToString().StartsWith(str)) //Contains(str))
                    .Select(x => x.FullName).ToList();
                namelist.Sort();

                return Json(namelist, JsonRequestBehavior.AllowGet);
            }
            else
            {
              
                var listIds = employees
                    .Where(x => x.MisparIshi.ToString().StartsWith(str)) //Contains(str))
                    .Select(x => x.MisparIshi).ToList();

                listIds.Sort();
                return Json(listIds, JsonRequestBehavior.AllowGet);
            }
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