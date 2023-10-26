Imports System.Data
Imports System.Data.SqlClient
'Imports System.Web.Mail
Partial Class _dCuti
    Inherits System.Web.UI.Page
    Dim TotLapangan As Integer
    Dim TotTahunan As Integer
    Dim TotBesar As Integer
    Dim TotPerjalanan As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
            cs.RegisterClientScriptBlock(cstype, csname2, cstext2.ToString(), False)

        End If

        If Session("userid") = "" Then
            Response.Redirect("./")
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
        ''---------------Cuti --------------
        CutiLapangan()
        CutiTahunan()
        CutiBesar()
        CutiPerjalanan()
        CutiTotal()
        'PeriodeTugas()
        AwalCutiTahunan()

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
            .CommandText = "sp_sisa_cuti"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = lblNrp.Text
            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Me.txtTahunan.Enabled = True
            Me.lblSisaCuti1.Text = dr.Item("SisaCuti1").ToString
            Me.lblSisaCuti2.Text = dr.Item("SisaCuti2").ToString
            Me.lblSisaCutiBesar.Text = dr.Item("SisaCutiBesar").ToString
            Me.lblTotal.Text = dr.Item("Total").ToString
            If Me.txtTahunan.Text <> "" And dr.Item("Total").ToString <> "" Then
                Me.lblSisaCuti.Text = dr.Item("Total").ToString - txtTahunan.Text
                TotTahunan = txtTahunan.Text
                'RangeValidator1.MaximumValue = dr.Item("Total").ToString
                'RangeValidator1.ErrorMessage = "Cuti tahunan tinggal : " & dr.Item("Total").ToString & " hari"
                If (dr.Item("Total").ToString - txtTahunan.Text) < 0 Then
                    Me.lblSisaCuti.ForeColor = Drawing.Color.Red
                    Me.lblHariCTahunan.ForeColor = Drawing.Color.Red
                Else
                    Me.lblSisaCuti.ForeColor = Drawing.Color.Black
                    Me.lblHariCTahunan.ForeColor = Drawing.Color.Black
                End If
            Else
                Me.lblSisaCuti.Text = dr.Item("Total").ToString
                TotTahunan = 0
            End If

        Else

        End If
        If Me.ckTahunan.Checked = True Then
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

            If Me.txtTahunan.Text <> "0" Then
                Do While i < CInt(Me.txtTahunan.Text) + CInt(Me.txtBesar.Text)
                    If temp1.DayOfWeek <> DayOfWeek.Sunday Then
                        i += 1
                    End If
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
            '.CommandText = "Select tblSutu.*, tblKaryawan.Nama As NamaAtasan, tblKaryawan.Nama As Nama_Hrga From tblSutu Left Join tblKaryawan On tblSutu.NrpAtasan = tblKaryawan.Nrp Where NomorST = @NomorST "
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
            Me.lblPersonnelAdmin.Text = dr.Item("HR_Officer").ToString & " / " & dr.Item("NamaHR_Officer").ToString

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
            'Validasi HRGA
            If dr.Item("TglValidasi").ToString <> "" Then
                'Me.Panel2.Enabled = False
                Me.lblTg1.Text = dr.Item("TglValidasi").ToString
                Me.lblHrga.Text = dr.Item("Hrga_Head").ToString & " / " & dr.Item("NamaHrga").ToString
                Me.txtCatatanHrga.Text = dr.Item("CatatanHrga").ToString
                Me.btnSetujuHrga.Visible = False
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
            Me.GridView2.Visible = True
        End If

        'Enable Panel1
        If dr.Item("PersetujuanAtasan").ToString <> "" Then
            Me.Panel1.Enabled = False
            Me.Panel2.Visible = True
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
                    'Response.Write("1 " & Session("ndPosisi").ToString)

                    If InStr(1, Session("jabatan").ToString, "SECT. HEAD") > 0 Then
                        Me.Panel2.Enabled = True
                    ElseIf InStr(1, Session("ndPosisi").ToString, "SECT. HEAD") > 0 Then
                        'Response.Write(InStr(1, Session("ndPosisi").ToString, "SECT. HEAD"))
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
                        ElseIf InStr(1, Session("ndPosisi").ToString, "PROJECT MANAGER") > 0 Then
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
                '-----------------------------
            End If
        Else
            If Trim(dr.Item("Departemen").ToString) = Trim(Session("dept").ToString) Then
                'Response.Write("1 " & Session("ndPosisi").ToString)
                If InStr(1, Session("jabatan").ToString, "DEPT. HEAD") > 0 Then
                    Response.Write("1 " & Session("ndPosisi").ToString)
                    Me.Panel1.Enabled = True
                ElseIf InStr(1, Session("ndPosisi").ToString, "DEPT. HEAD") > 0 Then
                    Me.Panel1.Enabled = True
                Else
                    Me.Panel1.Enabled = False
                End If
            Else
                Me.Panel1.Enabled = False
            End If
        End If

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
            .Parameters.Add("@Catatan", SqlDbType.VarChar, 50)
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

                Dim cstext1 As String = "alert('Surat cuti telah tersimpan...    ');"
                cstext1 += "location='dCuti.aspx?n=" & Me.lblNomor.Text & "'"
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

            Response.Redirect("pCuti.aspx?n=" & Me.lblNomor.Text)
        End With
    End Sub
End Class
