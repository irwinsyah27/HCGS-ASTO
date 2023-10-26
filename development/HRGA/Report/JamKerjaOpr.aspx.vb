Imports System.Data
Imports System.Data.SqlClient
Partial Class HRGA_Report_JamKerjaOpr
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./report/jamkerjaopr.aspx"
            Response.Redirect("../login.aspx")
        End If

        AccessAdm()

        If InStr(1, Session("AccessAdm").ToString, "True") > 0 Then
            If InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Then
                Me.ReportViewer1.ServerReport.ReportPath = "/hrga/Weekly_Man_Power_Report_All"
            Else
                Me.ReportViewer1.ServerReport.ReportPath = "/hrga/Weekly_Man_Power_Report_" & Session("Dept").ToString
            End If
        Else
            Me.ReportViewer1.ServerReport.ReportPath = "/hrga/Weekly_Man_Power_Report_" & Session("Dept").ToString
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
