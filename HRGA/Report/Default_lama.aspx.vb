
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Me.ReportViewer1.Visible = True
        Me.ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DropDownList1.Items.Clear()
        Me.DropDownList1.Items.Add("PROD")
        'Me.TextBox1.Text = Month(Date.Today) - 1 & "/16/" & Year(Date.Today)
        'Me.TextBox2.Text = Month(Date.Today) & "/16/" & Year(Date.Today)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.ReportViewer1.Visible = True
        Me.ReportViewer1.LocalReport.Refresh()
    End Sub
End Class
