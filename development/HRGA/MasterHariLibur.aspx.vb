Imports System.Data
Imports System.Data.SqlClient
Partial Class HRGA_MasterHariLibur
    Inherits System.Web.UI.Page
    Public EditIndex As Integer = -1
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        EditIndex = e.NewEditIndex
    End Sub
    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        Dim KeyValue As String
        'Dim RowID As String
        Dim Nrp As String
        Dim Url As String
        If (e.Row.RowType = DataControlRowType.Header) Then
            'AddGlyph(GridView1, e.Row)
        End If

        If (e.Row.RowType = DataControlRowType.DataRow) Then
            KeyValue = GridView1.DataKeys(e.Row.RowIndex).Value.ToString
            If KeyValue = "0" And EditIndex = -1 Then
                e.Row.Attributes.Add("isadd", "1")
            End If
            'MsgBox(KeyValue & EditIndex)
            'RowID = Convert.ToString(System.Web.UI.DataBinder.Eval(e.Row.DataItem, "Nrp"))
            Nrp = Convert.ToString(System.Web.UI.DataBinder.Eval(e.Row.DataItem, "Id"))

            Url = "EditKaryawan.aspx?nrp=" + Nrp
            e.Row.Attributes.Add("href", Url)       '// link to details
            e.Row.Attributes.Add("open", "0")           '// used by the detail table expander/contracter
            e.Row.Attributes.Add("hascontent", "0") '// used to prevent excessive callbacks to the server
        End If
    End Sub

    Protected Sub GridView1_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GridView1.RowUpdated
        Dim N As String = e.Keys.Item(0).ToString
        Dim Tanggal As DateTime
        Dim Keterangan As String

        Tanggal = e.NewValues.Item(0).ToString
        Keterangan = e.NewValues.Item(1).ToString
        If N = "0" Then
            Dim con As SqlClient.SqlConnection = Nothing
            Dim cmd As SqlClient.SqlCommand = Nothing

            cmd = New SqlClient.SqlCommand

            Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
            con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

            con.Open()
            With cmd
                .Connection = con
                .CommandType = CommandType.Text
                .CommandText = "Insert Into tblHariLibur " _
                                & "([Tanggal]" _
                                & ",[Keterangan]" _
                                & ") values (" _
                                & "@Tanggal" _
                                & ",@Keterangan" _
                                & ")"

                .Parameters.Add("@Tanggal", SqlDbType.DateTime)
                .Parameters.Add("@Keterangan", SqlDbType.VarChar, 50)

                .Parameters("@Tanggal").Value = Tanggal
                .Parameters("@Keterangan").Value = Keterangan

                .ExecuteNonQuery()
            End With
        End If
    End Sub
End Class
