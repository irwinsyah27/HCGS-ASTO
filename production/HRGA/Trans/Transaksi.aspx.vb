Imports System.Data
Imports System.Data.SqlClient
Partial Class HRGA_Trans_Transaksi
    Inherits System.Web.UI.Page
    Public EditIndex As Integer = -1
    Dim Nilai As String
    Dim Nrp As String
    Dim Kode As String
    Dim Keterangan As String

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
        Kode = e.NewValues.Item(0).ToString
        Nilai = e.NewValues.Item(1).ToString
        Keterangan = e.NewValues.Item(2).ToString
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
            .CommandText = "Insert Into tblTransaksi " _
                            & "([Tgl]" _
                            & ",[Kode]" _
                            & ",[Nilai]" _
                            & ",[Keterangan]" _
                            & ",[UploadOleh]" _
                            & ",[Nrp]" _
                    & ") values (" _
                            & " Getdate()" _
                            & ",@Kode" _
                            & ",@Nilai" _
                            & ",@Keterangan" _
                            & ",@UploadOleh" _
                            & ",@Nrp" _
                            & ")"

            .Parameters.Add("@Kode", SqlDbType.VarChar, 2)
            .Parameters.Add("@Nilai", SqlDbType.VarChar, 30)
            .Parameters.Add("@Keterangan", SqlDbType.VarChar, 100)
            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters.Add("@UploadOleh", SqlDbType.VarChar, 10)

            .Parameters("@Kode").Value = Kode
            .Parameters("@Nilai").Value = Nilai
            .Parameters("@Keterangan").Value = Keterangan
            .Parameters("@Nrp").Value = Nrp
            .Parameters("@UploadOleh").Value = Session("userid").ToString

            .ExecuteNonQuery()
        End With
    End Sub

    Sub DataKaryawan()
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
            .CommandText = "Select Nrp,Nama,Departemen,StatusKawin,StatusKeluarga,StatusBawaKeluarga = Case StatusBawaKeluarga When 1 Then 'YA' Else 'TIDAK' End  From tblKaryawan Where Nrp = @Nrp"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = Me.txtNrp.Text

            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Me.txtNama.Text = dr.Item("Nama").ToString
            Me.txtDepartemen.Text = dr.Item("Departemen").ToString
            Me.txtStatusKeluarga.Text = dr.Item("StatusKeluarga").ToString
            Me.txtStatusBawaKeluarga.Text = dr.Item("StatusBawaKeluarga").ToString
        Else
            Me.txtNama.Text = ""
            Me.txtDepartemen.Text = ""
            Me.txtStatusKeluarga.Text = ""
            Me.txtStatusBawaKeluarga.Text = ""
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DataKaryawan()
    End Sub
End Class
