using BsmBL.DAL;
using BsmCommon.DataModels.Employees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Metadata.Edm;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTests
{
    [TestClass]
    public class OracleSqlTester
    {
        [TestMethod]
        public void call_function()
        {
            //var BudgetManager =ServiceLocator.Current.GetInstance<IBudgetDal>();
            //int sum = BudgetManager.GetSumMeafyen14(KodYechida, Month, bakasha_id);
            //return sum; 
            // using (var context = new BsmEntities())
            //{
            //    var result = new OracleParameter("p_cur", OracleDbType.RefCursor, ParameterDirection.Output);
            //    var x = context.Database.SqlQuery<int>("BEGIN PKG_Budget.getEzors(:p_cur); end;", result).ToList();
            //}

        //   
             using (var context = new BsmEntities())
             {
                 var p_mitkan  = new OracleParameter("p_mitkan", OracleDbType.Int32, 87783, ParameterDirection.Input);
                 var p_date = new OracleParameter("p_date", OracleDbType.Date, DateTime.Parse("01/04/2015"), ParameterDirection.Input);
                 var p_bakasha_id = new OracleParameter("p_bakasha_id", OracleDbType.Int64, 19046, ParameterDirection.Input);
                  var result = new OracleParameter("p_cur", OracleDbType.RefCursor, ParameterDirection.Output);
                 
                  var sum = context.Database.SqlQuery<emp>("BEGIN PKG_BUDGET.GetEmployeesDetailsForMitkan(:p_mitkan, :p_date, :p_bakasha_id, :p_cur); end;", p_mitkan, p_date, p_bakasha_id, result).ToList();

           }  
        }

        [TestMethod]
        public void GetOvedimId_StartsWithFunc_Succeeds()
        {
            using (var db = new KdsEntities())
            {
                //'%:param1%'
                var sql = string.Format("select mispar_ishi as MisparIshi, SHEM_PRAT as Firstname, SHEM_MISH as LastName  from ovdim where to_char(mispar_ishi) like '{0}%'","12");
                var res = db.Database.SqlQuery<Oved>(sql);
                //var res = db.Ovdim.Where(x => x.to_char(x.MisparIshi).Contains("12"));
                var list =  res.ToList();
            }
        }

        [TestMethod]
        public void GetOvedimId_IntCollection_Succeeds()
        {
            using (var db = new KdsEntities())
            {
                //'%:param1%'
                var sql = string.Format("select mispar_ishi from ovdim where to_char(mispar_ishi) like '{0}%'", "12");
                var res = db.Database.SqlQuery<int>(sql);
                //var res = db.Ovdim.Where(x => x.to_char(x.MisparIshi).Contains("12"));
                var list = res.ToList();
            }
        }
    }

    public class emp
    {

        public decimal masad { get; set; }
    }
}
