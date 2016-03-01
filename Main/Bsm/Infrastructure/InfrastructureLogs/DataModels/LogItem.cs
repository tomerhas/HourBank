using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLogs.Logs.DataModels
{
    [Table("Logs")]
    public class LogItem
    {
        public int LogItemId { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string Message { get; set; }
    }
}
