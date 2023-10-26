
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

	If  Session.Timeout = 0 Then
            Response.Redirect("../login.aspx")
        End If

        'Session("userid") = "6103041"
        'Session("username") = "Mas Mai..Suk...Ri..."
        'Session("jabatan") = "PERSONNEL ADMIN"
        'Session("DEPT") = "HRPGA"

        If Session("userid") = "" Then
            Response.Redirect("../")
        End If
        If Session("userid") <> "" Then
            Login.Text = "| .:: Logout ::. |"
            User.Text = "| User : " & Session("userid").ToString & "|"
            Nama.Text = "|" & Session("UserName").ToString
            Login.PostBackUrl = "../Logout.aspx"
            If InStr(1, Session("Admin").ToString, "1") > 0 Or InStr(1, Session("ndPosisi").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("ndPosisi").ToString, "DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRPGA SECT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "Project Manager") > 0 Or InStr(1, Session("ndPosisi").ToString, "Dept. Head") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRPGA Sect. Head") > 0 Then
                If InStr(1, Session("Company").ToString, "KPP") = 0 Then
                    Me.Menu1.Visible = False
                    Me.Menu2.Visible = False
                    Me.Menu3.Visible = False
                    Me.Menu4.Visible = True
                    Me.Menu5.Visible = False
                    Me.MenuPlant.Visible = False
                Else
                    Me.Menu1.Visible = True
                    Me.Menu2.Visible = False
                    Me.Menu3.Visible = False
                    Me.Menu4.Visible = False
                    Me.Menu5.Visible = False
                    Me.MenuPlant.Visible = False
                End If
            Else
                'Admin All Dept
                If InStr(1, Session("Dept").ToString, "PLANT") > 1 Then
                    Me.Menu1.Visible = False
                    Me.Menu2.Visible = False
                    Me.Menu3.Visible = False
                    Me.Menu4.Visible = False
                    Me.Menu5.Visible = False
                    Me.MenuPlant.Visible = True
                Else
                    If InStr(1, Session("Company").ToString, "KPP") = 0 Then
                        Me.Menu1.Visible = False
                        Me.Menu2.Visible = False
                        Me.Menu3.Visible = False
                        Me.Menu4.Visible = False
                        Me.Menu5.Visible = True
                        Me.MenuPlant.Visible = False
                    Else
                        Me.Menu1.Visible = False
                        Me.Menu2.Visible = True
                        Me.Menu3.Visible = False
                        Me.Menu4.Visible = False
                        Me.Menu5.Visible = False
                        Me.MenuPlant.Visible = False
                    End If
                End If
            End If

                'HR & Personnel
                If InStr(1, Session("jabatan").ToString, "PERSONNEL SITE OFFICER") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL OFFICER") > 0 Or InStr(1, Session("jabatan").ToString, "Personnel Admin") > 0 Or InStr(1, Session("jabatan").ToString, "Payroll Officer") > 0 Or InStr(1, Session("jabatan").ToString, "Admin Payroll") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Then
                    Me.Menu1.Visible = False
                    Me.Menu2.Visible = False
                    Me.Menu3.Visible = True
                    Me.Menu4.Visible = False
                    Me.Menu5.Visible = False
                    Me.MenuPlant.Visible = False
                End If
            Else
                Response.Redirect("../")
                Login.Visible = False
                User.Visible = False
                Nama.Visible = False
                Login.PostBackUrl = "../"
            End If

        'Session("userid") = "6102003"
        'Session("UserName") = "Freddy Eko"
        'Session("jabatan") = "IT SECTION HEAD"
        'Session("dept") = "HRGA"

        'Session("userid") = "6104018"
        'Session("UserName") = "Yayan Rudianto"
        'Session("jabatan") = "HRGA DEPT. HEAD"
        'Session("dept") = "HRGA"

        'Session("userid") = "6105318"
        'Session("UserName") = "YUZE ROLIX"
        'Session("jabatan") = "HRGA SECT. HEAD"
        'Session("dept") = "HRGA"

        'Session("userid") = "0192069"
        'Session("UserName") = "AGUS DWI WIDIYANTO"
        'Session("jabatan") = "PROJECT MANAGER"
        'Session("dept") = "OPR"

        'Session("userid") = "1F96185"
        'Session("UserName") = "FITRIYANTO"
        'Session("jabatan") = "PERSONNEL ADMIN."
        'Session("dept") = "HRGA"

        If Session("userid") = "" Then
            Response.Redirect("../")
        End If
    End Sub

    Protected Sub Menu2_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu2.MenuItemClick

    End Sub

    Protected Sub Menu3_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu3.MenuItemClick

    End Sub
End Class

