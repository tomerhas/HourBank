using BsmCommon.DataModels;
using BsmCommon.DataModels.Changes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BsmWebApp.ViewModels.Changes
{
    public class GriaBudgetViewModel
    {
        public GriaBudgetViewModel()
        {

        }
        public SelectList Yechidot { get; set; }
        public Yechida Yechida { get; set; }
        public int Kamut { get; set; }
    }
}