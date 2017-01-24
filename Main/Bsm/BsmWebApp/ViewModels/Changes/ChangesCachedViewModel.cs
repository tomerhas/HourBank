using BsmCommon.DataModels.Changes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BsmWebApp.ViewModels.Changes
{
    public class ChangesCachedViewModel
    {
    //    public int SelectedEzor { get; set; }
        public DateTime CurMonth { get; set; }
        public int Isuk { get; set; }
        public int YechidaIrgunit { get; set; }
        public List<BudgetChangesGrid> Changes { get; set; }
    }
}