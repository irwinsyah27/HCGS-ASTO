Imports Microsoft.Reporting.WebForms
Imports System.Data
Imports System.Data.SqlClient
Partial Class HRGA_Report_Lembur2
    Inherits System.Web.UI.Page
    Dim dep As String
    Dim company As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AccessAdm()
        Dim nrpp As String = ""
        nrpp = Request.QueryString("n").ToString

        CariDepartemen(nrpp)

        'ReportViewer1.ServerReport.ReportPath = "/hrga/Lembur_Per_Periode_Per_Nrp_Hari_Raya"
        Dim csname1 As String = "PopupScript"
        Dim cstype As Type = Me.GetType()

        Dim cs As ClientScriptManager = Page.ClientScript
        If InStr(1, Session("AccessAdm").ToString, "True") > 0 Then 'Or InStr(1, Session("Jabatan").ToString, "PAYROLL") = 0 Or InStr(1, Session("ndPosisi").ToString, "PAYROLL") = 0 Then
            If InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Then

            Else

                If Trim(dep) <> Trim(Session("Dept").ToString) Then
                    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

                        Dim cstext1 As String = "alert('Anda tidak punya access....    ');"
                        cstext1 += "location='tgllembur.aspx?a=" & Request.QueryString("a").ToString & "&b=" & Request.QueryString("b").ToString & "';"
                        cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                        Me.ReportViewer1.Visible = False
                    End If
                End If
            End If
        Else
            If Request.QueryString("n").ToString <> Session("userid").ToString Then
                If InStr(1, Session("Jabatan").ToString, "PAYROLL") = 0 And InStr(1, Session("ndPosisi").ToString, "PAYROLL") = 0 Then

                    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

                        Dim cstext1 As String = "alert('Anda tidak punya access...    ');"
                        cstext1 += "location='lembur1.aspx?a=" & Request.QueryString("a").ToString & "&b=" & Request.QueryString("b").ToString & "';"
                        cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                        Me.ReportViewer1.Visible = False

                    End If
                End If


            End If
        End If
        If Trim(company) = "PAMA" Then
            ReportViewer1.ServerReport.ReportPath = "/hrga/Lembur_Per_Periode_Per_Nrp"
        End If
            Dim nrp As String = ""
            Dim aw As String = ""
            Dim ak As String = ""

            Session("Nrp") = Request.QueryString("n").ToString
            Session("a") = Request.QueryString("a").ToString
            Session("b") = Request.QueryString("b").ToString

            nrp = Session("Nrp").ToString
            aw = Request.QueryString("a").ToString
            ak = Request.QueryString("b").ToString

            'ReportViewer1.ServerReport.ReportPath = "/hrga/Lembur_Per_Periode"
            'If Session("Dept") = "PCH" Then
            Me.ReportViewer1.ShowParameterPrompts = False
            Dim N As New ReportParameter("Nrp", nrp)
            Dim Awal As New ReportParameter("Awal", aw)
            Dim Akhir As New ReportParameter("Akhir", ak)
            Dim q() As ReportParameter = {N}
            Dim r() As ReportParameter = {Awal}
            Dim s() As ReportParameter = {Akhir}
            ReportViewer1.ServerReport.SetParameters(q)
            ReportViewer1.ServerReport.SetParameters(r)
            ReportViewer1.ServerReport.SetParameters(s)
            'Else
            'Me.ReportViewer1.ShowParameterPrompts = True

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

    Sub CariDepartemen(ByVal _nrpp As String)
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
            .CommandText = "Select Departemen,Company From tblKaryawan Where Nrp = @Nrp"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = _nrpp

            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            dep = dr.Item("Departemen").ToString
            company = dr.Item("Company").ToString
        End If
        con.Close()
    End Sub
End Class
