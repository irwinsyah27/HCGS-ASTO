<%@ Page Language="VB" Debug="true"  MasterPageFile="~/HRGA/MasterHrga.master" AutoEventWireup="false" CodeFile="ndPosisi.aspx.vb" Inherits="HRGA_ndPosisi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="#333333"
        GridLines="None" Width="100%">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                SortExpression="ID" />
            <asp:BoundField DataField="Nrp" HeaderText="Nrp" SortExpression="Nrp" />
            <asp:BoundField DataField="ndPosisi" HeaderText="ndPosisi" SortExpression="ndPosisi" />
            <asp:BoundField DataField="Awal" HeaderText="Awal" SortExpression="Awal" />
            <asp:BoundField DataField="Akhir" HeaderText="Akhir" SortExpression="Akhir" />
            <asp:CheckBoxField DataField="Expired" HeaderText="Expired" SortExpression="Expired" />
            <asp:BoundField DataField="Tanggal" HeaderText="Tanggal" ReadOnly="True" SortExpression="Tanggal" />
            <asp:BoundField DataField="DibuatOleh" HeaderText="DibuatOleh" SortExpression="DibuatOleh" />
        </Columns>
        <RowStyle BackColor="#E3EAEB" />
        <EditRowStyle BackColor="#7C6F57" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        DeleteCommand="DELETE FROM [tblndPosisi] WHERE [ID] = @ID" InsertCommand="INSERT INTO [tblndPosisi] ([Nrp], [ndPosisi], [Awal], [Akhir], [Expired], [Tanggal], [DibuatOleh]) VALUES (@Nrp, @ndPosisi, @Awal, @Akhir, @Expired, @Tanggal, @DibuatOleh)"
        SelectCommand="SELECT [ID], [Nrp], [ndPosisi], [Awal], [Akhir], [Expired], [Tanggal], [DibuatOleh] FROM [tblndPosisi]"
        UpdateCommand="UPDATE [tblndPosisi] SET [Nrp] = @Nrp, [ndPosisi] = @ndPosisi, [Awal] = @Awal, [Akhir] = @Akhir, [Expired] = @Expired, [Tanggal] = @Tanggal, [DibuatOleh] = @DibuatOleh WHERE [ID] = @ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Nrp" Type="String" />
            <asp:Parameter Name="ndPosisi" Type="String" />
            <asp:Parameter Name="Awal" Type="DateTime" />
            <asp:Parameter Name="Akhir" Type="DateTime" />
            <asp:Parameter Name="Expired" Type="Boolean" />
            <asp:Parameter Name="Tanggal" Type="DateTime" />
            <asp:Parameter Name="DibuatOleh" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Nrp" Type="String" />
            <asp:Parameter Name="ndPosisi" Type="String" />
            <asp:Parameter Name="Awal" Type="DateTime" />
            <asp:Parameter Name="Akhir" Type="DateTime" />
            <asp:Parameter Name="Expired" Type="Boolean" />
            <asp:Parameter Name="Tanggal" Type="DateTime" />
            <asp:Parameter Name="DibuatOleh" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
    &nbsp;&nbsp;
</asp:Content>

