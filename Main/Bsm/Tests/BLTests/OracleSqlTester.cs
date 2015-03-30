using BsmBL.DAL;
using BsmCommon.DataModels.Employees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
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
}
