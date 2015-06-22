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
            Harshaot = new List<HarshaatMasach>();
         //   Profiles = new List<Profile>();
        }
        [Column("KOD_MASACH")]
        public int MasachId{ get; set; }

        [Column("PAIL")]
        public int Pail { get; set; }

        [Column("NAME_VIEW")]
        public string MasachName { get; set; }

        public List<HarshaatMasach> Harshaot { get; set; }
      //  public List<Profile> Profiles { get; set; }
    }
}
