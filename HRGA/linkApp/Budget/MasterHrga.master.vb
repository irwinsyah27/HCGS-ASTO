
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

	If  Session.Timeout = 0 Then
            Response.Redirect("../login.aspx")
        End If

        'Session("userid") = "6103041"
        'Session("username") = "Mas Mai..Suk...Ri..."
        'Session("jabatan") = "PERSONNEL ADMIN"
        'Session("DEPT") = "HRPGA"

        If Session("userid") = "" Then
            Response.Redirect("../")
        End If
        If Session("userid") <> "" Then
            Login.Text = "| .:: Logout ::. |"
            User.Text = "| User : " & Session("userid").ToString & "|"
            Nama.Text = "|" & Session("UserName").ToString
            Login.PostBackUrl = "../Logout.aspx"
                
            Else
                Response.Redirect("../")
                Login.Visible = False
                User.Visible = False
                Nama.Visible = False
                Login.PostBackUrl = "../"
            End If

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

