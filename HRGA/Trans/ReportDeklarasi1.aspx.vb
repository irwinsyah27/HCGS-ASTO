
Partial Class HRGA_Trans_ReportDeklarasi1
    Inherits System.Web.UI.Page

    Protected Sub btnLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Me.ReportViewer1.LocalReport.Refresh()
    End Sub
End Class
