using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BsmCommon.DataModels
{
    public class Ezor
    {
        [Key, Column("KOD_HEVRA", Order = 0)]
        public int KodHevra { get; set; }
        [Key, Column(Order = 1)]
        public int KOD_EZOR { get; set; }
        public string TEUR_EZOR { get; set; }
    }

    public class TeurEzor
    {
    //    [Column("KOD_EZOR")]
        public decimal KOD_EZOR { get; set; }
      //  [Column("TEUR_EZOR")]
        public string TEUR_EZOR { get; set; }
    }
}
