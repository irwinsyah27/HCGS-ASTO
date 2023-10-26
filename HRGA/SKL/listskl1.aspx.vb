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
        If Session("Dept") = "HCGS" Then
            cekakses()
        Else
            Me.Label1.Text = Session("Dept")
        End If

        If InStr(1, Session("jabatan").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "HCGS & FAT DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HCGS SECT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL SITE OFFICER") > 0 Or InStr(1, Session("jabatan").ToString, "HCGS SECT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "FAT SECT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL SITE OFFICER") > 0  Then
            Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] UNION SELECT 'ALL DEPT' AS [Departemen]"
            Me.SqlDatacompany.SelectCommand = "SELECT *, CASE WHEN Tbl.Company='KPP' THEN 0 ELSE 1 END AS URUT FROM(SELECT DISTINCT Company FROM tblKaryawan where Company <>'') AS Tbl ORDER BY URUT "
            Else If InStr(1, Session("jabatan").ToString, "HRM & ENGINEERING DEPT. HEAD") > 0 Then
                Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] WHERE DEPARTEMEN IN ('HAULING','RM','ENG')"
                Me.SqlDatacompany.SelectCommand = "SELECT *, CASE WHEN Tbl.Company='KPP' THEN 1 ELSE 2 END AS URUT FROM(SELECT DISTINCT Company FROM tblKaryawan where Company <>'') AS Tbl UNION SELECT '' AS Company , 0 as URUT ORDER BY URUT"
            Else If InStr(1, Session("jabatan").ToString, "SM SITE SECT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "SM SITE SECT. HEAD") > 0 Then
                Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] WHERE DEPARTEMEN IN ('SM')"
                Me.SqlDatacompany.SelectCommand = "SELECT *, CASE WHEN Tbl.Company='KPP' THEN 1 ELSE 2 END AS URUT FROM(SELECT DISTINCT Company FROM tblKaryawan where Company <>'') AS Tbl UNION SELECT '' AS Company , 0 as URUT ORDER BY URUT"
            Else If InStr(1, Session("jabatan").ToString, "SHE DEPT. HEAD") > 0 Then
                Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] WHERE DEPARTEMEN IN ('SHE')"
                Me.SqlDatacompany.SelectCommand = "SELECT *, CASE WHEN Tbl.Company=('KPP','AEA') THEN 1 ELSE 2 END AS URUT FROM(SELECT DISTINCT Company FROM tblKaryawan where Company <>'') AS Tbl UNION SELECT '' AS Company , 0 as URUT ORDER BY URUT"
        Else
            If InStr(1, Session("ndPosisi").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("ndPosisi").ToString, "HCGS & FAT DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HCGS SECT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL SITE OFFICER") > 0 Or InStr(1, Session("ndPosisi").ToString, "HCGS SECT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "PAYROLL SITE OFFICER") > 0 Or InStr(1, Session("ndPosisi").ToString, "FAT SECT. HEAD") > 0 Then
                Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] UNION SELECT 'ALL DEPT' AS [Departemen]"
                Me.SqlDatacompany.SelectCommand = "SELECT *, CASE WHEN Tbl.Company='KPP' THEN 0 ELSE 1 END AS URUT FROM(SELECT DISTINCT Company FROM tblKaryawan where Company <>'') AS Tbl ORDER BY URUT "
            Else
                If InStr(1, Session("Admin").ToString, "0") = 0 Then
                    If Session("Jabatan") = "KORLAP DAB" Or Session("Jabatan") = "KORLAP GNI" Or Session("Jabatan") = "KORLAP SIGAP" Or Session("Jabatan") = "PERSONNEL ADMIN" Then
                        Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] UNION SELECT 'ALL DEPT' AS [Departemen]"
                        Me.SqlDatacompany.SelectCommand = "SELECT * FROM(SELECT DISTINCT Company FROM tblKaryawan WHERE Company ='" & Session("Company").ToString & "' UNION SELECT '' AS  [company]) AS Tbl ORDER BY Company "
                    Else
                        Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] WHERE Departemen ='" & Session("dept").ToString & "' UNION SELECT '' AS  [Departemen] "
                        Me.SqlDatacompany.SelectCommand = "SELECT *, CASE WHEN Tbl.Company='KPP' THEN 0 ELSE 1 END AS URUT FROM(SELECT DISTINCT Company FROM tblKaryawan where Company <>'') AS Tbl ORDER BY URUT "
                    End If
                Else
                    Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] UNION SELECT 'ALL DEPT' AS [Departemen]"
                    Me.SqlDatacompany.SelectCommand = "SELECT *, CASE WHEN Tbl.Company='KPP' THEN 0 ELSE 1 END AS URUT FROM(SELECT DISTINCT Company FROM tblKaryawan where Company <>'') AS Tbl ORDER BY URUT "
                End If
            End If
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
