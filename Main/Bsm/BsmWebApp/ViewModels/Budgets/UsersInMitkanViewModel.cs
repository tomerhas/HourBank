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
            Employees = new List<UserInMitkanVM>();
        }
        public List<UserInMitkanVM> Employees { get; set; }
    }
}