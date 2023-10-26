Imports Microsoft.Reporting.WebForms
Partial Class HRGA_Report_SKL
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./report/skl.aspx"
            Response.Redirect("../login.aspx")
        End If

        'Dim d As String = ""
        'Session("Dept") = "HRGA"
        'd = Session("Dept").ToString
        ''ReportViewer1.ServerReport.ReportPath = "/hrga/Lembur_Per_Periode"
        'If Session("Dept") = "PCH" Then
        '    Me.ReportViewer1.ShowParameterPrompts = False
        '    Dim Dept As New ReportParameter("DEPT", d)
        '    Dim q() As ReportParameter = {Dept}
        '    ReportViewer1.ServerReport.SetParameters(q)
        'Else
        '    Me.ReportViewer1.ShowParameterPrompts = True

        'End If
    End Sub
End Class
