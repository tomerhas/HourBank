using BsmCommon.DataModels.Budgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BsmWebApp.ViewModels.Budgets
{
    public class UserInMitkanVM
    {
        public UserInMitkanVM(BudgetEmployee be)
        {
            BudgetEmployee = be;
        }
        public BudgetEmployee BudgetEmployee { get; set; }
    }
}