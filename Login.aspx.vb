Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Security
Imports System.Windows.Forms
Imports System.Web.UI
Imports Adro_Web.LdapAuthentication
Partial Class Login
    Inherits System.Web.UI.Page
    Dim SelectSQL As String
    Dim i As Integer
    Dim Akses() As String
    Dim temp As String
    Dim password As String
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim dr As SqlDataReader
        Dim sDomain As String = "KPPMINING"

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)
        con.Open()

        Dim adPath As String = "LDAP://" & sDomain & ":389"
        Dim adAuth As Adro_Web.LdapAuthentication = New Adro_Web.LdapAuthentication(adPath)
        Try
            If (adAuth.IsAuthenticated(sDomain, txtUserid.Text, txtPassword.Text) = True) Then
                Dim groups As String = adAuth.GetGroups()
				
                'Create the ticket, and add the groups.
                Dim isCookiePersistent As Boolean = True
                Dim authTicket As FormsAuthenticationTicket = New FormsAuthenticationTicket(1, _
                    txtUserid.Text, DateTime.Now, DateTime.Now.AddMinutes(30), isCookiePersistent, groups)
                
				'Encrypt the ticket.
                Dim encryptedTicket As String = FormsAuthentication.Encrypt(authTicket)
                
				'Create a cookie, and then add the encrypted ticket to the cookie as data.
                Dim authCookie As HttpCookie = New HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
                If (isCookiePersistent = True) Then
                    authCookie.Expires = authTicket.Expiration
                End If
                Dim C1 As HttpCookie = FormsAuthentication.GetAuthCookie(txtUserid.Text, False)
                C1.Expires = DateTime.Now.AddMinutes(30)
                
				'Add the cookie to the outgoing cookies collection.
                C1.Domain = sDomain
                
				'Create Session
                Session("UID") = Trim(txtUserid.Text)
                Session("nrpp") = Right(Trim(txtUserid.Text), Len(Me.txtUserid.Text) - 1)
                Session("Password") = Me.txtPassword.Text
                Session("Domain") = sDomain.ToString
                Session("BValid") = True
                
				'Set session time out
                Session.Timeout = 1440
                
				'Update cookies
                Response.AppendCookie(C1)
                
				'Set cookie expire
                C1.Expires = DateTime.Now.AddMinutes(30)

                With cmd
                    .Connection = con
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT [NRP],[Nama],[Jabatan],[Departemen],[Golongan],[Lokasi],[Company],[LoginStatus], CASE WHEN [LoginStatus] = 'User' THEN 0 ELSE 1 END AS ADM FROM [Persis].[dbo].[v_Login_DomainUser] WHERE (([Persis].[dbo].[v_Login_DomainUser].[Nrp]" & _
                    "= @userid))"

                    .Parameters.Add("@userid", SqlDbType.VarChar, 19)
                    '.Parameters.Add("@Password", SqlDbType.VarChar, 19)

                    .Parameters("@userid").Value = Right(Me.txtUserid.Text, Len(Me.txtUserid.Text) - 1)
                    '.Parameters("@Password").Value = temp

                    dr = .ExecuteReader
                    If dr.Read = True Then
                        Session("Login") = "Yes"
                        Session("userid") = Right(Me.txtUserid.Text, Len(Me.txtUserid.Text) - 1)
                        Session("UserName") = dr.Item("Nama").ToString
                        Session("Nama") = dr.Item("Nama").ToString
                        Session("Jabatan") = dr.Item("Jabatan").ToString
                        Session("Dept") = dr.Item("Departemen").ToString
                        Session("Golongan") = dr.Item("Golongan").ToString
                        Session("Site") = dr.Item("Lokasi").ToString
                        Session("LStatus") = dr.Item("LoginStatus").ToString
                        Session("Admin") = dr.Item("ADM").ToString
                        Session("Company") = dr.Item("Company").ToString
                        Posisi()
						
                        Response.Cookies("UserID").Value = Session("userid")
                        Response.Cookies("UserID").Expires = DateTime.Now.AddMinutes(30)
                        Response.Cookies("UserName").Value = Session("UserName")
                        Response.Cookies("UserName").Expires = DateTime.Now.AddMinutes(30)
                        Response.Cookies("Nama").Value = Session("Nama")
                        Response.Cookies("Nama").Expires = DateTime.Now.AddMinutes(30)
                        Response.Cookies("Jabatan").Value = Session("Jabatan")
                        Response.Cookies("Jabatan").Expires = DateTime.Now.AddMinutes(30)
                        Response.Cookies("Dept").Value = Session("dept")
                        Response.Cookies("Dept").Expires = DateTime.Now.AddMinutes(30)
                        Response.Cookies("Golongan").Value = Session("dept")
                        Response.Cookies("Golongan").Expires = DateTime.Now.AddMinutes(30)
                        Response.Cookies("Site").Value = Session("Site")
                        Response.Cookies("Site").Expires = DateTime.Now.AddMinutes(30)
                        Response.Cookies("LStatus").Value = Session("LStatus")
                        Response.Cookies("LStatus").Expires = DateTime.Now.AddMinutes(30)
                        Response.Cookies("Admin").Value = Session("Admin")
                        Response.Cookies("Admin").Expires = DateTime.Now.AddMinutes(30)
                        Response.Cookies("Company").Value = Session("Company")
                        Response.Cookies("Company").Expires = DateTime.Now.AddMinutes(30)
                        Response.Cookies("ndPosisi").Value = Session("ndPosisi")
                        Response.Cookies("ndPosisi").Expires = DateTime.Now.AddMinutes(30)
                       
					   'If dr.Item("lastupdate").ToString = "" Then
                        '    con.Close()
                        '    Response.Redirect("CPass.aspx")
                        'End If
                        
						If Session("BValid") = True Then
                            Dim Par As String = "R=" + Session("userid").ToString + "&A=" + Session("UserName").ToString + "&T=" + Session("dept").ToString + "&S=" + Session("Site").ToString + "&P=" + Session("Password").ToString
                            
							Response.Redirect("HTTP://pabbapco401.kppmining.net:83/SessionOn.php?" + Par)
							Label5.Text = Server.UrlEncode(Par)
                        End If
                    End If
                    con.Close()
                    Response.Redirect(Session("Q"))
                    'Response.Redirect("./")
                End With

                If Session("BValid") = True Then
                    FormsAuthentication.RedirectFromLoginPage(Me.txtUserid.Text, False)
                Else
                    Label5.Text = "Login Error: Please try again."
                End If
            Else
                Label5.Text = "Authentication did not succeed. Check user name and password."
            End If
        Catch ex As Exception
            Label5.Text = "Error authenticating. " & ex.Message
        End Try
    End Sub
	

    Sub Posisi()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim dr As SqlDataReader
        cmd = New SqlClient.SqlCommand
        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)
		try 
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
		Finally
			con.Close()
		End Try 
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Q") = "" Then
            Session("Q") = "./"
        End If
    End Sub

End Class
