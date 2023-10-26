<%@ Page Language="VB" Debug="TRUE"  AutoEventWireup="false" CodeFile="pDinas.aspx.vb" Inherits="_pDinas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Form Cuti</title>
    <script src="jscript.js" type="text/javascript"></script>
    <link href="" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="5" cellspacing="2" style="width: 100%; height: 100%; border-right: #0066cc 1px solid; border-top: #0066cc 1px solid; border-left: #0066cc 1px solid; border-bottom: #0066cc 1px solid;" id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
            <tr>
                <td align="left" valign="top" width="35%">
                    <asp:Image ID="Image1" runat="server" Height="80px" ImageUrl="Images/logo.jpg"
                        Width="80px" /></td>
                <td valign="top" align="center">
                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="SURAT DINAS" Font-Size="16pt"></asp:Label><br />
                                            <asp:Label ID="lblNomor" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label></td>
                <td align="center" valign="top" width="35%">
                </td>
            </tr>
            <tr>
                <td style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none;" valign="top" colspan="3">
                    <table border="1" cellpadding="1" cellspacing="0" style="width: 100%">
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="1" style="width: 100%">
                                    <tr>
                                        <td colspan="6" style="height: 19px">
                                            <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="Diberikan kepada :"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 161px; height: 19px">
                                            <asp:Label ID="Label22" runat="server" Text="Nrp" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="Label23" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="width: 262px">
                                            <asp:Label ID="lblNrp" runat="server" Font-Size="10pt"></asp:Label>
                                            <asp:Label ID="Label11" runat="server" Text="Periode Tugas" Visible="False"></asp:Label>
                                            </td>
                                        <td align="right" width="100">
                                            <asp:Label ID="Label19" runat="server" Text="No. Telp / Hp"></asp:Label></td>
                                        <td align="center" style="width: 20px; height: 19px">
                                            <asp:Label ID="Label16" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 199px; height: 19px">
                                            <asp:Label ID="lblNoTelp" runat="server" Font-Size="10pt"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 19px; width: 161px;">
                                            <asp:Label ID="Label1" runat="server" Text="Nama" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="Label6" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="width: 262px">
                                            <asp:Label ID="lblNama" runat="server" Font-Size="10pt"></asp:Label>
                                            <asp:Label ID="lblPeriodeTugas" runat="server" Font-Size="10pt" Width="170px" Visible="False"></asp:Label></td>
                                        <td align="right" width="100">
                                            <asp:Label ID="Label17" runat="server" Text="Alamat"></asp:Label></td>
                                        <td style="width: 20px; height: 19px" align="center">
                                            <asp:Label ID="Label12" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 199px;" rowspan="5" valign="top">
                                            <asp:Label ID="lblAlamatdiSite" runat="server" Font-Size="10pt" Width="99%"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 24px; width: 161px;">
                                            <asp:Label ID="Label2" runat="server" Text="Jabatan / Dept "></asp:Label></td>
                                        <td align="center" style="width: 28px; height: 24px">
                                            <asp:Label ID="Label7" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="height: 24px; width: 262px;">
                                            <asp:Label ID="lblJabatan" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td align="right" rowspan="4" valign="top" width="100">
                                            &nbsp;</td>
                                        <td style="width: 20px;" align="center" rowspan="4" valign="top">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 161px;">
                                            <asp:Label ID="Label4" runat="server" Text="Status Perkawinan"></asp:Label></td>
                                        <td align="center" style="width: 28px;">
                                            <asp:Label ID="Label8" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="width: 262px">
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
                                            &nbsp;<asp:Label ID="Label3" runat="server" Text="Status Penerimaan" Width="120px" Visible="False"></asp:Label></td>
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
                            <td colspan="2" style="height: 117px" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <caption align="left">
                                        <asp:Label ID="Label27" runat="server" Text="Periode Dinas :" Font-Bold="True"></asp:Label></caption>
                                    <tr>
                                        <td style="width: 30px; height: 24px">
                                            <asp:Label ID="Label33" runat="server" Text="Awal" Width="104px"></asp:Label></td>
                                        <td style="width: 47%; height: 24px">
                                            <asp:TextBox ID="txtAwal" runat="server" AutoPostBack="True" Width="136px"></asp:TextBox></td>
                                        <td style="width: 100%; height: 24px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px">
                                            <asp:Label ID="Label34" runat="server" Text="Akhir" Width="104px"></asp:Label></td>
                                        <td colspan="1" style="height: 19px">
                                            <asp:TextBox ID="txtAkhir" runat="server" Width="136px"></asp:TextBox><a href="javascript:;" onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=txtAkhir','PopupClass','width=215,height=195,left=330,top=300')"></a></td>
                                        <td colspan="2" style="height: 19px">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px">
                                            <asp:Label ID="Label18" runat="server" Text="Tujuan" Width="104px"></asp:Label></td>
                                        <td colspan="2" style="height: 19px">
                                            <asp:TextBox ID="txtTujuan" runat="server" Width="136px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px">
                                            <asp:Label ID="Label20" runat="server" Text="Penginapan" Width="104px"></asp:Label></td>
                                        <td colspan="2" style="height: 19px">
                                            <asp:TextBox ID="txtPenginapan" runat="server" Width="136px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px">
                                            <asp:Label ID="Label38" runat="server" Text="Keterangan" Width="104px"></asp:Label></td>
                                        <td colspan="2" style="height: 19px">
                                            <asp:TextBox ID="txtKeterangan" runat="server" Width="80%" TextMode="MultiLine"></asp:TextBox>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Panel ID="Panel5" runat="server" Height="50px" Width="100%">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td colspan="2" style="text-align: center">
                                PERSETUJUAN</td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" valign="top" width="35%">
                                    <br />
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td width="100%">
                                                <asp:Image ID="imgForPm" runat="server" />
                                                <asp:Image ID="imgSignPm" runat="server" Height="134px" Width="144px" /></td>
                                        </tr>
                                        <tr>
                                            <td width="100%">
                                                <asp:Label ID="lblPM" runat="server" Font-Bold="True" Font-Size="10pt" Font-Underline="True"
                                                    Width="100%">Agus Dwi Widiyanto</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 16px" width="100%">
                                                <asp:Label ID="lblJabatan1" runat="server" Font-Bold="False" Font-Size="10pt" Width="100%">Project Manager</asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="text-align: center" valign="top" width="35%">
                                    <br />
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td width="100%">
                                                <asp:Image ID="imgForHrga" runat="server" />
                                                <asp:Image ID="imgSignHrga" runat="server" Height="134px" Width="144px" /></td>
                                        </tr>
                                        <tr>
                                            <td width="100%">
                                                <asp:Label ID="lblHrga" runat="server" Font-Bold="True" Font-Size="10pt" Font-Underline="True"
                                                    Width="100%">Yayan Rudianto</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 16px" width="100%">
                                                <asp:Label ID="lblJabatan2" runat="server" Font-Bold="False" Font-Size="10pt" Width="100%">HRGA Dept. Head</asp:Label></td>
                                        </tr>
                                    </table>
                                    <br />
                                    </td>
                                <td style="text-align: center" valign="top" width="30%">
                                    <asp:Label ID="Label48" runat="server" Text="Personnel Admin : " Width="80%" Visible="False"></asp:Label><br />
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td width="100%">
                                                <asp:Image ID="imgSignAdmin" runat="server" Visible="False" Height="134px" Width="144px" /></td>
                                        </tr>
                                        <tr>
                                            <td width="100%">
                                                <asp:Label ID="lblPersonnelAdmin" runat="server" Font-Bold="True" Font-Size="10pt"
                                                    Font-Underline="True" Width="100%" Visible="False">Personnel Admin</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 16px" width="100%">
                                                <asp:Label ID="lblJabatan3" runat="server" Font-Bold="False" Font-Size="10pt" Width="100%" Visible="False"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    &nbsp;
                                </td>
            </tr>
        </table>
    
    </div>
    </form>
     <script language="javascript" type="text/javascript">
		previewit();
	</script>
</body>
</html>
