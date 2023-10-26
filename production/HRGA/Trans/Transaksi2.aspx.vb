Imports System.Data
Imports System.Data.SqlClient
Partial Class HRGA_Trans_Transaksi2
    Inherits System.Web.UI.Page
    Public EditIndex As Integer = -1
    'Dim tHotel As String
    'Dim tUPD As String
    'Dim tLainlain As String
    Dim tNilai1 As String
    Dim sisa As String

    Protected Sub GridView2_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowCreated
        If e.Row.RowType = DataControlRowType.Header Or e.Row.RowIndex.ToString < 0 Then
        Else
            Dim KeyValue As String = Me.GridView2.DataKeys(e.Row.RowIndex).Value.ToString

            If KeyValue = "0" And EditIndex = -1 Then
                e.Row.Attributes.Add("isadd", "1")

                'MsgBox(e.Row.RowIndex.ToString)
                'Me.GridView2.Rows(e.Row.RowIndex).Cells(5).Text = "XX"
            Else
                tNilai1 += e.Row.Cells(3).Text
            End If

        End If

        If e.Row.RowType = DataControlRowType.Footer Then
            Jumlah()
            e.Row.Cells(4).Text = tNilai1

            'Me.txtPengeluaran.Text = tNilai1
            'If Me.DetailsView1.DataItemCount > 0 Then
            '    Me.txtUangMuka.Text = FormatCurrency(Me.DetailsView1.Rows(12).Cells(1).Text)
            '    Me.txtSisa.Text = FormatCurrency(Trim(Me.txtUangMuka.Text) - Trim(Me.txtPengeluaran.Text))
            'End If
        End If

    End Sub
    Protected Sub GridView2_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView2.RowEditing
        EditIndex = e.NewEditIndex
    End Sub

    Dim Nilai As String
    Dim Keterangan As String
    Dim Nrp As String
    Dim Kode As String
    Protected Sub GridView2_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GridView2.RowUpdated
        Dim N As String = e.Keys.Item(0).ToString

        Nilai = e.NewValues.Item(0).ToString
        Keterangan = e.NewValues.Item(1).ToString
        Kode = e.NewValues.Item(2).ToString
        Nrp = Me.DetailsView1.Rows(0).Cells(1).Text

        If N = "0" Then
            insDeklarasi()
        End If

    End Sub


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
                            & ",[Nilai]" _
                            & ",[Keterangan]" _
                            & ",[UploadOleh]" _
                            & ",[Kode]" _
                            & ",[Nrp]" _
                    & ") values (" _
                            & "@NomorST" _
                            & ",@Tgl" _
                            & ",@Nilai" _
                            & ",@Keterangan" _
                            & ",@UploadOleh" _
                            & ",@Kode" _
                            & ",@Nrp" _
                            & ")"

            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)
            .Parameters.Add("@Tgl", SqlDbType.DateTime)
            .Parameters.Add("@Nilai", SqlDbType.Money)
            .Parameters.Add("@Keterangan", SqlDbType.VarChar, 100)
            .Parameters.Add("@UploadOleh", SqlDbType.VarChar, 10)
            .Parameters.Add("@Kode", SqlDbType.VarChar, 1)
            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)

            .Parameters("@NomorST").Value = Me.txtNomor.Text
            .Parameters("@Tgl").Value = Date.Today.Date
            .Parameters("@Nilai").Value = Nilai
            .Parameters("@Keterangan").Value = Keterangan
            .Parameters("@UploadOleh").Value = Session("userid").ToString
            .Parameters("@Kode").Value = Kode
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
            .CommandText = "Select Sum([Nilai]) As tNilai from tblTransaksi Where NomorST = @NomorST Group By NomorST"

            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)
            .Parameters("@NomorST").Value = Me.txtNomor.Text

            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            tNilai1 = dr.Item("tNilai").ToString
            tNilai1 = CInt(tNilai1)
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.txtPengeluaran.Text = FormatCurrencyt(Me.txtPengeluaran.Text)
        'Me.txtUangMuka.Text = FormatCurrency(Me.DetailsView1.Rows(12).Cells(1).Text)
        'Me.txtSisa.Text = FormatCurrency(Trim(Me.txtUangMuka.Text) - Trim(Me.txtPengeluaran.Text))
    End Sub

    Protected Sub txtNomor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNomor.TextChanged
        Me.txtNomor.Text = UCase(Me.txtNomor.Text)
    End Sub
End Class
