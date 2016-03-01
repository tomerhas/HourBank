using InfrastructureLogs.Logs.DataModels;
using InfrastructureLogs.Logs.Interfaces;
using log4net;
using Microsoft.Practices.Prism.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLogs.Logs.LogAdapters.Log4net
{
    /// <summary>
    /// A global class for mapping Prism ILoggerFacade interface to write to Log4Net.
    /// The actual log will be written according to the log4net configurations (e.g multiple appenders will cause the log to be written to multiple locations
    /// so if there is a file appender and db appender - logs will be writen to both)
    /// 
    /// The correct way to use logging in the app:
    /// in the app bootstraper map the ILoggerFacade to the Log4NetLoggerFacade implementation. 
    /// from the app always log using the ILoggerFacade. This will cause logs to be written according to log4net config
    /// In the app config use the required appenders (e.g. file, trace DB)
    /// To add the DB appender - need to add the following to the client config:
    /// <appender name="DBLogAppender" type="ClientCommon.Logger.DBLog4netLoggerClientApp">
    ///  <layout type="log4net.Layout.PatternLayout">
    ///    <param name="ConversionPattern" value="%d Thread: [%thread] %-5p-[%logger] %m%n" />
    ///  </layout>
    ///  </appender>
    ///  and for the server;
    ///   <appender name="DBLogAppender" type="InfrastructureLogs.Logs.LogAdapters.Log4net.DBLog4NetLoggerServer">
    ///   ...
    /// </summary>
    public class Log4NetLoggerFacade : ILogger
    {
        private ILog log;
        public Log4NetLoggerFacade(string appName)
        {
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
            log = LogManager.GetLogger(appName);
        }

        public virtual void Log(string message, Category category, Priority priority)
        {
            switch (category)
            {
                case Category.Debug:
                    LogDebug(message, Priority.None);
                    break;
                case Category.Info:
                    LogInfo(message, Priority.None);
                    break;
                case Category.Exception:
                    LogException(message, Priority.None);
                    break;
                case Category.Warn:
                    LogWarn(message, Priority.None);
                    break;
            }

        }

        private void LogWarn(string message, Priority priority)
        {
            log.Warn(message);
        }

        private void LogException(string message, Priority priority)
        {
            log.Error(message);
        }

        private void LogDebug(string message, Priority priority)
        {
            log.Debug(message);
        }

        private void LogInfo(string message, Priority priority)
        {
            log.Info(message);
        }
    }
}
