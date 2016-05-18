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
        //    BudgetChanges = new List<BudgetChange>();
        }
        [Key, Column("KOD_YECHIDA", Order = 0)] 			
        public int KodYechida { get; set; }
       
        [Key, Column("CHODESH", Order = 1)] 
        public DateTime Month { get; set; }

        [Column("BUDGET")]
        public decimal BudgetLefiTeken { get; set; }
        
        [Display(Name = "תקציב")]
        [NotMapped]
        public decimal BudgetVal{ get; set; }

       [Display(Name = "שעות שבוצעו")]
        [Column("BUDGET_USED")]
        public decimal? Budget_Used { get; set; }
       
        [NotMapped]
        public decimal BudgetUsed
        {
            get
            {
                return Budget_Used ?? 0;
            }
            set
            {
                Budget_Used = value == 0 ? new Nullable<decimal>() : value;
            }
        }

        [Display(Name = "שעות שהוקצו")]
        [NotMapped]
        public decimal ShaotByMeafyen14 { get; set; }

        [Display(Name = "שעות שנותרו להקצאה")]
        [NotMapped]
        public decimal YitratTakzivToDivide { get; set; }

        [Column("TAARICH_IDKUN")]
        public DateTime TaarichIdkun { get; set; }

        [Column("BAKASHA_ID")]
        public long BakashaId { get; set; }

        [Column("MICHSA_BASIC")]
        public decimal MichsaBasic { get; set; }

        [Column("AGE_ADDITION")]
        public decimal Age { get; set; }
         
        [Column("HALBASHA_ADDITION")]
        public decimal Halbasha { get; set; }

        [Column("IZUN_MATZEVET_LETEKEN")]
        public decimal IzunMatzevet { get; set; }
        	 
        //public List<BudgetChange> BudgetChanges { get; set; }

        //[Display(Name = "יתרת מחודש קודם")]
        //[NotMapped]
        //public int RemainHoursLastMonth { get; set; }

        //[Display(Name = "הפחתה/הוספה")]
        //[NotMapped]
        //public int AddSubtractHours { get; set; }

        //[Display(Name = "ס''הכ תקציב")]
        //[NotMapped]
        //public int SachTakzivShaotNosafot { get; set; }


        //[Display(Name = "לחלוקה")]
        //[NotMapped]
        //public int YitratTakzivToDivide { get; set; }

        //[Display(Name = "ניצול בפועל")]
        //[NotMapped]
        //public int HoursNotUsed { get; set; }
    }
}
