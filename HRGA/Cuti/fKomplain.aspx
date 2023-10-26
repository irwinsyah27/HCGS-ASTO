<%@ Page Language="VB" Debug="TRUE"  AutoEventWireup="false" CodeFile="fKomplain.aspx.vb" Inherits="_fKomplain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Form Dinas</title>
<link rel="alternate" type="application/rss+xml" title="RSS" href="/rss.xml" >
<link rel="stylesheet" type="text/css">
<link rel="stylesheet" type="text/css" href="../css/niftyCor.css">
<link rel="stylesheet" type="text/css" href="../css/niftyPri.css" media="print">

<SCRIPT type="text/javascript" src="../css/prototyp.js"></SCRIPT>
<SCRIPT type="text/javascript" src="../css/ubahgaga.js"></SCRIPT>
<SCRIPT type="text/javascript" src="../css/kuki0000.js"></SCRIPT>
<SCRIPT type="text/javascript" src="../css/nifty000.js"></SCRIPT>
    <link href="" rel="stylesheet" type="text/css" />


    <style type="text/css">
        .style1
        {
            width: 442px;
        }
        .style2
        {
            text-align: left;
            width: 83px;
        }
        .style3
        {
            width: 132px;
        }
        .style4
        {
            width: 83px;
        }
    </style>


