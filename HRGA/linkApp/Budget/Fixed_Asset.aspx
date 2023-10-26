<%@ Page Language="VB" MasterPageFile="MasterHrga.master" AutoEventWireup="false" CodeFile="Fixed_Asset.aspx.vb" Inherits="_HRGA_Fixed_Asset" title="Fixed_Asset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <strong>
        &nbsp;</strong><asp:TextBox ID="txtSearch" runat="server" Visible="False"></asp:TextBox>
    &nbsp;
    <asp:DropDownList ID="DDCategory" runat="server" DataSourceID="DS_Category" DataTextField="Category" DataValueField="Category">
    </asp:DropDownList>
        <asp:LinkButton ID="btnSearch" runat="server" Font-Bold="True">Search Asset / Category</asp:LinkButton>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataKeyNames="id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="18" Width="100%" AllowSorting="True" Height="100%">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:CommandField ShowEditButton="True"  ButtonType=Image DeleteImageUrl="Images/Delete.gif" EditImageUrl="Images/Edit.gif" CancelImageUrl="Images/Cancel.gif" UpdateImageUrl="Images/Update.gif"/>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="ID" Visible="False" />
                <asp:TemplateField HeaderText="Category" SortExpression="Category">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="DS_Category" DataTextField="Category"
                            DataValueField="Category" SelectedValue='<%# Bind("Category") %>'>
                        </asp:DropDownList>&nbsp;
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UnitKodePama" SortExpression="UnitKode">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="DS_UnitKode" DataTextField="UnitKode"
                            DataValueField="UnitKode" SelectedValue='<%# Bind("UnitKode") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="DS_UnitKode" runat="server" ConnectionString="<%$ ConnectionStrings:RbusConnectionString %>" InsertCommand="INSERT INTO [lembarkerja] ([nrp], [tanggal], [in], [out]) VALUES (@nrp, @tanggal, @in, @out)"
            SelectCommand="SELECT DISTINCT [UnitKode]&#13;&#10;  FROM [BudgetSystem].[dbo].[Asset_Fixed]" ProviderName="<%$ ConnectionStrings:RbusConnectionString.ProviderName %>">
                            <InsertParameters>
                                <asp:Parameter Name="nrp" Type="String" />
                                <asp:Parameter Name="tanggal" Type="DateTime" />
                                <asp:Parameter Name="in" Type="DateTime" />
                                <asp:Parameter Name="out" Type="DateTime" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("UnitKode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UnitKodeKPP" SortExpression="UnitEqNum">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="DS_UnitEqNum" DataTextField="UnitEqNum"
                            DataValueField="UnitEqNum" SelectedValue='<%# Bind("UnitEqNum") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="DS_UnitEqNum" runat="server" ConnectionString="<%$ ConnectionStrings:RbusConnectionString %>" InsertCommand="INSERT INTO [lembarkerja] ([nrp], [tanggal], [in], [out]) VALUES (@nrp, @tanggal, @in, @out)"
            SelectCommand="SELECT DISTINCT [UnitEqNum]&#13;&#10;  FROM [BudgetSystem].[dbo].[Asset_Fixed]" ProviderName="<%$ ConnectionStrings:RbusConnectionString.ProviderName %>">
                            <InsertParameters>
                                <asp:Parameter Name="nrp" Type="String" />
                                <asp:Parameter Name="tanggal" Type="DateTime" />
                                <asp:Parameter Name="in" Type="DateTime" />
                                <asp:Parameter Name="out" Type="DateTime" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("UnitEqNum") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UnitEGI" SortExpression="UnitEGI">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="DS_UnitEGI" DataTextField="UnitEGI"
                            DataValueField="UnitEGI" SelectedValue='<%# Bind("UnitEGI") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="DS_UnitEGI" runat="server" ConnectionString="<%$ ConnectionStrings:RbusConnectionString %>" InsertCommand="INSERT INTO [lembarkerja] ([nrp], [tanggal], [in], [out]) VALUES (@nrp, @tanggal, @in, @out)"
            SelectCommand="SELECT DISTINCT [UnitEGI]&#13;&#10;  FROM [BudgetSystem].[dbo].[Asset_Fixed]" ProviderName="<%$ ConnectionStrings:RbusConnectionString.ProviderName %>">
                            <InsertParameters>
                                <asp:Parameter Name="nrp" Type="String" />
                                <asp:Parameter Name="tanggal" Type="DateTime" />
                                <asp:Parameter Name="in" Type="DateTime" />
                                <asp:Parameter Name="out" Type="DateTime" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("UnitEGI") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Kode" SortExpression="Kode">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="DS_Kode" DataTextField="Kode"
                            DataValueField="Kode" SelectedValue='<%# Bind("Kode") %>'>
                        </asp:DropDownList>
                    <asp:SqlDataSource ID="DS_Kode" runat="server" ConnectionString="<%$ ConnectionStrings:RbusConnectionString %>" InsertCommand="INSERT INTO [lembarkerja] ([nrp], [tanggal], [in], [out]) VALUES (@nrp, @tanggal, @in, @out)"
            SelectCommand="SELECT DISTINCT [Kode]&#13;&#10;  FROM [BudgetSystem].[dbo].[Asset_Fixed]" ProviderName="<%$ ConnectionStrings:RbusConnectionString.ProviderName %>">
            <InsertParameters>
                <asp:Parameter Name="nrp" Type="String" />
                <asp:Parameter Name="tanggal" Type="DateTime" />
                <asp:Parameter Name="in" Type="DateTime" />
                <asp:Parameter Name="out" Type="DateTime" />
            </InsertParameters>
        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Kode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                <asp:BoundField DataField="SN" HeaderText="SN" SortExpression="SN" />
                <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
                <asp:BoundField DataField="NoDoc" HeaderText="NoDoc" SortExpression="NoDoc" />
                <asp:TemplateField HeaderText="AcqtDate" SortExpression="AcqtDate">
                    <EditItemTemplate>
                        <asp:Calendar ID="Calendar1" runat="server" Visible="False"></asp:Calendar>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("AcqtDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Site" SortExpression="Site">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList6" runat="server">
                            <asp:ListItem>RANT</asp:ListItem>
                            <asp:ListItem>BINU</asp:ListItem>
                            <asp:ListItem>TAJA</asp:ListItem>
                            <asp:ListItem>SPUT</asp:ListItem>
                            <asp:ListItem Value="INDE">INDE</asp:ListItem>
                            <asp:ListItem>PASS</asp:ListItem>
                            <asp:ListItem>MASS</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label13" runat="server" Text='<%# Bind("Site") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Penyusutan" HeaderText="LamaPenyusutan" SortExpression="Penyusutan" />
                <asp:BoundField DataField="SaldoAwal" HeaderText="SoAcqtCost(Awal)" SortExpression="SaldoAwal" DataFormatString="{0:c}" />
                <asp:BoundField DataField="SaldoAkhir" HeaderText="SoAcqtCost(Akhir)" SortExpression="SaldoAkhir" DataFormatString="{0:c}" />
            </Columns>
            <RowStyle BackColor="#EFF3FB" />
            <EditRowStyle BackColor="#2461BF" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RbusConnectionString %>" InsertCommand="INSERT INTO [lembarkerja] ([nrp], [tanggal], [in], [out]) VALUES (@nrp, @tanggal, @in, @out)"
            SelectCommand="Select * FROM v_Report_Fixed_Asset&#13;&#10;Where Category = @Category" ProviderName="<%$ ConnectionStrings:RbusConnectionString.ProviderName %>">
            <InsertParameters>
                <asp:Parameter Name="nrp" Type="String" />
                <asp:Parameter Name="tanggal" Type="DateTime" />
                <asp:Parameter Name="in" Type="DateTime" />
                <asp:Parameter Name="out" Type="DateTime" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="DDCategory" Name="Category" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="DS_Category" runat="server" ConnectionString="<%$ ConnectionStrings:RbusConnectionString %>" InsertCommand="INSERT INTO [lembarkerja] ([nrp], [tanggal], [in], [out]) VALUES (@nrp, @tanggal, @in, @out)"
            SelectCommand="SELECT DISTINCT &#13;&#10;                      Category, &#13;&#10;                      CASE Category WHEN 'Production Equipment' THEN 1 WHEN 'Asset Under Capital Lease (ACL)' THEN 2 WHEN 'Leasehold Asset' THEN 3 WHEN 'Building Equipment' THEN&#13;&#10;                       4 WHEN 'Workshop Equipment' THEN 5 WHEN 'Fixture & Fitting Equipment' THEN 6 WHEN 'Office Equipment' THEN 7 WHEN 'Support Equipment' THEN 8 WHEN 'Engineering Equipment'&#13;&#10;                       THEN 9 WHEN 'Computer' THEN 10 WHEN 'Leasehold Asset' THEN 11 ELSE 12 END AS Urut&#13;&#10;FROM         Asset_Fixed&#13;&#10;ORDER BY Urut" ProviderName="<%$ ConnectionStrings:RbusConnectionString.ProviderName %>">
                            <InsertParameters>
                                <asp:Parameter Name="nrp" Type="String" />
                                <asp:Parameter Name="tanggal" Type="DateTime" />
                                <asp:Parameter Name="in" Type="DateTime" />
                                <asp:Parameter Name="out" Type="DateTime" />
                            </InsertParameters>
                        </asp:SqlDataSource>

</asp:Content>