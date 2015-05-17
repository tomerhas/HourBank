using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BsmCommon.DataModels.Changes
{
    public class BudgetChangesGrid
    {
        public int Masad { get; set; }
        public int KodYechida { get; set; }
        public float Budget { get; set; }
        public float LastMonthYitra { get; set; }
        public float Diffrence { get; set; }
        public float Takziv { get; set; }
        public string Reason { get; set; }

    }
}
