using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels.Profiles
{
    public class HarshaatMasach
    {

        [Key, Column("KOD_MASACH", Order = 0)]
        public int MasachId{ get; set; }

        [Key, Column("SUG_HARSHAA", Order = 1)]
        public int SugHarshaa{ get; set; }

        [Column("SUG_PEULT_HARSHAA")]
        public int SugPeilut { get; set; }

    }
}
