Imports System.Data
Imports System.Data.SqlClient
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Redirect("http://pama-adro/hrga/")


        '       If Session("userid") = "" Then
        '           Response.Redirect("http://pama-adro/")
        '       End If

        ''Session("userid") = Request.Cookies("userid").Value
        '       'Session("userid") = Mid(Session("userid").ToString, 2, Len(Session("userid").ToString))

        '       Dim con As SqlClient.SqlConnection = Nothing
        '       Dim cmd As SqlClient.SqlCommand = Nothing
        '       Dim dr As SqlDataReader

        '       cmd = New SqlClient.SqlCommand

        '       Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        '       con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        '       con.Open()
        '       With cmd
        '           .Connection = con
        '           .CommandType = CommandType.Text
        '           .CommandText = "Select * From tblKaryawan WHERE Nrp = @Nrp "
        '           .Parameters.Add("@Nrp", SqlDbType.VarChar, 19)
        '           .Parameters("@Nrp").Value = Session("userid").ToString
        '           '.Parameters("@Nrp").Value = Mid(Session("userid").ToString, 2, Len(Session("userid").ToString))

        '           dr = .ExecuteReader
        '       End With
        '       If dr.Read = True Then
        '           Session("UserName") = dr.Item("Nama").ToString
        '           Session("jabatan") = dr.Item("jabatan").ToString
        '           Session("dept") = dr.Item("Departemen").ToString
        '           'Response.Write(dr.Item("jabatan").ToString)
        '       End If
        '       Posisi()
    End Sub
    Sub Posisi()
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
            .CommandText = "Select * From tblndPosisi WHERE Nrp = @Nrp "
            .Parameters.Add("@Nrp", SqlDbType.VarChar, 19)
            .Parameters("@Nrp").Value = Session("userid").ToString
            '.Parameters("@Nrp").Value = Mid(Session("userid").ToString, 2, Len(Session("userid").ToString))

            dr = .ExecuteReader
        End With
        Dim Posisi As String = ""
        Do While dr.Read = True
            Posisi &= "," & dr.Item("ndPosisi").ToString
        Loop
        Session("ndPosisi") = Posisi
        'Response.Write("1" & Session("ndPosisi").ToString)
    End Sub

End Class
