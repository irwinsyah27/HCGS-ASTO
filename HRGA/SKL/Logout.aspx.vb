
Partial Class Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("userid") = ""
        Session("Login") = ""
        Session("UserName") = ""
        Session("access") = ""
        Session("Status") = ""
        Session("Section") = ""
        Response.Cookies("UserName").Value = ""
        Response.Cookies("UserName").Value = ""
        Response.Cookies("Status").Value = ""
        Response.Cookies("Section").Value = ""
        Response.Cookies("Dept").Value = ""
        
        Response.Redirect("Default.aspx")
    End Sub
End Class
