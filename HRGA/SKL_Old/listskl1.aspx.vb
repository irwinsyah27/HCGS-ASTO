Imports System.Data
Imports System.Data.SqlClient


Partial Class listskl1
    Inherits System.Web.UI.Page
    Dim dept As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Dept") = "" Then
            'MsgBox("iii")
            Session("Q") = "skl/listskl1.aspx"
            Response.Redirect("../login.aspx")
        Else
        End If
        If Session("Dept") = "HRPGA" Then
            cekakses()
        Else
            Me.Label1.Text = Session("dept")
        End If


        'MsgBox(Session("DEPT"))

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        'Session("Q") = "vwskl.aspx?n=" & Me.GridView1.SelectedRow.Cells(1).Text
        ''MsgBox(Session("Q"))
        'Response.Redirect(Session("Q"))
    End Sub
    Function cekakses()
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand
        dept = Session("dept")


        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("Data_abs1ConnectionString").ConnectionString)

        Dim dr As SqlDataReader

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            '.CommandText = "select nrp, nama, dept, aprove from karyawan where nrp='" & Session("userid").ToString & "'"
            .CommandText = "select nrp, aprovehr from karyawan where nrp='" & Session("userid") & "'"
            dr = .ExecuteReader

        End With
        If dr.Read Then
            'MsgBox(dr.Item(1).ToString)
            'MsgBox(dr.Item(2).ToString)
            'MsgBox(dr.Item(3).ToString)
            Session("aprovehr2") = dr.Item(1).ToString
            'If dr.Item(1).ToString = True Then
            If (Session("aprovehr2").ToString = True) Or (Session("aprovehr2").ToString = "1") Then
                Me.DropDownList1.Visible = True
                Me.DropDownList3.Visible = True
                Me.Label4.Visible = True
                Me.Label1.Visible = False
            Else
                'Response.Write("palse")
                Me.Label1.Text = Session("dept")
                Me.Label2.Visible = False

            End If
        End If
        con.Close()
    End Function

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Me.Label1.Text = Me.DropDownList1.Text
    End Sub
End Class
