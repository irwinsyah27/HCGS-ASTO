<%@ Page Language="VB" MasterPageFile="~/HRGA/MasterHrga.master" AutoEventWireup="false" CodeFile="DinasSudahSelesai.aspx.vb" Inherits="HRGA_Cuti_DinasSudahSelesai" title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" BorderColor="Black" BorderStyle="Solid"
        BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt" Height="900px" ProcessingMode="Remote"
        Width="100%">
        <ServerReport ReportPath="/hrga/Surat Dinas Sudah Berakhir" />
    </rsweb:ReportViewer>
</asp:Content>

