using BsmBL.ReportService;
using BsmCommon.DataModels.Reports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmBL.Managers.Reports
{
    public class ReportManager
    {
      
        public Byte[] CreateReport(Report rdl)
        {
            string  encoding, mimeType, extension;
            string historyID = null, devInfo ;
            ReportExecutionService rs = new ReportExecutionService();
            Warning[] warnings2012 = null;
            Byte[] CurrentReportByte ;
            string[] streamIDs = null;
            try
            {
                devInfo = @"<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>";
                rs.Credentials = new System.Net.NetworkCredential(ConfigurationSettings.AppSettings["RSUserName"], ConfigurationSettings.AppSettings["RSPassword"], ConfigurationSettings.AppSettings["RSDomain"]);
                rs.Url = ConfigurationSettings.AppSettings["service_url_2012"];
                ExecutionInfo execInfo = new ExecutionInfo();
                ExecutionHeader execHeader = new ExecutionHeader();

                rs.ExecutionHeaderValue = execHeader;
                rs.Timeout = 1000000000;
                execInfo = rs.LoadReport(rdl.sRdlName, historyID);
                rs.SetExecutionParameters(GetParamsObject(rdl.ReportParams) , "he-IL");
                String SessionId = rs.ExecutionHeaderValue.ExecutionID;
                CurrentReportByte = rs.Render(rdl.Extension.ToString(), devInfo, out extension, out mimeType, out encoding, out warnings2012, out streamIDs);
                return CurrentReportByte;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                rs.Dispose();
               // parameters2012 = null;
            }
        }

        private ParameterValue[] GetParamsObject(List<ReportParam> listParam)
        {
            ParameterValue[] parameters2012 = new ParameterValue[0];
            int LengthParam2012;
            try
            {

                listParam.ForEach(p =>
                {
                    LengthParam2012 = parameters2012.Length;
                    Array.Resize(ref parameters2012, LengthParam2012 + 1);
                    parameters2012[LengthParam2012] = new ParameterValue();
                    parameters2012[LengthParam2012].Name = p.Name;
                    parameters2012[LengthParam2012].Value = p.Value;
                });

                return parameters2012;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
