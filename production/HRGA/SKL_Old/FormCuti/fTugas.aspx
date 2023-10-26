<%@ Page Language="VB" Debug="TRUE"  AutoEventWireup="false" CodeFile="fTugas.aspx.vb" Inherits="_fTugas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Form Cuti</title>
<script language="javascript" type="text/javascript">
<!--

function TABLE1_onclick() {

}

// -->
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="1" cellpadding="5" cellspacing="2" style="width: 100%; height: 100%" id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
            <tr>
                <td valign="top" align="center" style="width: 98%">
                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="SURAT TUGAS"></asp:Label><br />
                                            <asp:Label ID="lblNomor" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label></td>
            </tr>
            <tr>
                <td style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; width: 98%;" valign="top">
                    <table border="1" cellpadding="1" cellspacing="0" style="width: 100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label27" runat="server" Font-Bold="True" Text="Diberikan Kepada :"></asp:Label></td>
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
                                            <asp:TextBox ID="txtNrp" runat="server" Width="104px" AutoPostBack="True" ValidationGroup="kosong"></asp:TextBox>
                                            <A onclick="window.open('PopupNrp.aspx?FormName=' + document.forms[0].name + '&textbox=txtNrp','PopupClass','width=390,height=400,left=300,top=100')"
		            href="javascript:;"><IMG src="Images/GoLtrHS.png" border="0" id="IMG3" runat="server" align="absMiddle" height="16" width="16"></A>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNrp"
                                                ErrorMessage="Mohon diisi..."></asp:RequiredFieldValidator></td>
                                        <td align="right">
                                            <asp:Label ID="Label11" runat="server" Text="Periode Tugas"></asp:Label></td>
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
                                            <asp:Label ID="Label17" runat="server" Text="Alamat di site"></asp:Label></td>
                                        <td style="width: 20px;" align="center" rowspan="4" valign="top">
                                            <asp:Label ID="Label13" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 100px;" rowspan="4" valign="top">
                                            <asp:Label ID="lblAlamatdiSite" runat="server" Font-Size="10pt"></asp:Label></td>
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
                                        PERIODE TUGAS :</caption>
                                    <tr>
                                        <td style="width: 30px; height: 24px">
                                            <asp:Label ID="Label15" runat="server" Text="Tujuan" Width="104px"></asp:Label></td>
                                        <td style="width: 47%; height: 24px">
                                            <asp:TextBox ID="txtTujuan" runat="server" Width="136px"></asp:TextBox></td>
                                        <td style="width: 100%; height: 24px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 24px;">
                                            <asp:Label ID="Label33" runat="server" Text="Awal" Width="104px"></asp:Label></td>
                                        <td style="width: 47%; height: 24px;">
                                            <asp:TextBox ID="txtAwal" runat="server" Width="136px" AutoPostBack="True"></asp:TextBox>
                                            <A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=txtAwal','PopupClass','width=215,height=195,left=330,top=300')"
		                            href="javascript:;"><IMG src="Images/Calendar.png" border="0" id="IMG1" runat="server" align="absMiddle" height="20" width="20"></A>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAwal"
                                                ErrorMessage="Mohon diisi..."></asp:RequiredFieldValidator></td>
                                        <td style="width: 100%; height: 24px;">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px;">
                                            <asp:Label ID="Label34" runat="server" Text="Akhir" Width="104px"></asp:Label></td>
                                        <td colspan="1" style="height: 19px">
                                            <asp:TextBox ID="txtAkhir" runat="server" Width="136px"></asp:TextBox>
                                            <A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=txtAkhir','PopupClass','width=215,height=195,left=330,top=300')"
		                            href="javascript:;"><IMG src="Images/Calendar.png" border="0" id="IMG2" runat="server" align="absMiddle" height="20" width="20"></A></td>
                                        <td colspan="2" style="height: 19px">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px">
                                        </td>
                                        <td colspan="2" style="height: 19px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px">
                                            <asp:Label ID="Label20" runat="server" Text="Penginapan" Width="104px"></asp:Label></td>
                                        <td colspan="2" style="height: 19px">
                                            <asp:TextBox ID="txtPenginapan" runat="server" Width="136px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px">
                                            <asp:Label ID="Label26" runat="server" Text="Transport" Width="104px"></asp:Label></td>
                                        <td colspan="2" style="height: 19px">
                                            <asp:TextBox ID="txtTransport" runat="server" Width="136px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px">
                                            <asp:Label ID="Label14" runat="server" Text="Uang Muka" Width="104px"></asp:Label></td>
                                        <td colspan="2" style="height: 19px">
                                            <asp:TextBox ID="txtUangMuka" runat="server" Width="136px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px">
                                            <asp:Label ID="Label38" runat="server" Text="Keterangan" Width="104px"></asp:Label></td>
                                        <td colspan="2" style="height: 19px">
                                            <asp:TextBox ID="txtKeterangan" runat="server" Width="80%"></asp:TextBox>
                                            <asp:Button ID="btSave" runat="server" Text="  Simpan  " />
                                            <asp:Button ID="btUpdate" runat="server" Text="  Update   " Visible="False" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Panel ID="Panel1" runat="server" Enabled="False" Height="50px" Width="100%">
                        <table border="0" cellpadding="0" cellspacing="0" style="border-right: #3366cc 1px solid;
                            border-top: #3366cc 1px solid; border-left: #3366cc 1px solid; width: 100%; border-bottom: #3366cc 1px solid;
                            background-color: #ffffcc">
                            <caption style="text-align: left">
                                PERSETUJUAN :</caption>
                            <tr>
                                <td style="width: 37%; text-align: right">
                                    <asp:Label ID="Label46" runat="server" Text="Tanggal : "></asp:Label></td>
                                <td style="width: 100%; height: 19px">
                                    &nbsp;<asp:Label ID="lblTg0" runat="server" Font-Bold="True" Font-Italic="False"
                                        Font-Size="10pt"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 37%; text-align: right">
                                    <asp:Label ID="Label18" runat="server" Text="Section Head / Dept Head : "></asp:Label></td>
                                <td style="width: 100%; height: 19px">
                                    &nbsp;<asp:Label ID="lblHead" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 37%; text-align: right">
                                    <asp:Label ID="Label32" runat="server" Text="Persetujuan : "></asp:Label></td>
                                <td style="width: 100%; height: 19px">
                                    &nbsp;<asp:RadioButton ID="ckSetuju" runat="server" GroupName="Persetujuan" Text="Menyetuju" />
                                    <asp:RadioButton ID="ckTidakSetuju" runat="server" GroupName="Persetujuan" Text="Tidak Menyetuju" /></td>
                            </tr>
                            <tr>
                                <td style="width: 37%; text-align: right">
                                    <asp:Label ID="Label40" runat="server" Text="Catatan : "></asp:Label></td>
                                <td style="width: 100%; height: 19px">
                                    &nbsp;<asp:TextBox ID="txtCatatan" runat="server" Width="376px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 37%; height: 24px; text-align: right">
                                </td>
                                <td style="width: 100%; height: 24px">
                                    &nbsp;<asp:Button ID="btnRevisi" runat="server" OnClientClick="DoClick()" Text="  Revisi  " />
                                    <asp:Button ID="btnSetuju" runat="server" Text="    OK    " /></td>
                            </tr>
                        </table>
                    </asp:Panel>
                    &nbsp; &nbsp;
                                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
