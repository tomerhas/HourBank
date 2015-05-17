<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ReportViewerWebForm.cs" Inherits="ReportViewerForMvc.ReportViewerWebForm" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html  xmlns="http://www.w3.org/1999/xhtml">

<%--#reportViewerContainer > span
{
    display:block;
    height:100% !important;
}

.reportViewer
{
    height:100% !important;
}--%>
<head runat="server">
    <title></title>
      <script src='../Scripts/jquery-1.11.1.min.js' type='text/javascript'></script>  
 
    <%--  <meta http-equiv="X-UA-Compatible" content="IE=8" />--%>
</head>
<body >

    <form id="form1"    runat="server">
        <div >
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference  Assembly="ReportViewerForMvc" Name="ReportViewerForMvc.Scripts.PostMessage.js" />
                </Scripts>
            </asp:ScriptManager>   
            <rsweb:ReportViewer ID="ReportViewer1"   style="Height:800px;Width:850px;direction:rtl" AsyncRendering="false" SizeToReportContent="false"    ZoomMode="FullPage"   runat="server"></rsweb:ReportViewer>
        </div>
         
    </form>
    
</body>
</html>

<script type="text/javascript" >
    $(document).ready(function () {
       // alert($("#ReportViewer1_ctl09").length);
        $('#ReportViewer1_ctl09').css("height", "");
        $('#ReportViewer1_fixedTable').css("width", "");
        $('#ReportViewer1_ctl05').css("padding-right", "300px");
    });


</script>