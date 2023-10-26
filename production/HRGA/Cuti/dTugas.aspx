<%@ Page Language="VB" Debug="TRUE"  AutoEventWireup="false" CodeFile="dTugas.aspx.vb" Inherits="_dTugas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Form Cuti</title>
    <script src="GridViewHelper.js" type="text/javascript"></script>
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
    <div id="div1" style="margin: 0 auto; padding:0; background: #ffcc66; width: 900px; height: 100%;">
    <div>
        <table border="0" cellpadding="5" cellspacing="0" style="width: 100%; height: 100%" id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
            <tr>
                <td valign="top" align="center" style="width: 96%">
                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="SURAT TUGAS"></asp:Label><br />
                                            <asp:Label ID="lblNomor" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label></td>
            </tr>
            <tr>
                <td style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; width: 96%; height: 1006px;" valign="top">
                    <table border="1" cellpadding="1" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="background-color: gainsboro">
                                <asp:Label ID="Label25" runat="server" Font-Bold="True" Text="Diberikan Kepada :"></asp:Label></td>
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
                                            <asp:Label ID="Label11" runat="server" Text="Periode Tugas" Width="95px"></asp:Label></td>
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
                                            <asp:Label ID="Label19" runat="server" Text="No. Telp / Hp" Width="95px"></asp:Label></td>
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
                                            <asp:Label ID="Label17" runat="server" Text="Alamat di site" Width="95px"></asp:Label></td>
                                        <td style="width: 20px;" align="center" rowspan="4" valign="top">
                                            <asp:Label ID="Label13" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 100px;" rowspan="4" valign="top">
                                            <asp:Label ID="lblAlamatdiSite" runat="server" Font-Size="10pt" Width="177px"></asp:Label></td>
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
                                            &nbsp;<asp:Label ID="Label3" runat="server" Text="Status Penerimaan" Width="120px" Visible="False"></asp:Label></td>
                                        <td align="center" style="width: 28px; height: 24px">
                                            <asp:Label ID="Label10" runat="server" Text=" : " Visible="False"></asp:Label></td>
                                        <td align="left" style="width: 262px; height: 24px">
                                            &nbsp;<asp:Label ID="lblStatusPenerimaan" runat="server" Font-Size="10pt" Visible="False"></asp:Label></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table border="1" cellpadding="2" cellspacing="0" style="width: 100%">
                        <tr>
                            <td colspan="2" valign="top" style="height: 117px">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <caption align="left">
                                        <asp:Label ID="Label24" runat="server" Font-Bold="True" Text="Keperluan :"></asp:Label></caption>
                                    <tr>
                                        <td style="width: 30px; height: 24px">
                                            <asp:Label ID="Label15" runat="server" Text="Tujuan" Width="104px"></asp:Label></td>
                                        <td style="width: 47%; height: 24px">
                                            <asp:TextBox ID="txtTujuan" runat="server" Enabled="False" Width="136px"></asp:TextBox></td>
                                        <td style="width: 100%; height: 24px">
                                            <asp:Label ID="Label20" runat="server" Text="Penginapan" Width="104px"></asp:Label><asp:TextBox ID="txtPenginapan" runat="server" Enabled="False" Width="136px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 24px;">
                                            <asp:Label ID="Label33" runat="server" Text="Awal" Width="104px"></asp:Label></td>
                                        <td style="width: 47%; height: 24px;">
                                            <asp:TextBox ID="txtAwal" runat="server" Width="136px" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                            <A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=txtAwal','PopupClass','width=215,height=195,left=330,top=300')"
		                            href="javascript:;"><IMG src="Images/Calendar.png" border="0" id="IMG1" runat="server" align="absMiddle" height="20" width="20" visible="false"></A>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAwal"
                                                ErrorMessage="Mohon diisi..."></asp:RequiredFieldValidator></td>
                                        <td style="width: 100%; height: 24px;">
                                            <asp:Label ID="Label26" runat="server" Text="Transport" Width="104px"></asp:Label><asp:TextBox ID="txtTransport" runat="server" Enabled="False" Width="136px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px;">
                                            <asp:Label ID="Label34" runat="server" Text="Akhir" Width="104px"></asp:Label></td>
                                        <td colspan="1" style="height: 19px">
                                            <asp:TextBox ID="txtAkhir" runat="server" Width="136px" Enabled="False"></asp:TextBox>
                                            <IMG src="Images/Calendar.png" border="0" id="IMG2" runat="server" align="absMiddle" height="20" width="20" visible="false"></td>
                                        <td colspan="2" style="height: 19px">
                                            <asp:Label ID="Label14" runat="server" Text="Uang Muka" Width="104px"></asp:Label><asp:TextBox ID="txtUangMuka" runat="server" Enabled="False" Width="136px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px" valign="top">
                                            <asp:Label ID="Label38" runat="server" Text="Keterangan" Width="104px"></asp:Label></td>
                                        <td colspan="2" style="height: 19px">
                                            <asp:TextBox ID="txtKeterangan" runat="server" Width="45%" Enabled="False"></asp:TextBox>
                                            <asp:Button ID="btSave" runat="server" Text="  Simpan  " />
                                            <asp:Button ID="btUpdate" runat="server" Text="  Update   " Visible="False" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table border="1" bordercolor="#cccccc" cellpadding="2" cellspacing="0" style="border-right: #cccccc 1px solid;
                        border-top: #cccccc 1px solid; border-left: #cccccc 1px solid; width: 100%; border-bottom: #cccccc 1px solid">
                        <tr>
                            <td style="width: 60%" valign="top">
                                <table bordercolor="#cccccc" cellpadding="2" cellspacing="0" style="width: 100%">
                                    <caption align="left">
                                        FLIGHT FARE :</caption>
                                    <tr>
                                        <td align="left" colspan="5" style="height: 19px" valign="top">
                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                                DataSourceID="SqlDataSource1" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="9pt">
                                                <Columns>
                                                    <asp:CommandField ButtonType="Image" CancelImageUrl="Images/Cancel.gif" DeleteImageUrl="Images/Delete.gif"
                                                        EditImageUrl="Images/Edit.gif" ShowDeleteButton="True" ShowEditButton="True"
                                                        UpdateImageUrl="Images/Update.gif" Visible="False" />
                                                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                                                        SortExpression="ID" Visible="False" />
                                                    <asp:BoundField DataField="NomorST" HeaderText="NomorST" SortExpression="NomorST"
                                                        Visible="False" />
                                                    <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
                                                    <asp:BoundField DataField="Umur" HeaderText="Umur" SortExpression="Umur" />
                                                    <asp:BoundField DataField="Tanggal" HeaderText="Tanggal" SortExpression="Tanggal" />
                                                    <asp:BoundField DataField="Dari_Ke" HeaderText="Dari_Ke" SortExpression="Dari_Ke" />
                                                    <asp:BoundField DataField="Keterangan" HeaderText="Keterangan" SortExpression="Keterangan" />
                                                </Columns>
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <RowStyle BackColor="#EFF3FB" />
                                                <EditRowStyle BackColor="#2461BF" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                                                DeleteCommand="DELETE FROM [tblFlight] WHERE [ID] = @ID" InsertCommand="INSERT INTO [tblFlight] ([NomorST], [Nama], [Umur], [Tanggal], [Dari_Ke], [Keterangan]) VALUES (@NomorST, @Nama,@Umur, @Tanggal, @Dari_Ke, @Keterangan)"
                                                SelectCommand="SELECT [ID], [NomorST], [Nama], [Umur], [Tanggal], [Dari_Ke], [Keterangan] FROM [tblFlight] WHERE [NomorST] = @Nomor UNION &#13;&#10;SELECT '0' AS [ID], '0' AS  [NomorST], '' AS  [Nama],'' AS  [Umur],   Getdate() AS [Tanggal],  '' AS [Dari_Ke], '' AS  [Keterangan] FROM [tblFlight] ORDER BY [ID] DESC"
                                                UpdateCommand="UPDATE [tblFlight] SET  [Nama] = @Nama, [Umur] = @Umur, [Tanggal] = @Tanggal, [Dari_Ke] = @Dari_Ke, [Keterangan] = @Keterangan WHERE [ID] = @ID">
                                                <DeleteParameters>
                                                    <asp:Parameter Name="ID" Type="Int32" />
                                                </DeleteParameters>
                                                <UpdateParameters>
                                                    <asp:Parameter Name="Nama" Type="String" />
                                                    <asp:Parameter Name="Umur" />
                                                    <asp:Parameter Name="Tanggal" Type="DateTime" />
                                                    <asp:Parameter Name="Dari_Ke" Type="String" />
                                                    <asp:Parameter Name="Keterangan" Type="String" />
                                                    <asp:Parameter Name="ID" Type="Int32" />
                                                </UpdateParameters>
                                                <InsertParameters>
                                                    <asp:Parameter Name="NomorST" Type="String" />
                                                    <asp:Parameter Name="Nama" Type="String" />
                                                    <asp:Parameter Name="Umur" />
                                                    <asp:Parameter Name="Tanggal" Type="DateTime" />
                                                    <asp:Parameter Name="Dari_Ke" Type="String" />
                                                    <asp:Parameter Name="Keterangan" Type="String" />
                                                </InsertParameters>
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="lblNomor" Name="Nomor" PropertyName="Text" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td rowspan="1" style="width: 40%" valign="top">
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Panel ID="Panel2" runat="server" Height="100px" Width="100%">
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
                                    <asp:Label ID="Label41" runat="server" Text="Hrpga Sect. Head/Hrpga Dept. Head : "></asp:Label></td>
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
                                <td style="width: 37%; height: 10px; text-align: right">
                                </td>
                                <td style="width: 100%; height: 10px">
                                    &nbsp;<asp:Button ID="btnRevisi" runat="server" OnClientClick="DoClick()" Text="  Revisi  " />
                                    <asp:Button ID="btnSetujuHrga" runat="server" Text="    OK    " />&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <br />
                    <asp:Panel ID="Panel3" runat="server" Height="100px" Visible="False" Width="100%">
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
                                    <asp:Label ID="Label47" runat="server" Text="Hrpga Dept. Head/Project Manager : "></asp:Label></td>
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
		GridViewHelper.Init(document.all.GridView2, 100,0);
	</script>
</body>
</html>
