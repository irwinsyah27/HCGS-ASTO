Imports System
Imports System.Collections
Imports System.Security.Principal
Imports System.DirectoryServices
Imports System.Web
Imports System.Web.Security
Imports System.Text

Namespace Backlog


Public Class Validate
    Private domainData As String = ""
    Private setValue As String = ""

    Public Property ldapDomain()
        Get
            ldapDomain = setValue
        End Get
        Set(ByVal Value)
            Try
                Dim a() As String
                Dim i As Integer
                setValue = Value
                a = Split(Value, ".")
                'domainData = "LDAP://" & Value & ":389/DC=" & a(LBound(a))
                ' For i = LBound(a) + 1 To UBound(a)
                'domainData = domainData & ",DC=" & a(i)
                'Next
                domainData = "LDAP://" & Value & ":389"
            Catch ex As Exception
                Throw New System.Exception("Invalid domain data for ldapDomain: " & ex.Message)
            End Try
        End Set
    End Property

    Public Function checkPassword(ByVal SamAccount As String, ByVal password As String, ByRef errMsg As String) As Boolean
        Try
            If domainData = "" Then
                errMsg = "ldap Domain tidak di set"
                Return False
            End If
            Dim sPath As String = domainData
            Dim objUser As DirectoryEntry
            ' Connect using the supplied credentials
            ' Ligar com as credenciais fornecidas
            Dim myDirectory As New DirectoryEntry(sPath, SamAccount, password)
            Dim mySearcher As New DirectorySearcher(myDirectory)
            Dim mySearchResult As SearchResult
            Dim myResultPropColl As ResultPropertyCollection
            Dim myResultPropValueColl As ResultPropertyValueCollection
            mySearcher.Filter = ("(&(objectClass=user)(samaccountname=" & SamAccount & "))")
            ' Following code will raise an error if credentials are wrong
            ' A próxima operação irá gerar um erro se as credenciais estiverem incorrectas
            mySearcher.PropertiesToLoad.Add("cn")
            mySearchResult = mySearcher.FindOne()
            objUser = mySearchResult.GetDirectoryEntry()
            myResultPropColl = mySearchResult.Properties


        Catch ex As System.Exception
            errMsg = ex.Message

            Return False
        End Try

        'Get the Properites, they contain the usefull info 

        Return True
    End Function

    Public Function changePassword(ByVal SamAccount As String, _
                                ByVal oldPassword As String, _
                                ByVal newPassword As String, _
                                ByVal adminLogon As String, _
                                ByVal adminPassword As String, _
                                ByRef errMsg As String) As Boolean
        Try
            If domainData = "" Then
                errMsg = "ldap Domain tidak di set"
                Return False
            End If
            Dim sPath As String = domainData
            Dim objUser As DirectoryEntry
            Dim myDirectory As New DirectoryEntry(sPath, adminLogon, adminPassword)
            Dim mySearcher As New DirectorySearcher(myDirectory)
            Dim mySearchResult As SearchResult
            mySearcher.Filter = ("(&(objectClass=user)(samaccountname=" & SamAccount & "))")
            mySearchResult = mySearcher.FindOne()
            objUser = mySearchResult.GetDirectoryEntry()
            Try
                objUser.Invoke("ChangePassword", New Object() {oldPassword, newPassword})
            Catch ex As Exception
                errMsg = "Unable to change password." & vbCrLf & ex.Message
                Return False
            End Try
        Catch ex As System.Exception
            errMsg = ex.Message
            Return False
        End Try
        Return True
    End Function
End Class

End Namespace
