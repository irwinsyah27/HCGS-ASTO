<%@ Page Language="VB" MasterPageFile="MasterHrga.master" AutoEventWireup="false" CodeFile="Proposal.aspx.vb" Inherits="HRGA_MasterKaryawanPama" title="Karyawan Pama" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp; &nbsp;
    <asp:SqlDataSource ID="SqlDataDept" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT [Dept] FROM [Tbl_Dept]"></asp:SqlDataSource>
    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" Width="90%">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Departemen :"></asp:Label>
    <asp:DropDownList ID="DropDownListDept" runat="server" AutoPostBack="True" DataSourceID="SqlDataDept"
        DataTextField="Dept" DataValueField="Dept">
    </asp:DropDownList>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        &nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Company :"></asp:Label>
    <asp:DropDownList ID="DropDownListCompany" runat="server" AutoPostBack="True">
        <asp:ListItem></asp:ListItem>
        <asp:ListItem Selected="True">KPP</asp:ListItem>
        <asp:ListItem>DAB</asp:ListItem>
        <asp:ListItem>GNI</asp:ListItem>
        <asp:ListItem>SIGAP</asp:ListItem>
    </asp:DropDownList></asp:Panel>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT DISTINCT [Company] FROM [TblKaryawan]"></asp:SqlDataSource>
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" DataKeyNames="Nrp" DataSourceID="SqlDataSource1" ForeColor="#333333"
        GridLines="None" PageSize="20" AllowSorting="True">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <Columns>
        <asp:CommandField ButtonType="Image" CancelImageUrl="~/Images/Cancel.gif" DeleteImageUrl="~/Images/Delete.gif" EditImageUrl="~/Images/Edit.gif" SelectImageUrl="~/Images/Plus.gif" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" UpdateImageUrl="~/Images/Update.gif" Visible="False">
				    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
				    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
			        </asp:CommandField>
            <asp:BoundField DataField="Nrp" HeaderText="Nrp" ReadOnly="True" SortExpression="Nrp" />
            <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
            <asp:BoundField DataField="TempatLahir" HeaderText="TempatLahir" SortExpression="TempatLahir" />
            <asp:BoundField DataField="TglLahir" HeaderText="TglLahir" SortExpression="TglLahir" />
            <asp:BoundField DataField="JenisKelamin" HeaderText="JenisKelamin" SortExpression="JenisKelamin" />
            <asp:BoundField DataField="GolonganDarah" HeaderText="GolonganDarah" SortExpression="GolonganDarah" />
            <asp:BoundField DataField="TglMasukPama" HeaderText="TglMasukPama" SortExpression="TglMasukPama" />
            <asp:BoundField DataField="StatusPenerimaan" HeaderText="StatusPenerimaan" SortExpression="StatusPenerimaan" />
            <asp:BoundField DataField="Company" HeaderText="Company" SortExpression="Company" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl='<%# Eval("Nrp", "images/GoLtrHS.png") %>'
                        NavigateUrl='<%# Eval("Nrp", "EditKaryawan.aspx?nrp={0}") %>' Target="_blank">[HyperLink1]</asp:HyperLink>
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT [Nrp], [Nama], [TempatLahir], [TglLahir], [JenisKelamin], [GolonganDarah], [TglMasukPama], [StatusPenerimaan], [Company] FROM [tblKaryawan] Where [StatusPenerimaan] IN ('LOKAL','KIRIMAN') And Company Like @Company AND Departemen Like @DEPT UNION &#13;&#10;SELECT '0' AS [Nrp], NULL AS [Nama],  NULL AS [TempatLahir], NULL AS [TglLahir],NULL AS [JenisKelamin],  NULL AS [GolonganDarah],NULL AS [TglMasukPama],NULL AS [StatusPenerimaan],NULL AS [Company] FROM [tblKaryawan] ">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownListDept" Name="DEPT" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="DropDownListCompany" Name="Company" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

