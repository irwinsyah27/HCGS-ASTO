Imports System.Data
Imports System.Data.SqlClient
Partial Class HRGA_Trans_Upload
    Inherits System.Web.UI.Page
    Dim nomer As String
    Dim sPath As String
    Dim sFile As String
    Dim sFullPath As String
    Dim sSplit() As String
    Dim sPathFriendly As String
    Dim FileSize As Integer
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        sPath = Server.MapPath(".")
        If Right(sPath, 1) <> "\" Then
            sPathFriendly = sPath 'Friendly path name for display
            sPath = sPath & "\Upload\"
        Else
            sPathFriendly = Left(sPath, Len(sPath) - 1)
        End If

        sFile = txtUpload.PostedFile.FileName
        sSplit = Split(sFile, "\")
        sFile = sSplit(UBound(sSplit))

        sFullPath = sPath & sFile

        uploadAttachment()

    End Sub

    Sub uploadAttachment()
        Try
            FileSize = txtUpload.PostedFile.ContentLength.ToString
            FileSize = FileSize / 1000
            If FileSize < 600 Then
                txtUpload.PostedFile.SaveAs(sFullPath)
                'lblResults.Text = "Upload of File " & sFile & " to " & sPathFriendly & " succeeded"
                Pilah()
                Response.Redirect("Titipan.aspx")
            Else
                lblResults.Text = "File " & FileSize & "mb tidak diijinkan, gunakan file yang lebih kecil..."
            End If
        Catch Ex As Exception

            lblResults.Text = "Upload of File " & sFile & " to " & sPathFriendly & " failed for the following reason: " & Ex.Message
        Finally
            lblResults.Font.Bold = True
            lblResults.Visible = True
        End Try
    End Sub

    Sub Pilah()
        Dim Nrp As String = ""
        Dim Nilai As String = ""
        Using MyReader As New _
       Microsoft.VisualBasic.FileIO.TextFieldParser(sFullPath)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentRow As String()
            Dim row As Integer = 0
            Dim col As Integer = 0

            While Not MyReader.EndOfData
                Try
                    col = 0
                    currentRow = MyReader.ReadFields()
                    Dim currentField As String
                    For Each currentField In currentRow
                        Select Case col
                            Case 0 : Nrp = currentField
                            Case 1 : Nilai = currentField
                        End Select
                        col += 1
                    Next

                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                End Try
                If row <> 0 Then
                    Simpan(Nrp, Nilai)
                End If
                row += 1
            End While
        End Using

    End Sub

    Function Simpan(ByVal _Nrp, ByVal _Nilai) As String
        Dim con As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing

        cmd = New SqlClient.SqlCommand

        Dim connectionStrings As ConnectionStringSettingsCollection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
        con = New SqlClient.SqlConnection(connectionStrings("persisConnectionString").ConnectionString)

        con.Open()
        With cmd
            .Connection = con
            .CommandType = CommandType.Text
            .CommandText = "Insert Into tblTransaksi" _
                            & "([Nrp]" _
                            & ",[Nilai]" _
                            & ",[Kode]" _
                            & ",[Tgl]" _
                            & ",[UploadOleh]" _
                    & ") values (" _
                            & "@Nrp" _
                            & ",@Nilai" _
                            & ",'G'" _
                            & ",Getdate()" _
                            & ",@UploadOleh" _
                            & ")"

            .Parameters.Add("@Nrp", SqlDbType.NVarChar, 10)
            .Parameters.Add("@Nilai", SqlDbType.NVarChar, 30)
            .Parameters.Add("@UploadOleh", SqlDbType.NVarChar, 10)

            .Parameters("@Nrp").Value = _Nrp
            .Parameters("@Nilai").Value = _Nilai
            .Parameters("@UploadOleh").Value = Session("userid").ToString

            .ExecuteNonQuery()
        End With

        Return _Nrp
    End Function
End Class
