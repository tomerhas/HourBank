using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels.Profiles
{
    public class Masach
    {

        public Masach()
        {
            Harshaot = new List<Harshaa>();
            Profiles = new List<Profile>();
        }
        [Key, Column("MASACH_ID", Order = 0)]
        public int MasachId{ get; set; }

        [Key, Column("PAKAD_ID", Order = 1)]
        public int PakadId { get; set; }

        [Column("SHEM")]
        public string Name { get; set; }

        public List<Harshaa> Harshaot { get; set; }
        public List<Profile> Profiles { get; set; }
    }
}
