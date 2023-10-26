
Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public EditIndex As Integer = -1
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        'EditIndex = e.NewEditIndex
        ' Get the country for the row being edited. For this example, the
        ' country is contained in the seventh column (index 6). 
        Dim country As String = GridView1.Rows(e.NewEditIndex).Cells(1).Text

        ' For this example, cancel the edit operation if the user attempts
        ' to edit the record of a customer from the United States. 
        If country = "1" Then

            ' Cancel the edit operation.
            e.Cancel = True
            Message.Text = "You cannot edit this record."

        Else

            Message.Text = ""

        End If

    End Sub
End Class
