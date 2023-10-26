<%@ Page Language="VB" MasterPageFile="../MasterHrga.master" AutoEventWireup="false" CodeFile="mprofilea.aspx.vb" Inherits="HRGA_Report_mprofilea" title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
        Height="530px" Width="100%" ProcessingMode="Remote">
        <LocalReport>
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet2_SP_MANPOWER_PROFILE_ALL" />
            </DataSources>
        </LocalReport>
        <ServerReport ReportPath="/hrga/ManPower_Profile" />
    </rsweb:ReportViewer>
</asp:Content>

