<%@ Page Language="VB" MasterPageFile="MasterTrans.master" AutoEventWireup="false" CodeFile="RekapDeklarasi.aspx.vb" Inherits="HRGA_Trans_RekapDeklarasi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Tanggal :"></asp:Label>
    <asp:TextBox ID="txtAwal"
        runat="server" Width="100px"></asp:TextBox>
        <A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=ctl00$ContentPlaceHolder1$txtAwal','PopupClass','width=215,height=195,left=300,top=200')"
		                            href="javascript:;"><IMG src="Images/Calendar.png" border="0" id="IMG1" runat="server" align="absMiddle" height="20" width="20"></A>
        <asp:Label ID="Label2" runat="server" Text="s/d Tanggal :"></asp:Label>
    <asp:TextBox
            ID="txtAkhir" runat="server" Width="100px"></asp:TextBox>
        <A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=ctl00$ContentPlaceHolder1$txtAkhir','PopupClass','width=215,height=195,left=400,top=200')"
		                            href="javascript:;"><IMG src="Images/Calendar.png" border="0" id="IMG2" runat="server" align="absMiddle" height="20" width="20"></A>    
        <asp:Button ID="btnLoad" runat="server"
                Text="   OK   " /><br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="100%">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <Columns>
            <asp:BoundField DataField="Nrp" HeaderText="Nrp" SortExpression="Nrp" />
            <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
            <asp:BoundField DataField="Departemen" HeaderText="Departemen" SortExpression="Departemen" />
            <asp:BoundField DataField="NomorST" HeaderText="NomorST" SortExpression="NomorST" />
            <asp:BoundField DataField="UDL" HeaderText="UDL" SortExpression="UDL" />
            <asp:BoundField DataField="UPD" HeaderText="UPD" SortExpression="UPD" />
            <asp:BoundField DataField="TIKET" HeaderText="TIKET" SortExpression="TIKET" />
            <asp:BoundField DataField="AKOMODASI" HeaderText="AKOMODASI" ReadOnly="True" SortExpression="AKOMODASI" />
            <asp:BoundField DataField="TRANSPORT" HeaderText="TRANSPORT" SortExpression="TRANSPORT" />
        </Columns>
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BackColor="#999999" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SP_REKAP_TRANSAKSI" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtAwal" Name="AWAL" PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="txtAkhir" Name="AKHIR" PropertyName="Text" Type="DateTime" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

