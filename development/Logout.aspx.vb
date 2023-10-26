
Partial Class Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("userid") = ""
        Session("Login") = ""
        Session("UserName") = ""
        Session("access") = ""
        Session("Status") = ""
        Session("Section") = ""
        Session("Dept") = ""
        Session("Company") = ""

        Response.Cookies("UserID").Value = ""
        Response.Cookies("UserName").Value = ""
        'Request.Cookies("access").Value = ""
        Response.Cookies("Status").Value = ""
        Response.Cookies("Section").Value = ""
        Response.Cookies("Dept").Value = ""
        Response.Cookies("Company").Value = ""

        Response.Redirect("http://pabbapco401.kppmining.net/Default.aspx")
    End Sub
End Class
