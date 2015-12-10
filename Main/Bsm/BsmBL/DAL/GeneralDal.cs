using BsmCommon.Interfaces.Dal;
using DalOraInfra.DAL;
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

        public DataTable GetYechidotForUser(DateTime Month, int KodYechida,string PreFix="")
        {
            try
            {//מחזיר נתוני עובד: 
                clDal oDal = new clDal();
                DataTable dt = new DataTable();
          
                oDal.AddParameter("p_taarich", ParameterType.ntOracleDate, Month, ParameterDir.pdInput);
                oDal.AddParameter("p_user_yechida", ParameterType.ntOracleInteger, KodYechida, ParameterDir.pdInput);
                oDal.AddParameter("p_PreFix", ParameterType.ntOracleVarchar, PreFix, ParameterDir.pdInput);  
                oDal.AddParameter("p_cur", ParameterType.ntOracleRefCursor, null, ParameterDir.pdOutput);
                //  oDal.ExecuteSP(cfunGetSumMeafyen14, ref dt);
                oDal.ExecuteSP(cProGetYechidotForUser, ref dt);
                return dt;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("kds",ex.Message);
                throw ex;
            }
        }
    }
}
