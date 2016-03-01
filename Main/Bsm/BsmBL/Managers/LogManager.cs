using BsmBL.DAL;
using DalOraInfra.DAL;
using InfrastructureLogs.Logs.DataModels;
using InfrastructureLogs.Logs.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmBL.Managers
{
    public class LogManager : ILogManager
    {
        private IUnityContainer _container;
        public LogManager(IUnityContainer container)
        {
            _container = container;
        }

        public void AddItem(LogItem logItem)
        {
            clDal oDal = _container.Resolve<clDal>();
            try
            {
                oDal.AddParameter("p_mispar_ishi", ParameterType.ntOracleInteger, 0, ParameterDir.pdInput);
                oDal.AddParameter("p_kod_yechida", ParameterType.ntOracleInteger, 0, ParameterDir.pdInput);
                oDal.AddParameter("p_chodesh", ParameterType.ntOracleDate, null, ParameterDir.pdInput);
                oDal.AddParameter("p_meadken", ParameterType.ntOracleInteger, 0, ParameterDir.pdInput);
                oDal.AddParameter("p_meadken", ParameterType.ntOracleVarchar, logItem.Message, ParameterDir.pdInput);

                oDal.ExecuteSP("PKG_LOG.pro_ins_log");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
