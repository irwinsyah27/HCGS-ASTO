Imports System.Data
Imports System.Data.SqlClient

Partial Class _dDinas
    Inherits System.Web.UI.Page
    Dim TotLapangan As Integer
    Dim TotTahunan As Integer
    Dim TotBesar As Integer
    Dim TotPerjalanan As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        CutiTahunan()
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
            .Parameters("@Nrp").Value = lblNrp.Text
            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Me.lblPeriodeTugas.Text = Format(CDate(dr.Item("Awal").ToString), "dd MMM yyyy") & " s/d " & Format(CDate(dr.Item("Akhir").ToString), "dd MMM yyyy")
        Else
            Me.lblPeriodeTugas.Text = ""
        End If

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
            .CommandText = "SELECT     tblSutu.NomorST, tblSutu.Nrp, tblKaryawan.Nama, tblSutu.tglST, tblSutu.Tujuan, tblSutu.Keperluan, tblSutu.Penginapan, tblSutu.Hari, tblSutu.Awal, " _
                        & "tblSutu.Akhir, tblSutu.Transport, tblSutu.C_Lapangan, tblSutu.C_Tahunan, tblSutu.C_Besar, tblSutu.C_Perjalanan, tblSutu.C_Lain2, tblSutu.Tiket, " _
                        & "tblSutu.Hotel, tblSutu.UPD, tblSutu.JP3U, tblSutu.Taxi_Bus, tblSutu.B_Lain2, tblSutu.PeriodeTugas, tblSutu.Uang_Muka, tblSutu.PV, tblSutu.AlamatCuti, tblSutu.Keterangan, " _
                        & "tblSutu.NomorST_Lama, tblSutu.ID, tblSutu.SisaCuti_Tahunan, tblSutu.PersetujuanAtasan, tblSutu.NrpAtasan, tblSutu.TglPersetujuan, tblSutu.Catatan, " _
                        & "tblSutu.HR_Officer, tblSutu.HRGA_Head, tblSutu.TglValidasi, tblSutu.CatatanHrga, tblSutu.ProjectManager, tblSutu.TglPersetujuanPM, tblSutu.CatatanPM, tblSutu.DibuatOleh, " _
                        & "tblKaryawan_3.Nama AS NamaAtasan, tblKaryawan_1.Nama AS NamaHrga, tblKaryawan_1.Jabatan AS JabatanHrga, tblKaryawan_2.Nama AS NamaPM, tblKaryawan_2.Jabatan AS JabatanPM, " _
                        & "tblKaryawan_4.Nama AS NamaHR_Officer, tblKaryawan_4.Jabatan AS JabatanHROfficer, tblKaryawan.Departemen, tblKaryawan.Golongan " _
                        & "FROM tblSutu LEFT OUTER JOIN " _
                        & "tblKaryawan ON tblSutu.Nrp = tblKaryawan.Nrp LEFT OUTER JOIN " _
                        & "tblKaryawan AS tblKaryawan_1 ON tblSutu.HRGA_Head = tblKaryawan_1.Nrp LEFT OUTER JOIN " _
                        & "tblKaryawan AS tblKaryawan_2 ON tblSutu.ProjectManager = tblKaryawan_2.Nrp LEFT OUTER JOIN " _
                        & "tblKaryawan AS tblKaryawan_3 ON tblSutu.NrpAtasan = tblKaryawan_3.Nrp LEFT OUTER JOIN " _
                        & "tblKaryawan AS tblKaryawan_4 ON tblSutu.HR_Officer = tblKaryawan_4.Nrp " _
                        & "WHERE NomorST = @NomorST "
            .Parameters.Add("@NomorST", SqlDbType.VarChar, 19)
            .Parameters("@NomorST").Value = Request.QueryString("n").ToString

            dr = .ExecuteReader
        End With
        If dr.Read = True Then

            Me.lblNrp.Text = dr.Item("Nrp").ToString
            Me.lblNomor.Text = dr.Item("NomorST").ToString
            Me.txtPenginapan.Text = dr.Item("Penginapan").ToString
            Me.txtAwal.Text = Format(CDate(dr.Item("Awal").ToString), "dd MMM yyyy")
            Me.txtAkhir.Text = Format(CDate(dr.Item("Akhir").ToString), "dd MMM yyyy")
            Me.txtKeterangan.Text = dr.Item("Keterangan").ToString
            Me.lblPeriodeTugas.Text = dr.Item("PeriodeTugas").ToString

            Me.btSave.Visible = False
            '----------

            'Me.txtTujuan.Text = dr.Item("Tujuan").ToString
            Me.txtAwal.Text = Format(CDate(dr.Item("Awal").ToString), "dd MMM yyyy")
            Me.txtAkhir.Text = Format(CDate(dr.Item("Akhir").ToString), "dd MMM yyyy")
            Me.txtKeterangan.Text = dr.Item("Keterangan").ToString
            Me.lblPersonnelAdmin.Text = dr.Item("HR_Officer").ToString & " / " & dr.Item("NamaHR_Officer").ToString

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

                If InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL") > 0 Then
                    Me.Panel4.Visible = True
                Else
                    Me.Panel4.Visible = True
                    Me.Panel4.Enabled = False
                End If

            End If

        Else
            Me.btSave.Visible = False

        End If

        'Enable Panel1
        'If dr.Item("PersetujuanAtasan").ToString <> "" Then
        '    Me.Panel1.Enabled = False
        '    Me.Panel2.Visible = True
        'Enable Panel2
        If Left(dr.Item("Golongan").ToString, 1) <= 3 Then
            'Golongan <= 3
            If dr.Item("TglValidasi").ToString <> "" Then
                Me.Panel2.Enabled = False
                Me.Panel3.Visible = True
                'Enable Panel3
                If dr.Item("ProjectManager").ToString <> "" Then
                    Me.Panel3.Enabled = False
                    'Proses Personnel---->>
                Else
                    If InStr(1, Session("jabatan").ToString, "HRGA DEPT. HEAD") > 0 Then
                        Me.Panel3.Enabled = True
                    ElseIf InStr(1, Session("ndPosisi").ToString, "HRGA DEPT. HEAD") > 0 Then
                        Me.Panel3.Enabled = True
                    Else
                        Me.Panel3.Enabled = False
                    End If
                End If
            Else
                If InStr(1, Session("jabatan").ToString, "HRGA SECT. HEAD") > 0 Then
                    Me.Panel2.Enabled = True
                ElseIf InStr(1, Session("ndPosisi").ToString, "HRGA SECT. HEAD") > 0 Then
                    Me.Panel2.Enabled = True
                Else
                    Me.Panel2.Enabled = False
                    Me.btnSetujuHrga.Visible = False
                End If
            End If

        Else
            'Golongan > 3
            If dr.Item("TglValidasi").ToString <> "" Then
                Me.Panel2.Enabled = False
                Me.Panel3.Visible = True
                'Enable Panel3
                If dr.Item("ProjectManager").ToString <> "" Then
                    Me.Panel3.Enabled = False
                    'Proses Personnel---->>
                Else
                    If InStr(1, Session("jabatan").ToString, "PROJECT MANAGER") > 0 Then
                        Me.Panel3.Enabled = True
                    Else
                        Me.Panel3.Enabled = False
                    End If
                End If
            Else
                If InStr(1, Session("jabatan").ToString, "HRGA DEPT. HEAD") > 0 Then
                    Me.Panel2.Enabled = True
                ElseIf InStr(1, Session("ndPosisi").ToString, "HRGA DEPT. HEAD") > 0 Then
                    Me.Panel2.Enabled = True
                Else
                    Me.Panel2.Enabled = False
                End If
            End If
        End If

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
        End With
    End Sub

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
                cstext1 += "location='dDinas.aspx?n=" & Me.lblNomor.Text & "'"
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

            Dim csname1 As String = "PopupScript"
            Dim cstype As Type = Me.GetType()

            ' Get a ClientScriptManager reference from the Page class.
            Dim cs As ClientScriptManager = Page.ClientScript

            ' Check to see if the startup script is already registered.
            If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

                Dim cstext1 As String = "alert('Surat tugas telah tersimpan...    ');"
                cstext1 += "location='dDinas.aspx?n=" & Me.lblNomor.Text & "'"
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

            Response.Redirect("pDinas.aspx?n=" & Me.lblNomor.Text)
        End With

    End Sub
End Class
