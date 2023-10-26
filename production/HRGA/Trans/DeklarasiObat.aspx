<%@ Page Language="VB" MasterPageFile="~/HRGA/Trans/MasterTrans.master" AutoEventWireup="false" CodeFile="DeklarasiObat.aspx.vb" Inherits="HRGA_Trans_DeklarasiObat" title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:reportviewer id="ReportViewer1" runat="server" font-names="Verdana" font-size="8pt"
        height="500px" processingmode="Remote" width="100%">
<ServerReport ReportPath="/HRGA/Deklarasi_Uang_Pengobatan"></ServerReport>
</rsweb:reportviewer>
</asp:Content>

