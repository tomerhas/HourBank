using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels.Profiles
{
    public class Profile
    {
        public Profile()
        {
            Masachim = new List<Masach>();
        }
        [Key, Column("KOD_PROFIL")]
        public int ProfileId{ get; set; }

        [Column("PAIL")]
        public int? Pail { get; set; }

        [Column("TEUR_PROFIL")]
        public string TeurProfile { get; set; }

        public List<Masach> Masachim { get; set; }
    }
}
