using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.Helpers
{
    public class DateHelper
    {
        public static DateTime GetPreviosMonth(DateTime current)
        {
            return current.AddMonths(-1);
        }
    }
}
