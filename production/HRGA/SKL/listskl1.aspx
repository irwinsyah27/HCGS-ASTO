<%@ Page Language="VB" Debug="True"  MasterPageFile="../MasterHrga.master" AutoEventWireup="false" CodeFile="listskl1.aspx.vb" Inherits="listskl1" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;&nbsp;
    <table style="width: 100%; text-align: center;">
        <tr>
            <td style="width: 100%">
                <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Company :"></asp:Label>&nbsp;<asp:DropDownList
                    ID="DropDownList8" runat="server" AutoPostBack="True"
                    DataTextField="Company" DataValueField="Company" 
                    DataSourceID="SqlDatacompany">
                    <asp:ListItem>ALL</asp:ListItem>
                </asp:DropDownList>&nbsp;
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Dept :"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                    DataSourceID="SqlDataDept" DataTextField="Departemen" 
                    DataValueField="Departemen">
                </asp:DropDownList><asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Status :"></asp:Label><asp:DropDownList
                    ID="DropDownList3" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3"
                    DataTextField="Status" DataValueField="Status">
                </asp:DropDownList>
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="NRP : "></asp:Label>
                <asp:TextBox ID="txNRP" runat="server"></asp:TextBox><asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DATA_ABS1ConnectionString %>"
                    SelectCommand="SELECT DISTINCT Status FROM Tbl_SKL1 UNION SELECT '' AS status"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataStatus" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                    SelectCommand="SELECT DISTINCT [Status] FROM [data_abs1.dbo.tbl_skl1] UNION SELECT '' AS  [status] ">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataDept" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                    SelectCommand="SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] ">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDatacompany" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                    SelectCommand="SELECT * FROM(&#13;&#10;SELECT DISTINCT Company FROM tblKaryawan where Company <>'' UNION ALL SELECT '' AS Company&#13;&#10;UNION ALL SELECT 'ALL' AS Company) AS Tbl&#13;&#10;ORDER BY Company"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; border-right: maroon 1px solid; border-top: maroon 1px solid; border-left: maroon 1px solid; border-bottom: maroon 1px solid; height: 100%;" align="center">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
                    Visible="False" style="text-align: center" Height="334px" Width="624px">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <Columns>
            <asp:BoundField DataField="noskl" HeaderText="noskl" SortExpression="noskl" />
            <asp:BoundField DataField="tglcreated" HeaderText="tglcreated" SortExpression="tglcreated" />
            <asp:BoundField DataField="nrp" HeaderText="nrp" SortExpression="nrp" />
            <asp:BoundField DataField="NAMA" HeaderText="NAMA" SortExpression="NAMA" />
            <asp:BoundField DataField="Dept" HeaderText="Dept" SortExpression="Dept" />
            <asp:BoundField DataField="uraianlembur" HeaderText="uraian lembur" SortExpression="uraianlembur" />
            <asp:CheckBoxField DataField="aprove" HeaderText="aprove dept" SortExpression="aprove" />
            <asp:CheckBoxField DataField="aprovehr" HeaderText="Aprove HR" SortExpression="aprovehr" />
            <asp:HyperLinkField DataNavigateUrlFields="noskl" DataNavigateUrlFormatString="vwskl.aspx?n={0}"
                Target="_blank" Text="Select" />
        </Columns>
        <RowStyle BackColor="#EFF3FB" />
        <EditRowStyle BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Data_abs1ConnectionString %>"
        SelectCommand="SELECT TOP 1000 Tbl_SKL.NoSKL, Tbl_SKL.TglCreated, Tbl_subSKL.Nrp, Karyawan.NAMA, Karyawan.Dept, Tbl_subSKL.AwalLembur, Tbl_subSKL.akhirLembur, Tbl_SKL.UraianLembur, Tbl_subSKL.Aprove, Tbl_subSKL.AproveHR FROM Karyawan INNER JOIN Tbl_subSKL ON Karyawan.Nrp = Tbl_subSKL.Nrp INNER JOIN Tbl_SKL ON Tbl_subSKL.NoSKL = Tbl_SKL.NoSKL WHERE (Karyawan.Dept = @Dept) 
AND (Lokasi=@Site OR @Jabatan LIKE '%PERSONNEL SITE%' OR @Jabatan LIKE '%ENG DEPT. HEAD%'  OR @Jabatan LIKE '%PROJECT MANAGER%' OR @Jabatan LIKE '%BPI SITE OFFICER%' OR @Jabatan LIKE '%FAT DEPT. HEAD%' OR @Jabatan LIKE '%HRPGA DEPT. HEAD%' OR @Jabatan LIKE '%HRPGA SECT. HEAD%' OR @Jabatan LIKE '%PAYROLL OFFICER%' OR @CNRP = 'DR00169' OR @CNRP = 'KC09056' OR @CNRP = 'KC04059' OR @CNRP = 'KB11082')
order by tbl_skl.Noskl Desc">
        <SelectParameters>
            <asp:ControlParameter ControlID="Label1" Name="dept" PropertyName="Text" />
            <asp:SessionParameter Name="Site" SessionField="Site" />
            <asp:ControlParameter ControlID="Label1" Name="Dept" PropertyName="Text" />
            <asp:SessionParameter Name="Jabatan" SessionField="Jabatan" />
            <asp:SessionParameter Name="CNRP" SessionField="userid" />
        </SelectParameters>
    </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Data_abs1ConnectionString %>"
                    
                    
                    SelectCommand="SELECT   TOP 1000  dSKL.NoSKL, CAST(DATEPART(month, dSKL.TglCreated) AS varchar) + '/' + CAST(DATEPART(day, dSKL.TglCreated) AS varchar) + '/' + CAST(DATEPART(year, 
                      dSKL.TglCreated) AS varchar) AS TglCreated, dbo.Tbl_subSKL1.Nrp, dSKL.NrpRequestor, dbo.Tbl_subSKL1.AwalLembur, dSKL.Aprovedept, CAST(DATEPART(month, 
                      dSKL.TglCreated) AS varchar) + '/' + CAST(DATEPART(day, dSKL.TglAproved) AS varchar) + '/' + CAST(DATEPART(year, dSKL.TglAproved) AS varchar) AS TglAproved, 
                      dSKL.Aprovehr, CAST(DATEPART(month, dSKL.TglHRAproved) AS varchar) + '/' + CAST(DATEPART(day, dSKL.TglHRAproved) AS varchar) + '/' + CAST(DATEPART(year, 
                      dSKL.TglHRAproved) AS varchar) AS TglHRAproved, dSKL.SKL, dSKL.Status, dSKL.NRPAproved, dSKL.NRPHR, dSKL.Departemen, 
                      Persis.dbo.tblKaryawan.Company
