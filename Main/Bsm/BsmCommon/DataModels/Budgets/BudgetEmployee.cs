using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels.Budgets
{
    public class BudgetEmployee
    {
        [Key, Column("MISPAR_ISHI", Order = 0)]
        public int MisparIshi { get; set; }

        [Key, Column("CHODESH", Order = 1)]
        public DateTime Month { get; set; }

        [Key, Column("BAKASHA_ID", Order = 2)]
        public int BakashaId { get; set; }

        [NotMapped]
        public string FirstName { get; set; }
        [NotMapped]
        public string LastName { get; set; }
    }
}
