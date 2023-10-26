
Partial Class lstDinas1
    Inherits System.Web.UI.Page
    Protected Sub GridView1_RowCreated1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If Session("userid") = "" Then
            Session("Q") = "./cuti/lstDinas1.aspx"
            Response.Redirect("../login.aspx")
        End If

        If InStr(1, Session("jabatan").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("jabatan").ToString, "HRGA DEPT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "HRGA SECT. HEAD") > 0 Or InStr(1, Session("jabatan").ToString, "PERSONNEL ADMIN") > 0 Then
            Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] "
        Else
            If InStr(1, Session("ndPosisi").ToString, "PROJECT MANAGER") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRGA DEPT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "HRGA SECT. HEAD") > 0 Or InStr(1, Session("ndPosisi").ToString, "PERSONNEL ADMIN") > 0 Then
                Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] "
            Else
                Me.SqlDataDept.SelectCommand = "SELECT DISTINCT [Departemen] FROM [tblKaryawan] WHERE Departemen ='" & Session("dept").ToString & "' UNION SELECT '' AS  [Departemen] "
            End If
        End If

        'MsgBox("Test " & DataBinder.Eval(e.Row.DataItem, "dept"))
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lbl As Label = CType(e.Row.FindControl("Label1"), Label)
            If Trim(DataBinder.Eval(e.Row.DataItem, "Tempo")) = "1" Or Trim(DataBinder.Eval(e.Row.DataItem, "Tempo")) = "0" Or Trim(DataBinder.Eval(e.Row.DataItem, "Tempo")) = "2" Then
                lbl.ForeColor = Drawing.Color.Red
                e.Row.Cells(5).BackColor = Drawing.Color.LightCoral
                e.Row.BackColor = Drawing.Color.LemonChiffon
            End If

        End If
    End Sub
End Class