FROM         dbo.Tbl_subSKL1 INNER JOIN
                      Persis.dbo.tblKaryawan ON dbo.Tbl_subSKL1.Nrp = Persis.dbo.tblKaryawan.Nrp RIGHT OUTER JOIN
                          (SELECT     A.NoSKL, B.Departemen, A.TglCreated, A.Aprovedept, A.TglAproved, A.Aprovehr, A.TglHRAproved, 
                                                   CASE A.SKL WHEN 'RT' THEN 'REST TIME' WHEN 'SN' THEN 'SENAM PAGI' WHEN 'PK' THEN 'PIKET MALAM' WHEN 'H7' THEN 'HARI KE 7' WHEN 'N' THEN
                                                    'HARI BIASA' ELSE A.SKL END AS SKL, A.Status, A.NrpRequestor, A.NRPAproved, A.NRPHR
                            FROM          dbo.Tbl_SKL1 AS A INNER JOIN
                                                   Persis.dbo.tblKaryawan AS B ON A.NrpRequestor = B.Nrp) AS dSKL ON dbo.Tbl_subSKL1.NoSKL = dSKL.NoSKL WHERE (dSKL.Departemen = @DEPT or @DEPT = 'ALL DEPT') AND (dSKL.Status=@Status or @Status='ALL')   AND (Company=@Company or @Company='ALL') AND
( Tbl_subSKL1.Nrp =@NRP or @NRP='ALL')
AND (Lokasi=@Site OR @Jabatan LIKE '%PERSONNEL SITE%' OR @Jabatan LIKE '%DEPT. HEAD%'
 OR @Jabatan LIKE '%SECT. HEAD%'
 OR @Jabatan LIKE '%PROJECT MANAGER%' OR @Jabatan LIKE '%ICT SITE%' OR @Jabatan LIKE '%PAYROLL%' OR @CAdmin = 1)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" Name="DEPT" 
                            PropertyName="SelectedValue" DefaultValue="ALL DEPT" />
                        <asp:ControlParameter ControlID="DropDownList3" Name="Status" PropertyName="SelectedValue" DefaultValue="ALL" />
                        <asp:ControlParameter ControlID="DropDownList8" DefaultValue="ALL" Name="Company"
                            PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="txNRP" DefaultValue="ALL" Name="NRP" PropertyName="Text" />
                        <asp:SessionParameter DefaultValue="" Name="Site" SessionField="Site" />
                        <asp:SessionParameter DefaultValue="" Name="Jabatan" SessionField="Jabatan" />
                        <asp:SessionParameter DefaultValue="" Name="CAdmin" SessionField="Admin" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None"
                    BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource2">
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <Columns>
                        <asp:BoundField DataField="NoSKL" HeaderText="NoSKL" SortExpression="NoSKL" />
                        <asp:BoundField DataField="nrprequestor" HeaderText="Requestor" SortExpression="nrprequestor" />
                        <asp:BoundField DataField="tglcreated" HeaderText="Tanggal Input" SortExpression="tglcreated" dataformatstring="{0:d}"/>
                        <asp:BoundField DataField="nrp" HeaderText="Karyawan" SortExpression="nrp" />
                        <asp:BoundField DataField="AwalLembur" HeaderText="Awal Lembur" SortExpression="AwalLembur" DataFormatString="{0:d}" />
                        <asp:CheckBoxField DataField="Aprovedept" HeaderText="Aprovedept" SortExpression="Aprovedept" />
                        <asp:BoundField DataField="NrpAproved" HeaderText="D H" SortExpression="NrpAproved" />
                        <asp:BoundField DataField="TglAproved" HeaderText="TglAproved" SortExpression="TglAproved" />
                        <asp:CheckBoxField DataField="Aprovehr" HeaderText="Aprovehr" SortExpression="Aprovehr" />
                        <asp:BoundField DataField="Nrphr" HeaderText="HRGA" SortExpression="Nrphr" />
                        <asp:BoundField DataField="TglHRAproved" HeaderText="TglHRAproved" SortExpression="TglHRAproved" />
                        <asp:BoundField DataField="skl" HeaderText="skl" SortExpression="skl" />
                        <asp:TemplateField HeaderText="Status" SortExpression="Status" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("Status") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField DataNavigateUrlFields="noskl" DataNavigateUrlFormatString="redirect.aspx?n={0}"
                            DataTextField="status" HeaderText="Status" SortExpression="status" Target="_blank" />
                        <asp:HyperLinkField DataNavigateUrlFields="noskl" DataNavigateUrlFormatString="ccc.aspx?n={0}"
                            DataTextField="Status" Visible="False" />
                    </Columns>
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                </asp:GridView>
                &nbsp; &nbsp;&nbsp; &nbsp;
                <asp:Label ID="Label1" runat="server" BorderColor="White" ForeColor="White"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

