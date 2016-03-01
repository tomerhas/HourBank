using Microsoft.Practices.ServiceLocation;
using InfrastructureLogs.Logs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLogs.Logs.LogAdapters.Log4net
{
    public class DBLog4NetLoggerServer : BaseDBLog4NetLogger
    {
        protected override void Append(log4net.Core.LoggingEvent loggingEvent)
        {
            try
            {
                var logger = ServiceLocator.Current.GetInstance<IDbLogger>();
                logger.Log(loggingEvent.RenderedMessage, ConvertLogg4NetToCategory(loggingEvent.Level));
            }
            catch { }
        }
    }
}
