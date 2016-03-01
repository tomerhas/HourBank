using InfrastructureLogs.Logs.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLogs.Logs.Interfaces
{
    public interface ILogEntity
    {
        DbSet<LogItem> Logs { get; set; }
    }
}
