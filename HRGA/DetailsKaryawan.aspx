<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DetailsKaryawan.aspx.vb" Inherits="HRGA_DetailsKaryawan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
            DeleteCommand="DELETE FROM [tblKaryawan] WHERE [Nrp] = @Nrp" InsertCommand="INSERT INTO [tblKaryawan] ([Nrp], [Nama], [StatusKawin], [Agama], [Pendidikan], [AlamatTinggal], [Jamsostek], [TglPensiun], [Golongan], [Jabatan], [TglMutasi], [StatusKeluarga], [StatusBawaKeluarga], [TglBawaKeluarga], [Departemen], [Telepon], [Lokasi], [SisaCutiPeriode1], [SisaCutiPeriode2], [SisaCutiBesar], [OnSite], [Rekening], [StatusPekerjaan], [RewardSarana]) VALUES (@Nrp, @Nama, @StatusKawin, @Agama, @Pendidikan, @AlamatTinggal, @Jamsostek, @TglPensiun, @Golongan, @Jabatan, @TglMutasi, @StatusKeluarga, @StatusBawaKeluarga, @TglBawaKeluarga, @Departemen, @Telepon, @Lokasi, @SisaCutiPeriode1, @SisaCutiPeriode2, @SisaCutiBesar, @OnSite, @Rekening, @StatusPekerjaan, @RewardSarana)"
            SelectCommand="SELECT [Nrp], [Nama], [StatusKawin], [Agama], [Pendidikan], [AlamatTinggal], [Jamsostek], [TglPensiun], [Golongan], [Jabatan], [TglMutasi], [StatusKeluarga], [StatusBawaKeluarga], [TglBawaKeluarga], [Departemen], [Telepon], [Lokasi], [SisaCutiPeriode1], [SisaCutiPeriode2], [SisaCutiBesar], [OnSite], [Rekening], [StatusPekerjaan], [RewardSarana] FROM [tblKaryawan] WHERE ([Nrp] = @Nrp)"
            UpdateCommand="UPDATE [tblKaryawan] SET [Nama] = @Nama, [StatusKawin] = @StatusKawin, [Agama] = @Agama, [Pendidikan] = @Pendidikan, [AlamatTinggal] = @AlamatTinggal, [Jamsostek] = @Jamsostek, [TglPensiun] = @TglPensiun, [Golongan] = @Golongan, [Jabatan] = @Jabatan, [TglMutasi] = @TglMutasi, [StatusKeluarga] = @StatusKeluarga, [StatusBawaKeluarga] = @StatusBawaKeluarga, [TglBawaKeluarga] = @TglBawaKeluarga, [Departemen] = @Departemen, [Telepon] = @Telepon, [Lokasi] = @Lokasi, [SisaCutiPeriode1] = @SisaCutiPeriode1, [SisaCutiPeriode2] = @SisaCutiPeriode2, [SisaCutiBesar] = @SisaCutiBesar, [OnSite] = @OnSite, [Rekening] = @Rekening, [StatusPekerjaan] = @StatusPekerjaan, [RewardSarana] = @RewardSarana WHERE [Nrp] = @Nrp">
            <DeleteParameters>
                <asp:Parameter Name="Nrp" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Nama" Type="String" />
                <asp:Parameter Name="StatusKawin" Type="String" />
                <asp:Parameter Name="Agama" Type="String" />
                <asp:Parameter Name="Pendidikan" Type="String" />
                <asp:Parameter Name="AlamatTinggal" Type="String" />
                <asp:Parameter Name="Jamsostek" Type="String" />
                <asp:Parameter Name="TglPensiun" Type="DateTime" />
                <asp:Parameter Name="Golongan" Type="String" />
                <asp:Parameter Name="Jabatan" Type="String" />
                <asp:Parameter Name="TglMutasi" Type="DateTime" />
                <asp:Parameter Name="StatusKeluarga" Type="String" />
                <asp:Parameter Name="StatusBawaKeluarga" Type="Boolean" />
                <asp:Parameter Name="TglBawaKeluarga" Type="DateTime" />
                <asp:Parameter Name="Departemen" Type="String" />
                <asp:Parameter Name="Telepon" Type="String" />
                <asp:Parameter Name="Lokasi" Type="String" />
                <asp:Parameter Name="SisaCutiPeriode1" Type="Int32" />
                <asp:Parameter Name="SisaCutiPeriode2" Type="Int32" />
                <asp:Parameter Name="SisaCutiBesar" Type="Int32" />
                <asp:Parameter Name="OnSite" Type="Boolean" />
                <asp:Parameter Name="Rekening" Type="String" />
                <asp:Parameter Name="StatusPekerjaan" Type="String" />
                <asp:Parameter Name="RewardSarana" Type="Boolean" />
                <asp:Parameter Name="Nrp" Type="String" />
            </UpdateParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="Nrp" QueryStringField="nrp" Type="String" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="Nrp" Type="String" />
                <asp:Parameter Name="Nama" Type="String" />
                <asp:Parameter Name="StatusKawin" Type="String" />
                <asp:Parameter Name="Agama" Type="String" />
                <asp:Parameter Name="Pendidikan" Type="String" />
                <asp:Parameter Name="AlamatTinggal" Type="String" />
                <asp:Parameter Name="Jamsostek" Type="String" />
                <asp:Parameter Name="TglPensiun" Type="DateTime" />
                <asp:Parameter Name="Golongan" Type="String" />
                <asp:Parameter Name="Jabatan" Type="String" />
                <asp:Parameter Name="TglMutasi" Type="DateTime" />
                <asp:Parameter Name="StatusKeluarga" Type="String" />
                <asp:Parameter Name="StatusBawaKeluarga" Type="Boolean" />
                <asp:Parameter Name="TglBawaKeluarga" Type="DateTime" />
                <asp:Parameter Name="Departemen" Type="String" />
                <asp:Parameter Name="Telepon" Type="String" />
                <asp:Parameter Name="Lokasi" Type="String" />
                <asp:Parameter Name="SisaCutiPeriode1" Type="Int32" />
                <asp:Parameter Name="SisaCutiPeriode2" Type="Int32" />
                <asp:Parameter Name="SisaCutiBesar" Type="Int32" />
                <asp:Parameter Name="OnSite" Type="Boolean" />
                <asp:Parameter Name="Rekening" Type="String" />
                <asp:Parameter Name="StatusPekerjaan" Type="String" />
                <asp:Parameter Name="RewardSarana" Type="Boolean" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4"
            DataKeyNames="Nrp" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
            Height="50px" Width="489px">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
            <EditRowStyle BackColor="#2461BF" />
            <RowStyle BackColor="#EFF3FB" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <Fields>
                <asp:BoundField DataField="Nrp" HeaderText="Nrp" ReadOnly="True" SortExpression="Nrp" />
                <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
                <asp:BoundField DataField="StatusKawin" HeaderText="StatusKawin" SortExpression="StatusKawin" />
                <asp:BoundField DataField="Agama" HeaderText="Agama" SortExpression="Agama" />
                <asp:BoundField DataField="Pendidikan" HeaderText="Pendidikan" SortExpression="Pendidikan" />
                <asp:BoundField DataField="AlamatTinggal" HeaderText="AlamatTinggal" SortExpression="AlamatTinggal" />
                <asp:BoundField DataField="Jamsostek" HeaderText="Jamsostek" SortExpression="Jamsostek" />
                <asp:BoundField DataField="TglPensiun" HeaderText="TglPensiun" SortExpression="TglPensiun" />
                <asp:BoundField DataField="Golongan" HeaderText="Golongan" SortExpression="Golongan" />
                <asp:BoundField DataField="Jabatan" HeaderText="Jabatan" SortExpression="Jabatan" />
                <asp:BoundField DataField="TglMutasi" HeaderText="TglMutasi" SortExpression="TglMutasi" />
                <asp:BoundField DataField="StatusKeluarga" HeaderText="StatusKeluarga" SortExpression="StatusKeluarga" />
                <asp:CheckBoxField DataField="StatusBawaKeluarga" HeaderText="StatusBawaKeluarga"
                    SortExpression="StatusBawaKeluarga" />
                <asp:BoundField DataField="TglBawaKeluarga" HeaderText="TglBawaKeluarga" SortExpression="TglBawaKeluarga" />
                <asp:BoundField DataField="Departemen" HeaderText="Departemen" SortExpression="Departemen" />
                <asp:BoundField DataField="Telepon" HeaderText="Telepon" SortExpression="Telepon" />
                <asp:BoundField DataField="Lokasi" HeaderText="Lokasi" SortExpression="Lokasi" />
                <asp:BoundField DataField="SisaCutiPeriode1" HeaderText="SisaCutiPeriode1" SortExpression="SisaCutiPeriode1" />
                <asp:BoundField DataField="SisaCutiPeriode2" HeaderText="SisaCutiPeriode2" SortExpression="SisaCutiPeriode2" />
                <asp:BoundField DataField="SisaCutiBesar" HeaderText="SisaCutiBesar" SortExpression="SisaCutiBesar" />
                <asp:CheckBoxField DataField="OnSite" HeaderText="OnSite" SortExpression="OnSite" />
                <asp:BoundField DataField="Rekening" HeaderText="Rekening" SortExpression="Rekening" />
                <asp:BoundField DataField="StatusPekerjaan" HeaderText="StatusPekerjaan" SortExpression="StatusPekerjaan" />
                <asp:CheckBoxField DataField="RewardSarana" HeaderText="RewardSarana" SortExpression="RewardSarana" />
            </Fields>
            <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:DetailsView>
    
    </div>
    </form>
</body>
</html>
