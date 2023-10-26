<%@ Page Language="VB" MasterPageFile="../MasterHrga.master" AutoEventWireup="false" CodeFile="lstCuti.aspx.vb" Inherits="lstCuti" title="List Surat Cuti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="width: 100%; text-align: center">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="14pt" Text="Karyawan Cuti"></asp:Label><br />

    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Company :" Visible="True"></asp:Label>&nbsp;<asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" DataSourceID="SqlDatacompany"
    DataTextField="Company" DataValueField="Company" Visible="False">
</asp:DropDownList>
                
    </asp:DropDownList><asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Departemen : "></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataDept"
        DataTextField="Departemen" DataValueField="Departemen">
    </asp:DropDownList>
    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Status : "></asp:Label>
    <asp:DropDownList ID="DDLStatus" runat="server" AutoPostBack="True" DataSourceID="SqlStatus"
        DataTextField="Status" DataValueField="Status">
    </asp:DropDownList>
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="NRP : "></asp:Label>&nbsp;
                <asp:TextBox ID="txNRP" runat="server"></asp:TextBox>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] ">
    </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDatacompany" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT * FROM(&#13;&#10;SELECT DISTINCT Company FROM tblKaryawan where Company <>'' UNION ALL SELECT '' AS Company&#13;&#10;UNION ALL SELECT 'ALL' AS Company) AS Tbl&#13;&#10;ORDER BY Company">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataDept" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] UNION SELECT 'ALL DEPT' AS [Departemen]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlStatus" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT DISTINCT [Status] FROM [tblSutu] where NomorST like '%SC' UNION SELECT 'ALL' AS [Status]">
    </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 100%" valign="top">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT tblSutu.NomorST
	, vw_tblKaryawan.Nama
	, tblSutu.Nrp
	, vw_tblKaryawan.Jabatan
	, vw_tblKaryawan.Departemen
	, tblSutu.Tujuan
	, Awal = Case Len(Cast(Day(tblSutu.Awal) As Varchar)) When 1 Then '0'+ Cast(Day(tblSutu.Awal) As Varchar)When 2 Then Cast(Day(tblSutu.Awal) As Varchar) End
     		+ Case Cast(Month(tblSutu.Awal) as varchar)  When 1 Then ' Jan ' 
						When 2 Then ' Feb ' 
						When 3 Then ' Mar ' 
						When 4 Then ' Apr '
						When 5 Then ' Mei '
						When 6 Then ' Jun '
						When 7 Then ' Jul '
						When 8 Then ' Aug '
						When 9 Then ' Sep '
						When 10 Then ' Okt '
						When 11 Then ' Nov '
						When 12 Then ' Dec '
						End + Cast(Year(tblSutu.Awal)as varchar)
	, Akhir = Case Len(Cast(Day(tblSutu.Akhir) As Varchar)) When 1 Then '0'+ Cast(Day(tblSutu.Akhir) As Varchar)When 2 Then Cast(Day(tblSutu.Akhir) As Varchar) End
     		+ Case Cast(Month(tblSutu.Akhir) as varchar)  When 1 Then ' Jan ' 
						When 2 Then ' Feb ' 
						When 3 Then ' Mar ' 
						When 4 Then ' Apr '
						When 5 Then ' Mei '
						When 6 Then ' Jun '
						When 7 Then ' Jul '
						When 8 Then ' Aug '
						When 9 Then ' Sep '
						When 10 Then ' Okt '
						When 11 Then ' Nov '
						When 12 Then ' Dec '
						End + Cast(Year(tblSutu.Akhir)as varchar)
	, tblSutu.Keperluan
	,  TblSutu.Status 
FROM vw_tblKaryawan INNER JOIN tblSutu ON vw_tblKaryawan.Nrp = tblSutu.Nrp 
WHERE (tblSutu.Keperluan LIKE '%CUTI%') AND (vw_tblKaryawan.Departemen = @DEPT OR @DEPT='ALL DEPT') AND (TblSutu.Status=@Status or @Status='ALL')  AND (vw_tblKaryawan.Company=@Company or @Company='ALL') AND
(tblSutu.Nrp=@NRP or @NRP='ALL')
AND (Lokasi=@Site OR @Jabatan LIKE '%PERSONNEL SITE%' OR @Jabatan LIKE '%DEPT. HEAD%'
 OR @Jabatan LIKE '%SECT. HEAD%'
 OR @Jabatan LIKE '%PROJECT MANAGER%' OR @Jabatan LIKE '%ICT SITE%' OR @Jabatan LIKE '%PAYROLL%' OR @CAdmin = 1)
 ORDER BY tblSutu.tglST DESC
