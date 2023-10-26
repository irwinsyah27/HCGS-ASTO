<%@ Page Language="VB" MasterPageFile="../MasterHrga.master" AutoEventWireup="false" CodeFile="lstStatusProses.aspx.vb" Inherits="lstStatusProses" title="Status Proses Pelamar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="width: 100%; text-align: center; height: 43px;">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="14pt" Text="Proses di :"></asp:Label>
                <asp:DropDownList ID="DDLStatus" runat="server" AutoPostBack="True" DataSourceID="SqlStatus"
                    DataTextField="Status" DataValueField="Status">
                </asp:DropDownList><asp:SqlDataSource ID="SqlStatus" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                    SelectCommand="SELECT DISTINCT Status FROM   TblPelamar_Proses UNION SELECT 'ALL' AS [Status] UNION SELECT '' AS [Status]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 100%" valign="top">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT  TblPelamar_Proses.KodePosisi, tblPelamar.Nama, tblPelamar.Site, tblPelamar.Dept, tblPelamar.Posisi, TblPelamar_Proses.DeptInterviewStatus, TblPelamar_Proses.PsikoStatus, TblPelamar_Proses.PMInterviewstatus, TblPelamar_Proses.DirInterviewStatus, TblPelamar_Proses.MCUStatus, TblPelamar_Proses.Signdate, TblPelamar_Proses.Status FROM  TblPelamar_Proses LEFT OUTER JOIN   tblPelamar ON TblPelamar_Proses.KodePosisi = tblPelamar.KodePosisi WHERE (TblPelamar_Proses.Status=@Status or @Status='ALL') order by tblPelamar.KodePosisi desc">
    <SelectParameters>            
            <asp:ControlParameter ControlID="DDLStatus" Name="Status" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="viewpama" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataKeyNames="KodePosisi" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
        Width="100%" Font-Overline="False" Font-Size="10pt" AllowSorting="True" AllowPaging="True" PageSize="15">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <Columns>
            <asp:BoundField DataField="KodePosisi" HeaderText="Nomor" ReadOnly="True" SortExpression="KodePosisi" />
            <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
            <asp:BoundField DataField="Site" HeaderText="Site" SortExpression="Site" />
            <asp:BoundField DataField="Dept" HeaderText="Dept" SortExpression="Dept" />
            <asp:BoundField DataField="Posisi" HeaderText="Posisi" SortExpression="Posisi" />
            <asp:BoundField DataField="DeptInterviewStatus" HeaderText="Dept Interv" SortExpression="DeptInterviewStatus" />
            <asp:BoundField DataField="PsikoStatus" HeaderText="PsikoStatus" SortExpression="PsikoStatus" />
            <asp:BoundField DataField="PMInterviewstatus" HeaderText="PM Interv" SortExpression="PMInterviewstatus" />
            <asp:BoundField DataField="DirInterviewStatus" HeaderText="Dir Interv" SortExpression="DirInterviewStatus" />
            <asp:BoundField DataField="MCUStatus" HeaderText="MCU" SortExpression="MCUStatus" />
            <asp:BoundField DataField="Signdate" HeaderText="SIGN" SortExpression="Signdate" />
            <asp:HyperLinkField DataNavigateUrlFields="KodePosisi" DataNavigateUrlFormatString="ProsesPelamar.aspx?n={0}"
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