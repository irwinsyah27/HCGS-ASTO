<%@ Page Language="VB" MasterPageFile="../MasterHrga.master" AutoEventWireup="false" CodeFile="lstPelamar.aspx.vb" Inherits="lstPelamar" title="List Pelamar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="width: 100%; text-align: center; height: 43px;">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="14pt" Text="Company :"></asp:Label><asp:DropDownList
                    ID="DropDownList3" runat="server" AutoPostBack="True" DataSourceID="SqlDatacompany"
                    DataTextField="Company" DataValueField="Company">
                </asp:DropDownList><asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="14pt"
                    Text="Departemen : "></asp:Label><asp:DropDownList ID="DropDownList1" runat="server"
                        AutoPostBack="True" DataSourceID="SqlDataDept" DataTextField="Departemen" DataValueField="Departemen">
                    </asp:DropDownList>&nbsp;
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="14pt" Text="Status Rekruitmen :"></asp:Label>
                <asp:DropDownList ID="DDLStatus" runat="server" AutoPostBack="True" DataSourceID="SqlStatus"
                    DataTextField="Status" DataValueField="Status">
                </asp:DropDownList><asp:SqlDataSource ID="SqlStatus" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                    SelectCommand="SELECT DISTINCT StatusKandidat AS Status FROM [tblPelamar] UNION SELECT 'ALL' AS [Status] UNION SELECT '' AS [Status]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDatacompany" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                    SelectCommand="SELECT DISTINCT Company FROM tblKaryawan where Company <>'' UNION SELECT 'ALL' AS [Company] UNION SELECT '' AS [Company]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataDept" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                    SelectCommand="SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] UNION SELECT 'ALL DEPT' AS [Departemen]">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 100%" valign="top">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT KodeLamaran, [Nama], [TglLahir], [Pendidikan], Jenjang, [Jurusan], [Akreditasi], [IPK], ThnLulus, Status AS Status, Ket AS AmbilPosisi FROM [vw_Pelamar] WHERE (Status=@Status or @Status='ALL') AND  (FromRek=@FromRek or @FromRek='ALL') AND (Dept=@Dept or @Dept='ALL DEPT')  order by KodeLamaran desc">
    <SelectParameters>            
            <asp:ControlParameter ControlID="DDLStatus" Name="Status" PropertyName="SelectedValue" />
        <asp:ControlParameter ControlID="DropDownList3" Name="FromRek" PropertyName="SelectedValue" />
        <asp:ControlParameter ControlID="DropDownList1" Name="Dept" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="viewpama" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataKeyNames="KodeLamaran" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
        Width="100%" Font-Overline="False" Font-Size="10pt" AllowSorting="True" AllowPaging="True" PageSize="15">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <Columns>
            <asp:BoundField DataField="KodeLamaran" HeaderText="Nomor" ReadOnly="True" SortExpression="KodeLamaran" />
            <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
            <asp:BoundField DataField="TglLahir" HeaderText="TglLahir" SortExpression="TglLahir" />
            <asp:BoundField DataField="Pendidikan" HeaderText="Pendidikan" SortExpression="Pendidikan" />
            <asp:BoundField DataField="Jenjang" HeaderText="Jenjang" SortExpression="Jenjang" />
            <asp:BoundField DataField="Jurusan" HeaderText="Jurusan" SortExpression="Jurusan" />
            <asp:BoundField DataField="Akreditasi" HeaderText="Akreditasi" SortExpression="Akreditasi" />
            <asp:BoundField DataField="IPK" HeaderText="IPK" SortExpression="IPK" />
            <asp:BoundField DataField="AmbilPosisi" HeaderText="AmbilPosisi" SortExpression="AmbilPosisi" />
            <asp:HyperLinkField DataNavigateUrlFields="KodeLamaran" DataNavigateUrlFormatString="InputPosisiPelamar.aspx?n={0}"
                Text="Details" Target="_blank" DataTextField="Status" HeaderText="Status" SortExpression="Status" >
                <ItemStyle Width="80px" />
            </asp:HyperLinkField>            
        </Columns>
        <RowStyle BackColor="#E3EAEB" HorizontalAlign="Center" />
        <EditRowStyle BackColor="#7C6F57" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
                &nbsp;&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>