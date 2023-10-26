
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("access") <> "" Then
            Login.Text = "| .:: Logout ::. |"
            'User.Text = "| User : p" & Request.Cookies("UserID").Value.ToString & "|"
            'Nama.Text = "|" & Request.Cookies("UserName").Value.ToString
            User.Text = "| User : p" & Session("UserID") & "|"
            Nama.Text = "|" & Session("nama")
            Login.PostBackUrl = "../Logout.aspx"
            'Me.User.Text = "| User : p" & Session("UserID") & "|"
        Else
            Response.Redirect("./login.aspx")
            Login.Visible = False
            User.Visible = False
            Nama.Visible = False
            Login.PostBackUrl = "../"
        End If
    End Sub
End Class

