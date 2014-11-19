using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels.Profiles
{
    public class ProfilesMasachim
    {

        
        [Key, Column("MASACH_ID", Order = 0)]
        [ForeignKey("Masach")]
        public int MasachId { get; set; }

        [Key, Column("PAKAD_ID", Order = 1)]
        [ForeignKey("Masach")]
        public int PakadId { get; set; }

        [Key, Column("KOD_PROFIL", Order = 2)]
        public int ProfileId { get; set; }

        [Column("KOD_HARSHAA")]
        public int HarshaaId { get; set; }

        [NotMapped]
        public string MasachName { get; set; }
        
        public Masach Masach { get; set; }
    }
}
