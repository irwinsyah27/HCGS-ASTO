<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="lstTugas.aspx.vb" Inherits="lstTugas" title="List Surat Dinas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataKeyNames="NomorST" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
        Width="100%" Font-Overline="False" Font-Size="10pt">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <Columns>
            <asp:BoundField DataField="NomorST" HeaderText="NomorST" ReadOnly="True" SortExpression="NomorST" />
            <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
            <asp:BoundField DataField="Nrp" HeaderText="Nrp" SortExpression="Nrp" />
            <asp:BoundField DataField="Jabatan" HeaderText="Jabatan" SortExpression="Jabatan" />
            <asp:BoundField DataField="Departemen" HeaderText="Departemen" SortExpression="Departemen" />
            <asp:BoundField DataField="Tujuan" HeaderText="Tujuan" SortExpression="Tujuan" />
            <asp:BoundField DataField="Awal" HeaderText="Awal" SortExpression="Awal" />
            <asp:BoundField DataField="Akhir" HeaderText="Akhir" SortExpression="Akhir" />
            <asp:BoundField DataField="Keperluan" HeaderText="Keperluan" SortExpression="Keperluan" />
            <asp:HyperLinkField DataNavigateUrlFields="NomorST" DataNavigateUrlFormatString="dTugas.aspx?n={0}"
                Text="Details" Target="_blank" />
        </Columns>
        <RowStyle BackColor="#E3EAEB" />
        <EditRowStyle BackColor="#7C6F57" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT tblSutu.NomorST, tblKaryawan.Nama, tblSutu.Nrp, tblKaryawan.Jabatan, tblKaryawan.Departemen, tblSutu.Tujuan, tblSutu.Awal, tblSutu.Akhir, tblSutu.Keperluan FROM tblKaryawan INNER JOIN tblSutu ON tblKaryawan.Nrp = tblSutu.Nrp Where Keperluan Like '%TUGAS%'">
    </asp:SqlDataSource>
</asp:Content>

