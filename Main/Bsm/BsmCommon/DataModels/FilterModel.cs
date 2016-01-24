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
        public SelectList Months { get; set; }
        public string SelectedMonth { get; set; }
        public string LastDateIdkunBankStr { get; set; }
        public DateTime LastDateIdkunBank { get; set; }
        public string NumDays { get; set; }
    }
}
