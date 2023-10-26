<%@ Page Language="VB" debug="true" MasterPageFile="~/HRGA/MasterHrga.master" AutoEventWireup="false" CodeFile="lstDinas1.aspx.vb" Inherits="lstDinas1" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="width: 100%; height: 36px; text-align: center">
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Daftar Karyawan, Surat Dinas akan berakhir dalam 7 hari" Font-Size="14pt"></asp:Label><br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Departemen : "></asp:Label><asp:DropDownList
        ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataDept"
        DataTextField="Departemen" DataValueField="Departemen">
    </asp:DropDownList><asp:SqlDataSource ID="SqlDataDept" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] ">
    </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333"
        GridLines="None" PageSize="15" Width="100%">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <Columns>
            <asp:BoundField DataField="Nrp" HeaderText="Nrp" SortExpression="Nrp" />
            <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
            <asp:BoundField DataField="Departemen" HeaderText="Departemen" SortExpression="Departemen" />
            <asp:BoundField DataField="Jabatan" HeaderText="Jabatan" SortExpression="Jabatan" />
            <asp:BoundField DataField="Awal" HeaderText="Awal" SortExpression="Awal" />
            <asp:BoundField DataField="Akhir" HeaderText="Akhir" SortExpression="Akhir" />
            <asp:TemplateField HeaderText="Tempo" SortExpression="Tempo">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Tempo") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Tempo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle BackColor="#E3EAEB" />
        <EditRowStyle BackColor="#7C6F57" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT [Nrp], [Nama], [Departemen], [Jabatan], [Awal], [Akhir],[Tempo] FROM [VW_DINAS_AKAN_SELESAI] WHERE Departemen = @DEPT">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="DEPT" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

