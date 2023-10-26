Imports System.Data
Imports System.Data.SqlClient

Partial Class _fTugas
    Inherits System.Web.UI.Page
    Dim TotLapangan As Integer
    Dim TotTahunan As Integer
    Dim TotBesar As Integer
    Dim TotPerjalanan As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./cuti/ftugas.aspx"
            Response.Redirect("../login.aspx")
        End If
		
		If InStr(1, Session("jabatan").ToString, "PERSONNEL SITE OFFICER") = 0 And InStr(1, Session("jabatan").ToString, "PERSONNEL OFFICER") = 0 And InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") = 0 And InStr(1, Session("ndPosisi").ToString, "PERSONNEL SITE OFFICER") = 0 And InStr(1, Session("ndPosisi").ToString, "PERSONNEL OFFICER") = 0 And InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") = 0 Then
            Dim csname1 As String = "PopupScript"
            Dim cstype As Type = Me.GetType()

            Dim cs As ClientScriptManager = Page.ClientScript

            If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

                Dim cstext1 As String = "alert('Anda tidak punya access sebagai Personnel Officer...    ');"
                cstext1 += "location='../login.aspx';"
                cs.RegisterStartupScript(cstype, csname1, cstext1, True)

            End If
        End If
		
        If Me.txtNrp.Text <> "" Then
            If Session("Nomor") = "" Then
                Me.btSave.Visible = True
            End If
            Dim con As SqlClient.SqlConnection = Nothing
            Dim cmd As SqlClient.SqlCommand = Nothing
            Dim dr As SqlDataReader

            cmd = New SqlClient.SqlCommand

            Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
            con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

            con.Open()
            With cmd
                .Connection = con
                .CommandType = CommandType.Text
                .CommandText = "Select Nrp, Nama, Jabatan, Golongan, Departemen, StatusPenerimaan, StatusKawin, StatusBawaKeluarga, AlamatTinggal, Telepon  From tblKaryawan Where Nrp = @Nrp "

                .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
                .Parameters("@Nrp").Value = txtNrp.Text
                dr = .ExecuteReader
            End With
            If dr.Read = True Then
                Me.lblNama.Text = dr.Item("Nama").ToString
                Me.lblJabatan.Text = dr.Item("Jabatan").ToString & " / " & dr.Item("Departemen").ToString '& " / " & dr.Item("Golongan").ToString
                Me.lblStatusPenerimaan.Text = dr.Item("StatusPenerimaan").ToString
                Me.lblStatusKawin.Text = dr.Item("StatusKawin").ToString
                Me.lblAlamatdiSite.Text = dr.Item("AlamatTinggal").ToString
                Me.lblNoTelp.Text = dr.Item("Telepon").ToString

                If dr.Item("StatusBawaKeluarga").ToString = True Then
                    Me.lblBawaKeluarga.Text = "Ya"
                Else
                    Me.lblBawaKeluarga.Text = "Tidak"
                End If

            Else
                Me.lblNama.Text = ""
                Me.lblJabatan.Text = ""
                Me.lblStatusPenerimaan.Text = ""
                Me.lblStatusKawin.Text = ""
                Me.lblBawaKeluarga.Text = ""
            End If

            CutiTahunan()
            PeriodeTugas()

        End If
    End Sub

    Sub CutiTahunan()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim dr As SqlDataReader

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_sisa_cuti"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = txtNrp.Text
            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Me.lblSisaCuti1.Text = dr.Item("SisaCuti1").ToString
            Me.lblSisaCuti2.Text = dr.Item("SisaCuti2").ToString
            Me.lblCutiBesar.Text = dr.Item("SisaCutiBesar").ToString
            'Me.lblTotal.Text = dr.Item("Total").ToString

        End If
    End Sub

    Sub PeriodeTugas()
        'If Me.ckTahunan.Checked = True Then
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim dr As SqlDataReader

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_dinas_terakhir"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = txtNrp.Text
            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Me.lblPeriodeTugas.Text = Format(CDate(dr.Item("Awal").ToString), "dd MMM yyyy") & " s/d " & Format(CDate(dr.Item("Akhir").ToString), "dd MMM yyyy")
        Else
            Me.lblPeriodeTugas.Text = ""
        End If

    End Sub

    Protected Sub btSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btSave.Click
        Session("Nrp") = Me.txtNrp.Text
        Session("Tanggal") = Format(Date.Today.Date, "dd MMM yyyy")

        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Insert Into tblSutu " _
                            & "([Nrp]" _
                            & ",[NomorST]" _
                            & ",[tglST]" _
                            & ",[Tujuan]" _
                            & ",[Keperluan]" _
                            & ",[Penginapan]" _
                            & ",[Awal]" _
                            & ",[Akhir]" _
                            & ",[Transport]" _
                            & ",[Uang_Muka]" _
                            & ",[Keterangan]" _
                            & ",[DibuatOleh]" _
                    & ") values (" _
                            & "@Nrp" _
                            & ",@NomorST" _
                            & ",Getdate()" _
                            & ",@Tujuan" _
                            & ",@Keperluan" _
                            & ",@Penginapan" _
                            & ",@Awal" _
                            & ",@Akhir" _
                            & ",@Transport" _
                            & ",@UangMuka" _
                            & ",@Keterangan" _
                            & ",@DibuatOleh" _
                            & ")"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 50)
            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)
            .Parameters.Add("@Tujuan", SqlDbType.VarChar, 20)
            .Parameters.Add("@Keperluan", SqlDbType.VarChar, 30)
            .Parameters.Add("@Penginapan", SqlDbType.VarChar, 50)
            .Parameters.Add("@Awal", SqlDbType.DateTime)
            .Parameters.Add("@Akhir", SqlDbType.DateTime)
            .Parameters.Add("@Transport", SqlDbType.VarChar, 20)
            .Parameters.Add("@UangMuka", SqlDbType.Money)
            .Parameters.Add("@Keterangan", SqlDbType.VarChar, 200)
            .Parameters.Add("@DibuatOleh", SqlDbType.NVarChar, 10)

            .Parameters("@Nrp").Value = Me.txtNrp.Text
            .Parameters("@NomorST").Value = "BARU"
            .Parameters("@Tujuan").Value = Me.txtTujuan.Text
            .Parameters("@Keperluan").Value = "TUGAS"
            .Parameters("@Penginapan").Value = Me.txtPenginapan.Text
            .Parameters("@Awal").Value = Me.txtAwal.Text
            .Parameters("@Akhir").Value = Me.txtAkhir.Text
            .Parameters("@Transport").Value = Me.txtTransport.Text
            .Parameters("@UangMuka").Value = Me.txtUangMuka.Text
            .Parameters("@Keterangan").Value = Me.txtKeterangan.Text
            .Parameters("@DibuatOleh").Value = Session("userid").ToString

            .ExecuteNonQuery()
        End With

        CariSC()

        ' Define the name and type of the client scripts on the page.
        Dim csname1 As String = "PopupScript"
        Dim csname2 As String = "ButtonClickScript"
        Dim cstype As Type = Me.GetType()

        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript

        ' Check to see if the startup script is already registered.
        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

            Dim cstext1 As String = "alert('Surat Tugas telah tersimpan...');"
            'cstext1 += "self.close();"
            'cstext1 += "location='lstTugas.aspx'"
            cs.RegisterStartupScript(cstype, csname1, cstext1, True)

        End If

    End Sub

    Sub CariSC()

        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim dr As SqlDataReader

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Select * From tblSutu Where Nrp = @Nrp And Cast(Month(TglST)As Varchar) + '/' + " & _
                           "Cast(Day(TglST)As Varchar) + '/' + " & _
                           "Cast(Year(TglST)As Varchar) " & _
                           "= Cast(Month(@Tanggal)As Varchar) + '/' + " & _
                           "Cast(Day(@Tanggal)As Varchar) + '/' + " & _
                           "Cast(Year(@Tanggal)As Varchar) "

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters.Add("@Tanggal", SqlDbType.DateTime)
            .Parameters("@Nrp").Value = Session("Nrp").ToString
            .Parameters("@Tanggal").Value = Session("Tanggal").ToString

            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Session("Nomor") = dr.Item("NomorST").ToString
            Me.lblNomor.Text = Session("Nomor")
            Me.Panel1.Visible = True
            Me.Panel1.Enabled = True
            Me.btSave.Visible = False
        Else

            'Response.Redirect("fCuti2.aspx")

        End If
    End Sub


    Public EditIndex As Integer = -1

    Protected Sub GridView2_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowCreated
        If e.Row.RowType = DataControlRowType.Header Or e.Row.RowIndex.ToString < 0 Then
        Else
            Dim KeyValue As String = Me.GridView2.DataKeys(e.Row.RowIndex).Value.ToString

            If KeyValue = "0" And EditIndex = -1 Then
                e.Row.Attributes.Add("isadd", "1")

            End If
        End If
    End Sub

    Protected Sub GridView2_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView2.RowEditing
        EditIndex = e.NewEditIndex
        'Dim X As String = GridView2.Rows(e.NewEditIndex).Cells(3).Text
        ''Dim X As String = GridView2.DataKeys(0).Value.ToString
        'If X = "D" Then

        '    e.Cancel = True
        '    'MsgBox("1 " & GridView2.Rows(e.NewEditIndex).Cells(3).Text)
        '    MsgBox("1 " & GridView2.DataKeys(0).Value.ToString)
        'Else

        '    'MsgBox("2 " & GridView2.Rows(e.NewEditIndex).Cells(3).Text)
        '    'MsgBox("2 " & GridView2.SelectedRow.Cells(1).Text.ToString)
        'End If


        Dim X As String = GridView2.DataKeys(e.NewEditIndex).Value.ToString
        If X = "0" Then

            'MsgBox("1 " & GridView2.DataKeys(e.NewEditIndex).Value.ToString)

        Else
            'e.Cancel = True
            'MsgBox("2 " & GridView2.Rows(e.NewEditIndex).Cells(3).Text)
            'MsgBox("2 " & GridView2.SelectedRow.Cells(1).Text.ToString)
        End If
    End Sub

    Protected Sub GridView2_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GridView2.RowUpdated

        Dim N As String = e.Keys.Item(0).ToString

        Nama = e.NewValues.Item(0).ToString
        Umur = e.NewValues.Item(1).ToString
        Tanggal = e.NewValues.Item(2).ToString
        Dari_Ke = e.NewValues.Item(3).ToString
        Keterangan = e.NewValues.Item(4).ToString

        If N = "0" Then
            'MsgBox("Simpan data baru..")
            insFlight()
        End If

    End Sub

    Dim Nama As String
    Dim Umur As String
    Dim Tanggal As String
    Dim Dari_Ke As String
    Dim Keterangan As String

    Sub insFlight()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Insert Into tblFlight " _
                            & "([NomorST]" _
                            & ",[Nama]" _
                            & ",[Umur]" _
                            & ",[Tanggal]" _
                            & ",[Dari_Ke]" _
                            & ",[Keterangan]" _
                    & ") values (" _
                            & "@NomorST" _
                            & ",@Nama" _
                            & ",@Umur" _
                            & ",@Tanggal" _
                            & ",@Dari_Ke" _
                            & ",@Keterangan" _
                            & ")"

            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)
            .Parameters.Add("@Nama", SqlDbType.VarChar, 30)
            .Parameters.Add("@Umur", SqlDbType.VarChar, 2)
            .Parameters.Add("@Tanggal", SqlDbType.DateTime)
            .Parameters.Add("@Dari_Ke", SqlDbType.VarChar, 50)
            .Parameters.Add("@Keterangan", SqlDbType.VarChar, 30)

            .Parameters("@NomorST").Value = Me.lblNomor.Text
            .Parameters("@Nama").Value = Nama
            .Parameters("@Umur").Value = Umur
            .Parameters("@Tanggal").Value = Tanggal
            .Parameters("@Dari_Ke").Value = Dari_Ke
            .Parameters("@Keterangan").Value = Keterangan

            .ExecuteNonQuery()
        End With
    End Sub
End Class
