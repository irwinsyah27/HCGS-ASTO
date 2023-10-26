<%@ Page Language="VB" MasterPageFile="~/HRGA/Trans/MasterTrans.master" AutoEventWireup="false" CodeFile="ReportTransferPotongan.aspx.vb" Inherits="HRGA_Trans_ReportTransferPotongan" title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Tanggal :"></asp:Label>
    <asp:TextBox ID="txtAwal"
        runat="server" Width="100px"></asp:TextBox>
        <A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=ctl00$ContentPlaceHolder1$txtAwal','PopupClass','width=215,height=195,left=300,top=200')"
		                            href="javascript:;"><IMG src="Images/Calendar.png" border="0" id="IMG1" runat="server" align="absMiddle" height="20" width="20"></A>
        <asp:Label ID="Label2" runat="server" Text="s/d Tanggal :"></asp:Label>
    <asp:TextBox
            ID="txtAkhir" runat="server" Width="100px"></asp:TextBox>
        <A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=ctl00$ContentPlaceHolder1$txtAkhir','PopupClass','width=215,height=195,left=400,top=200')"
		                            href="javascript:;"><IMG src="Images/Calendar.png" border="0" id="IMG2" runat="server" align="absMiddle" height="20" width="20"></A>    
        <asp:Button ID="btnLoad" runat="server"
                Text="   OK   " /><br />
    <rsweb:reportviewer id="ReportViewer1" runat="server" font-names="Verdana" font-size="8pt"
        height="400px" width="100%">
<LocalReport ReportPath="HRGA\Trans\ReportTransferPotongan.rdlc"><DataSources>
<rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="Transaksi_SP_POTONGAN"></rsweb:ReportDataSource>
</DataSources>
</LocalReport>
</rsweb:reportviewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData"
        TypeName="TransaksiTableAdapters.SP_POTONGANTableAdapter" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtAwal" Name="AWAL" PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="txtAkhir" Name="AKHIR" PropertyName="Text" Type="DateTime" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

