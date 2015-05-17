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
            UsersInMitkan = new UsersInMitkanViewModel();   
        }

        public BudgetMainViewModel(List<MonthHolder> months) : this()
        {
            FillMonths(months);
        }

        public void FillMonths(List<MonthHolder> months)
        {
         
            Months = new SelectList(months, "Id", "Val");
            //SelectedMonth = 1;
        }
        public string MitkanName { get; set; }
        public int KodMitkan { get; set; }
        public long BakashaId { get; set; }
        public DateTime Month { get; set; }
        public bool IsMitkanBudgetDetailEmpty { get; set; }
        public Budget MitkanBudgetDetail { get; set; }

        public SelectList Months { get; set; }

        public string SelectedMonth { get; set; }

        public UsersInMitkanViewModel UsersInMitkan { get; set; }
       // public ReportingServicesReportViewModel ReportVM { get; set; }

        public int MisparIshi { get; set; }
        public string OvedName { get; set; }
    }

   
}