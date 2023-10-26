Imports System.Data
Imports System.Data.SqlClient
'Imports System.Web.Mail
Partial Class _fCutiNonKpp
    Inherits System.Web.UI.Page
    Dim TotLapangan As Integer
    Dim TotPerjalananAwal As Integer
    Dim TotTahunan As Integer
    Dim TotBesar As Integer
    Dim TotPerjalanan As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./cuti/fCutiNonKpp.aspx"
            Response.Redirect("../login.aspx")
        End If
       

    End Sub
	
	Protected Sub btSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btSave.Click
		Dim con As SqlClient.SqlConnection = Nothing
		Dim cmd As SqlClient.SqlCommand = Nothing

		cmd = New SqlClient.SqlCommand

			Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
			con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

			con.Open()
			With cmd
				.Connection = con
				.CommandType = CommandType.Text
				.CommandText = "Insert Into tblSutuNonKpp " _
								& "([NRP]" _
							    & ",[NO_ST]" _
								& ",[AWAL]" _
								& ",[AKHIR]" _
								& ",[NAMA]" _
								& ",[COMPANY]" _
								& ",[DEPARTEMEN]" _
								& ",[JABATAN]" _
								& ",[TUJUAN]" _
								& ",[TELEPON]" _
								& ",[MESS]" _
								& ",[STATUS]" _
								& ",[KETERANGAN]" _
								& ",[CREATED_BY]" _
								& ",[CREATED_DATE]" _
						& ") values (" _
								& "@Nrp" _
							    & ",'BARU'" _
								& ",@Awal" _
								& ",@Akhir" _
								& ",@Nama" _
								& ",@Company" _
								& ",@Departemen" _
								& ",@Jabatan" _
								& ",@Tujuan" _
								& ",@Telepon" _
								& ",@Mess" _
								& ",@Status" _
								& ",@Keterangan" _
								& ",@CreatedBy" _
								& ",Getdate()" _
								& ")"


				.Parameters.Add("@Nrp", SqlDbType.VarChar, 50)
				.Parameters.Add("@Awal", SqlDbType.DateTime)
				.Parameters.Add("@Akhir", SqlDbType.DateTime)
				.Parameters.Add("@Nama", SqlDbType.VarChar, 20)
				.Parameters.Add("@Company", SqlDbType.VarChar, 30)
				.Parameters.Add("@Departemen", SqlDbType.VarChar, 50)
				.Parameters.Add("@Jabatan", SqlDbType.VarChar, 50)
				.Parameters.Add("@Tujuan", SqlDbType.VarChar, 50)
				.Parameters.Add("@Telepon", SqlDbType.VarChar, 50)
				.Parameters.Add("@Mess", SqlDbType.VarChar, 50)
				.Parameters.Add("@Status", SqlDbType.VarChar, 50)
				.Parameters.Add("@Keterangan", SqlDbType.VarChar, 50)
				.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50)
		
				.Parameters("@Nrp").Value = Me.txtNrp.Text
				
				 If Me.txtAwal.Text = String.Empty Then
					.Parameters("@Awal").Value = DBNull.Value
				 Else
					.Parameters("@Awal").Value = Me.txtAwal.Text		 
				 end If
				 
				  If Me.txtAkhir.Text = String.Empty Then
					.Parameters("@Akhir").Value = DBNull.Value
				 Else
					.Parameters("@Akhir").Value = Me.txtAkhir.Text		 
				 end If
					

				.Parameters("@Nama").Value = Me.txtNama.Text
				.Parameters("@Company").Value = Me.txtCompany.Text
				.Parameters("@Departemen").Value = Me.txtDepartemen.Text
				.Parameters("@Jabatan").Value = Me.txtJabatan.Text
				.Parameters("@Tujuan").Value = Me.txtTujuan.Text
				.Parameters("@Telepon").Value = Me.txtTelepon.Text
			    .Parameters("@Mess").Value = Me.txtMess.Text
				.Parameters("@Status").Value = "Complete"
				.Parameters("@Keterangan").Value = Me.txtKeterangan.Text
				.Parameters("@CreatedBy").Value = Session("userid").ToString
				
				'=========pupup=====================
				
				Dim csname1 As String = "PopupScript"
			    Dim cstype As Type = Me.GetType()
			    Dim cs As ClientScriptManager = Page.ClientScript
		
				If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
					Dim cstext2 As String = "alert('Permohonan manifest berhasil disimpan !');"
				   cs.RegisterStartupScript(cstype, csname1, cstext2, True)  
				End If
				
				 Me.txtNrp.Text = ""
				 Me.txtAwal.Text = ""
				 Me.txtAkhir.Text = ""
				 Me.txtNama.Text = ""
				 Me.txtCompany.Text = ""
				 Me.txtJabatan.Text = ""
				 Me.txtTujuan.Text = ""
				 Me.txtTelepon.Text = ""
			     Me.txtMess.Text = ""
				 Me.txtKeterangan.Text = ""
				
				.ExecuteNonQuery()
				con.Close()

			End With
	End Sub
	
End Class
