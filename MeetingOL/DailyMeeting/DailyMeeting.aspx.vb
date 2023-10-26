Imports System
Imports System.Web.UI.WebControls
Imports Telerik.Web.UI
Imports System.Data.SqlClient
Imports System.Configuration

Namespace Telerik.Web.Examples.Editor.EditTemplate
    Partial Public Class DefaultVB
        Inherits System.Web.UI.Page
        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        End Sub

        Protected Sub SqlDataSource1_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceCommandEventArgs) Handles SqlDataSource1.Inserting

        End Sub
    End Class
End Namespace
