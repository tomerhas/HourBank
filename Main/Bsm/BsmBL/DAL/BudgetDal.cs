using BsmCommon.Interfaces.DAL;
using DalOraInfra.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmBL.DAL
{
    public class BudgetDal : IBudgetDal
    {

        private const string cfunGetSumMeafyen14 = "PKG_BUDGET.fun_get_sum_meafyen14";
        private const string cfunGgetShaotNosafotMeshek = "PKG_BUDGET.fun_get_shaot_nosafot_meshek";
        private const string cProGetEmployeesDetailsForMitkan = "PKG_BUDGET.GetEmployeesDetailsForMitkan";

        public int GetSumMeafyen14(int KodYechida, DateTime Month, long BakashaId)
        {
            clDal oDal = new clDal();
            DataTable dt = new DataTable();

            try
            {//מחזיר נתוני עובד: 
                oDal.AddParameter("p_result", ParameterType.ntOracleInteger, null, ParameterDir.pdReturnValue);
                oDal.AddParameter("p_mitkan", ParameterType.ntOracleInteger, KodYechida, ParameterDir.pdInput);
                oDal.AddParameter("p_date",  ParameterType.ntOracleDate, Month, ParameterDir.pdInput);
                oDal.AddParameter("p_bakasha_id", ParameterType.ntOracleInt64, BakashaId, ParameterDir.pdInput);
               // oDal.AddParameter("p_Cur", ParameterType.ntOracleRefCursor, null, ParameterDir.pdOutput);
              //  oDal.ExecuteSP(cfunGetSumMeafyen14, ref dt);

                oDal.ExecuteSP(cfunGetSumMeafyen14);

                return int.Parse(oDal.GetValParam("p_result").ToString());

              //  return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetShaotnosafotMeshek(int KodYechida, DateTime Month, long BakashaId)
        {
            clDal oDal = new clDal();
            DataTable dt = new DataTable();

            try
            {//מחזיר נתוני עובד: 
                oDal.AddParameter("p_result", ParameterType.ntOracleInteger, null, ParameterDir.pdReturnValue);
                oDal.AddParameter("p_mitkan", ParameterType.ntOracleInteger, KodYechida, ParameterDir.pdInput);
                oDal.AddParameter("p_date", ParameterType.ntOracleDate, DateTime.Parse("01/03/2015"), ParameterDir.pdInput);
                oDal.AddParameter("p_bakasha_id", ParameterType.ntOracleInt64, BakashaId, ParameterDir.pdInput);
                // oDal.AddParameter("p_Cur", ParameterType.ntOracleRefCursor, null, ParameterDir.pdOutput);
                //  oDal.ExecuteSP(cfunGetSumMeafyen14, ref dt);

                oDal.ExecuteSP(cfunGgetShaotNosafotMeshek);

                return int.Parse(oDal.GetValParam("p_result").ToString());

                //  return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetEmployeeDatails(int KodYechida, DateTime Month, long BakashaId)
        {
            clDal oDal = new clDal();
            DataTable dt = new DataTable();

            try
            {//מחזיר נתוני עובד: 
              
                oDal.AddParameter("p_mitkan", ParameterType.ntOracleInteger, KodYechida, ParameterDir.pdInput);
                oDal.AddParameter("p_date", ParameterType.ntOracleDate, Month, ParameterDir.pdInput);
                oDal.AddParameter("p_bakasha_id", ParameterType.ntOracleInt64, BakashaId, ParameterDir.pdInput);
                 oDal.AddParameter("p_cur", ParameterType.ntOracleRefCursor, null, ParameterDir.pdOutput);
                //  oDal.ExecuteSP(cfunGetSumMeafyen14, ref dt);

                 oDal.ExecuteSP(cProGetEmployeesDetailsForMitkan, ref dt);

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
