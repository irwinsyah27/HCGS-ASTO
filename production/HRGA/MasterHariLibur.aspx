<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MasterHariLibur.aspx.vb" Inherits="HRGA_MasterHariLibur" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Tabel Hari Libur</title>
    <script src="GridViewHelper.js" type="text/javascript"></script>
    <link href="GridViewHelper.css" rel="STYLESHEET" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div><fieldset style="width: 272px">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="14pt" Text="Tabel Hari Libur"
            Width="473px"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource1"
            ForeColor="#333333" GridLines="None" Width="474px">
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:CommandField ButtonType="Image" CancelImageUrl="~/Images/Cancel.gif" DeleteImageUrl="~/Images/Delete.gif" EditImageUrl="~/Images/Edit.gif" SelectImageUrl="~/Images/Plus.gif" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="false" UpdateImageUrl="~/Images/Update.gif">
				    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
				    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
			    </asp:CommandField>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True"
                    SortExpression="Id" />
                <asp:BoundField DataField="Tanggal" HeaderText="Tanggal" SortExpression="Tanggal" />
                <asp:BoundField DataField="Keterangan" HeaderText="Keterangan" SortExpression="Keterangan" />
            </Columns>
            <RowStyle BackColor="#E3EAEB" />
            <EditRowStyle BackColor="#7C6F57" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
            DeleteCommand="DELETE FROM [tblHariLibur] WHERE [Id] = @Id" InsertCommand="INSERT INTO [tblHariLibur] ([Tanggal], [Keterangan]) VALUES (@Tanggal, @Keterangan)"
            SelectCommand="SELECT [Id], [Tanggal], [Keterangan] FROM [tblHariLibur] &#13;&#10;UNION&#13;&#10;SELECT '0' AS [Id], NULL AS [Tanggal],NULL AS [Keterangan] FROM [tblHariLibur] " UpdateCommand="UPDATE [tblHariLibur] SET [Tanggal] = @Tanggal, [Keterangan] = @Keterangan WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Tanggal" Type="DateTime" />
                <asp:Parameter Name="Keterangan" Type="String" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="Tanggal" Type="DateTime" />
                <asp:Parameter Name="Keterangan" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
    </fieldset>
    </div>
    </form>
    <script language="javascript" type="text/javascript">
		GridViewHelper.Init(document.all.GridView1, 800,120);
	</script>
</body>
</html>
