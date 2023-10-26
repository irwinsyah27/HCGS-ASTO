<%@ Page Language="VB" debug="true" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <div style="text-align: center">
            <table border="0" cellpadding="0" cellspacing="0" style="border-right: #6699ff 1px solid;
                border-top: #6699ff 1px solid; border-left: #6699ff 1px solid; border-bottom: #6699ff 1px solid">
                <tr>
                    <td colspan="3" style="border-bottom: #6699ff 1px solid; height: 149px; background-color: whitesmoke;">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/getimage4.gif" />
                        <br />
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="Silver"
                            Text="HRPGA Online" Width="200px"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" style="width: 100px">
                        UserID
                    </td>
                    <td style="width: 18px">
                        :</td>
                    <td align="left" style="width: 100px">
                        <asp:TextBox ID="txtUserid" runat="server" Width="120px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" style="width: 100px">
                        Password
                    </td>
                    <td style="width: 18px">
                        :</td>
                    <td align="left" style="width: 100px">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="120px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" style="width: 100px">
                        Domain</td>
                    <td style="width: 18px">
                    </td>
                    <td align="left" style="width: 100px">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>PAMAPERSADA</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="center" colspan="3" style="height: 27px">
                        <asp:Button ID="Button1" runat="server" Text="  Login  " /></td>
                </tr>
            </table>
        </div>
    </div>
        <asp:Label ID="Label5" runat="server" ForeColor="Blue"></asp:Label>
    </form>
</body>
</html>
