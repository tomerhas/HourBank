using BsmCommon.DataModels.Budgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BsmWebApp.ViewModels.Budgets
{
    public class UsersInMitkanViewModel
    {
        public UsersInMitkanViewModel()
        {
            Employees = new List<BudgetEmployeeGrid>();
        }
        public List<BudgetEmployeeGrid> Employees { get; set; }
    }


}