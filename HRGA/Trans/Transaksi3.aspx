<%@ Page Language="VB" MasterPageFile="~/HRGA/Trans/MasterTrans.master" AutoEventWireup="false" CodeFile="Transaksi3.aspx.vb" Inherits="HRGA_Trans_Transaksi3" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Tanggal :"></asp:Label><asp:TextBox ID="txtAwal"
        runat="server"></asp:TextBox><asp:Label ID="Label2" runat="server" Text="s/d Tanggal :"></asp:Label><asp:TextBox
            ID="txtAkhir" runat="server"></asp:TextBox><asp:Button ID="btnLoad" runat="server"
                Text="   OK   " /><br />
    &nbsp;<asp:GridView ID="GridView1" runat="server" CellPadding="4" DataSourceID="SqlDataSource1"
        ForeColor="#333333" GridLines="None">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#E3EAEB" />
        <EditRowStyle BackColor="#7C6F57" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SP_TRANSAKSI3" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtAwal" Name="AWAL" PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="txtAkhir" Name="AKHIR" PropertyName="Text" Type="DateTime" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

