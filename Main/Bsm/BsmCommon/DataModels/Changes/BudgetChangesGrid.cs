using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BsmCommon.DataModels.Changes
{
    public class BudgetChangesGrid
    {
      //  public int Masad { get; set; }
        public int Kod_Yechida { get; set; }
        public string Teur_Yechida { get; set; }
        public string Takziv { get; set; }
        public string Yitra { get; set; }
        public string Niyud { get; set; }
        public string AddRem { get; set; }
        //  public float Miztaber { get; set; }
        //    public string Reason { get; set; }

    }
}
