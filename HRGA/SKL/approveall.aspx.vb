Imports System.Data
Imports System.Data.SqlClient


Partial Class _approveall
    Inherits System.Web.UI.Page


     Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./skl/approveall.aspx"
            Response.Redirect("../login.aspx")
        End If

        If InStr(1, Session("jabatan").ToString, "HRM & ENGINEERING DEPT. HEAD") > 0 Then
            Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] WHERE DEPARTEMEN IN ('HAULING','RM','ENG')"
		Else If InStr(1, Session("jabatan").ToString, "HCGS & FAT DEPT. HEAD") > 0 Then
            Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] WHERE DEPARTEMEN IN ('FAT','HCGS')"
		Else If InStr(1, Session("jabatan").ToString, "PLANT DEPT. HEAD") > 0 Then
            Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] WHERE DEPARTEMEN IN ('PLANT')"
		Else
		 	Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] WHERE Departemen ='" & Session("dept").ToString & "'"
		End If

		If InStr(1, Session("jabatan").ToString, "DEPT. HEAD") = 0 And InStr(1, Session("ndPosisi").ToString, "DEPT. HEAD") = 0 And InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") = 0 And InStr(1, Session("jabatan").ToString, "PERSONNEL SITE OFFICER") = 0 Then
            Dim csname1 As String = "PopupScript"
            Dim cstype As Type = Me.GetType()

            Dim cs As ClientScriptManager = Page.ClientScript

            If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

                Dim cstext1 As String = "alert('Anda tidak punya access');"
                cstext1 += "self.close();"
                cs.RegisterStartupScript(cstype, csname1, cstext1, True)

            End If
           
        End If
       
    End Sub

    Protected Sub btSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btSave.Click

	    Dim con As SqlClient.SqlConnection = Nothing
		Dim cmd As SqlClient.SqlCommand = Nothing

		cmd = New SqlClient.SqlCommand

		Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
		con = New SqlClient.SqlConnection(connectionStrings("Data_abs1ConnectionString").ConnectionString)


		If InStr(1, Session("jabatan").ToString, "DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "DEPT. HEAD") > 0 Then

			con.Open()
			With cmd
				.Connection = con
				.CommandType = CommandType.StoredProcedure
				.CommandText = "SP_APPROVE_SKL_DEPT_HEAD"
			
				.Parameters.Add("@awal", SqlDbType.DateTime)
				.Parameters.Add("@akhir", SqlDbType.DateTime)
				.Parameters.Add("@DEPT", SqlDbType.VarChar, 21)
				.Parameters.Add("@nrp", SqlDbType.VarChar, 21)

				.Parameters("@awal").Value = Me.txtAwal.Text	
				.Parameters("@akhir").Value = Me.txtAkhir.Text	
				.Parameters("@DEPT").Value = Me.txtDepartemen.Text
				.Parameters("@nrp").Value = Session("userid").ToString

				.ExecuteNonQuery()
				con.Close()
			End With

				'=========pupup=====================
				
				Dim csname1 As String = "PopupScript"
			    Dim cstype As Type = Me.GetType()
			    Dim cs As ClientScriptManager = Page.ClientScript
		
				If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
					Dim cstext2 As String = "alert('Berhasil Di Approve DH !');"
				   cs.RegisterStartupScript(cstype, csname1, cstext2, True)  
				End If
		
				'=========END POPUP=====================

		End If

		If InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL SITE OFFICER") > 0 Then

			con.Open()
			With cmd
				.Connection = con
				.CommandType = CommandType.StoredProcedure
				.CommandText = "SP_APPROVE_SKL_HCGS"
			
				.Parameters.Add("@awal",SqlDbType.DateTime)
				.Parameters.Add("@akhir", SqlDbType.DateTime)
				.Parameters.Add("@nrp", SqlDbType.VarChar, 21)

				.Parameters("@awal").Value = Me.txtAwal.Text
				.Parameters("@akhir").Value = Me.txtAkhir.Text
				.Parameters("@nrp").Value = Session("userid").ToString

				.ExecuteNonQuery()
				con.Close()
			End With

		'=========pupup=====================
				
				Dim csname1 As String = "PopupScript"
			    Dim cstype As Type = Me.GetType()
			    Dim cs As ClientScriptManager = Page.ClientScript
		
				If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
					Dim cstext2 As String = "alert('Berhasil Di Approve Personnel !');"
				   cs.RegisterStartupScript(cstype, csname1, cstext2, True)  
				End If
		
		'=========END POPUP=====================

		End If

	End Sub
   
End Class
