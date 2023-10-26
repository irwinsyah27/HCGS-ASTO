<%@ Page Language="VB" MasterPageFile="MasterHrga.master" AutoEventWireup="false" CodeFile="RosterNrp.aspx.vb" Inherits="RosterNrp" title="Roster NRP" %>
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
        &nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Company :"></asp:Label><asp:DropDownList ID="DropDownListCompany" runat="server" AutoPostBack="True">
        <asp:ListItem></asp:ListItem>
        <asp:ListItem Selected="True">KPP</asp:ListItem>
        <asp:ListItem>TMN</asp:ListItem>
        <asp:ListItem>AEA</asp:ListItem>
            <asp:ListItem>TPP</asp:ListItem>
            <asp:ListItem>Global</asp:ListItem>

    </asp:DropDownList>
	 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
	 <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="NRP : "></asp:Label>&nbsp;
                <asp:TextBox ID="txNRP" runat="server"></asp:TextBox>
	
	</asp:Panel>
	
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
            <asp:BoundField DataField="JABATAN" HeaderText="Jabatan" SortExpression="JABATAN" />
            <asp:BoundField DataField="Departemen" HeaderText="Departemen" SortExpression="Departemen" />
            <asp:BoundField DataField="RosterCode" HeaderText="RosterCode" SortExpression="RosterCode" />
			<asp:BoundField DataField="HariKe7" HeaderText="HariKe7" SortExpression="HariKe7" />
			<asp:BoundField DataField="Company" HeaderText="Company" SortExpression="Company" />
        </Columns>
        <RowStyle BackColor="#E3EAEB" />
        <EditRowStyle BackColor="#7C6F57" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Data_abs1ConnectionString %>"
        SelectCommand="SELECT [Nrp],[Nama],[JABATAN],[Departemen],[RosterCode],[Harike7],[Company] FROM VW_ROSTER_NRP WHERE ([Nrp] = @NRP OR @NRP = 'ALL') And Company Like @Company AND Departemen Like @DEPT ">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownListDept" Name="DEPT" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="DropDownListCompany" Name="Company" PropertyName="SelectedValue" />
			<asp:ControlParameter ControlID="txNRP" DefaultValue="ALL" Name="NRP" PropertyName="Text" />
            <asp:SessionParameter DefaultValue="" Name="Site" SessionField="Site" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

