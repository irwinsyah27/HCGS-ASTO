<%@ Page Language="VB" MasterPageFile="~/HRGA/MasterHrga.master" AutoEventWireup="false" CodeFile="ReportCuti1.aspx.vb" Inherits="HRGA_Report_ReportCuti1" title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
        Height="400px" ProcessingMode="Remote" Width="100%">
        <ServerReport ReportPath="/Hrga/CutiBelumSelesai" ReportServerUrl="http://10.2.167.124/reportserver" />
    </rsweb:ReportViewer>
</asp:Content>

