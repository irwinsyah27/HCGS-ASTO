<%@ Page Language="VB" MasterPageFile="~/HRGA/MasterHrga.master" AutoEventWireup="false" CodeFile="status1.aspx.vb" Inherits="HRGA_status1" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
        SelectCommand="SELECT [NoIjin], [Nrp], [Tanggal], [Awal], [Akhir], [Keperluan], [Requestor] FROM [tblIjin] WHERE [Persetujuan] is null OR [ValidasiHR] is Null">
    </asp:SqlDataSource>
    <table border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td style="height: 181px" valign="top" width="776">
                <fieldset>
                    <asp:TreeView ID="TreeView1" runat="server" Font-Bold="True" Font-Size="10pt" ImageSet="Arrows">
                        <ParentNodeStyle Font-Bold="False" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                            VerticalPadding="0px" />
                        <Nodes>
                            <asp:TreeNode Text="STATUS IJIN JOB SITE" Value="STATUS IJIN JOB SITE">
                                <asp:TreeNode NavigateUrl="status1.aspx" Text="PROSES" Value="PROSES"></asp:TreeNode>
                                <asp:TreeNode NavigateUrl="status2.aspx" Text="DISETUJUI" Value="DISETUJUI"></asp:TreeNode>
                                <asp:TreeNode NavigateUrl="status3.aspx" Text="TIDAK DISETUJUI" Value="TIDAK DISETUJUI">
                                </asp:TreeNode>
                            </asp:TreeNode>
                        </Nodes>
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                </fieldset>
            </td>
            <td style="width: 100px; height: 181px" valign="top"><fieldset style="padding-top: 3px">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataKeyNames="NoIjin" DataSourceID="SqlDataSource1" Font-Size="10pt" ForeColor="#333333"
                    GridLines="None" Width="776px" AllowPaging="True" AllowSorting="True" PageSize="15">
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Nrp" HeaderText="Nrp" SortExpression="Nrp" />
                        <asp:BoundField DataField="Tanggal" HeaderText="Tanggal" SortExpression="Tanggal" />
                        <asp:BoundField DataField="Awal" HeaderText="Awal" SortExpression="Awal" />
                        <asp:BoundField DataField="Akhir" HeaderText="Akhir" SortExpression="Akhir" />
                        <asp:BoundField DataField="Keperluan" HeaderText="Keperluan" SortExpression="Keperluan" />
                        <asp:BoundField DataField="Requestor" HeaderText="Requestor" SortExpression="Requestor" />
                        <asp:HyperLinkField DataNavigateUrlFields="NoIjin" DataNavigateUrlFormatString="dIjin.aspx?n={0}"
                            DataTextField="NoIjin" HeaderText="NoIjin" />
                    </Columns>
                    <RowStyle BackColor="#E3EAEB" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView></fieldset>
                &nbsp;&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

