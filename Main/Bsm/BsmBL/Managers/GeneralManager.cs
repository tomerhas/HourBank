﻿using BsmBL.DAL;
using BsmCommon.DataModels;
using BsmCommon.DataModels.Employees;
using BsmCommon.Interfaces.Dal;
using BsmCommon.Interfaces.Managers;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmBL.Managers
{
    public class GeneralManager : IGeneralManager
    {
        private IUnityContainer _container;

        public GeneralManager(IUnityContainer container)
        {
            _container = container;
        }

        public List<Oved> GetOvdim(int[] PirteyOvedIds)
        {
            using (var context = new KdsEntities())
            {
                var result = context.Ovdim.Where(x => PirteyOvedIds.Contains(x.MisparIshi)).ToList();
                return result;
            }
        }

        public List<TeurEzor> GetEzors()
        {
          using (var db = new KdsEntities())
            {
                var sql = string.Format("select distinct kod_ezor,teur_ezor from ctb_ezor");
                var res = db.Database.SqlQuery<TeurEzor>(sql);
                return res.ToList();
            }
        }

        public long GetLastBakasha(DateTime Month)
        {
            string chodesh = Month.Date.Month.ToString().PadLeft(2, '0') + "/" + Month.Date.Year;
            using (var context = new KdsEntities())
            {

                var sql = string.Format("select max(b.bakasha_id) from tb_bakashot b,tb_bakashot_params p where b.sug_bakasha=27 and b.bakasha_id=p.bakasha_id and p.erech='{0}'", chodesh);
                var res = context.Database.SqlQuery<decimal>(sql).ToList();

                return (long)res[0];
            }
        }

        public long GetLastBakashatChishuv(DateTime Month)
        {
            string chodesh = Month.Date.Month.ToString().PadLeft(2, '0') + "/" + Month.Date.Year;
            using (var context = new KdsEntities())
            {

                var sql = string.Format("select b.bakasha_id from tb_bakashot b,tb_bakashot_params p where b.sug_bakasha=1 and b.bakasha_id=p.bakasha_id and b.huavra_lesachar='1'  and p.param_id=2 p.erech='{0}'", chodesh);
                                                                                                                                                            			
                var res = context.Database.SqlQuery<decimal>(sql).ToList();

                return (long)res[0];
            }
        }

        public DataTable GetYechidutForUser(DateTime Month, int KodYechida, string PreFix="")
        {
            var GeneralDal = _container.Resolve<IGeneralDal>();
            return GeneralDal.GetYechidotForUser(Month, KodYechida, PreFix);
             
        }
    }
}