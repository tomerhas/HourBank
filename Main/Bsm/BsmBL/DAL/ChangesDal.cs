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
        private const string cProAddTakzivToMitkan = "PKG_CHANGES.PRO_ADD_TAKZIV_TO_MITKAN";
        private const string cProAddNewTakziv = "PKG_CHANGES.PRO_ADD_NEW_TAKZIV";
        private const string cProSaveChangeMitkan = "PKG_CHANGES.pro_save_change_mitkan";
        private const string cProSaveReductionMitkan = "PKG_CHANGES.pro_save_reducation_mitkan";
       
        
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

        public void AddTakzivLeMitkan(int p_mitkan,DateTime p_chodesh, int p_id_takziv, decimal p_kamut, string p_reason,int p_user)
        {
            clDal oDal = _container.Resolve<clDal>();
            DataTable dt = new DataTable();

            try
            {//מחזיר נתוני עובד: 
                oDal.AddParameter("p_mitkan", ParameterType.ntOracleInteger, p_mitkan, ParameterDir.pdInput);
                oDal.AddParameter("p_chodesh", ParameterType.ntOracleDate, p_chodesh, ParameterDir.pdInput);
                oDal.AddParameter("p_id_takziv", ParameterType.ntOracleInteger, p_id_takziv, ParameterDir.pdInput);
                oDal.AddParameter("p_kamut", ParameterType.ntOracleDecimal, p_kamut, ParameterDir.pdInput);
                oDal.AddParameter("p_reason", ParameterType.ntOracleVarchar, p_reason, ParameterDir.pdInput);
                oDal.AddParameter("p_user", ParameterType.ntOracleInteger, p_user, ParameterDir.pdInput);

                oDal.ExecuteSP(cProAddTakzivToMitkan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddNewTakziv(int p_id_takziv,string p_teur, decimal p_kamut, string p_reason, int p_user)
        {
            clDal oDal = _container.Resolve<clDal>();
            DataTable dt = new DataTable();

            try
            {//מחזיר נתוני עובד: 
                oDal.AddParameter("p_id_takziv", ParameterType.ntOracleInteger, p_id_takziv, ParameterDir.pdInput);
                oDal.AddParameter("p_teur", ParameterType.ntOracleVarchar, p_teur, ParameterDir.pdInput);
                oDal.AddParameter("p_kamut", ParameterType.ntOracleDecimal, p_kamut, ParameterDir.pdInput);
                oDal.AddParameter("p_reason", ParameterType.ntOracleVarchar, p_reason, ParameterDir.pdInput);
                oDal.AddParameter("p_user", ParameterType.ntOracleInteger, p_user, ParameterDir.pdInput);

                oDal.ExecuteSP(cProAddNewTakziv);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveChangeMitkan(int p_mitkan, DateTime p_chodesh, decimal p_erech, string p_reason, int p_user,int p_type)
        {
            clDal oDal = _container.Resolve<clDal>();
            DataTable dt = new DataTable();

            try
            {//מחזיר נתוני עובד: 
                oDal.AddParameter("p_mitkan", ParameterType.ntOracleInteger, p_mitkan, ParameterDir.pdInput);
                oDal.AddParameter("p_chodesh", ParameterType.ntOracleDate, p_chodesh, ParameterDir.pdInput);
                oDal.AddParameter("p_erech", ParameterType.ntOracleDecimal, p_erech, ParameterDir.pdInput);
                oDal.AddParameter("p_reason", ParameterType.ntOracleVarchar, p_reason, ParameterDir.pdInput);
                oDal.AddParameter("p_user", ParameterType.ntOracleInteger, p_user, ParameterDir.pdInput);
                oDal.AddParameter("p_type", ParameterType.ntOracleInteger, p_type, ParameterDir.pdInput);

                oDal.ExecuteSP(cProSaveChangeMitkan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveReductionMitkan(int p_mitkan, DateTime p_chodesh, decimal p_kamut, string p_reason, int p_user)
        {
            clDal oDal = _container.Resolve<clDal>();
            DataTable dt = new DataTable();

            try
            {//מחזיר נתוני עובד: 
                oDal.AddParameter("p_mitkan", ParameterType.ntOracleInteger, p_mitkan, ParameterDir.pdInput);
                oDal.AddParameter("p_chodesh", ParameterType.ntOracleDate, p_chodesh, ParameterDir.pdInput);
                oDal.AddParameter("p_kamut", ParameterType.ntOracleDecimal, p_kamut, ParameterDir.pdInput);
                oDal.AddParameter("p_reason", ParameterType.ntOracleVarchar, p_reason, ParameterDir.pdInput);
                oDal.AddParameter("p_user", ParameterType.ntOracleInteger, p_user, ParameterDir.pdInput);

                oDal.ExecuteSP(cProSaveReductionMitkan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        

    }
}
