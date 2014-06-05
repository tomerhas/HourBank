using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels.Budgets
{
    public class BudgetChange
    {

        [Key, Column("ID")]
        public int Id { get; set; }

        [Column("KOD_YECHID")]
        public int KodYechida { get; set; }

        [Column("CHODESH")]
        public DateTime Month { get; set; }

        [Column("ERECH")]
        public int Val { get; set; }

         [Column("TYPE")]
        public int Type { get; set; }
        			
    }
}
