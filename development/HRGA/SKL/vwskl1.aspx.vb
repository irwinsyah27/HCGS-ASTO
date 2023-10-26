
Imports System.Data
Imports System.Data.SqlClient
Partial Class vwskl
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Dept") = "" Then
            'MsgBox("iii")
            Session("v") = "vwskl1.aspx?n=" & Request.QueryString("n").ToString
            'Session("v") = "vwskl1.aspx?n=" & Session("noskl").ToString
            'Me.LblNoSKL.Text = Request.QueryString("n").ToString
            Response.Redirect("login.aspx")
        End If

        cekatasan()
        'cekhr()
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
            .CommandText = "select A.Noskl, A.nrpaproved, A.tglaproved, B.nama, A.Catatan, A.aprovedept FROM tbl_skl1 A INNER JOIN karyawan B ON A.nrpaproved=B.nrp WHERE A.NOSKL='" & Session("noskl").ToString & "'"

            dr = .ExecuteReader

        End With
        If dr.Read Then
            'Response.Write("1")
            If dr.Item(5).ToString = True Then

                'Response.Write("2")
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

                cekhr()
            End If
            If dr.Item(5).ToString = False Then
                'Response.Write("3")
                Me.Label5.Visible = True
                Me.Label5.Text = "SKL No. " & " " & dr.Item(0).ToString & " " & "Sudah Direject Oleh :"

                Me.Label2.Visible = True
                Me.Label3.Visible = True
                Me.Label1.Visible = True
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
                Me.LBLHRGA.Visible = False
                Me.Label9.Visible = False
                Me.Lblnamahr.Visible = False
                Me.lbltglhr.Visible = False
                Me.lblcathr.Visible = False
                Me.Lblnamahr.Visible = False
                Me.lblnamahr1.Visible = False
                Me.lbltglhr1.Visible = False
                Me.lblcathr1.Visible = False
                Me.lblnamahr1.Visible = False
                Me.Lblnrphr.Visible = False
                Me.lblnrphr1.Visible = False

                Me.Label11.Visible = False
                Me.Label14.Visible = False
                Me.Label17.Visible = False
                Me.Label20.Visible = False


            End If
        Else
            'Response.Write("4")
            Me.Label5.Visible = False
            'Me.Label5.Text = "SKL No. " & " " & dr.Item(0).ToString & " " & "Sudah Diaprove Oleh :"
            Me.Label1.Visible = False
            Me.Label2.Visible = False
            Me.Label3.Visible = False
            Me.Label4.Visible = False
            Me.lblnama.Visible = False
            Me.lblnama1.Visible = False
            'Me.lblnama1.Text = dr.Item(3).ToString
            Me.lblnrp.Visible = False
            Me.lblnrp1.Visible = False
            'Me.lblnrp1.Text = dr.Item(1).ToString
            Me.lbltgl.Visible = False
            Me.lbltgl1.Visible = False
            'Me.lbltgl1.Text = dr.Item(2).ToString
            Me.lblCatatan.Visible = False
            Me.LBLCAT1.Visible = False
            'Me.LBLCAT1.Text = dr.Item(4).ToString

            '----------------------pop up-----------------------
            'Define the name and type of the client scripts on the page.
            Dim csname1 As String = "PopupScript"
            Dim cstype As Type = Me.GetType()
            'Get a ClientScriptManager reference from the Page class.
            Dim cs As ClientScriptManager = Page.ClientScript
            'Check to see if the startup script is already registered.
            If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                Dim cstext1 As String = "alert('SKL Belum Diaprove Atasan');"
                cstext1 += "self.close();"
                cs.RegisterStartupScript(cstype, csname1, cstext1, True)
            End If
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

            .CommandText = "SELECT A.NoSKL, B.Nrp, B.AwalLembur, B.akhirLembur, A.Aprovehr, B.Totalhr, A.NRPhr, A.TglhrAproved, A.Catatanhr, c.Dept, c.NAMA FROM Tbl_SKL1 A INNER JOIN Tbl_subSKL1 B ON A.NoSKL = B.NoSKL LEFT JOIN Karyawan C ON A.Nrphr = C.Nrp WHERE A.NOSKL='" & Session("noskl").ToString & "'"
            dr = .ExecuteReader

        End With

        If dr.Read Then
            If dr.Item(6).ToString <> "" Then
                If dr.Item(4).ToString = True Then
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

                If dr.Item(4).ToString = False Then
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
                    Me.Label9.Text = "SKL No. " & " " & dr.Item(0).ToString & " " & "Sudah Direject Di HR Oleh :"
                End If
                
            Else
                '----------------------pop up-----------------------
                ' Define the name and type of the client scripts on the page.
                Dim csname1 As String = "PopupScript"
                Dim cstype As Type = Me.GetType()
                ' Get a ClientScriptManager reference from the Page class.
                Dim cs As ClientScriptManager = Page.ClientScript
                ' Check to see if the startup script is already registered.
                If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                    Dim cstext1 As String = "alert('SKL Belum Divalidasi HR');"
                    cstext1 += "self.close();"
                    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                End If
                'Response.Write("tES")
            End If
        End If
    End Function
End Class

