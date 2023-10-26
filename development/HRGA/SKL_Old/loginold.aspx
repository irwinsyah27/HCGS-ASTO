<%@ Page Language="VB" AutoEventWireup="false" CodeFile="loginold.aspx.vb" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center" style="width: 732px" valign="middle">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="2" style="height: 36px">
                                <asp:Image ID="Image1" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="lblUsername" runat="server" Text="UserName" Width="104px"></asp:Label></td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtusername" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="LblPassword" runat="server" Text="Password" Width="104px"></asp:Label></td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" Width="149%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;<asp:Button ID="btnlogin" runat="server" OnClick="btnlogin_Click" Text="Login" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
