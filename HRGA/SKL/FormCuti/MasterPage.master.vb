
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") <> "" Then
            Login.Text = "| .:: Logout ::. |"
            User.Text = "| User : " & Request.Cookies("UserID").Value.ToString & "|"
            Nama.Text = "|" & Request.Cookies("UserName").Value.ToString
            Login.PostBackUrl = "../Logout.aspx"
        Else
            'Response.Redirect("./login.aspx")
            Response.Redirect("../")
            Login.Visible = False
            User.Visible = False
            Nama.Visible = False
            Login.PostBackUrl = "../"
        End If
        'Session("userid") = "1F00019"
        'Session("UserName") = "Nurwidiyanto"
        'Session("jabatan") = "IT REPRESENTATIVE"
        'Session("dept") = "HRGA"

        'Session("userid") = "6102003"
        'Session("UserName") = "Freddy Eko"
        'Session("jabatan") = "IT SECTION HEAD"
        'Session("dept") = "HRGA"

        'Session("userid") = "6104018"
        'Session("UserName") = "Yayan Rudianto"
        'Session("jabatan") = "HRGA DEPT. HEAD"
        'Session("dept") = "HRGA"

        'Session("userid") = "6105318"
        'Session("UserName") = "YUZE ROLIX"
        'Session("jabatan") = "HRGA SECT. HEAD"
        'Session("dept") = "HRGA"

        'Session("userid") = "0192069"
        'Session("UserName") = "AGUS DWI WIDIYANTO"
        'Session("jabatan") = "PROJECT MANAGER"
        'Session("dept") = "OPR"

        'Session("userid") = "1F96185"
        'Session("UserName") = "FITRIYANTO"
        'Session("jabatan") = "PERSONNEL ADMIN."
        'Session("dept") = "HRGA"

        If Session("userid") = "" Then
            Response.Redirect("../")
        End If
    End Sub
End Class

