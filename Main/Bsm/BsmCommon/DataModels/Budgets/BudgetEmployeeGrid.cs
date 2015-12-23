﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels.Budgets
{
    public class BudgetEmployeeGrid
    {
        public int Masad { get; set; }
        public int MisparIshi { get; set; }
        public string FullName { get; set; }
        public string TeurIsuk { get; set; }
        public string AlTikni { get; set; }
        public string TeurMutamut { get; set; }
        public string TeurGil { get; set; }
        public float MichsaYomit { get; set; }
        public float NosafotPrev { get; set; }
        public float MichsaPrev { get; set; }
        public float NosafotCur { get; set; }
        public decimal MichsaCur { get; set; }
        public decimal ShaotShebuzu { get; set; }
        public float NosafotNotUsed { get; set; }
        public string Paar { get; set; }
        public int CurYechida { get; set; }
        public string ReadOnly { get; set; }
       // public float Meafyen14 { get; set; }
    }
}
