using log4net.Appender;
using log4net.Core;
using InfrastructureLogs.Common.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLogs.Logs.LogAdapters.Log4net
{
    /// <summary>
    /// The base db log4net inherits from log4net appender.
    /// It is used by client or server implementation.
    /// The client will call the server to log.
    /// The server will do the actual logging to the DB
    /// By setting the appender in the log4net config (a different appender for client and server) -when trying to log from client or server calls will be mapped accordingly
    /// </summary>
    public abstract class BaseDBLog4NetLogger : AppenderSkeleton
    {   
        protected Category ConvertLogg4NetToCategory(Level level)
        {
            if (level.DisplayName == "DEBUG")
                return Category.Debug;
            if (level.DisplayName == "WARN")
                return Category.Warn;
            if (level.DisplayName == "ERROR" || level.DisplayName == "FATAL" || level.DisplayName == "CRITICAL")
                return Category.Exception;
            else
                return Category.Info;
        }

    }
}
