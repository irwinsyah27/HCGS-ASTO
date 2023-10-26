Imports System.Data
Imports System.Data.SqlClient
'Imports System.Web.Mail
Partial Class _fCuti1
    Inherits System.Web.UI.Page
    Dim TotLapangan As Integer
    Dim TotPerjalananAwal As Integer
    Dim TotTahunan As Integer
    Dim TotBesar As Integer
    Dim TotPerjalanan As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./cuti/fCuti1.aspx"
            Response.Redirect("../login.aspx")
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
            .CommandText = "Select Nrp, Nama, Jabatan, Golongan, Departemen, StatusPenerimaan, StatusKawin, StatusBawaKeluarga, AlamatTinggal, Telepon  From vw_tblKaryawan Where Nrp = @Nrp"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = txtNrp.Text
            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Dim csname1 As String = "PopupScript"
            Dim csname2 As String = "ButtonClickScript"
            Dim cstype As Type = Me.GetType()
            Dim cs As ClientScriptManager = Page.ClientScript

            '--------
			If Session("Admin").ToString <> "Admin" AND Session("Jabatan").ToString <> "KORLAP" AND Session("Jabatan").ToString <> "HAULING GL" Then
            
            If dr.Item("Departemen").ToString <> Session("Dept").ToString Then
                If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                    Dim cstext1 As String = "alert('Hanya diijinkan input cuti karyawan departemen " & Session("Dept").ToString & " ');"
                    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                    Exit Sub
                End If
			End If
            End If

            If dr.Item("StatusPenerimaan").ToString <> "LOKAL" And dr.Item("StatusPenerimaan").ToString <> "LS" And dr.Item("StatusPenerimaan").ToString <> "KIRIMAN" Then
                If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                    Dim cstext1 As String = "alert('Hanya diijinkan input cuti karyawan KPP Group  ');"
                    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                    Exit Sub
                End If
            End If
            Session("jabatan01") = UCase((dr.Item("Jabatan").ToString))
            '            -------

            Me.lblNama.Text = dr.Item("Nama").ToString
            'Me.lblPemohon.Text = dr.Item("Nama").ToString
            Me.lblJabatan.Text = dr.Item("Jabatan").ToString & " / " & dr.Item("Departemen").ToString '& " / " & dr.Item("Golongan").ToString
            Me.lblStatusPenerimaan.Text = dr.Item("StatusPenerimaan").ToString
            Me.lblStatusKawin.Text = dr.Item("StatusKawin").ToString
            Me.lblAlamatdiSite.Text = dr.Item("AlamatTinggal").ToString
            Me.lblNoTelp.Text = dr.Item("Telepon").ToString

			 If dr.Item("StatusBawaKeluarga").ToString = True Then
                Me.lblBawaKeluarga.Text = "Ya"
                Me.RangeValidator1.MaximumValue = 14
                Me.RangeValidator1.ErrorMessage = "Cuti Lapangan yang bisa diambil maksimal : 14 hari. "
            Else
                Me.lblBawaKeluarga.Text = "Tidak"
				
				If dr.Item("Jabatan") = "DEPUTY PROJECT MANAGER" Or dr.Item("Jabatan") = "PROJECT MANAGER"
					 Me.RangeValidator1.MaximumValue = 10
                     Me.RangeValidator1.ErrorMessage = "Cuti Lapangan yang bisa diambil maksimal : 10 hari. "
				Else
					
					If (Left(dr.Item("Nrp").ToString, 2) = "KR") 'Lokal
						Me.RangeValidator1.MaximumValue = 14
                        Me.RangeValidator1.ErrorMessage = "Cuti Lapangan yang bisa diambil maksimal : 14 hari. "
					Else
						Me.RangeValidator1.MaximumValue = 14
                        Me.RangeValidator1.ErrorMessage = "Cuti Lapangan yang bisa diambil maksimal : 14 hari "
					End If
				End If 
            End If

        Else
                Me.lblNama.Text = ""
                Me.lblJabatan.Text = ""
                Me.lblStatusPenerimaan.Text = ""
                Me.lblStatusKawin.Text = ""
                Me.lblBawaKeluarga.Text = ""
                If Me.txtNrp.Text <> "" Then
                    Dim csname1 As String = "PopupScript"
                    Dim csname2 As String = "ButtonClickScript"
                    Dim cstype As Type = Me.GetType()
                    Dim cs As ClientScriptManager = Page.ClientScript

                    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                        Dim cstext1 As String = "alert('Nrp " & Me.txtNrp.Text & " tidak ditemukan di data karyawan...    ');"
                        cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                    End If
                End If
        End If
        con.Close()

        '---------------Cuti --------------
            'CutiPerjalananAwal()
            CutiLapangan()
            CutiTahunan()
            CutiBesar()
            CutiPerjalanan()
            CutiTotal()
            PeriodeTugas()
        AwalCutiTahunan()
        'MasaDinas()

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
            Me.txtLapangan.Text = 0
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
            .Parameters("@Nrp").Value = txtNrp.Text
            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Me.txtTahunan.Enabled = True
            Me.lblSisaCuti1.Text = dr.Item("SisaCuti1").ToString
            Me.lblSisaCuti2.Text = dr.Item("SisaCuti2").ToString
            Me.lblCutiBesar.Text = dr.Item("SisaCutiBesar").ToString
            Me.lblTotal.Text = CInt(dr.Item("Total").ToString) + CInt(dr.Item("SisaCutiBesar").ToString)
            If Me.txtTahunan.Text <> "" And dr.Item("Total").ToString <> "" Then
                Me.lblSisaCuti.Text = dr.Item("Total").ToString - txtTahunan.Text
                TotTahunan = txtTahunan.Text
                If (dr.Item("Total").ToString - txtTahunan.Text) < 0 Then
                    Me.lblSisaCuti.ForeColor = Drawing.Color.Red
                    Me.lblHariCTahunan.ForeColor = Drawing.Color.Red
                    RangeValidator1.MaximumValue = dr.Item("Total").ToString
                    RangeValidator1.ErrorMessage = "Cuti tahunan tinggal : " & dr.Item("Total").ToString & " hari"
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
        con.Close()

    End Sub

    Sub CutiBesar()
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
            Me.lblSisaCutiBesar.Text = dr.Item("SisaCutiBesar").ToString
            If Me.ckBesar.Checked = True Then
                Me.txtBesar.Enabled = True
                If txtBesar.Text <> "" Then
                    TotBesar = txtBesar.Text
                    Me.lblSisaCutiBesar.Text = CInt(Me.lblCutiBesar.Text) - CInt(Me.txtBesar.Text)
                Else
                    TotBesar = 0
                End If
            Else
                Me.txtBesar.Enabled = False
                Me.txtBesar.Text = 0
            End If
        End If
        con.Close()

    End Sub
	
	   
    Sub CutiPerjalanan()
        If Me.ckPerjalanan.Checked = True Then
		     Me.txtPerjalanan.Enabled = True
			 If txtPerjalanan.Text <> "" Then
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
        con.Close()

    End Sub

    Sub AwalCutiTahunan()
        Dim AwalCTahunan As DateTime
        Dim temp1 As DateTime

        Dim i As Integer
        If Me.txtAwal.Text <> "" Then
            AwalCTahunan = txtAwal.Text
           AwalCTahunan = AwalCTahunan.AddDays(CInt(Me.txtLapangan.Text) + 1)
            'AwalCTahunan = AwalCTahunan.AddDays(Me.txtPerjalananAwal.Text)

            temp1 = Format(AwalCTahunan, "dd MMM yyyy")

            If Me.txtTahunan.Text <> "0" Or Me.txtBesar.Text <> "0" Then
                'Response.Write("tahunan")
                Do While i < CInt(Me.txtTahunan.Text) + CInt(Me.txtBesar.Text)
                    CheckHariLibur(temp1)
                    If temp1.DayOfWeek <> DayOfWeek.Sunday Then
                        i += 1
                        If libur = True Then
                            i = i - 1
                        End If
                    End If
                    'Response.Write(temp1 & " " & libur & "<BR>")
                    temp1 = temp1.AddDays(1)

                Loop
				if Me.txtPerjalanan.Text <> "0" then 'penghitungan NRP lokal tanpa perjalanan
					temp1 = temp1.AddDays(CInt(Me.txtPerjalanan.Text)-1)	
                end if					
                'Response.Write("tahunan2222")
                Me.txtAkhir.Text = Format(Format(temp1.AddDays(-1), "dd MMM yyyy"))
            Else
                'Response.Write("tahunan3333")
                Me.txtAkhir.Text = Format(CDate(txtAwal.Text).AddDays(CInt(Me.txtLapangan.Text) - 1 + CInt(Me.txtPerjalanan.Text)), "dd MMM yyyy")
            End If
        End If
        ' ''Dim AwalCTahunan As DateTime
        ' ''Dim temp1 As DateTime

        ' ''Dim i As Integer
        ' ''If Me.txtAwal.Text <> "" Then
        ' ''    AwalCTahunan = txtAwal.Text
        ' ''    If Me.txtPerjalanan.Text <> "0" Then
        ' ''        AwalCTahunan = AwalCTahunan.AddDays(CInt(Me.txtLapangan.Text) + 1)
        ' ''    Else
        ' ''        AwalCTahunan = AwalCTahunan.AddDays(Me.txtLapangan.Text)
        ' ''    End If

        ' ''    temp1 = Format(AwalCTahunan, "dd MMM yyyy")

        ' ''    If Me.txtTahunan.Text <> "0" Or Me.txtBesar.Text <> "0" Then
        ' ''        Do While i < CInt(Me.txtTahunan.Text) + CInt(Me.txtBesar.Text)
        ' ''            CheckHariLibur(temp1)
        ' ''            If temp1.DayOfWeek <> DayOfWeek.Sunday Then
        ' ''                i += 1
        ' ''                If libur = True Then
        ' ''                    i = i - 1
        ' ''                End If
        ' ''            End If
        ' ''            'Response.Write(temp1 & " " & libur & "<BR>")
        ' ''            temp1 = temp1.AddDays(1)

        ' ''        Loop
        ' ''        If Me.txtPerjalanan.Text = 0 Then
        ' ''            Me.txtAkhir.Text = Format(Format(temp1.AddDays(-1), "dd MMM yyyy"))
        ' ''        Else
        ' ''            Me.txtAkhir.Text = Format(Format(temp1, "dd MMM yyyy"))
        ' ''        End If
        ' ''    Else
        ' ''        Me.txtAkhir.Text = Format(CDate(txtAwal.Text).AddDays(CInt(Me.txtLapangan.Text) - 1 + CInt(Me.txtPerjalanan.Text)), "dd MMM yyyy")
        ' ''    End If
        ' ''End If
    End Sub

    Protected Sub btSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btSave.Click
        Session("Nrp") = Me.txtNrp.Text
        Session("Tanggal") = Format(Date.Today.Date, "dd MMM yyyy")
		
				
		Dim maxCuti As Integer = 10
		Dim maxOnsite As Integer = 10
		Dim jumlahCuti As Integer = 0
		Dim jumlahOnsite As Integer = 0
        Dim StatusPenerimaan As String = ""
		
		Dim con1 As SqlClient.SqlConnection = Nothing
        Dim con2 As SqlClient.SqlConnection = Nothing
        Dim con3 As SqlClient.SqlConnection = Nothing
        Dim con4 As SqlClient.SqlConnection = Nothing
        Dim cmd1 As SqlClient.SqlCommand = Nothing
        Dim cmd2 As SqlClient.SqlCommand = Nothing
        Dim cmd3 As SqlClient.SqlCommand = Nothing
        Dim cmd4 As SqlClient.SqlCommand = Nothing


        Dim dr1 As SqlDataReader
        Dim dr2 As SqlDataReader
        Dim dr3 As SqlDataReader
        Dim dr4 As SqlDataReader

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        cmd1 = New SqlClient.SqlCommand
        con1 = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)
        cmd2 = New SqlClient.SqlCommand
        con2 = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)
        cmd3 = New SqlClient.SqlCommand
        con3 = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)
		cmd4 = New SqlClient.SqlCommand
        con4 = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)
        'VALIDASI CUTI
		
		con1.open()
			 with cmd1
				.Connection = con1
				.CommandType = CommandType.Text
				.CommandText = "SELECT count(*) as jumlah FROM [tblSutu] WHERE KEPERLUAN = 'CUTI' AND AWAL = @tgl AND (Status = 'Complete' or status = 'HCGS & FAT Dept. Head' or Status = 'HCGS Sect. Head') and nrp not like 'kr%'"
				.Parameters.Add("@tgl", SqlDbType.Date)
				.Parameters("@tgl").Value = Format(CDate(Me.txtAwal.Text), "yyyy-MM-dd")
				dr1 = .ExecuteReader
			 End With
			 
			  If dr1.Read = True  Then  
			  
				jumlahCuti = dr1.Item("jumlah")
				  
			  End If
        con1.close()
			  
			  
	    'VALIDASI ONSITE
		
		con2.open()
			 with cmd2
				.Connection = con2
				.CommandType = CommandType.Text
				.CommandText = "SELECT count(*) as jumlah FROM [tblSutu] WHERE KEPERLUAN = 'CUTI' AND AKHIR = @tgl AND  (Status = 'Complete' or status = 'HCGS & FAT Dept. Head' or Status = 'HCGS Sect. Head') and nrp not like 'kr%'"
				.Parameters.Add("@tgl", SqlDbType.Date)
				.Parameters("@tgl").Value = Format(CDate(Me.txtAkhir.Text), "yyyy-MM-dd")
				dr2 = .ExecuteReader
			 End With
			 
			  If dr2.Read = True  Then  
			  
				jumlahOnsite = dr2.Item("jumlah")
			  
			  End If
        con2.close()

        con3.open()
			 with cmd3
				.Connection = con3
				.CommandType = CommandType.Text
				.CommandText = "SELECT *  FROM [tblKaryawan] WHERE nrp = @Nrp"
			    .Parameters.Add("@Nrp", SqlDbType.VarChar, 50)
				.Parameters("@Nrp").Value = Me.txtNrp.Text
				dr3 = .ExecuteReader
			 End With
			 
			  If dr3.Read = True  Then  
			  
				StatusPenerimaan = dr3.Item("StatusPenerimaan")
			  
			  End If
        con3.close()

        con4.open()
			 with cmd4
				.Connection = con4
				.CommandType = CommandType.Text
				.CommandText = "select * from tblSutu WHERE KEPERLUAN = 'CUTI' AND nrp = @Nrp AND MONTH(AWAL = @tgl) AND  nrp not like 'kr%'"
				.Parameters.Add("@Nrp", SqlDbType.VarChar, 50)
				.Parameters("@Nrp").Value = Me.txtNrp.Text
                .Parameters.Add("@tgl", SqlDbType.Date)
				.Parameters("@tgl").Value = Format(CDate(Me.txtAwal.Text), "yyyy-MM-dd")
				dr4 = .ExecuteReader
			 End With
			 
			  If dr4.Read = True  Then  
			  
				ValidasiCuti = dr4.Item("Awal")
			  
			  End If
        con4.close()

		If jumlahCuti > maxCuti And Me.txtNrp.Text.Substring(0, 2).ToUpper <> "KR" And Session("Jabatan").ToString <> "PERSONNEL SITE OFFICER" And StatusPenerimaan <> "LS" Then 
		
			Dim csname1 As String = "PopupScript"
			Dim cstype As Type = Me.GetType()
			Dim cs As ClientScriptManager = Page.ClientScript
			
			If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
				Dim cstext2 As String = "alert('Mohon maaf kuota sarana cuti site sudah penuh, Silahkan koordinasi dengan HCGS Dept. !');"
			   cs.RegisterStartupScript(cstype, csname1, cstext2, True)
			End If
			
		Else If jumlahOnsite > maxOnsite And Me.txtNrp.Text.Substring(0, 2).ToUpper <> "KR" And Session("Jabatan").ToString <> "PERSONNEL SITE OFFICER" And StatusPenerimaan <> "LS"  Then
		
			Dim csname1 As String = "PopupScript"
			Dim cstype As Type = Me.GetType()
			Dim cs As ClientScriptManager = Page.ClientScript
		
			If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
				Dim cstext2 As String = "alert('Mohon maaf kuota on site sarana ke site sudah penuh, Silahkan koordinasi dengan HCGS Dept. !');"
			   cs.RegisterStartupScript(cstype, csname1, cstext2, True)
			End If
			
		Else
			
				Dim con As SqlClient.SqlConnection = Nothing
				Dim cmd As SqlClient.SqlCommand = Nothing

				cmd = New SqlClient.SqlCommand

				'Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
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
									& ",[Hari]" _
									& ",[Awal]" _
									& ",[Akhir]" _
									& ",[Transport]" _
									& ",[C_Lapangan]" _
									& ",[C_Tahunan]" _
									& ",[C_Besar]" _
									& ",[C_Perjalanan]" _
									& ",[C_Lain2]" _
									& ",[PeriodeTugas]" _
									& ",[AlamatCuti]" _
									& ",[Keterangan]" _
									& ",[SisaCuti1]" _
									& ",[SisaCuti2]" _
									& ",[SisaCuti3]" _
									& ",[SisaCuti_Tahunan]" _
									& ",[SisaCuti_Besar]" _
									& ",[DibuatOleh]" _
							& ") values (" _
									& "@Nrp" _
									& ",@NomorST" _
									& ",Getdate()" _
									& ",@Tujuan" _
									& ",@Keperluan" _
									& ",@Penginapan" _
									& ",@Hari" _
									& ",@Awal" _
									& ",@Akhir" _
									& ",@Transport" _
									& ",@C_Lapangan" _
									& ",@C_Tahunan" _
									& ",@C_Besar" _
									& ",@C_Perjalanan" _
									& ",@C_Lain2" _
									& ",@PeriodeTugas" _
									& ",@AlamatCuti" _
									& ",@Keterangan" _
									& ",@SisaCuti1" _
									& ",@SisaCuti2" _
									& ",@SisaCuti3" _
									& ",@SisaCuti_Tahunan" _
									& ",@SisaCuti_Besar" _
									& ",@DibuatOleh" _
									& ")"


					.Parameters.Add("@Nrp", SqlDbType.VarChar, 50)
					.Parameters.Add("@NomorST", SqlDbType.VarChar, 20)
					.Parameters.Add("@Tujuan", SqlDbType.VarChar, 20)
					.Parameters.Add("@Keperluan", SqlDbType.VarChar, 30)
					.Parameters.Add("@Penginapan", SqlDbType.VarChar, 50)
					.Parameters.Add("@Hari", SqlDbType.Float)
					.Parameters.Add("@Awal", SqlDbType.DateTime)
					.Parameters.Add("@Akhir", SqlDbType.DateTime)
					.Parameters.Add("@Transport", SqlDbType.VarChar, 20)
					.Parameters.Add("@C_Lapangan", SqlDbType.Int)
					.Parameters.Add("@C_Tahunan", SqlDbType.Int)
					.Parameters.Add("@C_Besar", SqlDbType.Int)
					.Parameters.Add("@C_Perjalanan", SqlDbType.Int)
					.Parameters.Add("@C_Lain2", SqlDbType.Int)
					.Parameters.Add("@PeriodeTugas", SqlDbType.VarChar, 50)
					.Parameters.Add("@AlamatCuti", SqlDbType.VarChar, 50)
					.Parameters.Add("@Keterangan", SqlDbType.VarChar, 200)
					.Parameters.Add("@SisaCuti1", SqlDbType.VarChar, 20)
					.Parameters.Add("@SisaCuti2", SqlDbType.VarChar, 20)
					.Parameters.Add("@SisaCuti3", SqlDbType.VarChar, 20)
					.Parameters.Add("@SisaCuti_Tahunan", SqlDbType.Int)
					.Parameters.Add("@SisaCuti_Besar", SqlDbType.Int)
					.Parameters.Add("@DibuatOleh", SqlDbType.NVarChar, 10)

					.Parameters("@Nrp").Value = Me.txtNrp.Text
					.Parameters("@NomorST").Value = "BARU"
					.Parameters("@Tujuan").Value = Me.txtTujuan.Text
					.Parameters("@Keperluan").Value = "CUTI"
					.Parameters("@Penginapan").Value = ""
					.Parameters("@Hari").Value = Me.txtTotal.Text
					.Parameters("@Awal").Value = Me.txtAwal.Text
					.Parameters("@Akhir").Value = Me.txtAkhir.Text
					.Parameters("@Transport").Value = ""
					If Me.txtLapangan.Text <> "" Then
						.Parameters("@C_Lapangan").Value = Me.txtLapangan.Text
					Else
						.Parameters("@C_Lapangan").Value = 0
					End If
					If Me.txtTahunan.Text <> "" Then
						.Parameters("@C_Tahunan").Value = Me.txtTahunan.Text
					Else
						.Parameters("@C_Tahunan").Value = 0
					End If
					If Me.txtBesar.Text <> "" Then
						.Parameters("@C_Besar").Value = Me.txtBesar.Text
					Else
						.Parameters("@C_Besar").Value = 0
					End If
					If Me.txtPerjalanan.Text <> "" Then
						.Parameters("@C_Perjalanan").Value = Me.txtPerjalanan.Text
					Else
						.Parameters("@C_Perjalanan").Value = 0
					End If

					.Parameters("@C_Lain2").Value = 0 '""
					.Parameters("@PeriodeTugas").Value = Me.lblPeriodeTugas.Text
					.Parameters("@AlamatCuti").Value = Me.txtAlamatCuti.Text
					.Parameters("@Keterangan").Value = Me.txtKeterangan.Text
					.Parameters("@SisaCuti1").Value = Me.lblSisaCuti1.Text
					.Parameters("@SisaCuti2").Value = Me.lblSisaCuti2.Text
					.Parameters("@SisaCuti3").Value = Me.lblCutiBesar.Text
					.Parameters("@SisaCuti_Tahunan").Value = Me.lblSisaCuti.Text
					.Parameters("@SisaCuti_Besar").Value = Me.lblSisaCutiBesar.Text
					.Parameters("@DibuatOleh").Value = Session("userid").ToString

					.ExecuteNonQuery()
					con.Close()

				End With

				'=========pupup=====================
				Dim csname1 As String = "PopupScript"
				Dim csname2 As String = "ButtonClickScript"
				Dim cstype As Type = Me.GetType()

				' Get a ClientScriptManager reference from the Page class.
				Dim cs As ClientScriptManager = Page.ClientScript

				' Check to see if the startup script is already registered.
				If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

					Dim cstext1 As String = "var answer = confirm('Form Cuti telah disimpan, click OK jika perlu Input Flight Fare   ');"
					cstext1 += "if (answer){"
					'cstext1 += "window.open('flightfare.aspx','PopupClass','width=600,height=500,left=200,top=30,scrollbars=no,copyhistory=yes,resizable = yes ')"
					cstext1 += "window.location = 'fCuti2.aspx';"
					cstext1 += "} else {"
					cstext1 += "self.close(); }"
					'cstext1 += "window.location = 'fCuti1.aspx';}"
					cs.RegisterStartupScript(cstype, csname1, cstext1, True)

				End If
			
		
		End If
		

    End Sub

    Protected Sub txtNrp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNrp.TextChanged

        'Dim con As SqlClient.SqlConnection = Nothing
        'Dim cmd As SqlClient.SqlCommand = Nothing
        'Dim dr As SqlDataReader

        'cmd = New SqlClient.SqlCommand

        'Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        'con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        'con.Open()
        'With cmd
        '    .Connection = con
        '    .CommandType = CommandType.StoredProcedure
        '    .CommandText = "sp_dinas_terakhir"

        '    .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
        '    .Parameters("@Nrp").Value = txtNrp.Text
        '    dr = .ExecuteReader
        'End With
        'If dr.Read = True Then
        '    'jika dinas belum berakhir
        '    If CDate(dr.Item("Akhir").ToString) > Date.Now.Date Then
        '        Dim csname1 As String = "PopupScript"
        '        Dim cstype As Type = Me.GetType()
        '        Dim cs As ClientScriptManager = Page.ClientScript
        '        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
        '            Dim cstext1 As String = "var answer = confirm('Dinas baru akan berakhir pada tanggal " & Format(CDate(dr.Item("Akhir").ToString), "dd MMM yyyy") & ", anda yakin akan mengajukan cuti..? ');"
        '            cstext1 += "if (answer){"
        '            'cstext1 += "window.open('flightfare.aspx','PopupClass','width=600,height=500,left=200,top=30,scrollbars=no,copyhistory=yes,resizable = yes ')"
        '            'cstext1 += "window.location = 'fCuti2.aspx';"
        '            cstext1 += "} else {"
        '            cstext1 += "self.close(); }"
        '            'cstext1 += "window.location = 'fCuti1.aspx';}"
        '            cs.RegisterStartupScript(cstype, csname1, cstext1, True)

        '        End If
        '    End If

        '    Me.lblPeriodeTugas.Text = Format(CDate(dr.Item("Awal").ToString), "dd MMM yyyy") & " s/d " & Format(CDate(dr.Item("Akhir").ToString), "dd MMM yyyy")
        'Else
        '    Me.lblPeriodeTugas.Text = ""
        'End If
        'con.Close()

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

    Sub CutiTerakhir()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim dr As SqlDataReader
        Dim tHari As Integer = 0

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_cuti_terakhir"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = txtNrp.Text
            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            'jika dinas belum berakhir
            If Me.txtAwal.Text <> "" Then
                If CDate(dr.Item("Awal").ToString) = CDate(Me.txtAwal.Text) Then 'Date.Now.Date Then
                    Dim csname1 As String = "PopupScript"
                    Dim cstype As Type = Me.GetType()
                    Dim cs As ClientScriptManager = Page.ClientScript
                    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                        Dim cstext1 As String = "var answer = confirm('Cuti ini telah diajukan sebelumnya, mohon direject cuti sebelumnya " & Format(CDate(dr.Item("Akhir").ToString), "dd MMM yyyy") & ", anda yakin akan mengajukan cuti..? ');"
                        cstext1 += "if (answer){"
                        'cstext1 += "window.open('flightfare.aspx','PopupClass','width=600,height=500,left=200,top=30,scrollbars=no,copyhistory=yes,resizable = yes ')"
                        'cstext1 += "window.location = 'fCuti2.aspx';"
                        cstext1 += "} else {"
                        cstext1 += "self.close(); }"
                        'cstext1 += "window.location = 'fCuti1.aspx';}"
                        cs.RegisterStartupScript(cstype, csname1, cstext1, True)

                    End If
                    tHari = DateDiff(DateInterval.Day, CDate(dr.Item("Awal").ToString), CDate(Me.txtAwal.Text))
                    CutiProporsional(tHari)
                End If
                Me.txtLapangan.ReadOnly = True
                Me.lblPeriodeTugas.Text = Format(CDate(dr.Item("Awal").ToString), "dd MMM yyyy") & " s/d " & Format(CDate(dr.Item("Akhir").ToString), "dd MMM yyyy")
            Else
                Me.txtLapangan.ReadOnly = False
                Me.lblPeriodeTugas.Text = ""
            End If
            con.Close()
        End If
    End Sub

    Sub MasaDinas()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim dr As SqlDataReader
        Dim tHari As Integer = 0

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
            'jika dinas belum berakhir
            If Me.txtAwal.Text <> "" Then
                If CDate(dr.Item("Akhir").ToString) >= CDate(Me.txtAwal.Text) Then 'Date.Now.Date Then
                    Dim csname1 As String = "PopupScript"
                    Dim cstype As Type = Me.GetType()
                    Dim cs As ClientScriptManager = Page.ClientScript
                    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                        Dim cstext1 As String = "var answer = confirm('Cuti lapangan akan dihitung proporsional jika masa dinas belum selesai. Masa Dinas anda baru akan berakhir pada tanggal " & Format(CDate(dr.Item("Akhir").ToString), "dd MMM yyyy") & ", anda yakin akan mengajukan cuti..? ');"
                        cstext1 += "if (answer){"
                        'cstext1 += "window.open('flightfare.aspx','PopupClass','width=600,height=500,left=200,top=30,scrollbars=no,copyhistory=yes,resizable = yes ')"
                        'cstext1 += "window.location = 'fCuti2.aspx';"
                        cstext1 += "} else {"
                        cstext1 += "self.close(); }"
                        'cstext1 += "window.location = 'fCuti1.aspx';}"
                        cs.RegisterStartupScript(cstype, csname1, cstext1, True)

                    End If
                    tHari = DateDiff(DateInterval.Day, CDate(dr.Item("Awal").ToString), CDate(Me.txtAwal.Text))
                    CutiProporsional(tHari)
                End If
                Me.txtLapangan.ReadOnly = True
                Me.lblPeriodeTugas.Text = Format(CDate(dr.Item("Awal").ToString), "dd MMM yyyy") & " s/d " & Format(CDate(dr.Item("Akhir").ToString), "dd MMM yyyy")
            Else
                Me.txtLapangan.ReadOnly = False
                Me.lblPeriodeTugas.Text = ""
            End If
            con.Close()
        End If
    End Sub

    Sub CutiProporsional(ByVal t As Integer)
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
           .CommandText = "Select Nrp, Nama, Jabatan, Golongan, Departemen, StatusPenerimaan, StatusKawin, StatusBawaKeluarga, AlamatTinggal, Telepon  From vw_tblKaryawan Where Nrp = @Nrp"
    
           .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
           .Parameters("@Nrp").Value = txtNrp.Text
           dr = .ExecuteReader
       End With
       If dr.Read = True Then
           Dim c As Double = 0
           
       End If
       con.Close()
    
    End Sub
