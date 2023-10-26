
Partial Class HRGA_newndpos
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'CType(DetailsView1.Rows(DetailsView1.SelectedValue).FindControl("TextBox1"), TextBox).Text = Format(CType(DetailsView1.Rows(DetailsView1.SelectedValue).FindControl("Calendar1"), Calendar).SelectedDate, "dd/MM/yyyy").ToString
        CType(DetailsView1.Rows(DetailsView1.SelectedValue).FindControl("Calendar1"), Calendar).Visible = True
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(DetailsView1.Rows(DetailsView1.SelectedValue).FindControl("TextBox1"), TextBox).Text = Format(CType(DetailsView1.Rows(DetailsView1.SelectedValue).FindControl("Calendar1"), Calendar).SelectedDate, "dd/MM/yyyy").ToString
        CType(DetailsView1.Rows(DetailsView1.SelectedValue).FindControl("Calendar1"), Calendar).Visible = False
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(DetailsView1.Rows(DetailsView1.SelectedValue).FindControl("Calendar2"), Calendar).Visible = True

    End Sub

    Protected Sub Calendar2_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(DetailsView1.Rows(DetailsView1.SelectedValue).FindControl("TextBox2"), TextBox).Text = Format(CType(DetailsView1.Rows(DetailsView1.SelectedValue).FindControl("Calendar2"), Calendar).SelectedDate, "dd/MM/yyyy").ToString
        CType(DetailsView1.Rows(DetailsView1.SelectedValue).FindControl("Calendar2"), Calendar).Visible = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Session("userid") = "1F00019" Then
        '    Me.GridView1.Columns(0).Visible = True
        'Else
        '    Me.GridView1.Columns(0).Visible = False
        'End If

        If InStr(1, Session("jabatan").ToString, "HRPGA DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRPGA SECT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL OFFICER") > 0 Then
            Me.DetailsView1.Visible = True
        Else
            If InStr(1, Session("ndPosisi").ToString, "HRPGA DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRPGA SECT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL OFFICER") > 0 Then
                Me.DetailsView1.Visible = True
            Else
                Me.DetailsView1.Visible = False
            End If
        End If
    End Sub
End Class
