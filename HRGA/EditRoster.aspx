<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EditRoster.aspx.vb" Inherits="HRGA_EditRoster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Edit Roster & Hari Off</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Nrp :"></asp:Label>
        <asp:TextBox ID="txtNrp" runat="server"></asp:TextBox>
        <asp:LinkButton ID="LinkButton1" runat="server">Search...</asp:LinkButton><br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataKeyNames="Nrp" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
            Width="708px">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="Nrp" HeaderText="Nrp" SortExpression="Nrp" ReadOnly="True" />
                <asp:BoundField DataField="NAMA" HeaderText="NAMA" SortExpression="NAMA" ReadOnly="True" />
                <asp:BoundField DataField="Dept" HeaderText="Dept" SortExpression="Dept" ReadOnly="True" />
               
				<asp:TemplateField HeaderText="RosterCode" SortExpression="RosterCode">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="SqlDataDept" DataTextField="RosterCode"
                            DataValueField="RosterCode" SelectedValue='<%# Bind("RosterCode") %>'>
                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataDept" runat="server" ConnectionString="<%$ ConnectionStrings:Data_abs1ConnectionString %>"
                            SelectCommand="SELECT [RosterCode] FROM [Roster]">
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        &nbsp;<asp:DropDownList ID="DropDownList6" runat="server" DataSourceID="SqlDataDept" DataTextField="RosterCode"
                            DataValueField="RosterCode" SelectedValue='<%# Bind("RosterCode") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataDept" runat="server" ConnectionString="<%$ ConnectionStrings:Data_abs1ConnectionString %>"
                            SelectCommand="SELECT [RosterCode] FROM [Roster]">
                        </asp:SqlDataSource>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("RosterCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
				
				
                <asp:TemplateField HeaderText="Harike7" SortExpression="Harike7">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList2" runat="server" SelectedValue='<%# Bind("Harike7") %>'>
                            <asp:ListItem Selected="True">Senin</asp:ListItem>
                            <asp:ListItem>Selasa</asp:ListItem>
                            <asp:ListItem>Rabu</asp:ListItem>
                            <asp:ListItem>Kamis</asp:ListItem>
                            <asp:ListItem>Jumat</asp:ListItem>
                            <asp:ListItem>Sabtu</asp:ListItem>
                            <asp:ListItem>Minggu</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Harike7") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TglHarike7" HeaderText="TglHarike7" SortExpression="TglHarike7" />
                <asp:CommandField ShowEditButton="True"  ButtonType=Image DeleteImageUrl="~/Images/Delete.gif" EditImageUrl="~/Images/Edit.gif" CancelImageUrl="~/Images/Cancel.gif" UpdateImageUrl="~/Images/Update.gif"/>
            </Columns>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Data_abs1ConnectionString %>"
            DeleteCommand="DELETE FROM [Karyawan] WHERE [Nrp] = @Nrp" InsertCommand="INSERT INTO [Karyawan] ([Nrp], [NAMA], [Dept], [RosterCode], [Harike7], [TglHarike7]) VALUES (@Nrp, @NAMA, @Dept, @RosterCode, @Harike7, @TglHarike7)"
            SelectCommand="SELECT [Nrp], [NAMA], [Dept], [RosterCode], RTrim([Harike7]) As [Harike7], [TglHarike7] FROM [Karyawan] Where Nrp = @Nrp"
            UpdateCommand="UPDATE [Karyawan] SET  [RosterCode] = @RosterCode, [Harike7] = @Harike7, [TglHarike7] = @TglHarike7 WHERE [Nrp] = @Nrp">
            <DeleteParameters>
                <asp:Parameter Name="Nrp" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="RosterCode" Type="Int32" />
                <asp:Parameter Name="Harike7" Type="String" />
                <asp:Parameter Name="TglHarike7" Type="DateTime" />
                <asp:Parameter Name="Nrp" Type="String" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="txtNrp" Name="Nrp" PropertyName="Text" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="Nrp" Type="String" />
                <asp:Parameter Name="NAMA" Type="String" />
                <asp:Parameter Name="Dept" Type="String" />
                <asp:Parameter Name="RosterCode" Type="Int32" />
                <asp:Parameter Name="Harike7" Type="String" />
                <asp:Parameter Name="TglHarike7" Type="DateTime" />
            </InsertParameters>
        </asp:SqlDataSource>
    
    </div>
	
	

	<div style="margin-top:100px; margin-bottom: 100px">
	<hr/>
	<h3>Keterangan Roster Code :</h3> 
		<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataKeyNames="RosterCode" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None"
            Width="708px">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="RosterCode" HeaderText="Roster Code" SortExpression="RosterCode" ReadOnly="True" />
				 <asp:BoundField DataField="Dept" HeaderText="Dept" SortExpression="Dept" ReadOnly="True" />
				  <asp:BoundField DataField="Lokasi" HeaderText="Lokasi" SortExpression="Lokasi" ReadOnly="True" />
                <asp:BoundField DataField="Shift" HeaderText="Shift" SortExpression="Shift" ReadOnly="True" />
                <asp:BoundField DataField="In" HeaderText="In" SortExpression="In" ReadOnly="True" />
				 <asp:BoundField DataField="Out" HeaderText="Out" SortExpression="Out" ReadOnly="True" />
				<asp:BoundField DataField="JamKerja" HeaderText="Jam Kerja" SortExpression="JamKerja" ReadOnly="True" />
			    <asp:BoundField DataField="Toleransi" HeaderText="Toleransi" SortExpression="Toleransi" ReadOnly="True" />
				<asp:BoundField DataField="Ket" HeaderText="Ket" SortExpression="Ket" ReadOnly="True" />
            </Columns>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
		  <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Data_abs1ConnectionString %>"   
            SelectCommand="SELECT [RosterCode], [Dept], [Lokasi], [Shift],[In],[Out],[JamKerja],[Toleransi],[Ket] FROM [VW_ROSTER]">       
        </asp:SqlDataSource>
	</div>
	
    </form>
	
	
</body>
</html>
