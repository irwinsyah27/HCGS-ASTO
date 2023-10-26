<%@ Page Language="VB" Debug="true" AutoEventWireup="false" CodeFile="rCuti2.aspx.vb" Inherits="rCuti2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4"
            DataKeyNames="NomorST" DataSourceID="SqlDataCuti" ForeColor="#333333" GridLines="None"
            Height="50px" Style="border-right: #3399ff 1px solid; border-top: #3399ff 1px solid;
            border-left: #3399ff 1px solid; border-bottom: #3399ff 1px solid" Width="100%">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
            <EditRowStyle BackColor="InactiveCaptionText" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <Fields>
                <asp:BoundField DataField="NomorST" HeaderText="NomorST" ReadOnly="True" SortExpression="NomorST" >
                    <HeaderStyle Width="300px" />
                </asp:BoundField>
                <asp:BoundField DataField="Nrp" HeaderText="Nrp" ReadOnly="True" SortExpression="Nrp" />
                <asp:TemplateField HeaderText="Sisa Cuti Tahunan" SortExpression="SisaCuti1">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("SisaCuti1") %>'></asp:TextBox>
                        <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("SisaCuti2") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("SisaCuti1") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("SisaCuti1") %>'></asp:Label>
                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("SisaCuti2") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SisaCuti3" HeaderText="Sisa Cuti Besar" SortExpression="SisaCuti3" />
                <asp:TemplateField HeaderText="Cuti Lapangan" SortExpression="C_Lapangan">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtLapangan" runat="server" OnTextChanged="TextBox1_TextChanged" Text='<%# Bind("C_Lapangan") %>' AutoPostBack="True"></asp:TextBox>&nbsp;
                        <asp:RangeValidator ID="RangeValidator1" runat="server"
                            ErrorMessage="RangeValidator" MaximumValue="8" MinimumValue="0" Type="Integer" ControlToValidate="txtLapangan"></asp:RangeValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("C_Lapangan") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("C_Lapangan") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cuti Tahunan" SortExpression="C_Tahunan">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtTahunan" runat="server" Text='<%# Bind("C_Tahunan") %>' AutoPostBack="True" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("C_Tahunan") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("C_Tahunan") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cuti Besar" SortExpression="C_Besar">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBesar" runat="server" Text='<%# Bind("C_Besar") %>' AutoPostBack="True" OnTextChanged="txtBesar_TextChanged"></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("C_Besar") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("C_Besar") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cuti Perjalanan" SortExpression="C_Perjalanan">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPerjalanan" runat="server" Text='<%# Bind("C_Perjalanan") %>' AutoPostBack="True" OnTextChanged="txtPerjalanan_TextChanged"></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("C_Perjalanan") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("C_Perjalanan") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Awal" SortExpression="Awal">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAwal" runat="server" Text='<%# Bind("Awal") %>' AutoPostBack="True" OnTextChanged="txtAwal_TextChanged"></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Awal") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Awal") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Akhir" SortExpression="Akhir">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAkhir" runat="server" Text='<%# Bind("Akhir") %>' AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Akhir") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Akhir") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SisaCuti_Tahunan" SortExpression="SisaCuti_Tahunan">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtSisaCuti" runat="server" Text='<%# Bind("SisaCuti_Tahunan") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("SisaCuti_Tahunan") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("SisaCuti_Tahunan") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SisaCuti_Besar" HeaderText="SisaCuti_Besar" SortExpression="SisaCuti_Besar">
                    <HeaderStyle Width="296px" />
                </asp:BoundField>
                <asp:BoundField DataField="Tujuan" HeaderText="Tujuan Cuti" ReadOnly="True" SortExpression="Tujuan"
                    Visible="False" />
                <asp:BoundField DataField="AlamatCuti" HeaderText="Alamat Cuti" ReadOnly="True" SortExpression="AlamatCuti"
                    Visible="False" />
                <asp:TemplateField HeaderText="Keterangan" SortExpression="Keterangan">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Height="31px" Text='<%# Bind("Keterangan") %>'
                            TextMode="MultiLine" Width="320px"></asp:TextBox>
                        <hr />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Keterangan") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("Keterangan") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="VerifikasiHr" SortExpression="VerifikasiHr">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Height="31px" Text='<%# Bind("VerifikasiHr") %>'
                            TextMode="MultiLine" Width="320px"></asp:TextBox><br />
                        Check jika anda menyetujui
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("VerifikasiHr") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("VerifikasiHr") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CheckBoxField DataField="PersetujuanHr" SortExpression="PersetujuanHr" />
                <asp:CommandField ShowEditButton="True" />
            </Fields>
            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" Width="200px" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataCuti" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
            DeleteCommand="DELETE FROM [tblSutu] WHERE [NomorST] = @NomorST" InsertCommand="INSERT INTO [tblSutu] ([NomorST], [Nrp], [Awal], [Akhir], [C_Lapangan], [C_Tahunan], [C_Besar], [C_Perjalanan]) VALUES (@NomorST, @Nrp, @Awal, @Akhir, @C_Lapangan, @C_Tahunan, @C_Besar, @C_Perjalanan)"
            SelectCommand="SELECT NomorST, Nrp, Awal, Akhir, C_Lapangan, C_Tahunan, C_Besar, C_Perjalanan, SisaCuti_Tahunan, Tujuan, AlamatCuti, Keterangan, PeriodeTugas, Uang_Muka, SisaCuti1, SisaCuti2, SisaCuti3, SisaCuti_Besar, HR_Officer, VerifikasiHr, PersetujuanHr, TglVerifikasi FROM tblSutu WHERE (NomorST = @NomorST)"
            UpdateCommand="UPDATE [tblSutu] SET [Awal] = @Awal, [Akhir] = @Akhir, [C_Lapangan] = @C_Lapangan, [C_Tahunan] = @C_Tahunan, [C_Besar] = @C_Besar, [C_Perjalanan] = @C_Perjalanan, [SisaCuti_Tahunan] = @SisaCuti_Tahunan,[SisaCuti_Besar] = @SisaCuti_Besar,[SisaCuti1] = @SisaCuti1,[SisaCuti2] = @SisaCuti2,[SisaCuti3] = @SisaCuti3,[Keterangan] = @Keterangan,[VerifikasiHr] = @VerifikasiHr,[PersetujuanHr] = @PersetujuanHr,[HR_Officer] = @HR_Officer,[TglVerifikasi] = Getdate() WHERE [NomorST] = @NomorST">
            <DeleteParameters>
                <asp:Parameter Name="NomorST" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="NomorST" Type="String" />
                <asp:Parameter Name="Nrp" Type="String" />
                <asp:Parameter Name="Awal" Type="DateTime" />
                <asp:Parameter Name="Akhir" Type="DateTime" />
                <asp:Parameter Name="SisaCuti1" />
                <asp:Parameter Name="SisaCuti2" />
                <asp:Parameter Name="SisaCuti3" />
                <asp:Parameter Name="C_Lapangan" Type="Int32" />
                <asp:Parameter Name="C_Tahunan" Type="Int32" />
                <asp:Parameter Name="C_Besar" Type="Int32" />
                <asp:Parameter Name="C_Perjalanan" Type="Int32" />
                <asp:Parameter Name="SisaCuti_Tahunan" />
                <asp:Parameter Name="SisaCuti_Besar" />
                <asp:Parameter Name="Keterangan" />
                <asp:Parameter Name="VerifikasiHr" />
                <asp:Parameter Name="PersetujuanHr" />
                <asp:SessionParameter Name="HR_Officer" SessionField="userid" />
            </UpdateParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="NomorST" QueryStringField="n" Type="String" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="NomorST" Type="String" />
                <asp:Parameter Name="Nrp" Type="String" />
                <asp:Parameter Name="Awal" Type="DateTime" />
                <asp:Parameter Name="Akhir" Type="DateTime" />
                <asp:Parameter Name="C_Lapangan" Type="Int32" />
                <asp:Parameter Name="C_Tahunan" Type="Int32" />
                <asp:Parameter Name="C_Besar" Type="Int32" />
                <asp:Parameter Name="C_Perjalanan" Type="Int32" />
            </InsertParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
