using BsmCommon.DataModels;
using BsmCommon.Interfaces.Managers;
using BsmWebApp.ViewModels.Changes;
using Kendo.Mvc.UI;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BsmWebApp.Controllers
{
    public class ChangesController : BaseController
    {
        public ChangesController(IUnityContainer container)
            : base(container)
        {

        }
        //// [PageAuthorize("aaa.aspx")]
        public ActionResult Index()
        {
            ChangesMainViewModel vm = InitChangesVm();
            List<Ezor> ezors = GetEzorList();
            vm.Ezors = new SelectList(ezors, "KOD_EZOR", "TEUR_EZOR");
            return View(vm);
        }

        private ChangesMainViewModel InitChangesVm()
        {
            var months = GetMonthsBackList(6);
            ChangesMainViewModel vm = new ChangesMainViewModel(months);
           // vm.MitkanBudgetDetail = new Budget();
            return vm;
        }

      


    }
   
}