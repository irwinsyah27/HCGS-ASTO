<%@ Page Language="VB" AutoEventWireup="false" CodeFile="tglLembur.aspx.vb" Inherits="HRGA_Report_tglLembur" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 100px; text-align: right" valign="top">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="10pt"
                        Text="Awal :"></asp:Label></td>
                <td style="width: 6px">
                </td>
                <td style="width: 334px">
                    <asp:TextBox ID="txtAwal" runat="server"></asp:TextBox>&nbsp;<asp:ImageButton ID="ImageButton1"
                        runat="server" ImageUrl="~/HRGA/Report/Images/Calendar.png" />
                    <asp:Calendar ID="CalAwal" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px"
                        Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth"
                        Visible="False" Width="350px">
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True"
                            Font-Size="12pt" ForeColor="#333399" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: right" valign="top">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="10pt"
                        Text="Akhir :"></asp:Label></td>
                <td style="width: 6px">
                </td>
                <td style="width: 334px">
                    <asp:TextBox ID="txtAkhir" runat="server"></asp:TextBox>&nbsp;<asp:ImageButton ID="ImageButton2"
                        runat="server" ImageUrl="~/HRGA/Report/Images/Calendar.png" />
                    <asp:Calendar ID="CalAkhir" runat="server" BackColor="White" BorderColor="White"
                        BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px"
                        NextPrevFormat="FullMonth" Visible="False" Width="350px">
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True"
                            Font-Size="12pt" ForeColor="#333399" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 6px">
                </td>
                <td style="width: 334px">
                    <asp:Button ID="Button1" runat="server" Text="    OK     " /></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
