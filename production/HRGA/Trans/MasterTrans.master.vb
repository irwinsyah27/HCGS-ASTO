
Partial Class HRGA_MasterTrans
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") <> "" Then
            Login.Text = "| .:: Logout ::. |"
            User.Text = "| User : " & Session("userid").ToString & "|"
            Nama.Text = "|" & Session("UserName").ToString & "|"
            Login.PostBackUrl = "../Logout.aspx"
            If InStr(1, Session("jabatan").ToString, "DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRGA SECT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL OFFICER") > 0 Then

            Else
                If InStr(1, Session("ndPosisi").ToString, "DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRGA SECT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL OFFICER") > 0 Then

                Else
                    Response.Redirect("./")
                End If
            End If
        Else
            Response.Redirect("../")
            Login.Visible = False
            User.Visible = False
            Nama.Visible = False
            Login.PostBackUrl = "../"
        End If

        If Session("userid") = "" Then
            Response.Redirect("../")
        End If
    End Sub

End Class

