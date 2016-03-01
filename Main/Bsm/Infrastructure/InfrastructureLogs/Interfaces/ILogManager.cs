//using InfrastructureLogs.DalEF.Interfaces;
using InfrastructureLogs.Logs.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLogs.Logs.Interfaces
{
    public interface ILogManager
    {
        void AddItem(LogItem logItem);
    }
}
