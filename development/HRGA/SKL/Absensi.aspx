<%@ Page Language="VB" Debug="TRUE"  MasterPageFile="../MasterHrga.master" AutoEventWireup="false" CodeFile="Absensi.aspx.vb" Inherits="Absensi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<asp:TextBox ID="txttgl" runat="server" AutoPostBack="True"></asp:TextBox>&nbsp;<asp:Button
        ID="Button1" runat="server" Text="Enter" />&nbsp;
    <asp:Label ID="lbldept" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="Label1" runat="server" BorderColor="Red" ForeColor="Red" Style="text-decoration: underline"
        Text='* Masukkan tanggal dengan format "MM/DD/YYYY" kemudian enter'></asp:Label>
    &nbsp;
    <br />
    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333"
        GridLines="None" Width="100%">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <Columns>
            <asp:BoundField DataField="Expr1" HeaderText="Tanggal" ReadOnly="True" SortExpression="Expr1" />
            <asp:BoundField DataField="Dept" HeaderText="Dept" SortExpression="Dept" />
            <asp:BoundField DataField="Nrp" HeaderText="Nrp" SortExpression="Nrp" />
            <asp:BoundField DataField="NAMA" HeaderText="NAMA" SortExpression="NAMA" />
            <asp:BoundField DataField="in" HeaderText="in" SortExpression="in" />
            <asp:BoundField DataField="out" HeaderText="out" SortExpression="out" />
            <asp:BoundField DataField="Harike7" HeaderText="Harike7" SortExpression="Harike7" />
            <asp:BoundField DataField="Jabatan" HeaderText="Jabatan" SortExpression="Jabatan" />
            <asp:BoundField DataField="Keterangan" HeaderText="Keterangan" SortExpression="Keterangan" />
        </Columns>
        <RowStyle BackColor="#E3EAEB" />
        <EditRowStyle BackColor="#7C6F57" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Data_abs1ConnectionString %>"
        SelectCommand="SELECT CAST(MONTH(lembarkerja.tanggal) AS VARCHAR) + '/' + CAST(DAY(lembarkerja.tanggal) AS VARCHAR) + '/' + CAST(YEAR(lembarkerja.tanggal) AS VARCHAR) AS Expr1, Karyawan.Dept, Karyawan.NAMA, Karyawan.Nrp, lembarkerja.[in], lembarkerja.out, Karyawan.Harike7, Persis.dbo.tblKaryawan.Jabatan, lembarkerja.Absent, AbsentCode.Keterangan FROM Karyawan INNER JOIN lembarkerja ON Karyawan.Nrp = lembarkerja.nrp INNER JOIN Persis.dbo.tblKaryawan ON Karyawan.Nrp = Persis.dbo.tblKaryawan.Nrp LEFT OUTER JOIN AbsentCode ON lembarkerja.Absent = AbsentCode.Code WHERE (lembarkerja.[in] IS NULL) AND (Karyawan.Dept = @dept) AND (lembarkerja.Absent NOT IN ('j', 'i') OR lembarkerja.Absent IS NULL) AND (CAST(MONTH(lembarkerja.tanggal) AS VARCHAR) + '/' + CAST(DAY(lembarkerja.tanggal) AS VARCHAR) + '/' + CAST(YEAR(lembarkerja.tanggal) AS VARCHAR) = CAST(MONTH(@tanggal) AS VARCHAR) + '/' + CAST(DAY(@tanggal) AS VARCHAR) + '/' + CAST(YEAR(@tanggal) AS VARCHAR)) AND (Karyawan.Nrp NOT IN (SELECT Nrp FROM Karyawan WHERE (Harike7 = (CASE datepart(dw , @tanggal) WHEN 1 THEN 'Minggu' WHEN 2 THEN 'Senin' WHEN 3 THEN 'Selasa' WHEN 4 THEN 'Rabu' WHEN 5 THEN 'Kamis' WHEN 6 THEN 'Jumat' WHEN 7 THEN 'Sabtu' END))))">
        <SelectParameters>
            <asp:SessionParameter Name="dept" SessionField="dept" />
            <asp:ControlParameter ControlID="txttgl" Name="tanggal" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

