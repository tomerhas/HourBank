using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels
{
    public class Parameter
    {
        [Key, Column("KOD_PARAM", Order = 0)]
        public int KodParam { get; set; }
        [Key, Column("ME_TAARICH", Order = 1)]
        public DateTime TaarichMe { get; set; }
        [Column("AD_TAARICH")]
        public DateTime TaarichAd { get; set; }
         [ Column("ERECH")]
        public string Val { get; set; }
    }
}
