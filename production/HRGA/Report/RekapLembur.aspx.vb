
Partial Class HRGA_Report_RekapLembur
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./report/RekapLembur.aspx"
            Response.Redirect("../login.aspx")
        Else
            If InStr(1, Session("Admin").ToString, "1") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL OFFICER") > 0 Then
                'Me.ReportViewer1.ServerReport.ReportPath = "/hrga/Rekap_Lembur_Bonus_Hari_Raya"
            Else
                Response.Redirect("http://HJURWSCO404/KPP_INDEX/HRGA/login.aspx")
            End If
        End If

    End Sub
End Class
