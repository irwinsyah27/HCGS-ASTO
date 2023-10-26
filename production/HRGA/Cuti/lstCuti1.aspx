<%@ Page Language="VB" MasterPageFile="../MasterHrga.master" AutoEventWireup="false" CodeFile="lstCuti1.aspx.vb" Inherits="HRGA_Cuti_lstCuti1" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="width: 100%; height: 37px; text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="14pt" Text="Daftar Karyawan Cuti "
                    Width="100%"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100%">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333"
        GridLines="None" Width="100%" PageSize="15">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <Columns>
            <asp:BoundField DataField="Nrp" HeaderText="Nrp" SortExpression="Nrp" />
            <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
            <asp:BoundField DataField="Jabatan" HeaderText="Jabatan" SortExpression="Jabatan" />
            <asp:BoundField DataField="Departemen" HeaderText="Departemen" SortExpression="Departemen" />
            <asp:BoundField DataField="Awal" HeaderText="Awal" SortExpression="Awal" />
            <asp:BoundField DataField="Akhir" HeaderText="Akhir" SortExpression="Akhir" />
            <asp:BoundField DataField="Tujuan" HeaderText="Tujuan" SortExpression="Tujuan" />
            <asp:BoundField DataField="NomorST" HeaderText="Nomor" SortExpression="NomorST" />
        </Columns>
        <RowStyle BackColor="#E3EAEB" />
        <EditRowStyle BackColor="#7C6F57" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT [NomorST], [Nrp], [Nama], [Departemen], [Awal], [Akhir], [Tujuan], [Jabatan] FROM [VW_CUTI_BELUM_SELESAI]">
    </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

