Imports System.Data
Imports System.Data.SqlClient

Partial Class _dTugas
    Inherits System.Web.UI.Page
    Dim TotLapangan As Integer
    Dim TotTahunan As Integer
    Dim TotBesar As Integer
    Dim TotPerjalanan As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./cuti/dTugas.aspx?n=" & Request.QueryString("n").ToString
            Response.Redirect("../login.aspx")
        End If

        ' Define the name and type of the client scripts on the page.
        Dim csname1 As String = "PopupScript"
        Dim csname2 As String = "ButtonClickScript"
        Dim cstype As Type = Me.GetType()

        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript

        ' Check to see if the client script is already registered.
        If (Not cs.IsClientScriptBlockRegistered(cstype, csname2)) Then

            Dim cstext2 As New StringBuilder()
            cstext2.Append("<script type=text/javascript> function DoClick() {")
            cstext2.Append("window.open('rTugas.aspx?n=" & Request.QueryString("n").ToString & "','PopupClass','width=515,height=310,left=330,top=300')} </")
            cstext2.Append("script>")
            cs.RegisterClientScriptBlock(cstype, csname2, cstext2.ToString(), False)

        End If
        CariSC()

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
            .Parameters("@Nrp").Value = lblNrp.Text
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

            'If Me.txtAwal.Text <> "" Then
            '    If dr.Item("StatusBawaKeluarga").ToString = True Then
            '        Me.lblBawaKeluarga.Text = "Ya"
            '        Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(84), "dd MMM yyyy")
            '    Else
            '        Me.lblBawaKeluarga.Text = "Tidak"
            '        If dr.Item("StatusPenerimaan").ToString = "LOCAL" Then
            '            Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(84), "dd MMM yyyy")
            '            'MsgBox("1 :")
            '        ElseIf dr.Item("StatusPenerimaan").ToString = "KIRIMAN" Then
            '            If Left(dr.Item("Golongan").ToString, 1) <= 2 Then
            '                Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(84), "dd MMM yyyy")
            '                'MsgBox("2 :")
            '            ElseIf Left(dr.Item("Golongan").ToString, 1) >= 3 And Left(dr.Item("Golongan").ToString, 1) <= 4 Then
            '                Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(56), "dd MMM yyyy")
            '                'MsgBox("3 :")
            '            ElseIf Left(dr.Item("Golongan").ToString, 1) = "P" Then
            '                If Right(dr.Item("Golongan").ToString, 1) <= 4 Then
            '                    Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(84), "dd MMM yyyy")
            '                    'MsgBox("4 :")
            '                Else
            '                    Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(56), "dd MMM yyyy")
            '                    'MsgBox("5 :")
            '                End If

            '            ElseIf Left(dr.Item("Golongan").ToString, 1) = "G" Then
            '                If Right(dr.Item("Golongan").ToString, 1) <= 5 Then
            '                    Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(84), "dd MMM yyyy")
            '                    'MsgBox("6 :")
            '                Else
            '                    Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(56), "dd MMM yyyy")
            '                    'MsgBox("7 :")
            '                End If
            '            End If
            '        Else
            '            'MsgBox("8 :")
            '            'Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(84), "dd MMMM yyyy")
            '        End If
            '    End If
            'End If

        Else
            Me.lblNama.Text = ""
            Me.lblJabatan.Text = ""
            Me.lblStatusPenerimaan.Text = ""
            Me.lblStatusKawin.Text = ""
            Me.lblBawaKeluarga.Text = ""
        End If
        con.Close()

        'CutiTahunan()
        PeriodeTugas()

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
            .Parameters("@Nrp").Value = lblNrp.Text
            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            'Me.lblSisaCuti1.Text = dr.Item("SisaCuti1").ToString
            'Me.lblSisaCuti2.Text = dr.Item("SisaCuti2").ToString
            'Me.lblCutiBesar.Text = dr.Item("SisaCutiBesar").ToString
            'Me.lblTotal.Text = dr.Item("Total").ToString

        End If
        con.Close()

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
            .Parameters("@Nrp").Value = lblNrp.Text
            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Me.lblPeriodeTugas.Text = Format(CDate(dr.Item("Awal").ToString), "dd MMM yyyy") & " s/d " & Format(CDate(dr.Item("Akhir").ToString), "dd MMM yyyy")
        Else
            Me.lblPeriodeTugas.Text = ""
        End If
        con.Close()

    End Sub

    Protected Sub btSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btSave.Click
        Session("Nrp") = Me.lblNrp.Text
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
                            & ",[Keperluan]" _
                            & ",[Awal]" _
                            & ",[Akhir]" _
                            & ",[Keterangan]" _
                    & ") values (" _
                            & "@Nrp" _
                            & ",@NomorST" _
                            & ",Getdate()" _
                            & ",@Keperluan" _
                            & ",@Awal" _
                            & ",@Akhir" _
                            & ",@Keterangan" _
                            & ")"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 50)
            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)
            .Parameters.Add("@Keperluan", SqlDbType.VarChar, 30)
            .Parameters.Add("@Awal", SqlDbType.DateTime)
            .Parameters.Add("@Akhir", SqlDbType.DateTime)
            .Parameters.Add("@Keterangan", SqlDbType.VarChar, 50)

            .Parameters("@Nrp").Value = Me.lblNrp.Text
            .Parameters("@NomorST").Value = "BARU"
            .Parameters("@Keperluan").Value = "DINAS"
            .Parameters("@Awal").Value = Me.txtAwal.Text
            .Parameters("@Akhir").Value = Me.txtAkhir.Text
            .Parameters("@Keterangan").Value = Me.txtKeterangan.Text

            .ExecuteNonQuery()
            con.Close()

        End With

        'CariSC()

        ' Define the name and type of the client scripts on the page.
        Dim csname1 As String = "PopupScript"
        Dim cstype As Type = Me.GetType()

        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript

        ' Check to see if the startup script is already registered.
        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

            Dim cstext1 As String = "alert('Surat Dinas telah tersimpan...    ');"
            cstext1 += "location='default.aspx'"
            cs.RegisterStartupScript(cstype, csname1, cstext1, True)

        End If

    End Sub


    Public EditIndex As Integer = -1

    Protected Sub GridView2_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowCreated
        If e.Row.RowType = DataControlRowType.Header Or e.Row.RowIndex.ToString < 0 Then
        Else
            Dim KeyValue As String = Me.GridView2.DataKeys(e.Row.RowIndex).Value.ToString

            If KeyValue = "0" And EditIndex = -1 Then
                e.Row.Attributes.Add("isadd", "1")
                'MsgBox(e.Row.RowIndex.ToString)
                'Me.GridView2.Rows(e.Row.RowIndex).Cells(5).Text = "XX"
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
            'MsgBox(e.NewEditIndex)
            'MsgBox("1 " & GridView2.DataKeys(e.NewEditIndex).Value.ToString)
            'GridView2.Rows(e.NewEditIndex).Cells(5).Text = "DDDDD"
        Else
            'e.Cancel = True
            'MsgBox("2 " & GridView2.Rows(e.NewEditIndex).Cells(3).Text)
            'MsgBox("2 " & GridView2.SelectedRow.Cells(1).Text.ToString)
        End If


        'MsgBox("2 " & GridView2.Rows(e.NewEditIndex).Cells(3).Text)
    End Sub

    Protected Sub GridView2_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GridView2.RowUpdated
        'MsgBox("1 " & e.NewValues.Item(0).ToString)
        'MsgBox("2 " & e.NewValues.Item(1).ToString)
        'MsgBox("3 " & e.NewValues.Item(2).ToString)
        'MsgBox("4 " & e.Keys.Item(0).ToString)

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
            con.Close()
        End With
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
            .CommandText = "SELECT     tblSutu.NomorST, tblSutu.Nrp, vw_tblKaryawan.Nama, tblSutu.tglST, tblSutu.Tujuan, tblSutu.Keperluan, tblSutu.Penginapan, tblSutu.Hari, tblSutu.Awal, " _
                        & "tblSutu.Akhir, tblSutu.Transport, tblSutu.C_Lapangan, tblSutu.C_Tahunan, tblSutu.C_Besar, tblSutu.C_Perjalanan, tblSutu.C_Lain2, tblSutu.Tiket, " _
                        & "tblSutu.Hotel, tblSutu.UPD, tblSutu.JP3U, tblSutu.Taxi_Bus, tblSutu.B_Lain2, tblSutu.Uang_Muka, tblSutu.PV, tblSutu.AlamatCuti, tblSutu.Keterangan, " _
                        & "tblSutu.NomorST_Lama, tblSutu.ID, tblSutu.SisaCuti_Tahunan, tblSutu.PersetujuanAtasan, tblSutu.NrpAtasan, tblSutu.TglPersetujuan, tblSutu.Catatan, " _
                        & "tblSutu.HR_Officer, tblSutu.HRGA_Head, tblSutu.TglValidasi, tblSutu.CatatanHrga, tblSutu.ProjectManager, tblSutu.TglPersetujuanPM, tblSutu.CatatanPM, tblSutu.DibuatOleh, " _
                        & "vw_tblKaryawan_3.Nama AS NamaAtasan, vw_tblKaryawan_1.Nama AS NamaHrga, vw_tblKaryawan_1.Jabatan AS JabatanHrga, vw_tblKaryawan_2.Nama AS NamaPM, vw_tblKaryawan_2.Jabatan AS JabatanPM, " _
                        & "vw_tblKaryawan_4.Nama AS NamaHR_Officer, vw_tblKaryawan_4.Jabatan AS JabatanHROfficer, vw_tblKaryawan.Departemen, vw_tblKaryawan.Golongan " _
                        & "FROM tblSutu LEFT OUTER JOIN " _
                        & "vw_tblKaryawan ON tblSutu.Nrp = vw_tblKaryawan.Nrp LEFT OUTER JOIN " _
                        & "vw_tblKaryawan AS vw_tblKaryawan_1 ON tblSutu.HRGA_Head = vw_tblKaryawan_1.Nrp LEFT OUTER JOIN " _
                        & "vw_tblKaryawan AS vw_tblKaryawan_2 ON tblSutu.ProjectManager = vw_tblKaryawan_2.Nrp LEFT OUTER JOIN " _
                        & "vw_tblKaryawan AS vw_tblKaryawan_3 ON tblSutu.NrpAtasan = vw_tblKaryawan_3.Nrp LEFT OUTER JOIN " _
                        & "vw_tblKaryawan AS vw_tblKaryawan_4 ON tblSutu.HR_Officer = vw_tblKaryawan_4.Nrp " _
                        & "WHERE NomorST = @NomorST "
            .Parameters.Add("@NomorST", SqlDbType.VarChar, 19)
            .Parameters("@NomorST").Value = Request.QueryString("n").ToString

            dr = .ExecuteReader
        End With
        If dr.Read = True Then

            Me.lblNrp.Text = dr.Item("Nrp").ToString
            Me.lblNomor.Text = dr.Item("NomorST").ToString
            Me.txtTujuan.Text = dr.Item("Tujuan").ToString
            Me.txtPenginapan.Text = dr.Item("Penginapan").ToString
            Me.txtTransport.Text = dr.Item("Transport").ToString
            Me.txtAwal.Text = Format(CDate(dr.Item("Awal").ToString), "dd MMM yyyy")
            Me.txtAkhir.Text = Format(CDate(dr.Item("Akhir").ToString), "dd MMM yyyy")
            Me.txtUangMuka.Text = dr.Item("Uang_Muka").ToString
            Me.txtKeterangan.Text = dr.Item("Keterangan").ToString

            Me.btSave.Visible = False
            '----------

            'Me.txtTujuan.Text = dr.Item("Tujuan").ToString
            Me.txtAwal.Text = Format(CDate(dr.Item("Awal").ToString), "dd MMM yyyy")
            Me.txtAkhir.Text = Format(CDate(dr.Item("Akhir").ToString), "dd MMM yyyy")
            Me.txtKeterangan.Text = dr.Item("Keterangan").ToString
            Me.lblPersonnelAdmin.Text = dr.Item("HR_Officer").ToString & " / " & dr.Item("NamaHR_Officer").ToString
            If Me.lblPersonnelAdmin.Text <> "" Then
                Me.btnPrint.Visible = False
            End If
            ''Persetujuan Atasan
            'Me.lblHead.Text = dr.Item("NrpAtasan").ToString & " / " & dr.Item("NamaAtasan").ToString
            'Me.lblTg0.Text = dr.Item("TglPersetujuan").ToString
            ''Me.txtCatatan.Text = dr.Item("Catatan").ToString
            'If dr.Item("PersetujuanAtasan").ToString <> "" Then
            '    Me.txtCatatan.Text = dr.Item("Catatan").ToString
            '    If CBool(dr.Item("PersetujuanAtasan").ToString) = True Then
            '        Me.ckSetuju.Checked = True
            '    ElseIf CBool(dr.Item("PersetujuanAtasan").ToString) = False Then
            '        Me.ckTidakSetuju.Checked = True
            '    End If
            '    Me.btnSetuju.Visible = False

            'End If
            'Validasi HRGA
            If dr.Item("TglValidasi").ToString <> "" Then
                'Me.Panel2.Enabled = False
                Me.lblTg1.Text = dr.Item("TglValidasi").ToString
                Me.lblHrga.Text = dr.Item("Hrga_Head").ToString & " / " & dr.Item("NamaHrga").ToString
                Me.txtCatatanHrga.Text = dr.Item("CatatanHrga").ToString
                Me.btnSetujuHrga.Visible = False
                Me.btnRevisi.Visible = False
            End If

            'Persetujuan PM/HRGA
            If dr.Item("ProjectManager").ToString <> "" Then
                'Me.Panel2.Enabled = False
                Me.lblTg2.Text = dr.Item("TglPersetujuanPM").ToString
                Me.lblPM.Text = dr.Item("ProjectManager").ToString & " / " & dr.Item("NamaPM").ToString
                Me.txtCatatanPM.Text = dr.Item("CatatanPM").ToString
                Me.btnSetujuPM.Visible = False

                'If InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL") > 0 Then
                '    Me.Panel4.Visible = True
                'ElseIf InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("ndPosisi").ToString, "PAYROLL") > 0 Then
                '    Me.Panel4.Visible = True
                'Else
                '    Me.Panel4.Visible = True
                '    Me.Panel4.Enabled = False
                'End If

            End If

        Else
            Me.btSave.Visible = False

        End If

        'Enable Panel1
        'If dr.Item("PersetujuanAtasan").ToString <> "" Then
        '    Me.Panel1.Enabled = False
        '    Me.Panel2.Visible = True
        'Enable Panel2
        If (dr.Item("Golongan").ToString) <= 18 Then
            'Golongan <= 3..gol 1-18
            If dr.Item("TglValidasi").ToString <> "" Then
                Me.Panel2.Enabled = False
                Me.Panel3.Visible = True
                'Enable Panel3
                If dr.Item("ProjectManager").ToString <> "" Then
                    Me.Panel3.Enabled = False
                    'Proses Personnel---->>
                Else 'rubah dari hrga head ke pm'..gak sido...
                    'If InStr(1, Session("jabatan").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("jabatan").ToString, "Project Manager") > 0 Then
                    If InStr(1, Session("jabatan").ToString, "HRPGA DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRPGA Dept. Head") > 0 Then
                        Me.Panel3.Enabled = True
                        'ElseIf InStr(1, Session("ndPosisi").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("ndPosisi").ToString, "Project Manager") > 0 Then
                    ElseIf InStr(1, Session("ndPosisi").ToString, "HRPGA DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRPGA Dept. Head") > 0 Then
                        Me.Panel3.Enabled = True
                    Else
                        Me.Panel3.Enabled = False
                    End If
                    'If InStr(1, Session("jabatan").ToString, "HRPGA DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRPGA Dept. Head") > 0 Then
                    '    Me.Panel3.Enabled = True
                    'ElseIf InStr(1, Session("ndPosisi").ToString, "HRPGA DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRPGA Dept. Head") > 0 Then
                    '    Me.Panel3.Enabled = True
                    'Else
                    '    Me.Panel3.Enabled = False
                    'End If
                End If
            Else  'rubah dari hrga sect ke hrga head '...gaksido..
                'If InStr(1, Session("jabatan").ToString, "HRPGA DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRPGA Dept. Head") > 0 Then
                If InStr(1, Session("jabatan").ToString, "HRPGA SECT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRPGA Sect. Head") > 0 Then
                    Me.Panel2.Enabled = True
                    'ElseIf InStr(1, Session("ndPosisi").ToString, "HRPGA DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRPGA Dept. Head") > 0 Then
                ElseIf InStr(1, Session("ndPosisi").ToString, "HRPGA SECT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRPGA Sect. Head") > 0 Then
                    Me.Panel2.Enabled = True
                    'If InStr(1, Session("jabatan").ToString, "HRPGA SECT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRPGA Sect. Head") > 0 Then
                    '    Me.Panel2.Enabled = True
                    'ElseIf InStr(1, Session("ndPosisi").ToString, "HRPGA SECT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRPGA Sect. Head") > 0 Then
                    '    Me.Panel2.Enabled = True
                Else
                    Me.Panel2.Enabled = False
                    Me.btnSetujuHrga.Visible = False
                End If
            End If

        ElseIf (dr.Item("Golongan").ToString) >= 19 Then
            'Golongan > 3
            If dr.Item("TglValidasi").ToString <> "" Then
                Me.Panel2.Enabled = False
                Me.Panel3.Visible = True
                'Enable Panel3
                If dr.Item("ProjectManager").ToString <> "" Then
                    Me.Panel3.Enabled = False
                    'Proses Personnel---->>
                Else
                    If InStr(1, Session("jabatan").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("jabatan").ToString, "Project Manager") > 0 Then
                        Me.Panel3.Enabled = True
                    ElseIf InStr(1, Session("ndPosisi").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("ndPosisi").ToString, "Project Manager") > 0 Then
                        Me.Panel3.Enabled = True
                    Else
                        Me.Panel3.Enabled = False
                    End If
                End If
            Else
                If InStr(1, Session("jabatan").ToString, "HRPGA DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRPGA Dept. Head") > 0 Then
                    Me.Panel2.Enabled = True
                ElseIf InStr(1, Session("ndPosisi").ToString, "HRPGA DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRPGA Dept. Head") > 0 Then
                    Me.Panel2.Enabled = True
                Else
                    Me.Panel2.Enabled = False
                End If
            End If
        End If

        con.Close()

        'Else
        '    If Trim(dr.Item("Departemen").ToString) = Trim(Session("dept").ToString) Then
        '        If InStr(1, Session("jabatan").ToString, "DEPT. HEAD") > 0 Then
        '            Me.Panel1.Enabled = True
        '        ElseIf InStr(1, Session("ndPosisi").ToString, "DEPT. HEAD") > 0 Then
        '            Me.Panel1.Enabled = True
        '        Else
        '            Me.Panel1.Enabled = False
        '        End If
        '    Else
        '        Me.Panel1.Enabled = False
        '    End If
        'End If
        ''Response.Write(Session("jabatan"))
        ''Response.Write(Session("ndPosisi"))
    End Sub

    Protected Sub btUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btUpdate.Click
        Session("Nrp") = Me.lblNrp.Text
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
            .CommandText = "Update tblSutu Set " _
                            & " [Nrp]=@Nrp" _
                            & ",[tglST]=Getdate()" _
                            & ",[Keperluan]=@Keperluan" _
                            & ",[Awal]=@Awal" _
                            & ",[Akhir]=@Akhir" _
                            & ",[Keterangan]=@Keterangan" _
                            & " Where NomorST = @NomorST"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 50)
            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)
            .Parameters.Add("@Keperluan", SqlDbType.VarChar, 30)
            .Parameters.Add("@Awal", SqlDbType.DateTime)
            .Parameters.Add("@Akhir", SqlDbType.DateTime)
            .Parameters.Add("@Keterangan", SqlDbType.VarChar, 50)

            .Parameters("@Nrp").Value = Me.lblNrp.Text
            .Parameters("@NomorST").Value = Me.lblNomor.Text
            .Parameters("@Keperluan").Value = "DINAS"
            .Parameters("@Awal").Value = Me.txtAwal.Text
            .Parameters("@Akhir").Value = Me.txtAkhir.Text
            .Parameters("@Keterangan").Value = Me.txtKeterangan.Text

            .ExecuteNonQuery()
            con.Close()

        End With
    End Sub

    'Protected Sub btnSetuju_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetuju.Click
    '    Dim con As SqlClient.SqlConnection = Nothing
    '    Dim cmd As SqlClient.SqlCommand = Nothing

    '    cmd = New SqlClient.SqlCommand

    '    Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
    '    con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

    '    con.Open()
    '    With cmd
    '        .Connection = con
    '        .CommandType = CommandType.Text
    '        .CommandText = "Update tblSutu Set " _
    '                        & " [PersetujuanAtasan]=@PersetujuanAtasan" _
    '                        & ",[NrpAtasan]=@NrpAtasan" _
    '                        & ",[TglPersetujuan]=Getdate()" _
    '                        & ",[Catatan]=@Catatan" _
    '                        & " Where NomorST = @NomorST"

    '        .Parameters.Add("@PersetujuanAtasan", SqlDbType.Bit)
    '        .Parameters.Add("@NrpAtasan", SqlDbType.VarChar, 10)
    '        .Parameters.Add("@Catatan", SqlDbType.VarChar, 50)
    '        .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)

    '        If Me.ckSetuju.Checked = True Then
    '            .Parameters("@PersetujuanAtasan").Value = True
    '        Else
    '            .Parameters("@PersetujuanAtasan").Value = False
    '        End If
    '        .Parameters("@NrpAtasan").Value = Session("userid").ToString
    '        .Parameters("@NomorST").Value = Me.lblNomor.Text
    '        .Parameters("@Catatan").Value = Me.txtCatatan.Text

    '        .ExecuteNonQuery()

    '        Dim csname1 As String = "PopupScript"
    '        Dim cstype As Type = Me.GetType()

    '        ' Get a ClientScriptManager reference from the Page class.
    '        Dim cs As ClientScriptManager = Page.ClientScript

    '        ' Check to see if the startup script is already registered.
    '        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

    '            Dim cstext1 As String = "alert('Surat tugas telah tersimpan...    ');"
    '            cstext1 += "location='dTugas.aspx?n=" & Me.lblNomor.Text & "'"
    '            cs.RegisterStartupScript(cstype, csname1, cstext1, True)

    '        End If
    '    End With
    'End Sub

    Protected Sub btnSetujuHrga_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetujuHrga.Click
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Update tblSutu Set " _
                            & " [Hrga_Head]=@Hrga_Head" _
                            & ",[TglValidasi]=Getdate()" _
                            & ",[CatatanHrga]=@CatatanHrga" _
                            & " Where NomorST = @NomorST"

            .Parameters.Add("@Hrga_Head", SqlDbType.VarChar, 10)
            .Parameters.Add("@CatatanHrga", SqlDbType.VarChar, 50)
            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)

            .Parameters("@Hrga_Head").Value = Session("userid").ToString
            .Parameters("@NomorST").Value = Me.lblNomor.Text
            .Parameters("@CatatanHrga").Value = Me.txtCatatanHrga.Text

            .ExecuteNonQuery()

            Dim csname1 As String = "PopupScript"
            Dim cstype As Type = Me.GetType()

            ' Get a ClientScriptManager reference from the Page class.
            Dim cs As ClientScriptManager = Page.ClientScript

            ' Check to see if the startup script is already registered.
            If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

                Dim cstext1 As String = "alert('Surat tugas telah tersimpan...    ');"
                cstext1 += "location='dTugas.aspx?n=" & Me.lblNomor.Text & "'"
                cs.RegisterStartupScript(cstype, csname1, cstext1, True)

            End If
        End With
    End Sub

    Protected Sub btnSetujuPM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetujuPM.Click
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Update tblSutu Set " _
                            & " [ProjectManager]=@PM" _
                            & ",[TglPersetujuanPM]=Getdate()" _
                            & ",[CatatanPM]=@CatatanPM" _
                            & " Where NomorST = @NomorST"

            .Parameters.Add("@PM", SqlDbType.VarChar, 10)
            .Parameters.Add("@CatatanPM", SqlDbType.VarChar, 50)
            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)

            .Parameters("@PM").Value = Session("userid").ToString
            .Parameters("@NomorST").Value = Me.lblNomor.Text
            .Parameters("@CatatanPM").Value = Me.txtCatatanPM.Text

            .ExecuteNonQuery()
            con.Close()

            Dim csname1 As String = "PopupScript"
            Dim cstype As Type = Me.GetType()

            ' Get a ClientScriptManager reference from the Page class.
            Dim cs As ClientScriptManager = Page.ClientScript

            ' Check to see if the startup script is already registered.
            If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

                Dim cstext1 As String = "alert('Surat tugas telah tersimpan...    ');"
                cstext1 += "location='dTugas.aspx?n=" & Me.lblNomor.Text & "'"
                cs.RegisterStartupScript(cstype, csname1, cstext1, True)

            End If
        End With
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Update tblSutu Set " _
                            & " [HR_Officer]=@HR_Officer" _
                            & " Where NomorST = @NomorST"

            .Parameters.Add("@HR_Officer", SqlDbType.VarChar, 10)
            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)

            .Parameters("@HR_Officer").Value = Session("userid").ToString
            .Parameters("@NomorST").Value = Me.lblNomor.Text

            .ExecuteNonQuery()
            con.Close()

            Response.Redirect("pTugas.aspx?n=" & Me.lblNomor.Text)
        End With
    End Sub
End Class
