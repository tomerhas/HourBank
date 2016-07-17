using BsmCommon.Interfaces.DAL;
using BsmCommon.UDT;
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
    public class BudgetDal : IBudgetDal
    {

        private const string cfunGetSumMeafyen14 = "PKG_BUDGET.fun_get_sum_meafyen14";
        private const string cfunGgetShaotNosafotMeshek = "PKG_BUDGET.fun_get_shaot_nosafot_meshek";
        private const string cProGetEmployeesDetailsForMitkan = "PKG_BUDGET.GetEmployeesDetailsForMitkan";
        private const string cFunSaveEmployeeBudgets = "PKG_BUDGET.fun_save_employee_Michsot";
        private const string cFunGetFullBudget = "PKG_BUDGET.fun_get_full_budget_mitkan";
        private const string cProSaveBudgetLeft = "PKG_BUDGET.pro_update_budget_left";
        private IUnityContainer _container;

        public BudgetDal(IUnityContainer container)
        {
            _container = container;
        }

        public float GetSumMeafyen14(int KodYechida, DateTime Month)
        {
            clDal oDal = _container.Resolve<clDal>();
            DataTable dt = new DataTable();

            try
            {
                oDal.AddParameter("p_result", ParameterType.ntOracleDecimal, null, ParameterDir.pdReturnValue);
                oDal.AddParameter("p_mitkan", ParameterType.ntOracleInteger, KodYechida, ParameterDir.pdInput);
                oDal.AddParameter("p_date",  ParameterType.ntOracleDate, Month, ParameterDir.pdInput);
             //   oDal.AddParameter("p_bakasha_id", ParameterType.ntOracleInt64, BakashaId, ParameterDir.pdInput);
               // oDal.AddParameter("p_Cur", ParameterType.ntOracleRefCursor, null, ParameterDir.pdOutput);
              //  oDal.ExecuteSP(cfunGetSumMeafyen14, ref dt);

                oDal.ExecuteSP(cfunGetSumMeafyen14);

                return oDal.GetValParam("p_result") != "null" ? float.Parse(oDal.GetValParam("p_result").ToString()) : 0;

              //  return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public float GetShaotnosafotMeshek(int KodYechida, DateTime Month)
        {
            clDal oDal = _container.Resolve<clDal>();
            DataTable dt = new DataTable();

            try
            {//מחזיר נתוני עובד: 
                oDal.AddParameter("p_result", ParameterType.ntOracleDecimal, null, ParameterDir.pdReturnValue);
                oDal.AddParameter("p_mitkan", ParameterType.ntOracleInteger, KodYechida, ParameterDir.pdInput);
                oDal.AddParameter("p_date", ParameterType.ntOracleDate, Month, ParameterDir.pdInput);
                // oDal.AddParameter("p_Cur", ParameterType.ntOracleRefCursor, null, ParameterDir.pdOutput);
                //  oDal.ExecuteSP(cfunGetSumMeafyen14, ref dt);

                oDal.ExecuteSP(cfunGgetShaotNosafotMeshek);

                return float.Parse(oDal.GetValParam("p_result").ToString());

                //  return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetEmployeeDatails(int KodYechida, DateTime Month)
        {
            clDal oDal = _container.Resolve<clDal>();
            DataTable dt = new DataTable();

            try
            {//מחזיר נתוני עובד: 
              
                oDal.AddParameter("p_mitkan", ParameterType.ntOracleInteger, KodYechida, ParameterDir.pdInput);
                oDal.AddParameter("p_date", ParameterType.ntOracleDate, Month, ParameterDir.pdInput);           
                 oDal.AddParameter("p_cur", ParameterType.ntOracleRefCursor, null, ParameterDir.pdOutput);
                //  oDal.ExecuteSP(cfunGetSumMeafyen14, ref dt);

                 oDal.ExecuteSP(cProGetEmployeesDetailsForMitkan, dt);
                return dt;
              //  return int.Parse(oDal.GetValParam("p_result").ToString());

                //  return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SaveEmployeeMichsot(int KodYechida, int userId, COLL_BUDGET_EMPLOYEES_MICHSA ocollMichsot)
        {
            clDal oDal = _container.Resolve<clDal>();
            try
            {
                oDal.AddParameter("p_code", ParameterType.ntOracleInteger, null, ParameterDir.pdReturnValue);
                oDal.AddParameter("p_kod_yechida", ParameterType.ntOracleInteger, KodYechida, ParameterDir.pdInput);
                oDal.AddParameter("p_user_id", ParameterType.ntOracleInteger, userId, ParameterDir.pdInput);           
                oDal.AddParameter("p_coll_employe_michsa", ParameterType.ntOracleArray, ocollMichsot, ParameterDir.pdInput, "COLL_BUDGET_EMPLOYEES_MICHSA");

                oDal.ExecuteSP(cFunSaveEmployeeBudgets);
                return int.Parse(oDal.GetValParam("p_code").ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public float GetFullBudgetToMitkan(int KodYechida, DateTime Month, int type)
        {
            clDal oDal = _container.Resolve<clDal>();
            DataTable dt = new DataTable();

            try
            {
                oDal.AddParameter("p_result", ParameterType.ntOracleDecimal, null, ParameterDir.pdReturnValue);
                oDal.AddParameter("p_kod_yechida", ParameterType.ntOracleInteger, KodYechida, ParameterDir.pdInput);
                oDal.AddParameter("p_chodesh", ParameterType.ntOracleDate, Month, ParameterDir.pdInput);
                oDal.ExecuteSP(cFunGetFullBudget);

                return oDal.GetValParam("p_result") != "null" ? float.Parse(oDal.GetValParam("p_result").ToString()) : 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveBudgetLeft(int p_kod_yechida, DateTime p_chodesh, int p_user)
        {
            clDal oDal = _container.Resolve<clDal>();
            DataTable dt = new DataTable();

            try
            {//מחזיר נתוני עובד: 
                oDal.AddParameter("p_kod_yechida", ParameterType.ntOracleInteger, p_kod_yechida, ParameterDir.pdInput);
                oDal.AddParameter("p_chodesh", ParameterType.ntOracleDate, p_chodesh, ParameterDir.pdInput);
                oDal.AddParameter("p_user", ParameterType.ntOracleInteger, p_user, ParameterDir.pdInput);

                oDal.ExecuteSP(cProSaveBudgetLeft);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
