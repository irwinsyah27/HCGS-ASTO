<%@ Page Language="VB" Debug="TRUE"  AutoEventWireup="false" CodeFile="pTugas.aspx.vb" Inherits="_pTugas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Form Cuti</title>
    <script src="GridViewHelper.js" type="text/javascript"></script>
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
                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="SURAT TUGAS" Font-Size="16pt"></asp:Label><br />
                                            <asp:Label ID="lblNomor" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label></td>
                <td align="center" valign="top" width="35%">
                </td>
            </tr>
            <tr>
                <td style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none;" valign="top" colspan="3">
                    <table border="0" cellpadding="1" cellspacing="0" style="width: 100%; border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid;">
                        <tr>
                            <td style="height: 174px">
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
                                            <asp:Label ID="Label11" runat="server" Text="Periode Tugas" Width="94px" Visible="False"></asp:Label>
                                            </td>
                                        <td align="right" width="100">
                                            <asp:Label ID="Label19" runat="server" Text="No. Telp / Hp" Width="92px" Font-Size="10pt"></asp:Label></td>
                                        <td align="center" style="width: 20px; height: 19px">
                                            <asp:Label ID="Label16" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 100px; height: 19px">
                                            <asp:Label ID="lblNoTelp" runat="server" Font-Size="10pt"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 19px; width: 161px;">
                                            <asp:Label ID="Label1" runat="server" Text="Nama" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="Label6" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="width: 262px">
                                            <asp:Label ID="lblNama" runat="server" Font-Size="10pt"></asp:Label>
                                            <asp:Label ID="lblPeriodeTugas" runat="server" Font-Size="10pt" Width="64px" Visible="False"></asp:Label></td>
                                        <td align="right" width="100" valign="top">
                                            <asp:Label ID="Label17" runat="server" Text="Alamat" Font-Size="10pt"></asp:Label></td>
                                        <td style="width: 20px; height: 19px" align="center">
                                            <asp:Label ID="Label12" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 200px;" rowspan="5" valign="top">
                                            <asp:Label ID="lblAlamatdiSite" runat="server" Font-Size="10pt" Width="98%"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 24px; width: 161px;">
                                            <asp:Label ID="Label2" runat="server" Text="Jabatan / Dept "></asp:Label></td>
                                        <td align="center" style="width: 28px; height: 24px">
                                            <asp:Label ID="Label7" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="height: 24px; width: 262px;">
                                            <asp:Label ID="lblJabatan" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td align="right" rowspan="4" valign="top" width="100">
                                            </td>
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
                    <table border="0" cellpadding="2" cellspacing="0" style="width: 100%; border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid;">
                        <tr>
                            <td colspan="2" style="height: 117px" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <caption align="left">
                                        <asp:Label ID="Label27" runat="server" Text="KEPERLUAN :"></asp:Label></caption>
                                    <tr>
                                        <td style="width: 30px; height: 24px">
                                            <asp:Label ID="Label18" runat="server" Text="Tujuan" Width="104px"></asp:Label></td>
                                        <td style="width: 47%; height: 24px">
                                            <asp:TextBox ID="txtTujuan" runat="server" Width="136px" ReadOnly="True"></asp:TextBox></td>
                                        <td style="width: 100%; height: 24px">
                                            <asp:Label ID="Label20" runat="server" Text="Penginapan" Width="104px"></asp:Label><asp:TextBox ID="txtPenginapan" runat="server" Width="136px" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 24px">
                                            <asp:Label ID="Label33" runat="server" Text="Awal" Width="104px"></asp:Label></td>
                                        <td style="width: 47%; height: 24px">
                                            <asp:TextBox ID="txtAwal" runat="server" AutoPostBack="True" Width="136px" ReadOnly="True"></asp:TextBox>
                                            <a href="javascript:;" onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=txtAwal','PopupClass','width=215,height=195,left=330,top=300')">
                                                <img id="IMG1" runat="server" align="absMiddle" border="0" height="20" src="Images/Calendar.png"
                                                    width="20" visible="false" /></a>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAwal"
                                                ErrorMessage="Mohon diisi..."></asp:RequiredFieldValidator></td>
                                        <td style="width: 100%; height: 24px">
                                            <asp:Label ID="Label26" runat="server" Text="Transport" Width="104px"></asp:Label><asp:TextBox ID="txtTransport" runat="server" Width="136px" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px">
                                            <asp:Label ID="Label34" runat="server" Text="Akhir" Width="104px"></asp:Label></td>
                                        <td colspan="1" style="height: 19px">
                                            <asp:TextBox ID="txtAkhir" runat="server" Width="136px" ReadOnly="True"></asp:TextBox>
                                            <a href="javascript:;" onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=txtAkhir','PopupClass','width=215,height=195,left=330,top=300')">
                                                <img id="IMG2" runat="server" align="absMiddle" border="0" height="20" src="Images/Calendar.png"
                                                    width="20" visible="false" /></a></td>
                                        <td colspan="2" style="height: 19px">
                                            <asp:Label ID="Label14" runat="server" Text="Uang Muka" Width="104px"></asp:Label><asp:TextBox ID="txtUangMuka" runat="server" Width="136px" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px">
                                            <asp:Label ID="Label38" runat="server" Text="Keterangan" Width="104px"></asp:Label></td>
                                        <td colspan="2" style="height: 19px">
                                            <asp:TextBox ID="txtKeterangan" runat="server" Width="80%" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                                            <asp:Button ID="btSave" runat="server" Text="  Simpan  " Visible="False" />
                                            <asp:Button ID="btUpdate" runat="server" Text="  Update   " Visible="False" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table border="1" cellpadding="2" cellspacing="0" style="border-right: #000000 1px solid;
                        border-top: #000000 1px solid; border-left: #000000 1px solid; width: 100%; border-bottom: #000000 1px solid" bordercolor="#cccccc">
                        <tr>
                            <td style="width: 77%" valign="top">
                                <table bordercolor="#cccccc" cellpadding="2" cellspacing="0" style="width: 100%">
                                    <caption align="left">
                                        FLIGHT FARE :</caption>
                                    <tr>
                                        <td align="left" colspan="5" style="height: 19px" valign="top">
                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                                DataSourceID="SqlDataSource1" Width="100%" Font-Size="9pt">
                                                <Columns>
                                                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True"  ButtonType=Image DeleteImageUrl="Images/Delete.gif" EditImageUrl="Images/Edit.gif" CancelImageUrl="Images/Cancel.gif" UpdateImageUrl="Images/Update.gif"/>
                                                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                                                        SortExpression="ID" Visible="False" />
                                                    <asp:BoundField DataField="NomorST" HeaderText="NomorST" SortExpression="NomorST" Visible="False" />
                                                    <asp:BoundField DataField="Nama" HeaderText="Nama" SortExpression="Nama" />
                                                    <asp:BoundField DataField="Umur" HeaderText="Umur" SortExpression="Umur" />
                                                    <asp:BoundField DataField="Tanggal" HeaderText="Tanggal" SortExpression="Tanggal" />
                                                    <asp:BoundField DataField="Dari_Ke" HeaderText="Dari_Ke" SortExpression="Dari_Ke" />
                                                    <asp:BoundField DataField="Keterangan" HeaderText="Keterangan" SortExpression="Keterangan" />
                                                </Columns>
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                                                DeleteCommand="DELETE FROM [tblFlight] WHERE [ID] = @ID" InsertCommand="INSERT INTO [tblFlight] ([NomorST], [Nama], [Umur], [Tanggal], [Dari_Ke], [Keterangan]) VALUES (@NomorST, @Nama,@Umur, @Tanggal, @Dari_Ke, @Keterangan)"
                                                SelectCommand="SELECT [ID], [NomorST], [Nama], [Umur], [Tanggal], [Dari_Ke], [Keterangan] FROM [tblFlight] WHERE [NomorST] = @Nomor UNION &#13;&#10;SELECT '0' AS [ID], '0' AS  [NomorST], '' AS  [Nama],'' AS  [Umur],  Null AS [Tanggal],  '' AS [Dari_Ke], '' AS  [Keterangan] FROM [tblFlight] ORDER BY [ID] DESC"
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
                    <asp:Panel ID="Panel5" runat="server" Height="50px" Width="100%">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td colspan="2" style="text-align: center">
                                PERSETUJUAN</td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" valign="bottom" width="35%">
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
                                <td style="text-align: center" valign="bottom" width="35%">
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
                                </td>
                                <td style="text-align: center" valign="bottom" width="30%">
                                    <asp:Label ID="Label48" runat="server" Text="Personnel Admin : " Width="80%" Visible="False"></asp:Label><br />
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td width="100%">
                                                <asp:Image ID="imgSignAdmin" runat="server" Height="134px" Visible="False" Width="144px" /></td>
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
                                </td>
            </tr>
        </table>
    
    </div>
    </form>
    <script language="javascript" type="text/javascript">
		GridViewHelper.Init(document.all.GridView2, 100,0);
		previewit();
	</script>
	
</body>
</html>
