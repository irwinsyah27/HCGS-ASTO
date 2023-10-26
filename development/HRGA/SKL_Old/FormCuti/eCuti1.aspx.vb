Imports System.Data
Imports System.Data.SqlClient
'Imports System.Web.Mail
Partial Class _eCuti1
    Inherits System.Web.UI.Page
    Dim TotLapangan As Integer
    Dim TotTahunan As Integer
    Dim TotBesar As Integer
    Dim TotPerjalanan As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.ckLapangan.Checked = True
        'Me.ckLapangan.Checked = True
        'Me.ckTahunan.Checked = True
        'Me.ckBesar.Checked = True

        'Me.txtNrp.Text = Request.QueryString("nrp").ToString
        'Me.lblNomor.Text = Request.QueryString("n").ToString
        'Me.txtLapangan.Text = Request.QueryString("a").ToString
        'Me.txtTahunan.Text = Request.QueryString("b").ToString
        'Me.txtPerjalanan.Text = Request.QueryString("c").ToString
        'Me.txtBesar.Text = Request.QueryString("d").ToString
        'Me.txtAwal.Text = Request.QueryString("e").ToString


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
            .CommandText = "Select Nrp, Nama, Jabatan, Golongan, Departemen, StatusPenerimaan, StatusKawin, StatusBawaKeluarga, AlamatTinggal, Telepon  From tblKaryawan Where Nrp = @Nrp "

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = txtNrp.Text
            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Me.lblNama.Text = dr.Item("Nama").ToString
            Me.lblPemohon.Text = dr.Item("Nama").ToString
            Me.lblJabatan.Text = dr.Item("Jabatan").ToString & " / " & dr.Item("Departemen").ToString '& " / " & dr.Item("Golongan").ToString
            Me.lblStatusPenerimaan.Text = dr.Item("StatusPenerimaan").ToString
            Me.lblStatusKawin.Text = dr.Item("StatusKawin").ToString
            Me.lblAlamatdiSite.Text = dr.Item("AlamatTinggal").ToString
            Me.lblNoTelp.Text = dr.Item("Telepon").ToString
            If dr.Item("StatusBawaKeluarga").ToString = True Then
                Me.lblBawaKeluarga.Text = "Ya"
                Me.RangeValidator1.MaximumValue = 8
                Me.RangeValidator1.ErrorMessage = "Cuti Lapangan yang bisa diamblil maksimal : 8 hari. "
            Else
                Me.lblBawaKeluarga.Text = "Tidak"
                If dr.Item("StatusPenerimaan").ToString = "LOCAL" Then
                    Me.RangeValidator1.MaximumValue = 8
                    Me.RangeValidator1.ErrorMessage = "Cuti Lapangan yang bisa diamblil maksimal : 8 hari. "
                ElseIf dr.Item("StatusPenerimaan").ToString = "KIRIMAN" Then
                    If Left(dr.Item("Golongan").ToString, 1) <= 2 Then
                        Me.RangeValidator1.MaximumValue = 14
                        Me.RangeValidator1.ErrorMessage = "Cuti Lapangan yang bisa diamblil maksimal : 14 hari. "

                    ElseIf Left(dr.Item("Golongan").ToString, 1) >= 3 And Left(dr.Item("Golongan").ToString, 1) <= 4 Then
                        Me.RangeValidator1.MaximumValue = 12
                        Me.RangeValidator1.ErrorMessage = "Cuti Lapangan yang bisa diamblil maksimal : 12 hari. "

                    ElseIf Left(dr.Item("Golongan").ToString, 1) = "P" Then
                        If Right(dr.Item("Golongan").ToString, 1) <= 4 Then
                            Me.RangeValidator1.MaximumValue = 14
                            Me.RangeValidator1.ErrorMessage = "Cuti Lapangan yang bisa diamblil maksimal : 14 hari. "
                        Else
                            Me.RangeValidator1.MaximumValue = 12
                            Me.RangeValidator1.ErrorMessage = "Cuti Lapangan yang bisa diamblil maksimal : 12 hari. "
                        End If

                    ElseIf Left(dr.Item("Golongan").ToString, 1) = "G" Then
                        If Right(dr.Item("Golongan").ToString, 1) <= 5 Then
                            Me.RangeValidator1.MaximumValue = 14
                            Me.RangeValidator1.ErrorMessage = "Cuti Lapangan yang bisa diamblil maksimal : 14 hari. "
                        Else
                            Me.RangeValidator1.MaximumValue = 12
                            Me.RangeValidator1.ErrorMessage = "Cuti Lapangan yang bisa diamblil maksimal : 12 hari. "
                        End If
                    End If
                Else
                    Me.RangeValidator1.MaximumValue = 8
                    Me.RangeValidator1.ErrorMessage = "Cuti Lapangan yang bisa diamblil maksimal : 8 hari. "

                End If

            End If

        Else
            Me.lblNama.Text = ""
            Me.lblJabatan.Text = ""
            Me.lblStatusPenerimaan.Text = ""
            Me.lblStatusKawin.Text = ""
            Me.lblBawaKeluarga.Text = ""
        End If
        '---------------Cuti --------------
        CutiLapangan()
        CutiTahunan()
        CutiBesar()
        CutiPerjalanan()
        CutiTotal()
        PeriodeTugas()
        AwalCutiTahunan()

    End Sub

    Sub CutiLapangan()
        If Me.ckLapangan.Checked = True Then
            Me.txtLapangan.Enabled = True
            If txtLapangan.Text <> "" Then
                TotLapangan = txtLapangan.Text
            Else
                TotLapangan = 0
            End If
        Else
            Me.txtLapangan.Enabled = False
            Me.txtLapangan.Text = 0
        End If
    End Sub

    Sub CutiTahunan()
        'If Me.ckTahunan.Checked = True Then
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim dr As SqlDataReader

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_sisa_cuti"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = txtNrp.Text
            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Me.txtTahunan.Enabled = True
            Me.lblSisaCuti1.Text = dr.Item("SisaCuti1").ToString
            Me.lblSisaCuti2.Text = dr.Item("SisaCuti2").ToString
            Me.lblCutiBesar.Text = dr.Item("SisaCutiBesar").ToString
            Me.lblTotal.Text = dr.Item("Total").ToString
            If Me.txtTahunan.Text <> "" And dr.Item("Total").ToString <> "" Then
                Me.lblSisaCuti.Text = dr.Item("Total").ToString - txtTahunan.Text
                TotTahunan = txtTahunan.Text
                'RangeValidator1.MaximumValue = dr.Item("Total").ToString
                'RangeValidator1.ErrorMessage = "Cuti tahunan tinggal : " & dr.Item("Total").ToString & " hari"
                If (dr.Item("Total").ToString - txtTahunan.Text) < 0 Then
                    Me.lblSisaCuti.ForeColor = Drawing.Color.Red
                    Me.lblHariCTahunan.ForeColor = Drawing.Color.Red
                Else
                    Me.lblSisaCuti.ForeColor = Drawing.Color.Black
                    Me.lblHariCTahunan.ForeColor = Drawing.Color.Black
                End If
            Else
                Me.lblSisaCuti.Text = dr.Item("Total").ToString
                TotTahunan = 0
            End If

        Else

        End If
        If Me.ckTahunan.Checked = True Then
        Else
            Me.txtTahunan.Enabled = False
            Me.txtTahunan.Text = 0
        End If
    End Sub

    Sub CutiBesar()
        If Me.ckBesar.Checked = True Then
            Me.txtBesar.Enabled = True
            If txtBesar.Text <> "" Then
                TotBesar = txtBesar.Text
                Me.lblSisaCutiBesar.Text = CInt(Me.lblCutiBesar.Text) - CInt(Me.txtBesar.Text)
            Else
                TotBesar = 0
            End If
        Else
            Me.txtBesar.Enabled = False
            Me.txtBesar.Text = 0
        End If

    End Sub

    Sub CutiPerjalanan()
        If Me.ckPerjalanan.Checked = True Then
            TotPerjalanan = 2
            Me.txtPerjalanan.Text = 2
            Me.txtPerjalanan.Enabled = True
        Else
            Me.txtPerjalanan.Enabled = False
            Me.txtPerjalanan.Text = 0
        End If
    End Sub

    Sub CutiTotal()
        Me.txtTotal.Text = TotLapangan + TotTahunan + TotBesar + TotPerjalanan
    End Sub

    Sub PeriodeTugas()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim dr As SqlDataReader

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_dinas_terakhir"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = txtNrp.Text
            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Me.lblPeriodeTugas.Text = Format(CDate(dr.Item("Awal").ToString), "dd MMM yyyy") & " s/d " & Format(CDate(dr.Item("Akhir").ToString), "dd MMM yyyy")
        Else
            Me.lblPeriodeTugas.Text = ""
        End If

    End Sub

    Sub AwalCutiTahunan()
        Dim AwalCTahunan As DateTime
        Dim temp1 As DateTime

        Dim i As Integer
        If Me.txtAwal.Text <> "" Then
            AwalCTahunan = txtAwal.Text
            If Me.txtPerjalanan.Text <> "0" Then
                AwalCTahunan = AwalCTahunan.AddDays(CInt(Me.txtLapangan.Text) + 1)
            Else
                AwalCTahunan = AwalCTahunan.AddDays(Me.txtLapangan.Text)
            End If

            temp1 = Format(AwalCTahunan, "dd MMM yyyy")

            If Me.txtTahunan.Text <> "0" Then
                Do While i < CInt(Me.txtTahunan.Text) + CInt(Me.txtBesar.Text)
                    If temp1.DayOfWeek <> DayOfWeek.Sunday Then
                        i += 1
                    End If
                    temp1 = temp1.AddDays(1)
                Loop
                If Me.txtPerjalanan.Text = 0 Then
                    Me.txtAkhir.Text = Format(Format(temp1.AddDays(-1), "dd MMM yyyy"))
                Else
                    Me.txtAkhir.Text = Format(Format(temp1, "dd MMM yyyy"))
                End If
            Else
                Me.txtAkhir.Text = Format(CDate(txtAwal.Text).AddDays(CInt(Me.txtLapangan.Text) - 1 + CInt(Me.txtPerjalanan.Text)), "dd MMM yyyy")
            End If
        End If
    End Sub

    Protected Sub btSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btSave.Click
        Session("Nrp") = Me.txtNrp.Text
        Session("Tanggal") = Format(Date.Today.Date, "dd MMM yyyy")

        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Insert Into tblSutu " _
                            & "([Nrp]" _
                            & ",[NomorST]" _
                            & ",[tglST]" _
                            & ",[Tujuan]" _
                            & ",[Keperluan]" _
                            & ",[Penginapan]" _
                            & ",[Hari]" _
                            & ",[Awal]" _
                            & ",[Akhir]" _
                            & ",[Transport]" _
                            & ",[C_Lapangan]" _
                            & ",[C_Tahunan]" _
                            & ",[C_Besar]" _
                            & ",[C_Perjalanan]" _
                            & ",[C_Lain2]" _
                            & ",[AlamatCuti]" _
                            & ",[Keterangan]" _
                            & ",[SisaCuti_Tahunan]" _
                            & ",[DibuatOleh]" _
                    & ") values (" _
                            & "@Nrp" _
                            & ",@NomorST" _
                            & ",Getdate()" _
                            & ",@Tujuan" _
                            & ",@Keperluan" _
                            & ",@Penginapan" _
                            & ",@Hari" _
                            & ",@Awal" _
                            & ",@Akhir" _
                            & ",@Transport" _
                            & ",@C_Lapangan" _
                            & ",@C_Tahunan" _
                            & ",@C_Besar" _
                            & ",@C_Perjalanan" _
                            & ",@C_Lain2" _
                            & ",@AlamatCuti" _
                            & ",@Keterangan" _
                            & ",@SisaCuti_Tahunan" _
                            & ",@DibuatOleh" _
                            & ")"


            .Parameters.Add("@Nrp", SqlDbType.VarChar, 50)
            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)
            .Parameters.Add("@Tujuan", SqlDbType.VarChar, 20)
            .Parameters.Add("@Keperluan", SqlDbType.VarChar, 30)
            .Parameters.Add("@Penginapan", SqlDbType.VarChar, 50)
            .Parameters.Add("@Hari", SqlDbType.Float)
            .Parameters.Add("@Awal", SqlDbType.DateTime)
            .Parameters.Add("@Akhir", SqlDbType.DateTime)
            .Parameters.Add("@Transport", SqlDbType.VarChar, 20)
            .Parameters.Add("@C_Lapangan", SqlDbType.Int)
            .Parameters.Add("@C_Tahunan", SqlDbType.Int)
            .Parameters.Add("@C_Besar", SqlDbType.Int)
            .Parameters.Add("@C_Perjalanan", SqlDbType.Int)
            .Parameters.Add("@C_Lain2", SqlDbType.Int)
            .Parameters.Add("@AlamatCuti", SqlDbType.VarChar, 50)
            .Parameters.Add("@Keterangan", SqlDbType.VarChar, 50)
            .Parameters.Add("@SisaCuti_Tahunan", SqlDbType.Int)
            .Parameters.Add("@DibuatOleh", SqlDbType.NVarChar, 10)

            .Parameters("@Nrp").Value = Me.txtNrp.Text
            .Parameters("@NomorST").Value = "BARU"
            .Parameters("@Tujuan").Value = Me.txtTujuan.Text
            .Parameters("@Keperluan").Value = "CUTI"
            .Parameters("@Penginapan").Value = ""
            .Parameters("@Hari").Value = Me.txtTotal.Text
            .Parameters("@Awal").Value = Me.txtAwal.Text
            .Parameters("@Akhir").Value = Me.txtAkhir.Text
            .Parameters("@Transport").Value = ""
            If Me.txtLapangan.Text <> "" Then
                .Parameters("@C_Lapangan").Value = Me.txtLapangan.Text
            Else
                .Parameters("@C_Lapangan").Value = 0
            End If
            If Me.txtTahunan.Text <> "" Then
                .Parameters("@C_Tahunan").Value = Me.txtTahunan.Text
            Else
                .Parameters("@C_Tahunan").Value = 0
            End If
            If Me.txtBesar.Text <> "" Then
                .Parameters("@C_Besar").Value = Me.txtBesar.Text
            Else
                .Parameters("@C_Besar").Value = 0
            End If
            If Me.txtPerjalanan.Text <> "" Then
                .Parameters("@C_Perjalanan").Value = Me.txtPerjalanan.Text
            Else
                .Parameters("@C_Perjalanan").Value = 0
            End If

            .Parameters("@C_Lain2").Value = 0 '""
            .Parameters("@AlamatCuti").Value = Me.txtAlamatCuti.Text
            .Parameters("@Keterangan").Value = Me.txtKeterangan.Text
            .Parameters("@SisaCuti_Tahunan").Value = Me.lblSisaCuti.Text
            .Parameters("@DibuatOleh").Value = Session("userid").ToString

            .ExecuteNonQuery()
        End With

        CariSC()

    End Sub

    Protected Sub GridView2_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView2.RowEditing
        'Dim X As String = GridView2.Rows(e.NewEditIndex).Cells(3).Text
        ''Dim X As String = GridView2.DataKeys(0).Value.ToString
        'If X = "D" Then

        '    e.Cancel = True
        '    'MsgBox("1 " & GridView2.Rows(e.NewEditIndex).Cells(3).Text)
        '    MsgBox("1 " & GridView2.DataKeys(0).Value.ToString)
        'Else

        '    'MsgBox("2 " & GridView2.Rows(e.NewEditIndex).Cells(3).Text)
        '    'MsgBox("2 " & GridView2.SelectedRow.Cells(1).Text.ToString)
        'End If

        Dim X As String = GridView2.DataKeys(e.NewEditIndex).Value.ToString
        If X = "0" Then

            'MsgBox("1 " & GridView2.DataKeys(e.NewEditIndex).Value.ToString)

        Else
            'e.Cancel = True
            'MsgBox("2 " & GridView2.Rows(e.NewEditIndex).Cells(3).Text)
            'MsgBox("2 " & GridView2.SelectedRow.Cells(1).Text.ToString)
        End If


        'MsgBox("2 " & GridView2.Rows(e.NewEditIndex).Cells(3).Text)
    End Sub

    Protected Sub GridView2_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GridView2.RowUpdated
        Dim N As String = e.Keys.Item(0).ToString

        Nama = e.NewValues.Item(0).ToString
        Umur = e.NewValues.Item(1).ToString
        Tanggal = e.NewValues.Item(2).ToString
        Dari_Ke = e.NewValues.Item(3).ToString
        Keterangan = e.NewValues.Item(4).ToString

        If N = "0" Then
            'MsgBox("Simpan data baru..")
            insFlight()
        End If

    End Sub

    Dim Nama As String
    Dim Umur As String
    Dim Tanggal As String
    Dim Dari_Ke As String
    Dim Keterangan As String
    Sub insFlight()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Insert Into tblFlight " _
                            & "([NomorST]" _
                            & ",[Nama]" _
                            & ",[Umur]" _
                            & ",[Tanggal]" _
                            & ",[Dari_Ke]" _
                            & ",[Keterangan]" _
                    & ") values (" _
                            & "@NomorST" _
                            & ",@Nama" _
                            & ",@Umur" _
                            & ",@Tanggal" _
                            & ",@Dari_Ke" _
                            & ",@Keterangan" _
                            & ")"

            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)
            .Parameters.Add("@Nama", SqlDbType.VarChar, 30)
            .Parameters.Add("@Umur", SqlDbType.VarChar, 2)
            .Parameters.Add("@Tanggal", SqlDbType.DateTime)
            .Parameters.Add("@Dari_Ke", SqlDbType.VarChar, 50)
            .Parameters.Add("@Keterangan", SqlDbType.VarChar, 30)

            .Parameters("@NomorST").Value = Me.lblNomor.Text
            .Parameters("@Nama").Value = Nama
            .Parameters("@Umur").Value = Umur
            .Parameters("@Tanggal").Value = Tanggal
            .Parameters("@Dari_Ke").Value = Dari_Ke
            .Parameters("@Keterangan").Value = Keterangan

            .ExecuteNonQuery()
        End With
    End Sub

    Sub CariSC()

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
            .CommandText = "Select * From tblSutu Where Nrp = @Nrp And Cast(Month(TglST)As Varchar) + '/' + " & _
                           "Cast(Day(TglST)As Varchar) + '/' + " & _
                           "Cast(Year(TglST)As Varchar) " & _
                           "= Cast(Month(@Tanggal)As Varchar) + '/' + " & _
                           "Cast(Day(@Tanggal)As Varchar) + '/' + " & _
                           "Cast(Year(@Tanggal)As Varchar) "

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters.Add("@Tanggal", SqlDbType.DateTime)
            .Parameters("@Nrp").Value = Session("Nrp").ToString
            .Parameters("@Tanggal").Value = Session("Tanggal").ToString

            dr = .ExecuteReader
        End With
        If dr.Read = True Then

            Response.Redirect("fCuti2.aspx")

        End If
    End Sub

    Protected Sub btUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btUpdate.Click
        Session("Nrp") = Me.txtNrp.Text
        Session("Tanggal") = Format(Date.Today.Date, "dd MMM yyyy")

        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Update tblSutu Set " _
                            & " [Nrp]=@Nrp" _
                            & ",[tglST]=Getdate()" _
                            & ",[Tujuan]=@Tujuan" _
                            & ",[Keperluan]=@Keperluan" _
                            & ",[Penginapan]=@Penginapan" _
                            & ",[Hari]=@Hari" _
                            & ",[Awal]=@Awal" _
                            & ",[Akhir]=@Akhir" _
                            & ",[Transport]=@Transport" _
                            & ",[C_Lapangan]=@C_Lapangan" _
                            & ",[C_Tahunan]=@C_Tahunan" _
                            & ",[C_Besar]=@C_Besar" _
                            & ",[C_Perjalanan]=@C_Perjalanan" _
                            & ",[C_Lain2]=@C_Lain2" _
                            & ",[AlamatCuti]=@AlamatCuti" _
                            & ",[Keterangan]=@Keterangan" _
                            & ",[SisaCuti_Tahunan]=@SisaCuti_Tahunan" _
                            & " Where NomorST = @NomorST"


            .Parameters.Add("@Nrp", SqlDbType.VarChar, 50)
            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)
            .Parameters.Add("@Tujuan", SqlDbType.VarChar, 20)
            .Parameters.Add("@Keperluan", SqlDbType.VarChar, 30)
            .Parameters.Add("@Penginapan", SqlDbType.VarChar, 50)
            .Parameters.Add("@Hari", SqlDbType.Float)
            .Parameters.Add("@Awal", SqlDbType.DateTime)
            .Parameters.Add("@Akhir", SqlDbType.DateTime)
            .Parameters.Add("@Transport", SqlDbType.VarChar, 20)
            .Parameters.Add("@C_Lapangan", SqlDbType.Int)
            .Parameters.Add("@C_Tahunan", SqlDbType.Int)
            .Parameters.Add("@C_Besar", SqlDbType.Int)
            .Parameters.Add("@C_Perjalanan", SqlDbType.Int)
            .Parameters.Add("@C_Lain2", SqlDbType.Int)
            .Parameters.Add("@AlamatCuti", SqlDbType.VarChar, 50)
            .Parameters.Add("@Keterangan", SqlDbType.VarChar, 50)
            .Parameters.Add("@SisaCuti_Tahunan", SqlDbType.Int)

            .Parameters("@Nrp").Value = Me.txtNrp.Text
            .Parameters("@NomorST").Value = Me.lblNomor.Text
            .Parameters("@Tujuan").Value = Me.txtTujuan.Text
            .Parameters("@Keperluan").Value = "CUTI"
            .Parameters("@Penginapan").Value = ""
            .Parameters("@Hari").Value = Me.txtTotal.Text
            .Parameters("@Awal").Value = Me.txtAwal.Text
            .Parameters("@Akhir").Value = Me.txtAkhir.Text
            .Parameters("@Transport").Value = ""
            If Me.txtLapangan.Text <> "" Then
                .Parameters("@C_Lapangan").Value = Me.txtLapangan.Text
            Else
                .Parameters("@C_Lapangan").Value = 0
            End If
            If Me.txtTahunan.Text <> "" Then
                .Parameters("@C_Tahunan").Value = Me.txtTahunan.Text
            Else
                .Parameters("@C_Tahunan").Value = 0
            End If
            If Me.txtBesar.Text <> "" Then
                .Parameters("@C_Besar").Value = Me.txtBesar.Text
            Else
                .Parameters("@C_Besar").Value = 0
            End If
            If Me.txtPerjalanan.Text <> "" Then
                .Parameters("@C_Perjalanan").Value = Me.txtPerjalanan.Text
            Else
                .Parameters("@C_Perjalanan").Value = 0
            End If

            .Parameters("@C_Lain2").Value = 0 '""
            .Parameters("@AlamatCuti").Value = Me.txtAlamatCuti.Text
            .Parameters("@Keterangan").Value = Me.txtKeterangan.Text
            .Parameters("@SisaCuti_Tahunan").Value = Me.lblSisaCuti.Text

            .ExecuteNonQuery()
        End With
    End Sub
End Class
