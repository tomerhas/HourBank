using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels
{
    public class GeneralObject
    {
        public Yechida CurYechida { get; set; }
        public DateTime CurMonth { get; set; }

        public GeneralObject()
        {
            CurYechida = new Yechida();
        }
    }
}
