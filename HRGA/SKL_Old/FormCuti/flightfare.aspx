<%@ Page Language="VB" Debug="true"  AutoEventWireup="false" CodeFile="flightfare.aspx.vb" Inherits="flightfare" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    	<script src="GridViewHelper.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
            DataSourceID="SqlDataSource1" Width="100%">
            <Columns>
                <asp:CommandField ButtonType="Image" CancelImageUrl="~/Images/Cancel.gif" DeleteImageUrl="~/Images/Delete.gif"
                    EditImageUrl="~/Images/Edit.gif" ShowDeleteButton="True" ShowEditButton="True"
                    UpdateImageUrl="~/Images/Update.gif" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="ID" />
                <asp:BoundField DataField="NomorST" HeaderText="NomorST" SortExpression="NomorST"
                    Visible="False" />
                <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
                <asp:BoundField DataField="Umur" HeaderText="Umur" SortExpression="Umur" />
                <asp:BoundField DataField="Tanggal" HeaderText="Tanggal" SortExpression="Tanggal" />
                <asp:BoundField DataField="Dari_Ke" HeaderText="Dari_Ke" SortExpression="Dari_Ke" />
                <asp:BoundField DataField="Keterangan" HeaderText="Keterangan" SortExpression="Keterangan" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
            DeleteCommand="DELETE FROM [tblFlight] WHERE [ID] = @ID" InsertCommand="INSERT INTO [tblFlight] ([NomorST], [Nama], [Umur], [Tanggal], [Dari_Ke], [Keterangan]) VALUES (@NomorST, @Nama,@Umur, @Tanggal, @Dari_Ke, @Keterangan)"
            SelectCommand="SELECT [ID], [NomorST], [Nama], [Umur], [Tanggal], [Dari_Ke], [Keterangan] FROM [tblFlight] WHERE [NomorST] = @Nomor UNION &#13;&#10;SELECT '0' AS [ID], '0' AS  [NomorST], '' AS  [Nama],'' AS  [Umur],   Getdate() AS [Tanggal],  '' AS [Dari_Ke], '' AS  [Keterangan] FROM [tblFlight] ORDER BY [ID] DESC"
            UpdateCommand="UPDATE [tblFlight] SET  [Nama] = @Nama, [Umur] = @Umur, [Tanggal] = @Tanggal, [Dari_Ke] = @Dari_Ke, [Keterangan] = @Keterangan WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Nama" Type="String" />
                <asp:Parameter Name="Umur" />
                <asp:Parameter Name="Tanggal" Type="DateTime" />
                <asp:Parameter Name="Dari_Ke" Type="String" />
                <asp:Parameter Name="Keterangan" Type="String" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="NomorST" Type="String" />
                <asp:Parameter Name="Nama" Type="String" />
                <asp:Parameter Name="Umur" />
                <asp:Parameter Name="Tanggal" Type="DateTime" />
                <asp:Parameter Name="Dari_Ke" Type="String" />
                <asp:Parameter Name="Keterangan" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="lblNomor" Name="Nomor" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        &nbsp;<asp:Label ID="lblNomor" runat="server" Text="ADRO/HRP/07/0002/SC"></asp:Label></div>
    </form>
        <script language="javascript" type="text/javascript">
		GridViewHelper.Init(document.all.GridView2, 100,0);
	</script>
</body>
</html>
