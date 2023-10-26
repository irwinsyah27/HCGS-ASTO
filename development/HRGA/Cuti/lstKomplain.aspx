<%@ Page Language="VB" MasterPageFile="../MasterHrga.master" AutoEventWireup="false" CodeFile="lstKomplain.aspx.vb" Inherits="lstKomplain" title="List Surat Komplain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="width: 100%; text-align: center">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="14pt" 
                    Text="Karyawan Komplain"></asp:Label><br />
                <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Company :"></asp:Label>&nbsp;<asp:DropDownList
                    ID="DropDownList8" runat="server" AutoPostBack="True"
                    DataTextField="Company" DataValueField="Company">
                    <asp:ListItem>-</asp:ListItem>
                    <asp:ListItem Selected="True">KPP</asp:ListItem>
                </asp:DropDownList>
                &nbsp; &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Departemen : "></asp:Label><asp:DropDownList
                    ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataDept"
                    DataTextField="Departemen" DataValueField="Departemen">
                </asp:DropDownList>
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Status : "></asp:Label>
                <asp:DropDownList ID="DDLStatus" runat="server" AutoPostBack="True" DataSourceID="SqlStatus"
                    DataTextField="Status" DataValueField="Status">
                </asp:DropDownList>
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="NRP : "></asp:Label>
                <asp:TextBox ID="txNRP" runat="server"></asp:TextBox><br />
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
	, tblSutu.Status FROM vw_tblKaryawan INNER JOIN tblSutu ON vw_tblKaryawan.Nrp = tblSutu.Nrp 
Where Keperluan Like '%KOMPLAIN%' AND (Departemen = @DEPT OR @DEPT='ALL DEPT') AND (tblSutu.Status=@Status or @Status='ALL')   AND (Company=@Company or @Company='ALL') AND
(tblSutu.Nrp=@NRP or @NRP='ALL')
AND (Lokasi=@Site OR @Jabatan LIKE '%PERSONNEL SITE%' OR @Jabatan LIKE '%ENG DEPT. HEAD%'  OR @Jabatan LIKE '%PROJECT MANAGER%' OR @Jabatan LIKE '%BPI SITE OFFICER%' OR @Jabatan LIKE '%FAT DEPT. HEAD%' OR @Jabatan LIKE '%HRPGA DEPT. HEAD%' OR @Jabatan LIKE '%HRPGA SECT. HEAD%' OR @Jabatan LIKE '%PAYROLL OFFICER%' OR @CNRP = 'DR00169' OR @CNRP = 'KC09056' OR @CNRP = 'KC04059' OR @CNRP = 'KB11082')
ORDER BY tblSutu.TglST DESC

">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" Name="DEPT" 
                            PropertyName="SelectedValue" DefaultValue="" />
                        <asp:ControlParameter ControlID="DDLStatus" Name="Status" PropertyName="SelectedValue" DefaultValue="ALL" />
                        <asp:ControlParameter ControlID="DropDownList8" Name="Company" 
                            PropertyName="SelectedValue" DefaultValue="" />
                        <asp:ControlParameter ControlID="txNRP" DefaultValue="ALL" Name="NRP" PropertyName="Text" />
                        <asp:SessionParameter Name="Site" SessionField="Site" />
                        <asp:SessionParameter Name="Jabatan" SessionField="Jabatan" />
                        <asp:SessionParameter Name="CNRP" SessionField="userid" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataDept" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                    SelectCommand="SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] UNION SELECT 'ALL DEPT' AS [Departemen]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlStatus" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                    
                    SelectCommand="SELECT * FROM(SELECT DISTINCT [Status] FROM [tblSutu] where NomorST like '%KL' UNION SELECT 'ALL' AS [Status]) AS TBL Where Status &lt;&gt;''">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDatacompany" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                    SelectCommand="SELECT * FROM(&#13;&#10;SELECT DISTINCT Company FROM tblKaryawan where Company <>'' UNION ALL SELECT '' AS Company) AS Tbl&#13;&#10;ORDER BY Company"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 100%" valign="top">
                <asp:GridView ID="ViewKPP" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="NomorST" DataSourceID="SqlDataSource1"
                    Font-Overline="False" Font-Size="10pt" ForeColor="#333333" GridLines="None" PageSize="15"
                    Width="100%">
                    <RowStyle BackColor="#E3EAEB" />
                    <Columns>
                        <asp:BoundField DataField="NomorST" HeaderText="NomorST" ReadOnly="True" SortExpression="NomorST" />
                        <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
                        <asp:BoundField DataField="Nrp" HeaderText="Nrp" SortExpression="Nrp" />
                        <asp:BoundField DataField="Jabatan" HeaderText="Jabatan" SortExpression="Jabatan" />
                        <asp:BoundField DataField="Departemen" HeaderText="Departemen" SortExpression="Departemen" />
                        <asp:BoundField DataField="Tujuan" HeaderText="Tujuan" SortExpression="Tujuan" />
                        <asp:BoundField DataField="Keperluan" HeaderText="Keperluan" 
                            SortExpression="Keperluan">
                        </asp:BoundField>
                        <asp:HyperLinkField DataNavigateUrlFields="NomorST" DataNavigateUrlFormatString="dKomplain.aspx?n={0}"
                            DataTextField="Status" HeaderText="Status" SortExpression="Status" Target="_blank"
                            Text="Status">
                            <ItemStyle Width="80px" />
                        </asp:HyperLinkField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl='<%# Eval("NomorST", "images/prinths.png") %>'
                                    NavigateUrl='<%# Eval("NomorST", "printForm.aspx?n={0}") %>' Target="_blank">[HyperLink1]</asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

