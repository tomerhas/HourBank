using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels.Changes
{

    public class BudgetLeft
    {
        [Key, Column("KOD_YECHIDA", Order = 0)]
        public int KodYechida { get; set; }

        [Key, Column("CHODESH", Order = 1)]
        public DateTime Month { get; set; }


     
        [Column("BUDGET_LEFT")]
        public float BudgetLeftAmount { get; set; }

        [Column("TAARICH_IDKUN")]
        public DateTime TaarichIdkun { get; set; }
        [Column("MEADKEN")]
        public int? Meadken { get; set; }
        [Column("BUDGET_LEFT_ACTUAL")]
        public float? BudgetLeftAmountActual { get; set; }
    }
}
