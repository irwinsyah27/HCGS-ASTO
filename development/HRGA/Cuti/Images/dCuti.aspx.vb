Imports System.Data
Imports System.Data.SqlClient
'Imports System.Web.Mail
Partial Class _dCuti
    Inherits System.Web.UI.Page
    Dim TotLapangan As Integer
    Dim TotTahunan As Integer
    Dim TotBesar As Integer
    Dim TotPerjalanan As Integer
    Dim Jabatan As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./cuti/dCuti.aspx?n=" & Request.QueryString("n").ToString
            Response.Redirect("../login.aspx")
        End If

        If InStr(1, Request.QueryString("n").ToString, "LSP") > 0 Then
            Response.Redirect("dCutiLS.aspx?n=" & Request.QueryString("n"))
        End If

        ' Define the name and type of the client scripts on the page.
        Dim csname1 As String = "PopupScript"
        Dim csname2 As String = "ButtonClickScript"
        Dim cstype As Type = Me.GetType()

        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript

        '' Check to see if the startup script is already registered.
        'If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

        '    Dim cstext1 As String = "alert('Hello World');"
        '    cs.RegisterStartupScript(cstype, csname1, cstext1, True)

        'End If

        ' Check to see if the client script is already registered.
        If (Not cs.IsClientScriptBlockRegistered(cstype, csname2)) Then
            Dim cstext2 As New StringBuilder()
            cstext2.Append("<script type=text/javascript> function DoClick() {")
            cstext2.Append("window.open('rCuti.aspx?n=" & Request.QueryString("n").ToString & "','PopupClass','width=515,height=330,left=230,top=300')} </")
            cstext2.Append("script>")

            cstext2.Append("<script type=text/javascript> function DoClick2() {")
            cstext2.Append("window.open('rCuti2.aspx?n=" & Request.QueryString("n").ToString & "','PopupClass','width=600,height=600,left=80,top=40')} </")
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
            .Parameters("@Nrp").Value = Me.lblNrp.Text
            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Me.lblNama.Text = dr.Item("Nama").ToString
            'Me.lblPemohon.Text = dr.Item("Nama").ToString
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
        con.Close()

        ''---------------Cuti --------------
        CutiLapangan()
        CutiTahunan()
        CutiBesar()
        CutiPerjalanan()
        CutiTotal()
        'PeriodeTugas()
        'AwalCutiTahunan()

        'Me.btnPrint.PostBackUrl = "pCuti.aspx?n=" & Me.lblNomor.Text

    End Sub

    Sub CutiLapangan()
        If Me.ckLapangan.Checked = True Then
            Me.txtLapangan.Enabled = True
            If txtLapangan.Text <> "" Then
                TotLapangan = txtLapangan.Text
            Else
                TotLapangan = 0
            End If
        Else
            Me.txtLapangan.Enabled = False
        End If
    End Sub

    Sub CutiTahunan()
        If Me.ckTahunan.Checked = True Then
            Me.txtTahunan.Enabled = True
            If txtTahunan.Text <> "" Then
                TotTahunan = txtTahunan.Text
            Else
                TotTahunan = 0
            End If
        Else
            Me.txtTahunan.Enabled = False
            Me.txtTahunan.Text = 0
        End If
    End Sub

    Sub CutiBesar()
        If Me.ckBesar.Checked = True Then
            Me.txtBesar.Enabled = True
            If txtBesar.Text <> "" Then
                TotBesar = txtBesar.Text
            Else
                TotBesar = 0
            End If
        Else
            Me.txtBesar.Enabled = False
            Me.txtBesar.Text = 0
        End If

    End Sub

    Sub CutiPerjalanan()
        If Me.ckPerjalanan.Checked = True Then
            Me.txtPerjalanan.Enabled = True
            If Me.txtPerjalanan.Text <> "" Then
                TotPerjalanan = txtPerjalanan.Text
            Else
                TotPerjalanan = 0
            End If
        Else
            Me.txtPerjalanan.Enabled = False
            Me.txtPerjalanan.Text = 0
        End If
    End Sub

    Sub CutiTotal()
        Me.txtTotal.Text = TotLapangan + TotTahunan + TotBesar + TotPerjalanan
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

    Sub AwalCutiTahunan()
        Dim AwalCTahunan As DateTime
        Dim temp1 As DateTime

        Dim i As Integer
        If Me.txtAwal.Text <> "" Then
            AwalCTahunan = txtAwal.Text
            If Me.txtPerjalanan.Text <> "0" Then
                AwalCTahunan = AwalCTahunan.AddDays(CInt(Me.txtLapangan.Text) + 1)
            Else
                AwalCTahunan = AwalCTahunan.AddDays(Me.txtLapangan.Text)
            End If

            temp1 = Format(AwalCTahunan, "dd MMM yyyy")

            If Me.txtTahunan.Text <> "0" Or Me.txtBesar.Text <> "0" Then
                CheckHariLibur(temp1)
                Do While i < CInt(Me.txtTahunan.Text) + CInt(Me.txtBesar.Text)
                    If temp1.DayOfWeek <> DayOfWeek.Sunday Then
                        i += 1
                        If libur = True Then
                            i = i - 1
                        End If
                    End If
                    'Response.Write(temp1 & " " & libur & "<BR>")
                    temp1 = temp1.AddDays(1)
                Loop
                If Me.txtPerjalanan.Text = 0 Then
                    Me.txtAkhir.Text = Format(Format(temp1.AddDays(-1), "dd MMM yyyy"))
                Else
                    Me.txtAkhir.Text = Format(Format(temp1, "dd MMM yyyy"))
                End If
            Else
                Me.txtAkhir.Text = Format(CDate(txtAwal.Text).AddDays(CInt(Me.txtLapangan.Text) - 1 + CInt(Me.txtPerjalanan.Text)), "dd MMM yyyy")
            End If
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
            '.CommandText = "Select tblSutu.*, vw_tblKaryawan.Nama As NamaAtasan, vw_tblKaryawan.Nama As Nama_Hrga From tblSutu Left Join vw_tblKaryawan On tblSutu.NrpAtasan = vw_tblKaryawan.Nrp Where NomorST = @NomorST "
            .CommandText = "SELECT     tblSutu.NomorST, tblSutu.Nrp, vw_tblKaryawan.Nama, vw_tblKaryawan.Jabatan, tblSutu.tglST, tblSutu.Tujuan, tblSutu.Keperluan, tblSutu.Penginapan, tblSutu.Hari, tblSutu.Awal, " _
                      & "tblSutu.Akhir, tblSutu.Transport, tblSutu.C_Lapangan, tblSutu.C_Tahunan, tblSutu.C_Besar, tblSutu.C_Perjalanan, tblSutu.C_Lain2, tblSutu.Tiket, " _
                      & "tblSutu.Hotel, tblSutu.UPD, tblSutu.JP3U, tblSutu.Taxi_Bus, tblSutu.B_Lain2, tblSutu.PeriodeTugas, tblSutu.Uang_Muka, tblSutu.PV, tblSutu.AlamatCuti, tblSutu.Keterangan, " _
                      & "tblSutu.NomorST_Lama, tblSutu.ID, tblSutu.SisaCuti1, tblSutu.SisaCuti2, tblSutu.SisaCuti3, tblSutu.SisaCuti_Tahunan, tblSutu.SisaCuti_Besar, tblSutu.PersetujuanAtasan, tblSutu.NrpAtasan, tblSutu.TglPersetujuan, tblSutu.Catatan, " _
                      & "tblSutu.HR_Officer, tblSutu.VerifikasiHR, tblSutu.TglVerifikasi, tblSutu.PersetujuanHr, tblSutu.PersetujuanHrga, tblSutu.PersetujuanPm, tblSutu.HRGA_Head, tblSutu.TglValidasi, tblSutu.CatatanHrga, tblSutu.ProjectManager, tblSutu.TglPersetujuanPM, tblSutu.CatatanPM, tblSutu.DibuatOleh, " _
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
            Jabatan = dr.Item("Jabatan").ToString
            Me.lblDibuatOleh.Text = dr.Item("DibuatOleh").ToString & " (" & Format(dr.Item("tglST"), "dd MMMM yyyy").ToString & ")"
            Me.lblNrp.Text = dr.Item("Nrp").ToString
            Me.lblNomor.Text = dr.Item("NomorST").ToString
            If dr.Item("C_Lapangan").ToString <> "" Then
                If dr.Item("C_Lapangan").ToString > 0 Then
                    Me.txtLapangan.Text = dr.Item("C_Lapangan").ToString
                    Me.txtLapangan.Enabled = False
                    Me.ckLapangan.Checked = True
                End If
            End If
            If dr.Item("C_Tahunan").ToString <> "" Then
                If dr.Item("C_Tahunan").ToString > 0 Then
                    Me.txtTahunan.Text = dr.Item("C_Tahunan").ToString
                    Me.txtTahunan.Enabled = False
                    Me.ckTahunan.Checked = True
                End If
            End If
            If dr.Item("C_Besar").ToString <> "" Then
                If dr.Item("C_Besar").ToString > 0 Then
                    Me.txtBesar.Text = dr.Item("C_Besar").ToString
                    Me.txtBesar.Enabled = False
                    Me.ckBesar.Checked = True
                End If
            End If
            If dr.Item("C_Perjalanan").ToString <> "" Then
                If dr.Item("C_Perjalanan").ToString > 0 Then
                    Me.txtPerjalanan.Text = dr.Item("C_Perjalanan").ToString
                    Me.txtPerjalanan.Enabled = False
                    Me.ckPerjalanan.Checked = True
                End If
            End If
            Me.lblPeriodeTugas.Text = dr.Item("PeriodeTugas").ToString
            Me.txtTujuan.Text = dr.Item("Tujuan").ToString
            Me.txtAwal.Text = Format(CDate(dr.Item("Awal").ToString), "dd MMM yyyy")
            Me.txtAkhir.Text = Format(CDate(dr.Item("Akhir").ToString), "dd MMM yyyy")
            Me.txtAlamatCuti.Text = dr.Item("AlamatCuti").ToString
            Me.txtKeterangan.Text = dr.Item("Keterangan").ToString
            Me.lblSisaCuti1.Text = dr.Item("SisaCuti1").ToString
            Me.lblSisaCuti2.Text = dr.Item("SisaCuti2").ToString
            Me.lblCutiBesar.Text = dr.Item("SisaCuti3").ToString
            Me.lblSisaCuti.Text = dr.Item("SisaCuti_Tahunan").ToString
            Me.lblSisaCutiBesar.Text = CInt(dr.Item("SisaCuti3").ToString) - CInt(dr.Item("C_Besar").ToString)
            Me.lblTotal.Text = CInt(dr.Item("SisaCuti_Tahunan").ToString) + CInt(dr.Item("SisaCuti_Besar").ToString) + CInt(dr.Item("C_Tahunan").ToString) + CInt(dr.Item("C_Besar").ToString)
            Me.lblPersonnelAdmin.Text = dr.Item("HR_Officer").ToString & " / " & dr.Item("NamaHR_Officer").ToString
            If Me.lblPersonnelAdmin.Text <> "" Then
                Me.btnVerifikasi.Visible = False
                Me.btRevisiHr.Visible = False
            End If
            'Persetujuan Atasan
            Me.lblHead.Text = dr.Item("NrpAtasan").ToString & " / " & dr.Item("NamaAtasan").ToString
            Me.lblTg0.Text = dr.Item("TglPersetujuan").ToString
            'Me.txtCatatan.Text = dr.Item("Catatan").ToString
            If dr.Item("PersetujuanAtasan").ToString <> "" Then
                Me.txtCatatan.Text = dr.Item("Catatan").ToString
                If CBool(dr.Item("PersetujuanAtasan").ToString) = True Then
                    Me.ckSetuju.Checked = True
                ElseIf CBool(dr.Item("PersetujuanAtasan").ToString) = False Then
                    Me.ckTidakSetuju.Checked = True
                End If
                Me.btnSetuju.Visible = False
                Me.btnRevisi.Visible = False
            End If

            'Verifikasi HR===============================
            If dr.Item("HR_Officer").ToString <> "" Then
                Me.Panel4.Enabled = False
                Me.Panel4.Visible = True
                Me.lblTg4.Text = dr.Item("TglVerifikasi").ToString
                Me.lblPersonnelAdmin.Text = dr.Item("HR_Officer").ToString & " / " & dr.Item("NamaHR_Officer").ToString
                Me.txtVerifikasiHr.Text = dr.Item("VerifikasiHr").ToString
                If dr.Item("PersetujuanHr").ToString <> "" Then
                    If CBool(dr.Item("PersetujuanHr").ToString) = True Then
                        Me.ckHrSetuju.Checked = True
                    ElseIf CBool(dr.Item("PersetujuanHr").ToString) = False Then
                        Me.ckHrTidakSetuju.Checked = True
                    End If
                    Me.btnVerifikasi.Visible = False
                    Me.btRevisiHr.Visible = False
                    'Me.btnVerifikasi.Visible = False
                    ''====cuti khusus ====
                    If dr.Item("PV").ToString = "A" Then
                        Me.Hari1.Checked = False
                        Me.Hari2.Checked = False
                        Me.Melahirkan.Checked = False
                        Me.Haji.Checked = False
                    ElseIf dr.Item("PV").ToString = "B" Then
                        Me.Hari1.Checked = True
                        Me.Hari2.Checked = False
                        Me.Melahirkan.Checked = False
                        Me.Haji.Checked = False
                    ElseIf dr.Item("PV").ToString = "C" Then
                        Me.Hari1.Checked = False
                        Me.Hari2.Checked = True
                        Me.Melahirkan.Checked = False
                        Me.Haji.Checked = False
                    ElseIf dr.Item("PV").ToString = "D" Then
                        Me.Hari1.Checked = False
                        Me.Hari2.Checked = False
                        Me.Melahirkan.Checked = True
                        Me.Haji.Checked = False
                    ElseIf dr.Item("PV").ToString = "E" Then
                        Me.Hari1.Checked = False
                        Me.Hari2.Checked = False
                        Me.Melahirkan.Checked = False
                        Me.Haji.Checked = True
                    End If

                    ''====end off cuti khusus ====
                End If

                Me.ckHrSetuju.Checked = True

            Else
                If InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL") > 0 Or InStr(1, Session("jabatan").ToString, "Personnel Admin") > 0 Or InStr(1, Session("jabatan").ToString, "Payroll") > 0 Then
                    Me.Panel4.Visible = True
                    Me.btnVerifikasi.Visible = True
                    Me.btRevisiHr.Visible = True
                    Me.Panel2.Visible = False
                ElseIf InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("ndPosisi").ToString, "PAYROLL") > 0 Or InStr(1, Session("ndPosisi").ToString, "Personnel Admin") > 0 Or InStr(1, Session("ndPosisi").ToString, "Payroll") > 0 Then
                    Me.Panel4.Visible = True
                    Me.btnVerifikasi.Visible = True
                    Me.btRevisiHr.Visible = True
                    Me.Panel2.Visible = False
                Else
                    Me.Panel4.Visible = True
                    Me.Panel4.Enabled = False
                    Me.btnVerifikasi.Visible = False
                    Me.btRevisiHr.Visible = False
                    Me.Panel2.Visible = False
                End If

            End If

            'Validasi HRGA================================
            If dr.Item("TglValidasi").ToString <> "" Then
                'Me.Panel2.Enabled = False
                Me.lblTg1.Text = dr.Item("TglValidasi").ToString
                Me.lblHrga.Text = dr.Item("Hrga_Head").ToString & " / " & dr.Item("NamaHrga").ToString
                Me.txtCatatanHrga.Text = dr.Item("CatatanHrga").ToString
                Me.btnSetujuHrga.Visible = False
                Me.btRevisiHrga.Visible = False
                If CBool(dr.Item("PersetujuanHrga").ToString) = True Then
                    Me.ckHrgaSetuju.Checked = True
                ElseIf CBool(dr.Item("PersetujuanHrga").ToString) = False Then
                    Me.ckHrgaTidakSetuju.Checked = True
                End If
            End If
            'Persetujuan PM/HRGA
            If dr.Item("ProjectManager").ToString <> "" Then
                'Me.Panel2.Enabled = False
                Me.lblTg2.Text = dr.Item("TglPersetujuanPM").ToString
                Me.lblPM.Text = dr.Item("ProjectManager").ToString & " / " & dr.Item("NamaPM").ToString
                Me.txtCatatanPM.Text = dr.Item("CatatanPM").ToString
                Me.btnSetujuPM.Visible = False
                Me.btRevisiPm.Visible = False
                If CBool(dr.Item("PersetujuanPm").ToString) = True Then
                    Me.ckPmSetuju.Checked = True
                ElseIf CBool(dr.Item("PersetujuanPm").ToString) = False Then
                    Me.ckPmTidakSetuju.Checked = True
                End If

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
            Me.GridView2.Visible = True
        End If

        'Enable Panel1
        If dr.Item("PersetujuanAtasan").ToString <> "" Then
            Me.Panel1.Enabled = False
            If CBool(dr.Item("PersetujuanAtasan").ToString) = True Then
                'Me.Panel2.Visible = True
                '-------------------------------xxxxxxxxxxxxxx
                If dr.Item("HR_Officer").ToString <> "" Then
                    If CBool(dr.Item("PersetujuanHr").ToString) = False Then
                        Me.Panel2.Visible = False
                    Else
                        Me.Panel2.Visible = True
                    End If

                Else
                    Me.Panel2.Visible = False
                    Me.Panel3.Visible = False
                End If
                '----------------------------------------xxxxxxxxxxxx
            ElseIf CBool(dr.Item("PersetujuanAtasan").ToString) = False Then
                'Me.Panel2.Visible = False
                Me.Panel4.Visible = False
            End If

            'Enable Panel2 
            If (dr.Item("Golongan").ToString) <= 18 Then
                'Golongan <= 3....---- golongan 1 - 18 hrga sect. & hrga head---
                If dr.Item("TglValidasi").ToString <> "" Then
                    Me.Panel2.Enabled = False
                    'Me.lblHrSecOrHrDeptHead.Text = "Hrga Dept. Head :"
                    'Me.lblHrOrPm.Text = "Project Manager :"
                    Me.lblHrSecOrHrDeptHead.Text = "Hrga Section Head :"
                    Me.lblHrOrPm.Text = "Hrga Dept. Head :"
                    If CBool(dr.Item("PersetujuanHrga").ToString) = False Then
                        Me.Panel3.Visible = False
                    Else
                        Me.Panel3.Visible = True
                    End If
                    'Enable Panel3
                    If dr.Item("ProjectManager").ToString <> "" Then
                        Me.Panel3.Enabled = False
                        'Proses Personnel---->>
                    Else  'diganti dari hrga ke pm'.. kagak jadi....
                        'If InStr(1, Session("jabatan").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("jabatan").ToString, "Project Manager") > 0 Then
                        If InStr(1, Session("jabatan").ToString, "HRPGA DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRPGA Dept. Head") > 0 Then
                            Me.Panel3.Enabled = True
                            'ElseIf InStr(1, Session("ndPosisi").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("ndPosisi").ToString, "Project Manager") > 0 Then
                        ElseIf InStr(1, Session("ndPosisi").ToString, "HRPGA DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRPGA Dept. Head") > 0 Then
                            Me.Panel3.Enabled = True
                        Else
                            Me.Panel3.Enabled = False
                        End If
                    End If
                Else  'diganti dari hrga sect ke hrga head'.... kagak jadi....
                    ''If InStr(1, Session("jabatan").ToString, "HRPGA DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRPGA Dept. Head") > 0 Then
                    If InStr(1, Session("jabatan").ToString, "HRPGA SECT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRPGA Sect. Head") > 0 Then
                        Me.Panel2.Enabled = True
                        'ElseIf InStr(1, Session("ndPosisi").ToString, "HRPGA DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRPGA Dept. Head") > 0 Then
                    ElseIf InStr(1, Session("ndPosisi").ToString, "HRPGA SECT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRPGA Sect. Head") > 0 Then
                        Me.Panel2.Enabled = True
                    Else
                        Me.Panel2.Enabled = False
                        Me.btnSetujuHrga.Visible = False
                        Me.btRevisiHrga.Visible = False
                    End If
                End If

            ElseIf (dr.Item("Golongan").ToString) >= 19 Then
                'Golongan > 3... golongan 19 up....
                Me.lblHrSecOrHrDeptHead.Text = "Hrga Dept. Head :"
                Me.lblHrOrPm.Text = "Project Manager :"
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
                '-----------------------------
            End If
        Else
            Me.Panel4.Visible = False
            If InStr(1, Jabatan, "DEPT. HEAD") > 0 Or InStr(1, Jabatan, "Dept. Head") > 0 Then
                If InStr(1, Session("jabatan").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("jabatan").ToString, "Project Manager") > 0 Then
                    Me.Panel1.Enabled = True
                ElseIf InStr(1, Session("ndPosisi").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("ndPosisi").ToString, "Project Manager") > 0 Then
                    Me.Panel1.Enabled = True
                Else
                    Me.Panel1.Enabled = False
                End If
            Else
                If Trim(dr.Item("Departemen").ToString) = Trim(Session("dept").ToString) Then
                    If InStr(1, Session("jabatan").ToString, "DEPT. HEAD") > 0 Then
                        Me.Panel1.Enabled = True
                    ElseIf InStr(1, Session("jabatan").ToString, "Dept. Head") > 0 Then
                        Me.Panel1.Enabled = True
                    ElseIf InStr(1, Session("ndPosisi").ToString, "DEPT. HEAD") > 0 Then
                        Me.Panel1.Enabled = True
                    ElseIf InStr(1, Session("ndPosisi").ToString, "Dept. Head") > 0 Then
                        Me.Panel1.Enabled = True
                    Else
                        Me.Panel1.Enabled = False
                    End If
                Else
                    Me.Panel1.Enabled = False
                End If
            End If

        End If
        con.Close()
    End Sub

    Protected Sub btnSetuju_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetuju.Click
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
                            & " [PersetujuanAtasan]=@PersetujuanAtasan" _
                            & ",[NrpAtasan]=@NrpAtasan" _
                            & ",[TglPersetujuan]=Getdate()" _
                            & ",[Catatan]=@Catatan" _
                            & " Where NomorST = @NomorST"

            .Parameters.Add("@PersetujuanAtasan", SqlDbType.Bit)
            .Parameters.Add("@NrpAtasan", SqlDbType.VarChar, 10)
            .Parameters.Add("@Catatan", SqlDbType.VarChar, 200)
            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)

            If Me.ckSetuju.Checked = True Then
                .Parameters("@PersetujuanAtasan").Value = True
            Else
                .Parameters("@PersetujuanAtasan").Value = False
            End If
            .Parameters("@NrpAtasan").Value = Session("userid").ToString
            .Parameters("@NomorST").Value = Me.lblNomor.Text
            .Parameters("@Catatan").Value = Me.txtCatatan.Text

            .ExecuteNonQuery()
            con.Close()

            Dim csname1 As String = "PopupScript"
            Dim cstype As Type = Me.GetType()

            ' Get a ClientScriptManager reference from the Page class.
            Dim cs As ClientScriptManager = Page.ClientScript

            ' Check to see if the startup script is already registered.
            If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

                Dim cstext1 As String = "alert('Surat cuti telah tersimpan...    ');"
                cstext1 += "location='dCuti.aspx?n=" & Me.lblNomor.Text & "'"
                cs.RegisterStartupScript(cstype, csname1, cstext1, True)

            End If
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
                            & " [PersetujuanHrga]=@PersetujuanHrga" _
                            & ",[Hrga_Head]=@Hrga_Head" _
                            & ",[TglValidasi]=Getdate()" _
                            & ",[CatatanHrga]=@CatatanHrga" _
                            & " Where NomorST = @NomorST"

            .Parameters.Add("@PersetujuanHrga", SqlDbType.Bit)
            .Parameters.Add("@Hrga_Head", SqlDbType.VarChar, 10)
            .Parameters.Add("@CatatanHrga", SqlDbType.VarChar, 200)
            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)

            If Me.ckHrgaSetuju.Checked = True Then
                .Parameters("@PersetujuanHrga").Value = True
            Else
                .Parameters("@PersetujuanHrga").Value = False
            End If
            .Parameters("@Hrga_Head").Value = Session("userid").ToString
            .Parameters("@NomorST").Value = Me.lblNomor.Text
            .Parameters("@CatatanHrga").Value = Me.txtCatatanHrga.Text

            

            .ExecuteNonQuery()
            con.Close()

            Dim csname1 As String = "PopupScript"
            Dim cstype As Type = Me.GetType()

            ' Get a ClientScriptManager reference from the Page class.
            Dim cs As ClientScriptManager = Page.ClientScript

            ' Check to see if the startup script is already registered.
            If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

                Dim cstext1 As String = "alert('Surat cuti telah tersimpan...    ');"
                cstext1 += "location='dCuti.aspx?n=" & Me.lblNomor.Text & "'"
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
                            & " [PersetujuanPm]=@PersetujuanPm" _
                            & ",[ProjectManager]=@PM" _
                            & ",[TglPersetujuanPM]=Getdate()" _
                            & ",[CatatanPM]=@CatatanPM" _
                            & " Where NomorST = @NomorST"

            .Parameters.Add("@PersetujuanPm", SqlDbType.Bit)
            .Parameters.Add("@PM", SqlDbType.VarChar, 10)
            .Parameters.Add("@CatatanPM", SqlDbType.VarChar, 200)
            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)

            If Me.ckPmSetuju.Checked = True Then
                .Parameters("@PersetujuanPm").Value = True
            Else
                .Parameters("@PersetujuanPm").Value = False
            End If
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

                Dim cstext1 As String = "alert('Surat cuti telah tersimpan...    ');"
                cstext1 += "location='dCuti.aspx?n=" & Me.lblNomor.Text & "'"
                cs.RegisterStartupScript(cstype, csname1, cstext1, True)

            End If
        End With

    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVerifikasi.Click
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
                            & " [PersetujuanHr]=@PersetujuanHr" _
                            & ",[HR_Officer]=@HR_Officer" _
                            & ",[VerifikasiHr]=@VerifikasiHr" _
                            & ",[TglVerifikasi]=Getdate()" _
                            & ",[PV]=@cutikhusus" _
                            & " Where NomorST = @NomorST"

            .Parameters.Add("@PersetujuanHr", SqlDbType.Bit)
            .Parameters.Add("@HR_Officer", SqlDbType.VarChar, 10)
            .Parameters.Add("@VerifikasiHr", SqlDbType.VarChar, 200)
            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)
            .Parameters.Add("@cutikhusus", SqlDbType.VarChar, 1)

            If Me.ckHrSetuju.Checked = True Then
                .Parameters("@PersetujuanHr").Value = True
            Else
                .Parameters("@PersetujuanHr").Value = False
            End If
            .Parameters("@HR_Officer").Value = Session("userid").ToString
            .Parameters("@VerifikasiHr").Value = Me.txtVerifikasiHr.Text
            .Parameters("@NomorST").Value = Me.lblNomor.Text

            ''======kode cuti khusus======
            If Me.Hari1.Checked = False And Me.Hari2.Checked = False And Me.Melahirkan.Checked = False And Me.Haji.Checked = False Then
                .Parameters("@cutikhusus").Value = "A"   'tidak ada cuti khusus'
            ElseIf Me.Hari1.Checked = True And Me.Hari2.Checked = False And Me.Melahirkan.Checked = False And Me.Haji.Checked = False Then
                .Parameters("@cutikhusus").Value = "B"   'KOMPENSASI 1 HARI'
            ElseIf Me.Hari1.Checked = False And Me.Hari2.Checked = True And Me.Melahirkan.Checked = False And Me.Haji.Checked = False Then
                .Parameters("@cutikhusus").Value = "C"   'KOMPENSASI 2 HARI'
            ElseIf Me.Hari1.Checked = False And Me.Hari2.Checked = False And Me.Melahirkan.Checked = True And Me.Haji.Checked = False Then
                .Parameters("@cutikhusus").Value = "D"   'KOMPENSASI MELAHIRKAN 90 HARI'
            ElseIf Me.Hari1.Checked = False And Me.Hari2.Checked = False And Me.Melahirkan.Checked = False And Me.Haji.Checked = True Then
                .Parameters("@cutikhusus").Value = "E"   'KOMPENSASI HAJI 40 HARI'
            End If
            ''=======end off cuti khusus ======

            .ExecuteNonQuery()
            con.Close()
            Response.Redirect("dCuti.aspx?n=" & Me.lblNomor.Text)
        End With
    End Sub

    Public libur As Boolean = False
    Sub CheckHariLibur(ByVal _temp)
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
            .CommandText = "Select * From tblHariLibur Where Tanggal Between @Tanggal And @Tanggal "

            .Parameters.Add("@Tanggal", SqlDbType.DateTime)
            .Parameters("@Tanggal").Value = _temp
            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            libur = True
        Else
            libur = False
        End If
        con.Close()

    End Sub
End Class
