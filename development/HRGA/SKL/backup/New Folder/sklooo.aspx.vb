Imports System.Data
Imports System.Data.SqlClient
Partial Class skl
    Inherits System.Web.UI.Page
    Protected Sub btnadd1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd1.Click
        Me.Gridkaryawan1.Visible = True

        Me.btnadd1.Visible = False

    End Sub

    Protected Sub Gridkaryawan1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Gridkaryawan1.SelectedIndexChanged
        Me.listnrp.Items.Add(Me.Gridkaryawan1.SelectedRow.Cells(1).Text)
        Me.listnama.Items.Add(Me.Gridkaryawan1.SelectedRow.Cells(2).Text)

        Me.Gridkaryawan1.Visible = False
        Me.btnadd1.Visible = True
        Me.lblhari7.Visible = True
        Me.Label9.Visible = True
        Me.Rdya.Visible = True
        Me.Rdno.Visible = True
    End Sub


    Protected Sub btnawallbr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnawallbr.Click
        Me.calawallbr.Visible = True
        Me.btnawallbr.Visible = False
        Me.btnadd1.Visible = False
        Me.lblhari7.Visible = True
        Me.Label9.Visible = True
        Me.Rdya.Enabled = False
        Me.Rdno.Enabled = False


    End Sub

    Protected Sub calawallbr_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles calawallbr.SelectionChanged
        If Me.calawallbr.SelectedDate.Date >= Date.Today.AddDays(-1) Then

            Me.txttglawal.Visible = True
            Me.lblawallbr.Visible = True
            Me.Label1.Visible = True
            Me.ddlawal1.Visible = True
            Me.ddlawal2.Visible = True
            Me.txttglawal.Text = Format((Me.calawallbr.SelectedDate), "dd/MM/yyyy").ToString
            Me.btnawallbr.Visible = False
            Me.calawallbr.Visible = False

        End If


    End Sub

    Protected Sub ddlawal2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlawal2.SelectedIndexChanged
        If Me.ddlawal2.Text <> "-" Then

            Me.TxtAwalSKL.Text = Me.txttglawal.Text & " " & Me.ddlawal1.Text & Me.Label1.Text & Me.ddlawal2.Text
            Me.TxtAwalSKL.Visible = True
            Me.btnakhirlbr.Visible = True
            Me.calawallbr.Visible = False
            Me.txttglawal.Visible = False
            Me.lblawallbr.Visible = False
            Me.ddlawal1.Visible = False
            Me.Label1.Visible = False
            Me.ddlawal2.Visible = False
            Me.Label7.Visible = True
            Me.lblakhirSKL.Visible = True


        Else
            Me.btnakhirlbr.Visible = False
        End If
    End Sub

    Protected Sub ddlawal1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlawal1.SelectedIndexChanged

    End Sub

    Protected Sub btnakhirlbr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnakhirlbr.Click
        Me.calakhirlbr.Visible = True
        Me.btnakhirlbr.Visible = False
    End Sub

    Protected Sub calakhirlbr_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles calakhirlbr.SelectionChanged
        'If Me.calakhirlbr.SelectedDate.Date >= Date.Today.AddDays(-1) Then
        If Me.calakhirlbr.SelectedDate.Date >= Me.txttglawal.Text Then

            Me.txttglakhir.Visible = True
            Me.lblakhirlbr.Visible = True
            Me.Label2.Visible = True
            Me.ddlakhir1.Visible = True
            Me.ddlakhir2.Visible = True
            Me.txttglakhir.Text = Format((Me.calakhirlbr.SelectedDate), "dd/MM/yyyy").ToString
            Me.btnakhirlbr.Visible = False
            Me.calakhirlbr.Visible = False

        End If

    End Sub

    Protected Sub ddlakhir2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlakhir2.SelectedIndexChanged
        If Me.ddlakhir2.Text <> "-" Then
            Me.TxtAkhirSKL.Text = Me.txttglakhir.Text & " " & Me.ddlakhir1.Text & Me.Label1.Text & Me.ddlakhir2.Text
            Me.btnsend.Visible = True
            Me.TxtAkhirSKL.Visible = True

            Me.txttglakhir.Visible = False
            Me.lblakhirlbr.Visible = False
            Me.ddlakhir1.Visible = False
            Me.Label2.Visible = False
            Me.ddlakhir2.Visible = False
            Me.Label8.Visible = True
            Me.Label10.Visible = True
            Me.lblUraianKerja.Visible = True
            Me.txturaian.Visible = True

        End If


    End Sub

    Protected Sub btnsend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsend.Click
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd1 As SqlClient.SqlCommand = Nothing
        Dim cmd2 As SqlClient.SqlCommand = Nothing
        Dim nomer As String
        Dim I As Integer
        Dim hari7 As Integer

        If Me.Rdya.Checked = True Then
            hari7 = 1
        End If
        If Me.Rdno.Checked = True Then
            hari7 = 0
        End If


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
            .CommandText = "Select Top 1 NoSKL From tbl_SKL Order By NoSKL Desc"
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
            nomer = "ADRO/HRP/" & th2 & "/000" & nomer & "/SKL"
        ElseIf Len(nomer) = 2 Then
            nomer = "ADRO/HRP/" & th2 & "/00" & nomer & "/SKL"
        ElseIf Len(nomer) = 3 Then
            nomer = "ADRO/HRP/" & th2 & "/0" & nomer & "/SKL"
        End If
        con.Close()
        ''=====

        con.Open()
        With cmd2

            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Insert Into tbl_Subskl (NoSKL,NRP,awallembur,akhirlembur, harike7) Values(@No,@Nrp,@awallembur,@akhirlembur,@harike7)"

            .Parameters.Add("@No", SqlDbType.VarChar, 20)
            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters.Add("@harike7", SqlDbType.Bit)
            .Parameters.Add("@awallembur", SqlDbType.DateTime)
            .Parameters.Add("@akhirlembur", SqlDbType.DateTime)


            .Parameters("@No").Value = nomer
            .Parameters("@harike7").Value = hari7
            .Parameters("@awallembur").Value = Me.TxtAwalSKL.Text
            .Parameters("@akhirlembur").Value = Me.TxtAkhirSKL.Text

            For I = 0 To Me.listnrp.Items.Count - 1

                .Parameters("@nrp").Value = Me.listnrp.Items(I).Text
                .ExecuteNonQuery()

            Next
        End With
        con.Close()


        con.Open()
        With cmd2
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Insert Into tbl_skl (NoSKL,NRPrequestor,TglCreated,uraianLembur) Values(@NoSKL,@NrpUser,getdate(),@uraianlembur)"

            .Parameters.Add("@NoSKL", SqlDbType.VarChar, 50)
            .Parameters.Add("@NrpUser", SqlDbType.VarChar, 10)
            .Parameters.Add("@uraianlembur", SqlDbType.VarChar, 200)



            .Parameters("@NoSKL").Value = nomer
            .Parameters("@NrpUser").Value = Session("Userid").ToString
            .Parameters("@uraianlembur").Value = Me.txturaian.Text

            .ExecuteNonQuery()
            con.Close()
        End With

        
        '---------insert ke tbl _alert untuk run alert---------
        con.Open()
        With cmd2
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "update tbl_alert set noinsert=@noinsert"
            '.CommandText = "Insert Into tbl_skl (NoSKL,NRPrequestor,TglCreated,uraianLembur) Values(@NoSKL,@NrpUser,getdate(),@uraianlembur)"

            .Parameters.Add("@noinsert", SqlDbType.VarChar, 20)
            '.Parameters.Add("@catatan", SqlDbType.VarChar, 200)


            .Parameters("@noinsert").Value = nomer
            '.Parameters("@catatan").Value = Me.txtcatatan.Text
            .ExecuteNonQuery()
            con.Close()
        End With

        '---------insert ke tbl _alert untuk run alert---------

        ' Define the name and type of the client scripts on the page.
        Dim csname1 As String = "PopupScript"
        Dim cstype As Type = Me.GetType()
        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript
        ' Check to see if the startup script is already registered.
        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
            Dim cstext1 As String = "alert('SKL sudah berhasil disimpan');"
            cstext1 += "self.close();"
            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
        End If
        'Response.Redirect("listskl1.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("Dept") = "" Then

            Session("Q") = "skl.aspx"

            Response.Redirect("login.aspx")

        Else


            Me.LblNamarequestor.Text = Session("nama")

            Me.LblNRPRequestor.Text = Session("userid")

            Me.LblTanggalCreated.Text = Date.Now

        End If


    End Sub


    Protected Sub ddlakhir1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlakhir1.SelectedIndexChanged
        Dim jam As String
        jam = 1

        If Me.ddlakhir1.Text >= Me.ddlawal1.Text + jam Then
            Me.ddlakhir2.Enabled = True

        End If
    End Sub

    Protected Sub Rdya_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdya.CheckedChanged
        If Me.Rdya.Checked = True Then
            'MsgBox("YA")
            Me.lblawalskl.Visible = True
            Me.Label6.Visible = True
            Me.btnawallbr.Visible = True
        End If
    End Sub

    Protected Sub Rdno_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdno.CheckedChanged
        If Me.Rdno.Checked = True Then
            'MsgBox("tidak")
            Me.lblawalskl.Visible = True
            Me.Label6.Visible = True
            Me.btnawallbr.Visible = True
        End If
    End Sub

    Protected Sub txturaian_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txturaian.TextChanged
        Me.Label10.Visible = False
        Me.btnsend.Visible = True
        Me.btnsend.Enabled = True
    End Sub
End Class
'
