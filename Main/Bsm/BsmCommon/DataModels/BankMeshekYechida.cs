using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels
{
    public class BankMeshekYechida
    {
        [Key, Column("KOD_YECHIDA", Order = 0)]
        public int KodYechida { get; set; }
        [Column("ME_TAARICH")]
        public DateTime MeTaarich { get; set; }
        [Column("AD_TAARICH")]
        public DateTime AdTaarich { get; set; }

    }
}

