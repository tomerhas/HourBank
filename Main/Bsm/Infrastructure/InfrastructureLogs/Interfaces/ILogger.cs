using InfrastructureLogs.Logs.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLogs.Logs.Interfaces
{
    public interface ILogger
    {
        void Log(string message, Category category, string user = "");
    }
}
