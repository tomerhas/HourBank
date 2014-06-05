using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels.Employees
{
    public class Oved
    {
        [Key, Column("MISPAR_ISHI", Order = 0)]
        public int MisparIshi { get; set; }

        [Key, Column("SHEM_PRAT", Order = 1)]
        public string FirstName { get; set; }

        [Key, Column("SHEM_MISH", Order = 2)]
        public string LastName { get; set; }

    }
}
