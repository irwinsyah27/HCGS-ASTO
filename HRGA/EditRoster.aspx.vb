
Partial Class HRGA_EditRoster
    Inherits System.Web.UI.Page

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./editroster.aspx"
            Response.Redirect("./login.aspx")
        End If
        If InStr(1, Session("jabatan").ToString, "PAYROLL SITE OFFICER") = 0 And InStr(1, Session("jabatan").ToString, "GS SITE OFFICER") = 0 And InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") = 0 And InStr(1, Session("jabatan").ToString, "KORLAP") = 0 Then
            Dim csname1 As String = "PopupScript"
            Dim cstype As Type = Me.GetType()

            Dim cs As ClientScriptManager = Page.ClientScript

            If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

                Dim cstext1 As String = "alert('Anda tidak punya access sebagai payroll officer...    ');"
                cstext1 += "location='login.aspx';"
                cs.RegisterStartupScript(cstype, csname1, cstext1, True)

            End If
        End If
    End Sub

End Class
