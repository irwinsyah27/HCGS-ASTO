Imports System.Data
Imports System.Data.SqlClient
Partial Class HRGA_Trans_deklast
    Inherits System.Web.UI.Page
    Public EditIndex As Integer = -1
    Dim tHotel As String
    Dim tUPD As String
    Dim tLainlain As String
    Dim tNilai As String

    Protected Sub GridView2_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowCreated
        If e.Row.RowType = DataControlRowType.Header Or e.Row.RowIndex.ToString < 0 Then
        Else
            Dim KeyValue As String = Me.GridView2.DataKeys(e.Row.RowIndex).Value.ToString

            If KeyValue = "0" And EditIndex = -1 Then
                e.Row.Attributes.Add("isadd", "1")

                'MsgBox(e.Row.RowIndex.ToString)
                'Me.GridView2.Rows(e.Row.RowIndex).Cells(5).Text = "XX"
            Else
                tHotel += e.Row.Cells(5).Text
            End If

        End If

        If e.Row.RowType = DataControlRowType.Footer Then
            Jumlah()
            e.Row.Cells(5).Text = "Rp." & tHotel
            e.Row.Cells(6).Text = "Rp." & tUPD
            e.Row.Cells(7).Text = "Rp." & tLainlain
            e.Row.Cells(8).Text = "Rp." & tNilai

            'Me.txtPengeluaran.Text = "Rp." & tNilai
            Me.txtPengeluaran.Text = FormatCurrency(tNilai)
            If Me.DetailsView1.DataItemCount > 0 Then
                Me.txtUangMuka.Text = FormatCurrency(Me.DetailsView1.Rows(12).Cells(1).Text)
                Me.txtSisa.Text = FormatCurrency(CInt(Me.DetailsView1.Rows(12).Cells(1).Text) - tNilai)

            End If
        End If

    End Sub
    Protected Sub GridView2_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView2.RowEditing
        EditIndex = e.NewEditIndex
    End Sub
    Protected Sub GridView2_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GridView2.RowUpdated
        Dim N As String = e.Keys.Item(0).ToString

        'Tgl = e.NewValues.Item(0).ToString
        Lokasi = e.NewValues.Item(0).ToString
        Hotel = e.NewValues.Item(1).ToString
        UPD = e.NewValues.Item(2).ToString
        Lainlain = e.NewValues.Item(3).ToString
        Keterangan = e.NewValues.Item(5).ToString
        Nrp = Me.DetailsView1.Rows(0).Cells(1).Text

        If N = "0" Then
            insDeklarasi()
        End If

    End Sub

    Dim Tgl As String
    Dim Lokasi As String
    Dim Hotel As String
    Dim UPD As String
    Dim Lainlain As String
    Dim Keterangan As String
    Dim Nrp As String

    Sub insDeklarasi()
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
                            & "([NomorST]" _
                            & ",[Tgl]" _
                            & ",[Lokasi]" _
                            & ",[Hotel]" _
                            & ",[UPD]" _
                            & ",[Lainlain]" _
                            & ",[Keterangan]" _
                            & ",[Nrp]" _
                    & ") values (" _
                            & "@NomorST" _
                            & ",@Tgl" _
                            & ",@Lokasi" _
                            & ",@Hotel" _
                            & ",@UPD" _
                            & ",@Lainlain" _
                            & ",@Keterangan" _
                            & ",@Nrp" _
                            & ")"

            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)
            .Parameters.Add("@Tgl", SqlDbType.DateTime)
            .Parameters.Add("@Lokasi", SqlDbType.VarChar, 50)
            .Parameters.Add("@Hotel", SqlDbType.Money)
            .Parameters.Add("@UPD", SqlDbType.Money)
            .Parameters.Add("@Lainlain", SqlDbType.Money)
            .Parameters.Add("@Keterangan", SqlDbType.VarChar, 100)
            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)

            .Parameters("@NomorST").Value = Me.txtNomor.Text
            .Parameters("@Tgl").Value = Date.Today.Date
            .Parameters("@Lokasi").Value = Lokasi
            .Parameters("@Hotel").Value = Hotel
            .Parameters("@UPD").Value = UPD
            .Parameters("@Lainlain").Value = Lainlain
            .Parameters("@Keterangan").Value = Keterangan
            .Parameters("@Nrp").Value = Nrp

            .ExecuteNonQuery()
        End With
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(GridView2.Rows(0).FindControl("Calendar1"), Calendar).Visible = True
        CType(GridView2.Rows(0).FindControl("TextBox1"), TextBox).Text = ""
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(GridView2.Rows(0).FindControl("TextBox1"), TextBox).Text = Format(CType(GridView2.Rows(0).FindControl("Calendar1"), Calendar).SelectedDate, "dd/MM/yyyy").ToString
        CType(GridView2.Rows(0).FindControl("Calendar1"), Calendar).Visible = False
    End Sub

    Sub Jumlah()
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
            .CommandText = "Select Sum([Hotel]) As tHotel, Sum([UPD]) As tUPD, Sum([Lainlain]) As tLainlain, Sum([Nilai]) As tNilai from tblTransaksi Where NomorST = @NomorST Group By NomorST"

            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)
            .Parameters("@NomorST").Value = Me.txtNomor.Text

            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            tHotel = dr.Item("tHotel").ToString
            tUPD = dr.Item("tUPD").ToString
            tLainlain = dr.Item("tLainlain").ToString
            tNilai = CInt(tHotel) + CInt(tUPD) + CInt(tLainlain)
        End If
    End Sub
End Class
