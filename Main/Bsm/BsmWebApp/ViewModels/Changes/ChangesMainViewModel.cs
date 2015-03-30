using BsmCommon.DataModels;
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
            
        }
        public ChangesMainViewModel(List<MonthHolder> months)
            : this()
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
        public DateTime Month { get; set; }
        public int KodEzor { get; set; }
        public SelectList Months { get; set; }
        public SelectList Ezors { get; set; }
        public string SelectedMonth { get; set; }
        public string SelectedEzor { get; set; }
    }
}