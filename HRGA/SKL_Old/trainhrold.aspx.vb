Imports System.Data
Imports System.Data.SqlClient
Partial Class trainhr
    Inherits System.Web.UI.Page
    Dim dept As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Dept") = "" Then
            Session("Q") = "trainhr.aspx?n=" & Request.QueryString("n").ToString
            Response.Redirect("loginl.aspx")
        Else
            'Me.lblnama1.Text = Session("nama").ToString
            'Me.lblnrp1.Text = Session("userid").ToString
            'Me.lbltgl1.Text = Date.Now
            cek()

        End If
        
        requestor()

        Me.LblNoSKL.Text = UCase(Request.QueryString("n").ToString)

    End Sub
    Function cek()
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
            .CommandText = "select A.nrp, B.nama, B.dept, B.aprovehr from tbl_login A inner join karyawan B on a.nrp=b.nrp where b.nrp='" & Session("userid").ToString & "'"

            dr = .ExecuteReader

        End With
        If dr.Read Then
            MsgBox(dr.Item(1).ToString)
            MsgBox(dr.Item(2).ToString)
            MsgBox(dr.Item(3).ToString)
            If dr.Item(3).ToString = "True" Then
                MsgBox("3")
                cekisi()

            Else
                MsgBox("2")
                Me.Label9.Visible = True
                Me.Label10.Visible = True
                Me.Label11.Visible = True
                Me.Label12.Visible = True
                Me.Label13.Visible = True
                Me.Label14.Visible = False
                Me.lblnama.Visible = True
                Me.lblnama1.Visible = True
                Me.lblnrp.Visible = True
                Me.lblnrp1.Visible = True
                Me.lbltgl.Visible = True
                Me.lbltgl1.Visible = True
                Me.lblCatatan.Visible = True
                Me.LBLCAT1.Visible = True
                Me.txtcatatan.Visible = False
                Me.btnvalidate.Visible = False

            End If
        Else
            MsgBox("1")
            Me.Label9.Visible = True
            Me.Label10.Visible = True
            Me.Label11.Visible = True
            Me.Label12.Visible = True
            Me.Label13.Visible = True
            Me.Label14.Visible = False
            Me.lblnama.Visible = True
            Me.lblnama1.Visible = True
            Me.lblnrp.Visible = True
            Me.lblnrp1.Visible = True
            Me.lbltgl.Visible = True
            Me.lbltgl1.Visible = True
            Me.lblCatatan.Visible = True
            Me.LBLCAT1.Visible = True
            Me.txtcatatan.Visible = False
            Me.btnvalidate.Visible = False

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
            '.CommandText = "select A.Notrs, A.nrpcreator, A.tglcreated, B.nama, A.lokasitraining, A.uraiantraining FROM tbl_trains A INNER JOIN tbl_login B ON A.nrpcreator=B.nrp WHERE A.NOtrs='" & Request.QueryString("n").ToString & "'"
            .CommandText = "select A.Notrs, A.nrpcreator, A.tglcreated, B.nama, A.lokasitraining, A.uraiantraining FROM tbl_trains A INNER JOIN KARYAWAN B ON A.nrpcreator=B.nrp WHERE A.NOtrs='" & Request.QueryString("n").ToString & "'"

            dr = .ExecuteReader

        End With
        If dr.Read Then
            Me.LblNoSKL.Text = dr.Item(0).ToString
            Me.LblNRPRequestor.Text = dr.Item(1).ToString
            Me.LblNamarequestor.Text = dr.Item(3).ToString
            Me.LblTanggalCreated.Text = dr.Item(2).ToString
            Me.lbllokasi1.Text = dr.Item(4).ToString
            Me.lbltraining1.Text = dr.Item(5).ToString


        End If

    End Function
    Function cekisi()
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
            .CommandText = "SELECT A.Notrs, B.Nrp, B.Awaltrain, B.akhirtrain, B.validatehr, A.NRPhr, A.Tglhrvalidate, A.Catatanhr, c.Dept, c.NAMA FROM Tbl_trains A INNER JOIN Tbl_subtrain B ON A.Notrs = B.Notrs INNER JOIN Karyawan C ON B.Nrp = C.Nrp WHERE A.NOtrs='" & Request.QueryString("n").ToString & "'"
            dr = .ExecuteReader

        End With
        If dr.Read Then
            'MsgBox((dept)("test"))
            'MsgBox(dr.Item(0).ToString)
            'MsgBox(dr.Item(1).ToString)
            'MsgBox(dr.Item(2).ToString)
            'MsgBox(dr.Item(6).ToString)
            'If dr.Item(9).ToString = dept Then
            If dr.Item(6).ToString <> "" Then
                MsgBox("sudah divalidasi")
                'ValidasiHR()

                Me.Label9.Visible = True
                Me.Label10.Visible = True
                Me.Label11.Visible = True
                Me.Label12.Visible = True
                Me.Label13.Visible = True
                Me.Label14.Visible = False
                Me.Label9.Text = "Train Site No. " & " " & dr.Item(0).ToString & " " & "Sudah DiValidasi Oleh :"
                Me.lblnama.Visible = True
                Me.lblnama1.Visible = True
                Me.lblnama1.Text = dr.Item(9).ToString
                Me.lblnrp.Visible = True
                Me.lblnrp1.Visible = True
                Me.lblnrp1.Text = dr.Item(5).ToString
                Me.lbltgl.Visible = True
                Me.lbltgl1.Visible = True
                Me.lbltgl1.Text = dr.Item(6).ToString
                Me.lblCatatan.Visible = True
                Me.LBLCAT1.Visible = True
                Me.LBLCAT1.Text = dr.Item(7).ToString
                Me.txtcatatan.Visible = False
                Me.btnvalidate.Visible = False
                ''Me.txtcatatan.Text = dr.Item(8).ToString
                ''Me.txtcatatan.Enabled = False
                'Me.txtcatatan.ReadOnly = True

            Else
                MsgBox("belum diaprove")
                Me.GridView2.Columns(0).Visible = True
                'Me.LA()
                Me.Label9.Visible = False
                Me.Label10.Visible = True
                Me.Label11.Visible = True
                Me.Label12.Visible = True
                Me.Label13.Visible = True
                Me.Label14.Visible = True
                Me.lblnama.Visible = True
                Me.lblnama1.Visible = True
                Me.lblnrp.Visible = True
                Me.lblnrp1.Visible = True
                Me.lbltgl.Visible = True
                Me.lbltgl1.Visible = True
                Me.lblCatatan.Visible = True
                Me.txtcatatan.Visible = True
                Me.lblnama1.Text = Session("nama").ToString
                Me.lblnrp1.Text = Session("userid").ToString
                Me.lbltgl1.Text = Date.Now
                'Me.btnva.Visible = True
                'Me.btnreject.Visible = True
            End If

        End If
        'End If

        con.Close()
    End Function


    Protected Sub txtcatatan_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcatatan.TextChanged
        Me.btnvalidate.Visible = True
        Me.btnvalidate.Enabled = True
    End Sub

    Protected Sub btnvalidate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnvalidate.Click
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
            .CommandText = "update tbl_trains set nrphr=@nrphr, tglhrvalidate=getdate(), catatanhr=@catatanhr where notrs='" & Request.QueryString("n").ToString & "'"

            .Parameters.Add("@nrphr", SqlDbType.VarChar, 20)
            .Parameters.Add("@catatanhr", SqlDbType.VarChar, 200)
            MsgBox(Request.QueryString("n").ToString)
            MsgBox(Me.lblnrp1.Text)
            MsgBox(Me.txtcatatan.Text)

            .Parameters("@nrphr").Value = Me.lblnrp1.Text
            .Parameters("@catatanhr").Value = Me.txtcatatan.Text
            .ExecuteNonQuery()
            con.Close()
        End With
        Me.btnvalidate.Visible = False
        Response.Redirect(Session("Q"))
    End Sub

End Class
