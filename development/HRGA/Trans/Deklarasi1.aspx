<%@ Page Language="VB" MasterPageFile="~/HRGA/Trans/MasterTrans.master" AutoEventWireup="false" CodeFile="Deklarasi1.aspx.vb" Inherits="HRGA_Trans_Deklarasi1" title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:reportviewer id="ReportViewer1" runat="server" font-names="Verdana" font-size="8pt"
        height="400px" processingmode="Remote" width="840px" BorderStyle="Solid" BorderWidth="1px">
<ServerReport ReportPath="/hrga/Deklarasi_Perjalanan_Dinas"></ServerReport>
</rsweb:reportviewer>
</asp:Content>

