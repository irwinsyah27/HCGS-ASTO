<%@ Page Language="VB" MasterPageFile="MasterTrans.master" AutoEventWireup="false" CodeFile="Titipan.aspx.vb" Inherits="HRGA_Trans_Titipan" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Tanggal :"></asp:Label>
    <asp:TextBox ID="txtAwal" runat="server"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text="s/d Tanggal :"></asp:Label>
    <asp:TextBox ID="txtAkhir" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="btnLoad"
        runat="server" Text="   OK   " /><br />
    &nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="100%">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <Columns>
            <asp:BoundField DataField="NRP" HeaderText="NRP" SortExpression="NRP" />
            <asp:BoundField DataField="NAMA" HeaderText="NAMA" SortExpression="NAMA" />
            <asp:BoundField DataField="GAJI" HeaderText="NILAI" ReadOnly="True" SortExpression="GAJI" />
            <asp:BoundField DataField="POTONGAN" HeaderText="POTONGAN" ReadOnly="True" SortExpression="POTONGAN" />
            <asp:BoundField DataField="TERIMA" HeaderText="TERIMA" SortExpression="TERIMA" />
            <asp:BoundField DataField="Rekening" HeaderText="Rekening" SortExpression="Rekening" />
        </Columns>
        <RowStyle BackColor="#E3EAEB" />
        <EditRowStyle BackColor="#7C6F57" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        DeleteCommand="DELETE FROM [tblTitipan] WHERE [ID] = @ID" InsertCommand="INSERT INTO [tblTitipan] ([NRP], [NAMA], [TITIPAN], [POTONGAN], [TERIMA], [TANGGAL], [NRP_UPLOAD]) VALUES (@NRP, @NAMA, @TITIPAN, @POTONGAN, @TERIMA, @TANGGAL, @NRP_UPLOAD)"
        SelectCommand="SP_POTONGAN"
        UpdateCommand="UPDATE [tblTitipan] SET [NRP] = @NRP, [NAMA] = @NAMA, [TITIPAN] = @TITIPAN, [POTONGAN] = @POTONGAN, [TERIMA] = @TERIMA, [TANGGAL] = @TANGGAL, [NRP_UPLOAD] = @NRP_UPLOAD WHERE [ID] = @ID" SelectCommandType="StoredProcedure">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="NRP" Type="String" />
            <asp:Parameter Name="NAMA" Type="String" />
            <asp:Parameter Name="TITIPAN" Type="Int32" />
            <asp:Parameter Name="POTONGAN" Type="Int32" />
            <asp:Parameter Name="TERIMA" Type="Int32" />
            <asp:Parameter Name="TANGGAL" Type="DateTime" />
            <asp:Parameter Name="NRP_UPLOAD" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="NRP" Type="String" />
            <asp:Parameter Name="NAMA" Type="String" />
            <asp:Parameter Name="TITIPAN" Type="Int32" />
            <asp:Parameter Name="POTONGAN" Type="Int32" />
            <asp:Parameter Name="TERIMA" Type="Int32" />
            <asp:Parameter Name="TANGGAL" Type="DateTime" />
            <asp:Parameter Name="NRP_UPLOAD" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="txtAwal" Name="AWAL" PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="txtAkhir" Name="AKHIR" PropertyName="Text" Type="DateTime" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

