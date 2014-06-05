using BsmCommon.DataModels;
using BsmCommon.DataModels.Budgets;
using BsmCommon.Interfaces.Managers;
using BsmWebApp.ViewModels.Budgets;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BsmWebApp.Controllers
{
    public class BudgetController : BaseController
    {
        public BudgetController(IUnityContainer container)
            : base(container)
        {

        }
        
        public ActionResult Index()
        {
            BudgetMainViewModel vm = InitBudgetVm();

            return View(vm);
        }
        [HttpPost]
        public ActionResult Index(BudgetMainViewModel vm)
        {
            DateTime month = DateTime.Parse(vm.SelectedMonth);
            BudgetMainViewModel vmResult = GetBudgetDetailForMitkan(vm.MitkanName, month);
            vmResult.UsersInMitkan =  GetEmployeesInMitkan(vm.MitkanName, month);
            return View(vmResult);
        }

        private UsersInMitkanViewModel GetEmployeesInMitkan(string mitkanName, DateTime month)
        {
            var manager = _container.Resolve<IBudgetManager>();
            var employees =  manager.GetBudgetEmployees(int.Parse(mitkanName), month);
            UsersInMitkanViewModel vm = new UsersInMitkanViewModel();
            employees.ForEach(x=>vm.Employees.Add(new UserInMitkanVM(x)));
            return vm;
        }
        private List<MonthHolder> GetMonthsBackList(int kodParam)
        {
            var manager = _container.Resolve<IBudgetManager>();
            return manager.GetMonthsBack(kodParam);
        }

        private BudgetMainViewModel GetBudgetDetailForMitkan(string mitkanName, DateTime dateTime)
        {
            //TODO -manager to fill in the MitkanBudget
          //  Budget mb = new Budget() { BudgetHoursMounthly = 20, BudgetHoursRemender = 10, RemainHours = 8 };
            Budget mb = _container.Resolve<IBudgetManager>().GetBudget(int.Parse(mitkanName), dateTime);
            BudgetMainViewModel vm = InitBudgetVm();
            vm.MitkanBudgetDetail = mb;
            vm.MitkanName = mitkanName;
            vm.Month = dateTime;
            //var months = new List<string>() { "1", "2", "3" };
            //vm.FillMonths(months);
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
	}
}