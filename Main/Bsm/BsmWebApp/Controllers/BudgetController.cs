﻿using BsmCommon.DataModels;
using BsmCommon.DataModels.Budgets;
using BsmCommon.DataModels.Employees;
using BsmCommon.Interfaces.Managers;
using BsmWebApp.Infrastructure.Security;
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
       // [PageAuthorize("aaa.aspx")]
        public ActionResult Index()
        {         
            BudgetMainViewModel vm = InitBudgetVm();

            return View(vm);
        }
        [HttpPost]
        public ActionResult Index(BudgetMainViewModel vm)
        {
            DateTime month = DateTime.Parse(vm.SelectedMonth);

            var manager = _container.Resolve<IBudgetManager>();
            var pirteyMitkan = manager.GetYechidaByName(vm.MitkanName);
            BudgetMainViewModel vmResult = GetBudgetDetailForMitkan(pirteyMitkan.KodYechida, month);
            vmResult.MitkanName = vm.MitkanName;
            vmResult.UsersInMitkan = GetEmployeesInMitkan(pirteyMitkan.KodYechida, month);
            return View(vmResult);
        }


        private UsersInMitkanViewModel GetEmployeesInMitkan(int KodYechida, DateTime month)
        {

            var manager = _container.Resolve<IBudgetManager>();
            var employees = manager.GetBudgetEmployees(KodYechida, month);
            UsersInMitkanViewModel vm = new UsersInMitkanViewModel();
            employees.ForEach(x=>vm.Employees.Add(new UserInMitkanVM(x)));
            return vm;
        }
        //private List<MonthHolder> GetMonthsBackList(int kodParam)
        //{
        //    var manager = _container.Resolve<IBudgetManager>();
        //    return manager.GetMonthsBack(kodParam);
        //}

        private BudgetMainViewModel GetBudgetDetailForMitkan(int kodMitkan, DateTime dateTime)
        {
           
            Budget mb = _container.Resolve<IBudgetManager>().GetBudget(kodMitkan, dateTime);
            BudgetMainViewModel vm = InitBudgetVm();
            vm.MitkanBudgetDetail = mb;
            vm.KodMitkan = kodMitkan;
            vm.Month = dateTime;
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
         
            var manager = _container.Resolve<IBudgetManager>();
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
	}
}