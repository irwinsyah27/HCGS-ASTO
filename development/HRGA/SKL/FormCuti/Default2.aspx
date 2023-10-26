<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default2.aspx.vb" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
            DataSourceID="SqlDataSourceFlight">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True"  />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="ID" />
                <asp:BoundField DataField="NomorST" HeaderText="NomorST" SortExpression="NomorST" />
                <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
                <asp:BoundField DataField="Tanggal" HeaderText="Tanggal" SortExpression="Tanggal" />
                <asp:BoundField DataField="Dari_Ke" HeaderText="Dari_Ke" SortExpression="Dari_Ke" />
                <asp:BoundField DataField="Keterangan" HeaderText="Keterangan" SortExpression="Keterangan" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceFlight" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
            DeleteCommand="DELETE FROM [tblFlight] WHERE [ID] = @ID" InsertCommand="INSERT INTO [tblFlight] ([NomorST], [Nama], [Tanggal], [Dari_Ke], [Keterangan]) VALUES (@NomorST, @Nama, @Tanggal, @Dari_Ke, @Keterangan)"
            SelectCommand="SELECT [ID], [NomorST], [Nama], [Tanggal], [Dari_Ke], [Keterangan] FROM [tblFlight]"
            UpdateCommand="UPDATE [tblFlight] SET [NomorST] = @NomorST, [Nama] = @Nama, [Tanggal] = @Tanggal, [Dari_Ke] = @Dari_Ke, [Keterangan] = @Keterangan WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="NomorST" Type="String" />
                <asp:Parameter Name="Nama" Type="String" />
                <asp:Parameter Name="Tanggal" Type="DateTime" />
                <asp:Parameter Name="Dari_Ke" Type="String" />
                <asp:Parameter Name="Keterangan" Type="String" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="NomorST" Type="String" />
                <asp:Parameter Name="Nama" Type="String" />
                <asp:Parameter Name="Tanggal" Type="DateTime" />
                <asp:Parameter Name="Dari_Ke" Type="String" />
                <asp:Parameter Name="Keterangan" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:Label ID="Message" runat="server" Text="Label"></asp:Label></div>
    </form>
</body>
</html>
