//using Microsoft.Practices.ServiceLocation;
//using InfrastructureLogs.Common.Logs;
//using InfrastructureLogs.Common.WCF;
//using InfrastructureLogs.Logs.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace InfrastructureLogs.Logs.Proxies
//{
//    /// <summary>
//    /// A class that is used on the client side. When called will  send the log to the server for unified logging
//    /// </summary>
//    public class LogProxy : DisposableClientBase<ILogService>, ILogService
//    {
//        public void Log(string message, Category category)
//        {
//            //Try to retrieve the users name before sending message
//            string userName = string.Empty;
//            try
//            {
//                var userNameProvider = ServiceLocator.Current.GetInstance<IUserNameProvider>();
//                userName = userNameProvider.UserName;
//            }
//            catch { }
//            Channel.Log(message, category, userName);
//        }

//        public void Log(string message, Category category, string user)
//        {
//            Channel.Log(message, category,user);
//        }
//    }
//}
