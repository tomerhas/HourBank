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

        public static string getMonthHeb(int month)
        {
            switch (month)
            {
                case 1: return "ינו'";  
                case 2: return "פבר'";
                case 3: return "מרץ";
                case 4: return "אפר'";
                case 5: return "מאי";
                case 6: return "יוני";
                case 7: return "יולי";
                case 8: return "אוג'";
                case 9: return "ספט'";
                case 10: return "אוק'";
                case 11: return "נוב'";
                case 12: return "דצמ'";
                default: return "";

            }
        }

        public static string getDayHeb(DateTime taarich)
        {
            switch (taarich.Day)
            {
                case 1: return "ראשון'";
                case 2: return "שני'";
                case 3: return "שלישי";
                case 4: return "רביעי";
                case 5: return "חמישי";
                case 6: return "שישי";
                case 7: return "שבת";
                default: return "";

            }
        }
    }
}
