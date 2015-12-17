using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels.Profiles
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EmployeeFullName { get; set; }
        public string EmployeeNumber { get; set; }
        public Harshaa HarshaatOved { get; set; }
        public List<Masach> Screens  { get; set; }
        public List<Yechida> Yechidot { get; set; }
       // public Yechida CurYechida { get; set; }
       // public List<ProfilesMasachim> ProfilesMasachim { get; set; }

        public bool IsPermittedForMasach(string masachName)
        {
            var permitted = Screens.Where(x =>  x.MasachName.Trim().ToLower() == masachName.Trim().ToLower());

            return (permitted.Count() > 0);
         //   return true;
        }
    }
}
