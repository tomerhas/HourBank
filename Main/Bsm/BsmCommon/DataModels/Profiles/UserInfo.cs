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
        public List<ProfilesMasachim> ProfilesMasachim { get; set; }

        public bool IsPermittedForMasach(string masachName)
        {
            var permitted = ProfilesMasachim.Where(x => x.Masach!= null && x.Masach.Name.Trim().ToLower() == masachName.Trim().ToLower());

            return (permitted.Count() > 0);
        }
    }
}