">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="DEPT" PropertyName="SelectedValue" DefaultValue="" />
            <asp:ControlParameter ControlID="DDLStatus" Name="Status" PropertyName="SelectedValue" DefaultValue="ALL" />
            <asp:ControlParameter ControlID="DropDownList3" Name="Company" PropertyName="SelectedValue" DefaultValue="" />
            <asp:ControlParameter ControlID="txNRP" DefaultValue="ALL" Name="NRP" PropertyName="Text" />
            <asp:SessionParameter Name="Site" SessionField="Site" />
            <asp:SessionParameter Name="Jabatan" SessionField="Jabatan" />
            <asp:SessionParameter Name="CNRP" SessionField="userid" />
            <asp:SessionParameter DefaultValue="" Name="CAdmin" SessionField="Admin" />
        </SelectParameters>
    </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                    SelectCommand="SELECT tblSutu.NomorST, vw_tblKaryawan.Nama, tblSutu.Nrp, vw_tblKaryawan.Jabatan, vw_tblKaryawan.Departemen, tblSutu.Tujuan, CASE Len(CAST(Day(tblSutu.Awal) AS Varchar)) WHEN 1 THEN '0' + CAST(Day(tblSutu.Awal) AS Varchar) WHEN 2 THEN CAST(Day(tblSutu.Awal) AS Varchar) END + CASE CAST(Month(tblSutu.Awal) AS varchar) WHEN 1 THEN ' Jan ' WHEN 2 THEN ' Feb ' WHEN 3 THEN ' Mar ' WHEN 4 THEN ' Apr ' WHEN 5 THEN ' Mei ' WHEN 6 THEN ' Jun ' WHEN 7 THEN ' Jul ' WHEN 8 THEN ' Aug ' WHEN 9 THEN ' Sep ' WHEN 10 THEN ' Okt ' WHEN 11 THEN ' Nov ' WHEN 12 THEN ' Dec ' END + CAST(YEAR(tblSutu.Awal) AS varchar) AS Awal, CASE Len(CAST(Day(tblSutu.Akhir) AS Varchar)) WHEN 1 THEN '0' + CAST(Day(tblSutu.Akhir) AS Varchar) WHEN 2 THEN CAST(Day(tblSutu.Akhir) AS Varchar) END + CASE CAST(Month(tblSutu.Akhir) AS varchar) WHEN 1 THEN ' Jan ' WHEN 2 THEN ' Feb ' WHEN 3 THEN ' Mar ' WHEN 4 THEN ' Apr ' WHEN 5 THEN ' Mei ' WHEN 6 THEN ' Jun ' WHEN 7 THEN ' Jul ' WHEN 8 THEN ' Aug ' WHEN 9 THEN ' Sep ' WHEN 10 THEN ' Okt ' WHEN 11 THEN ' Nov ' WHEN 12 THEN ' Dec ' END + CAST(YEAR(tblSutu.Akhir) AS varchar) AS Akhir, tblSutu.Keperluan, CASE WHEN PersetujuanAtasan IS NULL AND PersetujuanHr IS NULL THEN 'Atasan' WHEN PersetujuanAtasan = 1 AND PersetujuanHr IS NULL THEN 'Personnel' WHEN PersetujuanAtasan = 1 AND PersetujuanHr = 1 THEN 'Complete' WHEN PersetujuanAtasan = 0 OR PersetujuanHr = 0 THEN 'Reject' END AS Status FROM vw_tblKaryawan INNER JOIN tblSutu ON vw_tblKaryawan.Nrp = tblSutu.Nrp WHERE (tblSutu.Keperluan LIKE '%CUTI%')  ORDER BY tblSutu.tglST DESC">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" Name="DEPT" PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="DDLStatus" Name="Status" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:GridView ID="viewkorlap" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="NomorST" DataSourceID="SqlDataSource4"
                    Font-Overline="False" Font-Size="10pt" ForeColor="#333333" GridLines="None" PageSize="15"
                    Visible="False" Width="100%">
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="NomorST" HeaderText="Nomor" ReadOnly="True" SortExpression="NomorST" />
                        <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
                        <asp:BoundField DataField="Nrp" HeaderText="Nrp" SortExpression="Nrp" />
                        <asp:BoundField DataField="Jabatan" HeaderText="Jabatan" SortExpression="Jabatan" />
                        <asp:BoundField DataField="Departemen" HeaderText="Departemen" SortExpression="Departemen" />
                        <asp:BoundField DataField="Tujuan" HeaderText="Tujuan" SortExpression="Tujuan" />
                        <asp:BoundField DataField="Awal" HeaderText="Awal" SortExpression="Awal">
                            <ItemStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Akhir" HeaderText="Akhir" SortExpression="Akhir">
                            <ItemStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Keperluan" HeaderText="Keperluan" SortExpression="Keperluan" />
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl='<%# Eval("NomorST", "images/prinths.png") %>'
                                    NavigateUrl='<%# Eval("NomorST", "printForm.aspx?n={0}") %>' Target="_blank">[HyperLink1]</asp:HyperLink>
                            </ItemTemplate>
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl='<%# Eval("NomorST", "images/printd.png") %>'
                                    NavigateUrl='<%# Eval("NomorST", "printFormD.aspx?n={0}") %>' Target="_blank">[HyperLink2]</asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField DataNavigateUrlFields="nomorst" DataNavigateUrlFormatString="dCutils.aspx?n={0}"
                            DataTextField="Status" HeaderText="Status" SortExpression="Status" Target="_blank"
                            Text="details" >
                            <ItemStyle Width="30px" />
                        </asp:HyperLinkField>
                    </Columns>
                    <RowStyle BackColor="#E3EAEB" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
    <asp:GridView ID="viewpama" runat="server" AutoGenerateColumns="False" CellPadding="4"
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
            <asp:BoundField DataField="Keperluan" HeaderText="Keperluan" SortExpression="Keperluan" Visible="False" />
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
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                    SelectCommand="SELECT tblSutu.NomorST, vw_tblKaryawan.Nama, tblSutu.Nrp, vw_tblKaryawan.Jabatan, vw_tblKaryawan.Departemen, tblSutu.Tujuan, CASE Len(CAST(Day(tblSutu.Awal) AS Varchar)) WHEN 1 THEN '0' + CAST(Day(tblSutu.Awal) AS Varchar) WHEN 2 THEN CAST(Day(tblSutu.Awal) AS Varchar) END + CASE CAST(Month(tblSutu.Awal) AS varchar) WHEN 1 THEN ' Jan ' WHEN 2 THEN ' Feb ' WHEN 3 THEN ' Mar ' WHEN 4 THEN ' Apr ' WHEN 5 THEN ' Mei ' WHEN 6 THEN ' Jun ' WHEN 7 THEN ' Jul ' WHEN 8 THEN ' Aug ' WHEN 9 THEN ' Sep ' WHEN 10 THEN ' Okt ' WHEN 11 THEN ' Nov ' WHEN 12 THEN ' Dec ' END + CAST(YEAR(tblSutu.Awal) AS varchar) AS Awal, CASE Len(CAST(Day(tblSutu.Akhir) AS Varchar)) WHEN 1 THEN '0' + CAST(Day(tblSutu.Akhir) AS Varchar) WHEN 2 THEN CAST(Day(tblSutu.Akhir) AS Varchar) END + CASE CAST(Month(tblSutu.Akhir) AS varchar) WHEN 1 THEN ' Jan ' WHEN 2 THEN ' Feb ' WHEN 3 THEN ' Mar ' WHEN 4 THEN ' Apr ' WHEN 5 THEN ' Mei ' WHEN 6 THEN ' Jun ' WHEN 7 THEN ' Jul ' WHEN 8 THEN ' Aug ' WHEN 9 THEN ' Sep ' WHEN 10 THEN ' Okt ' WHEN 11 THEN ' Nov ' WHEN 12 THEN ' Dec ' END + CAST(YEAR(tblSutu.Akhir) AS varchar) AS Akhir, tblSutu.Keperluan, CASE WHEN PersetujuanAtasan IS NULL AND PersetujuanHr IS NULL THEN 'Atasan' WHEN PersetujuanAtasan = 1 AND PersetujuanHr IS NULL THEN 'Personnel' WHEN PersetujuanAtasan = 1 AND PersetujuanHr = 1 THEN 'Complete' WHEN PersetujuanAtasan = 0 OR PersetujuanHr = 0 THEN 'Reject' END AS Status FROM vw_tblKaryawan INNER JOIN tblSutu ON vw_tblKaryawan.Nrp = tblSutu.Nrp WHERE (tblSutu.Keperluan LIKE '%CUTI%') AND (vw_tblKaryawan.Departemen = @dept) AND (vw_tblKaryawan.Company =@company) ORDER BY tblSutu.tglST DESC">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" Name="DEPT" PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="DropDownList3" Name="company" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:GridView ID="viewls" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                    CellPadding="4" DataKeyNames="NomorST" DataSourceID="SqlDataSource2" Font-Overline="False"
                    Font-Size="10pt" ForeColor="#333333" GridLines="None" PageSize="15" Visible="False"
                    Width="100%">
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="NomorST" HeaderText="Nomor" ReadOnly="True" SortExpression="NomorST" />
                        <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
                        <asp:BoundField DataField="Nrp" HeaderText="Nrp" SortExpression="Nrp" />
                        <asp:BoundField DataField="Jabatan" HeaderText="Jabatan" SortExpression="Jabatan" />
                        <asp:BoundField DataField="Departemen" HeaderText="Departemen" SortExpression="Departemen" />
                        <asp:BoundField DataField="Tujuan" HeaderText="Tujuan" SortExpression="Tujuan" />
                        <asp:BoundField DataField="Awal" HeaderText="Awal" SortExpression="Awal">
                            <ItemStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Akhir" HeaderText="Akhir" SortExpression="Akhir">
                            <ItemStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Keperluan" HeaderText="Keperluan" SortExpression="Keperluan" Visible="False" />
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

