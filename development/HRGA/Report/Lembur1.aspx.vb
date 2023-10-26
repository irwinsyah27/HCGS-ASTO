Imports Microsoft.Reporting.WebForms
Imports System.Data
Imports System.Data.SqlClient
Partial Class HRGA_Report_Lembur
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./lembur1.aspx?a=" & Request.QueryString("a") & "&b=" & Request.QueryString("b").ToString
            Response.Redirect("../login.aspx")
        End If

        Dim dp As String = ""
        Dim aw As String = ""
        Dim ak As String = ""

        Session("a") = Request.QueryString("a").ToString
        Session("b") = Request.QueryString("b").ToString

        dp = Session("Dept").ToString
        aw = Session("a").ToString
        ak = Session("b").ToString

        'ReportViewer1.ServerReport.ReportPath = "/hrga/Lembur_Per_Periode"
        'If InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Then

        AccessAdm()

        If InStr(1, Session("AccessAdm").ToString, "True") > 0 Then
            If InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Then

            Else
                Me.ReportViewer1.ShowParameterPrompts = False
                Dim Dept As New ReportParameter("DEPT", dp)
                Dim Awal As New ReportParameter("Awal", aw)
                Dim Akhir As New ReportParameter("Akhir", ak)

                Dim q() As ReportParameter = {Dept}
                Dim r() As ReportParameter = {Awal}
                Dim s() As ReportParameter = {Akhir}
                ReportViewer1.ServerReport.SetParameters(q)
                ReportViewer1.ServerReport.SetParameters(r)
                ReportViewer1.ServerReport.SetParameters(s)
                Session("c") = ReportViewer1.ServerReport.GetParameters.Item("DEPT").Values.Item(0).ToString
            End If
        Else
            If InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Then

            Else
                Response.Redirect("lembur2.aspx?n=" & Session("userid").ToString & "&a=" & Request.QueryString("a").ToString & "&b=" & Request.QueryString("b").ToString)
            End If
        End If

    End Sub

    Sub AccessAdm()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim dr As SqlDataReader

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Select * From tblAdmin Where Nrp = @Nrp"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = Session("userid")

            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Session("AccessAdm") = "True"
        Else
            Session("AccessAdm") = "False"
        End If
        con.Close()
    End Sub
End Class
