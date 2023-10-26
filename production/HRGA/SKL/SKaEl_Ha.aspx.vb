Imports System.Data
Imports System.Data.SqlClient


Partial Class HRGA_SKL_SKaEl_Ha
    Inherits System.Web.UI.Page
    Dim d1 As String
    Dim d2 As String
    Dim d3 As String
    Dim d4 As String

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

    'End Sub

    'Protected Sub calakhirlbr_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles calakhirlbr.SelectionChanged
    '    Response.Write(calakhirlbr.SelectedDate.DayOfWeek.ToString)
    'End Sub

    Protected Sub btnawallbr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnawallbr.Click
        Me.calawallbr.Visible = True
        Me.btnawallbr.Visible = False
        Me.btnadd1.Visible = False
        'Me.lblhari7.Visible = True
        'Me.Label9.Visible = True
        'Me.Rdya.Enabled = False
        'Me.Rdno.Enabled = False
        Me.txtnrp.Visible = False
        Me.Button1.Visible = False
    End Sub

    Protected Sub calawallbr_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles calawallbr.SelectionChanged
        Dim csname1 As String = "PopupScript"
        Dim cstype As Type = Me.GetType()
        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript
        Dim con1 As SqlClient.SqlConnection = Nothing
        Dim con2 As SqlClient.SqlConnection = Nothing
        Dim cmd1 As SqlClient.SqlCommand = Nothing
        Dim cmd2 As SqlClient.SqlCommand = Nothing

        Dim dr1 As SqlDataReader
        Dim dr2 As SqlDataReader

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        cmd1 = New SqlClient.SqlCommand
        con1 = New SqlClient.SqlConnection(connectionStrings("Data_abs1ConnectionString").ConnectionString)
        cmd2 = New SqlClient.SqlCommand
        con2 = New SqlClient.SqlConnection(connectionStrings("Data_abs1ConnectionString").ConnectionString)


        'If Me.calawallbr.SelectedDate.Date >= Date.Today.AddDays(-60) Then

            Me.txttglawal.Visible = True
            Me.lblawallbr.Visible = True
            Me.Label1.Visible = True
            Me.ddlawal1.Visible = True
            Me.ddlawal2.Visible = True
            'Me.ddlawal2.Enabled = False
            Me.txttglawal.Text = Format((Me.calawallbr.SelectedDate), "dd/MM/yyyy").ToString
            Session("tglakhir") = Format((Me.calawallbr.SelectedDate.AddDays(1)), "dd/MM/yyyy").ToString
            Me.btnawallbr.Visible = False
            Me.calawallbr.Visible = False

            'End If

            d1 = Weekday(Me.calawallbr.SelectedDate.Date).ToString
            Select Case d1
                Case 1
                    d2 = "Minggu"
                Case 2
                    d2 = "Senin"
                Case 3
                    d2 = "Selasa"
                Case 4
                    d2 = "Rabu"
                Case 5
                    d2 = "Kamis"
                Case 6
                    d2 = "Jumat"
                Case 7
                    d2 = "Sabtu"
            End Select
            Session("dd") = d2.ToString
            'Me.txttglawal.Text = d2.ToString
            d3 = Weekday(Session("tglakhir")).ToString
            Select Case d3
                Case 1
                    d4 = "Minggu"
                Case 2
                    d4 = "Senin"
                Case 3
                    d4 = "Selasa"
                Case 4
                    d4 = "Rabu"
                Case 5
                    d4 = "Kamis"
                Case 6
                    d4 = "Jumat"
                Case 7
                    d4 = "Sabtu"
            End Select
            Session("dd1") = d4.ToString

        'End If

    End Sub

    Protected Sub ddlawal2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlawal2.SelectedIndexChanged
        If Me.ddlawal2.Text <> "-" Then
	    Session("blastfuel") = "50"
	    '--------------senam otd--------------

            'If Me.ddlawal1.Text = "05" Then
                'If Session("dept").ToString = "OTD" Then
                    'blast_fuel()
                    'Session("tc") = Me.ddlawal1.Text
                    'Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " " & Me.ddlawal1.Text & Me.Label1.Text & Me.ddlawal2.Text
                    'Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " 05:30"
                    'Me.TxtAwalSKL.Visible = True
                    'Me.Label2.Visible = True
                    'Me.calawallbr.Visible = False
                    'Me.txttglawal.Visible = False
                    'Me.lblawallbr.Visible = False
                    'Me.ddlawal1.Visible = False
                    'Me.Label1.Visible = False
                    'Me.ddlawal2.Visible = False
                    'Me.txttglakhir.Visible = False
                    'Me.txttglakhir.Text = Session("tglakhir").ToString
                    'Me.ddlakhir1.Visible = False
                    'Me.ddlakhir2.Visible = False
                    'Me.lblakhirlbr.Visible = False
                    'Me.Label7.Visible = True
                    'Me.lblakhirSKL.Visible = True
                    'Me.TxtAkhirSKL.Visible = True
                    'Me.TxtAkhirSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " 06:30"
                    'Me.txtnrp.Visible = True
                    'Me.btnadd1.Visible = True-----select karyawan
                    'Me.Button1.Visible = True
                    'Me.btnadd1.Visible = True
                    'Me.LblNrp.Visible = True
                    'Me.lblnama.Visible = True
                    'Me.listnama.Visible = True
                    'Me.listnrp.Visible = True
                    'Me.listharike7.Visible = True
                    'Me.Labelhari7.Visible = True
                    'Session("RT") = "2"
                'End If
                'End If
                '--------------end of senam otd--------------

                '-------------- piket malam otd--------------

            If Me.ddlawal1.Text = "17" Then
                If Session("dept").ToString = "OTD" Then
                    'blast_fuel()
                    Session("tc") = Me.ddlawal1.Text
                    'Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " " & Me.ddlawal1.Text & Me.Label1.Text & Me.ddlawal2.Text
                    Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " 17:00"
                    Me.TxtAwalSKL.Visible = True
                    'Me.Label2.Visible = True
                    Me.calawallbr.Visible = False
                    Me.txttglawal.Visible = False
                    Me.lblawallbr.Visible = False
                    Me.ddlawal1.Visible = False
                    Me.Label1.Visible = False
                    Me.ddlawal2.Visible = False
                    Me.txttglakhir.Visible = False
                    'Me.txttglakhir.Text = Session("tglakhir").ToString
                    Me.ddlakhir1.Visible = False
                    Me.ddlakhir2.Visible = False
                    Me.lblakhirlbr.Visible = False
                    Me.Label7.Visible = True
                    Me.lblakhirSKL.Visible = True
                    Me.TxtAkhirSKL.Visible = True
                    Me.TxtAkhirSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " 23:00"
                    Me.txtnrp.Visible = True
                    'Me.btnadd1.Visible = True-----select karyawan
                    Me.Button1.Visible = True
                    Me.btnadd1.Visible = True
                    Me.LblNrp.Visible = True
                    Me.lblnama.Visible = True
                    Me.listnama.Visible = True
                    Me.listnrp.Visible = True
                    Me.listharike7.Visible = True
                    Me.Labelhari7.Visible = True
                    Session("RT") = "3"
                Else
                    Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " " & Me.ddlawal1.Text & Me.Label1.Text & Me.ddlawal2.Text
                    Me.TxtAwalSKL.Visible = True
                    'Me.Label2.Visible = True
                    Me.calawallbr.Visible = False
                    Me.txttglawal.Visible = False
                    Me.lblawallbr.Visible = False
                    Me.ddlawal1.Visible = False
                    Me.Label1.Visible = False
                    Me.ddlawal2.Visible = False
                    Me.txttglakhir.Visible = True
                    Me.txttglakhir.Text = Me.txttglawal.Text
                    Me.ddlakhir1.Visible = True
                    Me.ddlakhir2.Visible = True
                    Me.lblakhirlbr.Visible = True
                    Me.Label7.Visible = True
                    Me.lblakhirSKL.Visible = True
                    Session("RT") = "0"
                End If
                'End If
                '--------------end of piket malam otd--------------
            ElseIf Me.ddlawal1.Text = 24 Then
                'blast_fuel()
                Session("blastfuel") = Me.ddlawal1.Text

                If Session("dept").ToString = "ENG" Then
                    'Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " " & Me.ddlawal1.Text & Me.Label1.Text & Me.ddlawal2.Text
                    Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " 23:59"
                    Me.TxtAwalSKL.Visible = True
                    'Me.Label2.Visible = True
                    Me.calawallbr.Visible = False
                    Me.txttglawal.Visible = False
                    Me.lblawallbr.Visible = False
                    Me.ddlawal1.Visible = False
                    Me.Label1.Visible = False
                    Me.ddlawal2.Visible = False
                    Me.txttglakhir.Visible = False
                    'Me.txttglakhir.Text = Session("tglakhir").ToString
                    Me.ddlakhir1.Visible = False
                    Me.ddlakhir2.Visible = False
                    Me.lblakhirlbr.Visible = False
                    Me.Label7.Visible = True
                    Me.lblakhirSKL.Visible = True
                    Me.TxtAkhirSKL.Visible = True
                    Me.TxtAkhirSKL.Text = Session("dd1") & ", " & Session("tglakhir").ToString & " 00:29"
                    Me.txtnrp.Visible = True
                    'Me.btnadd1.Visible = True-----select karyawan
                    Me.Button1.Visible = True
                    Me.btnadd1.Visible = True
                    Me.LblNrp.Visible = True
                    Me.lblnama.Visible = True
                    Me.listnama.Visible = True
                    Me.listnrp.Visible = True
                    Me.listharike7.Visible = True
                    Me.Labelhari7.Visible = True
                    Session("RT") = "1"
                Else
                    'Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " " & Me.ddlawal1.Text & Me.Label1.Text & Me.ddlawal2.Text
                    Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " 23:59"
                    Me.TxtAwalSKL.Visible = True
                    'Me.Label2.Visible = True
                    Me.calawallbr.Visible = False
                    Me.txttglawal.Visible = False
                    Me.lblawallbr.Visible = False
                    Me.ddlawal1.Visible = False
                    Me.Label1.Visible = False
                    Me.ddlawal2.Visible = False
                    Me.txttglakhir.Visible = False
                    'Me.txttglakhir.Text = Session("tglakhir").ToString
                    Me.ddlakhir1.Visible = False
                    Me.ddlakhir2.Visible = False
                    Me.lblakhirlbr.Visible = False
                    Me.Label7.Visible = True
                    Me.lblakhirSKL.Visible = True
                    Me.TxtAkhirSKL.Visible = True
                    Me.TxtAkhirSKL.Text = Session("dd1") & ", " & Session("tglakhir").ToString & " 00:59"
                    Me.txtnrp.Visible = True
                    'Me.btnadd1.Visible = True-----select karyawan
                    Me.Button1.Visible = True
                    Me.btnadd1.Visible = True
                    Me.LblNrp.Visible = True
                    Me.lblnama.Visible = True
                    Me.listnama.Visible = True
                    Me.listnrp.Visible = True
                    Me.listharike7.Visible = True
                    Me.Labelhari7.Visible = True
                    Session("RT") = "1"
                End If

                'End If
            ElseIf Me.ddlawal1.Text = 12 Then
                If (Session("dept").ToString = "OTD") Or (Session("dept").ToString = "ENG") Then
                    Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " 12:00"
                    Me.TxtAwalSKL.Visible = True
                    'Me.Label2.Visible = True
                    Me.calawallbr.Visible = False
                    Me.txttglawal.Visible = False
                    Me.lblawallbr.Visible = False
                    Me.ddlawal1.Visible = False
                    Me.Label1.Visible = False
                    Me.ddlawal2.Visible = False
                    Me.txttglakhir.Visible = False
                    'Me.txttglakhir.Text = Session("tglakhir").ToString
                    Me.ddlakhir1.Visible = False
                    Me.ddlakhir2.Visible = False
                    Me.lblakhirlbr.Visible = False
                    Me.Label7.Visible = True
                    Me.lblakhirSKL.Visible = True
                    Me.TxtAkhirSKL.Visible = True
                    Me.TxtAkhirSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " 12:30"
                    Me.txtnrp.Visible = True
                    'Me.btnadd1.Visible = True-----select karyawan
                    Me.Button1.Visible = True
                    Me.btnadd1.Visible = True
                    Me.LblNrp.Visible = True
                    Me.lblnama.Visible = True
                    Me.listnama.Visible = True
                    Me.listnrp.Visible = True
                    Me.listharike7.Visible = True
                    Me.Labelhari7.Visible = True
                    Session("RT") = "1"
                Else

                    Session("blastfuel") = Me.ddlawal1.Text
                    'Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " " & Me.ddlawal1.Text & Me.Label1.Text & Me.ddlawal2.Text
                    Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " 12:00"
                    Me.TxtAwalSKL.Visible = True
                    'Me.Label2.Visible = True
                    Me.calawallbr.Visible = False
                    Me.txttglawal.Visible = False
                    Me.lblawallbr.Visible = False
                    Me.ddlawal1.Visible = False
                    Me.Label1.Visible = False
                    Me.ddlawal2.Visible = False
                    Me.txttglakhir.Visible = False
                    'Me.txttglakhir.Text = Session("tglakhir").ToString
                    Me.ddlakhir1.Visible = False
                    Me.ddlakhir2.Visible = False
                    Me.lblakhirlbr.Visible = False
                    Me.Label7.Visible = True
                    Me.lblakhirSKL.Visible = True
                    Me.TxtAkhirSKL.Visible = True
                    Me.TxtAkhirSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " 13:00"
                    Me.txtnrp.Visible = True
                    'Me.btnadd1.Visible = True-----select karyawan
                    Me.Button1.Visible = True
                    Me.btnadd1.Visible = True
                    Me.LblNrp.Visible = True
                    Me.lblnama.Visible = True
                    Me.listnama.Visible = True
                    Me.listnrp.Visible = True
                    Me.listharike7.Visible = True
                    Me.Labelhari7.Visible = True
                    Session("RT") = "1"
                End If
                'If Me.ddlawal1.Text <> (12 Or 24) Then
                '    Me.ddlawal2.Visible = True
                'End If


                'else Me.ddlawal1.Text < 24 Then
            Else

                Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " " & Me.ddlawal1.Text & Me.Label1.Text & Me.ddlawal2.Text
                Me.TxtAwalSKL.Visible = True
                'Me.Label2.Visible = True
                Me.calawallbr.Visible = False
                Me.txttglawal.Visible = False
                Me.lblawallbr.Visible = False
                Me.ddlawal1.Visible = False
                Me.Label1.Visible = False
                Me.ddlawal2.Visible = False
                Me.txttglakhir.Visible = True
                Me.txttglakhir.Text = Me.txttglawal.Text
                Me.ddlakhir1.Visible = True
                Me.ddlakhir2.Visible = True
                Me.lblakhirlbr.Visible = True
                Me.Label7.Visible = True
                Me.lblakhirSKL.Visible = True
                Session("RT") = "0"
            End If
            'Me.txttglakhir.Visible = True
            'Me.txttglakhir.Text = Me.txttglawal.Text
            'Me.ddlakhir1.Visible = True
            'Me.ddlakhir2.Visible = True
            'Me.lblakhirlbr.Visible = True
            'Else

            '    Me.btnakhirlbr.Visible = False
            Session("tglakhir1") = Me.txttglakhir.Text
            End If
        'd3 = Weekday(Me.txttglakhir.Text).ToString
        'Select Case d3
        '    Case 1
        '        d4 = "Minggu"
        '    Case 2
        '        d4 = "Senin"
        '    Case 3
        '        d4 = "Selasa"
        '    Case 4
        '        d4 = "Rabu"
        '    Case 5
        '        d4 = "Kamis"
        '    Case 6
        '        d4 = "Jumat"
        '    Case 7
        '        d4 = "Sabtu"
        'End Select
        'Session("dd1") = d4.ToString

    End Sub

    Protected Sub ddlakhir2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlakhir2.SelectedIndexChanged
        If Me.ddlakhir2.Text <> "-" Then
            If Me.txttglakhir.Text = Session("tglakhir1").ToString Then
                Me.TxtAkhirSKL.Text = Session("dd") & ", " & Me.txttglakhir.Text & " " & Me.ddlakhir1.Text & Me.Label1.Text & Me.ddlakhir2.Text
            Else
                'Me.TxtAkhirSKL.Text = Session("DD").ToString
                Me.TxtAkhirSKL.Text = Session("dd1") & ", " & Me.txttglakhir.Text & " " & Me.ddlakhir1.Text & Me.Label1.Text & Me.ddlakhir2.Text

            End If


            'Me.TxtAkhirSKL.Text = Session("dd1") & ", " & Me.txttglakhir.Text & " " & Me.ddlakhir1.Text & Me.Label1.Text & Me.ddlakhir2.Text
            Me.TxtAkhirSKL.Visible = True
            Me.txttglakhir.Visible = False
            Me.lblakhirlbr.Visible = False
            Me.ddlakhir1.Visible = False
            Me.ddlakhir2.Visible = False
            Me.Label8.Visible = True
            Me.txtnrp.Visible = True
            'Me.btnadd1.Visible = True-----select karyawan
            Me.Button1.Visible = True
            Me.btnadd1.Visible = True
            Me.LblNrp.Visible = True
            Me.lblnama.Visible = True
            Me.listnama.Visible = True
            Me.listnrp.Visible = True
            Me.listharike7.Visible = True
            Me.Labelhari7.Visible = True
            Session("RT") = "0"




            ' '' ''Me.Label2.Visible = False
            ' '' ''Me.Label10.Visible = True
            ' '' ''Me.lblUraianKerja.Visible = True
            ' '' ''Me.txturaian.Visible = True
            ' '' ''Me.btnsend.Visible = True

        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        ''Dim con As SqlClient.SqlConnection = Nothing
        ''Dim cmd As SqlClient.SqlCommand = Nothing
        ''Dim con1 As SqlClient.SqlConnection = Nothing
        ''Dim cmd1 As SqlClient.SqlCommand = Nothing

        ''Dim dr As SqlDataReader

        ''cmd = New SqlClient.SqlCommand
        ''cmd1 = New SqlClient.SqlCommand

        ''Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        ''con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)
        ''con1 = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        ''con.Open()
        ''With cmd
        ''    .Connection = con
        ''    .CommandType = CommandType.Text
        ''    .CommandText = "Select Nrp, Nama, Jabatan, Golongan, Departemen, StatusPenerimaan, StatusKawin, StatusBawaKeluarga, AlamatTinggal, Telepon,onsite,harike7  From vw_tblkaryawan Where Nrp = @Nrp "

        ''    .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
        ''    .Parameters("@Nrp").Value = txtnrp.Text
        ''    dr = .ExecuteReader
        ''End With
        ''If dr.Read = True Then
        ''    Dim csname1 As String = "PopupScript"
        ''    Dim csname2 As String = "ButtonClickScript"
        ''    Dim cstype As Type = Me.GetType()
        ''    Dim cs As ClientScriptManager = Page.ClientScript

        ''    If dr.Item("Departemen").ToString <> Session("Dept").ToString Then
        ''        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
        ''            Dim cstext1 As String = "alert('Hanya diijinkan input SKL karyawan departemen " & Session("Dept").ToString & " ');"
        ''            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
        ''            Exit Sub
        ''        End If
        ''    End If
        ''    If (Left((dr.Item("Golongan").ToString), 1) = "4") Or (Left((dr.Item("Golongan").ToString), 1) = "5") Then
        ''        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
        ''            Dim cstext1 As String = "alert('SKL Hanya untuk golongan 1 - 3 or LS ');"
        ''            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
        ''            Exit Sub
        ''        End If
        ''    End If

        ''    If dr.Item("onsite").ToString <> True Then
        ''        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
        ''            Dim cstext1 As String = "alert('Nrp " & Me.txtnrp.Text & " Karyawan Sudah Tidak OnSite...    ');"
        ''            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
        ''            Exit Sub
        ''        End If
        ''    End If
        ''    If Trim(dr.Item("harike7").ToString) = Trim(Session("dd").ToString) Then
        ''        Response.Write(Trim(dr.Item("harike7").ToString))
        ''        Response.Write(Trim(Session("dd").ToString))
        ''        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
        ''            Dim cstext1 As String = "alert('Untuk Hari ke 7 gunakan form hari ke 7');"
        ''            'Dim cstext1 As String = "alert('Hari ke 7 " & dr.Item("nama").ToString & "  adalah " & dr.Item("harike7").ToString & "');"
        ''            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
        ''            Exit Sub
        ''        End If
        ''    End If

        ''    Me.listnrp.Items.Add(dr.Item("nrp").ToString)
        ''    Me.listnama.Items.Add(dr.Item("Nama").ToString)
        ''    Me.listharike7.Items.Add(dr.Item("harike7").ToString)

        ''Else

        ''    If Me.txtnrp.Text <> "" Then
        ''        Dim csname1 As String = "PopupScript"
        ''        Dim csname2 As String = "ButtonClickScript"
        ''        Dim cstype As Type = Me.GetType()
        ''        Dim cs As ClientScriptManager = Page.ClientScript

        ''        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
        ''            Dim cstext1 As String = "alert('Nrp " & Me.txtnrp.Text & " tidak ditemukan di data karyawan...    ');"
        ''            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
        ''        End If
        ''    End If
        ''End If
        ' ''---------------Cuti --------------
        '' ''CutiLapangan()
        '' ''CutiTahunan()
        '' ''CutiBesar()
        '' ''CutiPerjalanan()
        '' ''CutiTotal()
        '' ''PeriodeTugas()
        '' ''AwalCutiTahunan()
        ''Me.txtnrp.Text = ""
        ''Me.Label8.Visible = True
        ''Me.Label10.Visible = True
        ''Me.lblUraianKerja.Visible = True
        ''Me.txturaian.Visible = True
        ''Me.btnsend.Visible = True
        ' ''Me.lblhari7.Visible = True
        ' ''Me.Label9.Visible = True
        ' ''Me.Rdya.Visible = True
        ' ''Me.Rdno.Visible = True
        ' ''con.Close()
    End Sub

    Protected Sub ddlakhir1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlakhir1.SelectedIndexChanged
        Dim jam As String
        jam = 1
        'If DateDiff(DateInterval.Day, (CDate(Me.txttglawal.Text)), (CDate(Me.calakhirlbr.SelectedDate.ToString))) = 0 Then
        If Me.ddlakhir1.Text >= Me.ddlawal1.Text + jam Then
            Me.ddlakhir2.Enabled = True
        End If
        'Else
        '    If Me.ddlakhir1.Text <> "-" Then
        '        'Me.ddlakhir2.Enabled = True
        '    End If
        'End If
    End Sub

    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Define the name and type of the client scripts on the page.
        Dim csname1 As String = "PopupScript"
        Dim cstype As Type = Me.GetType()
        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript
    

        If Session("Dept") = "" Then

            Session("Q") = "skl.aspx"

            Response.Redirect("login.aspx")

        Else

            If InStr(1, Session("LStatus").ToString, "AdminSKL") = 0 Then

                Me.LblNamarequestor.Text = Session("nama")

                Me.LblNRPRequestor.Text = Session("userid")

                Me.LblTanggalCreated.Text = Date.Now
                '========================================================================
                Me.btnawallbr.Visible = False
                If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                    Dim cstext1 As String = "alert('Untuk form SKL saat ini ditutup !! Harap hubungi PIC dept. terkait');"
                    cstext1 += "self.close();"
                    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                    Exit Sub
                End If
                '========================================================================
			Else
				Me.LblNamarequestor.Text = Session("nama")

                Me.LblNRPRequestor.Text = Session("userid")

                Me.LblTanggalCreated.Text = Date.Now
            End If
        End If
    End Sub

    Protected Sub btnakhirlbr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnakhirlbr.Click
        Me.calakhirlbr.Visible = True
        Me.btnakhirlbr.Visible = False
    End Sub

    Protected Sub calakhirlbr_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles calakhirlbr.SelectionChanged
        If Me.calakhirlbr.SelectedDate.Date >= Me.txttglawal.Text Then
            If DateDiff(DateInterval.Day, (CDate(Me.txttglawal.Text)), (CDate(Me.calakhirlbr.SelectedDate.ToString))) <= 1 Then
                Me.txttglakhir.Visible = True
                Me.lblakhirlbr.Visible = True
                'Me.Label2.Visible = True
                Me.ddlakhir1.Visible = True
                Me.ddlakhir2.Visible = True
                Me.txttglakhir.Text = Format((Me.calakhirlbr.SelectedDate), "dd/MM/yyyy").ToString
                Me.btnakhirlbr.Visible = False
                Me.calakhirlbr.Visible = False

            End If
        End If
    End Sub

    Protected Sub listnrp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles listnrp.SelectedIndexChanged
        Me.btnremove.Visible = True
        Me.Button1.Visible = False
        Me.txtnrp.Visible = False
        Me.btnadd1.Visible = False
        Me.Button2.Visible = True
    End Sub

    Protected Sub btnremove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnremove.Click
        Dim pilih1 As String
        Dim pilih2 As String
        Dim pilih3 As String
        pilih1 = Me.listnrp.Items(Me.listnrp.SelectedIndex).ToString
        pilih2 = Me.listnama.Items(Me.listnrp.SelectedIndex).ToString
        pilih3 = Me.listharike7.Items(Me.listnrp.SelectedIndex).ToString



        Me.listnrp.Items.Remove(pilih1)
        Me.listnama.Items.Remove(pilih2)
        Me.listharike7.Items.Remove(pilih3)
        Me.btnremove.Visible = False
        Me.Button1.Visible = True
        Me.txtnrp.Visible = True
        'Me.btnadd1.Visible = True
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Button1.Visible = True
        Me.txtnrp.Visible = True
        Me.btnadd1.Visible = True
        Me.Button2.Visible = False
        Me.btnremove.Visible = False
    End Sub

    Protected Sub btnadd1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd1.Click
        Me.Gridkaryawan1.Visible = True

        'Me.btnadd1.Visible = False
        Me.Button1.Visible = False
        Me.txtnrp.Visible = False

    End Sub

    Protected Sub Gridkaryawan1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Gridkaryawan1.SelectedIndexChanged
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim con1 As SqlClient.SqlConnection = Nothing
        Dim cmd1 As SqlClient.SqlCommand = Nothing

        Dim dr As SqlDataReader

        cmd = New SqlClient.SqlCommand
        cmd1 = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)
        con1 = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            '.CommandText = "Select Nrp, Nama, Jabatan, Golongan, Departemen, StatusPenerimaan, StatusKawin, StatusBawaKeluarga, AlamatTinggal, Telepon,onsite,harike7  From vw_tblkaryawan Where Nrp = @Nrp "
            .CommandText = "Select A.Nrp, A.Nama, A.Jabatan, A.Golongan, A.Departemen, A.StatusPenerimaan, A.StatusKawin, A.StatusBawaKeluarga, A.AlamatTinggal, A.Telepon,A.onsite,A.harike7,B.rostercode  From persis.dbo.vw_tblkaryawan A inner join data_abs1.dbo.karyawan B on A.nrp=B.nrp Where A.Nrp = @Nrp "

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            '.Parameters("@Nrp").Value = txtnrp.Text
            .Parameters("@Nrp").Value = Me.Gridkaryawan1.SelectedRow.Cells(1).Text
            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Dim csname1 As String = "PopupScript"
            Dim csname2 As String = "ButtonClickScript"
            Dim cstype As Type = Me.GetType()
            Dim cs As ClientScriptManager = Page.ClientScript

            If dr.Item("Departemen").ToString <> Session("Dept").ToString Then
                If InStr(1, Session("jabatan").ToString, "HRPGA ADMINISTRATOR") > 0 And InStr(1, Session("ndPosisi").ToString, "HRPGA ADMINSTRATOR") > 0 Or ucase(session("userid").tostring) = "KC04066" Or session("userid").tostring = "6106016" Then
                Else
                    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                        Dim cstext1 As String = "alert('Hanya diijinkan input SKL karyawan departemen " & Session("Dept").ToString & " ');"
                        cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                        Exit Sub
                    End If
                End If
            End If
            If (Left((dr.Item("Golongan").ToString), 1) = "4") Or (Left((dr.Item("Golongan").ToString), 1) = "5") Then
                If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                    Dim cstext1 As String = "alert('SKL Hanya untuk golongan 1 - 3 or LS ');"
                    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                    Exit Sub
                End If
            End If
            '----------------no skl rest time utk blasting dan fuel crew roster 23 , 24 --------
            If dr.Item("rostercode").ToString = "23" Then
                If Session("blastfuel").ToString = "24" Then
                    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                        Dim cstext1 As String = "alert('Untuk Crew Blasting skl rest time sudah dalam system');"
                        cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                        Exit Sub
                    End If
                End If
                If Session("blastfuel").ToString = "12" Then
                    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                        Dim cstext1 As String = "alert('Untuk Crew Blasting skl rest time sudah dalam system');"
                        cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                        Exit Sub
                    End If
                End If
            End If
            If dr.Item("rostercode").ToString = "24" Then
                If Session("blastfuel").ToString = "24" Then
                    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                        Dim cstext1 As String = "alert('Untuk Crew fuel skl rest time sudah dalam system');"
                        cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                        Exit Sub
                    End If
                End If
                If Session("blastfuel").ToString = "12" Then
                    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                        Dim cstext1 As String = "alert('Untuk Crew fuel skl rest time sudah dalam system');"
                        cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                        Exit Sub
                    End If
                End If
            End If
            '--------------------end of roster blast fuel ---------------------
            If dr.Item("onsite").ToString <> True Then
                If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                    Dim cstext1 As String = "alert('Nrp " & Me.txtnrp.Text & " Karyawan Sudah Tidak OnSite...    ');"
                    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                    Exit Sub
                End If
            End If
            If Trim(dr.Item("harike7").ToString) = Trim(Session("dd").ToString) Then
                'Response.Write(Trim(dr.Item("harike7").ToString))
                'Response.Write(Trim(Session("dd").ToString))
                If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                    Dim cstext1 As String = "alert('Untuk Hari ke 7 gunakan form hari ke 7');"
                    'Dim cstext1 As String = "alert('Hari ke 7 " & dr.Item("nama").ToString & "  adalah " & dr.Item("harike7").ToString & "');"
                    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                    Exit Sub
                End If
            End If

            Me.listnrp.Items.Add(dr.Item("nrp").ToString)
            Me.listnama.Items.Add(dr.Item("Nama").ToString)
            Me.listharike7.Items.Add(dr.Item("harike7").ToString)
            Me.Gridkaryawan1.Visible = False
            Me.btnadd1.Visible = True
            Me.Button1.Visible = True
            Me.txtnrp.Visible = True
            Me.txtnrp.Text = ""

        Else

            If Me.txtnrp.Text <> "" Then
                Dim csname1 As String = "PopupScript"
                Dim csname2 As String = "ButtonClickScript"
                Dim cstype As Type = Me.GetType()
                Dim cs As ClientScriptManager = Page.ClientScript

                If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                    Dim cstext1 As String = "alert('Nrp " & Me.txtnrp.Text & " tidak ditemukan di data karyawan...    ');"
                    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                End If
            End If
        End If
        '---------------Cuti --------------
        ''CutiLapangan()
        ''CutiTahunan()
        ''CutiBesar()
        ''CutiPerjalanan()
        ''CutiTotal()
        ''PeriodeTugas()
        ''AwalCutiTahunan()
        Me.txtnrp.Text = ""

        Me.Label8.Visible = True
        Me.Label10.Visible = True
        Me.lblUraianKerja.Visible = True
        Me.txturaian.Visible = True
        Me.btnsend.Visible = True

        'Me.lblhari7.Visible = True
        'Me.Label9.Visible = True
        'Me.Rdya.Visible = True
        'Me.Rdno.Visible = True
        con.Close()

        ' ''Me.listnrp.Items.Add(Me.Gridkaryawan1.SelectedRow.Cells(1).Text)
        ' ''Me.listnama.Items.Add(Me.Gridkaryawan1.SelectedRow.Cells(2).Text)
        ' ''Me.listharike7.Items.Add(Me.Gridkaryawan1.SelectedRow.Cells(3).Text)
        ' ''Me.Gridkaryawan1.Visible = False
        ' ''Me.btnadd1.Visible = True
        '' ''Me.lblhari7.Visible = True
        '' ''Me.Label9.Visible = True
        '' ''Me.Rdya.Visible = True
        '' ''Me.Rdno.Visible = True
        ' ''Me.Button1.Visible = True
        ' ''Me.txtnrp.Visible = True
        ' ''Me.txtnrp.Text = ""

        ' ''Me.Label8.Visible = True
        ' ''Me.Label10.Visible = True
        ' ''Me.lblUraianKerja.Visible = True
        ' ''Me.txturaian.Visible = True
        ' ''Me.btnsend.Visible = True
    End Sub

    Protected Sub txtnrp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnrp.TextChanged
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim con1 As SqlClient.SqlConnection = Nothing
        Dim cmd1 As SqlClient.SqlCommand = Nothing

        Dim dr As SqlDataReader

        cmd = New SqlClient.SqlCommand
        cmd1 = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)
        con1 = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            '.CommandText = "Select Nrp, Nama, Jabatan, Golongan, Departemen, StatusPenerimaan, StatusKawin, StatusBawaKeluarga, AlamatTinggal, Telepon,onsite,harike7  From vw_tblkaryawan Where Nrp = @Nrp "
            .CommandText = "Select A.Nrp, A.Nama, A.Jabatan, A.Golongan, A.Departemen, A.StatusPenerimaan, A.StatusKawin, A.StatusBawaKeluarga, A.AlamatTinggal, A.Telepon,A.onsite,A.harike7,B.rostercode  From persis.dbo.vw_tblkaryawan A inner join data_abs1.dbo.karyawan B on A.nrp=B.nrp Where A.Nrp = @Nrp "

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = txtnrp.Text
            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Dim csname1 As String = "PopupScript"
            Dim csname2 As String = "ButtonClickScript"
            Dim cstype As Type = Me.GetType()
            Dim cs As ClientScriptManager = Page.ClientScript

            If dr.Item("Departemen").ToString <> Session("Dept").ToString Then
                If InStr(1, Session("jabatan").ToString, "HRPGA ADMINISTRATOR") > 0 And InStr(1, Session("ndPosisi").ToString, "HRPGA ADMINSTRATOR") > 0 Or ucase(session("userid").tostring) = "KC04066" Or session("userid").tostring = "6106016" Then
                Else
                    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                        Dim cstext1 As String = "alert('Hanya diijinkan input SKL karyawan departemen " & Session("Dept").ToString & " ');"
                        cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                        Exit Sub
                    End If
                End If
            End If
                If (dr.Item("Golongan").ToString) >= 19 Then
                    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                        Dim cstext1 As String = "alert('SKL Hanya untuk golongan 1 - 18 or LS ');"
                        cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                        Exit Sub
                    End If
                End If
                '----------------no skl rest time utk blasting dan fuel crew roster 23 , 24 --------
                If dr.Item("rostercode").ToString = "23" Then
                    If Session("blastfuel").ToString = "24" Then
                        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                            Dim cstext1 As String = "alert('Untuk Crew Blasting skl rest time sudah dalam system');"
                            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                            Exit Sub
                        End If
                    End If
                    If Session("blastfuel").ToString = "12" Then
                        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                            Dim cstext1 As String = "alert('Untuk Crew Blasting skl rest time sudah dalam system');"
                            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                            Exit Sub
                        End If
                    End If
                End If
                If dr.Item("rostercode").ToString = "24" Then
                    If Session("blastfuel").ToString = "24" Then
                        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                            Dim cstext1 As String = "alert('Untuk Crew fuel skl rest time sudah dalam system');"
                            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                            Exit Sub
                        End If
                    End If
                    If Session("blastfuel").ToString = "12" Then
                        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                            Dim cstext1 As String = "alert('Untuk Crew fuel skl rest time sudah dalam system');"
                            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                            Exit Sub
                        End If
                    End If
                End If
                '--------------------end of roster blast fuel ---------------------
                If dr.Item("onsite").ToString <> True Then
                    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                        Dim cstext1 As String = "alert('Nrp " & Me.txtnrp.Text & " Karyawan Sudah Tidak OnSite...    ');"
                        cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                        Exit Sub
                    End If
                End If
                If Trim(dr.Item("harike7").ToString) = Trim(Session("dd").ToString) Then
                    'Response.Write(Trim(dr.Item("harike7").ToString))
                    'Response.Write(Trim(Session("dd").ToString))
                    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                        Dim cstext1 As String = "alert('Untuk Hari ke 7 gunakan form hari ke 7');"
                        'Dim cstext1 As String = "alert('Hari ke 7 " & dr.Item("nama").ToString & "  adalah " & dr.Item("harike7").ToString & "');"
                        cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                        Exit Sub
                    End If
                End If

                Me.listnrp.Items.Add(dr.Item("nrp").ToString)
                Me.listnama.Items.Add(dr.Item("Nama").ToString)
                Me.listharike7.Items.Add(dr.Item("harike7").ToString)

            Else

                If Me.txtnrp.Text <> "" Then
                    Dim csname1 As String = "PopupScript"
                    Dim csname2 As String = "ButtonClickScript"
                    Dim cstype As Type = Me.GetType()
                    Dim cs As ClientScriptManager = Page.ClientScript

                    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                        Dim cstext1 As String = "alert('Nrp " & Me.txtnrp.Text & " tidak ditemukan di data karyawan...    ');"
                        cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                    End If
                End If
            End If
            '---------------Cuti --------------
            ''CutiLapangan()
            ''CutiTahunan()
            ''CutiBesar()
            ''CutiPerjalanan()
            ''CutiTotal()
            ''PeriodeTugas()
            ''AwalCutiTahunan()
            Me.txtnrp.Text = ""

            Me.Label8.Visible = True
            Me.Label10.Visible = True
            Me.lblUraianKerja.Visible = True
            Me.txturaian.Visible = True
            Me.btnsend.Visible = True

            'Me.lblhari7.Visible = True
            'Me.Label9.Visible = True
            'Me.Rdya.Visible = True
            'Me.Rdno.Visible = True
            con.Close()
    End Sub

    Protected Sub ddlawal1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlawal1.SelectedIndexChanged
        'Session("awal1") = Me.ddlawal1.Text
        '--------------senam otd--------------

        If Me.ddlawal1.Text = "05" Then
            If Session("dept").ToString = "OTD" Then
                'blast_fuel()
                Session("tc") = Me.ddlawal1.Text
                'Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " " & Me.ddlawal1.Text & Me.Label1.Text & Me.ddlawal2.Text
                Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " 05:30"
                Me.TxtAwalSKL.Visible = True
                'Me.Label2.Visible = True
                Me.calawallbr.Visible = False
                Me.txttglawal.Visible = False
                Me.lblawallbr.Visible = False
                Me.ddlawal1.Visible = False
                Me.Label1.Visible = False
                Me.ddlawal2.Visible = False
                Me.txttglakhir.Visible = False
                'Me.txttglakhir.Text = Session("tglakhir").ToString
                Me.ddlakhir1.Visible = False
                Me.ddlakhir2.Visible = False
                Me.lblakhirlbr.Visible = False
                Me.Label7.Visible = True
                Me.lblakhirSKL.Visible = True
                Me.TxtAkhirSKL.Visible = True
                Me.TxtAkhirSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " 06:30"
                Me.txtnrp.Visible = True
                'Me.btnadd1.Visible = True-----select karyawan
                Me.Button1.Visible = True
                Me.btnadd1.Visible = True
                Me.LblNrp.Visible = True
                Me.lblnama.Visible = True
                Me.listnama.Visible = True
                Me.listnrp.Visible = True
                Me.listharike7.Visible = True
                Me.Labelhari7.Visible = True
                Session("RT") = "2"
            End If
        End If
        '--------------end of senam otd--------------

        '-------------- piket malam otd--------------

        If Me.ddlawal1.Text = "17" Then
            If Session("dept").ToString = "OTD" Then
                'blast_fuel()
                Session("tc") = Me.ddlawal1.Text
                'Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " " & Me.ddlawal1.Text & Me.Label1.Text & Me.ddlawal2.Text
                Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " 17:00"
                Me.TxtAwalSKL.Visible = True
                'Me.Label2.Visible = True
                Me.calawallbr.Visible = False
                Me.txttglawal.Visible = False
                Me.lblawallbr.Visible = False
                Me.ddlawal1.Visible = False
                Me.Label1.Visible = False
                Me.ddlawal2.Visible = False
                Me.txttglakhir.Visible = False
                'Me.txttglakhir.Text = Session("tglakhir").ToString
                Me.ddlakhir1.Visible = False
                Me.ddlakhir2.Visible = False
                Me.lblakhirlbr.Visible = False
                Me.Label7.Visible = True
                Me.lblakhirSKL.Visible = True
                Me.TxtAkhirSKL.Visible = True
                Me.TxtAkhirSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " 23:00"
                Me.txtnrp.Visible = True
                'Me.btnadd1.Visible = True-----select karyawan
                Me.Button1.Visible = True
                Me.btnadd1.Visible = True
                Me.LblNrp.Visible = True
                Me.lblnama.Visible = True
                Me.listnama.Visible = True
                Me.listnrp.Visible = True
                Me.listharike7.Visible = True
                Me.Labelhari7.Visible = True
                Session("RT") = "3"
            End If
        End If
        '--------------end of piket malam otd--------------
        If Me.ddlawal1.Text = 24 Then
            'blast_fuel()
            Session("blastfuel") = Me.ddlawal1.Text

            If Session("dept").ToString = "ENG" Then
                'Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " " & Me.ddlawal1.Text & Me.Label1.Text & Me.ddlawal2.Text
                Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " 23:59"
                Me.TxtAwalSKL.Visible = True
                'Me.Label2.Visible = True
                Me.calawallbr.Visible = False
                Me.txttglawal.Visible = False
                Me.lblawallbr.Visible = False
                Me.ddlawal1.Visible = False
                Me.Label1.Visible = False
                Me.ddlawal2.Visible = False
                Me.txttglakhir.Visible = False
                'Me.txttglakhir.Text = Session("tglakhir").ToString
                Me.ddlakhir1.Visible = False
                Me.ddlakhir2.Visible = False
                Me.lblakhirlbr.Visible = False
                Me.Label7.Visible = True
                Me.lblakhirSKL.Visible = True
                Me.TxtAkhirSKL.Visible = True
                Me.TxtAkhirSKL.Text = Session("dd1") & ", " & Session("tglakhir").ToString & " 00:29"
                Me.txtnrp.Visible = True
                'Me.btnadd1.Visible = True-----select karyawan
                Me.Button1.Visible = True
                Me.btnadd1.Visible = True
                Me.LblNrp.Visible = True
                Me.lblnama.Visible = True
                Me.listnama.Visible = True
                Me.listnrp.Visible = True
                Me.listharike7.Visible = True
                Me.Labelhari7.Visible = True
                Session("RT") = "1"
            Else
                'Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " " & Me.ddlawal1.Text & Me.Label1.Text & Me.ddlawal2.Text
                Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " 23:59"
                Me.TxtAwalSKL.Visible = True
                'Me.Label2.Visible = True
                Me.calawallbr.Visible = False
                Me.txttglawal.Visible = False
                Me.lblawallbr.Visible = False
                Me.ddlawal1.Visible = False
                Me.Label1.Visible = False
                Me.ddlawal2.Visible = False
                Me.txttglakhir.Visible = False
                'Me.txttglakhir.Text = Session("tglakhir").ToString
                Me.ddlakhir1.Visible = False
                Me.ddlakhir2.Visible = False
                Me.lblakhirlbr.Visible = False
                Me.Label7.Visible = True
                Me.lblakhirSKL.Visible = True
                Me.TxtAkhirSKL.Visible = True
                Me.TxtAkhirSKL.Text = Session("dd1") & ", " & Session("tglakhir").ToString & " 00:59"
                Me.txtnrp.Visible = True
                'Me.btnadd1.Visible = True-----select karyawan
                Me.Button1.Visible = True
                Me.btnadd1.Visible = True
                Me.LblNrp.Visible = True
                Me.lblnama.Visible = True
                Me.listnama.Visible = True
                Me.listnrp.Visible = True
                Me.listharike7.Visible = True
                Me.Labelhari7.Visible = True
                Session("RT") = "1"
            End If

            ' ''Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " " & Me.ddlawal1.Text & Me.Label1.Text & Me.ddlawal2.Text
            ''Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " 23:59"
            ''Me.TxtAwalSKL.Visible = True
            ' ''Me.Label2.Visible = True
            ''Me.calawallbr.Visible = False
            ''Me.txttglawal.Visible = False
            ''Me.lblawallbr.Visible = False
            ''Me.ddlawal1.Visible = False
            ''Me.Label1.Visible = False
            ''Me.ddlawal2.Visible = False
            ''Me.txttglakhir.Visible = False
            ' ''Me.txttglakhir.Text = Session("tglakhir").ToString
            ''Me.ddlakhir1.Visible = False
            ''Me.ddlakhir2.Visible = False
            ''Me.lblakhirlbr.Visible = False
            ''Me.Label7.Visible = True
            ''Me.lblakhirSKL.Visible = True
            ''Me.TxtAkhirSKL.Visible = True
            ''Me.TxtAkhirSKL.Text = Session("dd1") & ", " & Session("tglakhir").ToString & " 00:59"
            ''Me.txtnrp.Visible = True
            ' ''Me.btnadd1.Visible = True-----select karyawan
            ''Me.Button1.Visible = True
            ''Me.btnadd1.Visible = True
            ''Me.LblNrp.Visible = True
            ''Me.lblnama.Visible = True
            ''Me.listnama.Visible = True
            ''Me.listnrp.Visible = True
            ''Me.listharike7.Visible = True
            ''Me.Labelhari7.Visible = True
            ''Session("RT") = "1"
        End If
        If Me.ddlawal1.Text = 12 Then
            If (Session("dept").ToString = "OTD") Or (Session("dept").ToString = "ENG") Then
                Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " 12:00"
                Me.TxtAwalSKL.Visible = True
                'Me.Label2.Visible = True
                Me.calawallbr.Visible = False
                Me.txttglawal.Visible = False
                Me.lblawallbr.Visible = False
                Me.ddlawal1.Visible = False
                Me.Label1.Visible = False
                Me.ddlawal2.Visible = False
                Me.txttglakhir.Visible = False
                'Me.txttglakhir.Text = Session("tglakhir").ToString
                Me.ddlakhir1.Visible = False
                Me.ddlakhir2.Visible = False
                Me.lblakhirlbr.Visible = False
                Me.Label7.Visible = True
                Me.lblakhirSKL.Visible = True
                Me.TxtAkhirSKL.Visible = True
                Me.TxtAkhirSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " 12:30"
                Me.txtnrp.Visible = True
                'Me.btnadd1.Visible = True-----select karyawan
                Me.Button1.Visible = True
                Me.btnadd1.Visible = True
                Me.LblNrp.Visible = True
                Me.lblnama.Visible = True
                Me.listnama.Visible = True
                Me.listnrp.Visible = True
                Me.listharike7.Visible = True
                Me.Labelhari7.Visible = True
                Session("RT") = "1"
            Else

                Session("blastfuel") = Me.ddlawal1.Text
                'Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " " & Me.ddlawal1.Text & Me.Label1.Text & Me.ddlawal2.Text
                Me.TxtAwalSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " 12:00"
                Me.TxtAwalSKL.Visible = True
                'Me.Label2.Visible = True
                Me.calawallbr.Visible = False
                Me.txttglawal.Visible = False
                Me.lblawallbr.Visible = False
                Me.ddlawal1.Visible = False
                Me.Label1.Visible = False
                Me.ddlawal2.Visible = False
                Me.txttglakhir.Visible = False
                'Me.txttglakhir.Text = Session("tglakhir").ToString
                Me.ddlakhir1.Visible = False
                Me.ddlakhir2.Visible = False
                Me.lblakhirlbr.Visible = False
                Me.Label7.Visible = True
                Me.lblakhirSKL.Visible = True
                Me.TxtAkhirSKL.Visible = True
                Me.TxtAkhirSKL.Text = Session("dd").ToString & ", " & Me.txttglawal.Text & " 13:00"
                Me.txtnrp.Visible = True
                'Me.btnadd1.Visible = True-----select karyawan
                Me.Button1.Visible = True
                Me.btnadd1.Visible = True
                Me.LblNrp.Visible = True
                Me.lblnama.Visible = True
                Me.listnama.Visible = True
                Me.listnrp.Visible = True
                Me.listharike7.Visible = True
                Me.Labelhari7.Visible = True
                Session("RT") = "1"
            End If
            'If Me.ddlawal1.Text <> (12 Or 24) Then
            '    Me.ddlawal2.Visible = True
        End If
    End Sub

    Protected Sub txturaian_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txturaian.TextChanged
        Me.Label10.Visible = False
        Me.btnsend.Visible = True
        Me.btnsend.Enabled = True
        Me.txtnrp.Visible = False
        Me.Button1.Visible = False
        Me.btnadd1.Visible = False
        Me.Button2.Visible = False



    End Sub

    Protected Sub btnsend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsend.Click
		' Define the name and type of the client scripts on the page.
        Dim csname1 As String = "PopupScript"
        Dim cstype As Type = Me.GetType()
        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript
	
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd1 As SqlClient.SqlCommand = Nothing
        Dim cmd2 As SqlClient.SqlCommand = Nothing
        Dim cmd3 As SqlClient.SqlCommand = Nothing
        Dim cmd4 As SqlClient.SqlCommand = Nothing
        Dim nomer As String
        Dim DeptKar As String
        Dim I As Integer
        'Dim hari7 As Integer

        'If Me.Rdya.Checked = True Then
        '    hari7 = 1
        'End If
        'If Me.Rdno.Checked = True Then
        '    hari7 = 0
        'End If


        cmd1 = New SqlClient.SqlCommand
        cmd2 = New SqlClient.SqlCommand
        cmd3 = New SqlClient.SqlCommand
        cmd4 = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("Data_abs1ConnectionString").ConnectionString)

        Dim dr As SqlDataReader
        Dim th1 As String
        Dim th2 As String

        '================== Nomor Terakhir====================
        con.Open()
        With cmd1
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Select Top 1 NoSKL From tbl_SKL1 where skl <>'H7' and NoSKL LIKE '" & Session("Site").ToString & "%' Order By NoSKL Desc"
            dr = .ExecuteReader
        End With
        dr.Read()
        th1 = dr.Item(0).ToString
        th1 = Mid(th1, 10, 2)
        th2 = Mid(Year(Now), 3, 2)

        nomer = dr.Item(0).ToString
        nomer = Mid(nomer, 13, 5) + 1
        If th2 > th1 Then
            nomer = "1"
        End If
        If Len(nomer) = 1 Then
            nomer = Session("Site").ToString & "/HC./" & th2 & "/0000" & nomer & "/SKH"
        ElseIf Len(nomer) = 2 Then
            nomer = Session("Site").ToString & "/HC./" & th2 & "/000" & nomer & "/SKH"
        ElseIf Len(nomer) = 3 Then
            nomer = Session("Site").ToString & "/HC./" & th2 & "/00" & nomer & "/SKH"
        ElseIf Len(nomer) = 4 Then
            nomer = Session("Site").ToString & "/HC./" & th2 & "/0" & nomer & "/SKH"
        ElseIf Len(nomer) = 5 Then
            nomer = Session("Site").ToString & "/HC./" & th2 & "/" & nomer & "/SKH"
        End If
        con.Close()
        ''=====
        ''cek dept karyawan yg lembur
        con.Open()
        With cmd3
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "select nrp, dept from karyawan where nrp=@nrp"
            .Parameters.Add("@nrp", SqlDbType.VarChar, 10)
            .Parameters("@nrp").Value = Me.listnrp.Items(0).Text
            dr = .ExecuteReader
            If dr.read = True Then
                DeptKar = dr.Item(1).tostring
            End If
        End With
        con.Close()
        'akhir cek dept

        If DeptKar = "XXXXX" Then
            'SKL Plant parai
            con.Open()
            With cmd2
                .Connection = con
                .CommandType = CommandType.Text
                .CommandText = "Insert Into tbl_skl1 (NoSKL,NRPrequestor,TglCreated,uraianLembur,aprovedept,nrpaproved,tglaproved,catatan,aprovehr,nrphr,tglhraproved,catatanhr,skl,proses,status) Values(@NoSKL,@NrpUser,getdate(),@uraianlembur,'1','0180124',getdate(),'Approved by System','1',@NrpUser,getdate(),'Approved by PM',@skl,'1','complete')"

                .Parameters.Add("@NoSKL", SqlDbType.VarChar, 50)
                .Parameters.Add("@NrpUser", SqlDbType.VarChar, 10)
                .Parameters.Add("@uraianlembur", SqlDbType.VarChar, 200)
                .Parameters.Add("@skl", SqlDbType.VarChar, 2)

                .Parameters("@NoSKL").Value = nomer
                .Parameters("@NrpUser").Value = Session("Userid").ToString
                .Parameters("@uraianlembur").Value = Me.txturaian.Text
                'If Trim(Session("RT").ToString) = "1" Then
                '    .Parameters("@SKL").Value = "RT"
                'Else
                '    .Parameters("@SKL").Value = "N"
                'End If
                If Trim(Session("RT").ToString) = "1" Then
                    .Parameters("@SKL").Value = "RT"
                    'Elseif
                    '.Parameters("@SKL").Value = "N"
                    'End If
                ElseIf Trim(Session("RT").ToString) = "2" Then
                    .Parameters("@SKL").Value = "SN"
                ElseIf Trim(Session("RT").ToString) = "3" Then
                    .Parameters("@SKL").Value = "PK"
                Else
                    .Parameters("@SKL").Value = "N"
                End If

                .ExecuteNonQuery()
                con.Close()
            End With

            con.Open()
            With cmd2

                .Connection = con
                .CommandType = CommandType.Text
                .CommandText = "Insert Into tbl_Subskl1 (NoSKL,NRP,awallembur,akhirlembur,reject,rejecthr) Values(@No,@Nrp,@awallembur,@akhirlembur,'0','0')"

                .Parameters.Add("@No", SqlDbType.VarChar, 23)
                .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
                '.Parameters.Add("@harike7", SqlDbType.Bit)
                .Parameters.Add("@awallembur", SqlDbType.DateTime)
                .Parameters.Add("@akhirlembur", SqlDbType.DateTime)


                .Parameters("@No").Value = nomer
                '.Parameters("@harike7").Value = hari7
                '.Parameters("@awallembur").Value = Me.TxtAwalSKL.Text
                '.Parameters("@akhirlembur").Value = Me.TxtAkhirSKL.Text
                .Parameters("@awallembur").Value = Right(Me.TxtAwalSKL.Text, 16)
                .Parameters("@akhirlembur").Value = Right(Me.TxtAkhirSKL.Text, 16)
                For I = 0 To Me.listnrp.Items.Count - 1

                    .Parameters("@nrp").Value = Me.listnrp.Items(I).Text
                    .ExecuteNonQuery()

                Next
            End With
            con.Close()

            con.open()
            With cmd4
                .Connection = con
                .CommandType = CommandType.StoredProcedure
                .CommandText = "SP_TOTALHR"
                .Parameters.Add("@noSKL", SqlDbType.VarChar, 21)
                .Parameters("@noSKL").Value = nomer
                .ExecuteNonQuery()
                con.Close()
            End With
            con.close()
        Else
            ' SKL non Plant
            con.Open()
            With cmd2
                .Connection = con
                .CommandType = CommandType.Text
                .CommandText = "Insert Into tbl_skl1 (NoSKL,NRPrequestor,TglCreated,uraianLembur,skl,status) Values(@NoSKL,@NrpUser,getdate(),@uraianlembur,@skl,'Proses Dept.')"

                .Parameters.Add("@NoSKL", SqlDbType.VarChar, 50)
                .Parameters.Add("@NrpUser", SqlDbType.VarChar, 10)
                .Parameters.Add("@uraianlembur", SqlDbType.VarChar, 200)
                .Parameters.Add("@skl", SqlDbType.VarChar, 2)



                .Parameters("@NoSKL").Value = nomer
                .Parameters("@NrpUser").Value = Session("Userid").ToString
                .Parameters("@uraianlembur").Value = Me.txturaian.Text
                'If Trim(Session("RT").ToString) = "1" Then
                '    .Parameters("@SKL").Value = "RT"
                'Else
                '    .Parameters("@SKL").Value = "N"
                'End If
                If Trim(Session("RT").ToString) = "1" Then
                    .Parameters("@SKL").Value = "RT"
                    'Elseif
                    '.Parameters("@SKL").Value = "N"
                    'End If
                ElseIf Trim(Session("RT").ToString) = "2" Then
                    .Parameters("@SKL").Value = "SN"
                ElseIf Trim(Session("RT").ToString) = "3" Then
                    .Parameters("@SKL").Value = "PK"
                Else
                    .Parameters("@SKL").Value = "N"
                End If


                .ExecuteNonQuery()
                con.Close()
            End With



            con.Open()
            With cmd2
				Me.LblNoSKL.Text = nomer
                .Connection = con
                .CommandType = CommandType.Text
                .CommandText = "Insert Into tbl_Subskl1 (NoSKL,NRP,awallembur,akhirlembur,reject,rejecthr) Values(@No,@Nrp,@awallembur,@akhirlembur,'0','0')"

                .Parameters.Add("@No", SqlDbType.VarChar, 23)
                .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
                '.Parameters.Add("@harike7", SqlDbType.Bit)
                .Parameters.Add("@awallembur", SqlDbType.DateTime)
                .Parameters.Add("@akhirlembur", SqlDbType.DateTime)


                .Parameters("@No").Value = nomer
                '.Parameters("@harike7").Value = hari7
                '.Parameters("@awallembur").Value = Me.TxtAwalSKL.Text
                '.Parameters("@akhirlembur").Value = Me.TxtAkhirSKL.Text
                .Parameters("@awallembur").Value = Right(Me.TxtAwalSKL.Text, 16)
                .Parameters("@akhirlembur").Value = Right(Me.TxtAkhirSKL.Text, 16)
                For I = 0 To Me.listnrp.Items.Count - 1

                    .Parameters("@nrp").Value = Me.listnrp.Items(I).Text
                    .ExecuteNonQuery()

                Next
            End With
            con.Close()
        End If
        


        
        '---------insert ke tbl _alert untuk run alert---------
        ' '' ''con.Open()
        ' '' ''With cmd2
        ' '' ''    .Connection = con
        ' '' ''    .CommandType = CommandType.Text
        ' '' ''    .CommandText = "update tbl_alert set noinsert=@noinsert"
        ' '' ''    '.CommandText = "Insert Into tbl_skl (NoSKL,NRPrequestor,TglCreated,uraianLembur) Values(@NoSKL,@NrpUser,getdate(),@uraianlembur)"

        ' '' ''    .Parameters.Add("@noinsert", SqlDbType.VarChar, 20)
        ' '' ''    '.Parameters.Add("@catatan", SqlDbType.VarChar, 200)


        ' '' ''    .Parameters("@noinsert").Value = nomer
        ' '' ''    '.Parameters("@catatan").Value = Me.txtcatatan.Text
        ' '' ''    .ExecuteNonQuery()
        ' '' ''    con.Close()
        ' '' ''End With

        '---------insert ke tbl _alert untuk run alert---------

        
        ' Check to see if the startup script is already registered.
        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
            Dim cstext1 As String = "alert('SKL ["+nomer+"] sudah berhasil disimpan');"
            cstext1 += "self.close();"
            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
        Else
            Dim cstext1 As String = "alert('Insert Into tbl_Subskl1 (NoSKL,NRP,awallembur,akhirlembur,reject,rejecthr) Values(@No,@Nrp,@awallembur,@akhirlembur,'0','0')');"
            cstext1 += "self.close();"
            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
        End If
        'Response.Redirect("listskl1.aspx")
    End Sub
    
End Class
