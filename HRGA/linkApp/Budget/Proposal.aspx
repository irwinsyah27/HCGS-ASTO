<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EditKaryawan.aspx.vb" Inherits="HRGA_EditKaryawan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset style="width: 334px"><legend>Edit Karyawan </legend>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4"
            DataKeyNames="Nrp" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
            Height="50px" Width="470px">
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <CommandRowStyle BackColor="#C5BBAF" Font-Bold="True" />
            <EditRowStyle BackColor="#7C6F57" />
            <RowStyle BackColor="#E3EAEB" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <Fields>
                <asp:TemplateField HeaderText="Nrp" SortExpression="Nrp">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Nrp") %>'></asp:Label>
                        <asp:Image ID="Image1" runat="server" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1px"
                            Height="129px" ImageUrl='<%# Eval("Nrp", "photo/{0}.jpg") %>' Style="clear: none;
                            left: 0px; float: right" Width="105px" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("Nrp") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("Nrp") %>'></asp:Label><asp:Image
                            ID="Image1" runat="server" BorderColor="Blue" BorderStyle="Solid" BorderWidth="1px"
                            Height="106px" ImageUrl='<%# Eval("Nrp", "photo/{0}.jpg") %>' Style="clear: none;
                            left: 0px; float: left" Width="95px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
                <asp:BoundField DataField="TempatLahir" HeaderText="TempatLahir" SortExpression="TempatLahir" />
                <asp:BoundField DataField="TglLahir" HeaderText="TglLahir" SortExpression="TglLahir" />
                <asp:TemplateField HeaderText="JenisKelamin" SortExpression="JenisKelamin">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("JenisKelamin") %>'>
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem Selected="True">M</asp:ListItem>
                            <asp:ListItem>F</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("JenisKelamin") %>'>
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Selected="True">M</asp:ListItem>
                            <asp:ListItem>F</asp:ListItem>
                        </asp:DropDownList>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("JenisKelamin") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="GolonganDarah" SortExpression="GolonganDarah">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList2" runat="server" SelectedValue='<%# Bind("GolonganDarah") %>'>
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem Selected="True">O</asp:ListItem>
                            <asp:ListItem>A</asp:ListItem>
                            <asp:ListItem>B</asp:ListItem>
                            <asp:ListItem>AB</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        &nbsp;<asp:DropDownList ID="DropDownList2" runat="server" SelectedValue='<%# Bind("GolonganDarah") %>'>
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem Selected="True">O</asp:ListItem>
                            <asp:ListItem>A</asp:ListItem>
                            <asp:ListItem>B</asp:ListItem>
                            <asp:ListItem>AB</asp:ListItem>
                        </asp:DropDownList>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("GolonganDarah") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="StatusKawin" SortExpression="StatusKawin">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList3" runat="server" SelectedValue='<%# Bind("StatusKawin") %>'>
                            <asp:ListItem Selected="True"></asp:ListItem>
                            <asp:ListItem>M</asp:ListItem>
                            <asp:ListItem>S</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        &nbsp;<asp:DropDownList ID="DropDownList3" runat="server" SelectedValue='<%# Bind("StatusKawin") %>'>
                            <asp:ListItem Selected="True"></asp:ListItem>
                            <asp:ListItem>M</asp:ListItem>
                            <asp:ListItem>S</asp:ListItem>
                        </asp:DropDownList>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("StatusKawin") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DPA" HeaderText="DPA" SortExpression="DPA" />
                <asp:BoundField DataField="TglMasukPama" HeaderText="TglMasukPama" SortExpression="TglMasukPama" />
                <asp:BoundField DataField="TglPensiun" HeaderText="TglPensiun" SortExpression="TglPensiun" />
                <asp:BoundField DataField="Golongan" HeaderText="Golongan" SortExpression="Golongan" />
                <asp:BoundField DataField="Agama" HeaderText="Agama" SortExpression="Agama" />
                <asp:BoundField DataField="Pendidikan" HeaderText="Pendidikan" SortExpression="Pendidikan" />
                <asp:TemplateField HeaderText="AlamatTinggal" SortExpression="AlamatTinggal">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("AlamatTinggal") %>' Width="400px"></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("AlamatTinggal") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("AlamatTinggal") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Jamsostek" HeaderText="Jamsostek" SortExpression="Jamsostek" />
                <asp:TemplateField HeaderText="Jabatan" SortExpression="Jabatan">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Jabatan") %>' Width="400px"></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Jabatan") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Jabatan") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TglMutasi" HeaderText="TglMutasi" SortExpression="TglMutasi" />
                <asp:TemplateField HeaderText="StatusKeluarga" SortExpression="StatusKeluarga">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList4" runat="server" SelectedValue='<%# Bind("StatusKeluarga") %>'>
                            <asp:ListItem Selected="True"></asp:ListItem>
                            <asp:ListItem>S/0</asp:ListItem>
                            <asp:ListItem>S/1</asp:ListItem>
                            <asp:ListItem>S/2</asp:ListItem>
                            <asp:ListItem>S/3</asp:ListItem>
                            <asp:ListItem>M/0</asp:ListItem>
                            <asp:ListItem>M/1</asp:ListItem>
                            <asp:ListItem>M/2</asp:ListItem>
                            <asp:ListItem>M/3</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        &nbsp;<asp:DropDownList ID="DropDownList4" runat="server" SelectedValue='<%# Bind("StatusKeluarga") %>'>
                            <asp:ListItem Selected="True"></asp:ListItem>
                            <asp:ListItem>S/0</asp:ListItem>
                            <asp:ListItem>S/1</asp:ListItem>
                            <asp:ListItem>S/2</asp:ListItem>
                            <asp:ListItem>S/3</asp:ListItem>
                            <asp:ListItem>M/0</asp:ListItem>
                            <asp:ListItem>M/1</asp:ListItem>
                            <asp:ListItem>M/2</asp:ListItem>
                            <asp:ListItem>M/3</asp:ListItem>
                        </asp:DropDownList>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("StatusKeluarga") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CheckBoxField DataField="StatusBawaKeluarga" HeaderText="StatusBawaKeluarga"
                    SortExpression="StatusBawaKeluarga" />
                <asp:BoundField DataField="TglBawaKeluarga" HeaderText="TglBawaKeluarga" SortExpression="TglBawaKeluarga" />
                <asp:TemplateField HeaderText="Departemen" SortExpression="Departemen">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="SqlDataDept" DataTextField="Dept"
                            DataValueField="Dept" SelectedValue='<%# Bind("Departemen") %>'>
                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataDept" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                            SelectCommand="SELECT null as  [Dept] FROM [Tbl_Dept] union SELECT [Dept] FROM [Tbl_Dept]">
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        &nbsp;<asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="SqlDataDept" DataTextField="Dept"
                            DataValueField="Dept" SelectedValue='<%# Bind("Departemen") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataDept" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                            SelectCommand="SELECT null as  [Dept] FROM [Tbl_Dept] union SELECT [Dept] FROM [Tbl_Dept]">
                        </asp:SqlDataSource>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Departemen") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="StatusPenerimaan" SortExpression="StatusPenerimaan">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList6" runat="server" SelectedValue='<%# Bind("StatusPenerimaan") %>'>
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>LOKAL</asp:ListItem>
                            <asp:ListItem Selected="True">KIRIMAN</asp:ListItem>
                            <asp:ListItem>LS</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        &nbsp;<asp:DropDownList ID="DropDownList6" runat="server" SelectedValue='<%# Bind("StatusPenerimaan") %>'>
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>LOKAL</asp:ListItem>
                            <asp:ListItem Selected="True">KIRIMAN</asp:ListItem>
                            <asp:ListItem>LS</asp:ListItem>
                        </asp:DropDownList>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("StatusPenerimaan") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Telepon" HeaderText="Telepon" SortExpression="Telepon" />
                <asp:TemplateField HeaderText="Lokasi" SortExpression="Lokasi">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList7" runat="server" SelectedValue='<%# Bind("Lokasi") %>'>
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Selected="True">KPRT</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        &nbsp;<asp:DropDownList ID="DropDownList7" runat="server" SelectedValue='<%# Bind("Lokasi") %>'>
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Selected="True">KPRT</asp:ListItem>
                        </asp:DropDownList>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("Lokasi") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SisaCutiPeriode1" HeaderText="SisaCutiPeriode1" SortExpression="SisaCutiPeriode1" />
                <asp:BoundField DataField="SisaCutiPeriode2" HeaderText="SisaCutiPeriode2" SortExpression="SisaCutiPeriode2" />
                <asp:BoundField DataField="SisaCutiBesar" HeaderText="SisaCutiBesar" SortExpression="SisaCutiBesar" />
                <asp:CheckBoxField DataField="OnSite" HeaderText="OnSite" SortExpression="OnSite" />
                <asp:TemplateField HeaderText="Company" SortExpression="Company">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList66" runat="server" SelectedValue='<%# Bind("Company") %>'>
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Selected="True">KPP</asp:ListItem>
                            <asp:ListItem>DAB</asp:ListItem>
                            <asp:ListItem>GNI</asp:ListItem>
                            <asp:ListItem>SIGAP</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        &nbsp;<asp:DropDownList ID="DropDownList67" runat="server" SelectedValue='<%# Bind("Company") %>'>
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Selected="True">KPP</asp:ListItem>
                            <asp:ListItem>DAB</asp:ListItem>
                            <asp:ListItem>GNI</asp:ListItem>
                            <asp:ListItem>SIGAP</asp:ListItem>
                        </asp:DropDownList>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Labe81" runat="server" Text='<%# Bind("Company") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Rekening" HeaderText="Rekening" SortExpression="Rekening" />
                <asp:CommandField ShowEditButton="True" ShowInsertButton="True" />
            </Fields>
            <FieldHeaderStyle BackColor="#D0D0D0" Font-Bold="True" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" VerticalAlign="Top" />
            <AlternatingRowStyle BackColor="White" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
            DeleteCommand="DELETE FROM [tblKaryawan] WHERE [Nrp] = @Nrp" InsertCommand="INSERT INTO [tblKaryawan] ([Nrp], [Nama], [TempatLahir], [TglLahir], [JenisKelamin], [GolonganDarah], [StatusKawin], [DPA], [TglMasukPama], [TglPensiun], [Golongan], [Agama], [Pendidikan], [AlamatTinggal], [Jamsostek], [Jabatan], [TglMutasi], [StatusKeluarga], [StatusBawaKeluarga], [TglBawaKeluarga], [Departemen], [StatusPenerimaan], [Telepon], [Lokasi], [SisaCutiPeriode1], [SisaCutiPeriode2], [SisaCutiBesar], [OnSite], [Company], [Rekening]) VALUES (@Nrp, @Nama, @TempatLahir, @TglLahir, @JenisKelamin, @GolonganDarah, @StatusKawin, @DPA, @TglMasukPama, @TglPensiun, @Golongan, @Agama, @Pendidikan, @AlamatTinggal, @Jamsostek, @Jabatan, @TglMutasi, @StatusKeluarga, @StatusBawaKeluarga, @TglBawaKeluarga, @Departemen, @StatusPenerimaan, @Telepon, @Lokasi, @SisaCutiPeriode1, @SisaCutiPeriode2, @SisaCutiBesar, @OnSite, @Company, @Rekening)"
            SelectCommand="SELECT [Nrp], [Nama], [TempatLahir], [TglLahir], [JenisKelamin], [GolonganDarah], [StatusKawin], [DPA], [TglMasukPama], [TglPensiun], [Golongan], [Agama], [Pendidikan], [AlamatTinggal], [Jamsostek], [Jabatan], [TglMutasi], [StatusKeluarga], [StatusBawaKeluarga], [TglBawaKeluarga], [Departemen], [StatusPenerimaan], [Telepon], [Lokasi], [SisaCutiPeriode1], [SisaCutiPeriode2], [SisaCutiBesar], [OnSite], [Company], [Rekening] FROM [tblKaryawan] WHERE ([Nrp] = @Nrp)"
            UpdateCommand="UPDATE [tblKaryawan] SET [Nama] = @Nama, [TempatLahir] = @TempatLahir, [TglLahir] = @TglLahir, [JenisKelamin] = @JenisKelamin, [GolonganDarah] = @GolonganDarah, [StatusKawin] = @StatusKawin, [DPA] = @DPA, [TglMasukPama] = @TglMasukPama, [TglPensiun] = @TglPensiun, [Golongan] = @Golongan, [Agama] = @Agama, [Pendidikan] = @Pendidikan, [AlamatTinggal] = @AlamatTinggal, [Jamsostek] = @Jamsostek, [Jabatan] = @Jabatan, [TglMutasi] = @TglMutasi, [StatusKeluarga] = @StatusKeluarga, [StatusBawaKeluarga] = @StatusBawaKeluarga, [TglBawaKeluarga] = @TglBawaKeluarga, [Departemen] = @Departemen, [StatusPenerimaan] = @StatusPenerimaan, [Telepon] = @Telepon, [Lokasi] = @Lokasi, [SisaCutiPeriode1] = @SisaCutiPeriode1, [SisaCutiPeriode2] = @SisaCutiPeriode2, [SisaCutiBesar] = @SisaCutiBesar, [OnSite] = @OnSite, [Company] = @Company, [Rekening] = @Rekening WHERE [Nrp] = @Nrp">
            <DeleteParameters>
                <asp:Parameter Name="Nrp" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Nama" Type="String" />
                <asp:Parameter Name="TempatLahir" Type="String" />
                <asp:Parameter Name="TglLahir" Type="DateTime" />
                <asp:Parameter Name="JenisKelamin" Type="String" />
                <asp:Parameter Name="GolonganDarah" Type="String" />
                <asp:Parameter Name="StatusKawin" Type="String" />
                <asp:Parameter Name="DPA" Type="String" />
                <asp:Parameter Name="TglMasukPama" Type="DateTime" />
                <asp:Parameter Name="TglPensiun" Type="DateTime" />
                <asp:Parameter Name="Golongan" Type="String" />
                <asp:Parameter Name="Agama" Type="String" />
                <asp:Parameter Name="Pendidikan" Type="String" />
                <asp:Parameter Name="AlamatTinggal" Type="String" />
                <asp:Parameter Name="Jamsostek" Type="String" />
                <asp:Parameter Name="Jabatan" Type="String" />
                <asp:Parameter Name="TglMutasi" Type="DateTime" />
                <asp:Parameter Name="StatusKeluarga" Type="String" />
                <asp:Parameter Name="StatusBawaKeluarga" Type="Boolean" />
                <asp:Parameter Name="TglBawaKeluarga" Type="DateTime" />
                <asp:Parameter Name="Departemen" Type="String" />
                <asp:Parameter Name="StatusPenerimaan" Type="String" />
                <asp:Parameter Name="Telepon" Type="String" />
                <asp:Parameter Name="Lokasi" Type="String" />
                <asp:Parameter Name="SisaCutiPeriode1" Type="Int32" />
                <asp:Parameter Name="SisaCutiPeriode2" Type="Int32" />
                <asp:Parameter Name="SisaCutiBesar" Type="Int32" />
                <asp:Parameter Name="OnSite" Type="Boolean" />
                <asp:Parameter Name="Rekening" Type="String" />
                <asp:Parameter Name="Nrp" Type="String" />
                <asp:Parameter Name="Company" Type="String" />
            </UpdateParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="Nrp" QueryStringField="nrp" Type="String" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="Nrp" Type="String" />
                <asp:Parameter Name="Nama" Type="String" />
                <asp:Parameter Name="TempatLahir" Type="String" />
                <asp:Parameter Name="TglLahir" Type="DateTime" />
                <asp:Parameter Name="JenisKelamin" Type="String" />
                <asp:Parameter Name="GolonganDarah" Type="String" />
                <asp:Parameter Name="StatusKawin" Type="String" />
                <asp:Parameter Name="DPA" Type="String" />
                <asp:Parameter Name="TglMasukPama" Type="DateTime" />
                <asp:Parameter Name="TglPensiun" Type="DateTime" />
                <asp:Parameter Name="Golongan" Type="String" />
                <asp:Parameter Name="Agama" Type="String" />
                <asp:Parameter Name="Pendidikan" Type="String" />
                <asp:Parameter Name="AlamatTinggal" Type="String" />
                <asp:Parameter Name="Jamsostek" Type="String" />
                <asp:Parameter Name="Jabatan" Type="String" />
                <asp:Parameter Name="TglMutasi" Type="DateTime" />
                <asp:Parameter Name="StatusKeluarga" Type="String" />
                <asp:Parameter Name="StatusBawaKeluarga" Type="Boolean" />
                <asp:Parameter Name="TglBawaKeluarga" Type="DateTime" />
                <asp:Parameter Name="Departemen" Type="String" />
                <asp:Parameter Name="StatusPenerimaan" Type="String" />
                <asp:Parameter Name="Telepon" Type="String" />
                <asp:Parameter Name="Lokasi" Type="String" />
                <asp:Parameter Name="SisaCutiPeriode1" Type="Int32" />
                <asp:Parameter Name="SisaCutiPeriode2" Type="Int32" />
                <asp:Parameter Name="SisaCutiBesar" Type="Int32" />
                <asp:Parameter Name="OnSite" Type="Boolean" />
                <asp:Parameter Name="Rekening" Type="String" />
                <asp:Parameter Name="Company" />
            </InsertParameters>
        </asp:SqlDataSource>
    </fieldset>
    </div>
    </form>
</body>
</html>
