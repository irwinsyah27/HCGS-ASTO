<%@ Page Language="VB" MasterPageFile="../MasterHrga.master" AutoEventWireup="false" CodeFile="lstCutiLS.aspx.vb" Inherits="lstCuti" title="List Surat Cuti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="width: 82%; text-align: center">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="14pt" Text="Karyawan Cuti"></asp:Label><br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Company :"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataDept"
        DataTextField="company" DataValueField="company">
    </asp:DropDownList><asp:SqlDataSource ID="SqlDataDept" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT DISTINCT [company]FROM [tblKaryawan] UNION SELECT '' AS  [company]">
    </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 82%; height: 457px;" valign="top">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT tblSutu.NomorST, vw_tblKaryawan.Nama, tblSutu.Nrp, vw_tblKaryawan.Jabatan, vw_tblKaryawan.Departemen, tblSutu.Tujuan, CASE Len(CAST(Day(tblSutu.Awal) AS Varchar)) WHEN 1 THEN '0' + CAST(Day(tblSutu.Awal) AS Varchar) WHEN 2 THEN CAST(Day(tblSutu.Awal) AS Varchar) END + CASE CAST(Month(tblSutu.Awal) AS varchar) WHEN 1 THEN ' Jan ' WHEN 2 THEN ' Feb ' WHEN 3 THEN ' Mar ' WHEN 4 THEN ' Apr ' WHEN 5 THEN ' Mei ' WHEN 6 THEN ' Jun ' WHEN 7 THEN ' Jul ' WHEN 8 THEN ' Aug ' WHEN 9 THEN ' Sep ' WHEN 10 THEN ' Okt ' WHEN 11 THEN ' Nov ' WHEN 12 THEN ' Dec ' END + CAST(YEAR(tblSutu.Awal) AS varchar) AS Awal, CASE Len(CAST(Day(tblSutu.Akhir) AS Varchar)) WHEN 1 THEN '0' + CAST(Day(tblSutu.Akhir) AS Varchar) WHEN 2 THEN CAST(Day(tblSutu.Akhir) AS Varchar) END + CASE CAST(Month(tblSutu.Akhir) AS varchar) WHEN 1 THEN ' Jan ' WHEN 2 THEN ' Feb ' WHEN 3 THEN ' Mar ' WHEN 4 THEN ' Apr ' WHEN 5 THEN ' Mei ' WHEN 6 THEN ' Jun ' WHEN 7 THEN ' Jul ' WHEN 8 THEN ' Aug ' WHEN 9 THEN ' Sep ' WHEN 10 THEN ' Okt ' WHEN 11 THEN ' Nov ' WHEN 12 THEN ' Dec ' END + CAST(YEAR(tblSutu.Akhir) AS varchar) AS Akhir, tblSutu.Keperluan, CASE WHEN PersetujuanAtasan IS NULL AND PersetujuanHr IS NULL THEN 'Atasan' WHEN PersetujuanAtasan = 1 AND PersetujuanHr IS NULL THEN 'Personnel' WHEN PersetujuanAtasan = 1 AND PersetujuanHr = 1 THEN 'Complete' WHEN PersetujuanAtasan = 0 OR PersetujuanHr = 0 THEN 'Reject' END AS Status FROM vw_tblKaryawan INNER JOIN tblSutu ON vw_tblKaryawan.Nrp = tblSutu.Nrp WHERE (tblSutu.Keperluan LIKE '%CUTI%') AND (vw_tblKaryawan.Company = @company) ORDER BY tblSutu.tglST DESC">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="DEPT" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="DropDownList1" Name="company" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
                <asp:GridView ID="viewls" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataKeyNames="NomorST" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
        Width="100%" Font-Overline="False" Font-Size="10pt" AllowSorting="True" AllowPaging="True" PageSize="15" Visible="False">
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
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl='<%# Eval("NomorST", "images/prinths.png") %>'
                                    NavigateUrl='<%# Eval("NomorST", "printForm.aspx?n={0}") %>' Target="_blank">[HyperLink1]</asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField DataNavigateUrlFields="nomorst" DataNavigateUrlFormatString="dCutils.aspx?n={0}"
                            DataTextField="Status" HeaderText="Status" SortExpression="Status" Target="_blank"
                            Text="details" />
                    </Columns>
                    <RowStyle BackColor="#E3EAEB" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT tblSutu.NomorST, vw_tblKaryawan.Nama, tblSutu.Nrp, vw_tblKaryawan.Jabatan, vw_tblKaryawan.Departemen, tblSutu.Tujuan, CASE Len(CAST(Day(tblSutu.Awal) AS Varchar)) WHEN 1 THEN '0' + CAST(Day(tblSutu.Awal) AS Varchar) WHEN 2 THEN CAST(Day(tblSutu.Awal) AS Varchar) END + CASE CAST(Month(tblSutu.Awal) AS varchar) WHEN 1 THEN ' Jan ' WHEN 2 THEN ' Feb ' WHEN 3 THEN ' Mar ' WHEN 4 THEN ' Apr ' WHEN 5 THEN ' Mei ' WHEN 6 THEN ' Jun ' WHEN 7 THEN ' Jul ' WHEN 8 THEN ' Aug ' WHEN 9 THEN ' Sep ' WHEN 10 THEN ' Okt ' WHEN 11 THEN ' Nov ' WHEN 12 THEN ' Dec ' END + CAST(YEAR(tblSutu.Awal) AS varchar) AS Awal, CASE Len(CAST(Day(tblSutu.Akhir) AS Varchar)) WHEN 1 THEN '0' + CAST(Day(tblSutu.Akhir) AS Varchar) WHEN 2 THEN CAST(Day(tblSutu.Akhir) AS Varchar) END + CASE CAST(Month(tblSutu.Akhir) AS varchar) WHEN 1 THEN ' Jan ' WHEN 2 THEN ' Feb ' WHEN 3 THEN ' Mar ' WHEN 4 THEN ' Apr ' WHEN 5 THEN ' Mei ' WHEN 6 THEN ' Jun ' WHEN 7 THEN ' Jul ' WHEN 8 THEN ' Aug ' WHEN 9 THEN ' Sep ' WHEN 10 THEN ' Okt ' WHEN 11 THEN ' Nov ' WHEN 12 THEN ' Dec ' END + CAST(YEAR(tblSutu.Akhir) AS varchar) AS Akhir, tblSutu.Keperluan, CASE WHEN PersetujuanAtasan IS NULL AND PersetujuanHr IS NULL THEN 'Atasan' WHEN PersetujuanAtasan = 1 AND PersetujuanHr IS NULL THEN 'Personnel' WHEN PersetujuanAtasan = 1 AND PersetujuanHr = 1 THEN 'Complete' WHEN PersetujuanAtasan = 0 OR PersetujuanHr = 0 THEN 'Reject' END AS Status FROM vw_tblKaryawan INNER JOIN tblSutu ON vw_tblKaryawan.Nrp = tblSutu.Nrp WHERE (tblSutu.Keperluan LIKE '%CUTI%') AND (vw_tblKaryawan.Departemen = @dept) AND (vw_tblKaryawan.Company <> 'PAMA') ORDER BY tblSutu.tglST DESC">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" Name="DEPT" PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="DropDownList1" Name="company" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:GridView ID="viewdept" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataKeyNames="NomorST" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None"
        Width="100%" Font-Overline="False" Font-Size="10pt" AllowSorting="True" AllowPaging="True" PageSize="15" Visible="False">
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
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl='<%# Eval("NomorST", "images/prinths.png") %>'
                                    NavigateUrl='<%# Eval("NomorST", "printForm.aspx?n={0}") %>' Target="_blank">[HyperLink1]</asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField DataNavigateUrlFields="nomorst" DataNavigateUrlFormatString="dCutils.aspx?n={0}"
                            DataTextField="Status" HeaderText="Status" SortExpression="Status" Target="_blank"
                            Text="details" />
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

