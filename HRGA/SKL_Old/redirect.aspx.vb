Imports System.Data
Imports System.Data.SqlClient
Partial Class HRGA_SKL_redirect
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Dept") = "" Then
            Session("Q") = "skl/redirect.aspx?n=" & Request.QueryString("n").ToString
            'Session("R") = "aprovehr1.aspx?n=" & Request.QueryString("n").ToString

            Response.Redirect("../login.aspx")
        Else
            Session("noskl") = Request.QueryString("n").ToString
            cek()
        End If

    End Sub

    Function cek()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim cmd1 As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand
        cmd1 = New SqlClient.SqlCommand


        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("Data_abs1ConnectionString").ConnectionString)

        Dim dr As SqlDataReader
        'Dim th1 As String
        'Dim th2 As String

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "select noskl,aprovedept,aprovehr,status from tbl_skl1  where noskl='" & Session("noskl").ToString & "'"


            dr = .ExecuteReader

        End With
        If dr.Read Then
            Session("status") = Trim(dr.Item("status").ToString)
            Session("aprovedept") = Trim(dr.Item("aprovedept").ToString)
            Session("aprovehr") = Trim(dr.Item("aprovehr").ToString)


            Response.Write(Session("status").ToString)
            Response.Write(Session("aprovedept").ToString)
            Response.Write(Session("aprovehr").ToString)


        End If
        con.Close()

        ' '' '' '' ''If dr.Read Then
        ' '' '' '' ''    If Trim(dr.Item("status").ToString) = "Proses Dept." Then
        ' '' '' '' ''        Response.Write("dept")

        ' '' '' '' ''        Response.Redirect("aprovehead.aspx?n=" & (Session("noskl").ToString))
        ' '' '' '' ''    ElseIf Trim(dr.Item("status").ToString) = "Proses HRGA" Then
        ' '' '' '' ''        Response.Redirect("aprovehr1.aspx?n=" & (Session("noskl").ToString))
        ' '' '' '' ''    ElseIf Trim(dr.Item("status").ToString) = "Reject Dept." Then
        ' '' '' '' ''        Response.Redirect("aprovehead.aspx?n=" & (Session("noskl").ToString))



        ' '' '' '' ''    End If
        ' '' '' '' ''    Response.Write("salah")
        ' '' '' '' ''End If

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            '.CommandText = "select noskl,aprovedept,aprovehr,status from tbl_skl1  where noskl='" & Session("noskl").ToString & "'"
            .CommandText = "select nrp, nama, dept, aprove,aprovehr from karyawan where nrp='" & Session("userid").ToString & "'"


            dr = .ExecuteReader

        End With
        If dr.Read Then
            
            Session("dept1") = Trim(dr.Item("dept").ToString)
            If (dr.Item("aprove").ToString) = "" Then
                Session("aprove") = "0"

            Else
                Session("aprove") = Trim(dr.Item("aprove").ToString)
            End If

            If (dr.Item("aprovehr").ToString) = "" Then
                Session("aprovehr1") = "0"

            Else
                Session("aprovehr1") = Trim(dr.Item("aprovehr").ToString)
            End If
            'Session("aprove") = Trim(dr.Item("aprove").ToString)
            'Session("aprovehr1") = Trim(dr.Item("aprovehr").ToString)


            Response.Write(Session("dept1").ToString)
            Response.Write(Session("aprove").ToString)
            Response.Write(Session("aprovehr1").ToString)


            '' ''----------------redirecting ke form apa--------------


            ' ''If (Session("status").ToString = "Proses Dept.") And ((Session("aprove").ToString = True) Or (Session("aprove").ToString = "1")) Then
            ' ''    'Response.Write("proses dept")
            ' ''    Response.Redirect("aprovehead.aspx?n=" & (Session("noskl").ToString))
            ' ''ElseIf (Session("status").ToString = "Proses Dept.") And ((Session("aprove").ToString = False) Or (Session("aprove").ToString = "0")) Then
            ' ''    'Response.Write("proses dept..anda tidak berhak aprove")

            ' ''    '---------------popup--------------

            ' ''    ' Define the name and type of the client scripts on the page.
            ' ''    Dim csname1 As String = "PopupScript"
            ' ''    Dim cstype As Type = Me.GetType()
            ' ''    ' Get a ClientScriptManager reference from the Page class.
            ' ''    Dim cs As ClientScriptManager = Page.ClientScript
            ' ''    ' Check to see if the startup script is already registered.
            ' ''    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
            ' ''        Dim cstext1 As String = "alert('SKL Belum diaprove atasan');"
            ' ''        cstext1 += "self.close();"
            ' ''        cs.RegisterStartupScript(cstype, csname1, cstext1, True)
            ' ''    End If
            ' ''ElseIf (Session("status").ToString = "complete") And ((Session("aprove").ToString = True) Or (Session("aprove").ToString = "1") Or (Session("aprove").ToString = "0") Or (Session("aprove").ToString = False)) Then
            ' ''    'Response.Write("proses dept..anda tidak berhak aprove")
            ' ''    Response.Redirect("vwskl1.aspx?n=" & (Session("noskl").ToString))


            ' ''ElseIf (Session("status").ToString = "Reject Dept.") Then
            ' ''    'Response.Write("proses dept..anda tidak berhak aprove")
            ' ''    Response.Redirect("vwskl1.aspx?n=" & (Session("noskl").ToString))

            ' ''ElseIf (Session("status").ToString = "reject HRGA") Then
            ' ''    'Response.Write("proses dept..anda tidak berhak aprove")
            ' ''    Response.Redirect("vwskl1.aspx?n=" & (Session("noskl").ToString))

            ' ''    '' ''---------------popup--------------

            ' ''    '' '' Define the name and type of the client scripts on the page.
            ' ''    ' ''Dim csname1 As String = "PopupScript"
            ' ''    ' ''Dim cstype As Type = Me.GetType()
            ' ''    '' '' Get a ClientScriptManager reference from the Page class.
            ' ''    ' ''Dim cs As ClientScriptManager = Page.ClientScript
            ' ''    '' '' Check to see if the startup script is already registered.
            ' ''    ' ''If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
            ' ''    ' ''    Dim cstext1 As String = "alert('SKL Direject atasan');"
            ' ''    ' ''    cstext1 += "self.close();"
            ' ''    ' ''    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
            ' ''    ' ''End If

            ' ''ElseIf (Session("status").ToString = "Proses HRGA") And ((Session("aprovehr1").ToString = True) Or (Session("aprovehr1").ToString = "1")) And (Session("dept1").ToString = "HRGA") Then
            ' ''    Response.Redirect("aprovehr1.aspx?n=" & (Session("noskl").ToString))

            ' ''ElseIf (Session("status").ToString = "Proses HRGA") And ((Session("aprovehr1").ToString = False) Or (Session("aprovehr1").ToString = "0")) Then
            ' ''    '---------------popup--------------
            ' ''    Response.Write("2")
            ' ''    ' Define the name and type of the client scripts on the page.
            ' ''    Dim csname1 As String = "PopupScript"
            ' ''    Dim cstype As Type = Me.GetType()
            ' ''    ' Get a ClientScriptManager reference from the Page class.
            ' ''    Dim cs As ClientScriptManager = Page.ClientScript
            ' ''    ' Check to see if the startup script is already registered.
            ' ''    If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
            ' ''        Dim cstext1 As String = "alert('SKL Belum divalidasi di HRGA');"
            ' ''        cstext1 += "self.close();"
            ' ''        cs.RegisterStartupScript(cstype, csname1, cstext1, True)
            ' ''    End If


            ' ''End If


            '' ''----------------end redirecting ke form apa--------------



        End If
        con.Close()

        'Response.Redirect("vwskl1.aspx?n=" & (Session("noskl").ToString))

        '----------------redirecting ke form apa--------------


        If (Session("status").ToString = "Proses Dept.") And ((Session("aprove").ToString = True) Or (Session("aprove").ToString = "1")) Then
            'Response.Write("proses dept")
            Response.Redirect("aprovehead.aspx?n=" & (Session("noskl").ToString))
        ElseIf (Session("status").ToString = "Proses Dept.") And ((Session("aprove").ToString = False) Or (Session("aprove").ToString = "0")) Then
            'Response.Write("proses dept..anda tidak berhak aprove")

            '---------------popup--------------

            ' Define the name and type of the client scripts on the page.
            Dim csname1 As String = "PopupScript"
            Dim cstype As Type = Me.GetType()
            ' Get a ClientScriptManager reference from the Page class.
            Dim cs As ClientScriptManager = Page.ClientScript
            ' Check to see if the startup script is already registered.
            If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                Dim cstext1 As String = "alert('SKL Belum diaprove atasan');"
                cstext1 += "self.close();"
                cs.RegisterStartupScript(cstype, csname1, cstext1, True)
            End If
            'ElseIf ((Session("status").ToString = "Complete") Or (Session("status").ToString = "complete")) And ((Session("aprove").ToString = True) Or (Session("aprove").ToString = "1") Or (Session("aprove").ToString = "0") Or (Session("aprove").ToString = False)) Then

        ElseIf ((Session("status").ToString = "Complete") Or (Session("status").ToString = "complete")) Then
            'Response.Write("proses dept..anda tidak berhak aprove")
            Response.Redirect("vwskl1.aspx?n=" & (Session("noskl").ToString))


        ElseIf (Session("status").ToString = "Reject Dept.") Or (Session("status").ToString = "reject Dept.") Then
            'Response.Write("proses dept..anda tidak berhak aprove")
            Response.Redirect("vwskl1.aspx?n=" & (Session("noskl").ToString))

        ElseIf (Session("status").ToString = "Reject HRGA") Or (Session("status").ToString = "reject HRGA") Then
            'Response.Write("proses dept..anda tidak berhak aprove")
            Response.Redirect("vwskl1.aspx?n=" & (Session("noskl").ToString))

            '' ''---------------popup--------------

            '' '' Define the name and type of the client scripts on the page.
            ' ''Dim csname1 As String = "PopupScript"
            ' ''Dim cstype As Type = Me.GetType()
            '' '' Get a ClientScriptManager reference from the Page class.
            ' ''Dim cs As ClientScriptManager = Page.ClientScript
            '' '' Check to see if the startup script is already registered.
            ' ''If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
            ' ''    Dim cstext1 As String = "alert('SKL Direject atasan');"
            ' ''    cstext1 += "self.close();"
            ' ''    cs.RegisterStartupScript(cstype, csname1, cstext1, True)
            ' ''End If

        ElseIf (Session("status").ToString = "Proses HRGA") And ((Session("aprovehr1").ToString = True) Or (Session("aprovehr1").ToString = "1")) And (Session("dept1").ToString = "HRPGA") Then
            Response.Redirect("aprovehr1.aspx?n=" & (Session("noskl").ToString))

        ElseIf (Session("status").ToString = "Proses HRGA") And ((Session("aprovehr1").ToString = False) Or (Session("aprovehr1").ToString = "0")) Then
            '---------------popup--------------
            Response.Write("2")
            ' Define the name and type of the client scripts on the page.
            Dim csname1 As String = "PopupScript"
            Dim cstype As Type = Me.GetType()
            ' Get a ClientScriptManager reference from the Page class.
            Dim cs As ClientScriptManager = Page.ClientScript
            ' Check to see if the startup script is already registered.
            If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then
                Dim cstext1 As String = "alert('SKL Belum divalidasi di HRGA');"
                cstext1 += "self.close();"
                cs.RegisterStartupScript(cstype, csname1, cstext1, True)
            End If


        End If


        '----------------end redirecting ke form apa--------------



    End Function
End Class
