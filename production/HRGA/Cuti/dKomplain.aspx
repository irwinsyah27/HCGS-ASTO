<%@ Page Language="VB" Debug="TRUE"  AutoEventWireup="false" CodeFile="dKomplain.aspx.vb" Inherits="_dKomplain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Form Cuti</title>
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
            width: 17px;
        }
        .style2
        {
            height: 20px;
            width: 17px;
        }
        .style3
        {
            text-align: right;
        }
        .style4
        {
            width: 166px;
        }
        .style5
        {
            height: 20px;
            width: 166px;
        }
        .style6
        {
            text-align: left;
            width: 200px;
        }
        .style7
        {
            height: 19px;
            width: 14%;
            text-align: left;
        }
        .style8
        {
            height: 24px;
            width: 14%;
            text-align: left;
        }
        .style9
        {
            width: 14%;
            text-align: left;
        }
        .style12
        {
            height: 24px;
            width: 14%;
        }
    </style>


</head>
<body>
    <form id="form1" runat="server">
    <div id="div1" style="margin: 0 auto; padding:0; background: #ffcc66; width: 900px; height: 100%;">
    <div>
        <table border="0" cellpadding="5" cellspacing="0" style="width: 100%; height: 100%" id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
            <tr>
                <td valign="top" align="center" style="width: 98%">
                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="SOLUSI PINTAR"></asp:Label><br />
                                            <asp:Label ID="lblNomor" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label></td>
            </tr>
            <tr>
                <td style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; width: 98%;" valign="top">
                    <table border="1" cellpadding="1" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="background-color: gainsboro; text-align: right;">
                                <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="Dibuat oleh : " 
                                    ForeColor="#FF6633"></asp:Label>
                                <asp:Label ID="lblDibuatOleh" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="#FF6633"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="1" style="width: 100%">
                                    <tr>
                                        <td style="height: 19px" colspan="3">
                                            A. IDENTITAS</td>
                                        <td align="right" colspan="3" style="text-align: center">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="height: 19px; text-align: center;" colspan="3">
                                            Yang Mengalami Masalah</td>
                                        <td align="right" colspan="3" style="text-align: center">
                                            Yang Menyampaikan</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 161px; height: 19px">
                                            <asp:Label ID="Label22" runat="server" Text="Nrp" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="Label23" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="width: 262px">
                                            <asp:Label ID="lblNrp" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td class="style6">
                                            <asp:Label ID="Label11" runat="server" Text="Nrp" Width="91px"></asp:Label></td>
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
                                        <td align="left" style="width: 262px">
                                            <asp:Label ID="lblNama" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td valign="top" class="style6">
                                            <asp:Label ID="Label19" runat="server" Text="Nama" Width="91px"></asp:Label></td>
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
                                        <td align="left" style="height: 24px; width: 262px;">
                                            <asp:Label ID="lblJabatan" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td valign="top" class="style6">
                                            <asp:Label ID="Label17" runat="server" Text="Jabatan / Dept" Width="91px"></asp:Label></td>
                                        <td style="width: 20px;" align="center" valign="top">
                                            <asp:Label ID="Label13" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 100px;" valign="top">
                                            <asp:Label ID="lblJabatan1" runat="server" Font-Size="10pt" Width="173px"></asp:Label></td>
                                    </tr>
                                    </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table border="1" cellpadding="2" cellspacing="0" style="width: 100%">
                        <tr>
                            <td valign="top">
                                <table border="0" cellpadding="0" cellspacing="1" 
                                    style="width: 73%; height: 120px;">
                                    <tr>
                                        <td style="text-align: center;" colspan="3">
                                            <asp:Label ID="Label50" runat="server" Text="Komplain yg pernah diajukan" 
                                                Width="191px"></asp:Label>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="style4">
                                            <asp:Label ID="Label51" runat="server" Text="Open" Width="102px"></asp:Label>
                                            </td>
                                        <td align="right" class="style1">
                                            :</td>
                                        <td align="left" style="text-align: right">
                                            <asp:Label ID="lblOpen" runat="server" Font-Size="10pt"></asp:Label>&nbsp;kali</td>
                                    </tr>
                                    <tr>
                                        <td class="style5">
                                            <asp:Label ID="Label52" runat="server" Text="Close" Width="109px"></asp:Label>
                                            </td>
                                        <td align="right" class="style1">
                                            :</td>
                                        <td style="height: 20px" class="style3">
                                            <asp:Label ID="lblClose" runat="server" Font-Size="10pt"></asp:Label>
                                            &nbsp;kali</td>
                                    </tr>
                                    <tr>
                                        <td class="style5">
                                            <asp:Label ID="Label53" runat="server" Text="Total Pengajuan" Width="111px"></asp:Label>
                                            </td>
                                        <td align="right" class="style2">
                                            :</td>
                                        <td style="height: 20px" class="style3">
                                            <asp:Label ID="lblTotalKomplain" runat="server" Font-Size="10pt"></asp:Label>&nbsp;kali</td>
                                    </tr>
                                    <tr>
                                        <td class="style5">
                                            </td>
                                        <td align="right" class="style2">
                                            :</td>
                                        <td align="left" style="height: 20px">
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
                                        <td style="height: 24px; text-align: center;" colspan="2">
                                            &nbsp;<A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=txtAkhir','PopupClass','width=215,height=195,left=330,top=300')"
		                            href="javascript:;"></A>
                                            <asp:Label ID="Label40" runat="server" Text="Deskripsi Masalah"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 19px;" colspan="2">
                                            <asp:TextBox ID="txtKeterangan" runat="server" Width="80%" Enabled="False" 
                                                TextMode="MultiLine" Height="100px"></asp:TextBox>
                                            </td>
                                    </tr>
									<tr>
									<td style="height: 24px; text-align: center;" colspan="2">
										<asp:Label ID="LabelSolusiPintar" runat="server" Text="Solusi Pintar"></asp:Label>
									</td>
                                    </tr>
									 <tr>
                                        <td style="height: 19px;" colspan="2">
                                            <asp:TextBox ID="txtSolusi" runat="server" Width="80%" Enabled="False" 
                                                TextMode="MultiLine" Height="100px"></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 19px" colspan="2">
                                            PIC :
                                            <asp:DropDownList ID="txtPIC" runat="server" Enabled="False">
                                                <asp:ListItem>HR</asp:ListItem>
                                                <asp:ListItem>PERS</asp:ListItem>
                                                <asp:ListItem>GA</asp:ListItem>
                                                <asp:ListItem>ALL HRPGA</asp:ListItem>
                                            </asp:DropDownList>
                                                </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px">
                                            &nbsp;</td>
                                        <td style="height: 19px">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px">
                                            &nbsp;</td>
                                        <td style="height: 19px">
                                            <asp:Button ID="btSave" runat="server" Text="  Simpan  " />
                                            <asp:Button ID="btUpdate" runat="server" Text="  Update   " Visible="False" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Panel ID="PanelAtasan" runat="server" Height="120px" Width="100%" Wrap="False">
                        <table border="0" cellpadding="0" cellspacing="0" style="border-right: #3366cc 1px solid;
                            border-top: #3366cc 1px solid; border-left: #3366cc 1px solid; width: 100%; border-bottom: #3366cc 1px solid;
                            background-color: azure">
                            <tr>
                                <td class="style9">
                                    <asp:Label ID="Label43" runat="server" Text="Tanggal"></asp:Label></td>
                                <td class="style9">
                                    &nbsp;:
                                </td>
                                <td style="width: 100%; height: 19px">
                                    &nbsp;<asp:Label ID="lblTg1" runat="server" Font-Bold="True" Font-Italic="False"
                                        Font-Size="10pt"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    <asp:Label ID="Label41" runat="server" Text="Atasan"></asp:Label></td>
                                <td class="style9">
                                    &nbsp;:
                                </td>
                                <td style="width: 100%; height: 19px">
                                    &nbsp;<asp:Label ID="lblHrga" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    Persetujuan</td>
                                <td class="style9">
                                    &nbsp;:
                                </td>
                                <td style="width: 100%; height: 19px">
                                    <asp:RadioButton ID="ckSetuju" runat="server" GroupName="Persetujuan" 
                                        Text="Menyetujui" Width="94px" />
                                    <asp:RadioButton ID="ckTidakSetuju" runat="server" GroupName="Persetujuan" 
                                        Text="Tidak Menyetujui" Width="132px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    <asp:Label ID="Label45" runat="server" Text="Catatan"></asp:Label></td>
                                <td class="style9">
                                    &nbsp;:
                                </td>
                                <td style="width: 100%; height: 19px">
                                    &nbsp;<asp:TextBox ID="txtCatatanHrga" runat="server" Width="376px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCatatanHrga"
                                        ErrorMessage="Harap diisi.."></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td style="text-align: right" class="style12">
                                </td>
                                <td class="style12" style="text-align: right">
                                    &nbsp;</td>
                                <td style="width: 100%; height: 24px">
                                    &nbsp;<asp:Button ID="btnRevisi" runat="server" OnClientClick="DoClick()" Text="  Revisi  "
                                        Visible="False" />
                                    <asp:Button ID="btnSetujuHrga" runat="server" Text="    OK    " />&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelHRPGA" runat="server" Height="200px" Visible="False" Width="100%">
                        <table border="0" cellpadding="0" cellspacing="0" style="border-right: #3366cc 1px solid;
                            border-top: #3366cc 1px solid; border-left: #3366cc 1px solid; width: 100%; border-bottom: #3366cc 1px solid;
                            background-color: beige">
                            <tr>
                                <td class="style7">
                                    <asp:Label ID="Label44" runat="server" Text="Tanggal"></asp:Label></td>
                                <td class="style7">
                                    &nbsp;:
                                </td>
                                <td style="width: 100%; height: 19px">
                                    &nbsp;<asp:Label ID="lblTg2" runat="server" Font-Bold="True" Font-Italic="False"
                                        Font-Size="10pt"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    <asp:Label ID="Label47" runat="server" Text="PIC - HRPGA"></asp:Label></td>
                                <td class="style7">
                                    &nbsp;:
                                </td>
                                <td style="width: 100%; height: 19px">
                                    &nbsp;<asp:Label ID="lblPM" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="style8">
                                    <asp:Label ID="Label49" runat="server" Text="Catatan"></asp:Label></td>
                                <td class="style8">
                                    &nbsp;:
                                </td>
                                <td style="width: 100%; height: 24px">
                                    &nbsp;<asp:TextBox ID="txtCatatanPM" runat="server" Width="71%" Height="100px" 
                                        TextMode="MultiLine"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCatatanPM"
                                        ErrorMessage="Harap diisi.."></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td class="style9">
                                </td>
                                <td class="style9">
                                    &nbsp;</td>
                                <td style="width: 100%; height: 19px">
                                    &nbsp;<asp:Button ID="btnSetujuPM" runat="server" Text="    OK    " /></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel4" runat="server" Height="100px" Visible="False" Width="100%">
                        <table border="0" cellpadding="0" cellspacing="0" style="border-right: #3366cc 1px solid;
                            border-top: #3366cc 1px solid; border-left: #3366cc 1px solid; width: 100%; border-bottom: #3366cc 1px solid;
                            background-color: beige">
                            <tr>
                                <td style="width: 37%; height: 19px; text-align: right">
                                </td>
                                <td style="width: 100%; height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 37%; height: 19px; text-align: right" valign="middle">
                                    <asp:Label ID="Label48" runat="server" Text="Personnel Admin : "></asp:Label></td>
                                <td style="width: 100%; height: 19px" valign="middle">
                                    &nbsp;<asp:Label ID="lblPersonnelAdmin" runat="server" Font-Bold="True"></asp:Label>&nbsp;<asp:Button
                                        ID="btnPrint" runat="server" Text="Print Preview" /></td>
                            </tr>
                            <tr>
                                <td style="width: 37%; text-align: right">
                                </td>
                                <td style="width: 100%; height: 19px">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                    .</td>
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
