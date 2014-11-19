using BsmBL.DAL;
using BsmBL.ExchangeService;
using BsmCommon.DataModels.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BsmCommon.Interfaces.Managers;

namespace BsmBL.Managers
{
    public class SecurityManager : ISecurityManager
    {
        public UserInfo GetUserInfo(string UserName)
        {
            //הבא את נתוני המשתמש מתוך active directory
            var exchangeSrv = new ExchangeInfoServiceSoapClient();
            UserInfo uf = new UserInfo();
            uf.EmployeeNumber = exchangeSrv.getEmpNumByUserName(UserName);
            uf.EmployeeFullName = exchangeSrv.getEmpFullName(UserName);
            uf.UserName = UserName;

            //הבא את הקבוצות אליהם המשתמש שייך ב AD
            var groups = GetUserADGroups(exchangeSrv, UserName);

            //הבא את הפרופילים השייכים למשתמש מהטבלה - DB  
            var profiles = GetProfilesByGroup(groups);

            //הבא את ההרשאות בהתאם לפרופילים של המשתמש
            uf.ProfilesMasachim = GetHarshaotForProfile(profiles);
            return uf;
        }


        private string[] GetUserADGroups(ExchangeInfoServiceSoapClient exchangeSrv, string UserName)
        {
            string[] userGroups = exchangeSrv.getUserPropertyByUserName(UserName,"MemberOf").Split("|".ToCharArray());
            return userGroups;  
        }

        private List<Profile> GetProfilesByGroup(string[]  groups)
        {
            List<string> groupsLC = new List<string>();
            groups.ToList().ForEach(x => groupsLC.Add(x.ToLower()));
            using (var context = new KdsEntities())
            {
                return context.Profiles.Where(x => groupsLC.Contains(x.TeurProfile.ToLower()) && x.Pail == 1).ToList();
            }   
        }

        private List<ProfilesMasachim> GetHarshaotForProfile(List<Profile> Profiles)
        {
            List<int> profilesIds = Profiles.Select(x => x.ProfileId).ToList();

            using (var context = new KdsEntities())
            {
               return context.ProfileMasachims.Include(x=>x.Masach).Where(x => profilesIds.Contains(x.ProfileId)).ToList();
            }      
        }

    }
}
