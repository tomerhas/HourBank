using BsmCommon.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.DataModels.Reports
{
    public class Report
    {
        public List<ReportParam> ReportParams { get; set; }
        public string sRdlName { get; set; }
        public string sTeur { get; set; }
        public int iKodReport { get; set; }
        public bool HasPeriodParameters = false;
        public eFormat Extension { get; set; }
       // private long _BakashaId;
       // private int _MisparIshi;
        public string sRSVersion { get; set; }
        public string sUrlConfigKey { get; set; }
        public string sServiceUrlConfigKey { get; set; }
    }
}
