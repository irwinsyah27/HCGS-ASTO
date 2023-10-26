
Partial Class lstCuti
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./cuti/lstCutils.aspx"
            Response.Redirect("../login.aspx")
        End If

        'If InStr(1, Session("jabatan").ToString, "KORLAP") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL OFFICER") > 0 Then
        If InStr(1, Session("jabatan").ToString, "PAYROLL SITE OFFICER") > 0 Or InStr(1, Session("jabatan").ToString, "KORLAP GNI") > 0 Or InStr(1, Session("jabatan").ToString, "KORLAP SIGAP") > 0 Or InStr(1, Session("jabatan").ToString, "Korlap") > 0 Or InStr(1, Session("jabatan").ToString, "SHE SITE DEPT. HEAD") > 0 Then
            Me.viewdept.Visible = False
            Me.viewls.Visible = True
            Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] UNION SELECT 'ALL DEPT' AS [Departemen]"
            Me.SqlCompany.SelectCommand = "SELECT DISTINCT [company] FROM [tblKaryawan] Where [company] ='" & Session("Company").ToString & "' UNION SELECT '' AS  [company]"
        Else
            Response.Redirect("lstcuti.aspx")
            ' ''Me.viewdept.Visible = True
            ' ''Me.viewls.Visible = False
            '' ''Response.Write("bukan korlap tapi pama")
            '' ''Response.Write("viewdept true mass")
            ' ''If InStr(1, Session("jabatan").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("jabatan").ToString, "HRGA DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRGA SECT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Then
            ' ''    Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] "
            ' ''Else
            ' ''    If InStr(1, Session("ndPosisi").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRGA DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRGA SECT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Then
            ' ''        Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] "
            ' ''    Else
            ' ''        Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] WHERE Departemen ='" & Session("dept").ToString & "' UNION SELECT '' AS  [Departemen] "
            ' ''    End If
            ' ''End If
        End If

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
