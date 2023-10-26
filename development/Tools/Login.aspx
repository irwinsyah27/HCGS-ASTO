<%@ Page Language="VB" debug="true" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<link href="style.css" rel="stylesheet" type="text/css" />
    <title>KPP-MINING Site Rantau</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <div style="text-align: center">
            <table border="0" cellpadding="0" cellspacing="0" style="border-right: #6699ff 1px solid;
                border-top: #6699ff 1px solid; border-left: #6699ff 1px solid; border-bottom: #6699ff 1px solid">
                <tr>
                    <td colspan="3" style="border-bottom: #6699ff 1px solid; height: 149px; background-color: transparent;">
                        <asp:Image ID="Image1" runat="server" ImageUrl="./Images/Logo_KPP2.JPG" />
                        <br />
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="Silver"
                            Text="KPP Index Rantau" Width="200px" style="background-color: transparent"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" style="width: 100px; color: gray;">
                        UserID
                    </td>
                    <td style="width: 18px">
                        :</td>
                    <td align="left" style="width: 100px">
                        <asp:TextBox ID="txtUserid" runat="server" Width="120px" style="color: gray"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" style="width: 100px; color: gray;">
                        Password
                    </td>
                    <td style="width: 18px; color: gray;">
                        :</td>
                    <td align="left" style="width: 100px">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="120px" style="color: gray"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" style="width: 100px; color: gray;">
                        Domain</td>
                    <td style="width: 18px">
                        :</td>
                    <td align="left" style="width: 100px">
                        <asp:DropDownList ID="DropDownList1" runat="server" style="color: gray">
                            <asp:ListItem>KPPMININIG</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="center" colspan="3" style="height: 27px">
                        <asp:Button ID="Button1" runat="server" Text="  Login  " style="color: gray" /></td>
                </tr>
            </table>
        </div>
    </div>
        <asp:Label ID="Label5" runat="server" ForeColor="Blue"></asp:Label>
    </form>
</body>
</html>
