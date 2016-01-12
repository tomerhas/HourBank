using BsmCommon.DataModels;
using BsmCommon.DataModels.Budgets;
using BsmWebApp.ViewModels.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BsmWebApp.ViewModels.Budgets
{
    public class BudgetMainViewModel
    {
        public BudgetMainViewModel()
        {
            IsMitkanBudgetDetailEmpty = true;
            OnlyOneYechida = false;
            UsersInMitkan = new UsersInMitkanViewModel();
            IsMonthToEdit = false;
            Messege = "";
        //    KodList = new List<KodListItem>();
        //    KodList.Add(new KodListItem() { ProductID = 2, ProductName = "prod1" });
        //    KodList.Add(new KodListItem() { ProductID = 3, ProductName = "prod2" });
        //    KodList.Add(new KodListItem() { ProductID = 4, ProductName = "prod3" });
            ShouldDisplayMessage = 0;
        }

        public BudgetMainViewModel(List<MonthHolder> months) : this()
        {
            FillMonths(months);
        }

        public void FillMonths(List<MonthHolder> months)
        {
         
            Months = new SelectList(months, "Id", "Val");
            SelectedMonth =months[0].Id;
        }
        public SelectList Months { get; set; }
        public string SelectedMonth { get; set; }
        public string LastDateIdkunBankStr { get; set; }
        public DateTime LastDateIdkunBank { get; set; }
        public string NumDays { get; set; }
        public Budget MitkanBudgetDetail { get; set; }
        public bool IsMitkanBudgetDetailEmpty { get; set; }
        public int KodMitkan { get; set; }
        public DateTime Month { get; set; }
        public bool IsMonthToEdit { get; set; }
        public string Messege { get; set; }
        /// <summary>
        /// ///////////////////////////////////////
        /// </summary>

        public string MitkanName { get; set; }
      
        public long BakashaId { get; set; }
       
        public DateTime LastBakashaDate { get; set; }
        public bool OnlyOneYechida { get; set; }
        public UsersInMitkanViewModel UsersInMitkan { get; set; }
       // public ReportingServicesReportViewModel ReportVM { get; set; }
        public int MisparIshi { get; set; }
        public string OvedName { get; set; }
      //  public List<KodListItem> KodList { get; set; }

        public int ShouldDisplayMessage { get; set; }
    }


    //public class KodListItem
    //{
    //    public string ProductName { get; set; }
    //    public int ProductID { get; set; }
    //}

   
}