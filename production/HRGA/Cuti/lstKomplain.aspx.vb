
Partial Class lstKomplain
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./cuti/lstDinas.aspx"
            Response.Redirect("../login.aspx")
        End If

        Me.ViewKPP.Visible = True

        If InStr(1, Session("jabatan").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "HRPGA DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRPGA SECT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRPGA SECT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL SITE OFFICER") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL OFFICER") > 0 Then
            Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] UNION SELECT 'ALL DEPT' AS [Departemen]"
            ' Me.SqlDatacompany.SelectCommand = "SELECT *, CASE WHEN Tbl.Company='KPP' THEN 0 ELSE 1 END AS URUT FROM(SELECT DISTINCT Company FROM tblKaryawan where Company <>'') AS Tbl ORDER BY URUT "
        Else
            If InStr(1, Session("ndPosisi").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRPGA DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRPGA SECT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL SITE OFFICER") > 0 Or InStr(1, Session("jabatan").ToString, "HRPGA SECT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL OFFICER") > 0 Then
                Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] UNION SELECT 'ALL DEPT' AS [Departemen]"
                ' Me.SqlDatacompany.SelectCommand = "SELECT *, CASE WHEN Tbl.Company='KPP' THEN 0 ELSE 1 END AS URUT FROM(SELECT DISTINCT Company FROM tblKaryawan where Company <>'') AS Tbl ORDER BY URUT "
            Else
                If InStr(1, Session("Admin").ToString, "0") = 0 Then
                    If Session("Jabatan") = "KORLAP MBAP" Or Session("Jabatan") = "KORLAP GNI" Or Session("Jabatan") = "KORLAP SIGAP" Then
                        Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] UNION SELECT 'ALL DEPT' AS [Departemen]"
                        ' Me.SqlDatacompany.SelectCommand = "SELECT * FROM(SELECT DISTINCT Company FROM tblKaryawan WHERE Company ='" & Session("Company").ToString & "' UNION SELECT '' AS  [company]) AS Tbl ORDER BY Company "
                    Else
                        Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] WHERE Departemen ='" & Session("dept").ToString & "' UNION SELECT '' AS  [Departemen] "
                        ' Me.SqlDatacompany.SelectCommand = "SELECT *, CASE WHEN Tbl.Company='KPP' THEN 0 ELSE 1 END AS URUT FROM(SELECT DISTINCT Company FROM tblKaryawan where Company <>'') AS Tbl ORDER BY URUT "
                    End If
                Else
                    Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] WHERE Departemen ='" & Session("dept").ToString & "' UNION SELECT '' AS  [Departemen] "
                    ' Me.SqlDatacompany.SelectCommand = "SELECT DISTINCT [company] FROM [tblKaryawan] WHERE Company ='" & Session("Company").ToString & "' UNION SELECT '' AS  [company] "
                End If
            End If
        End If
        'If InStr(1, Session("jabatan").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("jabatan").ToString, "HRGA DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRGA SECT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Then
        '    Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] "
        'Else
        '    If InStr(1, Session("ndPosisi").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRGA DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRGA SECT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Then
        '        Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] "
        '    Else
        '        Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] WHERE Departemen ='" & Session("dept").ToString & "' UNION SELECT '' AS  [Departemen] "
        '    End If
        'End If
        
    End Sub
End Class
