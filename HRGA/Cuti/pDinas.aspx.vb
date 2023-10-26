Imports System.Data
Imports System.Data.SqlClient
'Imports System.Web.Mail
Partial Class _pDinas
    Inherits System.Web.UI.Page
    Dim TotLapangan As Integer
    Dim TotTahunan As Integer
    Dim TotBesar As Integer
    Dim TotPerjalanan As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./cuti/pDinas.aspx?n=" & Request.QueryString("n").ToString
            Response.Redirect("../login.aspx")
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
            cstext2.Append("window.open('rCuti.aspx?n=" & Request.QueryString("n").ToString & "','PopupClass','width=515,height=310,left=330,top=300')} </")
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

        'CutiTahunan()
        PeriodeTugas()

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
            'Me.lblSisaCuti1.Text = dr.Item("SisaCuti1").ToString
            'Me.lblSisaCuti2.Text = dr.Item("SisaCuti2").ToString
            'Me.lblCutiBesar.Text = dr.Item("SisaCutiBesar").ToString
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
                      & "tblSutu.Hotel, tblSutu.UPD, tblSutu.JP3U, tblSutu.Taxi_Bus, tblSutu.B_Lain2, tblSutu.Uang_Muka, tblSutu.PV, tblSutu.AlamatCuti, tblSutu.Keterangan, " _
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
            If dr.Item("HR_Officer").ToString = "" Then
                Dim csname1 As String = "PopupScript"
                Dim cstype As Type = Me.GetType()
                Dim cs As ClientScriptManager = Page.ClientScript
                If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                    Dim cstext1 As String = ""
                    'If dr.Item("PersetujuanAtasan").ToString = False Then
                    '    cstext1 = "alert('  Form cuti tidak disetujui atasan...    ');self.close()"
                    '    GoTo x
                    'If dr.Item("PersetujuanAtasan").ToString = "" Then
                    '    cstext1 = "alert('  Form cuti diproses atasan...    ');self.close()"
                    '    GoTo x
                    If dr.Item("HRGA_Head").ToString = "" Then
                        cstext1 = "alert('  Surat dinas diproses Hrga Section...    ');self.close()"
                        GoTo x
                    ElseIf dr.Item("ProjectManager").ToString = "" Then
                        cstext1 = "alert('  Surat dinas diproses PM / Hrga Dept. Head...    ');self.close()"
                        GoTo x
                    Else
                        'cstext1 = "alert('  Surat dinas diproses Personalia...    ');self.close()"
                    End If
                    'If dr.Item("HR_Officer").ToString = "" Then cstext1 = "alert('  Form cuti diproses atasan...    ');self.close()"
                    'Response.Write(dr.Item("PersetujuanAtasan").ToString)
x:
                    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                End If
            End If


            Me.lblNrp.Text = dr.Item("Nrp").ToString
            Me.lblNomor.Text = dr.Item("NomorST").ToString
            Me.txtTujuan.Text = dr.Item("Tujuan").ToString
            Me.txtPenginapan.Text = dr.Item("Penginapan").ToString

            Me.txtAwal.Text = Format(CDate(dr.Item("Awal").ToString), "dd MMM yyyy")
            Me.txtAkhir.Text = Format(CDate(dr.Item("Akhir").ToString), "dd MMM yyyy")
            Me.txtKeterangan.Text = dr.Item("Keterangan").ToString
            Me.lblPersonnelAdmin.Text = dr.Item("HR_Officer").ToString
            'Me.lblJabatan1.Text = "(" & dr.Item("JabatanPM").ToString & ")"
            'Me.lblJabatan2.Text = "(" & dr.Item("JabatanHrga").ToString & ")"
            Me.lblPersonnelAdmin.Text = dr.Item("NamaHR_Officer").ToString
            'Me.lblJabatan3.Text = "(" & dr.Item("JabatanHROfficer").ToString & ")"

            If dr.Item("NamaHR_Officer").ToString <> "" Then
                Me.lblPersonnelAdmin.Text = dr.Item("NamaHR_Officer").ToString
                Me.lblJabatan3.Text = "(" & dr.Item("JabatanHROfficer").ToString & ")"
                Me.imgSignAdmin.ImageUrl = "images/sign/" & dr.Item("HR_Officer").ToString & ".jpg"
            End If
            'Validasi HRGA
            If dr.Item("TglValidasi").ToString <> "" Then
                'Me.lblHrga.Text = dr.Item("NamaHrga").ToString
                If dr.Item("Hrga_Head").ToString = "6104018" Then
                    Me.imgSignHrga.ImageUrl = "images/sign/6104018.jpg"
                Else
                    Me.imgForHrga.ImageUrl = "images/sign/for.jpg"
                    Me.imgSignHrga.ImageUrl = "images/sign/" & dr.Item("Hrga_Head").ToString & ".jpg"
                End If
            End If
            'Persetujuan PM/HRGA
            If dr.Item("ProjectManager").ToString <> "" Then
                'Me.lblPM.Text = dr.Item("NamaPM").ToString
                If dr.Item("ProjectManager").ToString = "0192069" Then
                    Me.imgSignHrga.ImageUrl = "images/sign/0192069.jpg"
                Else
                    Me.imgForPm.ImageUrl = "images/sign/for.jpg"
                    Me.imgSignPm.ImageUrl = "images/sign/" & dr.Item("ProjectManager").ToString & ".jpg"
                End If
            End If

        End If
        con.Close()

    End Sub
End Class
