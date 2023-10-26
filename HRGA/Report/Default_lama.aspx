<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default_lama.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
            <asp:ListItem> </asp:ListItem>
        </asp:DropDownList>&nbsp;<asp:Button ID="Button1" runat="server" Text="  OK  " /><br />
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 83%">
                    <br />
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="LightGray" Font-Names="Verdana"
                        Font-Size="8pt" Height="500px" Width="99.5%">
                        <LocalReport ReportPath="Report1.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1_QLembur1" />
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetData" TypeName="DataSet1TableAdapters.QLembur1TableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList1" Name="Dept" PropertyName="SelectedValue"
                                Type="String" />
                            <asp:ControlParameter ControlID="TextBox1" Name="Awal" PropertyName="Text" Type="DateTime" />
                            <asp:ControlParameter ControlID="TextBox2" Name="Akhir" PropertyName="Text" Type="DateTime" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
                <td style="width: 17%" valign="top">
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#804000"
                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1"
                        Font-Size="Smaller" ForeColor="#333333" GridLines="None" Width="100%">
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
                            <asp:BoundField DataField="Keterangan" HeaderText="Keterangan" SortExpression="Keterangan" />
                        </Columns>
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Data_absConnectionString %>"
                        SelectCommand="SELECT [Code], [Keterangan] FROM [AbsentCode] Where [Code] <> '-'&#13;&#10;UNION&#13;&#10;SELECT 'WD' As [Code], 'Working Day' As [Keterangan] &#13;&#10;UNION&#13;&#10;SELECT 'TTL' As [Code], 'Total Day' As [Keterangan] &#13;&#10;">
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
        &nbsp;&nbsp;</div>
    </form>
</body>
</html>
