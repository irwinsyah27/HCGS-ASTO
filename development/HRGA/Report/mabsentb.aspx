<%@ Page Language="VB" Debug="true"  AutoEventWireup="false" CodeFile="mabsentb.aspx.vb" Inherits="mabsentb" %>

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
        <strong>dari :</strong>
        <asp:TextBox ID="TextBox1" runat="server" BackColor="FloralWhite"></asp:TextBox>
        <strong>s/d</strong>
        <asp:TextBox ID="TextBox2" runat="server" BackColor="FloralWhite"></asp:TextBox>
        <strong>dept :</strong>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" BackColor="FloralWhite">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>PROD</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="  OK  " /><br />
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 83%" valign="top">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                        Height="513px" Visible="False" Width="100%">
                        <LocalReport ReportPath="HRGA\Report\Report2.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet2_SP_ABS_CODE" />
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetData" TypeName="DataSet2TableAdapters.SP_ABS_CODETableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TextBox1" Name="Awal" PropertyName="Text" Type="DateTime" />
                            <asp:ControlParameter ControlID="TextBox2" Name="Akhir" PropertyName="Text" Type="DateTime" />
                            <asp:ControlParameter ControlID="DropDownList1" Name="Dept" PropertyName="SelectedValue"
                                Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
                <td style="width: 17%" valign="top">
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
                        SelectCommand="SELECT [Code], [Keterangan] FROM [AbsentCode] Where [Code] <> '-'&#13;&#10;UNION&#13;&#10;SELECT 'OWD' As [Code], 'Working Day' As [Keterangan] &#13;&#10;UNION&#13;&#10;SELECT 'TTL' As [Code], 'Total Day' As [Keterangan] &#13;&#10;">
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
        <br />
        &nbsp; &nbsp;<br />
    
    </div>
    </form>
</body>
</html>
