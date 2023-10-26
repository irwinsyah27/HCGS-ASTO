<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Edit_Roster_Per_Dept.aspx.vb" Inherits="HRGA_EditRoster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Edit Roster & Hari Off</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Dept :"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="RosterCode" 
            DataValueField="RosterCode">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Ds_Edit_Roster" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DATA_ABS1ConnectionString2 %>" 
            SelectCommand="SELECT RosterCode FROM Roster"></asp:SqlDataSource>
        <asp:LinkButton ID="LinkButton1" runat="server">Search...</asp:LinkButton><br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataKeyNames="Nrp" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
            Width="708px">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="Nrp" HeaderText="Nrp" SortExpression="Nrp" ReadOnly="True" />
                <asp:BoundField DataField="NAMA" HeaderText="NAMA" SortExpression="NAMA" />
                <asp:BoundField DataField="Dept" HeaderText="Dept" SortExpression="Dept" />
                <asp:BoundField DataField="RosterCode" HeaderText="RosterCode" 
                    SortExpression="RosterCode" />
                <asp:BoundField DataField="Harike7" HeaderText="Harike7" ReadOnly="True" 
                    SortExpression="Harike7" />
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
            SelectCommand="SELECT Nrp, NAMA, Dept, RosterCode, RTRIM(Harike7) AS Harike7 FROM Karyawan WHERE (Dept = @Dept)"
            
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
                <asp:Parameter Name="Dept" />
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
    </form>
</body>
</html>
