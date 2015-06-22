using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels.Profiles
{
    public class Harshaa
    {

        [Key, Column("KOD_ISUK", Order=0)]
        public int KodIsuk{ get; set; }

        [Key, Column("KOD_YECHIDA", Order=1)]
        public int KodYechida{ get; set; }

        [Key, Column("SUG_HARSHAA", Order=2)]
        public int SugHarshaa { get; set; }

        [Column("KOD_YECHIDA_ICHUS")]
        public int KodYechidaIchus { get; set; }
        	
       
    }
}