</head>
<body>
    <form id="form1" runat="server">
    <div id="div1" style="margin: 0 auto; padding:0; background: #ffcc66; width: 900px; height: 500px;">
    <div>
        <table border="0" cellpadding="5" cellspacing="0" style="width: 100%; height: 100%; border-right: #0066cc 1px solid; border-top: #0066cc 1px solid; border-left: #0066cc 1px solid; border-bottom: #0066cc 1px solid;" id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
            <tr>
                <td valign="top" align="center" style="width: 98%">
                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="FORM SOLUSI PINTAR"></asp:Label><br />
                                            <asp:Label ID="lblNomor" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label></td>
            </tr>
            <tr>
                <td style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; width: 98%; height: 503px;" valign="top">
                    <table border="1" cellpadding="1" cellspacing="0" style="width: 100%">
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="1" style="width: 100%">
                                    <tr>
                                        <td style="height: 19px; text-align: left;" colspan="3">
                                            A. IDENTITAS</td>
                                        <td align="right" style="text-align: center" class="style3">
                                            &nbsp;</td>
                                        <td align="right" colspan="3" style="text-align: center">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="height: 19px; text-align: center;" colspan="3">
                                            Yang Mengalami Masalah</td>
                                        <td align="right" style="text-align: center" class="style3">
                                            &nbsp;</td>
                                        <td align="right" colspan="3" style="text-align: center">
                                            Yang Menyampaikan</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 161px; height: 19px">
                                            <asp:Label ID="Label22" runat="server" Text="Nrp" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="Label23" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="width: 292px">
                                            <asp:TextBox ID="txtNrp" runat="server" Width="104px" AutoPostBack="True" ValidationGroup="kosong"></asp:TextBox>
                                            <A onclick="window.open('PopupNrp.aspx?FormName=' + document.forms[0].name + '&textbox=txtNrp','PopupClass','width=390,height=400,left=300,top=100')"
		            href="javascript:;"><IMG src="Images/GoLtrHS.png" border="0" id="IMG3" runat="server" align="absMiddle" height="16" width="16"></A>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNrp"
                                                ErrorMessage="Mohon diisi..."></asp:RequiredFieldValidator></td>
                                        <td align="right" class="style3">
                                            &nbsp;</td>
                                        <td class="style2">
                                            Nrp</td>
                                        <td align="center" style="width: 20px; height: 19px">
                                            <asp:Label ID="Label16" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 100px; height: 19px">
                                            <asp:Label ID="lblNrp1" runat="server" Font-Size="10pt" Width="170px"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 19px; width: 161px;">
                                            <asp:Label ID="Label1" runat="server" Text="Nama" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="Label6" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="width: 292px">
                                            <asp:Label ID="lblNama" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td align="right" valign="top" class="style3">
                                            &nbsp;</td>
                                        <td align="right" valign="top" class="style4" style="text-align: left">
                                            Nama</td>
                                        <td style="width: 20px; height: 19px" align="center">
                                            <asp:Label ID="Label12" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 100px; height: 19px">
                                            <asp:Label ID="lblNama1" runat="server" Font-Size="10pt"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 24px; width: 161px;">
                                            <asp:Label ID="Label2" runat="server" Text="Jabatan / Dept "></asp:Label></td>
                                        <td align="center" style="width: 28px; height: 24px">
                                            <asp:Label ID="Label7" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="height: 24px; width: 292px;">
                                            <asp:Label ID="lblJabatan" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td align="right" valign="top" class="style3">
                                            &nbsp;</td>
                                        <td align="right" valign="top" class="style4">
                                            <asp:Label ID="Label17" runat="server" Text="Jabatan / Dept " Width="88px" 
                                                style="text-align: left"></asp:Label></td>
                                        <td style="width: 20px;" align="center" valign="top">
                                            <asp:Label ID="Label13" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 100px;" valign="top">
                                            <asp:Label ID="lblJabatan1" runat="server" Font-Size="10pt" Width="180px"></asp:Label></td>
                                    </tr>
                                    </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table border="1" cellpadding="2" cellspacing="0" style="width: 100%">
                        <tr>
                            <td valign="top" class="style1">
                                <table border="0" cellpadding="0" cellspacing="1" style="width: 100%">
                                    <tr>
                                        <td align="right" colspan="2" style="text-align: center">
                                            <asp:Label ID="Label43" runat="server" Text="Komplain yg pernah diajukan" 
                                                Width="209px"></asp:Label></td>
                                        <td align="right" style="width: 100px">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label41" runat="server" Text="Open : " Width="152px"></asp:Label></td>
                                        <td style="width: 106%" align="right">
                                            <asp:Label ID="lblSisaOpen" runat="server" Font-Size="10pt"></asp:Label>&nbsp;kali</td>
                                        <td align="right" style="width: 100px">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="height: 19px">
                                            <asp:Label ID="Label39" runat="server" Text="Close : " Width="152px"></asp:Label></td>
                                        <td style="width: 106%;" align="right">
                                            <asp:Label ID="lblClose" runat="server" Font-Size="10pt"></asp:Label>
                                            &nbsp;kali</td>
                                        <td align="right" style="width: 100px; height: 19px">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="height: 19px">
                                            <asp:Label ID="Label42" runat="server" Text="Total Pengajuan : " 
                                                Width="152px"></asp:Label></td>
                                        <td align="right" style="width: 106%">
                                            <asp:Label ID="lblTotalKomplain" runat="server" Font-Size="10pt"></asp:Label>&nbsp;kali</td>
                                        <td align="right" style="width: 100px; height: 19px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="height: 19px">
                                            &nbsp;</td>
                                        <td style="width: 106%;" align="right">
                                            &nbsp;</td>
                                        <td align="right" style="width: 100px; height: 19px">
                                            </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top" style="width: 390px;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top" style="height: 117px">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <caption align="left">
                                        B. PENJELASAN PENGAJUAN</caption>
                                    <tr>
                                        <td style="height: 24px; text-align: center;">
                                            <asp:Label ID="Label40" runat="server" Text="Deskripsi Masalah"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 19px">
                                            <asp:TextBox ID="txtKeterangan" runat="server" Width="80%" TextMode="MultiLine" 
                                                Height="100px" style="text-align: left"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtKeterangan"
                                                ErrorMessage="Mohon diisi..."></asp:RequiredFieldValidator></td>
                                    </tr>
									<tr>
                                        <td style="height: 24px; text-align: center;">
                                            <asp:Label ID="LabelSolusiPintar" runat="server" Text="Solusi Pintar"></asp:Label></td>
                                    </tr>
									 <tr>
                                        <td style="height: 19px">
                                            <asp:TextBox ID="txtSolusi" runat="server" Width="80%" TextMode="MultiLine" 
                                                Height="100px" style="text-align: left"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorSolusi" runat="server" ControlToValidate="txtSolusi"
                                                ErrorMessage="Mohon diisi..."></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 19px">
                                            Ditujukan Ke (PIC - HCGS) :
                                            <asp:DropDownList ID="txtTujuan" runat="server">
                                                <asp:ListItem>HR</asp:ListItem>
                                                <asp:ListItem>PERS</asp:ListItem>
                                                <asp:ListItem>GA</asp:ListItem>
                                                <asp:ListItem>ALL HCGS</asp:ListItem>
                                            </asp:DropDownList>
                                                </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 19px">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="height: 19px">
                                            <asp:Button ID="btSave" runat="server" Text=" Sampaikan ke Atasan" />
                                            </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                                </td>
            </tr>
        </table>
    </div>
    </div>
    </form>
    <script language="javascript" type="text/javascript">
     if(NiftyCheck()) {
	    Rounded("div#div1","all","#ffffff","#0066cc");
    }
	</script>
</body>
</html>
