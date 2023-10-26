Partial Class HRGA_MasterTrans2
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userid") <> "" Then
            If InStr(1, Session("jabatan").ToString, "DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRGA SECT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL OFFICER") > 0 Or InStr(1, Session("jabatan").ToString, "RM ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "HAULING ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "PLANT ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "SM ADMIN") > 0 Or InStr(1, Session("jabatan").ToString, "ADMIN SHE") > 0 Then

            Else
                If InStr(1, Session("ndPosisi").ToString, "DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRGA SECT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL") > 0 Or InStr(1, Session("jabatan").ToString, "PAYROLL OFFICER") > 0 Then

                Else
                    Response.Redirect("./")
                End If
            End If
        Else
            Response.Redirect("../")
        End If

        If Session("userid") = "" Then
            Response.Redirect("../")
        End If
    End Sub

End Class

