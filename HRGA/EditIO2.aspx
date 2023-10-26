<%@ Page Language="VB" MasterPageFile="MasterHrga.master" AutoEventWireup="false" CodeFile="EditIO2.aspx.vb" Inherits="_HRGA_EditIO2" title="Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <strong>
        &nbsp;</strong><asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:LinkButton ID="btnSearch" runat="server" Font-Bold="True">Search Nrp / Kode  | Edit By :  </asp:LinkButton>&nbsp;
    <asp:Label ID="User" runat="server" BackColor="White" BorderColor="White" BorderStyle="None"
        BorderWidth="1px" Font-Bold="True" Font-Size="11px" ForeColor="Black">| |</asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataKeyNames="id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" AllowPaging="True" BorderStyle="Solid" BorderWidth="1px" PageSize="18" Width="860px">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                    SortExpression="id" Visible="False" />
                <asp:BoundField DataField="nrp" HeaderText="NRP" SortExpression="nrp" ReadOnly="True" />
                <asp:BoundField DataField="Nama" HeaderText="NAMA" ReadOnly="True" SortExpression="Nama" />
                <asp:BoundField DataField="Dept" HeaderText="DEPT" ReadOnly="True" SortExpression="Dept" />
                <asp:BoundField DataField="tanggal" HeaderText="TANGGAL" SortExpression="tanggal" ReadOnly="True" />
                <asp:TemplateField HeaderText="SHIFT" SortExpression="Shift">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("Shift") %>'>
                            <asp:ListItem Selected="True"></asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Shift") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="IN" DataField ="in" SortExpression="in" ReadOnly="True"></asp:BoundField>
                <asp:BoundField HeaderText="OUT" DataField ="out" SortExpression="out" ReadOnly="True"></asp:BoundField>
                <asp:BoundField DataField="jk1" HeaderText="JK" ReadOnly="True" SortExpression="jk1" />
                <asp:TemplateField HeaderText="Rostercode" SortExpression="Rostercode">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataROSTER"
                            DataTextField="ROSTERCODE" DataValueField="rostercode" SelectedValue='<%# Bind("Rostercode") %>'>
                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataROSTER" runat="server" ConnectionString="<%$ ConnectionStrings:DATA_ABS1ConnectionString %>"
                            SelectCommand="SELECT [RosterCode], [Lokasi] FROM [Roster] UNION SELECT null AS [RosterCode], null  AS  [Lokasi] FROM [Roster] where rostercode <> 28 order by ROSTERCODE desc">
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Rostercode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Kode" SortExpression="Absent">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="AbsentCode" DataTextField="Keterangan"
                            DataValueField="Code" SelectedValue='<%# Bind("Absent") %>' Width="50px">
                        </asp:DropDownList><asp:SqlDataSource ID="AbsentCode" runat="server" ConnectionString="<%$ ConnectionStrings:Data_abs1ConnectionString %>"
                            SelectCommand="SELECT [Code], [Keterangan] FROM [AbsentCode]"></asp:SqlDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Absent") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="SKL" DataField ="SKL" SortExpression="SKL" ReadOnly="True"></asp:BoundField>
                <asp:BoundField HeaderText="SKL1" DataField ="SKL1" SortExpression="SKL1" ReadOnly="True"></asp:BoundField>
                <asp:BoundField HeaderText="Ket Absen" DataField ="ket_absen" SortExpression="ket_absen" ReadOnly="True"></asp:BoundField>
                <asp:BoundField HeaderText="Tgl Terima BA" DataField ="tgl_ba" SortExpression="tgl_ba" ReadOnly="True"></asp:BoundField>
                <asp:TemplateField HeaderText="Keterangan" SortExpression="Keterangan">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("keterangan") %>' Width="120px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("keterangan") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="EditBy" HeaderText="BY" ReadOnly="True" SortExpression="EditBy" />
                <asp:CommandField ShowEditButton="True"  ButtonType=Image DeleteImageUrl="Images/Delete.gif" EditImageUrl="Images/Edit.gif" CancelImageUrl="Images/Cancel.gif" UpdateImageUrl="Images/Update.gif"/>
            </Columns>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Data_abs1ConnectionString %>"
            DeleteCommand="DELETE FROM [lembarkerja] WHERE [id] = @id" 
            InsertCommand="INSERT INTO [lembarkerja] ([nrp], [tanggal],[ket_absen],[tgl_ba],[keterangan]) VALUES (@nrp, @tanggal, @in, @out, @ket_absen, @tgl_ba,@keterangan)"
            SelectCommand="SELECT  [id]&#13;&#10;&#9;,lembarkerja. [nrp]&#13;&#10;&#9;, [nama]&#13;&#10;&#9;, [Dept]&#13;&#10;&#9;, tanggal &#13;&#10;&#9;, [shift]&#13;&#10;                , [Absent]&#13;&#10;                , [SKL]&#13;&#10;                , [SKL1]&#13;&#10;&#9;, [JK1] = LEFT(Round([jk1],2),5)&#13;&#10;&#9;, [IN] = Case Len(Cast(Datepart(hour,lembarkerja.[in])as varchar)) When 1 Then '0'+Cast(Datepart(hour,lembarkerja.[in])as varchar) Else Cast(Datepart(hour,[in])as varchar)End +':'+ Case Len(Cast(Datepart(minute,lembarkerja.[in])as varchar)) When 1 Then '0'+Cast(Datepart(minute,lembarkerja.[in])as varchar)Else Cast(Datepart(minute,lembarkerja.[in])as varchar)End &#13;&#10;&#9;, [OUT] = Case Len(Cast(Datepart(hour,lembarkerja.[out])as varchar)) When 1 Then '0'+Cast(Datepart(hour,lembarkerja.[out])as varchar) Else Cast(Datepart(hour,lembarkerja.[out])as varchar)End +':'+ Case Len(Cast(Datepart(minute,lembarkerja.[out])as varchar)) When 1 Then '0'+Cast(Datepart(minute,lembarkerja.[out])as varchar)Else Cast(Datepart(minute,lembarkerja.[out])as varchar)End &#13;&#10;,lembarkerja.[rostercode]&#13;&#10;, lembarkerja.[ket_absen]&#13;&#10;, lembarkerja.[tgl_ba]&#13;&#10;,lembarkerja.[keterangan]&#13;&#10;, lembarkerja.[UserUpdate] AS EditBy&#13;&#10; FROM [lembarkerja] INNER JOIN Karyawan ON lembarkerja.Nrp = Karyawan.Nrp&#13;&#10; Where lembarkerja.Nrp = @Nrp OR lembarkerja.Absent = @X&#13;&#10; Order By Tanggal desc"
            UpdateCommand="UPDATE [lembarkerja] SET  [shift] = @shift, [absent] = @absent, [ket_absen]=@ket_absen,[tgl_ba]=@tgl_ba,[keterangan]=@keterangan , [rostercode]=@rostercode, [UserUpdate]=@UserUpdate  WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="shift" />
                <asp:Parameter Name="in" Type="DateTime" />
                <asp:Parameter Name="out" Type="DateTime" />
                <asp:Parameter Name="id" Type="Int32" />
                <asp:Parameter Name="absent" Type="String"/>
                <asp:Parameter Name="skl" />
                <asp:Parameter Name="skl1" />
                <asp:Parameter Name="ket_absen" />
                <asp:Parameter Name="tgl_ba" Type="DateTime" />
                <asp:Parameter Name="keterangan" Type="String" />
                <asp:Parameter Name="rostercode" Type="Int32"/>
                <asp:SessionParameter Name="UserUpdate" SessionField="userid" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="nrp" Type="String" />
                <asp:Parameter Name="tanggal" Type="DateTime" />
                <asp:Parameter Name="in" Type="DateTime" />
                <asp:Parameter Name="out" Type="DateTime" />
                <asp:Parameter Name="ket_absen" Type="String" />
                <asp:Parameter Name="tgl_ba" Type="DateTime" />
                <asp:Parameter Name="keterangan" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="txtSearch" Name="Nrp" PropertyName="Text" DefaultValue="" />
                <asp:ControlParameter ControlID="txtSearch" Name="X" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>

</asp:Content>