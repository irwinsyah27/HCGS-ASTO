<%@ Page Language="VB" Debug="true" MasterPageFile="~/HRGA/Trans/MasterTrans.master" AutoEventWireup="false" CodeFile="Transaksi2.aspx.vb" Inherits="HRGA_Trans_Transaksi2" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="1" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="width: 803px; background-color: #99ccff">
                &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Surat Tugas "
                    Width="152px"></asp:Label>
                <asp:TextBox ID="txtNomor" runat="server" AutoPostBack="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 803px">
                <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4"
                    DataKeyNames="NomorST" DataSourceID="SqlDataSource2" Font-Size="Small" ForeColor="#333333"
                    GridLines="None" Height="50px" Width="100%">
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
                        <asp:BoundField DataField="tglST" HeaderText="Tanggal ST" SortExpression="tglST" />
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
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="#CCCCFF"
                    BorderStyle="Solid" BorderWidth="1px" CellSpacing="1" DataKeyNames="ID" DataSourceID="SqlDataSource1"
                    Font-Size="Small" ForeColor="#333333" GridLines="None" ShowFooter="True" Width="100%">
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
                        <asp:TemplateField HeaderText="Tgl" SortExpression="Tgl" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Tgl") %>' Width="120px"></asp:TextBox><a
                                    href="javascript:;" onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=GridView2$ctl02$TextBox1','PopupClass','width=215,height=195,left=330,top=300')"><img
                                        id="IMG1" runat="server" align="absMiddle" border="0" height="20" src="Images/Calendar.png"
                                        visible="true" width="20"></a>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Tgl") %>' Width="150px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="160px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nilai" SortExpression="Nilai">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Nilai") %>' Width="70px"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                            <HeaderStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Nilai") %>' Width="70px"></asp:Label>
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
                        <asp:TemplateField HeaderText="Kode" SortExpression="Kode">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataKode" DataTextField="Keterangan"
                                    DataValueField="Kode" SelectedValue='<%# Bind("Kode") %>'>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataKode" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                                    SelectCommand="SELECT [Kode],[Keterangan] FROM [tblKodeTransaksi] Where [Kode] Not In ('C','D','G','P') UNION SELECT '' As [Kode],'' As [Keterangan] From [tblKodeTransaksi] &#13;&#10;">
                                </asp:SqlDataSource>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Kode") %>'></asp:Label>
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
                    SelectCommand="SELECT [ID]&#13;&#10;&#9;, (SELECT count([id]) FROM tblTransaksi AS x WHERE x.[id] <= y.[id] and x.NomorST=@NomorST) AS NoUrut&#13;&#10;&#9;, [Tgl],[Hotel], [UPD], [Lainlain], [Nilai], [Keterangan], [Nrp],[Kode] FROM [tblTransaksi] y WHERE ([NomorST] = @NomorST)&#13;&#10;UNION&#13;&#10;SELECT '0' As [ID],NULL AS NoUrut,'' As  [Tgl], 0 As [Hotel], 0 As [UPD], 0 As [Lainlain], 0 As  [Nilai], ''As [Keterangan], '' As [Nrp],'' As [Kode] FROM [tblTransaksi] ORDER BY [ID] &#13;&#10;"
                    UpdateCommand="UPDATE [tblTransaksi] SET [Nilai] = @Nilai, [Keterangan] = @Keterangan, [Kode] = @Kode WHERE [ID] = @ID">
                    <DeleteParameters>
                        <asp:Parameter Name="ID" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Nilai" />
                        <asp:Parameter Name="Keterangan" Type="String" />
                        <asp:Parameter Name="Kode" />
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
                            <asp:Label ID="Label8" runat="server" Font-Bold="False" Font-Size="11pt" Text="Jumlah Pengeluaran" Visible="False"></asp:Label></td>
                        <td align="right" style="width: 30%; height: 19px">
                            <asp:Label ID="txtPengeluaran" runat="server" Font-Bold="False" Font-Size="11pt" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 70%; height: 19px">
                            <asp:Label ID="Label9" runat="server" Font-Bold="False" Font-Size="11pt" Text="Jumlah Uang Muka" Visible="False"></asp:Label></td>
                        <td align="right" style="width: 30%; height: 19px">
                            <asp:Label ID="txtUangMuka" runat="server" Font-Bold="False" Font-Size="11pt" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 70%">
                            <asp:Label ID="Label10" runat="server" Font-Bold="False" Font-Size="11pt" Text="Uang Muka Lebih/Kurang" Visible="False"></asp:Label></td>
                        <td align="right" style="width: 30%">
                            <asp:Label ID="txtSisa" runat="server" Font-Bold="False" Font-Size="11pt" Visible="False"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

