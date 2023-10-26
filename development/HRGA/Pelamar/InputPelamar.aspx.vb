Imports System.Data
Imports System.Data.SqlClient
'Imports System.Web.Mail
Partial Class _hrga_inputPelamar
    Inherits System.Web.UI.Page
    Dim TotLapangan As Integer
    Dim TotTahunan As Integer
    Dim TotBesar As Integer
    Dim TotPerjalanan As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btSave.Click
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim tgl, bln, thn As String
        Dim TGLLahir As String

        tgl = ddlTgl.SelectedValue.ToString
        bln = DDLBulan.SelectedValue.ToString
        thn = DDLTahun.SelectedValue.ToString
        TGLLahir = tgl + bln + thn
        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Insert Into [Persis].[dbo].[tblPelamar] " _
                            & "([TglInput]" _
                            & ",[Nama]" _
                            & ",[TempatLahir]" _
                            & ",[TglLahir]" _
                            & ",[JenisKelamin]" _
                            & ",[GolonganDarah]" _
                            & ",[StatusKawin]" _
                            & ",[AlamatTinggal]" _
                            & ",[Kota]" _
                            & ",[Agama]" _
                            & ",[Jenjang]" _
                            & ",[Pendidikan]" _
                            & ",[Jurusan]" _
                            & ",[Akreditasi]" _
                            & ",[IPK]" _
                            & ",[ThnLulus]" _
                            & ",[TeleponRumah]" _
                            & ",[Handphone]" _
                            & ",[Status]" _
                            & ",[InputBy]" _
                        & ") values (" _
                            & "Getdate()" _
                            & ",@Nama" _
                            & ",@TempatLahir" _
                            & ",@TglLahir" _
                            & ",@JenisKelamin" _
                            & ",@GolonganDarah" _
                            & ",@StatusKawin" _
                            & ",@AlamatTinggal" _
                            & ",@Kota" _
                            & ",@Agama" _
                            & ",@Jenjang" _
                            & ",@Pendidikan" _
                            & ",@Jurusan" _
                            & ",@Akreditasi" _
                            & ",@IPK" _
                            & ",@ThnLulus" _
                            & ",@TeleponRumah" _
                            & ",@Handphone" _
                            & ",'Open'" _
                            & ",@InputBy" _
                            & ")"

            .Parameters.Add("@Nama", SqlDbType.VarChar, 100)
            .Parameters.Add("@TempatLahir", SqlDbType.VarChar, 50)
            .Parameters.Add("@TglLahir", SqlDbType.VarChar, 8)
            .Parameters.Add("@JenisKelamin", SqlDbType.Char, 1)
            .Parameters.Add("@GolonganDarah", SqlDbType.VarChar, 2)
            .Parameters.Add("@StatusKawin", SqlDbType.VarChar, 1)
            .Parameters.Add("@AlamatTinggal", SqlDbType.VarChar, 500)
            .Parameters.Add("@Kota", SqlDbType.VarChar, 20)
            .Parameters.Add("@Agama", SqlDbType.VarChar, 10)
            .Parameters.Add("@Jenjang", SqlDbType.VarChar, 5)
            .Parameters.Add("@Pendidikan", SqlDbType.VarChar, 80)
            .Parameters.Add("@Jurusan", SqlDbType.VarChar, 80)
            .Parameters.Add("@Akreditasi", SqlDbType.VarChar, 1)
            .Parameters.Add("@IPK", SqlDbType.Int)
            .Parameters.Add("@ThnLulus", SqlDbType.VarChar, 4)
            .Parameters.Add("@TeleponRumah", SqlDbType.VarChar, 20)
            .Parameters.Add("@Handphone", SqlDbType.VarChar, 20)
            .Parameters.Add("@InputBy", SqlDbType.VarChar, 10)

            .Parameters("@Nama").Value = Me.txtNama.Text
            .Parameters("@TempatLahir").Value = Me.txtTempatLahir.Text
            .Parameters("@TglLahir").Value = TGLLahir
            .Parameters("@JenisKelamin").Value = Me.DDLJk.SelectedValue.ToString
            .Parameters("@GolonganDarah").Value = Me.DDLGolDarah.SelectedValue.ToString
            .Parameters("@StatusKawin").Value = Me.DDLStatusKawin.SelectedValue.ToString
            .Parameters("@AlamatTinggal").Value = Me.TxtAlamat.Text
            .Parameters("@Kota").Value = Me.TxtKota.Text
            .Parameters("@Agama").Value = Me.DDLAgama.SelectedItem.Text
            .Parameters("@Jenjang").Value = Me.DDLJenjang.SelectedItem.Text
            .Parameters("@Pendidikan").Value = Me.txtSekolah.Text
            .Parameters("@Jurusan").Value = Me.TxtJurusan.Text
            .Parameters("@Akreditasi").Value = Me.TxtAkreditasi.Text
            .Parameters("@IPK").Value = CInt(Me.TxtIPK.Text)
            .Parameters("@ThnLulus").Value = Me.DDLThnLulus.Text
            .Parameters("@TeleponRumah").Value = Me.TxtTelponRumah.Text
            .Parameters("@Handphone").Value = Me.TxtHP.Text
            .Parameters("@InputBy").Value = "Imam" 'Session("userid").ToString


            .ExecuteNonQuery()
            con.Close()

        End With

        '=========pupup=====================
        Dim csname1 As String = "PopupScript"
        Dim csname2 As String = "ButtonClickScript"
        Dim cstype As Type = Me.GetType()

        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript

        ' Check to see if the startup script is already registered.
        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

            Dim cstext1 As String = "var answer = confirm('Data Pelamar telah disimpan, click OK jika perlu Input Pengalaman   ');"
            cstext1 += "if (answer){"
            'cstext1 += "window.open('flightfare.aspx','PopupClass','width=600,height=500,left=200,top=30,scrollbars=no,copyhistory=yes,resizable = yes ')"
            cstext1 += "window.location = 'fPengalaman.aspx';"
            cstext1 += "} else {"
            cstext1 += "self.close(); }"
            'cstext1 += "window.location = 'fCuti1.aspx';}"
            cs.RegisterStartupScript(cstype, csname1, cstext1, True)

        End If

    End Sub


End Class
