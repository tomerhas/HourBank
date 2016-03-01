//using Microsoft.Practices.ServiceLocation;
//using InfrastructureLogs.Common.Logs;
//using InfrastructureLogs.Logs.DataModels;
//using InfrastructureLogs.Logs.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.ServiceModel;
//using System.Text;
//using System.Threading.Tasks;

//namespace InfrastructureLogs.Logs.Services
//{
//    /// <summary>
//    /// The WCF service for recieving the log requests from the clients. Will then call the implemented ILogger for writing to file or DB
//    /// </summary>
//    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)] 
//    public class LogService : ILogService
//    {
//        public void Log(string message, Category category)
//        {
//            var logger =  ServiceLocator.Current.GetInstance<IDbLogger>();
//            logger.Log(message, category);
//        }

//        public void Log(string message, Category category, string user)
//        {
//            var logger = ServiceLocator.Current.GetInstance<IDbLogger>();
//            logger.Log(message, category,user);
//        }
//    }
//}
