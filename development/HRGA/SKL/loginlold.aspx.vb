Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Mail
Partial Class login
    Inherits System.Web.UI.Page

    Dim temp As String
    Dim password As String
    'Dim i As Integer

    Protected Sub btnlogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlogin.Click
        Dim con As SqlClient.SqlConnection = Nothing
        Dim con1 As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim dr As SqlDataReader
        'Dim SelectSQL As String
        'Dim i As Integer
        'Dim Akses() As String


        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("Data_abs1ConnectionString").ConnectionString)

        con.Open()
        ENC()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "SELECT [tbl_Login].[nrp], [tbl_Login].[nama],[tbl_login].[dept],[tbl_login].[section] FROM [tbl_Login] WHERE (([tbl_Login].[nrp]" & _
            "= @userid) AND ([tbl_Login].[Password] = @Password))"

            .Parameters.Add("@userid", SqlDbType.VarChar, 10)
            .Parameters.Add("@Password", SqlDbType.VarChar, 10)

            .Parameters("@userid").Value = Me.txtusername.Text
            .Parameters("@Password").Value = temp

            dr = .ExecuteReader
            If dr.Read = True Then
                Session("userid") = Me.txtusername.Text
                Session("nama") = dr.Item("nama").ToString
                Session("Dept") = dr.Item("Dept").ToString
                Session("section") = dr.Item("section").ToString
                'MsgBox(Session("nama") & Session("Dept") & Session("userid"))

                Response.Cookies("userid").Value = Me.txtusername.Text
                Response.Cookies("nama").Value = dr.Item("nama").ToString
                Response.Cookies("Dept").Value = dr.Item("Dept").ToString
                Response.Cookies("section").Value = dr.Item("section").ToString
                'Response.Cookies("type").Value = dr.Item("type").ToString
                Response.Cookies("UserID").Expires = DateTime.Now.AddMinutes(5)
                Response.Cookies("nama").Expires = DateTime.Now.AddMinutes(5)
                Response.Cookies("dept").Expires = DateTime.Now.AddMinutes(15)
                Response.Cookies("Section").Expires = DateTime.Now.AddMinutes(5)
                
            End If
            con.Close()
            MsgBox(Session("Q"))

            Response.Redirect(Session("Q"))
           
            'MsgBox("EEE")

        End With

    End Sub
    Function ENC()
        Dim DataString
        Dim I
        Dim lokasi
        Dim Code

        DataString = Me.txtPassword.Text

        I = 0
        Code = "1234567890"
        temp = ""
        For I = 1 To Len(DataString)
            lokasi = (I Mod Len(Code)) + 1
            temp = temp + Chr(Asc(Mid(DataString, I, 1)) Xor _
            Asc(Mid(Code, lokasi, 1)))
        Next
        password = temp
        'MsgBox(temp)
        Return temp

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
