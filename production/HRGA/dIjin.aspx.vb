Imports System.Data
Imports System.Data.SqlClient
Partial Class HRGA_dIjin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./dIjin.aspx?n=" & Request.QueryString("n").ToString
            Response.Redirect("./login.aspx")
        End If
        DataIjin()
        DataKaryawan()
    End Sub

    Protected Sub btn2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn2.Click
        UpdateAtasan()
    End Sub

    Protected Sub btn3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn3.Click
        UpdateHR()
    End Sub

    Sub UpdateAtasan()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Update tblIjin Set " _
                            & "[Persetujuan]=@Persetujuan" _
                            & ",[CatatanAtasan]=@CatatanAtasan " _
                            & ",[Atasan]=@Atasan " _
                            & "Where NoIjin=@NoIjin "

            .Parameters.Add("@NoIjin", SqlDbType.VarChar, 20)
            .Parameters.Add("@Persetujuan", SqlDbType.Bit)
            .Parameters.Add("@CatatanAtasan", SqlDbType.VarChar, 100)
            .Parameters.Add("@Atasan", SqlDbType.VarChar, 10)

            .Parameters("@NoIjin").Value = Request.QueryString("n").ToString
            If Me.RadioPersetujuan1.Checked = True Then
                .Parameters("@Persetujuan").Value = True
            Else
                .Parameters("@Persetujuan").Value = False
            End If
            .Parameters("@CatatanAtasan").Value = Me.txtCatatanAtasan.Text
            .Parameters("@Atasan").Value = Session("userid")

            .ExecuteNonQuery()
            con.Close()
        End With

        Dim csname1 As String = "PopupScript"
        Dim cstype As Type = Me.GetType()
        Dim cs As ClientScriptManager = Page.ClientScript

        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

            Dim cstext1 As String = "alert('Ijin telah disimpan...    ');"
            cstext1 += "location='dIjin.aspx?n=" & Request.QueryString("n").ToString & "';"
            cs.RegisterStartupScript(cstype, csname1, cstext1, True)

        End If
    End Sub

    Sub UpdateHR()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Update tblIjin Set " _
                            & "[ValidasiHR]=@ValidasiHR" _
                            & ",[PotongCuti]=@PotongCuti" _
                            & ",[PotongOff]=@PotongOff" _
                            & ",[CatatanHR]=@CatatanHR " _
                            & ",[HR]=@HR " _
                            & "Where NoIjin=@NoIjin "

            .Parameters.Add("@NoIjin", SqlDbType.VarChar, 20)
            .Parameters.Add("@ValidasiHR", SqlDbType.Bit)
            .Parameters.Add("@PotongCuti", SqlDbType.Bit)
            .Parameters.Add("@PotongOff", SqlDbType.Bit)
            .Parameters.Add("@CatatanHR", SqlDbType.VarChar, 100)
            .Parameters.Add("@HR", SqlDbType.VarChar, 10)

            .Parameters("@NoIjin").Value = Request.QueryString("n").ToString
            If Me.RadioValidasi1.Checked = True Then
                .Parameters("@ValidasiHR").Value = True
            Else
                .Parameters("@ValidasiHR").Value = False
            End If
            If Me.RadioPotongCuti.Checked = True Then
                .Parameters("@PotongCuti").Value = True
                .Parameters("@PotongOff").Value = False
            ElseIf Me.RadioPotongOff.Checked = True Then
                .Parameters("@PotongOff").Value = True
                .Parameters("@PotongCuti").Value = False
            Else
                .Parameters("@PotongOff").Value = False
                .Parameters("@PotongCuti").Value = False
            End If
            .Parameters("@CatatanHR").Value = Me.txtCatatanHR.Text
            .Parameters("@HR").Value = Session("userid")

            .ExecuteNonQuery()
            con.Close()
        End With

        Dim csname1 As String = "PopupScript"
        Dim cstype As Type = Me.GetType()
        Dim cs As ClientScriptManager = Page.ClientScript

        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

            Dim cstext1 As String = "alert('Ijin telah disimpan...    ');"
            cstext1 += "location='dIjin.aspx?n=" & Request.QueryString("n").ToString & "';"
            cs.RegisterStartupScript(cstype, csname1, cstext1, True)

        End If
    End Sub

    Sub DataKaryawan()
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
            .CommandText = "Select Nrp,Nama,Departemen,StatusKawin,StatusKeluarga,SisaCutiPeriode1,SisaCutiPeriode2,SisaCuti = SisaCutiPeriode1 + SisaCutiPeriode2 ,StatusBawaKeluarga = Case StatusBawaKeluarga When 1 Then 'YA' Else 'TIDAK' End  From tblKaryawan Where Nrp = @Nrp"

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = Me.lblNrp.Text

            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Me.lblNama.Text = dr.Item("Nama").ToString
            Me.lblDepartemen.Text = dr.Item("Departemen").ToString
            Me.lblSisaCuti.Text = dr.Item("SisaCuti").ToString & " hari"
        Else
            Me.lblNama.Text = ""
            Me.lblDepartemen.Text = ""
            'Me.txtStatusKeluarga.Text = ""
            'Me.txtStatusBawaKeluarga.Text = ""
        End If
        con.Close()
    End Sub

    Sub DataIjin()
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
            .CommandText = "Select tblIjin.*, tblKaryawan.Departemen From tblIjin INNER JOIN tblKaryawan ON tblIjin.Nrp = tblKaryawan.Nrp Where NoIjin = @NoIjin"

            .Parameters.Add("@NoIjin", SqlDbType.VarChar, 20)
            .Parameters("@NoIjin").Value = Request.QueryString("n").ToString

            dr = .ExecuteReader
        End With
        If dr.Read = True Then
            Me.lblNrp.Text = dr.Item("Nrp").ToString
            Me.lblAwal.Text = Format(CDate(dr.Item("Awal").ToString), "dd MMMM yyyy")
            Me.lblAkhir.Text = Format(CDate(dr.Item("Akhir").ToString), "dd MMMM yyyy")
            Me.lblKeperluan.Text = dr.Item("Keperluan").ToString
            Me.lblAtasan.Text = dr.Item("Atasan").ToString
            Me.lblHR.Text = dr.Item("HR").ToString

            If dr.Item("Kode").ToString = "H" Then
                Me.RadioButton2.Checked = True
            ElseIf dr.Item("Kode").ToString = "G" Then
                Me.RadioButton3.Checked = True
            Else
                Me.RadioButton1.Checked = True
            End If
            If dr.Item("Persetujuan").ToString <> "" Then
                If dr.Item("Persetujuan").ToString = True Then
                    Me.RadioPersetujuan1.Checked = True
                    Me.RadioPersetujuan2.Checked = False
                    Me.Panel4.Visible = True
                Else
                    Me.RadioPersetujuan1.Checked = False
                    Me.RadioPersetujuan2.Checked = True
                    Me.Panel4.Visible = False
                End If
                Me.txtCatatanAtasan.Visible = False
                Me.lblCatatanAtasan.Text = dr.Item("CatatanAtasan").ToString
                Me.btn2.Enabled = False
                Me.btn2.Visible = False
                Me.RadioPersetujuan1.Enabled = False
                Me.RadioPersetujuan2.Enabled = False
                Me.RadioPotongCuti.Enabled = False
                Me.RadioPotongOff.Enabled = False
            Else
                If Me.txtCatatanAtasan.Text <> "" Then
                    Me.btn2.Visible = True
                Else
                    Me.btn2.Visible = False
                End If
            End If
            If dr.Item("ValidasiHR").ToString <> "" Then
                If dr.Item("ValidasiHR").ToString = True Then
                    Me.RadioValidasi1.Checked = True
                    Me.RadioValidasi2.Checked = False
                ElseIf dr.Item("PotongCuti").ToString = True Then
                    Me.RadioValidasi1.Checked = False
                    Me.RadioValidasi2.Checked = True
                    Me.RadioPotongCuti.Visible = True
                    Me.RadioPotongOff.Visible = True
                    Me.RadioPotongCuti.Enabled = False
                    Me.RadioPotongOff.Enabled = False
                    Me.RadioValidasi1.Enabled = False
                    Me.RadioValidasi2.Enabled = False
                    Me.RadioPotongCuti.Checked = True
                ElseIf dr.Item("PotongOff").ToString = True Then
                    Me.RadioValidasi1.Checked = False
                    Me.RadioValidasi2.Checked = True
                    Me.RadioPotongCuti.Visible = True
                    Me.RadioPotongOff.Visible = True
                    Me.RadioPotongCuti.Enabled = False
                    Me.RadioPotongOff.Enabled = False
                    Me.RadioValidasi1.Enabled = False
                    Me.RadioValidasi2.Enabled = False
                    Me.RadioPotongOff.Checked = True
                End If
                Me.txtCatatanHR.Visible = False
                Me.lblCatatanHR.Text = dr.Item("CatatanHR").ToString
                
            Else
                If Me.txtCatatanHR.Text <> "" Then
                    Me.btn3.Visible = True
                Else
                    Me.btn3.Visible = False
                End If
                Me.RadioPotongCuti.Enabled = True
                Me.RadioPotongOff.Enabled = True
            End If

        Else
            Me.lblNrp.Text = ""
            Me.lblAwal.Text = ""
            Me.lblAkhir.Text = ""
            Me.lblKeperluan.Text = ""
            Me.lblCatatanAtasan.Text = ""
        End If

        '====AturForm====================
        If InStr(1, Session("jabatan").ToString, "HEAD") > 0 Then
            Me.Panel3.Enabled = True
            If Trim(dr.Item("Departemen").ToString) <> Trim(Session("dept").ToString) Then
                Me.Panel3.Enabled = False
            Else
                Me.Panel3.Enabled = True
            End If
            'Me.btn2.Visible = True
        ElseIf InStr(1, Session("ndPosisi").ToString, "HEAD") > 0 Then
            Me.Panel3.Enabled = True
            If Trim(dr.Item("Departemen").ToString) <> Trim(Session("dept").ToString) Then
                Me.Panel3.Enabled = False
            Else
                Me.Panel3.Enabled = True
            End If
            'Me.btn2.Visible = True
        Else

            Me.Panel3.Enabled = False

        End If

        If InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL") > 0 Then
            Me.Panel4.Enabled = True
            'Me.btn3.Visible = True
        ElseIf InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("ndPosisi").ToString, "PAYROLL") > 0 Then
            Me.Panel4.Enabled = True
            'Me.btn3.Visible = True
        Else
            Me.Panel4.Enabled = False
            'Me.btn3.Visible = False
        End If
        con.Close()
    End Sub

    Protected Sub RadioPersetujuan1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioPersetujuan1.CheckedChanged
        If Me.RadioPersetujuan1.Checked = True Then
            Me.txtCatatanAtasan.Enabled = True
        End If
    End Sub

    Protected Sub RadioPersetujuan2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioPersetujuan2.CheckedChanged
        If Me.RadioPersetujuan2.Checked = True Then
            Me.txtCatatanAtasan.Enabled = True
        End If
    End Sub

    Protected Sub RadioValidasi1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioValidasi1.CheckedChanged
        If Me.RadioValidasi1.Checked = True Then
            Me.txtCatatanHR.Enabled = True
            Me.RadioPotongCuti.Visible = False
            Me.RadioPotongOff.Visible = False
            Me.RadioPotongCuti.Checked = False
            Me.RadioPotongOff.Checked = False
        End If
    End Sub

    Protected Sub RadioValidasi2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioValidasi2.CheckedChanged
        If Me.RadioValidasi2.Checked = True Then
            Me.txtCatatanHR.Enabled = True
            Me.RadioPotongCuti.Visible = True
            Me.RadioPotongOff.Visible = True
        End If
    End Sub

End Class
