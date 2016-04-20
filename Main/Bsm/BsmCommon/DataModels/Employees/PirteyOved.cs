using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels.Employees
{
    public class PirteyOved
    {
        [Key, Column("MISPAR_ISHI", Order = 0)]
        public int MisparIshi { get; set; }

        [Key, Column("ME_TARICH", Order = 1)]
        public DateTime TaarichMe { get; set; }

        [ Column("AD_TARICH")]
        public DateTime TaarichAd { get; set; }

        [ Column("YECHIDA_IRGUNIT")]
        public int YechidaIrgunit { get; set; }

        [Column("ISUK")]
        public int Isuk { get; set; }
    }
}
