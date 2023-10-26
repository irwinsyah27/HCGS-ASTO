<%@ Page Language="VB" debug="true" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<link href="http://pabbapco401.kppmining.net/Tools/style.css" rel="stylesheet" type="text/css" />
    <title>KPP ASTO</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <div style="text-align: center">
          <div id="login">
           
            <div id="title">
              <p>PT Kalimantan Prima Persada</p>
              <p>ASTO</p>
             
            </div>
            
            <div class="item">
                UserID</div>
            <div class="input">
              <asp:TextBox ID="txtUserid" runat="server" ></asp:TextBox>
            </div>
            
            <div class="item">Password</div>
            <div class="input">
              <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ></asp:TextBox>
            </div>
			<div class="item2">
              <asp:DropDownList ID="DropDownList1" runat="server" >
                            <asp:ListItem>KPPMINING</asp:ListItem>
              </asp:DropDownList>
              </div>
			  
              <div class="item2" >
              <asp:Image ID="Button" onmouseover='this.src=&quot;http://pabbapco401.kppmining.net/img/login_hover.png&quot;' 
onmouseout='this.src=&quot;http://pabbapco401.kppmining.net/img/login.png&quot;'
type="image" runat="server"
src="http://pabbapco401.kppmining.net/img/login.png" border="0" title="Tekan Enter" alt="Log-In" />
                </div><asp:Button ID="Button1" runat="server" Text="" />
      </div>
    </div> 
    </form>
<asp:Label ID="Label5" runat="server" ForeColor="Blue"></asp:Label>
</body>
</html>
