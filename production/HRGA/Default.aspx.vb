Imports System.Data
Imports System.Data.SqlClient
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("userid") = "" Then
            Session("Q") = ""
            Response.Redirect("//pabbapco401.kppmining.net:83/HRGA/cek.php")
        End If

        'Session("userid") = Request.Cookies("userid").Value
        'Session("userid") = Mid(Session("userid").ToString, 2, Len(Session("userid").ToString))

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
            .CommandText = "Select * From tblKaryawan WHERE Nrp = @Nrp "
            .Parameters.Add("@Nrp", SqlDbType.VarChar, 19)
            .Parameters("@Nrp").Value = Session("userid").ToString
            '.Parameters("@Nrp").Value = Mid(Session("userid").ToString, 2, Len(Session("userid").ToString))

            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Session("UserName") = dr.Item("Nama").ToString
            Session("jabatan") = dr.Item("jabatan").ToString
            Session("dept") = dr.Item("Departemen").ToString
            'Response.Write(dr.Item("jabatan").ToString)
        End If
        Posisi()
        Company()
		   con.Close()
    End Sub
    Sub Posisi()
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
            .CommandText = "Select * From tblndPosisi WHERE Nrp = @Nrp And (Expired = 0 OR Expired IS NULL)"
            .Parameters.Add("@Nrp", SqlDbType.VarChar, 19)
            .Parameters("@Nrp").Value = Session("userid").ToString
            '.Parameters("@Nrp").Value = Mid(Session("userid").ToString, 2, Len(Session("userid").ToString))

            dr = .ExecuteReader
        End With
        Dim Posisi As String = ""
        Do While dr.Read = True
            Posisi &= "," & dr.Item("ndPosisi").ToString
        Loop
        Session("ndPosisi") = Posisi
    End Sub

    Sub Company()
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
            .CommandText = "Select Company From tblKaryawan WHERE Nrp = @Nrp"
            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = Session("userid").ToString
            '.Parameters("@Nrp").Value = Mid(Session("userid").ToString, 2, Len(Session("userid").ToString))

            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Session("Company") = dr.Item("Company").ToString
        End If
    End Sub
	
	Sub Admin()
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
            .CommandText = "Select COUNT(*) as [Admin] From tblAdmin WHERE Nrp = @Nrp"
            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = Session("userid").ToString

            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Session("Admin") = dr.Item("Admin").ToString
        End If
    End Sub

End Class
