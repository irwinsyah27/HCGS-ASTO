<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopupNrp.aspx.cs" Inherits="PopupNrp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Nrp" DataSourceID="SqlDataKaryawan"
            ForeColor="#333333" GridLines="None" Style="border-right: #5d7b9d 1px solid;
            border-top: #5d7b9d 1px solid; border-left: #5d7b9d 1px solid; border-bottom: #5d7b9d 1px solid" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" Width="100%">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="Nrp" HeaderText="Nrp" ReadOnly="True" SortExpression="Nrp" />
                <asp:BoundField DataField="NAMA" HeaderText="NAMA" SortExpression="NAMA" />
                <asp:BoundField DataField="Departemen" HeaderText="Departemen" SortExpression="Departemen" />
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/GoRtlHS.png" ShowSelectButton="True" />
            </Columns>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataKaryawan" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
            SelectCommand="SELECT Nrp, Nama, Departemen FROM tblKaryawan WHERE (Departemen = @dept)" ProviderName="<%$ ConnectionStrings:persisConnectionString.ProviderName %>">
            <SelectParameters>
                <asp:SessionParameter Name="dept" SessionField="dept" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
