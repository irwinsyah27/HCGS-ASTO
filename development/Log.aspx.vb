Imports System.Data
Imports System.Data.SqlClient

Partial Class Log
    Inherits System.Web.UI.Page
	
	Dim SelectSQL As String
    Dim i As Integer
    Dim Akses() As String
    Dim temp As String
    Dim password As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	
		Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim dr As SqlDataReader
        Dim sDomain As String = "KPPMINING"

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("Adro_WebConnectionString").ConnectionString)
        con.Open()
		
		 With cmd
                    .Connection = con
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT [tblLogin].[UserID], [tblLogin].[Password], [tblLogin].[UserName], [tblLogin].[dept],[tblLogin].[access], [tblLogin].[status], [tblLogin].[sect], [tblLogin].[lastupdate], [tblLogin].[Company]  FROM [tblLogin] WHERE (([tblLogin].[UserID]" & _
                    "= @userid))"

                    .Parameters.Add("@userid", SqlDbType.VarChar, 19)

                    .Parameters("@userid").Value = Right(Request.QueryString("n").ToString, Len(Request.QueryString("n").ToString) - 1)

                    dr = .ExecuteReader
                    If dr.Read = True Then
                        Session("Login") = "Yes"
                        Session("userid") = Right(Request.QueryString("n").ToString, Len(Request.QueryString("n").ToString) - 1)
                        Session("UserName") = dr.Item("username").ToString
                        Session("nama") = dr.Item("username").ToString
                        Session("access") = dr.Item("access").ToString
                        Session("Status") = dr.Item("status").ToString
                        Session("dept") = dr.Item("dept").ToString
                        Session("Company") = dr.Item("Company").ToString
                        Session("section") = dr.Item("sect").ToString
                        Jabatan()
                        Site()
                        Admin()

                        Response.Cookies("UserID").Value = Session("userid")
                        Response.Cookies("UserID").Expires = DateTime.Now.AddHours(5)
                        Response.Cookies("UserName").Value = Session("UserName")
                        Response.Cookies("UserName").Expires = DateTime.Now.AddHours(5)
                        Response.Cookies("Company").Value = Session("Company")
                        Response.Cookies("Company").Expires = DateTime.Now.AddHours(5)
                        Response.Cookies("Status").Value = Session("Status")
                        Response.Cookies("Status").Expires = DateTime.Now.AddHours(5)
                        Response.Cookies("Section").Value = Session("Section")
                        Response.Cookies("Section").Expires = DateTime.Now.AddHours(5)
                        Response.Cookies("Dept").Value = Session("dept")
                        Response.Cookies("Dept").Expires = DateTime.Now.AddHours(5)
                        Response.Cookies("LStatus").Value = Session("LStatus")
                        Response.Cookies("LStatus").Expires = DateTime.Now.AddHours(5)
		

        Dim Par As String = "R=" + Session("userid").ToString + "&A=" + Session("UserName").ToString + "&N=" + Session("section").ToString + "&T=" + Session("dept").ToString + "&S=" + Session("Site").ToString
                            
							Response.Redirect("HTTP://portfspu404.kppmining.net:83/SessionOn.php?" + Par)
							'Label5.Text = Server.UrlEncode(Par)
		End If
		con.Close()
                    Response.Redirect(Session("Q"))
		End With					
    End Sub
	
	Sub Site()
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
            .CommandText = "Select Lokasi as [Site] From tblKaryawan WHERE Nrp = @Nrp"
            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = Session("userid").ToString

            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Session("Site") = dr.Item("Site").ToString
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

    Sub Jabatan()
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
            .CommandText = "Select dbo.tblKaryawan.*, dbo.tblAdmin AS LStatus From dbo.tblKaryawan INNER JOIN dbo.tblAdmin ON dbo.tblKaryawan.Nrp = dbo.tblAdmin.Nrp WHERE dbo.tblKaryawan.Nrp = @Nrp "
            .Parameters.Add("@Nrp", SqlDbType.VarChar, 19)
            .Parameters("@Nrp").Value = Session("userid").ToString
            '.Parameters("@Nrp").Value = Mid(Session("userid").ToString, 2, Len(Session("userid").ToString))

            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Session("UserName") = dr.Item("Nama").ToString
            Session("jabatan") = dr.Item("jabatan").ToString
            Session("dept") = dr.Item("Departemen").ToString
            Session("LStatus") = dr.Item("LoginStatus").ToString
            'Response.Write(dr.Item("jabatan").ToString)
        End If
        Posisi()
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
            .CommandText = "Select * From tblndPosisi WHERE Nrp = @Nrp And (Expired = 0 OR Expired IS NULL) "
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
        'Response.Write("1" & Session("ndPosisi").ToString)
    End Sub
	
End Class
