
Partial Class hrga
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Dept") = "" Then

            Session("Q") = "hrga.aspx"

            Response.Redirect("login.aspx")


        End If


    End Sub
End Class
