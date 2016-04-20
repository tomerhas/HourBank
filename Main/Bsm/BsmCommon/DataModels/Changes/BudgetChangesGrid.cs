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
      //  public int Masad { get; set; }
        public int Kod_Yechida { get; set; }
        public string Teur_Yechida { get; set; }
        public float Takziv { get; set; }
        public float Yitra { get; set; }
      //  public float Miztaber { get; set; }
    //    public string Reason { get; set; }
      
    }
}
