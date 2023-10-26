Imports System.Data
Imports System.Data.SqlClient
Partial Class HRGA_fIjin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DataKaryawan()
        If Me.txtAwal.Text <> "" Then
		
		
		'VALIDASI DI HILANGKAN 2018-04-05
		
            'If DateDiff(DateInterval.Day, CDate(Me.txtAwal.Text), Date.Today.Date) > 7 AND (InStr(1, Session("jabatan").ToString, "PERSONNEL SITE OFFICER") = 0 And InStr(1, Session("jabatan").ToString, "PERSONNEL OFFICER") = 0 And InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") = 0 And InStr(1, Session("ndPosisi").ToString, "PERSONNEL SITE OFFICER") = 0 And InStr(1, Session("ndPosisi").ToString, "PERSONNEL OFFICER") = 0 And InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") = 0 And InStr(1, Session("Admin").ToString, "Admin") = 0) Then
                'Dim csname1 As String = "PopupScript"
                'Dim cstype As Type = Me.GetType()

                'Dim cs As ClientScriptManager = Page.ClientScript

                'If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

                   ' Dim cstext1 As String = "alert('Hanya bisa dibuat maksimal 7 hari setelah tanggal dilaksanakan ijin...    ');"
                    'cstext1 += "location='fijin.aspx';"
                    'cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                    'Me.txtAwal.Text = ""
                    'Me.txtAkhir.Text = ""
                'End If
            'End If
        Else
            Me.txtAkhir.Text = ""
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn1.Click
        Save()
    End Sub

    Sub Save()
		Dim con2 As SqlClient.SqlConnection = Nothing
        Dim cmd2 As SqlClient.SqlCommand = Nothing
        Dim dr2 As SqlDataReader
		Dim SisaCuti as String

        cmd2 = New SqlClient.SqlCommand

        Dim connectionStrings2 As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con2 = New SqlClient.SqlConnection(connectionStrings2("persisConnectionString").ConnectionString)

        con2.Open()
        With cmd2
            .Connection = con2
            .CommandType = CommandType.Text
            .CommandText = "Select Nrp,Nama,Departemen,SisaCuti = SisaCutiPeriode1 + SisaCutiPeriode2 From tblKaryawan Where Nrp = @Nrp"
            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = Me.txtNrp.Text
            dr2 = .ExecuteReader
        End With
        If dr2.Read = True Then
          SisaCuti = dr2.Item("SisaCuti").ToString     
        End If
	
	
	
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim Kode As String = Nothing
        If Me.RadioButton2.Checked = True Then
            Kode = "H"
        ElseIf Me.RadioButton3.Checked = True Then
            Kode = "G"
        Else
            Kode = ""
        End If
        cmd = New SqlClient.SqlCommand
		
		
		

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Insert Into tblIjin " _
                            & "([NoIjin]" _
                            & ",[Nrp]" _
                            & ",[Awal]" _
                            & ",[Akhir]" _
                            & ",[Keperluan]" _
                            & ",[Kode]" _
                            & ",[Requestor]" _
							& ",[SisaCuti]" _
                    & ") values (" _
                            & " @NoIjin" _
                            & ",@Nrp" _
                            & ",@Awal" _
                            & ",@Akhir" _
                            & ",@Keperluan" _
                            & ",@Kode" _
                            & ",@Requestor" _
							& ",@SisaCuti" _
                            & ")"

            .Parameters.Add("@NoIjin", SqlDbType.VarChar, 19)
            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters.Add("@Awal", SqlDbType.DateTime)
            .Parameters.Add("@Akhir", SqlDbType.DateTime)
            .Parameters.Add("@Keperluan", SqlDbType.VarChar, 50)
            .Parameters.Add("@Kode", SqlDbType.VarChar, 1)
            .Parameters.Add("@Requestor", SqlDbType.VarChar, 10)
			.Parameters.Add("@SisaCuti", SqlDbType.VarChar, 3)

            .Parameters("@NoIjin").Value = "BARU"
            .Parameters("@Nrp").Value = Me.txtNrp.Text
            .Parameters("@Awal").Value = Me.txtAwal.Text
            .Parameters("@Akhir").Value = Me.txtAkhir.Text
            .Parameters("@Keperluan").Value = Me.txtKeperluan.Text
            .Parameters("@Kode").Value = Kode
            .Parameters("@Requestor").Value = Session("userid")
			.Parameters("@SisaCuti").Value = SisaCuti

            .ExecuteNonQuery()
        End With
        NomorTerakhir()
    End Sub
    Sub NomorTerakhir()
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
            .CommandText = "Select Top 1 NoIjin From tblIjin Order By Tanggal Desc "
            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Dim csname1 As String = "PopupScript"
            Dim csname2 As String = "ButtonClickScript"
            Dim cstype As Type = Me.GetType()

            Dim cs As ClientScriptManager = Page.ClientScript

            If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

                Dim cstext1 As String = "alert('Form ijin telah tersimpan...    ');"
                cstext1 += "window.location = 'dIjin.aspx?n=" & dr.Item("NoIjin").ToString & "';"
                'cstext1 += "self.close();"
                'cstext1 += "location='lstTugas.aspx'"            
                cs.RegisterStartupScript(cstype, csname1, cstext1, True)

            End If
        End If
    End Sub

    Sub DataKaryawan()
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
            .CommandText = "Select Nrp,Nama,Departemen,StatusKawin,StatusKeluarga,SisaCutiPeriode1,SisaCutiPeriode2,SisaCuti = SisaCutiPeriode1 + SisaCutiPeriode2 ,StatusBawaKeluarga = Case StatusBawaKeluarga When 1 Then 'YA' Else 'TIDAK' End  From tblKaryawan Where Nrp = @Nrp"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = Me.txtNrp.Text

            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Dim csname1 As String = "PopupScript"
            Dim csname2 As String = "ButtonClickScript"
            Dim cstype As Type = Me.GetType()
            Dim cs As ClientScriptManager = Page.ClientScript

            Me.lblNama.Text = dr.Item("Nama").ToString
            Me.lblDepartemen.Text = dr.Item("Departemen").ToString
            Me.lblSisaCuti.Text = dr.Item("SisaCuti").ToString & " hari"
            If dr.Item("Departemen").ToString <> Session("Dept").ToString AND (InStr(1, Session("jabatan").ToString, "PERSONNEL SITE OFFICER") = 0 And InStr(1, Session("jabatan").ToString, "PERSONNEL OFFICER") = 0 And InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") = 0 And InStr(1, Session("ndPosisi").ToString, "PERSONNEL SITE OFFICER") = 0 And InStr(1, Session("ndPosisi").ToString, "PERSONNEL OFFICER") = 0 And InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") = 0 And InStr(1, Session("Jabatan").ToString, "KORLAP") = 0 And InStr(1, Session("Jabatan").ToString, "KORLAP MBAP") = 0 And InStr(1, Session("Jabatan").ToString, "KORLAP GNI") = 0 And InStr(1, Session("Jabatan").ToString, "KORLAP SIGAP") = 0) Then
                If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                    Dim cstext1 As String = "alert('Hanya diijinkan input karyawan departemen " & Session("Dept").ToString & " ');"
                    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                    Me.txtNrp.Text = ""
                    Me.lblNama.Text = ""
                    Me.lblDepartemen.Text = ""
                End If
            End If
            'If Me.txtAwal.Text <> "" And Me.txtAkhir.Text <> "" Then
            '    If DateDiff(DateInterval.Day, CDate(Me.txtAwal.Text), CDate(Me.txtAkhir.Text)) + 1 > CInt(dr.Item("SisaCuti").ToString) Then
            '        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
            '            Dim cstext1 As String = "alert('Jumlah cuti tahunan tersisa " & dr.Item("SisaCuti").ToString & " hari ');"
            '            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
            '            Me.txtAwal.Text = ""
            '            Me.txtAkhir.Text = ""
            '        End If
            '    End If
            'End If

        Else
            If Me.txtNrp.Text <> "" Then
                Dim csname1 As String = "PopupScript"
                Dim csname2 As String = "ButtonClickScript"
                Dim cstype As Type = Me.GetType()
                Dim cs As ClientScriptManager = Page.ClientScript

                If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                    Dim cstext1 As String = "alert('Nrp " & Me.txtNrp.Text & " tidak ditemukan di data karyawan...    ');"
                    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                    Me.txtNrp.Text = ""
                    Me.lblNama.Text = ""
                    Me.lblDepartemen.Text = ""
                End If
                Me.lblNama.Text = ""
                Me.lblDepartemen.Text = ""
            End If
        End If
        If Me.txtNrp.Text <> "" And Me.txtAwal.Text <> "" And Me.txtAkhir.Text <> "" And (Me.RadioButton1.Checked = True Or Me.RadioButton2.Checked = True Or Me.RadioButton3.Checked = True) Then
            Me.btn1.Enabled = True
        Else
            Me.btn1.Enabled = False
        End If
    End Sub
End Class