'    Sub CutiProporsional(ByVal t As Integer)
'        Dim con As SqlClient.SqlConnection = Nothing
'        Dim cmd As SqlClient.SqlCommand = Nothing
'        Dim dr As SqlDataReader
'
'        cmd = New SqlClient.SqlCommand
'
'        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
'        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)
'
'        con.Open()
'        With cmd
'            .Connection = con
'            .CommandType = CommandType.Text
'            .CommandText = "Select Nrp, Nama, Jabatan, Golongan, Departemen, StatusPenerimaan, StatusKawin, StatusBawaKeluarga, AlamatTinggal, Telepon  From vw_tblKaryawan Where Nrp = @Nrp"
'
'            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
'            .Parameters("@Nrp").Value = txtNrp.Text
'            dr = .ExecuteReader
'        End With
'        If dr.Read = True Then
'            Dim c As Double = 0
'            If dr.Item("StatusBawaKeluarga").ToString = True Then
'                c = CDbl(t / (84 + 1) * 8)
'                If InStr(1, CStr(c), ",") > 0 Then
'                    c = Left(c, InStr(1, CStr(c), ",") - 1)
'                End If
'                Me.lblBawaKeluarga.Text = "Ya"
'                Me.RangeValidator1.MaximumValue = c
'                Me.RangeValidator1.ErrorMessage = "Cuti Lapangan yang bisa diambil maksimal : " & c & " hari. "
'            Else
'                Me.lblBawaKeluarga.Text = "Tidak"
'                If Left(dr.Item("Nrp").ToString, 2) = "1F" Then
'                    c = CDbl(t / (84 + 1) * 8)
'                    If InStr(1, CStr(c), ",") > 0 Then
'                        c = Left(c, InStr(1, CStr(c), ",") - 1)
'                    End If
'                    Me.RangeValidator1.MaximumValue = c
'                    Me.RangeValidator1.ErrorMessage = "Cuti Lapangan yang bisa diambil maksimal : " & c & " hari. "
'                Else
'                    If Left(dr.Item("Golongan").ToString, 1) >= 1 And  Left(dr.Item("Golongan").ToString, 1) < 3 Then
'                        c = CDbl(t / (84 + 1) * 14)
'                        If InStr(1, CStr(c), ",") > 0 Then
'                            c = Left(c, InStr(1, CStr(c), ",") - 1)
'                        End If
'                        Me.RangeValidator1.MaximumValue = c
'                        Me.RangeValidator1.ErrorMessage = "Cuti Lapangan yang bisa diambil maksimal : " & c & " hari. "
'
'                    ElseIf Left(dr.Item("Golongan").ToString, 1) >= 3 And Left(dr.Item("Golongan").ToString, 1) <= 4 Then
'                        c = CDbl(t / (56 + 1) * 12)
'                        If InStr(1, CStr(c), ",") > 0 Then
'                            c = Left(c, InStr(1, CStr(c), ",") - 1)
'                        End If
'                        Me.RangeValidator1.MaximumValue = c
'                        Me.RangeValidator1.ErrorMessage = "Cuti Lapangan yang bisa diambil maksimal : " & c & " hari. "
'
'                    ElseIf Left(dr.Item("Golongan").ToString, 1) = 5 Then
'                        If InStr(1, dr.Item("Jabatan").ToString, "MANAGER") > 0 Then
'                            c = CDbl(t / (42 + 1) * 10)
'                            If InStr(1, CStr(c), ",") > 0 Then
'                                c = Left(c, InStr(1, CStr(c), ",") - 1)
'                            End If
'                            Me.RangeValidator1.MaximumValue = c
'                            Me.RangeValidator1.ErrorMessage = "Cuti Lapangan yang bisa diambil maksimal : " & c & " hari. "
'                        Else
'                            c = CDbl(t / (56 + 1) * 12)
'                            If InStr(1, CStr(c), ",") > 0 Then
'                                c = Left(c, InStr(1, CStr(c), ",") - 1)
'                            End If
'                            Me.RangeValidator1.MaximumValue = c
'                            Me.RangeValidator1.ErrorMessage = "Cuti Lapangan yang bisa diambil maksimal : " & c & " hari. "
'                        End If
'                    End If
'                End If
'
'            End If
'        End If
'        con.Close()
'
'    End Sub

    Protected Sub txtAwal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAwal.TextChanged
        Dim AwalCTahunan1 As DateTime
        AwalCTahunan1 = Me.txtAwal.Text
        AwalCTahunan1 = AwalCTahunan1.AddDays(-13)

        'If (Date.Compare(Date.Now(), CDate(Me.txtAwal.Text))) >= 4 Then
        If CDate(Date.Now()) >= CDate(AwalCTahunan1) Then
            Dim csname11 As String = "PopupScript"
            Dim cstype1 As Type = Me.GetType()
           Dim cs1 As ClientScriptManager = Page.ClientScript
            'If (Not cs1.IsStartupScriptRegistered(cstype1, csname11) AND Session("Jabatan").ToString <> "ICT OFFICER") Then
                Dim cstext11 As String = "alert('Awal cuti hanya bisa dinput, max. 14 hari sebelum waktu cuti....harap hubungi Dept. HCGS..');"
                'cstext1 += "self.close();"
                Me.txtAwal.Text = ""
                Me.txtAkhir.Text = ""
                cs1.RegisterStartupScript(cstype1, csname11, cstext11, True)
                'MasaDinas()
                'Exit Sub
            'End If
            MasaDinas()
        End If
        MasaDinas()
    End Sub

    Sub cekhari()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim dr As SqlDataReader
        Dim tHari As Integer = 0

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
            'jika dinas belum berakhir
            If Me.txtAwal.Text <> "" Then
                If CDate(dr.Item("Akhir").ToString) >= CDate(Me.txtAwal.Text) Then 'Date.Now.Date Then
                    Dim csname1 As String = "PopupScript"
                    Dim cstype As Type = Me.GetType()
                    Dim cs As ClientScriptManager = Page.ClientScript
                    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                        Dim cstext1 As String = "var answer = confirm('Cuti lapangan akan dihitung proporsional jika masa dinas belum selesai. Masa Dinas anda baru akan berakhir pada tanggal " & Format(CDate(dr.Item("Akhir").ToString), "dd MMM yyyy") & ", anda yakin akan mengajukan cuti..? ');"
                        cstext1 += "if (answer){"
                        'cstext1 += "window.open('flightfare.aspx','PopupClass','width=600,height=500,left=200,top=30,scrollbars=no,copyhistory=yes,resizable = yes ')"
                        'cstext1 += "window.location = 'fCuti2.aspx';"
                        cstext1 += "} else {"
                        cstext1 += "self.close(); }"
                        'cstext1 += "window.location = 'fCuti1.aspx';}"
                        cs.RegisterStartupScript(cstype, csname1, cstext1, True)

                    End If
                    tHari = DateDiff(DateInterval.Day, CDate(dr.Item("Awal").ToString), CDate(Me.txtAwal.Text))
                    CutiProporsional(tHari)
                End If
                Me.txtLapangan.ReadOnly = True
                Me.lblPeriodeTugas.Text = Format(CDate(dr.Item("Awal").ToString), "dd MMM yyyy") & " s/d " & Format(CDate(dr.Item("Akhir").ToString), "dd MMM yyyy")
            Else
                Me.txtLapangan.ReadOnly = False
                Me.lblPeriodeTugas.Text = ""
            End If
            con.Close()
        End If
    End Sub
End Class
