Imports System.Data
Imports System.Data.SqlClient

Partial Class _fKomplain
    Inherits System.Web.UI.Page
    Dim TotLapangan As Integer
    Dim TotTahunan As Integer
    Dim TotBesar As Integer
    Dim TotPerjalanan As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./cuti/fKomplain.aspx"
            Response.Redirect("../login.aspx")
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
            .CommandText = "Select Nrp, Nama, Jabatan, Departemen, StatusPenerimaan, (Select Nrp From vw_tblKaryawan Where Nrp = '" & Session("userid").ToString & "') AS Nrp1, (Select Nama From vw_tblKaryawan Where Nrp = '" & Session("userid").ToString & "') AS Nama1, (Select Jabatan From vw_tblKaryawan Where Nrp = '" & Session("userid").ToString & "') AS Jabatan1, (Select Departemen From vw_tblKaryawan Where Nrp = '" & Session("userid").ToString & "') AS Departemen1 From vw_tblKaryawan Where Nrp = @Nrp"

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

            If dr.Item("StatusPenerimaan").ToString <> "LOKAL" And dr.Item("StatusPenerimaan").ToString <> "KIRIMAN" Then
                If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                    Dim cstext1 As String = "alert('Hanya diijinkan komplain karyawan KPP   ');"
                    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
                    Exit Sub
                End If
            End If

            Me.lblNama.Text = dr.Item("Nama").ToString
            Me.lblJabatan.Text = dr.Item("Jabatan").ToString & " / " & dr.Item("Departemen").ToString '& " / " & dr.Item("Golongan").ToString

            Me.lblNrp1.Text = dr.Item("Nrp1").ToString
            Me.lblJabatan1.Text = dr.Item("Jabatan1").ToString & " / " & dr.Item("Departemen1").ToString
            Me.lblNama1.Text = dr.Item("Nama1").ToString

            

            

        Else
            Me.lblNama.Text = ""
            Me.lblJabatan.Text = ""

            Me.lblNrp1.Text = ""
            Me.lblJabatan1.Text = ""
            Me.lblNama1.Text = ""

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
        End If

        StatusKomplain()

    End Sub

    Sub StatusKomplain()
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
            .CommandText = "Select (Select COUNT(*) FROM tblSutu where Keperluan='KOMPLAIN' AND Nrp=@Nrp) AS Total, (Select COUNT(*) FROM tblSutu where Keperluan='KOMPLAIN' AND Status NOT IN ('Completed','Riject') AND Nrp=@Nrp) AS SOpen, (Select COUNT(*) FROM tblSutu where Keperluan='KOMPLAIN' AND Status='Completed' AND Nrp=@Nrp) AS SClose"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = txtNrp.Text
            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Me.lblTotalKomplain.Text = dr.Item("Total").ToString
            Me.lblSisaOpen.Text = dr.Item("SOpen").ToString
            Me.lblClose.Text = dr.Item("SClose").ToString
            'Me.lblTotal.Text = dr.Item("Total").ToString

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
                            & ",[tglST]" _
                            & ",[Keperluan]" _
                            & ",[AlamatCuti]" _
							& ",[Keterangan]" _
                            & ",[DibuatOleh]" _
                    & ") values (" _
                            & "@Nrp" _
                            & ",@NomorST" _
                            & ",@Tujuan" _
                            & ",Getdate()" _
                            & ",@Keperluan" _
							& ",@Solusi" _
                            & ",@Keterangan" _
                            & ",@DibuatOleh" _
                            & ")"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 50)
            .Parameters.Add("@NomorST", SqlDbType.VarChar, 20)
            .Parameters.Add("@Tujuan", SqlDbType.VarChar, 30)
            .Parameters.Add("@Keperluan", SqlDbType.VarChar, 30)
			.Parameters.Add("@Solusi", SqlDbType.VarChar, 100)
            .Parameters.Add("@Keterangan", SqlDbType.VarChar, 200)
            .Parameters.Add("@DibuatOleh", SqlDbType.NVarChar, 10)

            .Parameters("@Nrp").Value = Me.txtNrp.Text
            .Parameters("@NomorST").Value = "BARU"
            .Parameters("@Tujuan").Value = Me.txtTujuan.Text
            .Parameters("@Keperluan").Value = "KOMPLAIN"
			.Parameters("@Solusi").Value = Me.txtSolusi.Text
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

            Dim cstext1 As String = "alert('Surat pengajuan komplain telah tersimpan...');"
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
