using Microsoft.Practices.Unity;
using InfrastructureLogs.Logs.DataModels;
using InfrastructureLogs.Logs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLogs.Logs.Loggers
{
    /// <summary>
    /// Implements the ILogger interface and writes the logs to the DB
    /// </summary>
    public class DbLogger : IDbLogger
    {
        private IUnityContainer _container;
        public DbLogger(IUnityContainer container)
        {
            _container = container;
        }

        public void Log(string message, Category category, string user = "")
        {
            try
            {
                var logManager = _container.Resolve<ILogManager>();
                //logManager.AddItem(new LogItem() { Category = category.ToString(), Message = message, Date = DateTime.Now, User = user });
                logManager.AddItem(new LogItem() {  Message = string.Format("{0} - {1}",category.ToString() ,message), Date = DateTime.Now, User = user });
            }
            catch (Exception ex)
            {

            }
        }
    }
}
