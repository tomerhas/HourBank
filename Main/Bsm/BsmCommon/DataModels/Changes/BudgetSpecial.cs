using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels.Changes
{
    public class BudgetSpecial
    {
        [Key, Column("MISPAR_TAKZIV", Order = 0)]
        public int MisparTakziv { get; set; }
        [Column("DESCRIPTION")]
        public string Description { get; set; }
        [Column("AMOUNT")]
        public int Amount { get; set; }
        [Column("REASON")]
        public string Reason { get; set; }
        [Column("TAARICH_IDKUN")]
        public DateTime TaarichIdkun { get; set; }
        [Column("MEADKEN")]
        public int? Meadken { get; set; }
    }
}
