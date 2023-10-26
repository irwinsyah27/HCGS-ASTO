Imports System.Data
Imports System.Data.SqlClient
Partial Class Default4
    Inherits System.Web.UI.Page
    Dim dept As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Dept") = "" Then
            'MsgBox("iii")
            Session("Q") = "aprove.aspx?n=" & Request.QueryString("n").ToString
            'Me.LblNoSKL.Text = Request.QueryString("n").ToString
            'Response.Redirect("loginl.aspx")
            Response.Redirect("login.aspx")
        Else
            Me.lblnama1.Text = Session("nama").ToString
            'Me.LblNamarequestor.Text = Response.Cookies("nama").Value.ToString
            Me.lblnrp1.Text = Session("userid").ToString
            'Me.LblNRPRequestor.Text = Session("userid").ToString
            Me.lbltgl1.Text = Date.Now
            'Me.lblcat.Visible = True
            'Me.lblcat.Text = "* Catatan Harus Diisi"
            'MsgBox("dfdfd")
            'takeup()
            cek()

        End If
        'If UCase(Request.Cookies("section").Value) = "IT" Then
        'MsgBox("anda IT")
        'cektakeup()
        'Else
        'MsgBox("anda bukan IT")
        'Response.Redirect("login.aspx")
        ' End If
        requestor()

        Me.LblNoSKL.Text = UCase(Request.QueryString("n").ToString)

    End Sub
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
    Function aprove()
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
            Me.lblcat.Visible = False
            
            Me.txtcatatan.ReadOnly = True

        End If
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
            '.CommandText = "SELECT A.NoSKL, B.Nrp, B.AwalLembur, B.akhirLembur," & _
            '"B.Aprove, B.Total, A.NRPAproved, A.TglAproved, A.Catatan, c.Dept FROM" & _
            '"Tbl_SKL A INNER JOIN Tbl_subSKL B ON A.NoSKL = B.NoSKL INNER JOIN Karyawan C" & _
            '"ON B.Nrp = C.Nrp WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"
            '.CommandText = "SELECT A.NoSKL, B.Nrp, B.AwalLembur, B.akhirLembur, B.Aprove, B.Total, A.NRPAproved, A.TglAproved, A.Catatan, c.Dept, c.NAMA FROM Tbl_SKL A INNER JOIN Tbl_subSKL B ON A.NoSKL = B.NoSKL INNER JOIN Karyawan C ON A.Nrpaproved = C.Nrp WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"

            .CommandText = "SELECT A.NoSKL, B.Nrp, B.AwalLembur, B.akhirLembur, B.Aprove, B.Total, A.NRPAproved, A.TglAproved, A.Catatan, c.Dept, c.NAMA FROM Tbl_SKL A INNER JOIN Tbl_subSKL B ON A.NoSKL = B.NoSKL INNER JOIN Karyawan C ON B.Nrp = C.Nrp WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"
            '.CommandText = "SELECT A.NoSKL, B.Nrp, B.AwalLembur, B.akhirLembur, B.Aprove, B.Total, A.NRPAproved, A.TglAproved, A.Catatan FROM tbl_skl A INNER JOIN tbl_subskl B ON A.NoSKL = B.NoSKL WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"

            '" & Session("dept").ToString & "' and b.nrp='" & Session("userid").ToString & "'"

            '.CommandText = "select A.nrp, B.nama, B.dept, B.aprove from tbl_login A inner join karyawan B on a.nrp=b.nrp where b.dept='" & Session("dept").ToString & "' and b.nrp='" & Session("userid").ToString & "'"
            dr = .ExecuteReader

        End With
        If dr.Read Then
           
            If dr.Item(9).ToString = dept Then
                If dr.Item(6).ToString <> "" Then
                    'MsgBox("sudah diaprove")
                    aprove()
                Else
                    'MsgBox("belum diaprove")
                    Me.GridView2.Columns(0).Visible = True
                    'Me.LA()
                    Me.Label1.Visible = True
                    Me.Label2.Visible = True
                    Me.Label3.Visible = True
                    Me.Label4.Visible = True
                    Me.lblnama.Visible = True
                    Me.lblnama1.Visible = True
                    Me.lblnrp.Visible = True
                    Me.lblnrp1.Visible = True
                    Me.lbltgl.Visible = True
                    Me.lbltgl1.Visible = True
                    Me.lblCatatan.Visible = True
                    Me.txtcatatan.Visible = True
                    Me.btnsend.Visible = True
                    Me.btnreject.Visible = True
                    Me.lblcat.Visible = True
                    Me.lblcat.Text = "* Catatan Harus Diisi"
                End If
            Else
                Response.Redirect("listskl1.aspx")
                'MsgBox("beda dept tuch")

            End If
        End If
        'Response.Redirect("trainsite.aspx")

        con.Close()

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
            '.CommandText = "update tbl_shesms set takeupdept=@takeupdept, namadept=@namadept where No='" & Request.QueryString("n").ToString & "'"

            '.CommandText = "select A.nrp, B.nama, B.dept, B.aprove from tbl_login A inner join karyawan B on a.nrp=b.nrp where b.dept='" & Session("dept").ToString & "' and b.nrp='" & Session("userid").ToString & "'"
            '.CommandText = "select A.nrp, B.nama, B.dept, B.aprove from tbl_login A inner join karyawan B on a.nrp=b.nrp where b.nrp='" & Session("userid").ToString & "'"
            .CommandText = "select nrp, nama, dept, aprove from karyawan where nrp='" & Session("userid").ToString & "'"

            dr = .ExecuteReader

        End With
        If dr.Read Then
            'MsgBox(dr.Item(1).ToString)
            'MsgBox(dr.Item(2).ToString)
            'MsgBox(dr.Item(3).ToString)
            If dr.Item(3).ToString = "True" Then
                'MsgBox("3")
                'If dr.Item(2).ToString = "True" Then
                cekisi()
                'Me.GridView2.Columns(0).Visible = True
                'Me.Label1.Visible = True
                'Me.Label2.Visible = True
                'Me.Label3.Visible = True
                'Me.Label4.Visible = True
                'Me.lblnama.Visible = True
                'Me.lblnama1.Visible = True
                'Me.lblnrp.Visible = True
                'Me.lblnrp1.Visible = True
                'Me.lbltgl.Visible = True
                'Me.lbltgl1.Visible = True
                'Me.lblCatatan.Visible = True
                'Me.txtcatatan.Visible = True
                'Me.btnsend.Visible = True
            Else
                'Response.Redirect("hrga.aspx")
                'MsgBox("2")
                'Me.GridView2.Columns(0).Visible = False

            End If
        Else
            Response.Redirect("listskl1.aspx")
            'MsgBox("1")
        End If
        con.Close()
    End Function


    Protected Sub btnsend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsend.Click
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
            .CommandText = "update tbl_skl set nrpaproved=@nrpaproved, tglaproved=getdate(), catatan=@catatan where noskl='" & Request.QueryString("n").ToString & "'"
            '.CommandText = "Insert Into tbl_skl (NoSKL,NRPrequestor,TglCreated,uraianLembur) Values(@NoSKL,@NrpUser,getdate(),@uraianlembur)"

            .Parameters.Add("@nrpaproved", SqlDbType.VarChar, 20)
            .Parameters.Add("@catatan", SqlDbType.VarChar, 200)
            'MsgBox(Request.QueryString("n").ToString)
            'MsgBox(Me.lblnrp1.Text)
            'MsgBox(Me.txtcatatan.Text)

            .Parameters("@nrpaproved").Value = Me.lblnrp1.Text
            .Parameters("@catatan").Value = Me.txtcatatan.Text
            .ExecuteNonQuery()
            con.Close()
        End With
        '---------run alert----------------
        con.Open()
        With cmd1
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "update tbl_updateno set noupdate='" & Request.QueryString("n").ToString & "'"
            
            .ExecuteNonQuery()
            con.Close()
        End With


        con.Open()
        With cmd2
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "update tbl_ALERT set noupdate='" & Request.QueryString("n").ToString & "'"
            
            .ExecuteNonQuery()
            con.Close()
        End With
        '---------run alert----------------
        Me.btnsend.Visible = False
        Me.btnreject.Visible = False
        Me.lblcat.Visible = False

        Response.Redirect("Listskl1.aspx")
    End Sub

    Protected Sub txtcatatan_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcatatan.TextChanged
        Me.lblcat.Visible = False
        Me.btnsend.Enabled = True
        Me.btnreject.Enabled = True
    End Sub

    Protected Sub btnreject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnreject.Click
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
            .CommandText = "update tbl_skl set nrpaproved=@nrpaproved, tglaproved=getdate(), catatan=@catatan where noskl='" & Request.QueryString("n").ToString & "'"
            '.CommandText = "Insert Into tbl_skl (NoSKL,NRPrequestor,TglCreated,uraianLembur) Values(@NoSKL,@NrpUser,getdate(),@uraianlembur)"

            .Parameters.Add("@nrpaproved", SqlDbType.VarChar, 20)
            .Parameters.Add("@catatan", SqlDbType.VarChar, 200)
            'MsgBox(Request.QueryString("n").ToString)
            'MsgBox(Me.lblnrp1.Text)
            'MsgBox(Me.txtcatatan.Text)

            .Parameters("@nrpaproved").Value = Me.lblnrp1.Text
            .Parameters("@catatan").Value = Me.txtcatatan.Text
            .ExecuteNonQuery()
            con.Close()
        End With

        con.Open()
        With cmd2
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "update tbl_subskl set aprove='0' where noskl='" & Request.QueryString("n").ToString & "'"
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

        '---------run alert----------------
        con.Open()
        With cmd1
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "update tbl_updateno set noupdate='" & Request.QueryString("n").ToString & "'"

            .ExecuteNonQuery()
            con.Close()
        End With


        con.Open()
        With cmd2
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "update tbl_ALERT set noupdate='" & Request.QueryString("n").ToString & "'"

            .ExecuteNonQuery()
            con.Close()
        End With
        '---------run alert----------------
        Me.btnsend.Visible = False
        Me.btnreject.Visible = False
        Me.lblcat.Visible = False

        Response.Redirect("Listskl1.aspx")

    End Sub
End Class
