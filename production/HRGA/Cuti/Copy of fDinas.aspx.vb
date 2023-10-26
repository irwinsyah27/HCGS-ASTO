Imports System.Data
Imports System.Data.SqlClient

Partial Class _fDinas
    Inherits System.Web.UI.Page
    Dim TotLapangan As Integer
    Dim TotTahunan As Integer
    Dim TotBesar As Integer
    Dim TotPerjalanan As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If (Not IsClientScriptBlockRegistered("clientScript")) Then

        '    'Form the script that is to be registered at client side.
        '    Dim scriptString As String = "<script language=JavaScript> function DoClick() {"
        '    scriptString += "myForm.show.value='Welcome to Microsoft .NET'}<"
        '    scriptString += "/"
        '    scriptString += "script>"
        '    RegisterClientScriptBlock("clientScript", scriptString)
        'End If



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
            Dim csname1 As String = "PopupScript"
            Dim csname2 As String = "ButtonClickScript"
            Dim cstype As Type = Me.GetType()
            Dim cs As ClientScriptManager = Page.ClientScript

            If dr.Item("StatusPenerimaan").ToString <> "LOKAL" And dr.Item("StatusPenerimaan").ToString <> "KIRIMAN" Then
                If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                    Dim cstext1 As String = "alert('Hanya diijinkan input dinas karyawan PAMA   ');"
                    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                    Exit Sub
                End If
            End If

            Me.lblNama.Text = dr.Item("Nama").ToString
            Me.lblJabatan.Text = dr.Item("Jabatan").ToString & " / " & dr.Item("Departemen").ToString '& " / " & dr.Item("Golongan").ToString
            Me.lblStatusPenerimaan.Text = dr.Item("StatusPenerimaan").ToString
            Me.lblStatusKawin.Text = dr.Item("StatusKawin").ToString
            Me.lblAlamatdiSite.Text = dr.Item("AlamatTinggal").ToString
            Me.lblNoTelp.Text = dr.Item("Telepon").ToString

            If dr.Item("StatusBawaKeluarga").ToString = True Then
                Me.lblBawaKeluarga.Text = "Ya"
            Else
                Me.lblBawaKeluarga.Text = "Tidak"
            End If

            If Me.txtAwal.Text <> "" Then
                If dr.Item("StatusBawaKeluarga").ToString = True Then
                    Me.lblBawaKeluarga.Text = "Ya"
                    Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(84), "dd MMM yyyy")
                Else
                    Me.lblBawaKeluarga.Text = "Tidak"
                    If dr.Item("StatusPenerimaan").ToString = "LOKAL" Then
                        Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(84), "dd MMM yyyy")
                        'MsgBox("1 :")
                    ElseIf dr.Item("StatusPenerimaan").ToString = "KIRIMAN" Then
                        If Left(dr.Item("Golongan").ToString, 1) <= 2 Then
                            Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(84), "dd MMM yyyy")
                            'MsgBox("2 :")
                        ElseIf Left(dr.Item("Golongan").ToString, 1) >= 3 And Left(dr.Item("Golongan").ToString, 1) <= 4 Then
                            Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(56), "dd MMM yyyy")
                            'MsgBox("3 :")
                        ElseIf Left(dr.Item("Golongan").ToString, 1) = "P" Then
                            If Right(dr.Item("Golongan").ToString, 1) <= 4 Then
                                Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(84), "dd MMM yyyy")
                                'MsgBox("4 :")
                            Else
                                Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(56), "dd MMM yyyy")
                                'MsgBox("5 :")
                            End If

                        ElseIf Left(dr.Item("Golongan").ToString, 1) = "G" Then
                            If Right(dr.Item("Golongan").ToString, 1) <= 5 Then
                                Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(84), "dd MMM yyyy")
                                'MsgBox("6 :")
                            Else
                                Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(56), "dd MMM yyyy")
                                'MsgBox("7 :")
                            End If
                        End If
                    Else
                        'MsgBox("8 :")
                        'Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(84), "dd MMMM yyyy")
                    End If
                End If
            End If

        Else
            Me.lblNama.Text = ""
            Me.lblJabatan.Text = ""
            Me.lblStatusPenerimaan.Text = ""
            Me.lblStatusKawin.Text = ""
            Me.lblBawaKeluarga.Text = ""
            If Me.txtNrp.Text <> "" Then
                Dim csname1 As String = "PopupScript"
                Dim csname2 As String = "ButtonClickScript"
                Dim cstype As Type = Me.GetType()
                Dim cs As ClientScriptManager = Page.ClientScript

                If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                    Dim cstext1 As String = "alert('Nrp " & Me.txtNrp.Text & " tidak ditemukan di data karyawan...    ');"
                    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                End If
            End If

            Me.lblNama.Text = ""
            Me.lblJabatan.Text = ""
            Me.lblStatusPenerimaan.Text = ""
            Me.lblStatusKawin.Text = ""
            Me.lblBawaKeluarga.Text = ""
        End If

        CutiTahunan()
        PeriodeTugas()

    End Sub

    Sub CutiTahunan()
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
            Me.lblSisaCuti1.Text = dr.Item("SisaCuti1").ToString
            Me.lblSisaCuti2.Text = dr.Item("SisaCuti2").ToString
            Me.lblCutiBesar.Text = dr.Item("SisaCutiBesar").ToString
            'Me.lblTotal.Text = dr.Item("Total").ToString

        End If
    End Sub

    Sub PeriodeTugas()
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
                            & ",[Tujuan]" _
                            & ",[Penginapan]" _
                            & ",[tglST]" _
                            & ",[Keperluan]" _
                            & ",[Awal]" _
                            & ",[Akhir]" _
                            & ",[Keterangan]" _
                            & ",[DibuatOleh]" _
                    & ") values (" _
                            & "@Nrp" _
                            & ",@NomorST" _
                            & ",@Tujuan" _
                            & ",@Penginapan" _
                            & ",Getdate()" _
                            & ",@Keperluan" _
                            & ",@Awal" _
                            & ",@Akhir" _
                            & ",@Keterangan" _
                            & ",@DibuatOleh" _
                            & ")"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 50)
            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)
            .Parameters.Add("@Tujuan", SqlDbType.VarChar, 30)
            .Parameters.Add("@Penginapan", SqlDbType.VarChar, 30)
            .Parameters.Add("@Keperluan", SqlDbType.VarChar, 30)
            .Parameters.Add("@Awal", SqlDbType.DateTime)
            .Parameters.Add("@Akhir", SqlDbType.DateTime)
            .Parameters.Add("@Keterangan", SqlDbType.VarChar, 50)
            .Parameters.Add("@DibuatOleh", SqlDbType.NVarChar, 10)

            .Parameters("@Nrp").Value = Me.txtNrp.Text
            .Parameters("@NomorST").Value = "BARU"
            .Parameters("@Tujuan").Value = Me.txtTujuan.Text
            .Parameters("@Penginapan").Value = Me.txtPenginapan.Text
            .Parameters("@Keperluan").Value = "DINAS"
            .Parameters("@Awal").Value = Me.txtAwal.Text
            .Parameters("@Akhir").Value = Me.txtAkhir.Text
            .Parameters("@Keterangan").Value = Me.txtKeterangan.Text
            .Parameters("@DibuatOleh").Value = Session("userid").ToString

            .ExecuteNonQuery()
        End With

        'CariSC()

        ' Define the name and type of the client scripts on the page.
        Dim csname1 As String = "PopupScript"
        Dim csname2 As String = "ButtonClickScript"
        Dim cstype As Type = Me.GetType()

        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript

        ' Check to see if the startup script is already registered.
        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

            Dim cstext1 As String = "alert('Surat Dinas telah tersimpan...');"
            cstext1 += "self.close();"
            'cstext1 += "location='default.aspx'"
            cs.RegisterStartupScript(cstype, csname1, cstext1, True)

        End If

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
            'Response.Redirect("fCuti2.aspx")

        End If
    End Sub

End Class
