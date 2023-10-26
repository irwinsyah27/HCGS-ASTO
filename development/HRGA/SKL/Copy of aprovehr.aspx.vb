Imports System.Data
Imports System.Data.SqlClient
Partial Class aprovehr
    Inherits System.Web.UI.Page
    Dim dept As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Dept") = "" Then
            Session("Q") = "skl/aprovehr.aspx?n=" & Request.QueryString("n").ToString
            Response.Redirect("../login.aspx")
        Else
            Me.lblnamahr1.Text = Session("UserName").ToString
            Me.lblnrphr1.Text = Session("userid").ToString
            Me.lbltglhr1.Text = Date.Now

            cek()

        End If
        requestor()
        atasan()
        'aprovehr()

        Me.LblNoSKL.Text = UCase(Request.QueryString("n").ToString)

    End Sub
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
            '.CommandText = "update tbl_shesms set takeupdept=@takeupdept, namadept=@namadept where No='" & Request.QueryString("n").ToString & "'"

            '.CommandText = "select A.nrp, B.nama, B.dept, B.aprove from tbl_login A inner join karyawan B on a.nrp=b.nrp where b.dept='" & Session("dept").ToString & "' and b.nrp='" & Session("userid").ToString & "'"
            '.CommandText = "select A.nrp, B.nama, B.dept, B.aprovehr from tbl_login A inner join karyawan B on a.nrp=b.nrp where b.aprovehr=1"
            '.CommandText = "select nrp, nama, dept, aprovehr, aprove from karyawan  where aprovehr=1 and dept='" & Session("dept").ToString & "'"
            .CommandText = "select nrp, nama, dept, aprovehr, aprove from karyawan  where aprovehr=1 and nrp='" & Session("userid").ToString & "'"


            dr = .ExecuteReader

        End With
        If dr.Read Then
            'MsgBox(dr.Item(1).ToString)
            'MsgBox(dr.Item(2).ToString)
            'MsgBox(dr.Item(3).ToString)
            If dr.Item(3).ToString = "True" Then
                ' MsgBox("3")
                'If dr.Item(2).ToString = "True" Then
                cekisi()

            Else
                Response.Redirect("listskl1.aspx")
                'MsgBox("2")
            End If
        Else
            Response.Redirect("listskl1.aspx")
            'MsgBox("1")
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

            .CommandText = "SELECT A.NoSKL, B.Nrp, B.AwalLembur, B.akhirLembur, B.Aprovehr, B.Totalhr, A.NRPhr, A.TglhrAproved, A.Catatanhr, c.Dept, c.NAMA, A.nrpaproved, A.tglAproved FROM Tbl_SKL A INNER JOIN Tbl_subSKL B ON A.NoSKL = B.NoSKL INNER JOIN Karyawan C ON B.Nrp = C.Nrp WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"
            dr = .ExecuteReader

        End With
        If dr.Read Then
            'MsgBox((dept)("test"))
            'MsgBox(dr.Item(0).ToString)
            'MsgBox(dr.Item(1).ToString)
            'MsgBox(dr.Item(2).ToString)
            'MsgBox(dr.Item(6).ToString)
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
                        Me.GridView1.Columns(7).Visible = True
                        'Me.LA()
                        Me.Label11.Visible = True
                        Me.LBLHRGA.Visible = True
                        Me.Label14.Visible = True
                        Me.Label17.Visible = True
                        Me.Label20.Visible = True
                        Me.Lblnamahr.Visible = True
                        Me.lblnamahr1.Visible = True
                        Me.Lblnrphr.Visible = True
                        Me.lblnrphr1.Visible = True
                        Me.lbltglhr.Visible = True
                        Me.lbltglhr1.Visible = True
                        Me.lblcathr.Visible = True
                        Me.txtcathr1.Visible = True
                        Me.btnhr1.Visible = True
                        Me.btnrejecthr.Visible = True
                        Me.Label9.Visible = True
                        Me.Label13.Visible = True
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

            .CommandText = "SELECT A.NoSKL, B.Nrp, B.AwalLembur, B.akhirLembur, B.Aprovehr, B.Totalhr, A.NRPhr, A.TglhrAproved, A.Catatanhr, c.Dept, c.NAMA, A.aprovehr FROM Tbl_SKL A INNER JOIN Tbl_subSKL B ON A.NoSKL = B.NoSKL INNER JOIN Karyawan C ON A.Nrphr = C.Nrp WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"
            dr = .ExecuteReader

        End With
        If dr.Read Then
            If dr.Item(6).ToString <> "" Then
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
                Me.txtcathr1.Visible = False
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
            .CommandText = "select A.Noskl, A.nrprequestor, A.tglcreated, B.nama, A.uraianlembur FROM tbl_skl A INNER JOIN KARYAWAN B ON A.nrprequestor=B.nrp WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"

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
            .CommandText = "select A.Noskl, A.nrpaproved, A.tglaproved, B.nama, A.Catatan FROM tbl_skl A INNER JOIN karyawan B ON A.nrpaproved=B.nrp WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"

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
        With cmd2
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "update tbl_skl set nrphr=@nrphr, tglhraproved=getdate(), catatanhr=@catatanhr, aprovehr='1' where noskl='" & Request.QueryString("n").ToString & "'"
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
        End If

        Me.btnhr1.Visible = False
        Response.Redirect(Session("Q"))
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
            .CommandText = "update tbl_skl set nrphr=@nrphr, tglhraproved=getdate(), catatanhr=@catatanhr, aprovehr='0' where noskl='" & Request.QueryString("n").ToString & "'"
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
        Response.Redirect(Session("Q"))
    End Sub
End Class
