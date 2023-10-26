<%@ Page Language="VB" MasterPageFile="../MasterHrga.master"  AutoEventWireup="false" CodeFile="lstCutiNonKpp.aspx.vb" Inherits="lstCutiNonKpp" title="List Cuti Non Kpp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp; &nbsp;
    <asp:SqlDataSource ID="SqlDataDept" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT [Dept] FROM [Tbl_Dept]"></asp:SqlDataSource>
    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" Width="90%">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Departemen :"></asp:Label>
    <asp:DropDownList ID="DropDownListDept" runat="server" AutoPostBack="True" DataSourceID="SqlDataDept"
        DataTextField="Dept" DataValueField="Dept">
    </asp:DropDownList>
	
	 <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="NRP : "></asp:Label>&nbsp;
                <asp:TextBox ID="txNRP" runat="server"></asp:TextBox>
	
	</asp:Panel>
	
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" DataKeyNames="NO_ST" DataSourceID="SqlDataSource1" ForeColor="#333333"
        GridLines="None" PageSize="20" AllowSorting="True" OnRowDeleting="OnRowDeleting">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <Columns>
        <asp:CommandField ButtonType="Image" CancelImageUrl="~/Images/Cancel.gif" DeleteImageUrl="~/Images/Delete.gif" EditImageUrl="~/Images/Edit.gif" SelectImageUrl="~/Images/Plus.gif" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" UpdateImageUrl="~/Images/Update.gif" Visible="False">
				    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
				    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
			        </asp:CommandField>
            <asp:BoundField DataField="NO_ST" HeaderText="No. ST" ReadOnly="True" SortExpression="NO_ST" />
            <asp:BoundField DataField="NRP" HeaderText="NRP" SortExpression="NRP" />
            <asp:BoundField DataField="NAMA" HeaderText="Nama" SortExpression="NAMA" />
            <asp:BoundField DataField="AWAL" HeaderText="Awal" SortExpression="AWAL" />
            <asp:BoundField DataField="AKHIR" HeaderText="Akhir" SortExpression="AKHIR" />
            <asp:BoundField DataField="COMPANY" HeaderText="Perusahaan" SortExpression="COMPANY" />
            <asp:BoundField DataField="DEPARTEMEN" HeaderText="Departemen" SortExpression="DEPARTEMEN" />
            <asp:BoundField DataField="JABATAN" HeaderText="Jabatan" SortExpression="JABATAN" />
            <asp:BoundField DataField="TUJUAN" HeaderText="Tujuan" SortExpression="TUJUAN" />
           
			 <asp:CommandField ButtonType="Link" ShowDeleteButton="true"
                    ItemStyle-Width="50" />
        </Columns>
        <RowStyle BackColor="#E3EAEB" />
        <EditRowStyle BackColor="#7C6F57" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT [NO_ST], [NRP], [AWAL], [AKHIR], [NAMA], [COMPANY], [DEPARTEMEN], [JABATAN], [TUJUAN], [TELEPON], [MESS],[STATUS], [KETERANGAN] FROM [TblSutuNonKpp] Where DEPARTEMEN Like @DEPT AND ([NRP]=@NRP or @NRP='ALL') ORDER BY CREATED_DATE DESC"	
		DeleteCommand="DELETE FROM [TblSutuNonKpp] WHERE [NO_ST] = @NO_ST">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownListDept" Name="DEPT" PropertyName="SelectedValue" />
			<asp:ControlParameter ControlID="txNRP" DefaultValue="ALL" Name="NRP" PropertyName="Text" />
            <asp:SessionParameter DefaultValue="" Name="Site" SessionField="Site" />
        </SelectParameters>
		<DeleteParameters>
            <asp:Parameter Name="NO_ST" Type="String" />
        </DeleteParameters>
    </asp:SqlDataSource>
</asp:Content>

