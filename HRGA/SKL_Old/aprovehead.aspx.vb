Imports System.Data
Imports System.Data.SqlClient
Partial Class aprove
    Inherits System.Web.UI.Page
    Dim dept As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Dept") = "" Then
            Session("Q") = "skl/aprovehead.aspx?n=" & Request.QueryString("n").ToString
            Response.Redirect("../login.aspx")
        Else
            Me.lblnama1.Text = Session("UserName").ToString
            Me.lblnrp1.Text = Session("userid").ToString
            Me.lbltgl1.Text = Date.Now
            cek1()
        End If
        requestor()

        Me.LblNoSKL.Text = UCase(Request.QueryString("n").ToString)
    End Sub
    Function cek1()

        '---------------YG(BARU)
        If InStr(1, Session("jabatan").ToString, "DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "Dept. Head") > 0 Then
            cekisi1()
        ElseIf InStr(1, Session("ndPosisi").ToString, "DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "Dept. Head") > 0 Then
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
            .CommandText = "SELECT A.NoSKL, B.Nrp, B.AwalLembur, B.akhirLembur, B.reject, B.Total, A.NRPAproved, A.TglAproved, A.Catatan, c.Dept, c.NAMA FROM Tbl_SKL1 A INNER JOIN Tbl_subSKL1 B ON A.NoSKL = B.NoSKL INNER JOIN Karyawan C ON B.Nrp = C.Nrp WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"
            dr = .ExecuteReader

        End With
        If dr.Read Then

            If Trim(dr.Item(9).ToString) = Session("dept").ToString Then
                If dr.Item(6).ToString <> "" Then
                    aprove()
                Else
                    Me.GridView2.Columns(8).Visible = True
                    Me.Label1.Visible = True
                    Me.Label2.Visible = True
                    Me.Label3.Visible = True
                    Me.lblnama.Visible = True
                    Me.lblnama1.Visible = True
                    Me.lblnrp.Visible = True
                    Me.lblnrp1.Visible = True
                    Me.lbltgl.Visible = True
                    Me.lbltgl1.Visible = True
                    Me.txtcatatan.Visible = True
                    Me.btnreject.Visible = True
                    Me.lblcat.Text = "* Catatan Harus Diisi"
                End If
            Else
                '-------isi pop up bukan haknya jerr-----

                ' Define the name and type of the client scripts on the page.
                Dim csname1 As String = "PopupScript"
                Dim cstype As Type = Me.GetType()
                ' Get a ClientScriptManager reference from the Page class.
                Dim cs As ClientScriptManager = Page.ClientScript
                ' Check to see if the startup script is already registered.
                If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                    'Dim cstext1 As String = "alert('Aprove SKL Sudah berhasil disimpan');"
                    Dim cstext1 As String = "alert('Maaf, ini Bukan SKL karyawan departemen " & Session("Dept").ToString & " ');"

                    cstext1 += "self.close();"
                    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                End If
                '-------isi pop up bukan haknya jerr-----
            End If
        Else
            

        End If
        con.Close()

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
            .CommandText = "select A.Noskl, A.nrprequestor, A.tglcreated, B.nama, A.uraianlembur, A.aprovedept FROM tbl_skl1 A INNER JOIN KARYAWAN B ON A.nrprequestor=B.nrp WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"


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
            .CommandText = "select A.Noskl, A.nrpaproved, A.tglaproved, B.nama, A.Catatan, A.aprovedept FROM tbl_skl1 A INNER JOIN karyawan B ON A.nrpaproved=B.nrp WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"
            dr = .ExecuteReader

        End With
        If dr.Read Then
            Me.Label5.Visible = True
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
            Me.txtcatatan.Visible = False
            Me.btnreject.Visible = False
            Me.btnsend.Visible = False
            If dr.Item(5).ToString = "True" Then
                Me.Label5.Text = "SKL No. " & " " & dr.Item(0).ToString & " " & "Sudah Diaprove Oleh :"
            Else
                Me.Label5.Text = "SKL No. " & " " & dr.Item(0).ToString & " " & "Sudah Direject Oleh :"
            End If


        End If
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
            .CommandText = "update tbl_skl1 set nrpaproved=@nrpaproved, tglaproved=getdate(), catatan=@catatan, aprovedept='1',proses='0',status='Proses HRGA' where noskl='" & Request.QueryString("n").ToString & "'"
            .Parameters.Add("@nrpaproved", SqlDbType.VarChar, 20)
            .Parameters.Add("@catatan", SqlDbType.VarChar, 200)
            .Parameters("@nrpaproved").Value = Me.lblnrp1.Text
            .Parameters("@catatan").Value = Me.txtcatatan.Text
            .ExecuteNonQuery()
            con.Close()
        End With

        Me.btnsend.Visible = False
        Me.btnreject.Visible = False
        Me.lblcat.Visible = False

        '---------------popup--------------

        ' Define the name and type of the client scripts on the page.
        Dim csname1 As String = "PopupScript"
        Dim cstype As Type = Me.GetType()
        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript
        ' Check to see if the startup script is already registered.
        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
            Dim cstext1 As String = "alert('Aprove SKL Sudah berhasil disimpan');"
            cstext1 += "self.close();"
            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
        End If

        'Response.Redirect("Listskl1.aspx")
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
            .CommandText = "update tbl_skl1 set nrpaproved=@nrpaproved, tglaproved=getdate(), catatan=@catatan, aprovedept='0',status='Reject Dept' where noskl='" & Request.QueryString("n").ToString & "'"
            .Parameters.Add("@nrpaproved", SqlDbType.VarChar, 20)
            .Parameters.Add("@catatan", SqlDbType.VarChar, 200)
            .Parameters("@nrpaproved").Value = Me.lblnrp1.Text
            .Parameters("@catatan").Value = Me.txtcatatan.Text
            .ExecuteNonQuery()
            con.Close()
        End With



        '--------------isi all kolom reject di tbl_subskl1----------------

        con.Open()
        With cmd2
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "update tbl_subskl1 set reject='1', total='0' where noskl='" & Request.QueryString("n").ToString & "'"
            .ExecuteNonQuery()
            con.Close()
        End With


        '----------------end off reject--------------
  
        Me.btnsend.Visible = False
        Me.btnreject.Visible = False
        Me.lblcat.Visible = False

        '---------------popup--------------

        ' Define the name and type of the client scripts on the page.
        Dim csname1 As String = "PopupScript"
        Dim cstype As Type = Me.GetType()
        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript
        ' Check to see if the startup script is already registered.
        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
            Dim cstext1 As String = "alert('Reject SKL Sudah berhasil disimpan');"
            cstext1 += "self.close();"
            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
        End If


    End Sub

    Protected Sub txtcatatan_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcatatan.TextChanged
        Me.lblcat.Visible = False
        Me.btnsend.Enabled = True
        Me.btnreject.Enabled = True
    End Sub

    Protected Sub GridView2_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView2.RowEditing
    End Sub

    Protected Sub GridView2_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView2.RowUpdating
        Me.txtcatatan.Visible = True
        Me.btnsend.Visible = True
        Me.btnreject.Visible = True
        Me.Label4.Visible = True
        Me.lblCatatan.Visible = True
        Me.lblcat.Visible = True
        Me.lblcat.Text = "* Catatan Harus Diisi"
    End Sub

    Protected Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged
        Me.txtcatatan.Visible = True
        Me.btnsend.Visible = True
        Me.btnreject.Visible = True
    End Sub
End Class
