<%@ Page Language="VB" Debug="TRUE"  MasterPageFile="../MasterHrga.master" AutoEventWireup="false" CodeFile="Absensi1.aspx.vb" Inherits="Absensi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<asp:TextBox ID="txttgl" runat="server" AutoPostBack="True" BackColor="White" BorderColor="White" ForeColor="White" Visible="False"></asp:TextBox>&nbsp;<asp:Button
        ID="Button1" runat="server" Text="Enter" Visible="False" />&nbsp;<asp:DropDownList
            ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
            DataTextField="Dept" DataValueField="Dept" Visible="False">
        </asp:DropDownList>
    <asp:Button ID="Button2" runat="server" Text="Tanggal" />&nbsp;
    <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>&nbsp;
    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC"
        BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
        Font-Size="8pt" ForeColor="#003399" Height="200px" Visible="False" Width="224px">
        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
        <WeekendDayStyle BackColor="#CCCCFF" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
            Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
    </asp:Calendar>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Data_abs1ConnectionString %>"
        SelectCommand="SELECT Dept, Keterangan FROM Persis.dbo.Tbl_Dept"></asp:SqlDataSource>
    <asp:Label ID="lbldept" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="Label1" runat="server" BorderColor="Red" ForeColor="Red" Style="text-decoration: underline"
        Text='* Masukkan tanggal dengan format "MM/DD/YYYY" kemudian enter'></asp:Label>
    &nbsp;
    <br />
    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" CellPadding="3" DataSourceID="SqlDataSource2"
        GridLines="None" Width="100%" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1">
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <Columns>
            <asp:BoundField DataField="Expr1" HeaderText="Tanggal" ReadOnly="True" SortExpression="Expr1" />
            <asp:BoundField DataField="Dept" HeaderText="Dept" SortExpression="Dept" />
            <asp:BoundField DataField="Nrp" HeaderText="Nrp" SortExpression="Nrp" />
            <asp:BoundField DataField="NAMA" HeaderText="NAMA" SortExpression="NAMA" />
            <asp:BoundField DataField="masuk" HeaderText="in" SortExpression="in" />
            <asp:BoundField DataField="keluar" HeaderText="out" SortExpression="out" />
            <asp:BoundField DataField="Harike7" HeaderText="Harike7" SortExpression="Harike7" />
            <asp:BoundField DataField="Jabatan" HeaderText="Jabatan" SortExpression="Jabatan" />
            <asp:BoundField DataField="Keterangan" HeaderText="Keterangan" SortExpression="Keterangan" />
        </Columns>
        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Data_abs1ConnectionString %>"
        SelectCommand="SELECT CAST(MONTH(lembarkerja.tanggal) AS VARCHAR) + '/' + CAST(DAY(lembarkerja.tanggal) AS VARCHAR) + '/' + CAST(YEAR(lembarkerja.tanggal) AS VARCHAR) AS Expr1, Karyawan.Dept, Karyawan.NAMA, Karyawan.Nrp, CASE len(CAST(datepart(hh , lembarkerja.[in]) AS varchar)) WHEN 1 THEN '0' + CAST(datepart(hh , lembarkerja.[in]) AS varchar) WHEN 2 THEN CAST(datepart(hh , lembarkerja.[in]) AS varchar) END + ':' + CASE len(CAST(datepart(mi , lembarkerja.[in]) AS varchar)) WHEN 1 THEN '0' + (CAST(datepart(mi , lembarkerja.[in]) AS varchar)) WHEN 2 THEN CAST(datepart(mi , lembarkerja.[in]) AS varchar) END AS Masuk, CASE len(CAST(datepart(hh , lembarkerja.[out]) AS varchar)) WHEN 1 THEN '0' + CAST(datepart(hh , lembarkerja.[out]) AS varchar) WHEN 2 THEN CAST(datepart(hh , lembarkerja.[out]) AS varchar) END + ':' + CASE len(CAST(datepart(mi , lembarkerja.[out]) AS varchar)) WHEN 1 THEN '0' + (CAST(datepart(mi , lembarkerja.[out]) AS varchar)) WHEN 2 THEN CAST(datepart(mi , lembarkerja.[out]) AS varchar) END AS Keluar, Karyawan.Harike7, Persis.dbo.tblKaryawan.Jabatan, lembarkerja.Absent, AbsentCode.Keterangan FROM Karyawan INNER JOIN lembarkerja ON Karyawan.Nrp = lembarkerja.nrp INNER JOIN Persis.dbo.tblKaryawan ON Karyawan.Nrp = Persis.dbo.tblKaryawan.Nrp LEFT OUTER JOIN AbsentCode ON lembarkerja.Absent = AbsentCode.Code WHERE (lembarkerja.[in] IS NULL) AND (Karyawan.Dept = @dept) AND (lembarkerja.Absent NOT IN ('J', 'I', 'E', 'C', 'D', 'G', 'H') OR lembarkerja.Absent IS NULL) AND (CAST(MONTH(lembarkerja.tanggal) AS VARCHAR) + '/' + CAST(DAY(lembarkerja.tanggal) AS VARCHAR) + '/' + CAST(YEAR(lembarkerja.tanggal) AS VARCHAR) = CAST(MONTH(@tanggal) AS VARCHAR) + '/' + CAST(DAY(@tanggal) AS VARCHAR) + '/' + CAST(YEAR(@tanggal) AS VARCHAR)) AND (Karyawan.Nrp NOT IN (SELECT Nrp FROM Karyawan AS Karyawan_1 WHERE (Harike7 = (CASE datepart(dw , @tanggal) WHEN 1 THEN 'Minggu' WHEN 2 THEN 'Senin' WHEN 3 THEN 'Selasa' WHEN 4 THEN 'Rabu' WHEN 5 THEN 'Kamis' WHEN 6 THEN 'Jumat' WHEN 7 THEN 'Sabtu' END)))) AND (Karyawan.Onsite = '1') AND (Karyawan.RosterCode <> '33')">
        <SelectParameters>
            <asp:SessionParameter Name="dept" SessionField="dept1" />
            <asp:SessionParameter Name="tanggal" SessionField="tgl" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

