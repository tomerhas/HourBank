using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels.Changes
{
    public class BudgetReduction
    {
        [Column("KOD_YECHIDA")]
        public int KodYechida { get; set; }

        [Column("CHODESH")]
        public DateTime Chodesh { get; set; }

        [Column("AMOUNT")]
        public float Amount { get; set; }

        [Column("REASON")]
        public string Reasson { get; set; }

        [Key, Column("TAARICH_IDKUN", Order = 0)]
        public DateTime TaarichIdkun { get; set; }

        [Column("MEADKEN")]
        public int? Meadken { get; set; }
        
    }
}
