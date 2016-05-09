using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels.Budgets
{
    public class BudgetChange
    {

        [Column("KOD_YECHIDA")]
        public int KodYechida { get; set; }

        [Column("CHODESH")]
        public DateTime Month { get; set; }

        [Column("ERECH")]
        public int Val { get; set; }

        [Column("TYPE")]
        public int Type { get; set; }
         
        [Column("REASON")]
        public string Reason { get; set; }

        [Column("MEADKEN")]
        public int Meadken { get; set; }

        [Key, Column("TAARICH_IDKUN", Order = 0)]
        public DateTime TaarichIdkun { get; set; }

        [NotMapped]
        public string ValToDisplay { get; set; }
        [NotMapped]
        public string MeadkenName { get; set; }
       
        			
    }
}
