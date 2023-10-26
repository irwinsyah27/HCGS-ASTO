
Partial Class test
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Define the name and type of the client scripts on the page.
        Dim csname1 As String = "PopupScript"
        Dim csname2 As String = "ButtonClickScript"
        Dim cstype As Type = Me.GetType()

        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript

        ' Check to see if the startup script is already registered.
        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

            Dim cstext1 As String = "alert('Hello World');"
            cs.RegisterStartupScript(cstype, csname1, cstext1, True)

        End If

        ' Check to see if the client script is already registered.
        If (Not cs.IsClientScriptBlockRegistered(cstype, csname2)) Then

            Dim cstext2 As New StringBuilder()
            cstext2.Append("<script type=text/javascript> function DoClick() {")
            cstext2.Append("alert('testing');")
            cstext2.Append("form1.Message.value='Text from client script.'} </")
            cstext2.Append("script>")
            cs.RegisterClientScriptBlock(cstype, csname2, cstext2.ToString(), False)

        End If



    End Sub
End Class
