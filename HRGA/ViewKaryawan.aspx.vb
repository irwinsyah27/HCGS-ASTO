Imports Microsoft.Reporting.WebForms
Imports System.Data
Imports System.Data.SqlClient

Partial Class HRGA_ViewKaryawan
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.ReportViewer1.ShowParameterPrompts = False
        Dim y As String = ""
        y = UCase(Request.QueryString("n").ToString)

        ReportViewer1.ServerReport.ReportPath = "/hrga/ViewKaryawan_PER_NRP"


        Dim Nrp As New ReportParameter("NRP", y)
        Dim q() As ReportParameter = {Nrp}
        ReportViewer1.ServerReport.SetParameters(q)


    End Sub

End Class
