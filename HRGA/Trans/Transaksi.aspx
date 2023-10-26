<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Transaksi.aspx.vb" Inherits="HRGA_Trans_Transaksi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link rel="alternate" type="application/rss+xml" title="RSS" href="/rss.xml" >
<link rel="stylesheet" type="text/css" href="css/gaga2000.css">
<link rel="stylesheet" type="text/css" href="css/niftyCor.css">
<link rel="stylesheet" type="text/css" href="css/niftyPri.css" media="print">

<SCRIPT type="text/javascript" src="css/prototyp.js"></SCRIPT>
<SCRIPT type="text/javascript" src="css/ubahgaga.js"></SCRIPT>
<SCRIPT type="text/javascript" src="css/kuki0000.js"></SCRIPT>
<SCRIPT type="text/javascript" src="css/nifty000.js"></SCRIPT>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script src="GridViewHelper.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Div2" style="margin: 0 auto; padding:0; background: #ff9900; width: 510px; ">
    <div>
        <table border="0" cellpadding="5" cellspacing="0" style="width: 100%">
            <tr>
                <td align="center" style="width: 101px; height: 27px" valign="top">
                
                        <asp:Label ID="Label6" runat="server" Text="Transaksi" Width="500px" BackColor="#FFFF80" Font-Bold="True" Font-Size="24pt"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 101px; height: 124px;" valign="top">
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Nrp :" Width="224px"></asp:Label><asp:TextBox
                        ID="txtNrp" runat="server" AutoPostBack="True" BackColor="#FFE0C0" Font-Bold="True"
                        ForeColor="#400000" Width="256px"></asp:TextBox><asp:Label ID="Label2" runat="server"
                            Font-Bold="True" Text="Nama :" Width="224px"></asp:Label><asp:TextBox ID="txtNama"
                                runat="server" AutoPostBack="True" BackColor="#FFE0C0" Font-Bold="True" ForeColor="#400000"
                                Width="256px"></asp:TextBox><asp:Label ID="Label3" runat="server" Font-Bold="True"
                                    Text="Depaertemen :" Width="224px"></asp:Label><asp:TextBox ID="txtDepartemen" runat="server"
                                        AutoPostBack="True" BackColor="#FFE0C0" Font-Bold="True" ForeColor="#400000"
                                        Width="256px"></asp:TextBox><asp:Label ID="Label4" runat="server" Font-Bold="True"
                                            Text="Status Keluarga :" Width="224px"></asp:Label><asp:TextBox ID="txtStatusKeluarga"
                                                runat="server" AutoPostBack="True" BackColor="#FFE0C0" Font-Bold="True" ForeColor="#400000"
                                                Width="256px"></asp:TextBox><asp:Label ID="Label5" runat="server" Font-Bold="True"
                                                    Text="Status Bawa Keluarga :" Width="224px"></asp:Label><asp:TextBox ID="txtStatusBawaKeluarga"
                                                        runat="server" AutoPostBack="True" BackColor="#FFE0C0" Font-Bold="True" ForeColor="#400000"
                                                        Width="256px"></asp:TextBox><br />
                </td>
            </tr>
            <tr>
                <td style="width: 101px; height: 16px">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
            DeleteCommand="DELETE FROM [tblTransaksi] WHERE [ID] = @ID" InsertCommand="INSERT INTO [tblTransaksi] ([Tgl],[Kode], [Nilai], [Keterangan], [Nrp]) VALUES (Getdate(), @Kode, @Nilai, @Keterangan, @Nrp)"
            SelectCommand="SELECT ID, (SELECT COUNT(ID) AS Expr1 FROM tblTransaksi AS x WHERE (ID <= y.ID) AND (Nrp = @Nrp And Kode Not In ('G'))) AS NoUrut, Tgl, Kode, Nilai, Keterangan, Nrp FROM tblTransaksi AS y WHERE (Nrp = @Nrp And Kode Not In ('G')) UNION SELECT '0' AS ID, NULL AS NoUrut, '' AS Tgl,'' As Kode, 0 AS Nilai, '' AS Keterangan, '' AS Nrp FROM tblTransaksi ORDER BY ID"
            UpdateCommand="UPDATE [tblTransaksi] SET [Kode]=@Kode, [Nilai]= @Nilai,   [Keterangan] = @Keterangan, [UploadOleh]=@UploadOleh WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Kode" />
                <asp:Parameter Name="Nilai" />
                <asp:Parameter Name="Keterangan" Type="String" />
                <asp:SessionParameter Name="UploadOleh" SessionField="userid" />
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
            <asp:GridView ID="GridView2"
                runat="server" AutoGenerateColumns="False" BackColor="#CCCCFF" BorderStyle="Solid"
                BorderWidth="1px" CellSpacing="1" DataKeyNames="ID" DataSourceID="SqlDataSource1"
                Font-Size="Small" ForeColor="#333333" GridLines="None" ShowFooter="True" Width="500px" AllowPaging="True">
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
                    <asp:TemplateField HeaderText="Kode" SortExpression="Kode">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("Kode") %>' DataSourceID="SqlDataKode" DataTextField="Keterangan" DataValueField="Kode">
                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataKode" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                                SelectCommand="SELECT [Kode],[Keterangan] FROM [tblKodeTransaksi] Where [Kode] Not In ('G') UNION SELECT '' As [Kode],'' As [Keterangan] From [tblKodeTransaksi] &#13;&#10;">
                            </asp:SqlDataSource>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Kode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Nilai" HeaderText="Nilai" SortExpression="Nilai" />
                    <asp:BoundField DataField="Keterangan" HeaderText="Keterangan" SortExpression="Keterangan" />
                </Columns>
                <RowStyle BackColor="#EFF3FB" />
                <EditRowStyle BorderColor="Blue" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            </td>
            </tr>
        </table>
    
    </div>
      </div>
        <br />
    </form>
    <script language="javascript" type="text/javascript">
		GridViewHelper.Init(document.all.GridView2, 100,0);
	</script>
	<script type="text/javascript">
    if(NiftyCheck()) {
	    Rounded("label#label6","all","#FF9900","#FFFF80");
	    Rounded("div#dIV2","bottom","#ffffff","#FF9900");
	    Rounded("div#dIV2","top","#ffffff","#FF9900");
    }
</script>
</body>
</html>
