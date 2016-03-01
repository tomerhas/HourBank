using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLogs.Logs.DataModels
{
    
    public class LogItem
    {
        [Key, Column("MISPAR_SIDURI")] 			
        public int LogItemId { get; set; }
        [Column("MEADKEN")] 			
        public string User { get; set; }
        [Column("TAARICH_IDKUN_ACHARON")] 			
        public DateTime Date { get; set; }
        //[Column("CATEGORY")] 			
        //public string Category { get; set; }
        [Column("TEUR_HODAA")] 			
        public string Message { get; set; }
    }
}
