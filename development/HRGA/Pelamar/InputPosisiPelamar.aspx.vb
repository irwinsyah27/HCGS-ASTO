Imports System.Data
Imports System.Data.SqlClient
'Imports System.Web.Mail
Partial Class _fCuti1
    Inherits System.Web.UI.Page
    Dim TotLapangan As Integer
    Dim TotTahunan As Integer
    Dim TotBesar As Integer
    Dim TotPerjalanan As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./Pelamar/InputPosisiPelamar.aspx?n=" & Request.QueryString("n").ToString
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
            .CommandText = "Select  KodeLamaran, TglInput, InputBy, Nama, TempatLahir, TglLahir, JenisKelamin, Agama, GolonganDarah, StatusKawin, AlamatTinggal, Kota, TeleponRumah, Handphone, Pendidikan, Jenjang, Jurusan, Akreditasi, IPK, ThnLulus, InputPosisiBy, TglInputPosisi, KodePosisi, Site, Dept, Posisi, Referensi, Resource, Status From tblPelamar where KodeLamaran= @KodeLamaran"

            .Parameters.Add("@KodeLamaran", SqlDbType.Int)
            .Parameters("@KodeLamaran").Value = Request.QueryString("n").ToString

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
            ''====== cek input posisi 
            If dr.Item("KodePosisi").ToString <> "" Then
                Me.PanelPosisi.Visible = False
                Me.PanelPosisi1.Visible = True
                Me.LblSite.Text = dr.Item("Site").ToString
                Me.LblDept.Text = dr.Item("Dept").ToString
                Me.LblJabatan.Text = dr.Item("Posisi").ToString
                Me.LblReff.Text = dr.Item("Referensi").ToString
                Me.LblResource.Text = dr.Item("Resource").ToString
                Me.LblInput.Text = dr.Item("InputPosisiBy").ToString
            Else
                Me.PanelPosisi.Visible = True
                Me.PanelPosisi1.Visible = False
            End If
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
        End If
        
    End Sub
    
    Protected Sub btSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btSave.Click
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim cmd1 As SqlClient.SqlCommand = Nothing
        Dim cmd3 As SqlClient.SqlCommand = Nothing
        Dim jabat As String
        Dim S, D As String
        S = Mid(DDLSite.SelectedValue.ToString, 5, 2)
        D = DDLDept.SelectedValue.ToString

        If DDLDept.SelectedItem.Text = "Others" Then
            jabat = txtJabatan.Text
        Else
            jabat = DDLJabatan.SelectedItem.Text
        End If

        cmd = New SqlClient.SqlCommand
        cmd1 = New SqlClient.SqlCommand
        cmd3 = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)
        Dim dr As SqlDataReader
        Dim bln, th1, nomer As String

        con.Open()
        With cmd1
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Select Top 1 KodePosisi From tblPelamar where Site=@Site AND Dept=@Dept Order By KodePosisi Desc"

            .Parameters.Add("@Site", SqlDbType.VarChar, 50)
            .Parameters.Add("@Dept", SqlDbType.VarChar, 50)
            .Parameters("@Site").Value = DDLSite.SelectedValue.ToString
            .Parameters("@Dept").Value = DDLDept.SelectedValue.ToString
            dr = .ExecuteReader
        End With
        dr.Read()
        If dr.Read = False Then
            nomer = "xxxxxxxxxxxxxxxx0000"
        Else
            nomer = dr.Item(0).ToString
        End If
        nomer = CInt(Right(nomer, 4)) + 1
        bln = Month(Now)
        th1 = Year(Now)

        If Len(nomer) = 1 Then
            nomer = S & "/" & D & "/" & th1 & "/" & bln & "/000" & nomer
        ElseIf Len(nomer) = 2 Then
            nomer = S & "/" & D & "/" & th1 & "/" & bln & "/00" & nomer
        ElseIf Len(nomer) = 3 Then
            nomer = S & "/" & D & "/" & th1 & "/" & bln & "/0" & nomer
        ElseIf Len(nomer) = 4 Then
            nomer = S & "/" & D & "/" & th1 & "/" & bln & "/" & nomer
        End If
        con.Close()

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Update [Persis].[dbo].[tblPelamar] set " _
                            & "[TglInputPosisi]= Getdate()" _
                            & ",[KodePosisi]=@KodePosisi" _
                            & ",[Site]=@Site" _
                            & ",[Dept]=@Dept" _
                            & ",[Posisi]=@Posisi" _
                            & ",[Referensi]=@Referensi" _
                            & ",[Resource]=@Resource" _
                            & ",[Status]='On Process'" _
                            & ",[InputPosisiBy]=@InputPosisiBy where Kodelamaran = @nomor"

            .Parameters.Add("@nomor", SqlDbType.Int)
            .Parameters.Add("@KodePosisi", SqlDbType.VarChar, 20)
            .Parameters.Add("@Site", SqlDbType.VarChar, 50)
            .Parameters.Add("@Dept", SqlDbType.VarChar, 50)
            .Parameters.Add("@Posisi", SqlDbType.VarChar, 50)
            .Parameters.Add("@Referensi", SqlDbType.VarChar, 50)
            .Parameters.Add("@Resource", SqlDbType.VarChar, 50)
            .Parameters.Add("@InputPosisiBy", SqlDbType.VarChar, 10)

            .Parameters("@nomor").Value = CInt(Me.lblNomor.Text)
            .Parameters("@KodePosisi").Value = nomer
            .Parameters("@Site").Value = DDLSite.SelectedValue.ToString
            .Parameters("@Dept").Value = DDLDept.SelectedValue.ToString
            .Parameters("@Posisi").Value = jabat
            .Parameters("@Referensi").Value = Me.TxtReff.Text
            .Parameters("@Resource").Value = Me.TxtResources.Text
            .Parameters("@InputPosisiBy").Value = Session("userid").ToString

            .ExecuteNonQuery()
            con.Close()
        End With

        con.Open()
        With cmd3
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Insert Into [Persis].[dbo].[tblPelamar_Proses] ([KodePosisi],[Status]) values (@KodePosisi,'HR Officer')"

            .Parameters.Add("@KodePosisi", SqlDbType.VarChar, 20)
            .Parameters("@KodePosisi").Value = nomer

            .ExecuteNonQuery()
            con.Close()
        End With
        '=========pupup=====================
        Dim csname1 As String = "PopupScript"
        Dim csname2 As String = "ButtonClickScript"
        Dim cstype As Type = Me.GetType()

        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript
        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
            Dim cstext1 As String = "alert('Kandidat telah diposisikan ... ');"
            cstext1 += "self.close();"
            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
        End If

    End Sub

    Protected Sub DDLDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLDept.SelectedIndexChanged
        If DDLDept.SelectedItem.Text = "Others" Then
            txtJabatan.Visible = True
            DDLJabatan.Visible = False
        Else
            txtJabatan.Visible = False
            DDLJabatan.Visible = True
        End If
    End Sub
End Class
