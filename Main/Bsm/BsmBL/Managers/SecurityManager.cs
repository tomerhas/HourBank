﻿using BsmBL.DAL;
using BsmBL.ExchangeService;
using BsmCommon.DataModels.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BsmCommon.Interfaces.Managers;
using BsmCommon.DataModels;
using Microsoft.Practices.Unity;
using System.Diagnostics;

namespace BsmBL.Managers
{
    public class SecurityManager : ISecurityManager
    {
        private IUnityContainer _container;

        public SecurityManager(IUnityContainer container)
        {
            _container = container;
        }

        public UserInfo GetUserInfo(string UserName)
        {
            int EmpNum = 0, Isuk = 0, YechidaIrgunit = 0, KodYechida=0;
            //הבא את נתוני המשתמש מתוך active directory
         
            var exchangeSrv = new ExchangeInfoServiceSoapClient();
            UserInfo uf = new UserInfo();
            uf.EmployeeNumber = exchangeSrv.getEmpNumByUserName(UserName);
            uf.EmployeeFullName = exchangeSrv.getEmpFullName(UserName);
            uf.UserName = UserName;
            uf.MursheBankShaot = KayemetHarshaaForBankShaot(exchangeSrv, UserName);
            int.TryParse(uf.EmployeeNumber, out EmpNum);
            if (EmpNum > 0)
            {
             
                using (var context = new KdsEntities())//עומדים לעבוד מול הטבלאות של kds Entiti
                {
                  var PirteyOved =  context.PirteyOvdim.SingleOrDefault(x => x.MisparIshi == EmpNum && DateTime.Now >= x.TaarichMe && DateTime.Now <= x.TaarichAd);
                  if (PirteyOved != null)
                  {
                      Isuk = PirteyOved.Isuk.HasValue? PirteyOved.Isuk.Value:0;
                      YechidaIrgunit = PirteyOved.YechidaIrgunit.HasValue ? PirteyOved.YechidaIrgunit.Value : 0;

                     
                  }
                }
               
                if (Isuk > 0)
                {
                    using (var context = new BsmEntities())
                    {
                        uf.HarshaatOved = context.HarshaotOvdim.SingleOrDefault(h => h.KodIsuk == Isuk && h.KodYechida == YechidaIrgunit);
                        if(uf.HarshaatOved != null){
                            List<Masach> Screens = context.Mashacim.Where(m => m.Pail == 1).ToList();
                            foreach (Masach Screen in Screens.ToList())
                            {
                                Screen.Harshaot = context.HarshaatMasach.Where(h => h.MasachId == Screen.MasachId && h.SugHarshaa == uf.HarshaatOved.SugHarshaa).ToList();
                                if (Screen.Harshaot.Count == 0)
                                    Screens.Remove(Screen);
                            }

                            uf.Screens = Screens;
                        }
                    }
                    if (uf.HarshaatOved.KodYechidaIchus > 0)
                        KodYechida = uf.HarshaatOved.KodYechidaIchus;
                    else KodYechida = uf.HarshaatOved.KodYechida;
                   
                    uf.Yechidot = GetYechidotToUser(KodYechida);
                    EventLog.WriteEntry("kds", "after  GetYechidotToUser");
                    if (uf.Yechidot.Count > 0)
                    {
                        EventLog.WriteEntry("kds", "uf.Yechidot.Count > 0");
                        //uf.CurYechida = uf.Yechidot[0];         
                    }
                    EventLog.WriteEntry("kds", "end");
                }

            }

          
           
            //הבא את הקבוצות אליהם המשתמש שייך ב AD
           // var groups = GetUserADGroups(exchangeSrv, UserName);

            //הבא את הפרופילים השייכים למשתמש מהטבלה - DB  
           // var profiles = GetProfilesByGroup(groups);

            //הבא את ההרשאות בהתאם לפרופילים של המשתמש
          //  uf.ProfilesMasachim = GetHarshaotForProfile(profiles);
            return uf;
        }

        private bool KayemetHarshaaForBankShaot(ExchangeInfoServiceSoapClient exchangeSrv, string UserName)
        {
            string[] userGroups = exchangeSrv.getUserPropertyByUserName(UserName, "MemberOf").Split("|".ToCharArray());
            foreach (string group in userGroups)
                if (group == "HourBank")
                    return true;

           return false;
        }


        private string[] GetUserADGroups(ExchangeInfoServiceSoapClient exchangeSrv, string UserName)
        {
            string[] userGroups = exchangeSrv.getUserPropertyByUserName(UserName,"MemberOf").Split("|".ToCharArray());
            return userGroups;  
        }

        private List<Yechida> GetYechidotToUser(int kodYechida)
        {
            IGeneralManager Gmanager = _container.Resolve<IGeneralManager>();
            return Gmanager.GetYechidutForUser(DateTime.Now.Date, kodYechida);
            
        }

        
        //private List<Profile> GetProfilesByGroup(string[]  groups)
        //{
        //    List<string> groupsLC = new List<string>();
        //    groups.ToList().ForEach(x => groupsLC.Add(x.ToLower()));
        //    using (var context = new KdsEntities())
        //    {
        //        return context.Profiles.Where(x => groupsLC.Contains(x.TeurProfile.ToLower()) && x.Pail == 1).ToList();
        //    }   
        //}

        //private List<ProfilesMasachim> GetHarshaotForProfile(List<Profile> Profiles)
        //{
        //    List<int> profilesIds = Profiles.Select(x => x.ProfileId).ToList();

        //    using (var context = new KdsEntities())
        //    {
        //       return context.ProfileMasachims.Include(x=>x.Masach).Where(x => profilesIds.Contains(x.ProfileId)).ToList();
        //    }      
        //}

    }
}
