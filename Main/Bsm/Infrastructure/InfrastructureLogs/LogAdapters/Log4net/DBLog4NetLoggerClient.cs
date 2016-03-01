using log4net.Appender;
using log4net.Core;
using Microsoft.Practices.ServiceLocation;
using InfrastructureLogs.Logs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLogs.Logs.LogAdapters.Log4net
{
    public class DBLog4NetLoggerClient : BaseDBLog4NetLogger
    {
        //When called on client side - use the proxy to send the log to the server
        protected override void Append(log4net.Core.LoggingEvent loggingEvent)
        {
            var logger = ServiceLocator.Current.GetInstance<ILogService>();
            
            logger.Log(loggingEvent.RenderedMessage, ConvertLogg4NetToCategory(loggingEvent.Level));
        }

        /// <summary>
        /// This function can be used by an applicative appender that has knowlege of the user info
        /// </summary>
        /// <param name="loggingEvent"></param>
        /// <param name="userName"></param>
        protected void Append(log4net.Core.LoggingEvent loggingEvent, string userName)
        {
            var logger = ServiceLocator.Current.GetInstance<ILogService>();
            logger.Log(loggingEvent.RenderedMessage, ConvertLogg4NetToCategory(loggingEvent.Level),userName);
        }

    }
}
