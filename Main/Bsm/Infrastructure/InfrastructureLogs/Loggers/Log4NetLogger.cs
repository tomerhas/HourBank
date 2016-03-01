using log4net;
using InfrastructureLogs.Logs.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfrastructureLogs.Logs.DataModels;

namespace InfrastructureLogs.Logs.Loggers
{
    /// <summary>
    /// This is the main log 4 net class that must be called from in the bootstraper
    /// The descision as to where to write the logs (file, trace, DB) is from the configuration. Yet all log calls will first be mapped here
    /// </summary>
    public class Log4NetLogger : ILogger
    {
        private ILog log;
        public Log4NetLogger(string appName,string configFilePath = "")
        {
            FileInfo fileInfo = null;
            if (string.IsNullOrWhiteSpace(configFilePath))
            {
                fileInfo = new FileInfo("log4net.config");
            }
            else 
            {
                fileInfo = new FileInfo(configFilePath);
            }
            log4net.Config.XmlConfigurator.Configure(fileInfo);
            log = LogManager.GetLogger(appName);
        }

        public void Log(string message, Category category, string user = "")
        {
            switch (category)
            {
                case Category.Debug:
                    LogDebug(message);
                    break;
                case Category.Info:
                    LogInfo(message);
                    break;
                case Category.Exception:
                    LogException(message);
                    break;
                case Category.Warn:
                    LogWarn(message);
                    break;
            }
        }

       
        private void LogWarn(string message)
        {
            log.Warn(message);
        }

        private void LogException(string message)
        {
            log.Error(message);
        }

        private void LogDebug(string message)
        {
            log.Debug(message);
        }

        private void LogInfo(string message)
        {
            log.Info(message);
        }
    }
}
