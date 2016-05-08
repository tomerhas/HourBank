using BsmCommon.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BsmWebApp.ViewModels.Changes
{
    public class NiyudBudgetViewModel
    {
        public NiyudBudgetViewModel()
        {

        }
        public SelectList YechidotIn { get; set; }
        public SelectList YechidotOut { get; set; }
        public Yechida YechidaIn { get; set; }
        public Yechida YechidaOut { get; set; }
        public int Kamut { get; set; }
    }
}