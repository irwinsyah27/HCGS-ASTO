
Partial Class Absensi
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Dept") = "" Then
            Session("Q") = "skl/absensi.aspx?Dept=" & Request.QueryString("dept").ToString
            Response.Redirect("../login.aspx")
        Else
            Me.lbldept.Text = Request.QueryString("dept").ToString
        End If
    End Sub

    Protected Sub txttgl_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttgl.TextChanged
        Me.Label1.Visible = False

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Label1.Visible = False
    End Sub
End Class
