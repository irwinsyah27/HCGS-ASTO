<%@ Page Language="VB" Debug="TRUE"  AutoEventWireup="false" CodeFile="deklast.aspx.vb" Inherits="HRGA_Trans_deklast" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script src="GridViewHelper.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="1" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 803px; background-color: #99ccff">
                    &nbsp;<asp:Label ID="Label1" runat="server" Text="Surat Tugas " Width="152px" Font-Bold="True"></asp:Label>
        <asp:TextBox ID="txtNomor" runat="server" AutoPostBack="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 803px">
                    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4"
                        DataKeyNames="NomorST" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None"
                        Height="50px" Width="100%" Font-Size="Small">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                        <EditRowStyle BackColor="#2461BF" />
                        <RowStyle BackColor="#EFF3FB" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <Fields>
                            <asp:BoundField DataField="Nrp" HeaderText="Nrp" SortExpression="Nrp">
                                <HeaderStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
                            <asp:BoundField DataField="Jabatan" HeaderText="Jabatan" SortExpression="Jabatan" />
                            <asp:BoundField DataField="Departemen" HeaderText="Departemen" SortExpression="Departemen" />
                            <asp:BoundField DataField="StatusBawaKeluarga" HeaderText="StatusBawaKeluarga" SortExpression="StatusBawaKeluarga" />
                            <asp:BoundField DataField="tglST" HeaderText="tglST" SortExpression="tglST" />
                            <asp:BoundField DataField="Tujuan" HeaderText="Tujuan" SortExpression="Tujuan" />
                            <asp:BoundField DataField="Keperluan" HeaderText="Keperluan" SortExpression="Keperluan" />
                            <asp:BoundField DataField="Penginapan" HeaderText="Penginapan" SortExpression="Penginapan" />
                            <asp:BoundField DataField="Awal" HeaderText="Awal" SortExpression="Awal" />
                            <asp:BoundField DataField="Akhir" HeaderText="Akhir" SortExpression="Akhir" />
                            <asp:BoundField DataField="Transport" HeaderText="Transport" SortExpression="Transport" />
                            <asp:BoundField DataField="Uang_Muka" HeaderText="Uang_Muka" SortExpression="Uang_Muka" />
                            <asp:BoundField DataField="Keterangan" HeaderText="Keterangan" SortExpression="Keterangan" />
                        </Fields>
                        <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:DetailsView>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="100%" BorderStyle="Solid" BorderWidth="1px" CellSpacing="1" BackColor="#CCCCFF" ShowFooter="True" Font-Size="Small">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True"  ButtonType=Image DeleteImageUrl="Images/Delete.gif" EditImageUrl="Images/Edit.gif" CancelImageUrl="Images/Cancel.gif" UpdateImageUrl="Images/Update.gif"/>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="ID" Visible="False" />
                <asp:BoundField DataField="NoUrut" HeaderText="No" ReadOnly="True" SortExpression="NoUrut" >
                    <HeaderStyle Width="20px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Tgl" SortExpression="Tgl" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Tgl") %>' Width =120px></asp:TextBox><A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=GridView2$ctl02$TextBox1','PopupClass','width=215,height=195,left=330,top=300')"
		                            href="javascript:;"><IMG src="Images/Calendar.png" border="0" id="IMG1" runat="server" align="absMiddle" height="20" width="20" visible="true"></A>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Tgl") %>' Width="150px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="160px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lokasi" SortExpression="Lokasi">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Lokasi") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Lokasi") %>' Width="100px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hotel" SortExpression="Hotel">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Hotel") %>' Width="70px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                    <HeaderStyle Width="100px" />
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Hotel") %>' Width="70px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UPD" SortExpression="UPD">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("UPD") %>' Width="70px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                    <HeaderStyle Width="100px" />
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("UPD") %>' Width="70px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lainlain" SortExpression="Lainlain">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Lainlain") %>' Width="70px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                    <HeaderStyle Width="100px" />
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Lainlain") %>' Width="70px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total" SortExpression="Nilai">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Enabled="False" Text='<%# Bind("Nilai") %>'
                            Width="80px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle BackColor="#FFE0C0" HorizontalAlign="Right" />
                    <HeaderStyle Width="100px" />
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Nilai") %>' Width="80px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Keterangan" SortExpression="Keterangan">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Keterangan") %>' Width="98%"></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle Width="100%" />
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Keterangan") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle BackColor="#EFF3FB" />
            <EditRowStyle BorderColor="Blue" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
            DeleteCommand="DELETE FROM [tblTransaksi] WHERE [ID] = @ID" InsertCommand="INSERT INTO [tblTransaksi] ([Tgl],[Lokasi],[Hotel],[UPD],[Lainlain] [Nilai], [Keterangan], [Nrp]) VALUES (@Tgl,@Lokasi,@Hotel,@UPD,@Lainlain, @Nilai, @Keterangan, @Nrp)"
            SelectCommand="SELECT [ID]&#13;&#10;&#9;, (SELECT count([id]) FROM tblTransaksi AS x WHERE x.[id] <= y.[id] and x.NomorST=@NomorST) AS NoUrut&#13;&#10;&#9;, [Tgl],[Lokasi], [Hotel], [UPD], [Lainlain], [Nilai]=[Hotel]+[UPD]+[Lainlain], [Keterangan], [Nrp] FROM [tblTransaksi] y WHERE ([NomorST] = @NomorST)&#13;&#10;UNION&#13;&#10;SELECT '0' As [ID],NULL AS NoUrut,'' As  [Tgl], '' As [Lokasi], 0 As [Hotel], 0 As [UPD], 0 As [Lainlain], 0 As  [Nilai], ''As [Keterangan], '' As [Nrp] FROM [tblTransaksi] ORDER BY [ID] &#13;&#10;"
            UpdateCommand="UPDATE [tblTransaksi] SET [Lokasi] = @Lokasi, [Hotel] = @Hotel,[UPD] = @UPD,[Lainlain] = @Lainlain,   [Keterangan] = @Keterangan WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Lokasi" />
                <asp:Parameter Name="Hotel" Type="Decimal" />
                <asp:Parameter Name="UPD" />
                <asp:Parameter Name="Lainlain" />
                <asp:Parameter Name="Keterangan" Type="String" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="txtNomor" Name="NomorST" PropertyName="Text" Type="String" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="Tgl" Type="DateTime" />
                <asp:Parameter Name="Lokasi" />
                <asp:Parameter Name="Hotel" />
                <asp:Parameter Name="UPD" />
                <asp:Parameter Name="Lainlain" />
                <asp:Parameter Name="Nilai" Type="Decimal" />
                <asp:Parameter Name="Keterangan" Type="String" />
                <asp:Parameter Name="Nrp" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                        SelectCommand="SELECT tblSutu.Nrp, tblKaryawan.Nama, tblKaryawan.Jabatan, tblKaryawan.Departemen, StatusBawaKeluarga=Case StatusBawaKeluarga When 1 Then 'YA' ELSE 'TIDAK' END , tblSutu.tglST, tblSutu.Tujuan, tblSutu.Keperluan, tblSutu.Penginapan, tblSutu.Awal, tblSutu.Akhir, tblSutu.Transport, tblSutu.Uang_Muka, tblSutu.Keterangan, tblSutu.NomorST FROM tblSutu INNER JOIN tblKaryawan ON tblSutu.Nrp = tblKaryawan.Nrp WHERE (tblSutu.NomorST = @NomorST)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtNomor" Name="NomorST" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td align="right" style="width: 70%; height: 19px">
                                <asp:Label ID="Label8" runat="server" Font-Bold="False" Font-Size="11pt" Text="Jumlah Pengeluaran"></asp:Label></td>
                            <td align="right" style="width: 30%; height: 19px">
                                <asp:Label ID="txtPengeluaran" runat="server" Font-Bold="False" Font-Size="11pt"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%; height: 19px">
                                <asp:Label ID="Label9" runat="server" Font-Bold="False" Font-Size="11pt" Text="Jumlah Uang Muka"></asp:Label></td>
                            <td align="right" style="width: 30%; height: 19px">
                                <asp:Label ID="txtUangMuka" runat="server" Font-Bold="False" Font-Size="11pt"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 70%">
                                <asp:Label ID="Label10" runat="server" Font-Bold="False" Font-Size="11pt" Text="Uang Muka Lebih/Kurang"></asp:Label></td>
                            <td align="right" style="width: 30%">
                                <asp:Label ID="txtSisa" runat="server" Font-Bold="False" Font-Size="11pt"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        &nbsp;<br />
        &nbsp;<br />
    
    </div>
    </form>
        <script language="javascript" type="text/javascript">
		GridViewHelper.Init(document.all.GridView2, 100,0);
	</script>
</body>
</html>
