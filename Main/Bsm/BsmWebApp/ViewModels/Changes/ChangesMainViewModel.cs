using BsmCommon.DataModels;
using BsmCommon.DataModels.Changes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BsmWebApp.ViewModels.Changes
{
    public class ChangesMainViewModel
    {
        public ChangesMainViewModel()
        {
            IsMonthToEdit = false;
            Changes = new List<BudgetChangesGrid>();
            Filter = new FilterModel();
            ShouldDisplayMessage = 0;
        }
        public List<BudgetChangesGrid> Changes { get; set; }
        public FilterModel Filter { get; set; }
        public bool IsMonthToEdit { get; set; }
        public int ShouldDisplayMessage { get; set; }
        public string Page { get; set; }
        //public ChangesMainViewModel(List<MonthHolder> months)
        //    : this()
        //{
        //    FillMonths(months);
        //    Changes = new List<BudgetChangesGrid>();
        //}

        //public void FillMonths(List<MonthHolder> months)
        //{
         
        //    Months = new SelectList(months, "Id", "Val");
        //    //SelectedMonth = 1;
        //}

 
        //public string MitkanName { get; set; }
        //public int KodMitkan { get; set; }
        //public DateTime Month { get; set; }
        //public int KodEzor { get; set; }
        //public SelectList Months { get; set; }
        //public SelectList Ezors { get; set; }
        //public string SelectedMonth { get; set; }
        //public string SelectedEzor { get; set; }
      //  public List<BudgetChangesGrid> Changes { get; set; }
    }
}