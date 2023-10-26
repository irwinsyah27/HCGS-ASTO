Imports System.Data
Imports System.Data.SqlClient
Partial Class rTugas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'MsgBox(Me.DetailsView1.Rows(1).Cells(1).Text.ToString)
        '' Define the name and type of the client scripts on the page.
        'Dim csname1 As String = "PopupScript"
        'Dim csname2 As String = "ButtonClickScript"
        'Dim cstype As Type = Me.GetType()

        '' Get a ClientScriptManager reference from the Page class.
        'Dim cs As ClientScriptManager = Page.ClientScript

        '' Check to see if the startup script is already registered.
        'If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

        '    Dim cstext1 As String = "__doPostBack('DetailsView1','Edit$0');"
        '    'cstext1 += "self.close();"
        '    'cstext1 += "location='default.aspx'"
        '    cs.RegisterStartupScript(cstype, csname1, cstext1, True)

        'End If
    End Sub


    Protected Sub DetailsView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewUpdatedEventArgs) Handles DetailsView1.ItemUpdated
        'MsgBox("test 1 " & Me.DetailsView1.Fields.Item(0).ToString)
        'MsgBox("test 2 " & e.NewValues.Item(0).ToString)
        'MsgBox("test 3 " & Me.DetailsView1.DataKey.Item(0).ToString)
        'MsgBox("test 3 " & Me.DetailsView1.Rows(0).Cells.Item(1).ToString)
        ' Define the name and type of the client scripts on the page.
        Dim csname1 As String = "PopupScript"
        Dim csname2 As String = "ButtonClickScript"
        Dim cstype As Type = Me.GetType()

        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript

        ' Check to see if the startup script is already registered.
        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

            Dim cstext1 As String = "window.opener.__doPostBack(true);"
            cstext1 += "self.close();"
            'cstext1 += "location='default.aspx'"
            cs.RegisterStartupScript(cstype, csname1, cstext1, True)

        End If

    End Sub


    Protected Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
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
            .CommandText = "Select Nrp, Nama, Jabatan, Golongan, Departemen, StatusPenerimaan, StatusKawin, StatusBawaKeluarga, AlamatTinggal, Telepon  From tblKaryawan Where Nrp = @Nrp "

            .Parameters.Add("@Nrp", SqlDbType.VarChar, 10)
            .Parameters("@Nrp").Value = Me.DetailsView1.Rows(1).Cells(1).Text.ToString
            dr = .ExecuteReader
        End With
        If dr.Read = True Then

            If dr.Item("StatusBawaKeluarga").ToString = True Then
                CType(Me.DetailsView1.Rows(0).FindControl("RangeValidator1"), RangeValidator).MaximumValue = 8
                CType(Me.DetailsView1.Rows(0).FindControl("RangeValidator1"), RangeValidator).ErrorMessage = "Maximum : 8 hari. "
            Else
                If dr.Item("StatusPenerimaan").ToString = "LOCAL" Then
                    CType(Me.DetailsView1.Rows(0).FindControl("RangeValidator1"), RangeValidator).MaximumValue = 8
                    CType(Me.DetailsView1.Rows(0).FindControl("RangeValidator1"), RangeValidator).ErrorMessage = "Maximum : 8 hari. "
                ElseIf dr.Item("StatusPenerimaan").ToString = "KIRIMAN" Then
                    If Left(dr.Item("Golongan").ToString, 1) <= 2 Then
                        CType(Me.DetailsView1.Rows(0).FindControl("RangeValidator1"), RangeValidator).MaximumValue = 14
                        CType(Me.DetailsView1.Rows(0).FindControl("RangeValidator1"), RangeValidator).ErrorMessage = "Maximum : 14 hari. "

                    ElseIf Left(dr.Item("Golongan").ToString, 1) >= 3 And Left(dr.Item("Golongan").ToString, 1) <= 4 Then
                        CType(Me.DetailsView1.Rows(0).FindControl("RangeValidator1"), RangeValidator).MaximumValue = 12
                        CType(Me.DetailsView1.Rows(0).FindControl("RangeValidator1"), RangeValidator).ErrorMessage = "Maximum : 12 hari. "

                    ElseIf Left(dr.Item("Golongan").ToString, 1) = "P" Then
                        If Right(dr.Item("Golongan").ToString, 1) <= 4 Then
                            CType(Me.DetailsView1.Rows(0).FindControl("RangeValidator1"), RangeValidator).MaximumValue = 14
                            CType(Me.DetailsView1.Rows(0).FindControl("RangeValidator1"), RangeValidator).ErrorMessage = "Maximum : 14 hari. "
                        Else
                            CType(Me.DetailsView1.Rows(0).FindControl("RangeValidator1"), RangeValidator).MaximumValue = 12
                            CType(Me.DetailsView1.Rows(0).FindControl("RangeValidator1"), RangeValidator).ErrorMessage = "Maximum : 12 hari. "
                        End If

                    ElseIf Left(dr.Item("Golongan").ToString, 1) = "G" Then
                        If Right(dr.Item("Golongan").ToString, 1) <= 5 Then
                            CType(Me.DetailsView1.Rows(0).FindControl("RangeValidator1"), RangeValidator).MaximumValue = 14
                            CType(Me.DetailsView1.Rows(0).FindControl("RangeValidator1"), RangeValidator).ErrorMessage = "Maximum : 14 hari. "
                        Else
                            CType(Me.DetailsView1.Rows(0).FindControl("RangeValidator1"), RangeValidator).MaximumValue = 12
                            CType(Me.DetailsView1.Rows(0).FindControl("RangeValidator1"), RangeValidator).ErrorMessage = "Maximum : 12 hari. "
                        End If
                    End If
                Else
                    CType(Me.DetailsView1.Rows(0).FindControl("RangeValidator1"), RangeValidator).MaximumValue = 8
                    CType(Me.DetailsView1.Rows(0).FindControl("RangeValidator1"), RangeValidator).ErrorMessage = "Maximum : 8 hari. "

                End If

            End If

        End If
        AwalCutiTahunan1()
        'CType(Me.DetailsView1.Rows(0).FindControl("txtTahunan"), TextBox).Text = 10
    End Sub
    Sub AwalCutiTahunan1()
        Dim AwalCTahunan As DateTime
        Dim temp1 As DateTime

        Dim i As Integer
        If CType(Me.DetailsView1.Rows(0).FindControl("txtAwal"), TextBox).Text <> "" Then
            AwalCTahunan = CType(Me.DetailsView1.Rows(0).FindControl("txtAwal"), TextBox).Text
            If CType(Me.DetailsView1.Rows(0).FindControl("txtPerjalanan"), TextBox).Text <> "0" Then
                AwalCTahunan = AwalCTahunan.AddDays(CInt(CType(Me.DetailsView1.Rows(0).FindControl("txtLapangan"), TextBox).Text) + 1)
            Else
                AwalCTahunan = AwalCTahunan.AddDays(CType(Me.DetailsView1.Rows(0).FindControl("txtLapangan"), TextBox).Text)
            End If

            temp1 = Format(AwalCTahunan, "dd MMM yyyy")

            If CType(Me.DetailsView1.Rows(0).FindControl("txtTahunan"), TextBox).Text <> "0" Then
                Do While i < CInt(CType(Me.DetailsView1.Rows(0).FindControl("txtTahunan"), TextBox).Text) + CInt(CType(Me.DetailsView1.Rows(0).FindControl("txtBesar"), TextBox).Text)
                    If temp1.DayOfWeek <> DayOfWeek.Sunday Then
                        i += 1
                    End If
                    temp1 = temp1.AddDays(1)
                Loop
                If CType(Me.DetailsView1.Rows(0).FindControl("txtPerjalanan"), TextBox).Text = 0 Then
                    CType(Me.DetailsView1.Rows(0).FindControl("txtAkhir"), TextBox).Text = Format(Format(temp1.AddDays(-1), "dd/MM/yyyy H:mm:ss"))
                Else
                    CType(Me.DetailsView1.Rows(0).FindControl("txtAkhir"), TextBox).Text = Format(Format(temp1, "dd/MM/yyyy H:mm:ss"))
                End If
            Else
                CType(Me.DetailsView1.Rows(0).FindControl("txtAkhir"), TextBox).Text = Format(CDate(CType(Me.DetailsView1.Rows(0).FindControl("txtAwal"), TextBox).Text).AddDays(CInt(CType(Me.DetailsView1.Rows(0).FindControl("txtLapangan"), TextBox).Text) - 1 + CInt(CType(Me.DetailsView1.Rows(0).FindControl("txtPerjalanan"), TextBox).Text)), "dd/MM/yyyy H:mm:ss")
            End If
        End If
    End Sub

    Protected Sub TextBox2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        AwalCutiTahunan1()
    End Sub

    Protected Sub txtBesar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        AwalCutiTahunan1()
    End Sub

    Protected Sub txtPerjalanan_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        AwalCutiTahunan1()
    End Sub

    Protected Sub txtAwal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        AwalCutiTahunan1()
    End Sub
End Class
