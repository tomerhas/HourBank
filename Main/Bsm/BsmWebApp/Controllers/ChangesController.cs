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
            InitFilterChash();
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

            FilterCachedViewModel obj = (FilterCachedViewModel)Session["GeneralDetails"];
            if (vm.SelectedEzor != 0)
            {
                vmResult.Changes = GetChangesShaotNosafot(vm.SelectedEzor, obj.CurMonth, CurrentUser.PirteyUser.Isuk, CurrentUser.PirteyUser.YechidaIrgunit);
                ChangesCachedViewModel sessionVm = new ChangesCachedViewModel() { Changes = vmResult.Changes, SelectedEzor = vm.SelectedEzor, CurMonth = obj.CurMonth, Isuk = CurrentUser.PirteyUser.Isuk, YechidaIrgunit = CurrentUser.PirteyUser.YechidaIrgunit };

                Session["ChangesGrid"] = sessionVm;
                vmResult.Filter = GetFilter();
                vmResult.Filter.ShowEzor = true;
                vmResult.Filter.SelectedMonth = vm.SelectedMonth;

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
            else return Index();

           
        }
        [HttpPost]
        public void SaveBudget(SaveBudgetVM vm)
        {
            var month = ((FilterCachedViewModel)Session["GeneralDetails"]).CurMonth;
            var ManagerChange = _container.Resolve<IChangesManager>();
            ManagerChange.AddTakzivLeMitkan(vm.Mitkan, month, vm.Takziv, vm.Kamut, vm.Comment, CurrentUser.PirteyUser.MisparIshi);

            var budget = _container.Resolve<IBudgetManager>();
            budget.SaveBudgetLeft(vm.Mitkan, month, CurrentUser.PirteyUser.MisparIshi);
            //Update the grid session with new data
            var changesVm = (Session["ChangesGrid"]) as ChangesCachedViewModel;
            if (changesVm != null)
            {
                var changesGridRes = GetChangesShaotNosafot(changesVm.SelectedEzor, changesVm.CurMonth, changesVm.Isuk, changesVm.YechidaIrgunit);
                changesVm.Changes = changesGridRes;
            }
        }

        [HttpPost]
        public void SaveNewBudget(SaveBudgetVM vm)
        {
            var ManagerChange = _container.Resolve<IChangesManager>();
            ManagerChange.AddNewTakziv(vm.Takziv, vm.Name, vm.Kamut, vm.Comment, CurrentUser.PirteyUser.MisparIshi);
        }


        [HttpPost]
        public void SaveNiyudBudget(SaveBudgetVM vm)
        {
            var month = ((FilterCachedViewModel)Session["GeneralDetails"]).CurMonth;
            var ManagerChange = _container.Resolve<IChangesManager>();
            ManagerChange.SaveChangeMitkan(vm.MitkanOut,vm.Mitkan, month, vm.Kamut, vm.Comment, CurrentUser.PirteyUser.MisparIshi);
          //  ManagerChange.SaveChangeMitkan(vm.MitkanOut, month, vm.Kamut, vm.Comment, CurrentUser.PirteyUser.MisparIshi, (int)TypeChange.Reduction);
            var budget = _container.Resolve<IBudgetManager>();
            budget.SaveBudgetLeft(vm.Mitkan, month, CurrentUser.PirteyUser.MisparIshi);
            budget.SaveBudgetLeft(vm.MitkanOut, month, CurrentUser.PirteyUser.MisparIshi);
            //Update the grid session with new data
            var changesVm = (Session["ChangesGrid"]) as ChangesCachedViewModel;
            if (changesVm != null)
            {
                var changesGridRes = GetChangesShaotNosafot(changesVm.SelectedEzor, changesVm.CurMonth, changesVm.Isuk, changesVm.YechidaIrgunit);
                changesVm.Changes = changesGridRes;
            }
        }
        [HttpPost]
        public void ReductionBudget(SaveBudgetVM vm)
        {
            var month = ((FilterCachedViewModel)Session["GeneralDetails"]).CurMonth;
            var ManagerChange = _container.Resolve<IChangesManager>();
            ManagerChange.SaveReductionMitkan(vm.Mitkan, month, vm.Kamut, vm.Comment, CurrentUser.PirteyUser.MisparIshi);

            var budget = _container.Resolve<IBudgetManager>();
            budget.SaveBudgetLeft(vm.Mitkan, month, CurrentUser.PirteyUser.MisparIshi);
            //Update the grid session with new data
            var changesVm = (Session["ChangesGrid"]) as ChangesCachedViewModel;
            if (changesVm != null)
            {
                var changesGridRes = GetChangesShaotNosafot(changesVm.SelectedEzor, changesVm.CurMonth, changesVm.Isuk, changesVm.YechidaIrgunit);
                changesVm.Changes = changesGridRes;
            }
        }
        private List<BudgetChangesGrid> GetChangesShaotNosafot(int KodEzor, DateTime Month, int isuk, int KodMitkan)
        {
            var ManagerChange = _container.Resolve<IChangesManager>();
            var Changes = ManagerChange.GetChangesShaotNosafot(KodEzor, Month, isuk, KodMitkan);
            return Changes;
        }

        public ActionResult ChangesMitkanRead([DataSourceRequest]DataSourceRequest request)
        {
            if (Session["ChangesGrid"] != null)
            {
                List<BudgetChangesGrid> changes = ((ChangesCachedViewModel)(Session["ChangesGrid"])).Changes;
                return Json(changes.ToDataSourceResult(request));
            }
            return Json("{}");
        }

        public JsonResult GetMitkanStartWith(string startsWith) //, int kod, DateTime tarrich)
        {
            if (Session["ChangesGrid"] != null)
            {
                List<BudgetChangesGrid> changes = ((ChangesCachedViewModel)(Session["ChangesGrid"])).Changes;

                var listMitkan = changes
                    .Where(x => x.Teur_Yechida.ToString().StartsWith(startsWith))
                    .Select(x => x.Teur_Yechida).ToList();

                listMitkan.Sort();
                return Json(listMitkan, JsonRequestBehavior.AllowGet);
            }
            return Json("{}");
        }

        public ActionResult AddBudget(SaveBudgetVM sv)
        {
            AddBudgetViewModel vm = new AddBudgetViewModel();

            List<Yechida> yechidot = GetListYechidotForCombo();
            vm.Yechidot = new SelectList(yechidot, "KodYechida", "TeurYechida");
            if (sv.Mitkan != null && sv.Mitkan > 0)
            {
                Yechida ym = yechidot.FirstOrDefault(y => y.KodYechida == sv.Mitkan);
                vm.Yechida = ym;
            }
            else vm.Yechida = yechidot[0];


            List<BudgetSpecial> bs = GetListBudgetSpecialForCombo();
            vm.Budgets = new SelectList(bs, "MisparTakziv", "Description");
   
            if (sv.Takziv != null && sv.Takziv > 0)
            {
                BudgetSpecial bsp = bs.FirstOrDefault(b => b.MisparTakziv == sv.Takziv);
                vm.budget = bsp;
            }
            else vm.budget = bs[0];

            vm.Kamut = sv.Kamut;
            vm.Comment = sv.Comment;
            vm.AddNewSucceeded = sv.AddNewSucceeded;
            return PartialView("_AddBudget", vm);
        }

        private List<Yechida> GetListYechidotForCombo()
        {
            List<Yechida> yechidot = new List<Yechida>();// CurrentUser.Yechidot.ToList();
            decimal shaot;
            var ezor=0;
            var month = ((FilterCachedViewModel)Session["GeneralDetails"]).CurMonth;
            var budget = _container.Resolve<IBudgetManager>();

            Yechida yechida = new Yechida();
            yechida.KodHevra = 0;
            yechida.KodYechida = 0;
            yechida.TeurYechida = "בחר מתקן...";
            yechida.KodEzor = 0;
            yechida.SugYechida = "";
            yechidot.Insert(0, yechida);

            var filter = ((FilterCachedViewModel)Session["GeneralDetails"]); ;
            if (filter != null)
             {
                 ezor = filter.Ezor;
             }
            CurrentUser.Yechidot.ForEach((item) =>
            {
                if (ezor == 0 || item.KodEzor == ezor)
                {
                    yechida = new Yechida();
                    yechida.KodYechida = item.KodYechida;
                    shaot = budget.GetBudgetLeftForMitkan(yechida.KodYechida, month);
                    //yechidot.if (shaot != 0)
                    yechida.TeurYechida = item.TeurYechida + " (יתרת שעות " + shaot + ")";
                    // else yechida.TeurYechida = item.TeurYechida;
                    yechidot.Add(yechida);
                }
            });
            return yechidot;
        }

        private List<BudgetSpecial> GetListBudgetSpecialForCombo()
        {
            var ManagerChange = _container.Resolve<IChangesManager>();
            var bs = ManagerChange.GetBudgetSpecial();

            //foreach (BudgetSpecial b in bs)
            //{
            //    b.Description = b.Description + "(" + b.MisparTakziv + ")";
            //}

            BudgetSpecial takziv = new BudgetSpecial();
            takziv.MisparTakziv = 0;
            takziv.Description = "בחר תקציב מהרשימה...";
            takziv.Amount = 0;
            takziv.Reason = "";
            takziv.TaarichIdkun = DateTime.Now;

            bs.Insert(0, takziv);
            return bs;
        }
        public ActionResult MoveBudget()
        {
            NiyudBudgetViewModel vm = new NiyudBudgetViewModel();


            List<Yechida> yechidot = GetListYechidotForCombo();
            vm.YechidotOut = new SelectList(yechidot, "KodYechida", "TeurYechida");
            vm.YechidotIn = new SelectList(yechidot, "KodYechida", "TeurYechida");
            vm.YechidaIn = yechidot[0];
            vm.YechidaOut = yechidot[0];
            return PartialView("_NiyudTakziv", vm);
        }

        public ActionResult RemoveBudget()
        {
            GriaBudgetViewModel vm = new GriaBudgetViewModel();

            List<Yechida> yechidot = GetListYechidotForCombo();
            vm.Yechidot = new SelectList(yechidot, "KodYechida", "TeurYechida");
            vm.Yechida = yechidot[0];
            return PartialView("_GriatTakziv", vm);
        }
        public ActionResult AddNewBudget(SaveBudgetVM vm)
        {
            vm.NewTakziv = GetNextTakzivNumber();
            return PartialView("_AddNewBudget", vm);
        }
        public int GetNextTakzivNumber()
        {
            var ManagerChange = _container.Resolve<IChangesManager>();
            return ManagerChange.GetNextTakzivNumber();
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

    public class SaveBudgetVM
    {
        public int Mitkan { get; set; }
        public int Takziv { get; set; }
        public decimal Kamut { get; set; }
        public string Comment { get; set; }
        public string Name { get; set; }
        public int MitkanOut { get; set; }
        public int NewTakziv { get; set; }
        public int AddNewSucceeded { get; set; }
    }

    public enum TypeChange
    {
        Add =1,
        Reduction=2
    }

}