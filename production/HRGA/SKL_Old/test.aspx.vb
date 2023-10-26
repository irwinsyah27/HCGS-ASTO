
Partial Class test
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Define the name and type of the client scripts on the page.
        Dim csname1 As String = "PopupScript"
        Dim cstype As Type = Me.GetType()
        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript
        ' Check to see if the startup script is already registered.
        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
            Dim cstext1 As String = "alert('Hello World');"
            cstext1 += "location='listskl1.aspx'"
            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
        End If
        'Response.Redirect("listskl1.aspx")
    End Sub
End Class
