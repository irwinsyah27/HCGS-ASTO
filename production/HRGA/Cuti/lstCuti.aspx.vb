
Partial Class lstCuti
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./cuti/lstCuti.aspx"
            Response.Redirect("../login.aspx")
        End If

        'If InStr(1, Session("jabatan").ToString, "KORLAP MBAP") > 0 Or InStr(1, Session("jabatan").ToString, "KORLAP GARUDA") > 0 Or InStr(1, Session("jabatan").ToString, "KORLAP SIGAP") > 0 Or InStr(1, Session("jabatan").ToString, "KORLAP") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL OFFICER") > 0 Then
        
        Me.DropDownList1.Visible = True
        'Me.DropDownList2.Visible = True
        Me.DropDownList3.Visible = True
        Me.Label1.Visible = True
        'Me.Label3.Visible = True
        Me.Label4.Visible = True
        Me.viewkorlap.Visible = False



        If InStr(1, Session("jabatan").ToString, "ICT OFFICER") > 0 Or InStr(1, Session("jabatan").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "HRPGA DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRPGA SECT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL SITE OFFICER") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL OFFICER") > 0 Or InStr(1, Session("jabatan").ToString, "HRPGA SECT. HEAD") > 0 Then
            Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] UNION SELECT 'ALL DEPT' AS [Departemen]"
            Me.SqlDatacompany.SelectCommand = "SELECT *, CASE WHEN Tbl.Company='KPP' THEN 1 ELSE 2 END AS URUT FROM(SELECT DISTINCT Company FROM tblKaryawan where Company <>'') AS Tbl UNION SELECT '' AS Company , 0 as URUT ORDER BY URUT"
        Else If InStr(1, Session("jabatan").ToString, "KORLAP") > 0 Then
            Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] UNION SELECT 'ALL DEPT' AS [Departemen]"
            Me.SqlDatacompany.SelectCommand = "SELECT * FROM(SELECT DISTINCT Company FROM tblKaryawan WHERE Company ='" & Session("Company").ToString & "' UNION SELECT '' AS  [company]) AS Tbl ORDER BY Company "
       ' Else If InStr(1, Session("dept").ToString, "RM") > 0 Or InStr(1, Session("dept").ToString, "HAUL")
           ' Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] WHERE DEPARTEMEN IN ('HAULING','RM')"
            'Me.SqlDatacompany.SelectCommand = "SELECT * FROM(SELECT DISTINCT Company FROM tblKaryawan WHERE Company ='" & Session("Company").ToString & "' UNION SELECT '' AS  [company]) AS Tbl ORDER BY Company "
        Else
            If InStr(1, Session("ndPosisi").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRPGA DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRPGA SECT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL SITE OFFICER") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRPGA SECT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "PAYROLL OFFICER") > 0 Then
                Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] UNION SELECT 'ALL DEPT' AS [Departemen]"
                Me.SqlDatacompany.SelectCommand = "SELECT *, CASE WHEN Tbl.Company='KPP' THEN 1 ELSE 2 END AS URUT FROM(SELECT DISTINCT Company FROM tblKaryawan where Company <>'') AS Tbl UNION SELECT '' AS Company , 0 as URUT ORDER BY URUT"
            Else
                If InStr(1, Session("Admin").ToString, "0") = 0 Then
                    If Session("Jabatan") = "KORLAP MBAP" Or Session("Jabatan") = "KORLAP GNI" Or Session("Jabatan") = "KORLAP SIGAP" Then
                        Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] UNION SELECT 'ALL DEPT' AS [Departemen]"
                        Me.SqlDatacompany.SelectCommand = "SELECT * FROM(SELECT DISTINCT Company FROM tblKaryawan WHERE Company ='" & Session("Company").ToString & "' UNION SELECT '' AS  [company]) AS Tbl ORDER BY Company "
                    Else
                        Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] WHERE Departemen ='" & Session("dept").ToString & "' UNION SELECT '' AS  [Departemen] "
                        Me.SqlDatacompany.SelectCommand = "SELECT *, CASE WHEN Tbl.Company='KPP' THEN 1 ELSE 2 END AS URUT FROM(SELECT DISTINCT Company FROM tblKaryawan where Company <>'') AS Tbl UNION SELECT '' AS Company , 0 as URUT ORDER BY URUT"
                    End If
                Else
                    Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] WHERE Departemen ='" & Session("dept").ToString & "' UNION SELECT '' AS  [Departemen] "
                    Me.SqlDatacompany.SelectCommand = "SELECT *, CASE WHEN Tbl.Company='KPP' THEN 1 ELSE 2 END AS URUT FROM(SELECT DISTINCT Company FROM tblKaryawan where Company <>'') AS Tbl UNION SELECT '' AS Company , 0 as URUT ORDER BY URUT"
                End If
            End If
        End If

        If Me.DropDownList3.Text = "KPP" Then
            Me.viewpama.Visible = True
            Me.viewls.Visible = False
        Else
            Me.viewpama.Visible = False
            Me.viewls.Visible = True
        End If


        ' '' '' ''If InStr(1, Session("jabatan").ToString, "KORLAP") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL OFFICER") > 0 Then
        '' '' ''If InStr(1, Session("jabatan").ToString, "KORLAP") > 0 Then
        '' '' ''    Response.Redirect("LSTCUTILS.ASPX")
        '' '' ''Else
        '' '' ''    If InStr(1, Session("jabatan").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("jabatan").ToString, "HRGA DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRGA SECT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Then
        '' '' ''        Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] "
        '' '' ''    Else
        '' '' ''        If InStr(1, Session("ndPosisi").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRGA DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRGA SECT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Then
        '' '' ''            Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] "
        '' '' ''        Else
        '' '' ''            Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] WHERE Departemen ='" & Session("dept").ToString & "' UNION SELECT '' AS  [Departemen] "
        '' '' ''        End If
        '' '' ''    End If
        '' '' ''End If

        ''        -------------AWAL-----------
        ''        If InStr(1, Session("jabatan").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("jabatan").ToString, "HRGA DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRGA SECT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Then
        ''            Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] "
        ''        Else
        ''            If InStr(1, Session("ndPosisi").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRGA DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRGA SECT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Then
        ''                Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] "
        ''            Else
        ''                Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] WHERE Departemen ='" & Session("dept").ToString & "' UNION SELECT '' AS  [Departemen] "
        ''            End If
        ''        End If
        ''-END OF AWAL-------------
    End Sub
End Class
