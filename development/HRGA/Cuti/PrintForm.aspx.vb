Imports Microsoft.Reporting.WebForms
Imports System.Data
Imports System.Data.SqlClient

Partial Class HRGA_Cuti_PrintForm
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.ReportViewer1.ShowParameterPrompts = False
        Dim y As String = ""
        y = UCase(Request.QueryString("n").ToString)

        If UCase(Right(y, 2)) = "SC" Then
            ReportViewer1.ServerReport.ReportPath = "/hrga/Form_Cuti_PER_NOMOR"
        ElseIf Right(y, 2) = "SD" Then
            ReportViewer1.ServerReport.ReportPath = "/hrga/Form_Dinas_Per_Nomor"
        ElseIf Right(y, 2) = "ST" Then
            ReportViewer1.ServerReport.ReportPath = "/hrga/Form_Tugas_Per_Nomor"
        ElseIf Right(y, 2) = "KL" Then
            ReportViewer1.ServerReport.ReportPath = "/hrga/Form_Komplain_Per_Nomor"
	    ElseIf Right(y, 2) = "SI" Then
        ReportViewer1.ServerReport.ReportPath = "/hrga/Ijin_Per_Nomor"
        End If

        Dim No As New ReportParameter("NomorST", y)
        Dim q() As ReportParameter = {No}
        ReportViewer1.ServerReport.SetParameters(q)

        CariSC()

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
            .CommandText = "SELECT     SUBSTRING(tblSutu.NomorST,6,2) AS NC,tblSutu.NomorST, tblSutu.Nrp, vw_tblKaryawan.Nama, tblSutu.tglST, tblSutu.Tujuan, tblSutu.Keperluan, tblSutu.Penginapan, tblSutu.Hari, tblSutu.Awal, " _
                      & "tblSutu.Akhir, tblSutu.Transport, tblSutu.C_Lapangan, tblSutu.C_Tahunan, tblSutu.C_Besar, tblSutu.C_Perjalanan, tblSutu.C_Lain2, tblSutu.Tiket, " _
                      & "tblSutu.Hotel, tblSutu.UPD, tblSutu.JP3U, tblSutu.Taxi_Bus, tblSutu.B_Lain2, tblSutu.PeriodeTugas, tblSutu.Uang_Muka, tblSutu.PV, tblSutu.AlamatCuti, tblSutu.Keterangan, " _
                      & "tblSutu.NomorST_Lama, tblSutu.ID, tblSutu.SisaCuti1, tblSutu.SisaCuti2, tblSutu.SisaCuti3, tblSutu.SisaCuti_Tahunan, tblSutu.SisaCuti_Besar, tblSutu.PersetujuanAtasan, tblSutu.NrpAtasan, tblSutu.TglPersetujuan, tblSutu.Catatan, " _
                      & "tblSutu.HR_Officer, tblSutu.HRGA_Head, tblSutu.TglValidasi, tblSutu.CatatanHrga, tblSutu.ProjectManager, tblSutu.TglPersetujuanPM, tblSutu.CatatanPM, tblSutu.Status, tblSutu.DibuatOleh, " _
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

            
                Dim csname1 As String = "PopupScript"
                Dim cstype As Type = Me.GetType()
                Dim cs As ClientScriptManager = Page.ClientScript
                If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                    Dim cstext1 As String = ""
                    If dr.Item("Status").ToString = "Atasan" Then
                        cstext1 = "alert('  Form "& dr.Item("Keperluan").ToString &" diproses atasan...    ');self.close()"
                        GoTo x
                    End If
                    If dr.Item("PersetujuanAtasan").ToString <> "" Then
                        If dr.Item("PersetujuanAtasan").ToString = False Then
                            cstext1 = "alert('   Form "& dr.Item("Keperluan").ToString &" tidak disetujui atasan...     ');self.close()"
                            GoTo x
                        End If
                    End If
                    If dr.Item("Status").ToString = "HRPGA Sect. Head" OR dr.Item("Status").ToString = "HRPGA Dept" Then
                        cstext1 = "alert('  Form "& dr.Item("Keperluan").ToString &" diproses hrga...    ');self.close()"
                        GoTo x
                    End If
                    If (dr.Item("Status").ToString = "HRPGA Dept. Head" OR dr.Item("Status").ToString = "PM")  AND dr.Item("NC").ToString <> "LS" Then
                        cstext1 = "alert('  Form "& dr.Item("Keperluan").ToString &" diproses PM / HRGA...    ');self.close()"
                        GoTo x
                    END If
					If dr.Item("Status").ToString = "PERSONNEL" AND dr.Item("NC").ToString <> "LS" Then
                        cstext1 = "alert('  Form "& dr.Item("Keperluan").ToString &" diproses Personalia...    ');self.close()"
                    End If
                    'If dr.Item("HR_Officer").ToString = "" Then cstext1 = "alert('  Form "& dr.Item("Keperluan").ToString &" diproses atasan...    ');self.close()"
                    'Response.Write(dr.Item("PersetujuanAtasan").ToString)

