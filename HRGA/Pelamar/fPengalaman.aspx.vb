Imports System.Data
Imports System.Data.SqlClient
'Imports System.Web.Mail
Partial Class _Default
    Inherits System.Web.UI.Page
    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CariLamaran()
    End Sub

    Public EditIndex As Integer = -1

    Protected Sub GridView2_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridPengalaman.RowCreated
        If e.Row.RowType = DataControlRowType.Header Or e.Row.RowIndex.ToString < 0 Then
        Else
            Dim KeyValue As String = Me.GridPengalaman.DataKeys(e.Row.RowIndex).Value.ToString

            If KeyValue = "0" And EditIndex = -1 Then
                e.Row.Attributes.Add("isadd", "1")

            End If
        End If
    End Sub

    Protected Sub GridView2_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridPengalaman.RowEditing
        EditIndex = e.NewEditIndex
        
        Dim X As String = GridPengalaman.DataKeys(e.NewEditIndex).Value.ToString
        If X = "0" Then

            'MsgBox("1 " & GridView2.DataKeys(e.NewEditIndex).Value.ToString)

        Else
            'e.Cancel = True
            'MsgBox("2 " & GridView2.Rows(e.NewEditIndex).Cells(3).Text)
            'MsgBox("2 " & GridView2.SelectedRow.Cells(1).Text.ToString)
        End If
    End Sub

    Protected Sub GridView2_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GridPengalaman.RowUpdated

        Dim N As String = e.Keys.Item(0).ToString

        Deskripsi = e.NewValues.Item(0).ToString
        BidangKerja = e.NewValues.Item(1).ToString
        Posisi = e.NewValues.Item(2).ToString
        LamaKerja = e.NewValues.Item(3).ToString
        Keterangan = e.NewValues.Item(4).ToString

        If N = "0" Then
            'MsgBox("Simpan data baru..")
            insPengalaman()
        End If

    End Sub

    Dim Deskripsi As String
    Dim BidangKerja As String
    Dim Posisi As String
    Dim LamaKerja As String
    Dim Keterangan As String

    Sub insPengalaman()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Insert Into tblPelamar_Pengalaman " _
                            & "([KodeLamaran]" _
                            & ",[Deskripsi]" _
                            & ",[BidangKerja]" _
                            & ",[Posisi]" _
                            & ",[LamaKerja]" _
                            & ",[Keterangan]" _
                    & ") values (" _
                            & "@KodeLamaran" _
                            & ",@Deskripsi" _
                            & ",@BidangKerja" _
                            & ",@Posisi" _
                            & ",@LamaKerja" _
                            & ",@Keterangan" _
                            & ")"

            .Parameters.Add("@KodeLamaran", SqlDbType.Int)
            .Parameters.Add("@Deskripsi", SqlDbType.VarChar, 100)
            .Parameters.Add("@BidangKerja", SqlDbType.VarChar, 50)
            .Parameters.Add("@Posisi", SqlDbType.VarChar, 50)
            .Parameters.Add("@LamaKerja", SqlDbType.VarChar, 20)
            .Parameters.Add("@Keterangan", SqlDbType.VarChar, 30)

            .Parameters("@KodeLamaran").Value = CInt(Me.lblNomor.Text)
            .Parameters("@Deskripsi").Value = Deskripsi
            .Parameters("@BidangKerja").Value = BidangKerja
            .Parameters("@Posisi").Value = Posisi
            .Parameters("@LamaKerja").Value = LamaKerja
            .Parameters("@Keterangan").Value = Keterangan

            .ExecuteNonQuery()
        End With
    End Sub

    Sub CariLamaran()

        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim cmd1 As SqlClient.SqlCommand = Nothing
        Dim dr As SqlDataReader
        Dim nomor As Integer

        cmd = New SqlClient.SqlCommand
        cmd1 = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd1
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Select Top 1 KodeLamaran From tblPelamar Order By KodeLamaran Desc"
            dr = .ExecuteReader
        End With
        dr.Read()
        nomor = dr.Item(0).ToString
        con.Close()

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Select * From tblPelamar where KodeLamaran= @KodeLamaran"

            .Parameters.Add("@KodeLamaran", SqlDbType.Int)
            .Parameters("@KodeLamaran").Value = nomor

            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Me.lblNomor.Text = dr.Item("KodeLamaran").ToString
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
            Me.GridPengalaman.Visible = True
        Else
            Me.lblNomor.Text = ""
            Me.LblNama.Text = ""
            Me.LblAlamat.Text = ""
            Me.LblJK.Text = ""
            Me.LblTempatLahir.Text = ""
            Me.LblTglLahir.Text = ""
            LblGolonganDarah.Text = ""
            LblStatusKawin.Text = ""
            LblKota.Text = ""
            LblAgama.Text = ""
            LblJenjang.Text = ""
            LblSekolah.Text = ""
            LblJurusan.Text = ""
            LblAkreditasi.Text = ""
            LblIPK.Text = ""
            LblThnLulus.Text = ""
            Lbltelp.Text = ""
            LblHP.Text = ""
            Me.GridPengalaman.Visible = False
        End If
    End Sub

End Class
