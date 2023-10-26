
Partial Class mabsenta
    Inherits System.Web.UI.Page

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Me.ReportViewer1.Visible = True
        Me.ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./report/mabsenta.aspx"
            Response.Redirect("../login.aspx")
        End If
    End Sub

    Protected Sub DropDownList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Me.ReportViewer1.Visible = True
        Me.ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Calendar1.Visible = True
        Me.Calendar2.Visible = False
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        Me.TextBox1.Text = Format(Me.Calendar1.SelectedDate, "MM/dd/yyyy").ToString
        Me.Calendar1.Visible = False
        Me.ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Calendar2.Visible = True
        Me.Calendar1.Visible = False
    End Sub

    Protected Sub Calendar2_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar2.SelectionChanged
        Me.TextBox2.Text = Format(Me.Calendar2.SelectedDate, "MM/dd/yyyy").ToString
        Me.Calendar2.Visible = False
        Me.ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Me.Panel1.Visible = True
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.Panel1.Visible = False
    End Sub
End Class
