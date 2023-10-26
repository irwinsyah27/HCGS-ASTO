<%@ Page language="VB" %>

<script runat="server">

  Sub CustomersGridView_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

    ' If multiple buttons are used in a GridView control, use the
    ' CommandName property to determine which button was clicked.
    If e.CommandName = "Add" Then
    
      ' Convert the row index stored in the CommandArgument
      ' property to an Integer.
      Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            
      ' Retrieve the row that contains the button clicked 
      ' by the user from the Rows collection.
      Dim row As GridViewRow = CustomersGridView.Rows(index)
            
      ' Create a new ListItem object for the customer in the row.     
      Dim item As New ListItem()
      item.Text = Server.HtmlDecode(row.Cells(2).Text)
            
      ' If the customer is not already in the ListBox, add the ListItem 
      ' object to the Items collection of the ListBox control. 
      If Not CustomersListBox.Items.Contains(item) Then
      
        CustomersListBox.Items.Add(item)
        
      End If
      
    End If
    
  End Sub

  Sub CustomersGridView_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
    
    ' The GridViewCommandEventArgs class does not contain a 
    ' property that indicates which row's command button was
    ' clicked. To identify which row's button was clicked, use 
    ' the button's CommandArgument property by setting it to the 
    ' row's index.
    If e.Row.RowType = DataControlRowType.DataRow Then
    
      ' Retrieve the LinkButton control from the first column.
      Dim addButton As LinkButton = CType(e.Row.Cells(0).Controls(0), LinkButton)
          
      ' Set the LinkButton's CommandArgument property with the
      ' row's index.
      addButton.CommandArgument = e.Row.RowIndex.ToString()
      
    End If

  End Sub
    
</script>

<html>
  <body>
    <form id="Form1" runat="server">
        
      <h3>GridView RowCommand Example</h3>
            
      <table width="100%">         
        <tr>                
          <td width="50%">
                    
            <asp:gridview id="CustomersGridView" 
              datasourceid="SqlDataSourceFlight"
              allowpaging="True" 
              autogeneratecolumns="False"
              onrowcommand="CustomersGridView_RowCommand"
              onrowcreated="CustomersGridView_RowCreated"  
              runat="server">
                
              <columns>
                <asp:buttonfield 
                  commandname="Add" 
                  text="Add"/>
                  <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                  <asp:BoundField DataField="NomorST" HeaderText="NomorST" SortExpression="NomorST" />
                  <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
              </columns>
                
            </asp:gridview>
                    
          </td>
                    
          <td valign="top" width="50%">
                    
            Customers: <br/>
            <asp:listbox id="CustomersListBox"
              runat="server"/> 
                    
          </td>  
        </tr>      
      </table>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:SqlDataSource ID="SqlDataSourceFlight" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
            DeleteCommand="DELETE FROM [tblFlight] WHERE [ID] = @ID" InsertCommand="INSERT INTO [tblFlight] ([NomorST], [Nama], [Tanggal], [Dari_Ke], [Keterangan]) VALUES (@NomorST, @Nama, @Tanggal, @Dari_Ke, @Keterangan)"
            SelectCommand="SELECT [ID], [NomorST], [Nama], [Tanggal], [Dari_Ke], [Keterangan] FROM [tblFlight]"
            UpdateCommand="UPDATE [tblFlight] SET [NomorST] = @NomorST, [Nama] = @Nama, [Tanggal] = @Tanggal, [Dari_Ke] = @Dari_Ke, [Keterangan] = @Keterangan WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="NomorST" Type="String" />
                <asp:Parameter Name="Nama" Type="String" />
                <asp:Parameter Name="Tanggal" Type="DateTime" />
                <asp:Parameter Name="Dari_Ke" Type="String" />
                <asp:Parameter Name="Keterangan" Type="String" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="NomorST" Type="String" />
                <asp:Parameter Name="Nama" Type="String" />
                <asp:Parameter Name="Tanggal" Type="DateTime" />
                <asp:Parameter Name="Dari_Ke" Type="String" />
                <asp:Parameter Name="Keterangan" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
            
    </form>
  </body>
</html>
