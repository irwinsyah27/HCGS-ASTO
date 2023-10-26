Imports System.Data
Imports System.Data.SqlClient
Partial Class aprovehr
    Inherits System.Web.UI.Page
    Dim dept As String
    Dim nama1 As String



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("noskl") = Request.QueryString("n").ToString
        If Session("Dept") = "" Then
            Session("Q") = "skl/aprovehr1.aspx?n=" & Request.QueryString("n").ToString
            Session("R") = "aprovehr1.aspx?n=" & Request.QueryString("n").ToString
            Response.Redirect("../login.aspx")
        Else
            Me.lblnamahr1.Text = Session("UserName").ToString
            Me.lblnrphr1.Text = Session("userid").ToString
            Me.lbltglhr1.Text = Date.Now
            requestor()
            atasan()
            cek1()

        End If
        'Session("R") = "aprovehr040308.aspx?n=" & Request.QueryString("n").ToString
        'requestor()
        'atasan()
        'aprovehr()
        'prosesi()


        Me.LblNoSKL.Text = UCase(Request.QueryString("n").ToString)
        Session("noskl") = Request.QueryString("n").ToString
        'Me.txtcathr1.Visible = True

    End Sub
    Function cek1()


        '---------------YG(BARU)
        If InStr(1, Session("jabatan").ToString, "PERSONNEL OFFICER") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL OFFICER") > 0 Or InStr(1, Session("jabatan").ToString, "HRPGA DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRPGA SECT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRGA TUTUPAN SECT. HEADD") > 0 Then
            cekisi1()
        ElseIf InStr(1, Session("ndposisi").ToString, "PERSONNEL OFFICER") > 0 Or InStr(1, Session("ndposisi").ToString, "PAYROLL OFFICER") > 0 Or InStr(1, Session("ndposisi").ToString, "HRPGA DEPT. HEAD") > 0 Or InStr(1, Session("ndposisi").ToString, "HRPGA SECT. HEAD") > 0 Or InStr(1, Session("ndposisi").ToString, "HRGA TUTUPAN SECT. HEADD") > 0 Then
            cekisi1()
        ElseIf InStr(1, Session("jabatan").ToString, "Personnel Officer") > 0 Or InStr(1, Session("jabatan").ToString, "Payrool Officer") > 0 Or InStr(1, Session("jabatan").ToString, "HRPGA Dept. Head") > 0 Or InStr(1, Session("jabatan").ToString, "HRPGA Sect. Head") > 0 Then
            cekisi1()
        ElseIf InStr(1, Session("ndposisi").ToString, "Personnel Officer") > 0 Or InStr(1, Session("ndposisi").ToString, "Payrool Officer") > 0 Or InStr(1, Session("ndposisi").ToString, "HRPGA Dept. Head") > 0 Or InStr(1, Session("ndposisi").ToString, "HRPGA Sect. Head") > 0 Then
            cekisi1()
        Else
            Response.Redirect("listskl1.aspx")
        End If



        '---------END OFF YG BARU
    End Function
    Function cekisi1()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("Data_abs1ConnectionString").ConnectionString)

        Dim dr As SqlDataReader
        dept = Session("dept").ToString
        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "SELECT A.NoSKL, B.Nrp, B.AwalLembur, B.akhirLembur, B.rejecthr, B.Totalhr, A.NRPhr, A.TglhrAproved, A.Catatanhr, c.Departemen, c.NAMA, A.nrpaproved, A.tglAproved, a.aprovedept,d.nama,a.aprovehr, e.nama, a.proses FROM Tbl_SKL1 A INNER JOIN Tbl_subSKL1 B ON A.NoSKL = B.NoSKL INNER JOIN persis.dbo.tblkaryawan C ON B.Nrp = C.Nrp inner join persis.dbo.tblkaryawan d on a.nrpaproved=d.nrp left join persis.dbo.tblkaryawan e on a.nrphr=e.nrp WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"
            '.CommandText = "SELECT A.NoSKL, B.Nrp, B.AwalLembur, B.akhirLembur, B.rejecthr, B.Totalhr, A.NRPhr, A.TglhrAproved, A.Catatanhr, c.Dept, c.NAMA, A.nrpaproved, A.tglAproved, a.aprovedept FROM Tbl_SKL1 A INNER JOIN Tbl_subSKL1 B ON A.NoSKL = B.NoSKL INNER JOIN Karyawan C ON B.Nrp = C.Nrp WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"
            '.CommandText = "SELECT A.NoSKL, B.Nrp, B.AwalLembur, B.akhirLembur, B.Aprovehr, B.Totalhr, A.NRPhr, A.TglhrAproved, A.Catatanhr, c.Dept, c.NAMA, A.nrpaproved, A.tglAproved FROM Tbl_SKL A INNER JOIN Tbl_subSKL B ON A.NoSKL = B.NoSKL INNER JOIN Karyawan C ON B.Nrp = C.Nrp WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"
            dr = .ExecuteReader

        End With
        If dr.Read Then
            Session("nama1") = dr.Item(14).ToString
            Session("nama2") = dr.Item(16).ToString
            'Response.Write(dr.Item(16).ToString)
            If dr.Item(6).ToString <> "" Then
                aprovehr()
            ElseIf dr.Item(6).ToString = "" And dr.Item(11).ToString = "" Then
                '-------isi pop up belum diaprove atasan jerr-----

                ' Define the name and type of the client scripts on the page.
                Dim csname1 As String = "PopupScript"
                Dim cstype As Type = Me.GetType()
                ' Get a ClientScriptManager reference from the Page class.
                Dim cs As ClientScriptManager = Page.ClientScript
                ' Check to see if the startup script is already registered.
                If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                    'Dim cstext1 As String = "alert('Aprove SKL Sudah berhasil disimpan');"
                    Dim cstext1 As String = "alert('Maaf, SKL No " & Session("noskl").ToString & " Belum DiAprove Oleh Atasan');"

                    cstext1 += "self.close();"
                    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                End If
                '-------isi pop up belum diaprove atasan jerr-----

            ElseIf dr.Item(13).ToString = False Then
                '-------isi pop up reject atasan jerr-----

                ' Define the name and type of the client scripts on the page.
                Dim csname1 As String = "PopupScript"
                Dim cstype As Type = Me.GetType()
                ' Get a ClientScriptManager reference from the Page class.
                Dim cs As ClientScriptManager = Page.ClientScript
                ' Check to see if the startup script is already registered.
                If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                    'Dim cstext1 As String = "alert('Aprove SKL Sudah berhasil disimpan');"
                    Dim cstext1 As String = "alert('SKL No " & Session("noskl").ToString & " sudah direject Oleh " & Session("nama1").ToString & "  ');"

                    cstext1 += "self.close();"
                    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                End If
                '-------isi pop up reject atasan jerr-----


                'ElseIf dr.Item(16).ToString = False Then
                '    '-------isi pop up reject hr jerr-----

                '    ' Define the name and type of the client scripts on the page.
                '    Dim csname1 As String = "PopupScript"
                '    Dim cstype As Type = Me.GetType()
                '    ' Get a ClientScriptManager reference from the Page class.
                '    Dim cs As ClientScriptManager = Page.ClientScript
                '    ' Check to see if the startup script is already registered.
                '    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                '        'Dim cstext1 As String = "alert('Aprove SKL Sudah berhasil disimpan');"
                '        Dim cstext1 As String = "alert('SKL No " & Session("noskl").ToString & " sudah direject Oleh " & Session("nama2").ToString & "  ');"

                '        cstext1 += "self.close();"
                '        cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                '    End If
                '    '-------isi pop up reject hr jerr-----
                '------------proses-----------
            ElseIf dr.Item(6).ToString = "" And dr.Item(11).ToString <> "" And (dr.Item(17).ToString = "" Or dr.Item(17).ToString = False) Then
                Me.GridView1.Columns(11).Visible = True
                Me.Label11.Visible = True
                Me.LBLHRGA.Visible = True
                Me.Label14.Visible = True
                Me.Label17.Visible = True
                Me.Lblnamahr.Visible = True
                Me.lblnamahr1.Visible = True
                Me.Lblnrphr.Visible = True
                Me.lblnrphr1.Visible = True
                Me.lbltglhr.Visible = True
                Me.lbltglhr1.Visible = True
                'Me.btnrejecthr.Visible = True
                Me.proses.Visible = True
                Me.Label9.Visible = True

                '---------------end of proses-----------
                '----------------validasi------------------
            ElseIf dr.Item(6).ToString = "" And dr.Item(11).ToString <> "" And dr.Item(17).ToString = True Then

                Me.GridView1.Columns(11).Visible = True
                'Me.LA()
                Me.Label11.Visible = True
                Me.LBLHRGA.Visible = True
                Me.Label14.Visible = True
                Me.Label17.Visible = True
                'Me.Label20.Visible = True
                Me.Lblnamahr.Visible = True
                Me.lblnamahr1.Visible = True
                Me.Lblnrphr.Visible = True
                Me.lblnrphr1.Visible = True
                Me.lbltglhr.Visible = True
                Me.lbltglhr1.Visible = True
                'Me.lblcathr.Visible = True
                Me.txtcathr1.Visible = True
                Me.btnhr1.Visible = True
                Me.btnrejecthr.Visible = True
                Me.Label9.Visible = True
                'Me.Label13.Visible = True
                prosesi()
                '-----end of validasi------------
            End If
        Else
            '-------isi pop up belum diaprove atasan jerr-----

            ' Define the name and type of the client scripts on the page.
            Dim csname1 As String = "PopupScript"
            Dim cstype As Type = Me.GetType()
            ' Get a ClientScriptManager reference from the Page class.
            Dim cs As ClientScriptManager = Page.ClientScript
            ' Check to see if the startup script is already registered.
            If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                'Dim cstext1 As String = "alert('Aprove SKL Sudah berhasil disimpan');"
                Dim cstext1 As String = "alert('Maaf, SKL No " & Session("noskl").ToString & " Belum DiAprove Oleh Atasan');"

                cstext1 += "self.close();"
                cs.RegisterStartupScript(cstype, csname1, cstext1, True)
            End If
            '-------isi pop up belum diaprove atasan jerr-----

        End If
        con.Close()

        '' '' '' ''Dim con As SqlClient.SqlConnection = Nothing
        '' '' '' ''Dim cmd As SqlClient.SqlCommand = Nothing
        '' '' '' ''cmd = New SqlClient.SqlCommand

        '' '' '' ''Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        '' '' '' ''con = New SqlClient.SqlConnection(connectionStrings("Data_abs1ConnectionString").ConnectionString)

        '' '' '' ''Dim dr As SqlDataReader
        '' '' '' ''dept = Session("dept").ToString
        '' '' '' ''con.Open()
        '' '' '' ''With cmd
        '' '' '' ''    .Connection = con
        '' '' '' ''    .CommandType = CommandType.Text
        '' '' '' ''    .CommandText = "SELECT A.NoSKL, B.Nrp, B.AwalLembur, B.akhirLembur, B.rejecthr, B.Totalhr, A.NRPhr, A.TglhrAproved, A.Catatanhr, c.Departemen, c.NAMA, A.nrpaproved, A.tglAproved, a.aprovedept,d.nama,a.aprovehr, e.nama FROM Tbl_SKL1 A INNER JOIN Tbl_subSKL1 B ON A.NoSKL = B.NoSKL INNER JOIN persis.dbo.tblkaryawan C ON B.Nrp = C.Nrp inner join persis.dbo.tblkaryawan d on a.nrpaproved=d.nrp left join persis.dbo.tblkaryawan e on a.nrphr=e.nrp WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"
        '' '' '' ''    dr = .ExecuteReader

        '' '' '' ''End With
        '' '' '' ''If dr.Read Then
        '' '' '' ''    Session("nama1") = dr.Item(14).ToString
        '' '' '' ''    Session("nama2") = dr.Item(16).ToString
        '' '' '' ''    If dr.Item(6).ToString <> "" Then
        '' '' '' ''        aprovehr()
        '' '' '' ''    ElseIf dr.Item(6).ToString = "" And dr.Item(11).ToString = "" Then
        '' '' '' ''        '-------isi pop up belum diaprove atasan jerr-----

        '' '' '' ''        ' Define the name and type of the client scripts on the page.
        '' '' '' ''        Dim csname1 As String = "PopupScript"
        '' '' '' ''        Dim cstype As Type = Me.GetType()
        '' '' '' ''        ' Get a ClientScriptManager reference from the Page class.
        '' '' '' ''        Dim cs As ClientScriptManager = Page.ClientScript
        '' '' '' ''        ' Check to see if the startup script is already registered.
        '' '' '' ''        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
        '' '' '' ''            'Dim cstext1 As String = "alert('Aprove SKL Sudah berhasil disimpan');"
        '' '' '' ''            Dim cstext1 As String = "alert('Maaf, SKL No " & Session("noskl").ToString & " Belum DiAprove Oleh Atasan');"

        '' '' '' ''            cstext1 += "self.close();"
        '' '' '' ''            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
        '' '' '' ''        End If
        '' '' '' ''        '-------isi pop up belum diaprove atasan jerr-----

        '' '' '' ''    ElseIf dr.Item(13).ToString = False Then
        '' '' '' ''        '-------isi pop up reject atasan jerr-----

        '' '' '' ''        ' Define the name and type of the client scripts on the page.
        '' '' '' ''        Dim csname1 As String = "PopupScript"
        '' '' '' ''        Dim cstype As Type = Me.GetType()
        '' '' '' ''        ' Get a ClientScriptManager reference from the Page class.
        '' '' '' ''        Dim cs As ClientScriptManager = Page.ClientScript
        '' '' '' ''        ' Check to see if the startup script is already registered.
        '' '' '' ''        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
        '' '' '' ''            'Dim cstext1 As String = "alert('Aprove SKL Sudah berhasil disimpan');"
        '' '' '' ''            Dim cstext1 As String = "alert('SKL No " & Session("noskl").ToString & " sudah direject Oleh " & Session("nama1").ToString & "  ');"

        '' '' '' ''            cstext1 += "self.close();"
        '' '' '' ''            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
        '' '' '' ''        End If
        '' '' '' ''        '-------isi pop up reject atasan jerr-----


        '' '' '' ''        'ElseIf dr.Item(15).ToString = False Then
        '' '' '' ''        '    '-------isi pop up reject hr jerr-----

        '' '' '' ''        '    ' Define the name and type of the client scripts on the page.
        '' '' '' ''        '    Dim csname1 As String = "PopupScript"
        '' '' '' ''        '    Dim cstype As Type = Me.GetType()
        '' '' '' ''        '    ' Get a ClientScriptManager reference from the Page class.
        '' '' '' ''        '    Dim cs As ClientScriptManager = Page.ClientScript
        '' '' '' ''        '    ' Check to see if the startup script is already registered.
        '' '' '' ''        '    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
        '' '' '' ''        '        'Dim cstext1 As String = "alert('Aprove SKL Sudah berhasil disimpan');"
        '' '' '' ''        '        Dim cstext1 As String = "alert('SKL No " & Session("noskl").ToString & " sudah direject Oleh " & Session("nama2").ToString & "  ');"

        '' '' '' ''        '        cstext1 += "self.close();"
        '' '' '' ''        '        cs.RegisterStartupScript(cstype, csname1, cstext1, True)
        '' '' '' ''        '    End If
        '' '' '' ''        '    '-------isi pop up reject hr jerr-----

        '' '' '' ''    ElseIf dr.Item(6).ToString = "" And dr.Item(11).ToString <> "" Then
        '' '' '' ''        Me.GridView1.Columns(11).Visible = True
        '' '' '' ''        Me.Label11.Visible = True
        '' '' '' ''        Me.LBLHRGA.Visible = True
        '' '' '' ''        Me.Label14.Visible = True
        '' '' '' ''        Me.Label17.Visible = True
        '' '' '' ''        Me.Lblnamahr.Visible = True
        '' '' '' ''        Me.lblnamahr1.Visible = True
        '' '' '' ''        Me.Lblnrphr.Visible = True
        '' '' '' ''        Me.lblnrphr1.Visible = True
        '' '' '' ''        Me.lbltglhr.Visible = True
        '' '' '' ''        Me.lbltglhr1.Visible = True
        '' '' '' ''        Me.btnrejecthr.Visible = True
        '' '' '' ''        Me.Label9.Visible = True
        '' '' '' ''    End If
        '' '' '' ''Else
        '' '' '' ''    '-------isi pop up belum diaprove atasan jerr-----

        '' '' '' ''    ' Define the name and type of the client scripts on the page.
        '' '' '' ''    Dim csname1 As String = "PopupScript"
        '' '' '' ''    Dim cstype As Type = Me.GetType()
        '' '' '' ''    ' Get a ClientScriptManager reference from the Page class.
        '' '' '' ''    Dim cs As ClientScriptManager = Page.ClientScript
        '' '' '' ''    ' Check to see if the startup script is already registered.
        '' '' '' ''    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
        '' '' '' ''        'Dim cstext1 As String = "alert('Aprove SKL Sudah berhasil disimpan');"
        '' '' '' ''        Dim cstext1 As String = "alert('Maaf, SKL No " & Session("noskl").ToString & " Belum DiAprove Oleh Atasan');"

        '' '' '' ''        cstext1 += "self.close();"
        '' '' '' ''        cs.RegisterStartupScript(cstype, csname1, cstext1, True)
        '' '' '' ''    End If
        '' '' '' ''    '-------isi pop up belum diaprove atasan jerr-----

        '' '' '' ''End If
        '' '' '' ''con.Close()
    End Function
    Function cek()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        'Dim cmd1 As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand
        'cmd1 = New SqlClient.SqlCommand


        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("Data_abs1ConnectionString").ConnectionString)

        Dim dr As SqlDataReader
        'Dim th1 As String
        'Dim th2 As String

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
           .CommandText = "select nrp, nama, dept, aprovehr, aprove from karyawan  where aprovehr=1 and nrp='" & Session("userid").ToString & "'"


            dr = .ExecuteReader

        End With
        If dr.Read Then
           
            If dr.Item(3).ToString = "True" Then
                
                cekisi()

            Else
                Response.Redirect("listskl1.aspx")

            End If
        Else
            Response.Redirect("listskl1.aspx")

        End If
        con.Close()
    End Function
    Function cekisi()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        'Dim cmd1 As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand
        'cmd1 = New SqlClient.SqlCommand


        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("Data_abs1ConnectionString").ConnectionString)

        Dim dr As SqlDataReader
        'Dim th1 As String
        'Dim th2 As String
        dept = Session("dept").ToString
        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text

            .CommandText = "SELECT A.NoSKL, B.Nrp, B.AwalLembur, B.akhirLembur, B.rejecthr, B.Totalhr, A.NRPhr, A.TglhrAproved, A.Catatanhr, c.Dept, c.NAMA, A.nrpaproved, A.tglAproved FROM Tbl_SKL1 A INNER JOIN Tbl_subSKL1 B ON A.NoSKL = B.NoSKL INNER JOIN Karyawan C ON B.Nrp = C.Nrp WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"
            dr = .ExecuteReader

        End With
        If dr.Read Then
           
            If dr.Item(11).ToString <> "" Then
                If dept = "HRGA" Then
                    If dr.Item(6).ToString <> "" Then
                        'MsgBox("sudah diaprove hr")
                        aprovehr()
                        'Me.Label11.Visible = True
                        'Me.Label14.Visible = True
                        'Me.Label17.Visible = True
                        'Me.Label20.Visible = True
                        'Me.Lblnamahr.Visible = True
                        'Me.lblnamahr1.Visible = True
                        'Me.lblnamahr1.Text = dr.Item(10).ToString
                        'Me.Lblnrphr.Visible = True
                        'Me.lblnrphr1.Visible = True
                        'Me.lblnrphr1.Text = dr.Item(6).ToString
                        'Me.lbltglhr.Visible = True
                        'Me.lbltglhr1.Visible = True
                        'Me.lbltglhr1.Text = dr.Item(7).ToString
                        'Me.lblcathr.Visible = True
                        'Me.lblcathr1.Visible = True
                        'Me.lblcathr1.Text = dr.Item(8).ToString
                        'Me.txtcathr1.Visible = False
                        'Me.btnhr1.Visible = False
                        'Me.Label9.Visible = True
                        'Me.Label9.Text = "SKL No. " & " " & dr.Item(0).ToString & " " & "Sudah Divalidasi Di HR Oleh :"

                    Else
                        'MsgBox("belum diaprove")
                        Me.GridView1.Columns(11).Visible = True
                        'Me.LA()
                        Me.Label11.Visible = True
                        Me.LBLHRGA.Visible = True
                        Me.Label14.Visible = True
                        Me.Label17.Visible = True
                        'Me.Label20.Visible = True
                        Me.Lblnamahr.Visible = True
                        Me.lblnamahr1.Visible = True
                        Me.Lblnrphr.Visible = True
                        Me.lblnrphr1.Visible = True
                        Me.lbltglhr.Visible = True
                        Me.lbltglhr1.Visible = True
                        'Me.lblcathr.Visible = True
                        Me.txtcathr1.Visible = True
                        Me.btnhr1.Visible = True
                        Me.btnrejecthr.Visible = True
                        Me.Label9.Visible = True
                        'Me.Label13.Visible = True
                        prosesi()
                    End If
                Else
                    'MsgBox("beda dept tuch")

                End If
            Else
                Me.Label5.Visible = True
                Me.Label5.Text = "SKL No. " & " " & dr.Item(0).ToString & " " & "Belum DiAprove Oleh Atasan"
            End If
        End If

        con.Close()

    End Function
    Function aprovehr()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        'Dim cmd1 As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand
        'cmd1 = New SqlClient.SqlCommand


        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("Data_abs1ConnectionString").ConnectionString)

        Dim dr As SqlDataReader
        'Dim th1 As String
        'Dim th2 As String
        dept = Session("dept").ToString
        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text

            .CommandText = "SELECT A.NoSKL, B.Nrp, B.AwalLembur, B.akhirLembur, B.rejecthr, B.Totalhr, A.NRPhr, A.TglhrAproved, A.Catatanhr, c.Dept, c.NAMA, A.aprovehr FROM Tbl_SKL1 A INNER JOIN Tbl_subSKL1 B ON A.NoSKL = B.NoSKL INNER JOIN Karyawan C ON A.Nrphr = C.Nrp WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"
            dr = .ExecuteReader

        End With
        If dr.Read Then
            If dr.Item(6).ToString <> "" Then
                'Response.Write("hra")
                'MsgBox("sudah diaprove hr")
                'aprovehr()
                Me.Label11.Visible = True
                Me.LBLHRGA.Visible = True
                Me.Label14.Visible = True
                Me.Label17.Visible = True
                Me.Label20.Visible = True
                Me.Lblnamahr.Visible = True
                Me.lblnamahr1.Visible = True
                Me.lblnamahr1.Text = dr.Item(10).ToString
                Me.Lblnrphr.Visible = True
                Me.lblnrphr1.Visible = True
                Me.lblnrphr1.Text = dr.Item(6).ToString
                Me.lbltglhr.Visible = True
                Me.lbltglhr1.Visible = True
                Me.lbltglhr1.Text = dr.Item(7).ToString
                Me.lblcathr.Visible = True
                Me.lblcathr1.Visible = True
                Me.lblcathr1.Text = dr.Item(8).ToString
                'Me.txtcathr1.Visible = False
                Me.btnhr1.Visible = False
                Me.btnrejecthr.Visible = False
                Me.Label9.Visible = True
                Me.Label13.Visible = False
                If dr.Item(11).ToString = True Then
                    Me.Label9.Text = "SKL No. " & " " & dr.Item(0).ToString & " " & "Sudah Divalidasi Di HR Oleh :"
                End If
                If dr.Item(11).ToString = False Then
                    Me.Label9.Text = "SKL No. " & " " & dr.Item(0).ToString & " " & "Sudah Direject Di HR Oleh :"
                End If
                'If dr.Item(11).ToString = "1" Then
                '    Me.Label9.Text = "SKL No. " & " " & dr.Item(0).ToString & " " & "Sudah Divalidasi Di HR Oleh :"
                'Else
                '    Me.Label9.Text = "SKL No. " & " " & dr.Item(0).ToString & " " & "Sudah Direject Di HR Oleh :"
                'End If
                'Me.Label9.Text = "SKL No. " & " " & dr.Item(0).ToString & " " & "Sudah Divalidasi Di HR Oleh :"
            End If
        End If
    End Function
    Function requestor()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand


        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("Data_abs1ConnectionString").ConnectionString)

        Dim dr As SqlDataReader

        dept = Session("dept").ToString
        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            '.CommandText = "select A.Noskl, A.nrprequestor, A.tglcreated, B.nama, A.uraianlembur FROM tbl_skl A INNER JOIN tbl_login B ON A.nrprequestor=B.nrp WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"
            .CommandText = "select A.Noskl, A.nrprequestor, A.tglcreated, B.nama, A.uraianlembur FROM tbl_skl1 A INNER JOIN KARYAWAN B ON A.nrprequestor=B.nrp WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"

            dr = .ExecuteReader

        End With
        If dr.Read Then
            Me.LblNoSKL.Text = dr.Item(0).ToString
            Me.lblrequest.Text = dr.Item(1).ToString
            Me.LblNamarequestor.Text = dr.Item(3).ToString
            Me.LblTanggalCreated.Text = dr.Item(2).ToString
            Me.lbluraian1.Text = dr.Item(4).ToString

        End If
    End Function
    Function atasan()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand


        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("Data_abs1ConnectionString").ConnectionString)

        Dim dr As SqlDataReader

        dept = Session("dept").ToString
        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "select A.Noskl, A.nrpaproved, A.tglaproved, B.nama, A.Catatan FROM tbl_skl1 A INNER JOIN karyawan B ON A.nrpaproved=B.nrp WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"

            dr = .ExecuteReader

        End With
        If dr.Read Then
            Me.Label5.Visible = True
            Me.Label5.Text = "SKL No. " & " " & dr.Item(0).ToString & " " & "Sudah Diaprove Oleh :"
            Me.Label1.Visible = True
            Me.Label2.Visible = True
            Me.Label3.Visible = True
            Me.Label4.Visible = True
            Me.lblnama.Visible = True
            Me.lblnama1.Visible = True
            Me.lblnama1.Text = dr.Item(3).ToString
            Me.lblnrp.Visible = True
            Me.lblnrp1.Visible = True
            Me.lblnrp1.Text = dr.Item(1).ToString
            Me.lbltgl.Visible = True
            Me.lbltgl1.Visible = True
            Me.lbltgl1.Text = dr.Item(2).ToString
            Me.lblCatatan.Visible = True
            Me.LBLCAT1.Visible = True
            Me.LBLCAT1.Text = dr.Item(4).ToString
            'Me.txtcatatan.Visible = True
            'Me.txtcatatan.Text = dr.Item(8).ToString
            'Me.txtcatatan.Enabled = False
            'Me.txtcatatan.ReadOnly = True

        End If

    End Function

    Protected Sub btnhr1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnhr1.Click
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd1 As SqlClient.SqlCommand = Nothing
        Dim cmd2 As SqlClient.SqlCommand = Nothing
        Dim nomer As String
        Dim I As Integer


        cmd1 = New SqlClient.SqlCommand
        cmd2 = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("Data_abs1ConnectionString").ConnectionString)

        Dim dr As SqlDataReader
        Dim th1 As String
        Dim th2 As String
        con.Open()
        With cmd1
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "update tbl_skl1 set nrphr=@nrphr, tglhraproved=getdate(), catatanhr=@catatanhr, aprovehr='1',status='complete' where noskl='" & Request.QueryString("n").ToString & "'"
            '.CommandText = "Insert Into tbl_skl (NoSKL,NRPrequestor,TglCreated,uraianLembur) Values(@NoSKL,@NrpUser,getdate(),@uraianlembur)"

            .Parameters.Add("@nrphr", SqlDbType.VarChar, 20)
            .Parameters.Add("@catatanhr", SqlDbType.VarChar, 200)
            'MsgBox(Request.QueryString("n").ToString)
            'MsgBox(Me.lblnrphr1.Text)
            'MsgBox(Me.txtcathr1.Text)

            .Parameters("@nrphr").Value = Me.lblnrphr1.Text
            .Parameters("@catatanhr").Value = Me.txtcathr1.Text
            .ExecuteNonQuery()
            con.Close()
        End With

        '---------------insert sp VALIDASI hr---------

        con.Open()
        With cmd2
            .Connection = con
            .CommandType = CommandType.StoredProcedure
            .CommandText = "SP_VALIDASIHR"
            '.CommandText = "update tbl_skl1 set nrphr=@nrphr, tglhraproved=getdate(), catatanhr=@catatanhr, aprovehr='1' where noskl='" & Request.QueryString("n").ToString & "'"
            '.CommandText = "Insert Into tbl_skl (NoSKL,NRPrequestor,TglCreated,uraianLembur) Values(@NoSKL,@NrpUser,getdate(),@uraianlembur)"

            .Parameters.Add("@noSKL", SqlDbType.VarChar, 21)
            '.Parameters.Add("@catatanhr", SqlDbType.VarChar, 200)
            'MsgBox(Request.QueryString("n").ToString)
            'MsgBox(Me.lblnrphr1.Text)
            'MsgBox(Me.txtcathr1.Text)

            .Parameters("@noSKL").Value = Session("noskl").ToString
            '.Parameters("@catatanhr").Value = Me.txtcathr1.Text
            .ExecuteNonQuery()
            con.Close()
        End With
        '---------------end VALIDASI hr----------

        '---------------popup--------------

        ' Define the name and type of the client scripts on the page.
        Dim csname1 As String = "PopupScript"
        Dim cstype As Type = Me.GetType()
        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript
        ' Check to see if the startup script is already registered.
        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
            Dim cstext1 As String = "alert('HR Validate SKL Sudah berhasil disimpan');"
            cstext1 += "self.close();"
            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
            'cstext1 += "location='aprovehr040308.aspx?n=" & Request.QueryString("n").ToString & "'"
            'cs.RegisterStartupScript(cstype, csname1, cstext1, True)
        End If

        Me.btnhr1.Visible = False
        'Response.Redirect(Session("Q"))
    End Sub

    Protected Sub txtcathr1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcathr1.TextChanged
        Me.btnhr1.Enabled = True
        Me.btnrejecthr.Enabled = True
        Me.Label13.Visible = False
    End Sub

    Protected Sub btnrejecthr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnrejecthr.Click
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd1 As SqlClient.SqlCommand = Nothing
        Dim cmd2 As SqlClient.SqlCommand = Nothing
        Dim nomer As String
        Dim I As Integer


        cmd1 = New SqlClient.SqlCommand
        cmd2 = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("Data_abs1ConnectionString").ConnectionString)

        Dim dr As SqlDataReader
        Dim th1 As String
        Dim th2 As String
        con.Open()
        With cmd2
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "update tbl_skl1 set nrphr=@nrphr, tglhraproved=getdate(), catatanhr=@catatanhr, aprovehr='0',status='reject HRGA' where noskl='" & Request.QueryString("n").ToString & "'"
            '.CommandText = "Insert Into tbl_skl (NoSKL,NRPrequestor,TglCreated,uraianLembur) Values(@NoSKL,@NrpUser,getdate(),@uraianlembur)"

            .Parameters.Add("@nrphr", SqlDbType.VarChar, 20)
            .Parameters.Add("@catatanhr", SqlDbType.VarChar, 200)
            'MsgBox(Request.QueryString("n").ToString)
            'MsgBox(Me.lblnrphr1.Text)
            'MsgBox(Me.txtcathr1.Text)

            .Parameters("@nrphr").Value = Me.lblnrphr1.Text
            .Parameters("@catatanhr").Value = Me.txtcathr1.Text
            '.Parameters("@catatanhr").Value = "Reject SKL"

            .ExecuteNonQuery()
            con.Close()
        End With

        '--------------isi all kolom reject di tbl_subskl1----------------

        con.Open()
        With cmd2
            .Connection = con
            .CommandType = CommandType.Text
            '.CommandText = "update tbl_skl1 set nrpaproved=@nrpaproved, tglaproved=getdate(), catatan=@catatan, aprovedept='0' where noskl='" & Request.QueryString("n").ToString & "'"
            .CommandText = "update tbl_subskl1 set rejecthr='1', totalhr='0' where noskl='" & Request.QueryString("n").ToString & "'"
            '.CommandText = "Insert Into tbl_skl (NoSKL,NRPrequestor,TglCreated,uraianLembur) Values(@NoSKL,@NrpUser,getdate(),@uraianlembur)"

            '.Parameters.Add("@nrpaproved", SqlDbType.VarChar, 20)
            '.Parameters.Add("@catatan", SqlDbType.VarChar, 200)
            ''MsgBox(Request.QueryString("n").ToString)
            ''MsgBox(Me.lblnrp1.Text)
            ''MsgBox(Me.txtcatatan.Text)

            '.Parameters("@nrpaproved").Value = Me.lblnrp1.Text
            '.Parameters("@catatan").Value = Me.txtcatatan.Text
            .ExecuteNonQuery()
            con.Close()
        End With


        '----------------end off reject--------------

        '---------------popup--------------

        ' Define the name and type of the client scripts on the page.
        Dim csname1 As String = "PopupScript"
        Dim cstype As Type = Me.GetType()
        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript
        ' Check to see if the startup script is already registered.
        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
            Dim cstext1 As String = "alert('HR Reject SKL Sudah berhasil disimpan');"
            cstext1 += "self.close();"
            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
        End If

        Me.btnhr1.Visible = False
        'Response.Redirect(Session("Q"))
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Me.lblcathr.Visible = True
        Me.txtcathr1.Visible = True
        Me.btnhr1.Visible = True
        Me.Label20.Visible = True
        Me.Label13.Visible = True
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Me.lblcathr.Visible = True
        Me.txtcathr1.Visible = True
        Me.btnhr1.Visible = True
        Me.Label20.Visible = True
        Me.Label13.Visible = True
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles proses.Click
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd1 As SqlClient.SqlCommand = Nothing
        Dim cmd2 As SqlClient.SqlCommand = Nothing
        Dim cmd3 As SqlClient.SqlCommand = Nothing
        Dim nomer As String
        Dim I As Integer


        cmd1 = New SqlClient.SqlCommand
        cmd2 = New SqlClient.SqlCommand
        cmd3 = New SqlClient.SqlCommand
        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("Data_abs1ConnectionString").ConnectionString)

        Dim dr As SqlDataReader
        Dim th1 As String
        Dim th2 As String

        '---------------insert sp total hr---------

        con.Open()
        With cmd2
            .Connection = con
            .CommandType = CommandType.StoredProcedure
            .CommandText = "SP_TOTALHR"
            '.CommandText = "update tbl_skl1 set nrphr=@nrphr, tglhraproved=getdate(), catatanhr=@catatanhr, aprovehr='1' where noskl='" & Request.QueryString("n").ToString & "'"
            '.CommandText = "Insert Into tbl_skl (NoSKL,NRPrequestor,TglCreated,uraianLembur) Values(@NoSKL,@NrpUser,getdate(),@uraianlembur)"

            .Parameters.Add("@noSKL", SqlDbType.VarChar, 21)
            '.Parameters.Add("@catatanhr", SqlDbType.VarChar, 200)
            'MsgBox(Request.QueryString("n").ToString)
            'MsgBox(Me.lblnrphr1.Text)
            'MsgBox(Me.txtcathr1.Text)

            .Parameters("@noSKL").Value = Session("noskl").ToString
            '.Parameters("@catatanhr").Value = Me.txtcathr1.Text
            .ExecuteNonQuery()
            con.Close()
        End With
        '---------------end total hr----------

        '---------------proses hr---------

        con.Open()
        With cmd2
            .Connection = con
            .CommandType = CommandType.Text
            '.CommandText = "SP_TOTALHR"
            .CommandText = "update tbl_skl1 set proses ='1' where noskl='" & Request.QueryString("n").ToString & "'"
            '.CommandText = "Insert Into tbl_skl (NoSKL,NRPrequestor,TglCreated,uraianLembur) Values(@NoSKL,@NrpUser,getdate(),@uraianlembur)"

            '.Parameters.Add("@noSKL", SqlDbType.VarChar, 20)
            ''.Parameters.Add("@catatanhr", SqlDbType.VarChar, 200)
            ''MsgBox(Request.QueryString("n").ToString)
            ''MsgBox(Me.lblnrphr1.Text)
            ''MsgBox(Me.txtcathr1.Text)

            '.Parameters("@noSKL").Value = Session("noskl").ToString
            '.Parameters("@catatanhr").Value = Me.txtcathr1.Text
            .ExecuteNonQuery()
            con.Close()

            '----------load page again---------------

            Dim csname1 As String = "PopupScript"
            Dim cstype As Type = Me.GetType()

            ' Get a ClientScriptManager reference from the Page class.
            Dim cs As ClientScriptManager = Page.ClientScript

            ' Check to see if the startup script is already registered.
            If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

                Dim cstext1 As String = "alert('Proses perhitungan total hr selesai, lanjutkan dengan validasi ????...    ');"
                cstext1 += "location='aprovehr1.aspx?n=" & Request.QueryString("n").ToString & "'"
                cs.RegisterStartupScript(cstype, csname1, cstext1, True)

            End If

            '----------------end load page----------


        End With
        '---------------end proses----------

        '' ''---------------popup--------------

        '' '' Define the name and type of the client scripts on the page.
        ' ''Dim csname1 As String = "PopupScript"
        ' ''Dim cstype As Type = Me.GetType()
        '' '' Get a ClientScriptManager reference from the Page class.
        ' ''Dim cs As ClientScriptManager = Page.ClientScript
        '' '' Check to see if the startup script is already registered.
        ' ''If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
        ' ''    Dim cstext1 As String = "alert('HR Validate SKL Sudah berhasil disimpan');"
        ' ''    cstext1 += "self.close();"
        ' ''    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
        ' ''End If

        ' ''Me.btnhr1.Visible = False
        Me.txtcathr1.Visible = True
        Me.btnhr1.Visible = True
        Me.btnrejecthr.Visible = True
        Me.Label1.Visible = True
        Me.proses.Visible = False



    End Sub
    Function prosesi()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand


        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("Data_abs1ConnectionString").ConnectionString)

        Dim dr As SqlDataReader

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "select A.Noskl, A.nrpaproved, A.tglaproved, B.nama, A.Catatan,A.proses, A.aprovehr, A.aprovedept FROM tbl_skl1 A INNER JOIN karyawan B ON A.nrpaproved=B.nrp WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"

            dr = .ExecuteReader

        End With
        If dr.Read Then
            If dr.Item("proses").ToString = True Then
                'Response.Write("1")
                Me.proses.Visible = False
                If dr.Item("aprovehr").ToString <> "" Then
                    'Response.Write("2")
                    Me.btnrejecthr.Visible = False
                    Me.btnhr1.Visible = False
                    Me.txtcathr1.Visible = False
                Else
                    'Response.Write("3")
                    Me.btnrejecthr.Visible = True
                    Me.btnhr1.Visible = True
                    Me.txtcathr1.Enabled = True
                    Me.txtcathr1.Visible = True
                    Me.Label13.Visible = True
                    'Me.TextBox1.Visible = True


                End If
                'Response.Write("sudah diproses")
                'Response.Redirect(Session("R"))
            End If
            If dr.Item("proses").ToString = False Then
                'Response.Write("4")
                If dr.Item("aprovedept").ToString = True Then
                    'Response.Write("5")
                    Me.proses.Visible = True
                    Me.btnrejecthr.Visible = False
                    Me.btnhr1.Visible = False
                    Me.txtcathr1.Visible = True
                    Me.txtcathr1.Enabled = False
                Else
                    'Response.Write("6")
                    Me.proses.Visible = False
                    Me.btnrejecthr.Visible = False
                    Me.btnhr1.Visible = False
                    Me.txtcathr1.Visible = True
                    Me.txtcathr1.Enabled = False
                    'Response.Write("belum diproses")
                End If

            End If

            End If
            'Response.Redirect(Session("R"))
    End Function

    Protected Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Me.btnhr1.Enabled = True
        Me.btnrejecthr.Enabled = True
        Me.Label13.Visible = False
    End Sub
End Class
