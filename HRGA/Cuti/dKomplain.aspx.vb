Imports System.Data
Imports System.Data.SqlClient

Partial Class _dKomplain
    Inherits System.Web.UI.Page
    Dim TotLapangan As Integer
    Dim TotTahunan As Integer
    Dim TotBesar As Integer
    Dim TotPerjalanan As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./cuti/dKomplain.aspx?n=" & Request.QueryString("n").ToString
            Response.Redirect("../login.aspx")
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
            .CommandText = "Select Nrp, Nama, Jabatan, Departemen, StatusPenerimaan, (Select Nrp From vw_tblKaryawan Where Nrp = '" & Session("userid").ToString & "') AS Nrp1, (Select Nama From vw_tblKaryawan Where Nrp = '" & Session("userid").ToString & "') AS Nama1, (Select Jabatan From vw_tblKaryawan Where Nrp = '" & Session("userid").ToString & "') AS Jabatan1, (Select Departemen From vw_tblKaryawan Where Nrp = '" & Session("userid").ToString & "') AS Departemen1 From vw_tblKaryawan Where Nrp = @Nrp"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = lblNrp.Text
            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Me.lblNama.Text = dr.Item("Nama").ToString
            Me.lblJabatan.Text = dr.Item("Jabatan").ToString & " / " & dr.Item("Departemen").ToString '& " / " & dr.Item("Golongan").ToString

            Me.lblNrp1.Text = dr.Item("Nrp1").ToString
            Me.lblJabatan1.Text = dr.Item("Jabatan1").ToString & " / " & dr.Item("Departemen1").ToString
            Me.lblNama1.Text = dr.Item("Nama1").ToString

            

        Else
            Me.lblNama.Text = ""
            Me.lblJabatan.Text = ""

            Me.lblNrp1.Text = ""
            Me.lblJabatan1.Text = ""
            Me.lblNama1.Text = ""
        End If
        con.Close()

        StatusKomplain()

    End Sub

    Sub StatusKomplain()
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
            .CommandText = "Select (Select COUNT(*) FROM tblSutu where Keperluan='KOMPLAIN' AND Nrp=@Nrp) AS Total, (Select COUNT(*) FROM tblSutu where Keperluan='KOMPLAIN' AND Status NOT IN ('Completed','Riject') AND Nrp=@Nrp) AS SOpen, (Select COUNT(*) FROM tblSutu where Keperluan='KOMPLAIN' AND Status='Completed' AND Nrp=@Nrp) AS SClose"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = lblNrp.Text
            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Me.lblTotalKomplain.Text = dr.Item("Total").ToString
            Me.lblOpen.Text = dr.Item("SOpen").ToString
            Me.lblClose.Text = dr.Item("SClose").ToString
            'Me.lblTotal.Text = dr.Item("Total").ToString

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
            .Parameters("@Keperluan").Value = "KOMPLAIN"
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
                        & "tblSutu.Hotel, tblSutu.UPD, tblSutu.JP3U, tblSutu.Taxi_Bus, tblSutu.B_Lain2, tblSutu.PeriodeTugas, tblSutu.Uang_Muka, tblSutu.PV, tblSutu.AlamatCuti, tblSutu.Keterangan, " _
                        & "tblSutu.NomorST_Lama, tblSutu.ID, tblSutu.SisaCuti_Tahunan, tblSutu.PersetujuanAtasan, tblSutu.PersetujuanHr, tblSutu.TglVerifikasi, tblSutu.VerifikasiHr, tblSutu.NrpAtasan, tblSutu.TglPersetujuan, tblSutu.Catatan, " _
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
            Me.lblDibuatOleh.Text = dr.Item("DibuatOleh").ToString & " (" & Format(dr.Item("tglST"), "dd MMMM yyyy").ToString & ")"
            Me.lblNrp.Text = dr.Item("Nrp").ToString
            Me.lblNomor.Text = dr.Item("NomorST").ToString
            Me.txtKeterangan.Text = dr.Item("Keterangan").ToString
			Me.txtSolusi.Text = dr.Item("AlamatCuti").ToString
            Me.txtPIC.Text = dr.Item("Tujuan").ToString
            'Me.lblNrp1.Text = dr.Item("PeriodeTugas").ToString

            If dr.Item("PersetujuanAtasan").ToString <> "" Then
                If CBool(dr.Item("PersetujuanAtasan").ToString) = True Then
                    Me.ckSetuju.Checked = True
                ElseIf CBool(dr.Item("PersetujuanAtasan").ToString) = False Then
                    Me.ckTidakSetuju.Checked = True
                End If
            End If

            Me.btSave.Visible = False
            '----------

            'Me.txtTujuan.Text = dr.Item("Tujuan").ToString
            Me.txtKeterangan.Text = dr.Item("Keterangan").ToString
			Me.txtSolusi.Text = dr.Item("AlamatCuti").ToString
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
            If dr.Item("TglPersetujuan").ToString <> "" Then
                'Me.Panel2.Enabled = False
                Me.lblTg1.Text = dr.Item("TglValidasi").ToString
                Me.lblHrga.Text = dr.Item("NrpAtasan").ToString & " / " & dr.Item("NamaAtasan").ToString
                Me.txtCatatanHrga.Text = dr.Item("Catatan").ToString
                Me.btnSetujuHrga.Visible = False
                Me.btnRevisi.Visible = False
            End If
            'Persetujuan PM/HRGA
            If dr.Item("PersetujuanHr").ToString <> "" Then
                'Me.Panel2.Enabled = False
                Me.lblTg2.Text = dr.Item("TglVerifikasi").ToString
                Me.lblPM.Text = dr.Item("HR_Officer").ToString & " / " & dr.Item("NamaHR_Officer").ToString
                Me.txtCatatanPM.Text = dr.Item("VerifikasiHr").ToString
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

        'Golongan <= 3.... golongan 1 - 18...
        If dr.Item("TglPersetujuan").ToString <> "" Then
            Me.PanelAtasan.Enabled = False
            Me.PanelHRPGA.Visible = True
            'Enable Panel3
            If dr.Item("HR_Officer").ToString <> "" Then
                Me.PanelHRPGA.Enabled = False
                'Proses Personnel---->>
            Else  'rubah dari hrga head ke pm'... gak sido..
                If InStr(1, Session("jabatan").ToString, "HCGS & FAT DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HCGS & FAT DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HCGS SECT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HCGS Sect. Head") > 0 Then
                    Me.PanelHRPGA.Enabled = True
                    Me.txtPIC.Enabled = True
                ElseIf InStr(1, Session("ndPosisi").ToString, "HCGS & FAT DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HCGS & FAT Dept. Head") > 0 Or InStr(1, Session("ndPosisi").ToString, "HCGS SECT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HCGS Sect. Head") > 0 Then
                    Me.PanelHRPGA.Enabled = True
                    Me.txtPIC.Enabled = True

                ElseIf InStr(1, Session("Dept").ToString, "HCGS") > 0 And InStr(1, Session("Company").ToString, "KPP") > 0 Then
                    Me.PanelHRPGA.Enabled = True
                    Me.txtPIC.Enabled = True

                Else
                    Me.PanelHRPGA.Enabled = False
                End If
            End If
        Else  'rubah dari hrga sect ke hrga head '.. gak sido...
            If (Trim(dr.Item("Departemen").ToString) = Trim(Session("dept").ToString)) Then
                If InStr(1, Session("jabatan").ToString, "DEPT. HEAD") > 0 Then
                    Me.PanelAtasan.Enabled = True
                    Me.txtPIC.Enabled = True
                ElseIf InStr(1, Session("jabatan").ToString, "Dept. Head") > 0 Then
                    Me.PanelAtasan.Enabled = True
                    Me.txtPIC.Enabled = True
                ElseIf InStr(1, Session("ndPosisi").ToString, "DEPT. HEAD") > 0 Then
                    Me.PanelAtasan.Enabled = True
                    Me.txtPIC.Enabled = True
                ElseIf InStr(1, Session("ndPosisi").ToString, "Dept. Head") > 0 Then
                    Me.PanelAtasan.Enabled = True
                    Me.txtPIC.Enabled = True

                ElseIf InStr(1, Session("jabatan").ToString, "SECT. HEAD") > 0 Then
                    Me.PanelAtasan.Enabled = True
                    Me.txtPIC.Enabled = True
                ElseIf InStr(1, Session("jabatan").ToString, "Sect. Head") > 0 Then
                    Me.PanelAtasan.Enabled = True
                    Me.txtPIC.Enabled = True
                ElseIf InStr(1, Session("ndPosisi").ToString, "SECT. HEAD") > 0 Then
                    Me.PanelAtasan.Enabled = True
                    Me.txtPIC.Enabled = True
                ElseIf InStr(1, Session("ndPosisi").ToString, "Sect. Head") > 0 Then
                    Me.PanelAtasan.Enabled = True
                    Me.txtPIC.Enabled = True

                ElseIf Session("Golongan").ToString >= 19 Then
                    Me.PanelAtasan.Enabled = True
                    Me.txtPIC.Enabled = True
                Else
                    Me.PanelAtasan.Enabled = False
                    Me.btnSetujuHrga.Visible = False
                End If
            End If
        End If


        con.Close()

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
                            & ",[Tujuan]=@PIC" _
                            & ",[Keperluan]=@Keperluan" _
                            & ",[Keterangan]=@Keterangan" _
                            & " Where NomorST = @NomorST"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 50)
            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)
            .Parameters.Add("@PIC", SqlDbType.VarChar, 30)
            .Parameters.Add("@Keperluan", SqlDbType.VarChar, 30)
            .Parameters.Add("@Keterangan", SqlDbType.VarChar, 50)

            .Parameters("@Nrp").Value = Me.lblNrp.Text
            .Parameters("@NomorST").Value = Me.lblNomor.Text
            .Parameters("@PIC").Value = Me.txtPIC.Text
            .Parameters("@Keperluan").Value = "KOMPLAIN"
            .Parameters("@Keterangan").Value = Me.txtKeterangan.Text

            .ExecuteNonQuery()
            con.Close()

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
                            & " [PersetujuanAtasan]=@PersetujuanAtasan" _
                            & ", [NrpAtasan]=@Hrga_Head" _
                            & ",[TglPersetujuan]=Getdate()" _
                            & ",[Catatan]=@CatatanHrga" _
                            & ",[Tujuan]=@PIC" _
                            & " Where NomorST = @NomorST"

            .Parameters.Add("@PersetujuanAtasan", SqlDbType.Bit)
            .Parameters.Add("@Hrga_Head", SqlDbType.VarChar, 10)
            .Parameters.Add("@CatatanHrga", SqlDbType.VarChar, 50)
            .Parameters.Add("@PIC", SqlDbType.VarChar, 30)
            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)

            If Me.ckSetuju.Checked = True Then
                .Parameters("@PersetujuanAtasan").Value = True
            Else
                .Parameters("@PersetujuanAtasan").Value = False
            End If
            .Parameters("@Hrga_Head").Value = Session("userid").ToString
            .Parameters("@NomorST").Value = Me.lblNomor.Text
            .Parameters("@PIC").Value = Me.txtPIC.Text
            .Parameters("@CatatanHrga").Value = Me.txtCatatanHrga.Text

            .ExecuteNonQuery()
            con.Close()

            Dim csname1 As String = "PopupScript"
            Dim cstype As Type = Me.GetType()

            ' Get a ClientScriptManager reference from the Page class.
            Dim cs As ClientScriptManager = Page.ClientScript

            ' Check to see if the startup script is already registered.
            If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

                Dim cstext1 As String = "alert('Surat Komplain telah tersimpan...    ');"
                cstext1 += "location='dKomplain.aspx?n=" & Me.lblNomor.Text & "'"
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
                            & " [PersetujuanHr]=@PersetujuanHr" _
                            & ", [HR_Officer]=@HR" _
                            & ",[TglVerifikasi]=Getdate()" _
                            & ",[VerifikasiHr]=@VerHR" _
                            & ",[Tujuan]=@PIC" _
                            & " Where NomorST = @NomorST"

            .Parameters.Add("@PersetujuanHr", SqlDbType.Bit)
            .Parameters.Add("@HR", SqlDbType.VarChar, 10)
            .Parameters.Add("@VerHR", SqlDbType.VarChar, 50)
            .Parameters.Add("@PIC", SqlDbType.VarChar, 30)
            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)

            .Parameters("@PersetujuanHr").Value = True
            .Parameters("@HR").Value = Session("userid").ToString
            .Parameters("@VerHR").Value = Me.txtCatatanPM.Text
            .Parameters("@PIC").Value = Me.txtPIC.Text
            .Parameters("@NomorST").Value = Me.lblNomor.Text

            .ExecuteNonQuery()
            con.Close()

            Dim csname1 As String = "PopupScript"
            Dim cstype As Type = Me.GetType()

            ' Get a ClientScriptManager reference from the Page class.
            Dim cs As ClientScriptManager = Page.ClientScript

            ' Check to see if the startup script is already registered.
            If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

                Dim cstext1 As String = "alert('Surat Komplain telah tersimpan...    ');"
                cstext1 += "location='dKomplain.aspx?n=" & Me.lblNomor.Text & "'"
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

            Response.Redirect("pKomplain.aspx?n=" & Me.lblNomor.Text)
        End With

    End Sub
End Class
