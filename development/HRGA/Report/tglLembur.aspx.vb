Imports System.Data
Imports System.Data.SqlClient
Partial Class HRGA_Report_tglLembur
    Inherits System.Web.UI.Page

    Protected Sub CalAwal_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CalAwal.SelectionChanged
        Me.txtAwal.Text = Format(Me.CalAwal.SelectedDate, "dd MMM yyyy")
        Me.CalAwal.Visible = False
    End Sub

    Protected Sub CalAkhir_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CalAkhir.SelectionChanged
        Me.txtAkhir.Text = Format(Me.CalAkhir.SelectedDate, "dd MMM yyyy")
        Me.CalAkhir.Visible = False
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Me.CalAwal.Visible = True
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Me.CalAkhir.Visible = True
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("Lembur1.aspx?a=" & Me.txtAwal.Text & "&b=" & Me.txtAkhir.Text)
        'If InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Then
        '    Response.Redirect("Lembur1.aspx?a=" & Me.txtAwal.Text & "&b=" & Me.txtAkhir.Text)
        'ElseIf InStr(1, Session("AccessAdm").ToString, "True") > 0 Then
        '    Response.Redirect("Lembur2.aspx?a=" & Me.txtAwal.Text & "&b=" & Me.txtAkhir.Text)
        'Else
        '    Response.Redirect("Lembur2.aspx?a=" & Me.txtAwal.Text & "&b=" & Me.txtAkhir.Text)
        'End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./tglLembur.aspx"
            Response.Redirect("../login.aspx")
        End If

        AccessAdm()

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
