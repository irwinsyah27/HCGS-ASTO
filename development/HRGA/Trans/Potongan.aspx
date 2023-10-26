<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Potongan.aspx.vb" Inherits="HRGA_Trans_Potongan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script src="GridViewHelper.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label8" runat="server" Text="Nrp :" Width="64px"></asp:Label><asp:TextBox
            ID="txtNrp" runat="server" AutoPostBack="True"></asp:TextBox>
            <asp:GridView ID="GridView2"
                runat="server" AutoGenerateColumns="False" BackColor="#CCCCFF" BorderStyle="Solid"
                BorderWidth="1px" CellSpacing="1" DataKeyNames="ID" DataSourceID="SqlDataSource1"
                Font-Size="Small" ForeColor="#333333" GridLines="None" ShowFooter="True">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                <Columns>
                    <asp:CommandField ButtonType="Image" CancelImageUrl="Images/Cancel.gif" DeleteImageUrl="Images/Delete.gif"
                        EditImageUrl="Images/Edit.gif" ShowDeleteButton="True" ShowEditButton="True"
                        UpdateImageUrl="Images/Update.gif" />
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                        SortExpression="ID" Visible="False" />
                    <asp:BoundField DataField="NoUrut" HeaderText="No" ReadOnly="True" SortExpression="NoUrut">
                        <HeaderStyle Width="20px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Nilai" HeaderText="Nilai" SortExpression="Nilai" />
                    <asp:BoundField DataField="Kode" HeaderText="Kode" SortExpression="Kode" />
                    <asp:BoundField DataField="Keterangan" HeaderText="Keterangan" SortExpression="Keterangan" />
                </Columns>
                <RowStyle BackColor="#EFF3FB" />
                <EditRowStyle BorderColor="Blue" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
            DeleteCommand="DELETE FROM [tblTransaksi] WHERE [ID] = @ID" InsertCommand="INSERT INTO [tblTransaksi] ([Tgl],[Kode], [Nilai], [Keterangan], [Nrp]) VALUES (Getdate(), @Kode, @Nilai, @Keterangan, @Nrp)"
            SelectCommand="SELECT ID, (SELECT COUNT(ID) AS Expr1 FROM tblTransaksi AS x WHERE (ID <= y.ID) AND (Nrp = @Nrp)) AS NoUrut, Tgl, Kode, Nilai, Keterangan, Nrp FROM tblTransaksi AS y WHERE (Nrp = @Nrp) UNION SELECT '0' AS ID, NULL AS NoUrut, '' AS Tgl,'' As Kode, 0 AS Nilai, '' AS Keterangan, '' AS Nrp FROM tblTransaksi ORDER BY ID"
            UpdateCommand="UPDATE [tblTransaksi] SET [Nilai]= @Nilai,   [Keterangan] = @Keterangan WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Nilai" />
                <asp:Parameter Name="Keterangan" Type="String" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="txtNrp" Name="Nrp" PropertyName="Text" Type="String" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="Kode" />
                <asp:Parameter Name="Nilai" Type="DateTime" />
                <asp:Parameter Name="Keterangan" Type="String" />
                <asp:ControlParameter ControlID="txtNrp" Name="Nrp" PropertyName="Text" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
    <script language="javascript" type="text/javascript">
		GridViewHelper.Init(document.all.GridView2, 100,0);
	</script>
</body>
</html>
