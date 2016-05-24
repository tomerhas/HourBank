using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels.Changes
{
    public class BudgetSpecialYechida
    {
        [Key, Column("KOD_YECHIDA", Order = 0)]
        public int KodYechida { get; set; }

        [Column("CHODESH")]
        public DateTime Chodesh { get; set; }

        [Key, Column("MISPAR_TAKZIV", Order = 1)]
        public int MisparTakziv { get; set; }

        [Column("AMOUNT")]
        public decimal Amount { get; set; }

        [Column("REASON")]
        public string Reason { get; set; }

        [Column("TAARICH_IDKUN")]
        public DateTime TaarichIdkun { get; set; }

        [Column("MEADKEN")]
        public int Meadken { get; set; }

        [NotMapped]
        public string MeadkenName { get; set; }
        [NotMapped]
        public string TeurYechida { get; set; }
        
    }
}
