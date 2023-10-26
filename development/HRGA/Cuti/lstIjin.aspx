<%@ Page Language="VB" MasterPageFile="../MasterHrga.master" AutoEventWireup="false" CodeFile="lstIjin.aspx.vb" Inherits="lstIjin" title="List Surat Ijin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="width: 100%; text-align: center">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="14pt" Text="Karyawan Ijin"></asp:Label><br />
    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Company :"></asp:Label>&nbsp;<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" DataSourceID="SqlDatacompany"
        DataTextField="company" DataValueField="company">
    </asp:DropDownList>&nbsp;
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Departemen : "></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataDept"
        DataTextField="Departemen" DataValueField="Departemen">
    </asp:DropDownList>
    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Status : "></asp:Label>
    <asp:DropDownList ID="DDLStatus" runat="server" AutoPostBack="True" DataSourceID="SqlStatus"
        DataTextField="Status" DataValueField="Status">
    </asp:DropDownList>&nbsp;
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Company :" Visible="False"></asp:Label>
    <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3"
        DataTextField="departemen" DataValueField="departemen" Visible="False">
    </asp:DropDownList>
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="NRP : "></asp:Label>
                <asp:TextBox ID="txNRP" runat="server"></asp:TextBox><asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] ">
    </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDatacompany" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                    SelectCommand="SELECT * FROM(&#13;&#10;SELECT DISTINCT Company FROM tblKaryawan where Company <>'' UNION ALL SELECT '' AS Company&#13;&#10;UNION ALL SELECT 'ALL' AS Company) AS Tbl&#13;&#10;ORDER BY Company"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataDept" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT ' ' AS  [Departemen] UNION SELECT 'ALL DEPT' AS [Departemen]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlStatus" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT DISTINCT [Status] FROM [tblIjin] UNION SELECT 'ALL' AS [Status]">
    </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 100%" valign="top">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT tblIjin.NoIjin, vw_tblKaryawan.Nama, tblIjin.Nrp, vw_tblKaryawan.Jabatan, vw_tblKaryawan.Departemen, Awal = Case Len(Cast(Day(tblIjin.Awal) As Varchar)) When 1 Then '0'+ Cast(Day(tblIjin.Awal) As Varchar)When 2 Then Cast(Day(tblIjin.Awal) As Varchar) End + Case Cast(Month(tblIjin.Awal) as varchar)  When 1 Then ' Jan ' When 2 Then ' Feb ' When 3 Then ' Mar ' When 4 Then ' Apr 'When 5 Then ' Mei 'When 6 Then ' Jun 'When 7 Then ' Jul 'When 8 Then ' Aug 'When 9 Then ' Sep 'When 10 Then ' Okt 'When 11 Then ' Nov 'When 12 Then ' Dec 'End + Cast(Year(tblIjin.Awal)as varchar), Akhir = Case Len(Cast(Day(tblIjin.Akhir) As Varchar)) When 1 Then '0'+ Cast(Day(tblIjin.Akhir) As Varchar)When 2 Then Cast(Day(tblIjin.Akhir) As Varchar) End + Case Cast(Month(tblIjin.Akhir) as varchar)  When 1 Then ' Jan ' When 2 Then ' Feb ' When 3 Then ' Mar ' When 4 Then ' Apr 'When 5 Then ' Mei 'When 6 Then ' Jun 'When 7 Then ' Jul 'When 8 Then ' Aug 'When 9 Then ' Sep 'When 10 Then ' Okt 'When 11 Then ' Nov 'When 12 Then ' Dec ' End + Cast(Year(tblIjin.Akhir)as varchar), tblIjin.Keperluan, tblIjin.Status FROM vw_tblKaryawan INNER JOIN tblIjin ON vw_tblKaryawan.Nrp = tblIjin.Nrp WHERE (vw_tblKaryawan.Departemen = @DEPT OR @DEPT = 'ALL DEPT') AND (tblIjin.Status=@Status or @Status='ALL')   AND (Company=@Company or @Company='ALL') AND
( tblIjin.Nrp=@NRP or @NRP='ALL') 
AND (Lokasi=@Site OR @Jabatan LIKE '%PERSONNEL SITE%' OR @Jabatan LIKE '%DEPT. HEAD%'
 OR @Jabatan LIKE '%SECT. HEAD%'
 OR @Jabatan LIKE '%PROJECT MANAGER%' OR @Jabatan LIKE '%ICT SITE%' OR @Jabatan LIKE '%PAYROLL%' OR @CAdmin = 1)
ORDER BY tblIjin.Tanggal DESC">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="DEPT" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="DDLStatus" Name="Status" PropertyName="SelectedValue" DefaultValue="ALL" />
            <asp:ControlParameter ControlID="DropDownList2" Name="Company" PropertyName="SelectedValue" DefaultValue="" />
            <asp:ControlParameter ControlID="txNRP" DefaultValue="ALL" Name="NRP" PropertyName="Text" />
            <asp:SessionParameter Name="Site" SessionField="Site" />
            <asp:SessionParameter Name="Jabatan" SessionField="Jabatan" />
            <asp:SessionParameter Name="CNRP" SessionField="userid" />
            <asp:SessionParameter Name="CAdmin" SessionField="Admin" />
        </SelectParameters>
    </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                    SelectCommand="SELECT tblIjin.NoIjin, vw_tblKaryawan.Nama, tblIjin.Nrp, vw_tblKaryawan.Jabatan, vw_tblKaryawan.Departemen, CASE Len(CAST(Day(tblIjin.Awal) AS Varchar)) WHEN 1 THEN '0' + CAST(Day(tblIjin.Awal) AS Varchar) WHEN 2 THEN CAST(Day(tblIjin.Awal) AS Varchar) END + CASE CAST(Month(tblIjin.Awal) AS varchar) WHEN 1 THEN ' Jan ' WHEN 2 THEN ' Feb ' WHEN 3 THEN ' Mar ' WHEN 4 THEN ' Apr ' WHEN 5 THEN ' Mei ' WHEN 6 THEN ' Jun ' WHEN 7 THEN ' Jul ' WHEN 8 THEN ' Aug ' WHEN 9 THEN ' Sep ' WHEN 10 THEN ' Okt ' WHEN 11 THEN ' Nov ' WHEN 12 THEN ' Dec ' END + CAST(YEAR(tblIjin.Awal) AS varchar) AS Awal, CASE Len(CAST(Day(tblIjin.Akhir) AS Varchar)) WHEN 1 THEN '0' + CAST(Day(tblIjin.Akhir) AS Varchar) WHEN 2 THEN CAST(Day(tblIjin.Akhir) AS Varchar) END + CASE CAST(Month(tblIjin.Akhir) AS varchar) WHEN 1 THEN ' Jan ' WHEN 2 THEN ' Feb ' WHEN 3 THEN ' Mar ' WHEN 4 THEN ' Apr ' WHEN 5 THEN ' Mei ' WHEN 6 THEN ' Jun ' WHEN 7 THEN ' Jul ' WHEN 8 THEN ' Aug ' WHEN 9 THEN ' Sep ' WHEN 10 THEN ' Okt ' WHEN 11 THEN ' Nov ' WHEN 12 THEN ' Dec ' END + CAST(YEAR(tblIjin.Akhir) AS varchar) AS Akhir, tblIjin.Keperluan, CASE WHEN Persetujuan IS NULL AND ValidasiHR IS NULL THEN 'Atasan' WHEN Persetujuan = 1 AND ValidasiHR IS NULL THEN 'Personnel' WHEN Persetujuan = 1 AND ValidasiHR = 1 THEN 'Complete' WHEN Persetujuan = 1 AND ValidasiHR = 0 THEN 'Reject' WHEN Persetujuan = 0 AND validasiHR is null THEN 'Reject' END AS Status FROM vw_tblKaryawan INNER JOIN tblIjin ON vw_tblKaryawan.Nrp = tblIjin.Nrp  ORDER BY tblIjin.Tanggal DESC">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" Name="DEPT" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                &nbsp;
    <asp:GridView ID="viewpama" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataKeyNames="NoIjin" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
        Width="100%" Font-Overline="False" Font-Size="10pt" AllowSorting="True" AllowPaging="True" PageSize="15">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <Columns>
            <asp:BoundField DataField="NoIjin" HeaderText="Nomor" ReadOnly="True" SortExpression="NoIjin" />
            <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
            <asp:BoundField DataField="Nrp" HeaderText="Nrp" SortExpression="Nrp" />
            <asp:BoundField DataField="Jabatan" HeaderText="Jabatan" SortExpression="Jabatan" />
            <asp:BoundField DataField="Departemen" HeaderText="Departemen" SortExpression="Departemen" />
            <asp:BoundField DataField="Awal" HeaderText="Awal" SortExpression="Awal" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="Akhir" HeaderText="Akhir" SortExpression="Akhir" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="Keperluan" HeaderText="Keperluan" SortExpression="Keperluan" />
            <asp:HyperLinkField DataNavigateUrlFields="Noijin" DataNavigateUrlFormatString="dIjin1.aspx?n={0}"
                Text="Details" Target="_blank" DataTextField="Status" HeaderText="Status" SortExpression="Status" >
                <ItemStyle Width="80px" />
            </asp:HyperLinkField>
            <asp:TemplateField >
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl='<%# Eval("NoIjin", "images/prinths.png") %>'
                                    NavigateUrl='<%# Eval("NoIjin", "printForm.aspx?n={0}") %>' Target="_blank">[HyperLink1]</asp:HyperLink>
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
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=TALAFSPU401\SQLEXPRESS;Initial Catalog=Persis;Persist Security Info=True;User ID=sa;Password=pitreptala"
                    SelectCommand="SELECT tblIjin.NoIjin, vw_tblKaryawan.Nama, tblIjin.Nrp, vw_tblKaryawan.Jabatan, vw_tblKaryawan.Departemen, CASE Len(CAST(Day(tblIjin.Awal) AS Varchar)) WHEN 1 THEN '0' + CAST(Day(tblIjin.Awal) AS Varchar) WHEN 2 THEN CAST(Day(tblIjin.Awal) AS Varchar) END + CASE CAST(Month(tblIjin.Awal) AS varchar) WHEN 1 THEN ' Jan ' WHEN 2 THEN ' Feb ' WHEN 3 THEN ' Mar ' WHEN 4 THEN ' Apr ' WHEN 5 THEN ' Mei ' WHEN 6 THEN ' Jun ' WHEN 7 THEN ' Jul ' WHEN 8 THEN ' Aug ' WHEN 9 THEN ' Sep ' WHEN 10 THEN ' Okt ' WHEN 11 THEN ' Nov ' WHEN 12 THEN ' Dec ' END + CAST(YEAR(tblIjin.Awal) AS varchar) AS Awal, CASE Len(CAST(Day(tblIjin.Akhir) AS Varchar)) WHEN 1 THEN '0' + CAST(Day(tblIjin.Akhir) AS Varchar) WHEN 2 THEN CAST(Day(tblIjin.Akhir) AS Varchar) END + CASE CAST(Month(tblIjin.Akhir) AS varchar) WHEN 1 THEN ' Jan ' WHEN 2 THEN ' Feb ' WHEN 3 THEN ' Mar ' WHEN 4 THEN ' Apr ' WHEN 5 THEN ' Mei ' WHEN 6 THEN ' Jun ' WHEN 7 THEN ' Jul ' WHEN 8 THEN ' Aug ' WHEN 9 THEN ' Sep ' WHEN 10 THEN ' Okt ' WHEN 11 THEN ' Nov ' WHEN 12 THEN ' Dec ' END + CAST(YEAR(tblIjin.Akhir) AS varchar) AS Akhir, tblIjin.Keperluan, CASE WHEN Persetujuan IS NULL AND ValidasiHR IS NULL &#13;&#10;&#9;&#9; THEN 'Atasan' &#13;&#10;&#9;&#9;WHEN Persetujuan = 1 AND ValidasiHR IS NULL &#13;&#10;&#9;&#9; THEN 'Personnel' &#13;&#10;&#9;&#9;WHEN Persetujuan = 1 AND ValidasiHR = 1 &#13;&#10;&#9;&#9; THEN 'Complete' &#13;&#10;&#9;&#9;WHEN Persetujuan = 1 AND ValidasiHR = 0 &#13;&#10;&#9;&#9; THEN 'Reject' &#13;&#10;&#9;&#9;WHEN Persetujuan = 0 AND validasiHR is null &#13;&#10;&#9;&#9; THEN 'Reject' &#13;&#10;&#9;&#9; END AS Status &#13;&#10; WHERE (vw_tblKaryawan.Departemen = @dept) AND (vw_tblKaryawan.Company =@company) ORDER BY tblIjin.Tanggal DESC" ProviderName="System.Data.SqlClient">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" Name="DEPT" PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="DropDownList2" Name="company" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:GridView ID="viewls" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                    CellPadding="4" DataKeyNames="NoIjin" DataSourceID="SqlDataSource2" Font-Overline="False"
                    Font-Size="10pt" ForeColor="#333333" GridLines="None" PageSize="15" Visible="False"
                    Width="100%">
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <Columns>
            <asp:BoundField DataField="NoIjin" HeaderText="Nomor" ReadOnly="True" SortExpression="NoIjin" />
            <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
            <asp:BoundField DataField="Nrp" HeaderText="Nrp" SortExpression="Nrp" />
            <asp:BoundField DataField="Jabatan" HeaderText="Jabatan" SortExpression="Jabatan" />
            <asp:BoundField DataField="Departemen" HeaderText="Departemen" SortExpression="Departemen" />
            <asp:BoundField DataField="Awal" HeaderText="Awal" SortExpression="Awal" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="Akhir" HeaderText="Akhir" SortExpression="Akhir" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="Keperluan" HeaderText="Keperluan" SortExpression="Keperluan" />
            <asp:HyperLinkField DataNavigateUrlFields="Noijin" DataNavigateUrlFormatString="dIjin1.aspx?n={0}"
                Text="Details" Target="_blank" DataTextField="Status" HeaderText="Status" SortExpression="Status" >
                <ItemStyle Width="80px" />                
            </asp:HyperLinkField>
            <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl='<%# Eval("NoIjin", "images/prinths.png") %>'
                                    NavigateUrl='<%# Eval("NoIjin", "printForm.aspx?n={0}") %>' Target="_blank">[HyperLink1]</asp:HyperLink>
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

