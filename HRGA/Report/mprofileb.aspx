<%@ Page Language="VB" Debug="true"  MasterPageFile="~/HRGA/MasterHrga.master" AutoEventWireup="false" CodeFile="mprofileb.aspx.vb" Inherits="HRGA_Report_mprofileb" title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Departemen : "></asp:Label><asp:DropDownList
        ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataDept"
        DataTextField="Departemen" DataValueField="Departemen">
    </asp:DropDownList><asp:SqlDataSource ID="SqlDataDept" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] ">
    </asp:SqlDataSource>
    <br />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
        Height="400px" Visible="False" Width="100%">
        <LocalReport ReportPath="HRGA\Report\ManPowerProfile_Dept.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet2_SP_MANPOWER_PROFILE_DEPT" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetData" TypeName="DataSet2TableAdapters.SP_MANPOWER_PROFILE_DEPTTableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="DEPT" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

