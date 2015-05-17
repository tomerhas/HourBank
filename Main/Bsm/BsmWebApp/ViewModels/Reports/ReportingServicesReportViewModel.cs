using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;


namespace BsmWebApp.ViewModels.Reports
{
    public class ReportingServicesReportViewModel
    {
        #region Constructor
        public ReportingServicesReportViewModel(String reportName, List<Microsoft.Reporting.WebForms.ReportParameter> Parameters)
        {

            ReportName = reportName;
            parameters = Parameters.ToArray();
            InilaizeReportViewer();
          //  SetListRenderingExtensions();
          //  SetStyleExportGroup();
        }
        public ReportingServicesReportViewModel()
        {
        }
        #endregion Constructor

        #region Public Properties
        public ReportViewer ReportViewer { get; set; }
      //  public ReportServerCredentials ServerCredentials { get { return new ReportServerCredentials(); } }
        public String ReportPath { get; set; }
        public String ReportName { get; set; }
      //  public Uri ReportServerURL { get { return new Uri(WebConfigurationManager.AppSettings["url_2012"]); } }
        public Microsoft.Reporting.WebForms.ReportParameter[] parameters { get; set; }
        private string UploadDirectory = HttpContext.Current.Server.MapPath("~/App_Data/UploadTemp/");
        private string TempDirectory = HttpContext.Current.Server.MapPath("~/tempFiles/");

        #endregion Properties

        private void InilaizeReportViewer()
        {
            ReportViewer = new ReportViewer();
            ReportViewer.ServerReport.ReportServerCredentials = new ReportServerCredentials();// ServerCredentials;

            ReportParameter[] RptParameters = parameters;

            //    lblRsVersion.Text = _Report.RSVersion;
            // RptViewer.Width = (_Report.Orientation == KdsLibrary.Utils.Reports.Orientation.Portrait) ? 790 : 1160;
            ReportViewer.PromptAreaCollapsed = true;
            ReportViewer.ShowBackButton = false;
            ReportViewer.ShowToolBar = true;
            ReportViewer.ShowDocumentMapButton = false;
            ReportViewer.ShowParameterPrompts = false;
            ReportViewer.ShowZoomControl = true;
            ReportViewer.ShowRefreshButton = false;
            ReportViewer.ShowFindControls = false;
            //   RptViewer.ZoomPercent = _Report.ZoomPercent;
          //  string userAgent = Request.ServerVariables.Get("HTTP_USER_AGENT");
          //  if (userAgent.Contains("MSIE 7.0"))
           //     ReportViewer.Attributes.Add("style", "margin-bottom: 30px;");

            ReportViewer.ProcessingMode = ProcessingMode.Remote;
            ReportViewer.ServerReport.ReportPath = ConfigurationSettings.AppSettings["RSFolderApplication"] + ReportName;
            ReportViewer.SizeToReportContent = false;
            ReportViewer.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["url_2012"]); //model.ReportServerURL;

            if (RptParameters.Count() > 0)
                ReportViewer.ServerReport.SetParameters(RptParameters);
            ReportViewer.ServerReport.Refresh();
        }

        private void SetListRenderingExtensions()
        {
           // KdsReport _Report = (KdsReport)Session["Report"];

            FieldInfo infoVisible, infoName;
            foreach (RenderingExtension extension in ReportViewer.ServerReport.ListRenderingExtensions())
            {
                infoVisible = extension.GetType().GetField("m_isVisible", BindingFlags.NonPublic | BindingFlags.Instance);
                infoName = extension.GetType().GetField("m_localizedName", BindingFlags.NonPublic | BindingFlags.Instance);
              //  if ((extension.Name != _Report.EXTENSION) && (extension.Name != "PDF") && (infoVisible != null))
                if ( (extension.Name != "PDF") && (infoVisible != null))
                    infoVisible.SetValue(extension, false);
               // if ((extension.Name == _Report.EXTENSION) && (infoName != null))
                if ((infoName != null))
                    infoName.SetValue(extension, "אקסל - Excel");
                if ((extension.Name == "PDF") && (infoName != null))
                    infoName.SetValue(extension, "Pdf");
            }
        }

        private void SetStyleExportGroup()
        {
            FieldInfo InfoExportButton;
            foreach (Control Ctrl in ReportViewer.Controls)
            {
                if (Ctrl.GetType().ToString() == "Microsoft.Reporting.WebForms.ToolbarControl")
                {
                    foreach (Control CtrlSub in Ctrl.Controls)
                    {
                        if (CtrlSub.GetType().ToString() == "Microsoft.Reporting.WebForms.ExportGroup")
                        {
                            foreach (Control CtrlSub2 in CtrlSub.Controls)
                            {
                                if (CtrlSub2.GetType().ToString() == "Microsoft.Reporting.WebForms.TextButton")
                                {
                                    InfoExportButton = CtrlSub2.GetType().GetField("m_text", BindingFlags.Instance | BindingFlags.NonPublic);
                                    InfoExportButton.SetValue(CtrlSub2, "יצוא");
                                }
                                //else // System.Web.UI.WebControls.DropDownList
                                //{
                                //    InfoExportButton = CtrlSub2.GetType().GetField("SelectedIndex", BindingFlags.Instance | BindingFlags.Public);
                                //    Ddl = (DropDownList)CtrlSub2;
                                //}
                            }
                        }
                    }
                }
            }
        }
    }



    [Serializable]
    public sealed class ReportServerCredentials : IReportServerConnection2//IReportServerCredentials
    {

        #region Private Properties
        private string _username;
        private string _password;
        private string _domain;
        #endregion Private Properties

        #region Public Properties
        public System.Security.Principal.WindowsIdentity ImpersonationUser
        {
            get { return null; }
        }

        public System.Net.ICredentials NetworkCredentials
        {
            get { return new NetworkCredential(_username, _password, _domain); }
        }
        #endregion Public Properties

        #region Constructor
        public ReportServerCredentials(string userName, string password, string domain)
        {
            _username = userName;
            _password = password;
            _domain = domain;
        }
        public ReportServerCredentials()
        {
            var appSetting = WebConfigurationManager.AppSettings;
            _username = appSetting["ReportServerUser"];
            _password = appSetting["ReportServerPassword"];
            _domain = appSetting["ReportServerDomain"];
        }
        #endregion Constructor

        #region Public Method
        public bool GetFormsCredentials(out System.Net.Cookie authCookie, out string userName, out string password, out string authority)
        {
            authCookie = null;
            userName = null;
            password = null;
            authority = null;
            return false;
        }
        #endregion Public Method


        public IEnumerable<Cookie> Cookies { get { return null; } }


        public IEnumerable<string> Headers { get { return null; } }

        public Uri ReportServerUrl { get { return new Uri(WebConfigurationManager.AppSettings["url_2012"]); } }


        public int Timeout { get { return 60000; } }
    }
}