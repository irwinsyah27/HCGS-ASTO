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
    Dim Keterangan As String
    Dim Nrp As String
    Dim Kode As String
    Dim UPD As Int32
    Dim Lainlain As Int32
    Dim Nilai As Int32

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

    Protected Sub GridView2_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GridView2.RowUpdated
        Dim N As String = e.Keys.Item(0).ToString
        Nilai = e.NewValues.Item(0).ToString
        Keterangan = e.NewValues.Item(1).ToString
        Kode = e.NewValues.Item(2).ToString
        Nrp = Me.DetailsView1.Rows(0).Cells(1).Text

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
            .CommandText = "SELECT Nrp, NomorST,Nama,AlamatTinggal,Golongan,POH,StatusBawaKeluarga,MasaDinas,Jabatan FROM Persis.dbo.VW_KARYAWAN_SUTU WHERE NomorST = @NomorST "

            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)
            .Parameters("@NomorST").Value = Me.txtNomor.Text
            dr = .ExecuteReader
        End With

        If dr.Read = True Then

            If Me.Kode = "T" Then
                If dr.Item("Golongan") > 18 And dr.Item("Nrp") <> "TA20005" And dr.Item("StatusBawaKeluarga") = 0 Then
                    Me.UPD = 170000 * 2
                Else
                    If dr.Item("Golongan") < 19 And dr.Item("Nrp") <> "TA20005" And dr.Item("StatusBawaKeluarga") = 0 Then
                        Me.UPD = 120000 * 2
                    Else
                        If dr.Item("Nrp") = "TA20005" And dr.Item("StatusBawaKeluarga") = 0 Then
                            Me.UPD = 170000 * 2
                        Else
                            Me.Lainlain = 0
                        End If       
                    End If
                End If
            End If

            If Me.Kode = "B" Then
                If dr.Item("POH") =  "JAKARTA" And dr.Item("StatusBawaKeluarga") = 0 Then
                        Me.Lainlain = 340000
                Else
                    If (dr.Item("POH") = "TAPIN" OR dr.Item("POH") = "BANJAR" OR dr.Item("POH") = "TANAH LAUT" OR dr.Item("POH") = "MALINAU" OR dr.Item("POH") = "LOREH" OR dr.Item("POH") = "BALIKPAPAN" OR dr.Item("POH") = "SAMARINDA") And dr.Item("StatusBawaKeluarga") = 0 Then
                        Me.Lainlain = 300000
                    Else
                        If dr.Item("POH") = "BANJARMASIN" And dr.Item("StatusBawaKeluarga") = 0 Then
                            Me.Lainlain = 275000
                        Else
                            If dr.Item("POH") = "KUTAI TIMUR" And dr.Item("StatusBawaKeluarga") = 0 Then
                                Me.Lainlain = 500000
                            Else
                                If (dr.Item("POH") = "MUARA ENIM" OR dr.Item("POH") = "LAHAT") And dr.Item("StatusBawaKeluarga") = 0 Then
                                    Me.Lainlain = 400000
                                Else
                                    If dr.Item("POH") = "PALEMBANG" And dr.Item("StatusBawaKeluarga") = 0 Then
                                        Me.Lainlain = 280000
                                    Else
                                        If dr.Item("Nrp") = "TA20005" And dr.Item("StatusBawaKeluarga") = 0 Then
                                            Me.Lainlain = 275000
                                        Else
                                            Me.Lainlain = 0
                                        End If                                
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If   
            End If             
        End If
        con.Close()

        insDeklarasi()

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
                            & ",[UPD]" _
                            & ",[Lainlain]" _
                            & ",[Nilai]" _
                            & ",[Keterangan]" _
                            & ",[UploadOleh]" _
                            & ",[Kode]" _
                            & ",[Nrp]" _
                    & ") values (" _
                            & "@NomorST" _
                            & ",@Tgl" _
                            & ",@UPD" _
                            & ",@Lainlain" _
                            & ",@Nilai" _
                            & ",@Keterangan" _
                            & ",@UploadOleh" _
                            & ",@Kode" _
                            & ",@Nrp" _
                            & ")"

            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)
            .Parameters.Add("@Tgl", SqlDbType.DateTime)
            .Parameters.Add("@UPD", SqlDbType.Money)
            .Parameters.Add("@Lainlain", SqlDbType.Money)
            .Parameters.Add("@Nilai", SqlDbType.Money)
            .Parameters.Add("@Keterangan", SqlDbType.VarChar, 100)
            .Parameters.Add("@UploadOleh", SqlDbType.VarChar, 10)
            .Parameters.Add("@Kode", SqlDbType.VarChar, 1)
            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)

            .Parameters("@NomorST").Value = Me.txtNomor.Text
            .Parameters("@Tgl").Value = Date.Today.Date
            .Parameters("@UPD").Value =  UPD
            .Parameters("@Lainlain").Value =  Lainlain
            .Parameters("@Nilai").Value =  UPD + Lainlain
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
