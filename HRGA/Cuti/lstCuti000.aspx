<%@ Page Language="VB" MasterPageFile="../MasterHrga.master" AutoEventWireup="false" CodeFile="lstCuti.aspx.vb" Inherits="lstCuti" title="List Surat Cuti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="width: 100%; text-align: center">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="14pt" Text="Karyawan Cuti"></asp:Label><br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Departemen : "></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataDept"
        DataTextField="Departemen" DataValueField="Departemen">
    </asp:DropDownList><asp:SqlDataSource ID="SqlDataDept" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] ">
    </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT tblSutu.NomorST&#13;&#10;&#9;, vw_tblKaryawan.Nama&#13;&#10;&#9;, tblSutu.Nrp&#13;&#10;&#9;, vw_tblKaryawan.Jabatan&#13;&#10;&#9;, vw_tblKaryawan.Departemen&#13;&#10;&#9;, tblSutu.Tujuan&#13;&#10;&#9;, Awal = Case Len(Cast(Day(tblSutu.Awal) As Varchar)) When 1 Then '0'+ Cast(Day(tblSutu.Awal) As Varchar)When 2 Then Cast(Day(tblSutu.Awal) As Varchar) End&#13;&#10;     &#9;&#9;+ Case Cast(Month(tblSutu.Awal) as varchar)  When 1 Then ' Jan ' &#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 2 Then ' Feb ' &#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 3 Then ' Mar ' &#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 4 Then ' Apr '&#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 5 Then ' Mei '&#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 6 Then ' Jun '&#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 7 Then ' Jul '&#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 8 Then ' Aug '&#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 9 Then ' Sep '&#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 10 Then ' Okt '&#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 11 Then ' Nov '&#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 12 Then ' Dec '&#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;End + Cast(Year(tblSutu.Awal)as varchar)&#13;&#10;&#9;, Akhir = Case Len(Cast(Day(tblSutu.Akhir) As Varchar)) When 1 Then '0'+ Cast(Day(tblSutu.Akhir) As Varchar)When 2 Then Cast(Day(tblSutu.Akhir) As Varchar) End&#13;&#10;     &#9;&#9;+ Case Cast(Month(tblSutu.Akhir) as varchar)  When 1 Then ' Jan ' &#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 2 Then ' Feb ' &#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 3 Then ' Mar ' &#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 4 Then ' Apr '&#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 5 Then ' Mei '&#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 6 Then ' Jun '&#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 7 Then ' Jul '&#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 8 Then ' Aug '&#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 9 Then ' Sep '&#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 10 Then ' Okt '&#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 11 Then ' Nov '&#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;When 12 Then ' Dec '&#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;End + Cast(Year(tblSutu.Akhir)as varchar)&#13;&#10;&#9;, tblSutu.Keperluan&#13;&#10;&#9;, CASE WHEN PersetujuanAtasan IS NULL AND PersetujuanHr IS NULL AND PersetujuanHrga IS NULL &#13;&#10;&#9;&#9;AND PersetujuanPm IS NULL THEN 'Atasan' &#13;&#10;&#9;&#9;WHEN PersetujuanAtasan = 1 AND PersetujuanHr IS NULL AND PersetujuanHrga IS NULL &#13;&#10;&#9;&#9;AND PersetujuanPm IS NULL THEN 'Personnel' &#13;&#10;&#9;&#9;WHEN PersetujuanAtasan = 1 AND PersetujuanHr = 1 AND PersetujuanHrga IS NULL &#13;&#10;&#9;&#9;AND PersetujuanPm IS NULL AND LEFT(vw_tblKaryawan.Golongan,1) < 4 THEN 'Hrga Section' &#13;&#10;&#9;&#9;WHEN PersetujuanAtasan = 1 AND PersetujuanHr = 1 AND PersetujuanHrga IS NULL &#13;&#10;&#9;&#9;AND PersetujuanPm IS NULL AND LEFT(vw_tblKaryawan.Golongan,1) >= 4 THEN 'Hrga Head' &#13;&#10;&#9;&#9;WHEN PersetujuanAtasan = 1 AND PersetujuanHr = 1 AND PersetujuanHrga = 1 &#13;&#10;&#9;&#9;AND PersetujuanPm IS NULL AND LEFT(vw_tblKaryawan.Golongan,1) < 4 THEN 'Hrga Head' &#13;&#10;&#9;&#9;WHEN PersetujuanAtasan = 1 AND PersetujuanHr = 1 AND PersetujuanHrga = 1 &#13;&#10;&#9;&#9;AND PersetujuanPm IS NULL AND LEFT(vw_tblKaryawan.Golongan,1) >= 4 THEN 'PM' &#13;&#10;&#9;&#9;WHEN PersetujuanAtasan = 1 AND PersetujuanHr = 1 AND PersetujuanHrga = 1 &#13;&#10;&#9;&#9;AND PersetujuanPm = 1 THEN 'Complete' &#13;&#10;&#9;&#9;WHEN PersetujuanAtasan = 0 OR PersetujuanHr = 0 OR PersetujuanHrga = 0 OR PersetujuanPm = 0 THEN 'Reject' END AS Status &#13;&#10;FROM vw_tblKaryawan INNER JOIN tblSutu ON vw_tblKaryawan.Nrp = tblSutu.Nrp &#13;&#10;WHERE (tblSutu.Keperluan LIKE '%CUTI%') AND (vw_tblKaryawan.Departemen = @DEPT) AND COMPANY = 'PAMA' ORDER BY tblSutu.tglST DESC&#13;&#10;">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="DEPT" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataKeyNames="NomorST" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
        Width="100%" Font-Overline="False" Font-Size="10pt" AllowSorting="True" AllowPaging="True" PageSize="15">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <Columns>
            <asp:BoundField DataField="NomorST" HeaderText="Nomor" ReadOnly="True" SortExpression="NomorST" />
            <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
            <asp:BoundField DataField="Nrp" HeaderText="Nrp" SortExpression="Nrp" />
            <asp:BoundField DataField="Jabatan" HeaderText="Jabatan" SortExpression="Jabatan" />
            <asp:BoundField DataField="Departemen" HeaderText="Departemen" SortExpression="Departemen" />
            <asp:BoundField DataField="Tujuan" HeaderText="Tujuan" SortExpression="Tujuan" />
            <asp:BoundField DataField="Awal" HeaderText="Awal" SortExpression="Awal" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="Akhir" HeaderText="Akhir" SortExpression="Akhir" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="Keperluan" HeaderText="Keperluan" SortExpression="Keperluan" />
            <asp:HyperLinkField DataNavigateUrlFields="NomorST" DataNavigateUrlFormatString="dCuti.aspx?n={0}"
                Text="Details" Target="_blank" DataTextField="Status" HeaderText="Status" SortExpression="Status" >
                <ItemStyle Width="80px" />
            </asp:HyperLinkField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl='<%# Eval("NomorST", "images/prinths.png") %>'
                        NavigateUrl='<%# Eval("NomorST", "printForm.aspx?n={0}") %>' Target="_blank">[HyperLink1]</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle BackColor="#E3EAEB" />
        <EditRowStyle BackColor="#7C6F57" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

