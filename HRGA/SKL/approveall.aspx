<%@ Page Language="VB" Debug="TRUE" AutoEventWireup="false" CodeFile="approveall.aspx.vb" Inherits="_approveall" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">   
    <title>APPROVE SKL PERTANGGAL</title>
    <link rel="alternate" type="application/rss+xml" title="RSS" href="/rss.xml" >
    <link rel="stylesheet" type="text/css">
    <link rel="stylesheet" type="text/css" href="../css/niftyCor.css">
    <link rel="stylesheet" type="text/css" href="../css/niftyPri.css" media="print">
    
    <SCRIPT type="text/javascript" src="../css/prototyp.js"></SCRIPT>
    <SCRIPT type="text/javascript" src="../css/ubahgaga.js"></SCRIPT>
    <SCRIPT type="text/javascript" src="../css/kuki0000.js"></SCRIPT>
    <SCRIPT type="text/javascript" src="../css/nifty000.js"></SCRIPT>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td colspan="4" style="height: 58px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3" style="border-right: black 2px solid; border-top: black 2px solid;
                    font-weight: normal; text-transform: uppercase; border-left: black 2px solid;
                    color: blue; font-family: 'Berlin Sans FB'; height: 19px; background-color: lemonchiffon;
                    text-decoration: underline">
                    APPROVE PENGAJUAN SKL PER PERIODE</td>
                <td style="height: 19px">
                </td>
            </tr>
        
            <tr>
                <td colspan="3" style="border-right: black 2px solid; border-top: black 2px solid;
                    font-weight: bold; text-transform: uppercase; border-left: black 2px solid; color: maroon;
                    border-bottom: silver 1px dashed; font-family: 'Baskerville Old Face', Fantasy;
                    height: 29px; background-color: silver; text-decoration: underline">
                    APPROVAL</td>
                <td style="height: 29px">
                </td>
            </tr>
			   <tr>
                <td style="border-left: black 2px solid; width: 20%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:Label ID="lblAwal" runat="server" Text="Awal" Width="100%"></asp:Label></td>
                <td align="center" style="border-bottom: maroon 1px solid; background-color: floralwhite">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                        Text=":" Width="100%"></asp:Label></td>
                <td style="border-right: black 2px solid; width: 70%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:TextBox ID="txtAwal" runat="server" Width="136px" AutoPostBack="True"></asp:TextBox>
                    <A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=txtAwal','PopupClass','width=215,height=195,left=330,top=300')"
            href="javascript:;"><IMG src="../Images/Calendar.png" border="0" id="IMGAwal" runat="server" align="absMiddle" height="20" width="20"></A>
                
                </td>
                <td style="height: 19px">
                </td>
            </tr>
            <tr>
                <td style="border-left: black 2px solid; width: 20%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:Label ID="lblAkhir" runat="server" Text="Akhir" Width="100%"></asp:Label></td>
                <td align="center" style="border-bottom: maroon 1px solid; background-color: floralwhite">
                    <asp:Label ID="lblakhir2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                        Text=":" Width="100%"></asp:Label></td>
                <td style="border-right: black 2px solid; width: 100%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:TextBox ID="txtAkhir" runat="server" Width="136px" AutoPostBack="True"></asp:TextBox>
                    <A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=txtAkhir','PopupClass','width=215,height=195,left=330,top=300')"
            href="javascript:;"><IMG src="../Images/Calendar.png" border="0" id="IMGAkhir" runat="server" align="absMiddle" height="20" width="20"></A>
                  </td>          
            </tr>

            <tr>
                <td style="border-left: black 2px solid; width: 20%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:Label ID="lblDept1" runat="server" Text="Dept" Width="100%"></asp:Label></td>
                <td align="center" style="border-bottom: maroon 1px solid; background-color: floralwhite">
                    <asp:Label ID="lblDept2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                        Text=":" Width="100%"></asp:Label></td>
                <td style="border-right: black 2px solid; width: 100%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:DropDownList ID="txtDepartemen" runat="server" AutoPostBack="True" 
                       DataSourceID="SqlDataDept" DataTextField="Departemen" DataValueField="Departemen">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataDept" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                        SelectCommand="SELECT DISTINCT [Departemen] FROM [tblKaryawan] UNION SELECT '' AS  [Departemen]">
                    </asp:SqlDataSource>
                </td>          
            </tr>


            <tr>
                <td style="border-left: black 2px solid; width: 20%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:Label ID="Label101" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                    Text="" Width="100%"></asp:Label></td>
                </td>
                <td align="center" style="border-bottom: maroon 1px solid; background-color: floralwhite">
                    <asp:Label ID="Label100" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                        Text="" Width="100%"></asp:Label></td>
                <td style="border-right: black 2px solid; width: 100%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:Button ID="btSave" runat="server" Text="  Approve  " />  
                
                </td>
                <td style="height: 19px">
                </td>
                   
            </tr>

    </div>
    </form>
</body>
</html>
