using BsmCommon.DataModels;
using BsmCommon.DataModels.Changes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BsmWebApp.ViewModels.Changes
{
    public class AddBudgetViewModel
    {
        public AddBudgetViewModel()
        {

        }
        public SelectList Yechidot { get; set; }
        public SelectList Budgets { get; set; }
        public Yechida Yechida { get; set; }
        public BudgetSpecial budget { get; set; }
    }
}