using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BsmCommon.DataModels
{
    public class FilterModel
    {
        public FilterModel()
        {
          //  ShowEzor = false;
        }
        public SelectList Months { get; set; }
        //public SelectList Ezors { get; set; }
        public string SelectedMonth { get; set; }
    //    public int SelectedEzor { get; set; }
        public string LastDateIdkunBankStr { get; set; }
        public DateTime LastDateIdkunBank { get; set; }
        public string NumDays { get; set; }
       // public bool ShowEzor { get; set; }
    }
}
