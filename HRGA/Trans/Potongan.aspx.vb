Imports System.Data
Imports System.Data.SqlClient
Partial Class HRGA_Trans_Potongan
    Inherits System.Web.UI.Page
    Public EditIndex As Integer = -1
    Dim Nilai As String
    Dim Nrp As String
    Dim Kode As String

    Protected Sub GridView2_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowCreated
        If e.Row.RowType = DataControlRowType.Header Or e.Row.RowIndex.ToString < 0 Then
        Else
            Dim KeyValue As String = Me.GridView2.DataKeys(e.Row.RowIndex).Value.ToString

            If KeyValue = "0" And EditIndex = -1 Then
                e.Row.Attributes.Add("isadd", "1")
            End If

        End If
    End Sub
    Protected Sub GridView2_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView2.RowEditing
        EditIndex = e.NewEditIndex
    End Sub
    Protected Sub GridView2_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GridView2.RowUpdated
        Dim N As String = e.Keys.Item(0).ToString

        Nilai = e.NewValues.Item(0).ToString
        Kode = e.NewValues.Item(1).ToString
        Nrp = Me.txtNrp.Text

        If N = "0" Then
            insPotongan()
        End If

    End Sub

    Sub insPotongan()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Insert Into tblTransaksi" _
                            & "[Tgl]" _
                            & ",[Kode]" _
                            & ",[Nilai]" _
                            & ",[Nrp]" _
                    & ") values (" _
                            & "@Tgl" _
                            & ",@Kode" _
                            & ",@Nilai" _
                            & ",@Nrp" _
                            & ")"

            .Parameters.Add("@Tgl", SqlDbType.DateTime)
            .Parameters.Add("@Kode", SqlDbType.VarChar, 2)
            .Parameters.Add("@Nilai", SqlDbType.Money)
            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)

            .Parameters("@Tgl").Value = Date.Today.Date
            .Parameters("@Kode").Value = Kode
            .Parameters("@Nilai").Value = Nilai
            .Parameters("@Nrp").Value = Nrp

            .ExecuteNonQuery()
        End With
    End Sub
End Class
