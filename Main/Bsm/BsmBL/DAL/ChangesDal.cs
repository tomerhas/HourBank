using BsmCommon.Interfaces.Dal;
using DalOraInfra.DAL;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmBL.DAL
{
    public class ChangesDal : IChangesDal
    {
        private const string cProGetChanges = "PKG_CHANGES.PRO_Get_changes";
        private IUnityContainer _container;

        public ChangesDal(IUnityContainer container)
        {
            _container = container;
        }

        public DataTable GetChangesShaotNosafot(int KodEzor, DateTime Month, int isuk, int KodMitkan)
        {
            clDal oDal = _container.Resolve<clDal>();
            DataTable dt = new DataTable();

            try
            {//מחזיר נתוני עובד: 
                oDal.AddParameter("p_ezor", ParameterType.ntOracleInteger, KodEzor, ParameterDir.pdInput);
                oDal.AddParameter("p_taarich", ParameterType.ntOracleDate, Month, ParameterDir.pdInput);
                oDal.AddParameter("p_isuk", ParameterType.ntOracleInteger, isuk, ParameterDir.pdInput);
                oDal.AddParameter("p_user_yechida", ParameterType.ntOracleInteger, KodMitkan, ParameterDir.pdInput);

                oDal.AddParameter("p_cur", ParameterType.ntOracleRefCursor, null, ParameterDir.pdOutput);
                //  oDal.ExecuteSP(cfunGetSumMeafyen14, ref dt);

                oDal.ExecuteSP(cProGetChanges, dt);

                return dt;
                //  return int.Parse(oDal.GetValParam("p_result").ToString());

                //  return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
