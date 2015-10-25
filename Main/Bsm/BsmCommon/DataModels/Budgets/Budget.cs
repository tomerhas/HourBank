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

        [Display(Name = "תקן")]
        [Column("BUDGET")]
        public int BudgetVal{ get; set; }
  
        [Column("BUDGET_USED")]
        public int? Budget_Used { get; set; }
        [NotMapped]
        public int BudgetUsed
        {
            get
            {
                return Budget_Used ?? 0;
            }
            set
            {
                Budget_Used = value == 0 ? new Nullable<int>() : value;
            }
        }


        [Column("TAARICH_IDKUN")]
        public DateTime TaarichIdkun { get; set; }

        [Column("BAKASHA_ID")]
        public long BakashaId { get; set; }

        public List<BudgetChange> BudgetChanges { get; set; }

        [Display(Name = "יתרת מחודש קודם")]
        [NotMapped]
        public int RemainHoursLastMonth { get; set; }

        [Display(Name = "הפחתה/הוספה")]
        [NotMapped]
        public int AddSubtractHours { get; set; }

        [Display(Name = "ס''הכ תקציב")]
        [NotMapped]
        public int SachTakzivShaotNosafot { get; set; }


        [Display(Name = "לחלוקה")]
        [NotMapped]
        public int YitratTakzivToDivide { get; set; }

        [Display(Name = "ניצול בפועל")]
        [NotMapped]
        public int HoursNotUsed { get; set; }
    }
}
