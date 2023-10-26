<%@ Page Language="VB" MasterPageFile="~/HRGA/Trans/MasterTrans.master" AutoEventWireup="false" CodeFile="ReportDeklarasi2.aspx.vb" Inherits="HRGA_Trans_ReportDeklarasi2" title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:Label ID="Label1" runat="server" Text="Tanggal :"></asp:Label>
    <asp:TextBox ID="txtAwal"
        runat="server" Width="100px"></asp:TextBox>
        <A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=ctl00$ContentPlaceHolder1$txtAwal','PopupClass','width=215,height=195,left=300,top=200')"
		                            href="javascript:;"><IMG src="Images/Calendar.png" border="0" id="IMG1" runat="server" align="absMiddle" height="20" width="20"></A>
        <asp:Button ID="btnLoad" runat="server"
                Text="   OK   " /><br />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" BorderColor="Black" BorderStyle="Solid"
        BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt" Height="400px" Width="100%">
        <LocalReport ReportPath="HRGA\Trans\ReportDeklarasi2.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="Transaksi_VW_TRANSAKSI" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetData" TypeName="TransaksiTableAdapters.VW_TRANSAKSITableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtAwal" Name="AWAL" PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="txtAwal" Name="AKHIR" PropertyName="Text" Type="DateTime" />
        </SelectParameters>
    </asp:ObjectDataSource>
    &nbsp; &nbsp;
    &nbsp; &nbsp;
</asp:Content>

