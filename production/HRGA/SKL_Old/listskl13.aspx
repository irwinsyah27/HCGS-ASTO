<%@ Page Language="VB" Debug="True"  MasterPageFile="../MasterHrga.master" AutoEventWireup="false" CodeFile="listskl13.aspx.vb" Inherits="listskl1" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;&nbsp;
    <table style="width: 100%">
        <tr>
            <td style="width: 100%">
                &nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Visible="False">
                    <asp:ListItem>-</asp:ListItem>
                    <asp:ListItem>HRGA</asp:ListItem>
                    <asp:ListItem>ENG</asp:ListItem>
                    <asp:ListItem>FAT</asp:ListItem>
                    <asp:ListItem>TYRE</asp:ListItem>
                    <asp:ListItem>PROD</asp:ListItem>
                    <asp:ListItem>OPR</asp:ListItem>
                    <asp:ListItem>SHE</asp:ListItem>
                    <asp:ListItem>PSV</asp:ListItem>
                    <asp:ListItem>CDV</asp:ListItem>
                    <asp:ListItem>PHE</asp:ListItem>
                    <asp:ListItem>LHE</asp:ListItem>
                    <asp:ListItem>OTD</asp:ListItem>
                    <asp:ListItem>HAUL</asp:ListItem>
                    <asp:ListItem>PCH</asp:ListItem>
                    <asp:ListItem>LCH</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 100%; border-right: maroon 1px solid; border-top: maroon 1px solid; border-left: maroon 1px solid; border-bottom: maroon 1px solid; height: 100%;" align="center">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Visible="False" style="text-align: center">
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
        SelectCommand="SELECT Tbl_SKL.NoSKL, Tbl_SKL.TglCreated, Tbl_subSKL.Nrp, Karyawan.NAMA, Karyawan.Dept, Tbl_subSKL.AwalLembur, Tbl_subSKL.akhirLembur, Tbl_SKL.UraianLembur, Tbl_subSKL.Aprove, Tbl_subSKL.AproveHR FROM Karyawan INNER JOIN Tbl_subSKL ON Karyawan.Nrp = Tbl_subSKL.Nrp INNER JOIN Tbl_SKL ON Tbl_subSKL.NoSKL = Tbl_SKL.NoSKL WHERE (Karyawan.Dept = @Dept)&#13;&#10;order by tbl_skl.Noskl Desc">
        <SelectParameters>
            <asp:ControlParameter ControlID="Label1" Name="dept" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Data_abs1ConnectionString %>"
                    SelectCommand="SELECT A.NoSKL, B.Departemen, A.Aprovedept, A.TglAproved, A.Aprovehr, A.TglHRAproved, CASE A.SKL WHEN 'RT' THEN 'REST TIME' WHEN 'SN' THEN 'SENAM PAGI' WHEN 'PK' THEN 'PIKET MALAM' WHEN 'H7' THEN 'HARI KE 7' WHEN 'N' THEN 'HARI BIASA' ELSE A.SKL END AS SKL, A.Status, A.NrpRequestor, A.NRPAproved, A.NRPHR FROM Tbl_SKL1 AS A INNER JOIN Persis.dbo.tblKaryawan AS B ON A.NrpRequestor = B.Nrp WHERE (B.Departemen = @DEPT)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Label1" Name="DEPT" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None"
                    BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource2">
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <Columns>
                        <asp:BoundField DataField="NoSKL" HeaderText="NoSKL" SortExpression="NoSKL" />
                        <asp:BoundField DataField="nrprequestor" HeaderText="Requestor" SortExpression="nrprequestor" />
                        <asp:CheckBoxField DataField="Aprovedept" HeaderText="Aprovedept" SortExpression="Aprovedept" />
                        <asp:BoundField DataField="NrpAproved" HeaderText="Dept" SortExpression="NrpAproved" />
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

