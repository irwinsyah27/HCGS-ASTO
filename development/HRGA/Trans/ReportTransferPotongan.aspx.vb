
Partial Class HRGA_Trans_ReportTransferPotongan
    Inherits System.Web.UI.Page

    Protected Sub btnLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Me.ReportViewer1.LocalReport.Refresh()
    End Sub
End Class
