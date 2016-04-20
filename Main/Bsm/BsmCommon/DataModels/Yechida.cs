using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels
{
    public class Yechida
    {
        [Key, Column("KOD_HEVRA", Order = 0)]
        public int KodHevra { get; set; }
        [Key, Column("KOD_YECHIDA", Order = 1)]
        public int KodYechida { get; set; }
        [Column("TEUR_YECHIDA")]
        public string TeurYechida { get; set; }
        [Column("SUG_YECHIDA")]
        public string SugYechida { get; set; }
        [Column("KOD_EZOR")]
        public int KodEzor { get; set; }
    }
}
