Imports System.Data
Imports System.Data.SqlClient
Partial Class HRGA_EditHarike7
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./editharike7.aspx"
            Response.Redirect("./login.aspx")
        End If

        AccessAdm()
        'Response.Write(Session("jabatan"))
        'Response.Write(Session("ndPosisi"))
        If InStr(1, Session("jabatan").ToString, "PERSONNEL SITE OFFICER") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL SITE OFFICER") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL OFFICER") > 0 Or InStr(1, Session("ndPosisi").ToString, "PAYROLL OFFICER") > 0 Or InStr(1, Session("jabatan").ToString, "RM ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "HAULING ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "PLANT ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "ENG ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "SHE ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "SM ADMIN") > 0 Then
            Me.SqlDataSource2.SelectCommand = "SELECT '' AS [Dept] FROM [Tbl_Dept] UNION SELECT [Dept] FROM [Tbl_Dept]"
        ElseIf InStr(1, Session("AccessAdm").ToString, "True") > 0 Then

            Me.SqlDataSource2.SelectCommand = "SELECT '' AS [Dept] FROM [Tbl_Dept] UNION SELECT [Dept] FROM [Tbl_Dept] WHERE [Dept]='" & Session("Dept").ToString & "'"
        Else
            Me.SqlDataSource2.SelectCommand = "SELECT '' AS [Dept] FROM [Tbl_Dept] UNION SELECT [Dept] FROM [Tbl_Dept] WHERE [Dept]='" & Session("Dept").ToString & "'"
            Me.GridView1.Columns(4).Visible = False
            'Dim csname1 As String = "PopupScript"
            'Dim cstype As Type = Me.GetType()

            'Dim cs As ClientScriptManager = Page.ClientScript

            'If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

            '    Dim cstext1 As String = "alert('Anda tidak punya access ...    ');"
            '    cstext1 += "location='login.aspx';"
            '    cs.RegisterStartupScript(cstype, csname1, cstext1, True)

            'End If
        End If
    End Sub
    Dim R As String = Nothing
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Session("Row") = e.NewEditIndex.ToString
        Response.Write(R)

        R = Session("Row").ToString
        Dim D As String = Nothing
        D = GridView1.Rows(R).Cells(2).Text
        Session("d") = D

        'AccessAdm()

        Dim csname1 As String = "PopupScript"
        Dim cstype As Type = Me.GetType()

        Dim cs As ClientScriptManager = Page.ClientScript
        'Script di bawah perlu dicoba
        If InStr(1, Session("AccessAdm").ToString, "True") = 0 And InStr(1, Session("Jabatan").ToString, "Admin Payroll") = 0 And InStr(1, Session("ndPosisi").ToString, "Admin Payroll") = 0 And InStr(1, Session("Jabatan").ToString, "PLANT ADMIN") = 0 And InStr(1, Session("Jabatan").ToString, "HAULING ADMIN") = 0 And InStr(1, Session("Jabatan").ToString, "RM ADMIN") = 0 And InStr(1, Session("Jabatan").ToString, "ENG ADMIN") = 0 And InStr(1, Session("Jabatan").ToString, "SM ADMIN") = 0 And InStr(1, Session("Jabatan").ToString, "SHE ADMIN") = 0 Then
            If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

                Dim cstext1 As String = "alert('Anda tidak punya access untuk edit hari ke7 ...    ');"
                'cstext1 += "location='login.aspx';"
                cs.RegisterStartupScript(cstype, csname1, cstext1, True)

            End If
            e.Cancel = True
        Else
            If D <> Session("Dept").ToString And "PLANT SITE ADMINISTRATOR" = Session("Jabatan").ToString Then
                If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

                    Dim cstext1 As String = "alert('Tidak diperbolehkan edit hari ke7 departemen lain1...    ');"
                    'cstext1 += "location='login.aspx';"
                    cs.RegisterStartupScript(cstype, csname1, cstext1, True)

                End If
                e.Cancel = True
            Else
                If D <> Session("Dept").ToString And InStr(1, Session("Admin").ToString, "1") < 1 Then
                    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

                        Dim cstext1 As String = "alert('Tidak diperbolehkan edit hari ke7 departemen lain2...    ');"
                        'cstext1 += "location='login.aspx';"
                        cs.RegisterStartupScript(cstype, csname1, cstext1, True)

                    End If
                    e.Cancel = True
                End If
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

    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Dim Nrp As String = e.Keys.Item(0).ToString
        Dim Tanggal As String = e.NewValues.Item(1).ToString
        Dim Harike7 As String = ""

        Dim csname1 As String = "PopupScript"
        Dim cstype As Type = Me.GetType()
        Dim cs As ClientScriptManager = Page.ClientScript

        Select Case Weekday(CDate(Tanggal))
            Case 1
                Harike7 = "Minggu"
            Case 2
                Harike7 = "Senin"
            Case 3
                Harike7 = "Selasa"
            Case 4
                Harike7 = "Rabu"
            Case 5
                Harike7 = "Kamis"
            Case 6
                Harike7 = "Jumat"
            Case 7
                Harike7 = "Sabtu"
        End Select

        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Insert Into tbLHarike7 " _
                            & "([Nrp]" _
                            & ",[TanggalUpdate]" _
                            & ",[TanggalHarike7]" _
                            & ",[Harike7]" _
                            & ",[UpdateOleh]" _
                    & ") values (" _
                            & " @Nrp" _
                            & ",Getdate()" _
                            & ",@Tanggal" _
                            & ",@Harike7" _
                            & ",@UpdateOleh" _
                            & ")"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters.Add("@Tanggal", SqlDbType.DateTime)
            .Parameters.Add("@Harike7", SqlDbType.VarChar, 10)
            .Parameters.Add("@UpdateOleh", SqlDbType.VarChar, 10)

            .Parameters("@Nrp").Value = Nrp
            .Parameters("@Tanggal").Value = Tanggal
            .Parameters("@Harike7").Value = Harike7
            .Parameters("@UpdateOleh").Value = Session("userid")

            .ExecuteNonQuery()
        End With
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        R = Session("Row").ToString
        Dim Nrp As String = Nothing
        Dim Tanggal As String = Nothing
        Nrp = GridView1.Rows(R).Cells(0).Text
        'Response.Write(GridView1.Rows(0).Cells(4).Text)
        'CType(GridView1.Rows(GridView1.SelectedValue).FindControl("Textbox1"), TextBox).Text = Format(CType(GridView1.Rows(GridView1.SelectedValue).FindControl("Calendar1"), Calendar).SelectedDate, "dd MMM yyyy")
        CType(GridView1.Rows(R).FindControl("Textbox1"), TextBox).Text = Format(CType(GridView1.Rows(R).FindControl("Calendar1"), Calendar).SelectedDate, "dd MMM yyyy")

        'CType(GridView1.Rows(GridView1.SelectedValue).FindControl("Calendar1"), Calendar).Visible = False
        Nrp = GridView1.Rows(R).Cells(0).Text
        Tanggal = Format(CType(GridView1.Rows(R).FindControl("Calendar1"), Calendar).SelectedDate, "dd MMM yyyy")
        'Response.Write(Nrp)
        'Response.Write(Tanggal)
        'Response.Write("Test2 :" & GridView1.SelectedRow.Cells(0).Text.ToString)
        Dim HARI As String = ""
        HARI = CType(GridView1.Rows(R).FindControl("Calendar1"), Calendar).SelectedDate.ToString
        Select Case Weekday(HARI)
            Case 1
                HARI = "Minggu"
            Case 2
                HARI = "Senin"
            Case 3
                HARI = "Selasa"
            Case 4
                HARI = "Rabu"
            Case 5
                HARI = "Kamis"
            Case 6
                HARI = "Jumat"
            Case 7
                HARI = "Sabtu"
        End Select
        Dim index As Integer = GridView1.EditIndex
        Dim row As GridViewRow = GridView1.Rows(index)

        CType(GridView1.Rows(R).FindControl("DropDownList1"), DropDownList).Text = HARI

        'Response.Write(CType(GridView1.SelectedRow.Cells(2).Controls(0), DataBoundLiteralControl))
        'Response.Write(HARI)

    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'CType(GridView1.Rows(GridView1.SelectedValue).FindControl("Calendar1"), Calendar).SelectedDate = CType(DetailsView1.Rows(DetailsView1.SelectedValue).FindControl("GridView1"), GridView).SelectedRow.Cells(1).Text
        'CType(GridView1.Rows(GridView1.SelectedValue).FindControl("TextBox6"), TextBox).Text = CType(DetailsView1.Rows(DetailsView1.SelectedValue).FindControl("GridView1"), GridView).SelectedRow.Cells(2).Text
        'CType(GridView1.Rows(GridView1.SelectedValue).FindControl("GridView1"), GridView).Visible = False
    End Sub

    Protected Sub GridView1_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        'Response.Write("Test2 :" & GridView1.SelectedRow.Cells(0).Text.ToString)
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Session("d") = ""
    End Sub
End Class
