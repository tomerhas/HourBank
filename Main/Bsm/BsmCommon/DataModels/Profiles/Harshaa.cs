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
      
        [Key, Column("KOD_HARSHAA")]
        public int HarshaaId{ get; set; }

        [Column("PAIL")]
        public int? Pail { get; set; }

       
    }
}
