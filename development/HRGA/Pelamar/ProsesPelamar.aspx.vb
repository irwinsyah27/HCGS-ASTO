Imports System.Data
Imports System.Data.SqlClient
'Imports System.Web.Mail
Partial Class _ProsesPelamar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./Pelamar/ProsesPelamar.aspx?n=" & Request.QueryString("n").ToString
            Response.Redirect("../login.aspx")
        End If
        CariLamaran()
    End Sub
    Sub CariLamaran()

        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim cmd1 As SqlClient.SqlCommand = Nothing
        Dim dr As SqlDataReader

        cmd = New SqlClient.SqlCommand
        cmd1 = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Select  KodeLamaran, TglInput, InputBy, Nama, TempatLahir, TglLahir, JenisKelamin, Agama, GolonganDarah, StatusKawin, AlamatTinggal, Kota, TeleponRumah, Handphone, Pendidikan, Jenjang, Jurusan, Akreditasi, IPK, ThnLulus, InputPosisiBy, TglInputPosisi, KodePosisi, Site, Dept, Posisi, Referensi, Resource, Status From tblPelamar where KodePosisi= @KodePosisi"

            .Parameters.Add("@KodePosisi", SqlDbType.VarChar, 20)
            .Parameters("@KodePosisi").Value = Request.QueryString("n").ToString

            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Me.lblNomor.Text = dr.Item("KodePosisi").ToString
            Me.LblNama.Text = dr.Item("Nama").ToString
            Me.LblAlamat.Text = dr.Item("AlamatTinggal").ToString
            Me.LblJK.Text = dr.Item("JenisKelamin").ToString
            Me.LblTempatLahir.Text = dr.Item("TempatLahir").ToString
            Me.LblTglLahir.Text = Left(dr.Item("TglLahir").ToString, 2) & "-" & Mid(dr.Item("TglLahir").ToString, 3, 2) & "-" & Right(dr.Item("TglLahir").ToString, 4)
            LblGolonganDarah.Text = dr.Item("GolonganDarah").ToString
            LblStatusKawin.Text = dr.Item("StatusKawin").ToString
            LblKota.Text = dr.Item("Kota").ToString
            LblAgama.Text = dr.Item("Agama").ToString
            LblJenjang.Text = dr.Item("Jenjang").ToString
            LblSekolah.Text = dr.Item("Pendidikan").ToString
            LblJurusan.Text = dr.Item("Jurusan").ToString
            LblAkreditasi.Text = dr.Item("Akreditasi").ToString
            LblIPK.Text = dr.Item("IPK").ToString
            LblThnLulus.Text = dr.Item("ThnLulus").ToString
            Lbltelp.Text = dr.Item("TeleponRumah").ToString
            LblHP.Text = dr.Item("Handphone").ToString
            Me.LblSite.Text = dr.Item("Site").ToString
            Me.LblDept.Text = dr.Item("Dept").ToString
            Me.LblJabatan.Text = dr.Item("Posisi").ToString
            Me.LblReff.Text = dr.Item("Referensi").ToString
            Me.LblResource.Text = dr.Item("Resource").ToString
            Me.LblInput.Text = dr.Item("InputPosisiBy").ToString
        Else
        End If

    End Sub

End Class
