<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EditHarike7.aspx.vb" Inherits="HRGA_EditHarike7" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Hari ke7</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Dept :
        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2"
            DataTextField="Dept" DataValueField="Dept">
        </asp:DropDownList>Nrp :
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
            SelectCommand="SELECT '' AS [Dept] FROM [Tbl_Dept] UNION SELECT [Dept] FROM [Tbl_Dept]">
        </asp:SqlDataSource>
        <asp:LinkButton ID="btnSearch" runat="server" Font-Bold="True">Search</asp:LinkButton><br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataKeyNames="Nrp" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" AllowPaging="True" BorderStyle="Solid" BorderWidth="1px" PageSize="18" AllowSorting="True">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="Nrp" HeaderText="Nrp" ReadOnly="True" SortExpression="Nrp" />
                <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" ReadOnly="True" />
                <asp:BoundField DataField="Departemen" HeaderText="Departemen" SortExpression="Departemen" ReadOnly="True" />
                <asp:TemplateField HeaderText="Harike7" SortExpression="Harike7">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("Harike7") %>'>
                            <asp:ListItem Selected="True" Value="  "> </asp:ListItem>
                            <asp:ListItem>Senin</asp:ListItem>
                            <asp:ListItem>Selasa</asp:ListItem>
                            <asp:ListItem>Rabu</asp:ListItem>
                            <asp:ListItem>Kamis</asp:ListItem>
                            <asp:ListItem>Jumat</asp:ListItem>
                            <asp:ListItem>Sabtu</asp:ListItem>
                            <asp:ListItem Value="Minggu">Minggu</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TanggalHarike7") %>'></asp:TextBox>
                        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                        
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Harike7") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True"  ButtonType=Image DeleteImageUrl="~/Images/Delete.gif" EditImageUrl="~/Images/Edit.gif" CancelImageUrl="~/Images/Cancel.gif" UpdateImageUrl="~/Images/Update.gif"/>
            </Columns>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
            DeleteCommand="DELETE FROM [tblKaryawan] WHERE [Nrp] = @Nrp" 
            InsertCommand="INSERT INTO [tblKaryawan] ([Nrp], [Nama], [Departemen], [Harike7]) VALUES (@Nrp, @Nama, @Departemen, @Harike7)"
            SelectCommand="SELECT A.Nrp, A.Nama, A.Departemen, RTrim(A.Harike7) As Harike7, B.TanggalHarike7 FROM tblKaryawan A INNER JOIN vw_Harike7 B ON A.Nrp= B.Nrp Where ((A.Nrp Like '%' + @Nrp + '%' AND A.Departemen = @Dept ) )&#13;&#10;&#13;&#10;"
            UpdateCommand="UPDATE [tblKaryawan] SET [Harike7] = @Harike7 WHERE [Nrp] = @Nrp">
            <DeleteParameters>
                <asp:Parameter Name="Nrp" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Harike7" Type="String" />
                <asp:Parameter Name="Nrp" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="Nrp" Type="String" />
                <asp:Parameter Name="Nama" Type="String" />
                <asp:Parameter Name="Departemen" Type="String" />
                <asp:Parameter Name="Harike7" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="txtSearch" Name="Nrp" PropertyName="Text" />
                <asp:ControlParameter ControlID="DropDownList2" Name="Dept" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
