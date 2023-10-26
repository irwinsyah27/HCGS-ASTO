Imports Microsoft.Reporting.WebForms
Partial Class HRGA_Cuti_PrintTugas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ReportViewer1.ShowParameterPrompts = False
        Dim y As String = ""
        y = Request.QueryString("n").ToString

        Dim No As New ReportParameter("NomorST", y)
        Dim q() As ReportParameter = {No}
        ReportViewer1.ServerReport.SetParameters(q)
    End Sub
End Class
