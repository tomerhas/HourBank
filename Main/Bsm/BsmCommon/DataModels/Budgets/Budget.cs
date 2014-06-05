using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels.Budgets
{
    public class Budget
    {

        public Budget()
        {
            BudgetChanges = new List<BudgetChange>();
        }
        [Key, Column("KOD_YECHIDA", Order = 0)] 			
        public int KodYechida { get; set; }
       
        [Key, Column("CHODESH", Order = 1)] 
        public DateTime Month { get; set; }



        [Display(Name = "תקציב ש''נ חודשי לפי תקן")]
        [Column("BUDGET")]
        public int BudgetVal{ get; set; }
  
        [Column("BUDGET_USED")]
        public int BudgetUsed { get; set; }

        public List<BudgetChange> BudgetChanges { get; set; }

        [NotMapped]
        public int RemainHoursLastMonth { get; set; }

         [Display(Name = "הפחתה/הוספה ש''נ")]
        [NotMapped]
        public int AddSubtractHours { get; set; }

      /*  [Display(Name="שעות חודשי")]
        public double BudgetHoursMounthly { get; set; }
        
        public double BudgetHoursRemender { get; set; }
       
        public double ModifyHours { get; set; }

        public double TotalHours { get; set; }

        public double RemainHours { get; set; }

        public double RemainHoursNonUsed { get; set; }*/
    }
}
