Imports System.Data
Imports System.Data.SqlClient
Partial Class _HRGA_EditIO_LS
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim nrpk, tgla, tglb As String
        nrpk = Session("nrpk")
        tgla = Session("tgla")
        tglb = Session("tglb")
        If Session("userid") = "" Then
            Session("Q") = "./editio2.aspx"
            Response.Redirect("./login.aspx")
        End If
        'If InStr(1, Session("jabatan").ToString, "PAYROLL") = 0 And InStr(1, Session("ndPosisi").ToString, "PAYROLL") = 0 Then
        If InStr(1, Session("jabatan").ToString, "GENERAL AFFAIR SITE GROUP LEADER") = 0 And InStr(1, Session("jabatan").ToString, "KORLAP TRAC") = 0 And InStr(1, Session("jabatan").ToString, "IT REPRESENTATIF") = 0 And InStr(1, Session("ndPosisi").ToString, "GENERAL AFFAIR SITE GROUP LEADER") = 0 Then

            Dim csname1 As String = "PopupScript"
            Dim cstype As Type = Me.GetType()

            Dim cs As ClientScriptManager = Page.ClientScript

            If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

                Dim cstext1 As String = "alert('Anda tidak punya access sebagai GENERAL AFFAIR...    ');"
                cstext1 += "location='login.aspx';"
                cs.RegisterStartupScript(cstype, csname1, cstext1, True)

            End If
        End If
        ''txtSearch.Text = nrpk
    End Sub

    Protected Sub GridView1_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GridView1.RowUpdated
        'Dim N As String = e.Keys.Item(0).ToString

        'Dim con As SqlClient.SqlConnection = Nothing
        'Dim cmd As SqlClient.SqlCommand = Nothing

        'cmd = New SqlClient.SqlCommand

        'Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        'con = New SqlClient.SqlConnection(connectionStrings("Data_abs1ConnectionString").ConnectionString)

        'con.Open()
        'With cmd
        '    .Connection = con
        '    .CommandType = CommandType.StoredProcedure
        '    .CommandText = "SP_UPDATE_JK_DATA_ABS1"

        '    .Parameters.Add("@ID", SqlDbType.Int)
        '    .Parameters("@ID").Value = N

        '    .ExecuteNonQuery()
        'End With
        'con.Close()

		'=========================================
		
        'Response.Write(N)
        'Nama = e.NewValues.Item(0).ToString
        'Umur = e.NewValues.Item(1).ToString
        'Tanggal = e.NewValues.Item(2).ToString
        'Dari_Ke = e.NewValues.Item(3).ToString
        'Keterangan = e.NewValues.Item(4).ToString

        'If N = "0" Then
        '    'MsgBox("Simpan data baru..")
        '    insFlight()
        'End If
    End Sub

    'Protected Sub btnCariError_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCariError.Click
    '    Me.SqlDataSource1.SelectCommand = "SELECT  [id]" & _
    '            ", lembarkerja. [nrp]" & _
    '            ", [nama]" & _
    '            ", [jkp_opr]" & _
    '            ", tanggal " & _
    '            ", [shift]" & _
    '            ", [Absent]" & _
    '            ", [SKL]" & _
    '            ", [JK1] = LEFT(Round([jk1],2),5)" & _
    '            ", [IN] = Case Len(Cast(Datepart(hour,lembarkerja.[in])as varchar)) When 1 Then '0'+Cast(Datepart(hour,lembarkerja.[in])as varchar) Else Cast(Datepart(hour,[in])as varchar)End +':'+ Case Len(Cast(Datepart(minute,lembarkerja.[in])as varchar)) When 1 Then '0'+Cast(Datepart(minute,lembarkerja.[in])as varchar)Else Cast(Datepart(minute,lembarkerja.[in])as varchar)End " & _
    '            ", [OUT] = Case Len(Cast(Datepart(hour,lembarkerja.[out])as varchar)) When 1 Then '0'+Cast(Datepart(hour,lembarkerja.[out])as varchar) Else Cast(Datepart(hour,lembarkerja.[out])as varchar)End +':'+ Case Len(Cast(Datepart(minute,lembarkerja.[out])as varchar)) When 1 Then '0'+Cast(Datepart(minute,lembarkerja.[out])as varchar)Else Cast(Datepart(minute,lembarkerja.[out])as varchar)End " & _
    '            "  FROM [lembarkerja] INNER JOIN Karyawan ON lembarkerja.Nrp = Karyawan.Nrp" & _
    '            "  Where lembarkerja.Absent = 'X' " & _
    '            "  Order By Tanggal desc"
    'End Sub
End Class
