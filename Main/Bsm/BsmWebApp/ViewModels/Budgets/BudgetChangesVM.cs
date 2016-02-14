using System;
using System.Collections.Generic;
using System.Linq;
using BsmCommon.DataModels.Budgets;
using System.Web;

namespace BsmWebApp.ViewModels.Budgets
{
     public class BudgetChangesVM
     {
         //public int kod_mitkan;
         //public DateTime month;
         public Budget Budget { get; set; }
         public List<BudgetChangeVM> BudgetChanges { get; set; }

          public  BudgetChangesVM()
          {
              BudgetChanges = new List<BudgetChangeVM>();
              Budget = new Budget();
          }
 
    }

     public class BudgetChangeVM
     {
         public BudgetChangeVM(BudgetChange bc)
         {
             if (bc.Type == 1)
                 bc.ValToDisplay = bc.Val + "+";
             else bc.ValToDisplay = bc.Val + "-";
             BudgetChange = bc;
         }
         public BudgetChange BudgetChange { get; set; }
     }
}