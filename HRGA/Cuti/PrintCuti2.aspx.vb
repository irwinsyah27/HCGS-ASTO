Imports Microsoft.Reporting.WebForms
Partial Class HRGA_Cuti_PrintCuti2
    Inherits System.Web.UI.Page

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load

        'Dim x As String = ""
        'x = Request.QueryString("n").ToString

        'Dim Nomor As New ReportParameter("NomorST", x)
        'Dim p() As ReportParameter = {Nomor}
        'ReportViewer1.ServerReport.SetParameters(p)

        Dim x As String = "HRGA"
        'x = Request.QueryString("d").ToString

        Dim Dept As New ReportParameter("Departemen", x)
        Dim p() As ReportParameter = {Dept}
        ReportViewer1.ServerReport.SetParameters(p)

    End Sub

    'Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
    '    Dim x As String = "HRGA"
    '    'x = Request.QueryString("d").ToString
    '    x = Me.DropDownList1.SelectedValue.ToString

    '    Dim Dept As New ReportParameter("Departemen", x)
    '    Dim p() As ReportParameter = {Dept}
    '    ReportViewer1.ServerReport.SetParameters(p)
    'End Sub
End Class
