<%@ Page Language="VB" MasterPageFile="MasterHrga.master" AutoEventWireup="false" CodeFile="lstShutleBus.aspx.vb" Inherits="lstShutleBus" title="List Shutle Bus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="width: 100%; text-align: center">
                &nbsp;<asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] ">
    </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDatacompany" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT * FROM(&#13;&#10;SELECT DISTINCT Company FROM tblKaryawan where Company <>'' UNION ALL SELECT '' AS Company&#13;&#10;UNION ALL SELECT 'ALL' AS Company) AS Tbl&#13;&#10;ORDER BY Company">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataDept" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen] UNION SELECT 'ALL DEPT' AS [Departemen]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlStatus" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT DISTINCT [Status] FROM [tblFlight] UNION SELECT 'ALL' AS [Status]">
    </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 100%" valign="top">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT *&#13;&#10;  FROM [Persis].[dbo].[VW_ListShutleBusCuti_RANT_BINU]&#13;&#10;WHERE (Departemen = @DEPT OR @DEPT='ALL DEPT') AND (Status=@Status or @Status='ALL')  AND &#13;&#10;(Nrp=@NRP or @NRP='ALL')&#13;&#10;AND (Site=@SiteC OR @SiteC='ALL SITE')  &#13;&#10;ORDER BY Tanggal DESC&#13;&#10;" EnableViewState="False">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="DEPT" PropertyName="SelectedValue" DefaultValue="" />
            <asp:ControlParameter ControlID="DDLStatus" Name="Status" PropertyName="SelectedValue" DefaultValue="ALL" />
            <asp:ControlParameter ControlID="txNRP" DefaultValue="ALL" Name="NRP" PropertyName="Text" />
            <asp:SessionParameter Name="Site" SessionField="Site" />
            <asp:ControlParameter ControlID="DropDownList3" Name="SiteC" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT *
  FROM [Persis].[dbo].[VW_ListShutleBusCuti_RANT_BINU]
WHERE (Tgl=@Tgl)
ORDER BY Tanggal DESC
" EnableViewState="False">
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtTgl" DbType="DateTime" DefaultValue="" 
                Name="Tgl" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
            </td>
        </tr>
    </table>
<asp:Panel ID="Panel2" runat="server" BorderColor="#99CCFF" 
    BorderStyle="Dashed" Height="372px" HorizontalAlign="Center" ScrollBars="Auto">
    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="14pt" 
        Text="Antrian Penumpang Shutle Bus"></asp:Label>
    <br />
    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Company :" 
        Visible="False"></asp:Label>
    <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" 
        Visible="False">
        <asp:ListItem>ALL SITE</asp:ListItem>
        <asp:ListItem Value="KPRT">RANT</asp:ListItem>
        <asp:ListItem Value="KPBN">BINU</asp:ListItem>
        <asp:ListItem Value="KPTA">TAJA</asp:ListItem>
        <asp:ListItem Value="KPOR">PORT</asp:ListItem>
    </asp:DropDownList>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Departemen : "></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        DataSourceID="SqlDataDept" DataTextField="Departemen" 
        DataValueField="Departemen">
    </asp:DropDownList>
    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Status : "></asp:Label>
    <asp:DropDownList ID="DDLStatus" runat="server" AutoPostBack="True" 
        DataSourceID="SqlStatus" DataTextField="Status" DataValueField="Status">
    </asp:DropDownList>
    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="NRP : "></asp:Label>
    <asp:TextBox ID="txNRP" runat="server"></asp:TextBox>
    <br />
    <asp:GridView ID="viewls" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataKeyNames="NomorST" DataSourceID="SqlDataSource1" 
    ForeColor="#333333" GridLines="None"
        Width="100%" Font-Overline="False" Font-Size="10pt" 
    AllowSorting="True" AllowPaging="True" Visible="False">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <Columns>
            <asp:BoundField DataField="NomorST" HeaderText="Nomor" ReadOnly="True" 
                SortExpression="NomorST" />
            <asp:BoundField DataField="Departemen" HeaderText="Dept" 
                SortExpression="Departemen" />
            <asp:BoundField DataField="Nrp" HeaderText="Nrp" SortExpression="Nrp" />
            <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
            <asp:BoundField DataField="Tujuan" HeaderText="Tujuan" 
                SortExpression="Tujuan" />
            <asp:BoundField DataField="Tanggal" HeaderText="Tanggal &amp; Jam" 
                SortExpression="Tanggal" ></asp:BoundField>
            <asp:BoundField DataField="Keterangan" HeaderText="Ket" 
                SortExpression="Keterangan" ></asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="NomorST" DataNavigateUrlFormatString="dCuti.aspx?n={0}"
                Text="Details" Target="_blank" DataTextField="Status" HeaderText="Status" 
                SortExpression="Status" ></asp:HyperLinkField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl='<%# Eval("NomorST", "../images/prinths.png") %>'
                        NavigateUrl='<%# Eval("NomorST", "printForm.aspx?n={0}") %>' 
                        Target="_blank">[HyperLink1]</asp:HyperLink>
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
</asp:Panel>
                <asp:Panel ID="Panel1" runat="server" BorderColor="#99CCFF" 
                    BorderStyle="Dashed" Height="432px" HorizontalAlign="Center" ScrollBars="Auto">
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="14pt" 
                        Text="List Penumpang Shutle Bus"></asp:Label>
                    <br />
                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Tanggal : "></asp:Label>
                    <asp:TextBox ID="TxtTgl" runat="server" Enabled="False" Visible="False" 
                        Width="10%"></asp:TextBox>
                    <asp:Button ID="btnawallbr" runat="server" Text="Tgl" />
                    <asp:Calendar ID="calawallbr" runat="server" BackColor="White" 
                        BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                        DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                        ForeColor="#003399" Height="67px" Visible="False" Width="150px">
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                            Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                    </asp:Calendar>
                    <asp:GridView ID="viewpama" runat="server" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                        DataKeyNames="NomorST" DataSourceID="SqlDataSource2" Font-Overline="False" 
                        Font-Size="10pt" ForeColor="#333333" GridLines="None" PageSize="12" 
                        Visible="False" Width="100%">
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="NomorST" HeaderText="Nomor" ReadOnly="True" 
                                SortExpression="NomorST" />
                            <asp:BoundField DataField="Departemen" HeaderText="Dept" 
                                SortExpression="Departemen" />
                            <asp:BoundField DataField="Nrp" HeaderText="Nrp" SortExpression="Nrp" />
                            <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
                            <asp:BoundField DataField="Tujuan" HeaderText="Tujuan" 
                                SortExpression="Tujuan" />
                            <asp:BoundField DataField="Tanggal" HeaderText="Tanggal &amp; Jam" 
                                SortExpression="Tanggal" />
                            <asp:BoundField DataField="Dari_Ke" HeaderText="Dari-Ke" 
                                SortExpression="Dari_Ke" />
                            <asp:BoundField DataField="Keterangan" HeaderText="Ket" 
                                SortExpression="Keterangan" />
                            <asp:HyperLinkField DataNavigateUrlFields="NomorST" 
                                DataNavigateUrlFormatString="dCuti.aspx?n={0}" DataTextField="Status" 
                                HeaderText="Status" SortExpression="Status" Target="_blank" Text="Details" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" 
                                        ImageUrl='<%# Eval("NomorST", "../images/prinths.png") %>' 
                                        NavigateUrl='<%# Eval("NomorST", "printForm.aspx?n={0}") %>' Target="_blank">[HyperLink1]</asp:HyperLink>
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
                    <br />
                </asp:Panel>
            </asp:Content>

