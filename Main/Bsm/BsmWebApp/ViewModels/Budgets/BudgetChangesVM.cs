using System;
using System.Collections.Generic;
using System.Linq;
using BsmCommon.DataModels.Budgets;
using System.Web;

namespace BsmWebApp.ViewModels.Budgets
{
     public class BudgetChangesVM
     {
         public int kod_mitkan;
         public DateTime month;
          public  BudgetChangesVM()
          {
              BudgetChanges = new List<BudgetChangeVM>();
          }

          public List<BudgetChangeVM> BudgetChanges { get; set; }
        
    }

     public class BudgetChangeVM
     {
         public BudgetChangeVM(BudgetChange bc)
         {
             BudgetChange = bc;
         }
         public BudgetChange BudgetChange { get; set; }
     }
}