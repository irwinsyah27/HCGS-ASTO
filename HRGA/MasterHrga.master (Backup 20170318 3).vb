
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If Session("userid") = "" Then
            Response.Redirect("../")
        End If
        If Session("userid") <> "" Then
            Login.Text = "| .:: Logout ::. |"
            User.Text = "| User : " & Session("userid").ToString & "|"
            Nama.Text = "|" & Session("UserName").ToString & "|"
            Akses.Text = "|" & Session("Akses").ToString
            Login.PostBackUrl = "../Logout.aspx"
            If InStr(1, Session("jabatan").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("jabatan").ToString, "DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("ndPosisi").ToString, "DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "SECT. HEAD") > 0 Then
                Me.Menu1.Visible = True
                Me.Menu2.Visible = False
                Me.Menu3.Visible = False
                Me.menu5.visible = False
                Me.menu6.visible = False
                Me.menu7.visible = False
                Me.Menu8.visible = False
            Else
                'HR & Personnel & HRGA Admin ---
                If InStr(1, Session("jabatan").ToString, "HRP & GA SECTION HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL OFFICER") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRP & GA SECTION HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "PAYROLL OFFICER") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRGA ADMINISTRATOR") > 0 Or InStr(1, Session("jabatan").ToString, "HRGA ADMINISTRATOR") > 0 Or InStr(1, Session("jabatan").ToString, "HR Officer") > 0 Then
                    Me.Menu1.Visible = False
                    Me.Menu2.Visible = False
                    Me.Menu3.Visible = True
                    Me.Menu5.Visible = False
                    Me.Menu6.Visible = False
                    Me.Menu7.Visible = False
                    Me.Menu8.Visible = False
                Else
                    'Adm Dept selain HR & Personel
                    If InStr(1, Session("Akses").ToString, "Admin") > 0 Then
                        Me.Menu1.Visible = False
                        Me.Menu2.Visible = False
                        Me.Menu3.Visible = False
                        Me.Menu5.Visible = False
                        Me.Menu6.Visible = True
                        Me.Menu7.Visible = False
                        Me.Menu8.Visible = False
                    ElseIf InStr(1, Session("userid").ToString, "kb10098") > 0 Or InStr(1, Session("userid").ToString, "ka10001") > 0 Then
                        Me.Menu1.Visible = False
                        Me.Menu2.Visible = False
                        Me.Menu3.Visible = False
                        Me.Menu5.Visible = False
                        Me.Menu6.Visible = False
                        Me.Menu7.Visible = False
                        Me.Menu8.Visible = False
                        Me.Menu4.Visible = False
                    Else
                        Me.Menu1.Visible = False
                        Me.Menu2.Visible = False
                        Me.Menu3.Visible = False
                        Me.Menu5.Visible = False
                        Me.Menu6.Visible = False
                        Me.Menu7.Visible = True
                        Me.Menu8.Visible = False

                    End If

                    If InStr(1, Session("jabatan").ToString, "HRP & GA SECTION HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL OFFICER") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRP & GA SECTION HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "PAYROLL OFFICER") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRP & GA ADMINISTRATOR") > 0 Or InStr(1, Session("jabatan").ToString, "HRP & GA ADMINISTRATOR") > 0 Then
                        Me.Menu1.Visible = False
                        Me.Menu2.Visible = False
                        Me.Menu3.Visible = True
                        Me.Menu5.Visible = False
                        Me.Menu6.Visible = False
                        Me.Menu7.Visible = False
                        Me.Menu8.Visible = False
                    End If
                    If InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Then
                        Me.Menu1.Visible = False
                        Me.Menu2.Visible = False
                        Me.Menu3.Visible = False
                        Me.Menu5.Visible = False
                        Me.Menu6.Visible = False
                        Me.Menu7.Visible = False
                        Me.Menu8.Visible = True
                    End If
                End If
            End If

        Else
            Response.Redirect("../")
            Login.Visible = False
            User.Visible = False
            Nama.Visible = False
            Login.PostBackUrl = "../"
        End If

        If Session("userid") = "" Then
            Response.Redirect("../")
        End If
    End Sub

End Class

