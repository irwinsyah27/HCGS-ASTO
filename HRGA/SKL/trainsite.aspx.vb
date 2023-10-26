Imports System.Data
Imports System.Data.SqlClient
Partial Class trainsite
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Dept") = "" Then
            'MsgBox("iii")
            Session("Q") = "trainsite.aspx"
            'MsgBox(Session("Q"))
            Response.Redirect("login.aspx")
            'Login.Visible = False
            'User.Visible = False
            'Nama.Visible = False
        Else
            'Login.Text = "| .:: Logout ::. |"
            'User.Text = "| User : p" & Session("UserID") & "|"
            'Nama.Text = "|" & Session("nama")
            'Login.PostBackUrl = "../Logout.aspx"
            cekisi()

            Me.LblNamarequestor.Text = Session("nama").ToString
            'Me.LblNamarequestor.Text = Response.Cookies("nama").Value.ToString
            Me.LblNRPRequestor.Text = Session("userid").ToString
            'Me.LblNRPRequestor.Text = Session("userid").ToString
            Me.LblTanggalCreated.Text = Date.Now

        End If
    End Sub
    Function cekisi()

    End Function

    Protected Sub btnadd1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd1.Click
        Me.Gridkaryawan1.Visible = True
        Me.btnadd1.Visible = False
    End Sub

    Protected Sub Gridkaryawan1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Gridkaryawan1.SelectedIndexChanged
        Me.listnrp.Items.Add(Me.Gridkaryawan1.SelectedRow.Cells(1).Text)
        Me.listnama.Items.Add(Me.Gridkaryawan1.SelectedRow.Cells(2).Text)
        Me.Gridkaryawan1.Visible = False
        Me.btnadd1.Visible = True
        Me.btnawaltraining.Visible = True
        Me.lblawalskl.Visible = True
        Me.Label6.Visible = True
        'Me.btnawallbr.Visible = True

        'Me.Label9.Visible = True
    End Sub

    Protected Sub btnawaltraining_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnawaltraining.Click
        Me.calawallbr.Visible = True
        Me.btnawaltraining.Visible = False
        Me.btnadd1.Visible = False
        'Me.lblhari7.Visible = True
        'Me.Label9.Visible = True
    End Sub

    Protected Sub calawallbr_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles calawallbr.SelectionChanged
        If Me.calawallbr.SelectedDate.Date >= Date.Today.AddDays(-1) Then
            'If Me.calawallbr.SelectedDate.Date >= Date.Today Then
            'Me.lbltglawal.Visible = True
            Me.txttglawal.Visible = True
            Me.lblawallbr.Visible = True
            Me.Label1.Visible = True
            Me.ddlawal1.Visible = True
            Me.ddlawal2.Visible = True
            Me.txttglawal.Text = Format((Me.calawallbr.SelectedDate), "dd/MM/yyyy").ToString
            Me.btnawaltraining.Visible = False
            Me.calawallbr.Visible = False

        End If
    End Sub

    Protected Sub ddlawal2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlawal2.SelectedIndexChanged
        If Me.ddlawal2.Text <> "-" Then
            'MsgBox(Date.Now.Hour)
            Me.TxtAwalSKL.Text = Me.txttglawal.Text & " " & Me.ddlawal1.Text & Me.Label1.Text & Me.ddlawal2.Text
            Me.TxtAwalSKL.Visible = True
            Me.btnakhirtrain.Visible = True
            Me.calawallbr.Visible = False
            Me.txttglawal.Visible = False
            Me.lblawallbr.Visible = False
            Me.ddlawal1.Visible = False
            Me.Label1.Visible = False
            Me.ddlawal2.Visible = False
            Me.Label7.Visible = True
            Me.lblakhirSKL.Visible = True
            'MsgBox(Date.Now.Hour)

        Else
            Me.btnakhirtrain.Visible = False
        End If
    End Sub

    Protected Sub btnakhirtrain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnakhirtrain.Click
        Me.calakhirlbr.Visible = True
        Me.btnakhirtrain.Visible = False
    End Sub

    Protected Sub calakhirlbr_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles calakhirlbr.SelectionChanged
        If Me.calakhirlbr.SelectedDate.Date >= Date.Today.AddDays(-1) Then
            'Me.lbltglakhir.Visible = True
            Me.txttglakhir.Visible = True
            Me.lblakhirlbr.Visible = True
            Me.Label2.Visible = True
            Me.ddlakhir1.Visible = True
            Me.ddlakhir2.Visible = True
            Me.txttglakhir.Text = Format((Me.calakhirlbr.SelectedDate), "dd/MM/yyyy").ToString
            Me.btnakhirtrain.Visible = False
            Me.calakhirlbr.Visible = False

        End If
    End Sub

    Protected Sub ddlakhir1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlakhir1.SelectedIndexChanged
        Dim jam As String
        jam = 1

        If Me.ddlakhir1.Text >= Me.ddlawal1.Text + jam Then
            Me.ddlakhir2.Enabled = True

        End If
    End Sub

    Protected Sub ddlakhir2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlakhir2.SelectedIndexChanged
        If Me.ddlakhir2.Text <> "-" Then
            Me.TxtAkhirSKL.Text = Me.txttglakhir.Text & " " & Me.ddlakhir1.Text & Me.Label1.Text & Me.ddlakhir2.Text
            'Me.btnsend.Visible = True
            Me.TxtAkhirSKL.Visible = True
            'Me.btnakhirlbr.Visible = False
            'Me.calawallbr.Visible = False
            Me.txttglakhir.Visible = False
            Me.lblakhirlbr.Visible = False
            Me.ddlakhir1.Visible = False
            Me.Label2.Visible = False
            Me.ddlakhir2.Visible = False
            Me.Label8.Visible = True
            Me.lblUraianKerja.Visible = True
            Me.txturaian.Visible = True
            Me.lbl01.Visible = True
            Me.lbl01.Text = "* Uraian training Wajib diisi"

            'Else
            '    Me.btnakhirlbr.Visible = False
        End If
    End Sub

    Protected Sub txturaian_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txturaian.TextChanged
        Me.lbllokasi.Visible = True
        Me.Label10.Visible = True
        Me.ddllokasi.Visible = True
        Me.lbl01.Visible = False

    End Sub

    Protected Sub ddllokasi_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddllokasi.SelectedIndexChanged
        Me.btnsend.Enabled = True
        Me.btnsend.Visible = True
    End Sub

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

        '================== Nomor Terakhir====================
        con.Open()
        With cmd1
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Select Top 1 NoTRS From tbl_TRainS Order By NoTRS Desc"
            dr = .ExecuteReader
        End With
        dr.Read()
        th1 = dr.Item(0).ToString
        th1 = Mid(th1, 10, 2)
        th2 = Mid(Year(Now), 3, 2)

        nomer = dr.Item(0).ToString
        nomer = Mid(nomer, 13, 4) + 1
        If th2 > th1 Then
            nomer = "1"
        End If
        If Len(nomer) = 1 Then
            nomer = "KPTO/HRP/" & th2 & "/000" & nomer & "/TRS"
        ElseIf Len(nomer) = 2 Then
            nomer = "KPTO/HRP/" & th2 & "/00" & nomer & "/TRS"
        ElseIf Len(nomer) = 3 Then
            nomer = "KPTO/HRP/" & th2 & "/0" & nomer & "/TRS"
        ElseIf Len(nomer) = 4 Then
            nomer = "KPTO/HRP/" & th2 & "/" & nomer & "/TRS"
        End If
        con.Close()
        ''=====
        'MsgBox(nomer)


        con.Open()
        With cmd2
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Insert Into tbl_trains (Notrs,NRPcreator,TglCreated,uraiantraining,lokasitraining,status) Values(@NotRS,@NrpUser,getdate(),@uraiantraining,@lokasi,'Proses HRGA')"

            .Parameters.Add("@NoTRS", SqlDbType.VarChar, 50)
            .Parameters.Add("@NrpUser", SqlDbType.VarChar, 10)
            .Parameters.Add("@uraiantraining", SqlDbType.VarChar, 200)
            .Parameters.Add("@lokasi", SqlDbType.VarChar, 20)


            'MsgBox(nomer)

            .Parameters("@Notrs").Value = nomer
            .Parameters("@NrpUser").Value = Request.Cookies("Userid").Value
            .Parameters("@uraiantraining").Value = Me.txturaian.Text
            .Parameters("@lokasi").Value = Me.ddllokasi.Text


            .ExecuteNonQuery()
            con.Close()
        End With
        con.Open()




        With cmd2

            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Insert Into tbl_Subtrain (Notrs,NRP,awaltrain,akhirtrain) Values(@No,@Nrp,@awaltrain,@akhirtrain)"

            .Parameters.Add("@No", SqlDbType.VarChar, 20)
            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters.Add("@awaltrain", SqlDbType.DateTime)
            .Parameters.Add("@akhirtrain", SqlDbType.DateTime)

            .Parameters("@No").Value = nomer

            .Parameters("@awaltrain").Value = Me.TxtAwalSKL.Text
            .Parameters("@akhirtrain").Value = Me.TxtAkhirSKL.Text

            For I = 0 To Me.listnrp.Items.Count - 1
                'MsgBox(Me.listnrp.Items(I).Text)
                .Parameters("@nrp").Value = Me.listnrp.Items(I).Text
                .ExecuteNonQuery()

            Next
        End With
        con.Close()

        '----------------------pop up-----------------------
        ' Define the name and type of the client scripts on the page.
        Dim csname1 As String = "PopupScript"
        Dim cstype As Type = Me.GetType()
        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript
        ' Check to see if the startup script is already registered.
        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
            Dim cstext1 As String = "alert('train di Site sudah berhasil disimpan');"
            cstext1 += "self.close();"
            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
        End If
        'Response.Redirect("/.")
    End Sub
End Class
