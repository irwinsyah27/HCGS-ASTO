Imports System.Data
Imports System.Data.SqlClient
Partial Class Absensi
    Inherits System.Web.UI.Page
    Dim dept As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Dept") = "" Then
            Session("Q") = "skl/absensi1.aspx"
            Response.Redirect("../login.aspx")
        Else
            'Me.lbldept.Text = Request.QueryString("dept").ToString
            'If Session("tgl") = "" Then
            '    session("tgl")= Format((), "MM/dd/yyyy").ToString
            'End If
            If Session("Dept") = "HRGA" Then
                cekakses()
            Else
                'Me.Label1.Text = Session("dept")
                Session("DEPT1") = Session("DEPT")
            End If

        End If
    End Sub

    Protected Sub txttgl_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttgl.TextChanged
        Me.Label1.Visible = False

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Label1.Visible = False
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
                'Response.Write("TRUE")

                Me.DropDownList1.Visible = True
                Me.Label1.Visible = False
            Else
                'Response.Write("palse")
                'Me.Label1.Text = Session("dept")
                Session("DEPT1") = Session("DEPT")

            End If
        End If
        con.Close()
    End Function

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Session("DEPT1") = Me.DropDownList1.Text
        'Me.Label1.Text = Me.DropDownList1.Text
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Calendar1.Visible = True

    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        Session("tgl") = Format((Me.Calendar1.SelectedDate), "MM/dd/yyyy").ToString
        'Me.txttgl.Text = Format((Me.Calendar1.SelectedDate), "MM/dd/yyyy").ToString
        'Me.Label2.Text = Format((Me.Calendar1.SelectedDate), "MM/dd/yyyy").ToString

        'Me.txttglawal.Text = Format((Me.calawallbr.SelectedDate), "dd/MM/yyyy").ToString
        Me.Calendar1.Visible = False
    End Sub
End Class