x:

                    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                End If

            'Me.lblNrp.Text = dr.Item("Nrp").ToString
            'Me.lblNomor.Text = dr.Item("NomorST").ToString
            'If dr.Item("C_Lapangan").ToString <> "" Then
            '    If dr.Item("C_Lapangan").ToString > 0 Then
            '        Me.txtLapangan.Text = dr.Item("C_Lapangan").ToString
            '        'Me.txtLapangan.Enabled = False
            '        Me.ckLapangan.Checked = True
            '        TotLapangan = dr.Item("C_Lapangan").ToString
            '    End If
            'End If
            'If dr.Item("C_Tahunan").ToString <> "" Then
            '    If dr.Item("C_Tahunan").ToString > 0 Then
            '        Me.txtTahunan.Text = dr.Item("C_Tahunan").ToString
            '        'Me.txtTahunan.Enabled = False
            '        Me.ckTahunan.Checked = True
            '        TotTahunan = dr.Item("C_Tahunan").ToString
            '    End If
            'End If
            'If dr.Item("C_Besar").ToString <> "" Then
            '    If dr.Item("C_Besar").ToString > 0 Then
            '        Me.txtBesar.Text = dr.Item("C_Besar").ToString
            '        'Me.txtBesar.Enabled = False
            '        Me.ckBesar.Checked = True
            '        TotBesar = dr.Item("C_Besar").ToString
            '    End If
            'End If
            'If dr.Item("C_Perjalanan").ToString <> "" Then
            '    If dr.Item("C_Perjalanan").ToString > 0 Then
            '        Me.txtPerjalanan.Text = dr.Item("C_Perjalanan").ToString
            '        'Me.txtPerjalanan.Enabled = False
            '        Me.ckPerjalanan.Checked = True
            '        TotPerjalanan = dr.Item("C_Perjalanan").ToString
            '    End If
            'End If

            'Me.txtTujuan.Text = dr.Item("Tujuan").ToString
            'Me.txtAwal.Text = Format(CDate(dr.Item("Awal").ToString), "dd MMM yyyy")
            'Me.txtAkhir.Text = Format(CDate(dr.Item("Akhir").ToString), "dd MMM yyyy")
            'Me.txtAlamatCuti.Text = dr.Item("AlamatCuti").ToString
            'Me.txtKeterangan.Text = dr.Item("Keterangan").ToString
            'Me.lblSisaCuti1.Text = dr.Item("SisaCuti1").ToString
            'Me.lblSisaCuti2.Text = dr.Item("SisaCuti2").ToString
            'Me.lblCutiBesar.Text = dr.Item("SisaCuti3").ToString
            'Me.lblSisaCuti.Text = dr.Item("SisaCuti_Tahunan").ToString
            'Me.lblSisaCutiBesar.Text = CInt(dr.Item("SisaCuti3").ToString) - CInt(dr.Item("C_Besar").ToString)
            'Me.lblTotal.Text = CInt(dr.Item("SisaCuti_Tahunan").ToString) + CInt(dr.Item("SisaCuti_Besar").ToString) + CInt(dr.Item("C_Tahunan").ToString) + CInt(dr.Item("C_Besar").ToString)
            ''Me.lblPersonnelAdmin.Text = dr.Item("HR_Officer").ToString
            ''Me.lblJabatan1.Text = "(" & dr.Item("JabatanPM").ToString & ")"
            ''Me.lblJabatan2.Text = "(" & dr.Item("JabatanHrga").ToString & ")"

            ''If dr.Item("NamaHR_Officer").ToString <> "" Then
            ''    Me.lblPersonnelAdmin.Text = dr.Item("NamaHR_Officer").ToString
            ''    Me.lblJabatan3.Text = "(" & dr.Item("JabatanHROfficer").ToString & ")"
            ''    Me.imgSignAdmin.ImageUrl = "images/sign/" & dr.Item("HR_Officer").ToString & ".jpg"
            ''End If
            ''Validasi HRGA
            'If dr.Item("TglValidasi").ToString <> "" Then
            '    'Me.lblHrga.Text = dr.Item("NamaHrga").ToString
            '    If dr.Item("Hrga_Head").ToString = "6104018" Then
            '        Me.imgSignHrga.ImageUrl = "images/sign/6104018.jpg"
            '    Else
            '        Me.imgForHrga.ImageUrl = "images/sign/for.jpg"
            '        Me.imgSignHrga.ImageUrl = "images/sign/" & dr.Item("Hrga_Head").ToString & ".jpg"
            '    End If

            'End If
            ''Persetujuan PM/HRGA
            'If dr.Item("ProjectManager").ToString <> "" Then
            '    'Me.lblPM.Text = dr.Item("NamaPM").ToString
            '    Me.GridView2.Columns(0).Visible = False
            '    If dr.Item("ProjectManager").ToString = "0192069" Then
            '        Me.imgSignHrga.ImageUrl = "images/sign/0192069.jpg"
            '    Else
            '        Me.imgForPm.ImageUrl = "images/sign/for.jpg"
            '        Me.imgSignPm.ImageUrl = "images/sign/" & dr.Item("ProjectManager").ToString & ".jpg"
            '    End If
            'End If

        Else
            'Me.btSave.Visible = False
            'Me.GridView2.Visible = True
        End If
        con.Close()

    End Sub

End Class
