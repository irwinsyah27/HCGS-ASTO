Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WebForms
Partial Class HRGA_Report_Lembur
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./report/Lembur.aspx"
            Response.Redirect("../login.aspx")
        Else
            AccessAdm()
            If InStr(1, Session("AccessAdm").ToString, "True") > 0 Then
                If InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") = 0 And InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") = 0 Then
                    Response.Redirect("./tglLembur.aspx")
		    'ReportViewer1.ServerReport.ReportPath = "/hrga/Lembur_Per_Nrp_MultiSelect"
                End If
            Else
                Response.Redirect("./tglLembur.aspx")
		'ReportViewer1.ServerReport.ReportPath = "/hrga/Lembur_Per_Nrp_MultiSelect"
            End If
        End If

        'Dim a As String
        'Dim b As String
        'Dim c As String
        'a = ReportViewer1.ServerReport.GetParameters.Item("Awal").Values.Item(0).ToString
        'b = ReportViewer1.ServerReport.GetParameters.Item("Akhir").Values.Item(0).ToString
        'c = ReportViewer1.ServerReport.GetParameters.Item("DEPT").Values.Item(0).ToString

        'If c <> "DEPT" Then
        '    Response.Redirect("lembur1.aspx?a=" & a & "&b=" & b)
        'End If


        'If InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Then

        'ElseIf InStr(1, Session("AccessAdm").ToString, "True") > 0 Then
        '    Response.Redirect("./lembur1.aspx")
        'Else
        '    Response.Redirect("./lembur2.aspx?n=" & Session("userid"))
        'End If
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
