
Partial Class mabsentb
    Inherits System.Web.UI.Page

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Me.ReportViewer1.Visible = True
        Me.ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.ReportViewer1.Visible = True
        Me.ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./report/mabsenta.aspx"
            Response.Redirect("../login.aspx")
        End If
    End Sub
End Class
