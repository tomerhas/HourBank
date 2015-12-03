using BsmCommon.Interfaces.DAL;
using BsmCommon.UDT;
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
        private const string cProSaveEmployeeBudgets = "PKG_BUDGET.pro_save_employee_Michsot";

        public int GetSumMeafyen14(int KodYechida, DateTime Month)
        {
            clDal oDal = new clDal();
            DataTable dt = new DataTable();

            try
            {//מחזיר נתוני עובד: 
                oDal.AddParameter("p_result", ParameterType.ntOracleInteger, null, ParameterDir.pdReturnValue);
                oDal.AddParameter("p_mitkan", ParameterType.ntOracleInteger, KodYechida, ParameterDir.pdInput);
                oDal.AddParameter("p_date",  ParameterType.ntOracleDate, Month, ParameterDir.pdInput);
             //   oDal.AddParameter("p_bakasha_id", ParameterType.ntOracleInt64, BakashaId, ParameterDir.pdInput);
               // oDal.AddParameter("p_Cur", ParameterType.ntOracleRefCursor, null, ParameterDir.pdOutput);
              //  oDal.ExecuteSP(cfunGetSumMeafyen14, ref dt);

                oDal.ExecuteSP(cfunGetSumMeafyen14);

                return oDal.GetValParam("p_result") != "null" ? int.Parse(oDal.GetValParam("p_result").ToString()) : 0;

              //  return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal GetShaotnosafotMeshek(int KodYechida, DateTime Month)
        {
            clDal oDal = new clDal();
            DataTable dt = new DataTable();

            try
            {//מחזיר נתוני עובד: 
                oDal.AddParameter("p_result", ParameterType.ntOracleInteger, null, ParameterDir.pdReturnValue);
                oDal.AddParameter("p_mitkan", ParameterType.ntOracleInteger, KodYechida, ParameterDir.pdInput);
                oDal.AddParameter("p_date", ParameterType.ntOracleDate, Month, ParameterDir.pdInput);
                // oDal.AddParameter("p_Cur", ParameterType.ntOracleRefCursor, null, ParameterDir.pdOutput);
                //  oDal.ExecuteSP(cfunGetSumMeafyen14, ref dt);

                oDal.ExecuteSP(cfunGgetShaotNosafotMeshek);

                return decimal.Parse(oDal.GetValParam("p_result").ToString());

                //  return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetEmployeeDatails(int KodYechida, DateTime Month)
        {
            clDal oDal = new clDal();
            DataTable dt = new DataTable();

            try
            {//מחזיר נתוני עובד: 
              
                oDal.AddParameter("p_mitkan", ParameterType.ntOracleInteger, KodYechida, ParameterDir.pdInput);
                oDal.AddParameter("p_date", ParameterType.ntOracleDate, Month, ParameterDir.pdInput);           
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

        public void SaveEmployeeMichsot(COLL_BUDGET_EMPLOYEES_MICHSA ocollMichsot)
        {
            clDal oDal = new clDal();
            try
            {
                oDal.AddParameter("p_coll_employe_michsa", ParameterType.ntOracleArray, ocollMichsot, ParameterDir.pdInput, "COLL_BUDGET_EMPLOYEES_MICHSA");

                oDal.ExecuteSP(cProSaveEmployeeBudgets);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
