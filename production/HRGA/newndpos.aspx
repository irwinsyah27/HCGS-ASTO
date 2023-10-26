<%@ Page Language="VB" MasterPageFile="MasterHrga.master" AutoEventWireup="false" CodeFile="newndpos.aspx.vb" Inherits="HRGA_newndpos" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4"
        DataKeyNames="ID" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None"
        Height="50px" Width="100%">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <CommandRowStyle BackColor="#C5BBAF" Font-Bold="True" />
        <EditRowStyle BackColor="#7C6F57" />
        <RowStyle BackColor="#E3EAEB" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <Fields>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                SortExpression="ID" Visible="False" />
            <asp:BoundField DataField="Nrp" HeaderText="Nrp" SortExpression="Nrp" />
            <asp:TemplateField HeaderText="Secondary Posisi" SortExpression="ndPosisi">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ndPosisi") %>'></asp:TextBox>&nbsp;
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataPosisi"
                        DataTextField="Jabatan" DataValueField="Jabatan" SelectedValue='<%# Bind("ndPosisi") %>'>
                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataPosisi" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                        SelectCommand="SELECT DISTINCT [Jabatan] FROM [tblKaryawan]&#13;&#10;WHERE Jabatan like '%HEAD%' OR  Jabatan like '%PROJECT MANAGER%'  OR  Jabatan like '%PERSONNEL%'  OR  Jabatan like '%PAYROLL%'&#13;&#10;UNION&#13;&#10;SELECT '' AS [Jabatan] FROM [tblKaryawan]">
                    </asp:SqlDataSource>
                </InsertItemTemplate>
                <HeaderStyle Width="300px" />
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("ndPosisi") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Awal" SortExpression="Awal">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Awal") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Awal") %>'></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="..." />
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC"
                        BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
                        Font-Size="8pt" ForeColor="#003399" Height="200px" OnSelectionChanged="Calendar1_SelectionChanged"
                        Style="position: absolute" Visible="False" Width="220px">
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
                            Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                    </asp:Calendar>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Awal") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Akhir" SortExpression="Akhir">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Akhir") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Akhir") %>'></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="..." />
                    <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#3366CC"
                        BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
                        Font-Size="8pt" ForeColor="#003399" Height="200px" OnSelectionChanged="Calendar2_SelectionChanged"
                        Style="position: absolute" Visible="False" Width="220px">
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
                            Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                    </asp:Calendar>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Akhir") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowInsertButton="True" />
        </Fields>
        <FieldHeaderStyle BackColor="#D0D0D0" Font-Bold="True" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        DeleteCommand="DELETE FROM [tblndPosisi] WHERE [ID] = @ID" InsertCommand="INSERT INTO [tblndPosisi] ([Nrp], [ndPosisi], [Awal], [Akhir], [Tanggal], [DibuatOleh]) VALUES (@Nrp, @ndPosisi, @Awal, @Akhir, Getdate(), @DibuatOleh)"
        SelectCommand="SELECT TOP 1 ID, Nrp, ndPosisi, Awal, Akhir, Expired, Tanggal, DibuatOleh FROM tblndPosisi ORDER BY ID DESC"
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
            <asp:SessionParameter Name="DibuatOleh" SessionField="userid" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
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
            <asp:BoundField DataField="DibuatOleh" HeaderText="DibuatOleh" SortExpression="DibuatOleh" />
            <asp:BoundField DataField="Tanggal" HeaderText="Tanggal" ReadOnly="True" SortExpression="Tanggal" />
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
        SelectCommand="SELECT [ID], [Nrp], [ndPosisi], [Awal], [Akhir], [Expired], [Tanggal], [DibuatOleh] FROM [tblndPosisi]&#13;&#10;ORDER BY ID DESC"
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
</asp:Content>

