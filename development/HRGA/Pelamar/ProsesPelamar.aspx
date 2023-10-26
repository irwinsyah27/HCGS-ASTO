<%@ Page Language="VB" Debug="TRUE"  AutoEventWireup="false" CodeFile="ProsesPelamar.aspx.vb" Inherits="_ProsesPelamar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Form Proses Pelamar</title>
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
<body bgcolor="#000000">
    <form id="form1" runat="server">
    <div id="div1" style="margin: 0 auto; padding:0; width: 900px;">
    <div>
        <table border="0" cellpadding="5" cellspacing="0" style="width: 100%; height: 100%; border-right: #0066cc 1px solid; border-top: #0066cc 1px solid; border-left: #0066cc 1px solid; border-bottom: #0066cc 1px solid; background-color: white;" id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
            <tr>
                <td valign="top" align="center" style="width: 98%">
                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="FORM PROSES PELAMAR"></asp:Label><br />
                    <asp:Label ID="lblNomor" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label></td>
            </tr>
            <tr>
                <td style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; width: 100%;" valign="top">
                    <table border="1" cellpadding="1" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="height: 277px">
                                <asp:Panel ID="PanelPelamar" runat="server" Width="900px">
                                    <table border="0" cellpadding="0" cellspacing="1" style="width: 100%">
                                        <tr>
                                            <td colspan="4" style="font-weight: bold; height: 19px; text-decoration: underline">
                                            BIODATA :
                                            </td>
                                            <td align="right" style="height: 19px; width: 167px;">
                                            </td>
                                            <td align="center" style="width: 20px; height: 19px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 40px; height: 19px">
                                            </td>
                                            <td style="width: 111px; height: 19px">
                                                <asp:Label ID="Label111" runat="server" Text="Nama"></asp:Label></td>
                                            <td align="center" style="width: 8px; height: 19px">
                                                <asp:Label ID="Label10" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 474px">
                                                <asp:Label ID="LblNama" runat="server" Font-Size="10pt" Font-Bold="True"></asp:Label></td>
                                            <td align="right" valign="top" style="width: 167px" rowspan="9">
                                            </td>
                                            <td align="center" style="width: 20px; height: 19px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 40px; height: 19px">
                                            </td>
                                            <td style="width: 111px; height: 19px">
                                                <asp:Label ID="Label22" runat="server" Text="Tempat lahir"></asp:Label></td>
                                            <td align="center" style="width: 8px; height: 19px">
                                                <asp:Label ID="Label11" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 474px; height: 19px">
                                                <asp:Label ID="LblTempatLahir" runat="server" Font-Size="10pt" Font-Bold="True"></asp:Label></td>
                                            <td align="center" style="width: 20px; height: 19px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 40px; height: 24px">
                                            </td>
                                            <td style="width: 111px; height: 24px">
                                                <asp:Label ID="Label200" runat="server" Text="Tanggal Lahir"></asp:Label></td>
                                            <td align="center" style="width: 8px; height: 24px">
                                                <asp:Label ID="Label1" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 474px; height: 24px">
                                                <asp:Label ID="LblTglLahir" runat="server" Font-Size="10pt" Font-Bold="True"></asp:Label></td>
                                            <td align="center" rowspan="4" style="width: 20px" valign="top">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 40px; height: 19px">
                                            </td>
                                            <td style="width: 111px; height: 19px">
                                                <asp:Label ID="Label400" runat="server" Text="Jenis Kelamin"></asp:Label></td>
                                            <td align="center" style="width: 8px; height: 19px">
                                                <asp:Label ID="Label2" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 474px; height: 19px">
                                                <asp:Label ID="LblJK" runat="server" Font-Size="10pt" Font-Bold="True"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 40px; height: 24px">
                                            </td>
                                            <td style="width: 111px; height: 24px">
                                                <asp:Label ID="Label44" runat="server" Text="Agama"></asp:Label></td>
                                            <td align="center" style="width: 8px; height: 24px">
                                                <asp:Label ID="Label18" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 474px; height: 24px">
                                                <asp:Label ID="LblAgama" runat="server" Font-Size="10pt" Font-Bold="True"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 40px; height: 24px">
                                            </td>
                                            <td style="width: 111px; height: 24px">
                                                <asp:Label ID="Labels" runat="server" Text="Status Kawin"></asp:Label></td>
                                            <td align="center" style="width: 8px; height: 24px">
                                                <asp:Label ID="Label19" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 474px; height: 24px">
                                                <asp:Label ID="LblStatusKawin" runat="server" Font-Size="10pt" Font-Bold="True"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 40px; height: 24px">
                                            </td>
                                            <td style="width: 111px; height: 24px">
                                                <asp:Label ID="Label41" runat="server" Text="Golongan Darah"></asp:Label></td>
                                            <td align="center" style="width: 8px; height: 24px">
                                                <asp:Label ID="Label3" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 474px; height: 24px">
                                                <asp:Label ID="LblGolonganDarah" runat="server" Font-Size="10pt" Font-Bold="True"></asp:Label></td>
                                            <td align="center" rowspan="1" style="width: 20px" valign="top">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; width: 40px; height: 24px; text-align: left">
                                            </td>
                                            <td style="vertical-align: top; width: 111px; height: 24px; text-align: left">
                                                <asp:Label ID="Label20" runat="server" Text="Alamat Tinggal"></asp:Label></td>
                                            <td align="center" style="vertical-align: top; width: 8px; height: 24px; text-align: center">
                                                <asp:Label ID="Label29" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 474px; height: 24px">
                                                <asp:Label ID="LblAlamat" runat="server" Font-Size="10pt" Font-Bold="True"></asp:Label></td>
                                            <td align="center" rowspan="1" style="width: 20px" valign="top">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 40px; height: 24px">
                                            </td>
                                            <td style="width: 111px; height: 24px">
                                                <asp:Label ID="Label4" runat="server" Text="Kota"></asp:Label></td>
                                            <td align="center" style="width: 8px; height: 24px">
                                                <asp:Label ID="Label30" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 474px; height: 24px">
                                                <asp:Label ID="LblKota" runat="server" Font-Size="10pt" Font-Bold="True"></asp:Label></td>
                                            <td align="center" rowspan="1" style="width: 20px; height: 24px;" valign="top">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 40px; height: 24px">
                                            </td>
                                            <td style="width: 111px; height: 24px">
                                                <asp:Label ID="Label33" runat="server" Text="Telepon Rumah"></asp:Label></td>
                                            <td align="center" style="width: 8px; height: 24px">
                                                <asp:Label ID="Label31" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 474px; height: 24px">
                                                <asp:Label ID="Lbltelp" runat="server" Font-Size="10pt" Font-Bold="True"></asp:Label></td>
                                            <td align="right" rowspan="1" valign="top" style="width: 167px">
                                            </td>
                                            <td align="center" rowspan="1" style="width: 20px" valign="top">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 40px; height: 24px">
                                            </td>
                                            <td style="width: 111px; height: 24px">
                                                <asp:Label ID="Label28" runat="server" Text="Handphone"></asp:Label></td>
                                            <td align="center" style="width: 8px; height: 24px">
                                                <asp:Label ID="Label36" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 474px; height: 24px">
                                                <asp:Label ID="LblHP" runat="server" Font-Size="10pt" Font-Bold="True"></asp:Label></td>
                                            <td align="right" rowspan="1" valign="top" style="width: 167px">
                                            </td>
                                            <td align="center" rowspan="1" style="width: 20px" valign="top">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table><table border="1" cellpadding="1" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="vertical-align: top; height: 159px; text-align: left">
                                <asp:Panel ID="Panel1" runat="server" Width="900px">
                                <table border="0" cellpadding="0" cellspacing="1" style="width: 100%">
                                    <tr>
                                        <td colspan="5" style="font-weight: bold; height: 19px; text-decoration: underline">
                                            PENDIDIKAN :</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 40px; height: 19px">
                                        </td>
                                        <td style="width: 119px; height: 19px">
                                            <asp:Label ID="Label26" runat="server" Text="Jenjang" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 6px; height: 19px">
                                            <asp:Label ID="Label27" runat="server" Text=" : "></asp:Label></td>
                                        <td align="right" style="width: 655px; height: 19px; text-align: left">
                                            <asp:Label ID="LblJenjang" runat="server" Font-Size="10pt" Font-Bold="True"></asp:Label></td>
                                        <td align="left" style="height: 19px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 40px; height: 19px;">
                                        </td>
                                        <td style="width: 119px; height: 19px;">
                                            <asp:Label ID="Label24" runat="server" Text="Sekolah" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 6px; height: 19px;">
                                            <asp:Label ID="Label48" runat="server" Text=" : "></asp:Label></td>
                                        <td align="right" style="width: 655px; text-align: left; height: 19px;">
                                            <asp:Label ID="LblSekolah" runat="server" Font-Size="10pt" Font-Bold="True"></asp:Label></td>
                                        <td align="left" style="height: 19px">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 40px; height: 20px">
                                        </td>
                                        <td style="width: 119px; height: 20px">
                                            <asp:Label ID="Label37" runat="server" Text="Jurusan" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 6px; height: 20px">
                                            <asp:Label ID="Label49" runat="server" Text=" : "></asp:Label></td>
                                        <td align="right" style="width: 655px; height: 20px; text-align: left">
                                            <asp:Label ID="LblJurusan" runat="server" Font-Size="10pt" Font-Bold="True"></asp:Label></td>
                                        <td align="left" style="height: 20px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 40px; height: 20px">
                                        </td>
                                        <td style="width: 119px; height: 20px">
                                            <asp:Label ID="Label45" runat="server" Text="Akreditasi" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 6px; height: 20px">
                                            <asp:Label ID="Label50" runat="server" Text=" : "></asp:Label></td>
                                        <td align="right" style="width: 655px; height: 20px; text-align: left">
                                            <asp:Label ID="LblAkreditasi" runat="server" Font-Size="10pt" Font-Bold="True"></asp:Label></td>
                                        <td align="left" style="height: 20px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 40px; height: 20px">
                                        </td>
                                        <td style="width: 119px; height: 20px">
                                            <asp:Label ID="Label46" runat="server" Text="Tahun Lulus" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 6px; height: 20px">
                                            <asp:Label ID="Label51" runat="server" Text=" : "></asp:Label></td>
                                        <td align="right" style="width: 655px; height: 20px; text-align: left">
                                            <asp:Label ID="LblThnLulus" runat="server" Font-Size="10pt" Font-Bold="True"></asp:Label></td>
                                        <td align="left" style="height: 20px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 40px; height: 19px; text-align: left">
                                        </td>
                                        <td align="right" style="width: 119px; height: 19px; text-align: left">
                                            <asp:Label ID="Label47" runat="server" Text="IPK" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 6px; height: 19px; text-align: left">
                                            <asp:Label ID="Label52" runat="server" Text=" : "></asp:Label></td>
                                        <td align="right" style="width: 655px; height: 19px; text-align: left">
                                            <asp:Label ID="LblIPK" runat="server" Font-Size="10pt" Font-Bold="True"></asp:Label></td>
                                        <td align="left">
                                        </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                                </td>
            </tr>
        </table>
    </div>
        <br />
        <table border="0" cellpadding="5" cellspacing="0" style="width: 102%; height: 6px; border-right: #0066cc 1px solid; border-top: #0066cc 1px solid; border-left: #0066cc 1px solid; border-bottom: #0066cc 1px solid; background-color: white;" id="Table2" language="javascript" onclick="return TABLE1_onclick()">
            <tr>
                <td style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; width: 100%; vertical-align: top; text-align: left; height: 10px;" valign="top">
                    <table border="1" cellpadding="2" cellspacing="0" style="width: 100%;">
                        <tr>
                            <td colspan="2" valign="top">
                                <asp:Panel ID="PanelPosisi1" runat="server" Width="900px">
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                    <caption align="left" style="font-weight: bold; text-decoration: underline">
                                                        POSISI LAMARAN :</caption>
                                                    <tr>
                                                        <td style="width: 50px; height: 2px">
                                                        </td>
                                                        <td style="width: 50px; height: 2px">
                                                            <asp:Label ID="Label7" runat="server" Text="Site" Width="104px"></asp:Label></td>
                                                        <td style="width: 30px; height: 2px">
                                                        </td>
                                                        <td style="width: 6px; height: 2px; text-align: left">
                                                            <asp:Label ID="Label8" runat="server" Text=" : "></asp:Label></td>
                                                        <td style="width: 47%; height: 2px; text-align: left">
                                                            <asp:Label ID="LblSite" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 50px; height: 2px">
                                                        </td>
                                                        <td style="width: 50px; height: 2px">
                                                            <asp:Label ID="Label9" runat="server" Text="Departemen" Width="104px"></asp:Label></td>
                                                        <td style="width: 30px; height: 2px">
                                                        </td>
                                                        <td style="width: 6px; height: 2px; text-align: left">
                                                            <asp:Label ID="Label15" runat="server" Text=" : "></asp:Label></td>
                                                        <td style="width: 47%; height: 2px; text-align: left">
                                                            <asp:Label ID="LblDept" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 50px; height: 2px">
                                                        </td>
                                                        <td style="width: 50px; height: 2px;">
                                                            <asp:Label ID="Label16" runat="server" Text="Jabatan" Width="104px"></asp:Label></td>
                                                        <td style="width: 30px; height: 2px">
                                                        </td>
                                                        <td style="width: 6px; height: 2px; text-align: left">
                                                            <asp:Label ID="Label17" runat="server" Text=" : "></asp:Label></td>
                                                        <td style="width: 47%; height: 2px; text-align: left;">
                                                            <asp:Label ID="LblJabatan" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 50px; height: 19px">
                                                        </td>
                                                        <td style="width: 50px; height: 19px;">
                                                            <asp:Label ID="Label23" runat="server" Text="Referensi" Width="104px"></asp:Label></td>
                                                        <td style="width: 30px; height: 19px">
                                                        </td>
                                                        <td colspan="1" style="width: 6px; height: 19px">
                                                            <asp:Label ID="Label25" runat="server" Text=" : "></asp:Label></td>
                                                        <td colspan="1" style="height: 19px">
                                                            <asp:Label ID="LblReff" runat="server"></asp:Label></td>
                                                        <td colspan="1" style="height: 19px">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 50px; height: 19px">
                                                        </td>
                                                        <td style="width: 50px; height: 19px">
                                                            <asp:Label ID="Label40" runat="server" Text="Resource" Width="104px"></asp:Label></td>
                                                        <td style="width: 30px; height: 19px">
                                                        </td>
                                                        <td colspan="1" style="width: 6px; height: 19px">
                                                            <asp:Label ID="Label42" runat="server" Text=" : "></asp:Label></td>
                                                        <td colspan="1" style="height: 19px">
                                                            <asp:Label ID="LblResource" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 50px; height: 19px">
                                                        </td>
                                                        <td style="width: 50px; height: 19px">
                                                <asp:Label ID="Label43" runat="server" Text="Input by : " Width="104px"></asp:Label></td>
                                                        <td style="width: 30px; height: 19px">
                                                        </td>
                                                        <td colspan="1" style="width: 6px; height: 19px">
                                                        </td>
                                                        <td colspan="1" style="height: 19px">
                                                <asp:Label ID="LblInput" runat="server"></asp:Label></td>
                                                    </tr>
                                                </table>
                                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <table border="0" cellpadding="5" cellspacing="0" style="width: 102%; height: 6px; border-right: #0066cc 1px solid; border-top: #0066cc 1px solid; border-left: #0066cc 1px solid; border-bottom: #0066cc 1px solid; background-color: white;" id="Table3" language="javascript" onclick="return TABLE1_onclick()">
            <tr>
                <td style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; width: 100%; vertical-align: top; text-align: left; height: 10px;" valign="top">
                    <table border="1" cellpadding="2" cellspacing="0" style="width: 100%;">
                        <tr>
                            <td colspan="2" valign="top" style="height: 222px">
                                <asp:Panel ID="Panel2" runat="server" Width="900px">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <caption align="left" style="font-weight: bold; text-decoration: underline">
                                            PROSES :</caption>
                                        <tr>
                                            <td colspan="1" style="height: 20px">
                                                &nbsp;</td>
                                            <td colspan="2" style="text-align: center; font-weight: bold;" bordercolor="#000000">
                                                <strong>STEP</strong></td>
                                            <td colspan="1" style="font-weight: bold; text-align: center" bordercolor="#000000">
                                                PLAN DATE</td>
                                            <td bordercolor="#000000" style="font-weight: bold; text-align: center">
                                                HR</td>
                                            <td style="font-weight: bold; width: 178px; text-align: center" bordercolor="#000000" colspan="">
                                                ACTUAL DATE</td>
                                            <td bordercolor="#000000" style="font-weight: bold; width: 199px; text-align: center">
                                                PIC</td>
                                            <td style="font-weight: bold; text-align: center" bordercolor="#000000">
                                                RESULT</td>
                                            <td style="width: 47%; text-align: left">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25px; height: 2px">
                                            </td>
                                            <td style="width: 25px; height: 2px">
                                                <asp:Label ID="Label6" runat="server" Text="Interview Departemen" Width="140px"></asp:Label></td>
                                            <td style="height: 2px">
                                                <asp:Label ID="Label12" runat="server" Text=" : "></asp:Label></td>
                                            <td style="height: 2px; text-align: left">
                                                <asp:TextBox ID="txtInDepPlanDate" runat="server" Width="80px"></asp:TextBox><A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=txtInDepPlanDate','PopupClass','width=215,height=195,left=330,top=300')"
		                            href="javascript:;"><IMG src="http://pama-tala/hrga/Images/Calendar.png" border="0" id="IMG1" runat="server" align="absMiddle" height="20" width="20"></A></td>
                                            <td style="width: 211px; height: 2px; text-align: left">
                                                <asp:Button ID="Button10" runat="server" Text="Simpan" /></td>
                                            <td style="width: 178px; height: 2px; text-align: left">
                                                <asp:TextBox ID="TextBox6" runat="server" Width="110px" Enabled="False"></asp:TextBox></td>
                                            <td style="width: 199px; height: 2px; text-align: center">
                                                <asp:Button ID="Button11" runat="server" Text="Proses" /></td>
                                            <td style="width: 47%; height: 2px; text-align: center">
                                                <asp:CheckBox ID="CheckBox1" runat="server" Enabled="False" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25px; height: 2px">
                                            </td>
                                            <td style="width: 25px; height: 2px">
                                                <asp:Label ID="Label39" runat="server" Text="Psiko Test" Width="140px"></asp:Label></td>
                                            <td style="height: 2px">
                                                <asp:Label ID="Label14" runat="server" Text=" : "></asp:Label></td>
                                            <td style="width: 201px; height: 2px; text-align: left">
                                                <asp:TextBox ID="txtPsikoPlanDate" runat="server" Width="80px"></asp:TextBox><A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=txtPsikoPlanDate','PopupClass','width=215,height=195,left=330,top=300')"
		                            href="javascript:;"><IMG src="http://pama-tala/hrga/Images/Calendar.png" border="0" id="IMG2" runat="server" align="absMiddle" height="20" width="20"></A></td>
                                            <td style="width: 211px; height: 2px; text-align: left">
                                                <asp:Button ID="Button6" runat="server" Text="Simpan" /></td>
                                            <td style="width: 178px; height: 2px; text-align: left">
                                                <asp:TextBox ID="TextBox7" runat="server" Width="110px" Enabled="False"></asp:TextBox></td>
                                            <td style="width: 199px; height: 2px; text-align: center">
                                                <asp:Button ID="Button12" runat="server" Text="Proses" /></td>
                                            <td style="width: 47%; height: 2px; text-align: center">
                                                <asp:CheckBox ID="CheckBox2" runat="server" Enabled="False" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25px; height: 2px">
                                            </td>
                                            <td style="width: 25px; height: 2px;">
                                                <asp:Label ID="Label5" runat="server" Text="Interview PM." Width="140px"></asp:Label></td>
                                            <td style="height: 2px">
                                                <asp:Label ID="Label35" runat="server" Text=" : "></asp:Label></td>
                                            <td style="width: 201px; height: 2px; text-align: left">
                                                <asp:TextBox ID="txtInPMPlanDate" runat="server" Width="80px"></asp:TextBox><A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=txtInPMPlanDate','PopupClass','width=215,height=195,left=330,top=300')"
		                            href="javascript:;"><IMG src="http://pama-tala/hrga/Images/Calendar.png" border="0" id="IMG3" runat="server" align="absMiddle" height="20" width="20"></A></td>
                                            <td style="width: 211px; height: 2px; text-align: left"><asp:Button ID="Button7" runat="server" Text="Simpan" /></td>
                                            <td style="width: 178px; height: 2px; text-align: left">
                                                <asp:TextBox ID="TextBox8" runat="server" Width="110px" Enabled="False"></asp:TextBox></td>
                                            <td style="width: 199px; height: 2px; text-align: center">
                                                <asp:Button ID="Button13" runat="server" Text="Proses" /></td>
                                            <td style="width: 47%; height: 2px; text-align: center">
                                                <asp:CheckBox ID="CheckBox3" runat="server" Enabled="False" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25px; height: 19px">
                                            </td>
                                            <td style="width: 25px; height: 19px;">
                                                <asp:Label ID="Label61" runat="server" Text="Interview Direktur" Width="140px"></asp:Label></td>
                                            <td style="height: 19px">
                                                <asp:Label ID="Label53" runat="server" Text=" : "></asp:Label></td>
                                            <td colspan="1" style="width: 201px; height: 19px">
                                                <asp:TextBox ID="txtInDirPlanDate" runat="server" Width="80px"></asp:TextBox><A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=txtInDirPlanDate','PopupClass','width=215,height=195,left=330,top=300')"
		                            href="javascript:;"><IMG src="http://pama-tala/hrga/Images/Calendar.png" border="0" id="IMG4" runat="server" align="absMiddle" height="20" width="20"></A></td>
                                            <td colspan="1" style="width: 211px; height: 19px"><asp:Button ID="Button8" runat="server" Text="Simpan" /></td>
                                            <td colspan="1" style="width: 178px; height: 19px">
                                                <asp:TextBox ID="TextBox9" runat="server" Width="110px" Enabled="False"></asp:TextBox></td>
                                            <td colspan="1" style="width: 199px; height: 2px; text-align: center">
                                                <asp:Button ID="Button14" runat="server" Text="Proses" /></td>
                                            <td colspan="1" style="height: 2px; width: 47%; text-align: center;">
                                                <asp:CheckBox ID="CheckBox4" runat="server" Enabled="False" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25px; height: 19px">
                                            </td>
                                            <td style="width: 25px; height: 19px">
                                                <asp:Label ID="Label55" runat="server" Text="Medical Check Up" Width="140px"></asp:Label></td>
                                            <td style="height: 19px">
                                                <asp:Label ID="Label56" runat="server" Text=" : "></asp:Label></td>
                                            <td colspan="1" style="width: 201px; height: 19px">
                                                <asp:TextBox ID="txtmcuplanDate" runat="server" Width="80px"></asp:TextBox><A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=txtmcuplanDate','PopupClass','width=215,height=195,left=330,top=300')"
		                            href="javascript:;"><IMG src="http://pama-tala/hrga/Images/Calendar.png" border="0" id="IMG5" runat="server" align="absMiddle" height="20" width="20"></A></td>
                                            <td colspan="1" style="width: 211px; height: 19px">
                                                <asp:Button ID="Button9" runat="server" Text="Simpan" /></td>
                                            <td colspan="1" style="width: 178px; height: 19px">
                                                <asp:TextBox ID="TextBox10" runat="server" Width="110px" Enabled="False"></asp:TextBox></td>
                                            <td colspan="1" style="width: 199px; height: 2px; text-align: center">
                                                <asp:Button ID="Button15" runat="server" Text="Proses" /></td>
                                            <td colspan="1" style="height: 2px; width: 47%; text-align: center;">
                                                <asp:CheckBox ID="CheckBox5" runat="server" Enabled="False" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25px; height: 19px">
                                            </td>
                                            <td style="width: 25px; height: 19px">
                                                <asp:Label ID="Label58" runat="server" Text="Input by : " Width="140px"></asp:Label></td>
                                        </tr>
                                    </table>
                                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script language="javascript" type="text/javascript">
     if(NiftyCheck()) {
	    Rounded("div#div1","all","#ffffff","#0066cc");
    }
	</script>
</body>
</html>
