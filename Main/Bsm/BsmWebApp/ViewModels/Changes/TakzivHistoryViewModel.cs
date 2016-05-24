using BsmCommon.DataModels.Changes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BsmWebApp.ViewModels.Changes
{
   
    public class TakzivHistoryViewModel
    {
        public List<BudgetSpecialYechida> TakzivHistoryList;
        public TakzivHistoryViewModel()
        {
             TakzivHistoryList= new List<BudgetSpecialYechida>();
        }
    }
}