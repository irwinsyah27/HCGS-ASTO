Imports System.Data
Imports System.Data.SqlClient
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
        Dim sDomain As String = "PAMAPERSADA"

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("Adro_WebConnectionString").ConnectionString)
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
                Session.Timeout = 30
                'Update cookies
                Response.AppendCookie(C1)
                'Set cookie expire
                C1.Expires = DateTime.Now.AddMinutes(30)

                With cmd
                    .Connection = con
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT [tblLogin].[UserID], [tblLogin].[Password], [tblLogin].[UserName], [tblLogin].[dept],[tblLogin].[access], [tblLogin].[status], [tblLogin].[sect], [tblLogin].[lastupdate]  FROM [tblLogin] WHERE (([tblLogin].[UserID]" & _
                    "= @userid))"

                    .Parameters.Add("@userid", SqlDbType.VarChar, 19)
                    '.Parameters.Add("@Password", SqlDbType.VarChar, 19)

                    .Parameters("@userid").Value = Right(Me.txtUserid.Text, Len(Me.txtUserid.Text) - 1)
                    '.Parameters("@Password").Value = temp

                    dr = .ExecuteReader
                    If dr.Read = True Then
                        Session("Login") = "Yes"
                        Session("userid") = Right(Me.txtUserid.Text, Len(Me.txtUserid.Text) - 1)
                        Session("UserName") = dr.Item("username").ToString
                        Session("nama") = dr.Item("username").ToString
                        Session("access") = dr.Item("access").ToString
                        Session("Status") = dr.Item("status").ToString
                        Session("dept") = dr.Item("dept").ToString
                        Session("section") = dr.Item("sect").ToString



                        Response.Cookies("UserID").Value = Session("userid")
                        'Response.Cookies("UserID").Expires = DateTime.Now.AddDays(1)
                        'Response.Cookies("UserID").Expires = DateTime.Now.AddMinutes(5)
                        Response.Cookies("UserID").Expires = DateTime.Now.AddHours(1)
                        Response.Cookies("UserName").Value = Session("UserName")
                        Response.Cookies("UserName").Expires = DateTime.Now.AddHours(1)
                        Response.Cookies("UserName").Value = Session("UserName")
                        Response.Cookies("UserName").Expires = DateTime.Now.AddHours(1)
                        Response.Cookies("Status").Value = Session("Status")
                        Response.Cookies("Status").Expires = DateTime.Now.AddHours(1)
                        Response.Cookies("Section").Value = Session("Section")
                        Response.Cookies("Section").Expires = DateTime.Now.AddHours(1)
                        Response.Cookies("Dept").Value = Session("dept")
                        Response.Cookies("Dept").Expires = DateTime.Now.AddHours(1)
                        'Response.Cookies("UserName").Value = Session("UserName")
                        'Response.Cookies("UserName").Expires = DateTime.Now.AddMinutes(5)
                        'Response.Cookies("UserName").Value = Session("UserName")
                        'Response.Cookies("UserName").Expires = DateTime.Now.AddMinutes(5)
                        'Response.Cookies("Status").Value = Session("Status")
                        'Response.Cookies("Status").Expires = DateTime.Now.AddMinutes(5)
                        'Response.Cookies("Section").Value = Session("Section")
                        'Response.Cookies("Section").Expires = DateTime.Now.AddMinutes(5)
                        'Response.Cookies("Dept").Value = Session("dept")
                        'Response.Cookies("Dept").Expires = DateTime.Now.AddMinutes(5)
                        'If dr.Item("lastupdate").ToString = "" Then
                        '    con.Close()
                        '    Response.Redirect("CPass.aspx")
                        'End If
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
    'Function ENC()
    '    Dim DataString
    '    Dim I
    '    Dim lokasi
    '    Dim Code

    '    DataString = Me.txtPassword.Text

    '    i = 0
    '    Code = "1234567890"
    '    temp = ""
    '    For i = 1 To Len(DataString)
    '        lokasi = (i Mod Len(Code)) + 1
    '        temp = temp + Chr(Asc(Mid(DataString, i, 1)) Xor _
    '        Asc(Mid(Code, lokasi, 1)))
    '    Next
    '    password = temp
    '    Return temp
    'End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Q") = "" Then
            Session("Q") = "./"
        End If
    End Sub
End Class
