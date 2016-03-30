using BsmCommon.Interfaces.Dal;
using DalOraInfra.DAL;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmBL.DAL
{
    public class GeneralDal : IGeneralDal
    {
        private const string cProGetYechidotForUser = "PKG_BUDGET.getYechidotToUser";
        private IUnityContainer _container;

        public GeneralDal(IUnityContainer container)
        {
            _container = container;
        }

        public DataTable GetYechidotForUser(DateTime Month, int isuk, int YechidaIrgunitOved, string PreFix="")
        {
            try
            {//מחזיר נתוני עובד: 
                clDal oDal = _container.Resolve<clDal>();
                DataTable dt = new DataTable();
          
                oDal.AddParameter("p_taarich", ParameterType.ntOracleDate, Month, ParameterDir.pdInput);
                oDal.AddParameter("p_Isuk", ParameterType.ntOracleInteger, isuk, ParameterDir.pdInput);
                oDal.AddParameter("p_user_yechida", ParameterType.ntOracleInteger, YechidaIrgunitOved, ParameterDir.pdInput);
                oDal.AddParameter("p_PreFix", ParameterType.ntOracleVarchar, PreFix, ParameterDir.pdInput);  
                oDal.AddParameter("p_cur", ParameterType.ntOracleRefCursor, null, ParameterDir.pdOutput);
                //  oDal.ExecuteSP(cfunGetSumMeafyen14, ref dt);
                oDal.ExecuteSP(cProGetYechidotForUser, dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
