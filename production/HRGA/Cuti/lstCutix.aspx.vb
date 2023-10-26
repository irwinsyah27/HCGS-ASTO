
Partial Class lstCuti
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") = "" Then
            Session("Q") = "./cuti/lstCuti.aspx"
            Response.Redirect("../login.aspx")
        End If


        'If InStr(1, Session("jabatan").ToString, "KORLAP") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL OFFICER") > 0 Then
        If InStr(1, Session("jabatan").ToString, "KORLAP") > 0 Then
            Response.Redirect("LSTCUTILS.ASPX")
            ' ''Me.DropDownList1.Visible = False
            ' ''Me.DropDownList2.Visible = False
            ' ''Me.DropDownList3.Visible = True
            ' ''Me.Label1.Visible = False
            ' ''Me.Label3.Visible = False
            ' ''Me.Label4.Visible = True
            ' ''Me.SqlDataSource3.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] WHERE Departemen ='" & Session("dept").ToString & "' UNION SELECT '' AS  [Departemen] "

            ' ''Me.viewkorlap.Visible = True
            ' ''Me.viewls.Visible = False
            ' ''Me.viewpama.Visible = False

            ' ''Response.Write("korlap...viewkorlap..tru...ddl3..true")
        Else
            Me.DropDownList1.Visible = True
            'Me.DropDownList2.Visible = True
            'Me.DropDownList3.Visible = False
            Me.Label1.Visible = True
            'Me.Label3.Visible = True
            'Me.Label4.Visible = False
            Me.viewkorlap.Visible = False
            If InStr(1, Session("jabatan").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("jabatan").ToString, "HRGA DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRGA SECT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Then
                Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] "
                Me.SqlDatacompany.SelectCommand = "SELECT DISTINCT [company] FROM [tblKaryawan] UNION SELECT '' AS  [company] "
            Else
                If InStr(1, Session("ndPosisi").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRGA DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRGA SECT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Then
                    Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] "
                    Me.SqlDatacompany.SelectCommand = "SELECT DISTINCT [company] FROM [tblKaryawan] UNION SELECT '' AS  [company] "

                Else
                    Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] WHERE Departemen ='" & Session("dept").ToString & "' UNION SELECT '' AS  [Departemen] "
                    Me.SqlDatacompany.SelectCommand = "SELECT DISTINCT [company] FROM [tblKaryawan] UNION SELECT '' AS  [company] "

                End If
            End If
            If Me.DropDownList2.Text = "PAMA" Then
                Me.viewpama.Visible = True
                Me.viewls.Visible = False
            ElseIf (Me.DropDownList2.Text = "BTP") Or (Me.DropDownList2.Text = "BSU") Or (Me.DropDownList2.Text = "RRM") Then
                Me.viewpama.Visible = False
                Me.viewls.Visible = True
            Else
                Me.viewpama.Visible = True
                Me.viewls.Visible = False
            End If
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
