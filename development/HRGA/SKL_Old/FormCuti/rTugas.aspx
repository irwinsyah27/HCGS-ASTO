<%@ Page Language="VB" Debug="true" AutoEventWireup="false" CodeFile="rTugas.aspx.vb" Inherits="rTugas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4"
            DataKeyNames="NomorST" DataSourceID="SqlDataCuti" ForeColor="#333333" GridLines="None"
            Height="50px" Style="border-right: #3399ff 1px solid; border-top: #3399ff 1px solid;
            border-left: #3399ff 1px solid; border-bottom: #3399ff 1px solid" Width="100%">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
            <EditRowStyle BackColor="InactiveCaptionText" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <Fields>
                <asp:BoundField DataField="NomorST" HeaderText="NomorST" ReadOnly="True" SortExpression="NomorST" />
                <asp:BoundField DataField="Nrp" HeaderText="Nrp" ReadOnly="True" SortExpression="Nrp" />
                <asp:TemplateField HeaderText="Awal" SortExpression="Awal">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAwal" runat="server" Text='<%# Bind("Awal") %>' AutoPostBack="True" OnTextChanged="txtAwal_TextChanged"></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Awal") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Awal") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Akhir" SortExpression="Akhir">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAkhir" runat="server" Text='<%# Bind("Akhir") %>' AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Akhir") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Akhir") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Uang_Muka" HeaderText="Uang Muka" SortExpression="Uang_Muka" />
                <asp:BoundField DataField="Keterangan" HeaderText="Keterangan" SortExpression="Keterangan" />
                <asp:CommandField ShowEditButton="True" />
            </Fields>
            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" Width="200px" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataCuti" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
            DeleteCommand="DELETE FROM [tblSutu] WHERE [NomorST] = @NomorST" InsertCommand="INSERT INTO [tblSutu] ([NomorST], [Nrp], [Awal], [Akhir], [C_Lapangan], [C_Tahunan], [C_Besar], [C_Perjalanan]) VALUES (@NomorST, @Nrp, @Awal, @Akhir, @C_Lapangan, @C_Tahunan, @C_Besar, @C_Perjalanan)"
            SelectCommand="SELECT NomorST, Nrp, Awal, Akhir,Uang_Muka, Keterangan FROM tblSutu WHERE (NomorST = @NomorST)"
            UpdateCommand="UPDATE [tblSutu] SET [Awal] = @Awal, [Akhir] = @Akhir, [Uang_Muka] = @Uang_Muka, [Keterangan] = @Keterangan WHERE [NomorST] = @NomorST">
            <DeleteParameters>
                <asp:Parameter Name="NomorST" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Nrp" Type="String" />
                <asp:Parameter Name="Awal" Type="DateTime" />
                <asp:Parameter Name="Akhir" Type="DateTime" />
                <asp:Parameter Name="NomorST" Type="String" />
                <asp:Parameter Name="Uang_Muka" />
            </UpdateParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="NomorST" QueryStringField="n" Type="String" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="NomorST" Type="String" />
                <asp:Parameter Name="Nrp" Type="String" />
                <asp:Parameter Name="Awal" Type="DateTime" />
                <asp:Parameter Name="Akhir" Type="DateTime" />
                <asp:Parameter Name="C_Lapangan" Type="Int32" />
                <asp:Parameter Name="C_Tahunan" Type="Int32" />
                <asp:Parameter Name="C_Besar" Type="Int32" />
                <asp:Parameter Name="C_Perjalanan" Type="Int32" />
            </InsertParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
