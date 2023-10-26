
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
            If InStr(1, Session("Admin").ToString, "1") > 0 Or InStr(1, Session("ndPosisi").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("ndPosisi").ToString, "DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HCGS SECT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "Project Manager") > 0 Or InStr(1, Session("ndPosisi").ToString, "Dept. Head") > 0 Or InStr(1, Session("jabatan").ToString, "KORLAP") > 0 Or InStr(1, Session("ndPosisi").ToString, "HCGS Sect. Head") > 0 Then

                If InStr(1, Session("Company").ToString, "KPP") = 0 Then
                    If InStr(1, Session("jabatan").ToString, "KORLAP") > 0 Then
                        Me.Menu_Admin_Kpp.Visible = False
                        Me.Menu_User_Kpp.Visible = False
                        Me.Menu_Admin_Mikad.Visible = False 
                        Me.Menu_User_Mikad.Visible = False 
                        Me.Menu_HCGS.Visible = False
                        Me.Menu_Korlap.Visible = True
                        Me.Menu_Payroll.Visible = False
                    Else
                        Me.Menu_Admin_Kpp.Visible = False
                        Me.Menu_User_Kpp.Visible = False
                        Me.Menu_Admin_Mikad.Visible = True 
                        Me.Menu_User_Mikad.Visible = False 
                        Me.Menu_HCGS.Visible = False
                        Me.Menu_Korlap.Visible = False
                        Me.Menu_Payroll.Visible = False
                    End If
                Else
                    Me.Menu_Admin_Kpp.Visible = True 
                    Me.Menu_User_Kpp.Visible = False
                    Me.Menu_Admin_Mikad.Visible = False 
                    Me.Menu_User_Mikad.Visible = False
                    Me.Menu_HCGS.Visible = False
                    Me.Menu_Korlap.Visible = False
                    Me.Menu_Payroll.Visible = False
                End If
            Else
                'Selain admin

                    If InStr(1, Session("Company").ToString, "KPP") = 0 Then
                        Me.Menu_Admin_Kpp.Visible = False
                        Me.Menu_User_Kpp.Visible = False
                        Me.Menu_Admin_Mikad.Visible = False
                        Me.Menu_User_Mikad.Visible = True 
                        Me.Menu_HCGS.Visible = False
                        Me.Menu_Korlap.Visible = False
                        Me.Menu_Payroll.Visible = False
                    Else
                        Me.Menu_Admin_Kpp.Visible = False
                        Me.Menu_User_Kpp.Visible = True
                        Me.Menu_Admin_Mikad.Visible = False
                        Me.Menu_User_Mikad.Visible = False
                        Me.Menu_HCGS.Visible = False
                        Me.Menu_Korlap.Visible = False
                        Me.Menu_Payroll.Visible = False
                    End If
       
            End If 

                'HR & Personnel
                If InStr(1, Session("jabatan").ToString, "Personnel Site Officer") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL SITE OFFICER") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0  Or InStr(1, Session("jabatan").ToString, "Personnel Admin") > 0 Or InStr(1, Session("jabatan").ToString, "Admin Payroll") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Then
                    Me.Menu_Admin_Kpp.Visible = False
                    Me.Menu_User_Kpp.Visible = False
                    Me.Menu_Admin_Mikad.Visible = False
                    Me.Menu_User_Mikad.Visible = False
                    Me.Menu_HCGS.Visible = True
                    Me.Menu_Korlap.Visible = False
                    Me.Menu_Payroll.Visible = False
                End If  

                If InStr(1, Session("jabatan").ToString, "PAYROLL OFFICER") > 0 Or InStr(1, Session("jabatan").ToString, "Payroll Officer") > 0 Then
                    Me.Menu_Admin_Kpp.Visible = False
                    Me.Menu_User_Kpp.Visible = False
                    Me.Menu_Admin_Mikad.Visible = False
                    Me.Menu_User_Mikad.Visible = False
                    Me.Menu_HCGS.Visible = False
                    Me.Menu_Korlap.Visible = False
                    Me.Menu_Payroll.Visible = True
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

