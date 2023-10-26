<%@ Page Language="VB" MasterPageFile="~/HRGA/MasterHrga.master" AutoEventWireup="false" CodeFile="lstCutiPerNrp.aspx.vb" Inherits="HRGA_Cuti_lstCutiPerNrp" title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:reportviewer id="ReportViewer1" runat="server" font-names="Verdana" font-size="8pt"
        height="400px" processingmode="Remote" width="100%">
<ServerReport ReportPath="/hrga/Cuti_Karyawan_Nrp"></ServerReport>
</rsweb:reportviewer>
</asp:Content>

