<%@ Page Language="VB" Debug="TRUE"  AutoEventWireup="false" CodeFile="dDinasLS.aspx.vb" Inherits="HRGA_Cuti_dDinasLS" %>

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
</head>
<body>
    <form id="form1" runat="server">
    <div id="div1" style="margin: 0 auto; padding:0; background: #ccccff; width: 900px; height: 500px;">
    <div>
       <table border="0" cellpadding="5" cellspacing="0" style="width: 100%; height: 100%; border-right: #0066cc 1px solid; border-top: #0066cc 1px solid; border-left: #0066cc 1px solid; border-bottom: #0066cc 1px solid;" id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
            <tr>
                <td valign="top" align="center" style="width: 98%">
                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="SURAT DINAS "></asp:Label><br />
                                            <asp:Label ID="lblNomor" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label></td>
            </tr>
            <tr>
                <td style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; width: 98%;" valign="top">
                    <table border="1" cellpadding="1" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="background-color: gainsboro">
                                <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="Diberikan Kepada :"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="1" style="width: 100%">
                                    <tr>
                                        <td style="width: 161px; height: 19px">
                                            <asp:Label ID="Label22" runat="server" Text="Nrp" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="Label23" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="width: 262px">
                                            <asp:Label ID="lblNrp" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td align="right">
                                            <asp:Label ID="Label11" runat="server" Text="Periode Tugas" Width="102px"></asp:Label></td>
                                        <td align="center" style="width: 20px; height: 19px">
                                            <asp:Label ID="Label16" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 100px; height: 19px">
                                            <asp:Label ID="lblPeriodeTugas" runat="server" Font-Size="10pt" Width="200px"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 19px; width: 161px;">
                                            <asp:Label ID="Label1" runat="server" Text="Nama" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="Label6" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="width: 262px">
                                            <asp:Label ID="lblNama" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td align="right" valign="top">
                                            <asp:Label ID="Label19" runat="server" Text="No. Telp / Hp" Width="91px"></asp:Label></td>
                                        <td style="width: 20px; height: 19px" align="center">
                                            <asp:Label ID="Label12" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 100px; height: 19px">
                                            <asp:Label ID="lblNoTelp" runat="server" Font-Size="10pt" Width="200px"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 24px; width: 161px;">
                                            <asp:Label ID="Label2" runat="server" Text="Jabatan / Dept "></asp:Label></td>
                                        <td align="center" style="width: 28px; height: 24px">
                                            <asp:Label ID="Label7" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="height: 24px; width: 262px;">
                                            <asp:Label ID="lblJabatan" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td align="right" rowspan="4" valign="top">
                                            <asp:Label ID="Label17" runat="server" Text="Alamat di site" Width="91px"></asp:Label></td>
                                        <td style="width: 20px;" align="center" rowspan="4" valign="top">
                                            <asp:Label ID="Label13" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 100px;" rowspan="4" valign="top">
                                            <asp:Label ID="lblAlamatdiSite" runat="server" Font-Size="10pt" Width="200px"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 161px; height: 19px;">
                                            <asp:Label ID="Label3" runat="server" Text="Status Penerimaan" Width="120px"></asp:Label></td>
                                        <td align="center" style="width: 28px; height: 19px;">
                                            <asp:Label ID="Label8" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="width: 262px; height: 19px;">
                                            <asp:Label ID="lblStatusPenerimaan" runat="server" Font-Size="10pt"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 161px">
                                            <asp:Label ID="Label4" runat="server" Text="Status Perkawinan"></asp:Label></td>
                                        <td align="center" style="width: 28px">
                                            <asp:Label ID="Label9" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="width: 262px">
                                            <asp:Label ID="lblStatusKawin" runat="server" Font-Size="10pt"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 24px; width: 161px;">
                                            <asp:Label ID="Label5" runat="server" Text="Bawa Keluarga"></asp:Label></td>
                                        <td align="center" style="width: 28px; height: 24px">
                                            <asp:Label ID="Label10" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="width: 262px; height: 24px">
                                            <asp:Label ID="lblBawaKeluarga" runat="server" Font-Size="10pt"></asp:Label></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table border="1" cellpadding="2" cellspacing="0" style="width: 100%">
                        <tr>
                            <td valign="top">
                                <table border="0" cellpadding="0" cellspacing="1" style="width: 100%">
                                    <tr>
                                        <td style="width: 100px">
                                            </td>
                                        <td align="right" style="width: 212px">
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 20px">
                                            </td>
                                        <td align="right" style="width: 212px;">
                                            &nbsp;</td>
                                        <td align="left" style="height: 20px">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 20px">
                                            </td>
                                        <td align="right" style="width: 212px; height: 20px">
                                            &nbsp;</td>
                                        <td align="left" style="height: 20px">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 20px">
                                            </td>
                                        <td align="right" style="width: 212px; height: 20px">
                                            &nbsp;</td>
                                        <td align="left" style="height: 20px">
                                            </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top" style="width: 390px;">
                                <table border="0" cellpadding="0" cellspacing="1" style="width: 100%">
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label24" runat="server" Text="Periode Cuti Tahunan : " Width="152px"></asp:Label></td>
                                        <td style="width: 106%" align="right">
                                            &nbsp;<asp:Label ID="lblSisaCuti1" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td align="right" style="width: 100px">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="height: 19px">
                                            <asp:Label ID="Label25" runat="server" Text="Cuti Tahunan : " Width="152px"></asp:Label></td>
                                        <td style="width: 106%;" align="right">
                                            <asp:Label ID="lblSisaCuti2" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td align="right" style="width: 100px; height: 19px">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="height: 19px">
                                            <asp:Label ID="Label39" runat="server" Text="Cuti Besar : " Width="152px"></asp:Label></td>
                                        <td align="right" style="width: 106%">
                                            <asp:Label ID="lblCutiBesar" runat="server" Font-Size="10pt"></asp:Label>
                                            <asp:Label ID="lblHariCBesar" runat="server" Font-Size="10pt">hari</asp:Label></td>
                                        <td align="right" style="width: 100px; height: 19px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="height: 19px">
                                            </td>
                                        <td style="width: 106%;" align="right">
                                            &nbsp;</td>
                                        <td align="right" style="width: 100px; height: 19px">
                                            </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top" style="height: 117px">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <caption align="left">
                                        PERIODE DINAS :</caption>
                                    <tr>
                                        <td style="width: 30px; height: 24px;">
                                            <asp:Label ID="Label33" runat="server" Text="Awal" Width="104px"></asp:Label></td>
                                        <td style="width: 47%; height: 24px;">
                                            <asp:TextBox ID="txtAwal" runat="server" Width="136px" AutoPostBack="True" Enabled="False"></asp:TextBox></td>
                                        <td style="width: 100%; height: 24px;">
                                            &nbsp;<A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=txtAkhir','PopupClass','width=215,height=195,left=330,top=300')"
		                            href="javascript:;"></A>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px;">
                                            <asp:Label ID="Label34" runat="server" Text="Akhir" Width="104px"></asp:Label></td>
                                        <td colspan="1" style="height: 19px">
                                            <asp:TextBox ID="txtAkhir" runat="server" Width="136px" Enabled="False"></asp:TextBox></td>
                                        <td colspan="2" style="height: 19px">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px" valign="top">
                                            <asp:Label ID="Label38" runat="server" Text="Keterangan" Width="104px"></asp:Label></td>
                                        <td colspan="2" style="height: 19px">
                                            <asp:TextBox ID="txtKeterangan" runat="server" Width="80%" Enabled="False" TextMode="MultiLine"></asp:TextBox>
                                            <asp:Button ID="btSave" runat="server" Text="  Simpan  " />
                                            </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Panel ID="Panel2" runat="server" Height="50px" Width="100%">
                        <table border="0" cellpadding="0" cellspacing="0" style="border-right: #3366cc 1px solid;
                            border-top: #3366cc 1px solid; border-left: #3366cc 1px solid; width: 100%; border-bottom: #3366cc 1px solid;
                            background-color: azure">
                            <tr>
                                <td style="width: 37%; text-align: right">
                                    <asp:Label ID="Label43" runat="server" Text="Tanggal : "></asp:Label></td>
                                <td style="width: 100%; height: 19px">
                                    &nbsp;<asp:Label ID="lblTg1" runat="server" Font-Bold="True" Font-Italic="False"
                                        Font-Size="10pt"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 37%; text-align: right">
                                    <asp:Label ID="Label41" runat="server" Text="Hrga Section Head / Hrga Head : "></asp:Label></td>
                                <td style="width: 100%; height: 19px">
                                    &nbsp;<asp:Label ID="lblHrga" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 37%; text-align: right">
                                    <asp:Label ID="Label45" runat="server" Text="Catatan : "></asp:Label></td>
                                <td style="width: 100%; height: 19px">
                                    &nbsp;<asp:TextBox ID="txtCatatanHrga" runat="server" Width="376px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCatatanHrga"
                                        ErrorMessage="Harap diisi.."></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 37%; height: 24px; text-align: right">
                                </td>
                                <td style="width: 100%; height: 24px">
                                    &nbsp;<asp:Button ID="btnRevisi" runat="server" OnClientClick="DoClick()" Text="  Revisi  "
                                        Visible="False" />
                                    <asp:Button ID="btnSetujuHrga" runat="server" Text="    OK    " />&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <br />
                    <asp:Panel ID="Panel3" runat="server" Height="50px" Visible="False" Width="100%">
                        <table border="0" cellpadding="0" cellspacing="0" style="border-right: #3366cc 1px solid;
                            border-top: #3366cc 1px solid; border-left: #3366cc 1px solid; width: 100%; border-bottom: #3366cc 1px solid;
                            background-color: beige">
                            <tr>
                                <td style="width: 37%; height: 19px; text-align: right">
                                    <asp:Label ID="Label44" runat="server" Text="Tanggal : "></asp:Label></td>
                                <td style="width: 100%; height: 19px">
                                    &nbsp;<asp:Label ID="lblTg2" runat="server" Font-Bold="True" Font-Italic="False"
                                        Font-Size="10pt"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 37%; height: 19px; text-align: right">
                                    <asp:Label ID="Label47" runat="server" Text="Hrga Head / Project Manager : "></asp:Label></td>
                                <td style="width: 100%; height: 19px">
                                    &nbsp;<asp:Label ID="lblPM" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 37%; text-align: right">
                                    <asp:Label ID="Label49" runat="server" Text="Catatan : "></asp:Label></td>
                                <td style="width: 100%; height: 19px">
                                    &nbsp;<asp:TextBox ID="txtCatatanPM" runat="server" Width="376px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCatatanPM"
                                        ErrorMessage="Harap diisi.."></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 37%; text-align: right">
                                </td>
                                <td style="width: 100%; height: 19px">
                                    &nbsp;<asp:Button ID="btnSetujuPM" runat="server" Text="    OK    " /></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <br />
                    <asp:Panel ID="Panel4" runat="server" Height="50px" Visible="False" Width="100%">
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
