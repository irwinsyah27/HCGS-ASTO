<%@ Page Language="VB" Debug="TRUE"  AutoEventWireup="false" CodeFile="fCuti22LS.aspx.vb" Inherits="_fCuti1" %>

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


</head>
<body>
    <form id="form1" runat="server">
    <div id="div1" style="margin: 0 auto; padding:0; background: #7afa76; width: 900px; height: 500px;">
    <div>
        <table border="0" cellpadding="5" cellspacing="0" style="width: 100%; height: 100%; border-right: #0066cc 1px solid; border-top: #0066cc 1px solid; border-left: #0066cc 1px solid; border-bottom: #0066cc 1px solid;" id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
            <tr>
                <td valign="top" align="center" style="width: 98%">
                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="FORM PERMOHONAN CUTI EMERGENCY"></asp:Label><br />
                                            <asp:Label ID="lblNomor" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label></td>
            </tr>
            <tr>
                <td style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; width: 98%; height: 586px;" valign="top">
                    <table border="1" cellpadding="1" cellspacing="0" style="width: 100%">
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="1" style="width: 100%">
                                    <tr>
                                        <td style="width: 161px; height: 19px">
                                            <asp:Label ID="Label22" runat="server" Text="Nrp" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="Label23" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="width: 262px">
                                            <asp:TextBox ID="txtNrp" runat="server" Width="104px" AutoPostBack="True" ValidationGroup="kosong"></asp:TextBox>
                                            <A onclick="window.open('PopupNrp.aspx?FormName=' + document.forms[0].name + '&textbox=txtNrp','PopupClass','width=390,height=400,left=300,top=100')"
		            href="javascript:;"><IMG src="Images/GoLtrHS.png" border="0" id="IMG3" runat="server" align="absMiddle" height="16" width="16"></A>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNrp"
                                                ErrorMessage="Mohon diisi..."></asp:RequiredFieldValidator></td>
                                        <td align="right">
                                            <asp:Label ID="Label11" runat="server" Text="Periode Dinas" Width="96px"></asp:Label></td>
                                        <td align="center" style="width: 20px; height: 19px">
                                            <asp:Label ID="Label16" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 100px; height: 19px">
                                            <asp:Label ID="lblPeriodeTugas" runat="server" Font-Size="10pt" Width="170px"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 19px; width: 161px;">
                                            <asp:Label ID="Label1" runat="server" Text="Nama" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="Label6" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="width: 262px">
                                            <asp:Label ID="lblNama" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td align="right" valign="top">
                                            <asp:Label ID="Label19" runat="server" Text="No. Telp / Hp"></asp:Label></td>
                                        <td style="width: 20px; height: 19px" align="center">
                                            <asp:Label ID="Label12" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 100px; height: 19px">
                                            <asp:Label ID="lblNoTelp" runat="server" Font-Size="10pt"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 24px; width: 161px;">
                                            <asp:Label ID="Label2" runat="server" Text="Jabatan / Dept "></asp:Label></td>
                                        <td align="center" style="width: 28px; height: 24px">
                                            <asp:Label ID="Label7" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="height: 24px; width: 262px;">
                                            <asp:Label ID="lblJabatan" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td align="right" rowspan="4" valign="top">
                                            <asp:Label ID="Label17" runat="server" Text="Alamat"></asp:Label></td>
                                        <td style="width: 20px;" align="center" rowspan="4" valign="top">
                                            <asp:Label ID="Label13" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 200px;" rowspan="4" valign="top">
                                            <asp:Label ID="lblAlamatdiSite" runat="server" Font-Size="10pt" Width="100%"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 161px; height: 19px;">
                                            <asp:Label ID="Label4" runat="server" Text="Status Perkawinan"></asp:Label></td>
                                        <td align="center" style="width: 28px; height: 19px;">
                                            <asp:Label ID="Label8" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="width: 262px; height: 19px;">
                                            <asp:Label ID="lblStatusKawin" runat="server" Font-Size="10pt"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 161px">
                                            <asp:Label ID="Label5" runat="server" Text="Bawa Keluarga"></asp:Label></td>
                                        <td align="center" style="width: 28px">
                                            <asp:Label ID="Label9" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="width: 262px">
                                            <asp:Label ID="lblBawaKeluarga" runat="server" Font-Size="10pt"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 24px; width: 161px;">
                                            <asp:Label ID="Label3" runat="server" Text="Status Penerimaan" Width="120px" Visible="False"></asp:Label></td>
                                        <td align="center" style="width: 28px; height: 24px">
                                            <asp:Label ID="Label10" runat="server" Text=" : " Visible="False"></asp:Label></td>
                                        <td align="left" style="width: 262px; height: 24px">
                                            <asp:Label ID="lblStatusPenerimaan" runat="server" Font-Size="10pt" Visible="False"></asp:Label></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table border="1" cellpadding="2" cellspacing="0" style="width: 100%">
                        <tr>
                            <td valign="top" style="height: 135px">
                                <table border="0" cellpadding="0" cellspacing="1" style="width: 100%">
						
                                    <tr>
                                        <td style="width: 100px">
                                            <asp:CheckBox ID="ckLapangan" runat="server" Text="Lapangan" AutoPostBack="True" /></td>
                                        <td align="right" style="width: 212px">
                                            <asp:TextBox ID="txtLapangan" runat="server" Width="200px" Enabled="False" AutoPostBack="True">0</asp:TextBox>&nbsp;</td>
                                        <td align="left">
                                            <asp:Label ID="Label28" runat="server" Text="hari"></asp:Label>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 20px">
                                            <asp:CheckBox ID="ckTahunan" runat="server" Text="Tahunan" AutoPostBack="True" /></td>
                                        <td align="right" style="width: 212px;">
                                            <asp:TextBox ID="txtTahunan" runat="server" Width="200px" Enabled="False" AutoPostBack="True">0</asp:TextBox>&nbsp;</td>
                                        <td align="left" style="height: 20px">
                                            <asp:Label ID="Label29" runat="server" Text="hari"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 20px">
                                            <asp:CheckBox ID="ckBesar" runat="server" Text="Besar" AutoPostBack="True" /></td>
                                        <td align="right" style="width: 212px; height: 20px">
                                            <asp:TextBox ID="txtBesar" runat="server" Width="200px" Enabled="False" AutoPostBack="True">0</asp:TextBox>&nbsp;</td>
                                        <td align="left" style="height: 20px">
                                            <asp:Label ID="Label30" runat="server" Text="hari"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 130px; height: 20px">
                                            <asp:CheckBox ID="ckPerjalanan" runat="server" Text="Perjalanan" AutoPostBack="True" /></td>
                                        <td align="right" style="width: 212px; height: 20px">
                                            <asp:TextBox ID="txtPerjalanan" runat="server" Width="200px" AutoPostBack="True" Enabled="False">0</asp:TextBox>&nbsp;</td>
                                        <td align="left" style="height: 20px">
                                            <asp:Label ID="Label31" runat="server" Text="hari"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px; height: 19px">
                                            <asp:Label ID="Label37" runat="server" Text="Total"></asp:Label></td>
                                        <td align="right" style="width: 212px; height: 19px">
                                            <asp:TextBox ID="txtTotal" runat="server" Width="200px" ReadOnly="True"></asp:TextBox>&nbsp;</td>
                                        <td align="left">
                                            <asp:Label ID="Label36" runat="server" Text="hari"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 19px" align="right">
                                            <asp:Label ID="Label20" runat="server" Text="Tujuan Cuti"></asp:Label></td>
                                        <td style="width: 212px; height: 19px" align="right">
                                            <asp:TextBox ID="txtTujuan" runat="server" Width="200px" MaxLength="30"></asp:TextBox>&nbsp;</td>
                                        <td align="left" style="height: 19px">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top" style="height: 135px; width: 390px;">
                                <table border="0" cellpadding="0" cellspacing="1" style="width: 100%">
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label24" runat="server" Text="Periode Cuti Tahunan : " Width="152px"></asp:Label></td>
                                        <td align="right" style="width: 100%">
                                            &nbsp;<asp:Label ID="lblSisaCuti1" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td align="right" style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="height: 19px">
                                            <asp:Label ID="Label18" runat="server" Text="Periode Cuti Tahunan : " Width="152px"></asp:Label></td>
                                        <td align="right" style="width: 100%">
                                            <asp:Label ID="lblSisaCuti2" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td align="right" style="width: 100px; height: 19px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="height: 19px">
                                            <asp:Label ID="Label14" runat="server" Text="Periode Cuti Besar : " Width="152px"></asp:Label></td>
                                        <td align="right" style="width: 100%">
                                            <asp:Label ID="lblCutiBesar" runat="server" Font-Size="10pt"></asp:Label>
                                            <asp:Label ID="Label15" runat="server" Font-Size="10pt">hari</asp:Label></td>
                                        <td align="right" style="width: 100px; height: 19px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2" style="height: 19px">
                                            <hr />
                                            <table border="0" cellpadding="0" cellspacing="1" style="width: 100%">
                                                <tr>
                                                    <td align="right" style="height: 19px">
                                                        <asp:Label ID="Label25" runat="server" Text="Total : " Width="151px"></asp:Label></td>
                                                    <td align="right" style="width: 100%">
                                                        <asp:Label ID="lblTotal" runat="server" Font-Size="10pt"></asp:Label>
                                                        <asp:Label ID="Label42" runat="server" Font-Size="10pt">hari</asp:Label></td>
                                                </tr>
                                            </table>
                                            <hr />
                                            <table border="0" cellpadding="0" cellspacing="1" style="width: 100%">
                                                <tr>
                                                    <td align="right" style="height: 19px">
                                                        &nbsp;<asp:Label ID="Label27" runat="server" Text="Sisa Cuti Tahunan : " Width="152px"></asp:Label></td>
                                                    <td align="right" style="width: 100%">
                                                        &nbsp;<asp:Label ID="lblSisaCuti" runat="server" Font-Size="10pt"></asp:Label>
                                                        <asp:Label ID="lblHariCTahunan" runat="server" Font-Size="10pt">hari</asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="height: 19px">
                                                        <asp:Label ID="Label39" runat="server" Text="Sisa Cuti Besar : " Width="152px"></asp:Label></td>
                                                    <td align="right" style="width: 100%">
                                                        <asp:Label ID="lblSisaCutiBesar" runat="server" Font-Size="10pt"></asp:Label>
                                                        <asp:Label ID="lblHariCBesar" runat="server" Font-Size="10pt">hari</asp:Label></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td align="right" style="width: 100px; height: 19px">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <caption align="left">
                                        CUTI DILAKSANAKAN :</caption>
                                    <tr>
                                        <td style="width: 30px; height: 2px;">
                                            <asp:Label ID="Label33" runat="server" Text="Awal" Width="104px"></asp:Label></td>
                                        <td style="width: 47%; height: 2px;">
                                            <asp:TextBox ID="txtAwal" runat="server" Width="136px" AutoPostBack="True"></asp:TextBox>
                                            <A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=txtAwal','PopupClass','width=215,height=195,left=330,top=300')"
		                            href="javascript:;"><IMG src="Images/Calendar.png" border="0" id="IMG1" runat="server" align="absMiddle" height="20" width="20"></A>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAwal"
                                                ErrorMessage="Mohon diisi..."></asp:RequiredFieldValidator></td>
                                        <td style="width: 100%; height: 2px;">
                                            &nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtLapangan"
                                                ErrorMessage="*" MaximumValue="12" MinimumValue="0" Type="Double"></asp:RangeValidator><A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=txtAkhir','PopupClass','width=215,height=195,left=330,top=300')"
		                            href="javascript:;"></A>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px;">
                                            <asp:Label ID="Label34" runat="server" Text="Akhir" Width="104px"></asp:Label></td>
                                        <td colspan="1" style="height: 19px">
                                            <asp:TextBox ID="txtAkhir" runat="server" Width="136px" Enabled="False"></asp:TextBox>
                                            <IMG src="Images/Calendar.png" border="0" id="IMG2" runat="server" align="absMiddle" height="20" width="20"></td>
                                        <td colspan="2" style="height: 19px">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px">
                                            <asp:Label ID="Label35" runat="server" Text="Alamat Cuti" Width="104px"></asp:Label></td>
                                        <td colspan="2" style="height: 19px">
                                            <asp:TextBox ID="txtAlamatCuti" runat="server" Width="80%" MaxLength="200"></asp:TextBox>
                                            <asp:Button ID="btSave" runat="server" Text="  Simpan  " /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px">
                                            <asp:Label ID="Label38" runat="server" Text="Keterangan" Width="104px"></asp:Label></td>
                                        <td colspan="2" style="height: 19px">
                                            <asp:TextBox ID="txtKeterangan" runat="server" Width="80%" MaxLength="200"></asp:TextBox>
                                </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
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
