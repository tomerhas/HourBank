using BsmBL.DAL;
using BsmCommon.DataModels;
using BsmCommon.DataModels.Employees;
using BsmCommon.Interfaces.Dal;
using BsmCommon.Interfaces.Managers;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

        
        public DateTime GetZmanBakasha(long bakasha_id)
        {
            using (var context = new KdsEntities())
            {

                var sql = string.Format("select zman_hatchala from tb_bakashot where bakasha_id={0}", bakasha_id);
                var res = context.Database.SqlQuery<DateTime>(sql).ToList();

                return (DateTime)res[0];
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

      
        ////////////////////////////////////

        public string GetLastTaarichcalc(DateTime Month,int kodYechida)
        {
            string chodesh = "01/"+ Month.Date.Month.ToString().PadLeft(2, '0') + "/" + Month.Date.Year;
            using (var context = new BsmEntities())
            {

                var sql = string.Format("select max(b.taarich_idkun) from tb_budget b where  to_char(b.chodesh,'dd/mm/yyyy')='{0}' and b.KOD_YECHIDA='{1}'", chodesh, kodYechida);
                var res = context.Database.SqlQuery<DateTime>(sql).ToList();

                return res[0].ToString();
            }
        }

        public DateTime GetLastDateIdkunBank(DateTime Month)
        {
            string chodesh = "01/" + Month.Date.Month.ToString().PadLeft(2, '0') + "/" + Month.Date.Year;
            using (var context = new KdsEntities())
            {

                var sql = string.Format("select max(taarich_close) from TB_CHISHUV_CLOSE where  to_char(taarich,'dd/mm/yyyy')='{0}' ", chodesh);
                var res = context.Database.SqlQuery<DateTime>(sql).ToList();

                return DateTime.Parse(res[0].ToString());
            }
        }

        public List<Yechida> GetYechidutForUser(DateTime Month, int KodYechida, string PreFix = "")
        {
            var GeneralDal = _container.Resolve<IGeneralDal>();

            var yechidot = GeneralDal.GetYechidotForUser(Month, KodYechida, PreFix);
            List<Yechida> list = new List<Yechida>();
            foreach (DataRow dr in yechidot.Rows)
            {
                Yechida item = new Yechida();
                item.TeurYechida = dr["TeurYechida"].ToString();
                item.KodYechida = int.Parse(dr["KodYechida"].ToString());
                list.Add(item);
            }
            return list;
        }

        public long GetLastBakashaOfTeken(DateTime Month)
        {
            string chodesh = Month.Date.Month.ToString().PadLeft(2, '0') + "/" + Month.Date.Year;
            using (var context = new KdsEntities())
            {

                var sql = string.Format("select max(b.bakasha_id) from tb_bakashot b,tb_bakashot_params p where b.sug_bakasha=27 and b.status=2 and b.bakasha_id=p.bakasha_id and p.erech='{0}'", chodesh);
                var res = context.Database.SqlQuery<decimal>(sql).ToList();

                return (long)res[0];
            }
        }


        public long GetLastBakashatChishuvPremia()
        {
        //    string chodesh = Month.Date.Month.ToString().PadLeft(2, '0') + "/" + Month.Date.Year;
            using (var context = new KdsEntities())
            {

                var sql = string.Format("select max(b.bakasha_id) from tb_bakashot b");

                var res = context.Database.SqlQuery<decimal>(sql).ToList();

                return (long)res[0];
            }
        }
    }
}
