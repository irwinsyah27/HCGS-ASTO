Imports System.Data
Imports System.Data.SqlClient
Partial Class vwskl
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Dept") = "" Then
            'MsgBox("iii")
            Session("Q") = "vwskl.aspx?n=" & Request.QueryString("n").ToString
            'Me.LblNoSKL.Text = Request.QueryString("n").ToString
            Response.Redirect("loginl.aspx")
        End If

        cekatasan()
        cekhr()
        requestor()
    End Sub
    Dim dept As String

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
            'Me.lbluraian1.Text = dr.Item(4).ToString

        End If
    End Function
    Function cekatasan()
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
        Else

        End If
    End Function
    Function cekhr()
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

            .CommandText = "SELECT A.NoSKL, B.Nrp, B.AwalLembur, B.akhirLembur, B.Aprovehr, B.Totalhr, A.NRPhr, A.TglhrAproved, A.Catatanhr, c.Dept, c.NAMA FROM Tbl_SKL A INNER JOIN Tbl_subSKL B ON A.NoSKL = B.NoSKL INNER JOIN Karyawan C ON A.Nrphr = C.Nrp WHERE A.NOSKL='" & Request.QueryString("n").ToString & "'"
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
                'Me.txtcathr1.Visible = False
                'Me.btnhr1.Visible = False
                Me.Label9.Visible = True
                'Me.Label13.Visible = False
                Me.Label9.Text = "SKL No. " & " " & dr.Item(0).ToString & " " & "Sudah Divalidasi Di HR Oleh :"
            End If
        End If
    End Function
End Class
