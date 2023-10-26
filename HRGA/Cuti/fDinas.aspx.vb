Imports System.Data
Imports System.Data.SqlClient

Partial Class _fDinas
    Inherits System.Web.UI.Page
    Dim TotLapangan As Integer
    Dim TotTahunan As Integer
    Dim TotBesar As Integer
    Dim TotPerjalanan As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./cuti/fdinas.aspx"
            Response.Redirect("../login.aspx")
        End If
		
        If InStr(1, Session("jabatan").ToString, "ICT OFFICER") = 0 And InStr(1, Session("jabatan").ToString, "PERSONNEL SITE OFFICER") = 0 And InStr(1, Session("jabatan").ToString, "PERSONNEL OFFICER") = 0 And InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") = 0 And InStr(1, Session("ndPosisi").ToString, "PERSONNEL SITE OFFICER") = 0 And InStr(1, Session("ndPosisi").ToString, "PERSONNEL OFFICER") = 0 And InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") = 0 And InStr(1, Session("ndPosisi").ToString, "KORLAP MBAP") = 0 And InStr(1, Session("jabatan").ToString, "PAYROLL SITE OFFICER") = 0 Then
            Dim csname1 As String = "PopupScript"
            Dim cstype As Type = Me.GetType()

            Dim cs As ClientScriptManager = Page.ClientScript

            If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

                Dim cstext1 As String = "alert('Anda tidak punya access sebagai Personnel Officer...    ');"
                cstext1 += "location='../login.aspx';"
                cs.RegisterStartupScript(cstype, csname1, cstext1, True)

            End If
        End If
		
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
            .CommandText = "Select Nrp, Nama, Jabatan, Golongan, Departemen, StatusPenerimaan, StatusKawin, StatusBawaKeluarga, AlamatTinggal, Telepon, MasaDinas  From vw_tblKaryawan Where Nrp = @Nrp "

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = txtNrp.Text
            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Dim csname1 As String = "PopupScript"
            Dim csname2 As String = "ButtonClickScript"
            Dim cstype As Type = Me.GetType()
            Dim cs As ClientScriptManager = Page.ClientScript

            Session("jabatan01") = UCase((dr.Item("Jabatan").ToString))

            If dr.Item("StatusPenerimaan").ToString <> "LOKAL" And dr.Item("StatusPenerimaan").ToString <> "KIRIMAN" And dr.Item("StatusPenerimaan").ToString <> "LS" Then
                If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                    Dim cstext1 As String = "alert('Hanya diijinkan input dinas karyawan KPP   ');"
                    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                    Exit Sub
                End If
            End If

            Me.lblNama.Text = dr.Item("Nama").ToString
            Me.lblJabatan.Text = dr.Item("Jabatan").ToString & " / " & dr.Item("Departemen").ToString '& " / " & dr.Item("Golongan").ToString
            Me.lblStatusPenerimaan.Text = dr.Item("StatusPenerimaan").ToString
            Me.lblMasaDinas.Text = dr.Item("MasaDinas").ToString
            Me.lblStatusKawin.Text = dr.Item("StatusKawin").ToString
            Me.lblAlamatdiSite.Text = dr.Item("AlamatTinggal").ToString
            Me.lblNoTelp.Text = dr.Item("Telepon").ToString

            If dr.Item("StatusBawaKeluarga").ToString = True Then
                Me.lblBawaKeluarga.Text = "Ya"
            Else
                Me.lblBawaKeluarga.Text = "Tidak"
            End If

            If Me.txtAwal.Text <> "" Then
                If dr.Item("MasaDinas").ToString = "13" Then
                    Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(90), "dd MMM yyyy")
                    Me.txtHari.Text = 90
                Else
                If dr.Item("MasaDinas").ToString = "12" Then
                    Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(83), "dd MMM yyyy")
                    Me.txtHari.Text = 83
                Else
                If dr.Item("MasaDinas").ToString = "11" Then
                    Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(76), "dd MMM yyyy")
                    Me.txtHari.Text = 76
                Else
                    If dr.Item("MasaDinas").ToString = "8" Then
                        Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(55), "dd MMM yyyy")
                        Me.txtHari.Text = 56
                    Else
                        If dr.Item("MasaDinas").ToString = "6" Then
                            Me.txtAkhir.Text = Format(CDate(Me.txtAwal.Text).AddDays(41), "dd MMM yyyy")
                            Me.txtHari.Text = 41
                                End If
                            End If
                        End If
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
		
		con.Close()

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
		 con.Close()
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
		
		con.Close()

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
            .Parameters.Add("@Keterangan", SqlDbType.VarChar, 200)
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
		
		con.Close()

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
		
		con.Close()
    End Sub

End Class
