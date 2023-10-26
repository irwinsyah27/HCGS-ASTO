<%@ Page Language="VB" Debug="TRUE"  AutoEventWireup="false" CodeFile="fPengalaman.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Form Input Pengalaman </title>
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
<body bgcolor="#000000">
    <form id="form1" runat="server">
    <div id="div1" style="margin: 0 auto; padding:0; width: 900px; background-position: 0% 0%; background-attachment: scroll; background-repeat: repeat;">
    <div>
        <table border="0" cellpadding="5" cellspacing="0" style="width: 100%; height: 100%; border-right: #3366cc 1px solid; border-top: #3366cc 1px solid; border-left: #3366cc 1px solid; border-bottom: #3366cc 1px solid; background-color: white;" id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
            <tr>
                <td valign="top" align="center" style="width: 100%">
                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="FORM INPUT PENGALAMAN KERJA"></asp:Label><br />
                                            <asp:Label ID="lblNomor" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label></td>
            </tr>
            <tr>
                <td style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; width: 100%;" valign="top">
                    <table border="1" cellpadding="1" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="height: 323px">
                                <asp:Panel ID="PanelPelamar" runat="server" Width="900px">
                                    <table border="0" cellpadding="0" cellspacing="1" style="width: 100%">
                                        <tr>
                                            <td colspan="3" style="font-weight: bold; height: 19px; text-decoration: underline">
                                                BIODATA :
                                            </td>
                                            <td align="right" style="height: 19px">
                                            </td>
                                            <td align="center" style="width: 20px; height: 19px">
                                            </td>
                                            <td style="width: 100px; height: 19px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 111px; height: 19px">
                                                <asp:Label ID="Label111" runat="server" Text="Nama"></asp:Label></td>
                                            <td align="center" style="width: 8px; height: 19px">
                                                <asp:Label ID="Label10" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 328px">
                                                <asp:Label ID="LblNama" runat="server" Font-Size="10pt"></asp:Label></td>
                                            <td align="right" valign="top">
                                            </td>
                                            <td align="center" style="width: 20px; height: 19px">
                                            </td>
                                            <td style="width: 100px; height: 19px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 111px; height: 19px">
                                                <asp:Label ID="Label22" runat="server" Text="Tempat lahir"></asp:Label></td>
                                            <td align="center" style="width: 8px; height: 19px">
                                                <asp:Label ID="Label11" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 328px; height: 19px;">
                                            <asp:Label ID="LblTempatLahir" runat="server" Font-Size="10pt"></asp:Label></td>
                                            <td align="right" rowspan="7" valign="top">
                                            </td>
                                            <td align="center" style="width: 20px; height: 19px">
                                            </td>
                                            <td style="width: 100px; height: 19px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 111px; height: 24px">
                                                <asp:Label ID="Label2" runat="server" Text="Tanggal Lahir"></asp:Label></td>
                                            <td align="center" style="width: 8px; height: 24px">
                                                <asp:Label ID="Label12" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 328px; height: 24px">
                                            <asp:Label ID="LblTglLahir" runat="server" Font-Size="10pt"></asp:Label></td>
                                            <td align="center" rowspan="4" style="width: 20px" valign="top">
                                            </td>
                                            <td rowspan="4" style="width: 200px" valign="top">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 111px; height: 19px">
                                                <asp:Label ID="Label4" runat="server" Text="Jenis Kelamin"></asp:Label></td>
                                            <td align="center" style="width: 8px; height: 19px">
                                                <asp:Label ID="Label13" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 328px; height: 19px">
                                            <asp:Label ID="LblJK" runat="server" Font-Size="10pt"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 111px; height: 24px">
                                                <asp:Label ID="Label44" runat="server" Text="Agama"></asp:Label></td>
                                            <td align="center" style="width: 8px; height: 24px">
                                                <asp:Label ID="Label18" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 328px; height: 24px">
                                                <asp:Label ID="LblAgama" runat="server" Font-Size="10pt"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 111px; height: 24px">
                                                <asp:Label ID="Labels" runat="server" Text="Status Kawin"></asp:Label></td>
                                            <td align="center" style="width: 8px; height: 24px">
                                                <asp:Label ID="Label19" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 328px; height: 24px">
                                                <asp:Label ID="LblStatusKawin" runat="server" Font-Size="10pt"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 111px; height: 24px">
                                                <asp:Label ID="Label41" runat="server" Text="Golongan Darah"></asp:Label></td>
                                            <td align="center" style="width: 8px; height: 24px">
                                                <asp:Label ID="Label1" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 328px; height: 24px">
                                                <asp:Label ID="LblGolonganDarah" runat="server" Font-Size="10pt"></asp:Label></td>
                                            <td align="center" rowspan="1" style="width: 20px" valign="top">
                                            </td>
                                            <td rowspan="1" style="width: 200px" valign="top">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; width: 111px; height: 24px; text-align: left">
                                                <asp:Label ID="Label20" runat="server" Text="Alamat Tinggal"></asp:Label></td>
                                            <td align="center" style="vertical-align: top; width: 8px; height: 24px; text-align: center">
                                                <asp:Label ID="Label29" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 328px; height: 24px">
                                            <asp:Label ID="LblAlamat" runat="server" Font-Size="10pt"></asp:Label></td>
                                            <td align="center" rowspan="1" style="width: 20px" valign="top">
                                            </td>
                                            <td rowspan="1" style="width: 200px" valign="top">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 111px; height: 24px">
                                                <asp:Label ID="Label3" runat="server" Text="Kota"></asp:Label></td>
                                            <td align="center" style="width: 8px; height: 24px">
                                                <asp:Label ID="Label30" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 328px; height: 24px">
                                                <asp:Label ID="LblKota" runat="server" Font-Size="10pt"></asp:Label></td>
                                            <td align="right" rowspan="1" valign="top">
                                            </td>
                                            <td align="center" rowspan="1" style="width: 20px" valign="top">
                                            </td>
                                            <td rowspan="1" style="width: 200px" valign="top">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 111px; height: 24px">
                                                <asp:Label ID="Label33" runat="server" Text="Telepon Rumah"></asp:Label></td>
                                            <td align="center" style="width: 8px; height: 24px">
                                                <asp:Label ID="Label31" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 328px; height: 24px">
                                                <asp:Label ID="Lbltelp" runat="server" Font-Size="10pt"></asp:Label></td>
                                            <td align="right" rowspan="1" valign="top">
                                            </td>
                                            <td align="center" rowspan="1" style="width: 20px" valign="top">
                                            </td>
                                            <td rowspan="1" style="width: 200px" valign="top">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 111px; height: 24px">
                                                <asp:Label ID="Label28" runat="server" Text="Handphone"></asp:Label></td>
                                            <td align="center" style="width: 8px; height: 24px">
                                                <asp:Label ID="Label36" runat="server" Text=" : "></asp:Label></td>
                                            <td align="left" style="width: 328px; height: 24px">
                                                <asp:Label ID="LblHP" runat="server" Font-Size="10pt"></asp:Label></td>
                                            <td align="right" rowspan="1" valign="top">
                                            </td>
                                            <td align="center" rowspan="1" style="width: 20px" valign="top">
                                            </td>
                                            <td rowspan="1" style="width: 200px" valign="top">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table border="1" cellpadding="2" cellspacing="0" style="width: 100%">
                        <tr>
                            <td valign="top">
                                <table border="0" cellpadding="0" cellspacing="1" style="width: 100%">
                                    <tr>
                                        <td colspan="4" style="font-weight: bold; text-decoration: underline">
                                            PENDIDIKAN :</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 119px; height: 19px">
                                            <asp:Label ID="Label6" runat="server" Text="Jenjang" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 6px; height: 19px">
                                            <asp:Label ID="Label7" runat="server" Text=" : "></asp:Label></td>
                                        <td align="right" style="width: 655px; height: 19px; text-align: left">
                                            <asp:Label ID="LblJenjang" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td align="left" style="font-size: 12pt; height: 19px">
                                        </td>
                                    </tr>
                                    <tr style="font-size: 12pt">
                                        <td style="width: 119px">
                                            <asp:Label ID="Label9" runat="server" Text="Sekolah" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 6px">
                                            <asp:Label ID="Label14" runat="server" Text=" : "></asp:Label></td>
                                        <td align="right" style="width: 655px; text-align: left">
                                            <asp:Label ID="LblSekolah" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td align="left">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 119px; height: 20px">
                                            <asp:Label ID="Label16" runat="server" Text="Jurusan" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 6px; height: 20px">
                                            <asp:Label ID="Label17" runat="server" Text=" : "></asp:Label></td>
                                        <td align="right" style="width: 655px; height: 20px; text-align: left">
                                            <asp:Label ID="LblJurusan" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td align="left" style="height: 20px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 119px; height: 20px">
                                            <asp:Label ID="Label25" runat="server" Text="Akreditasi" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 6px; height: 20px">
                                            <asp:Label ID="Label32" runat="server" Text=" : "></asp:Label></td>
                                        <td align="right" style="width: 655px; height: 20px; text-align: left">
                                            <asp:Label ID="LblAkreditasi" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td align="left" style="height: 20px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 119px; height: 20px">
                                            <asp:Label ID="Label35" runat="server" Text="Tahun Lulus" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 6px; height: 20px">
                                            <asp:Label ID="Label38" runat="server" Text=" : "></asp:Label></td>
                                        <td align="right" style="width: 655px; height: 20px; text-align: left">
                                            <asp:Label ID="LblThnLulus" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td align="left" style="height: 20px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 119px; height: 19px; text-align: left">
                                            <asp:Label ID="Label40" runat="server" Text="IPK" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 6px; height: 19px; text-align: left">
                                            <asp:Label ID="Label42" runat="server" Text=" : "></asp:Label></td>
                                        <td align="right" style="width: 655px; height: 19px; text-align: left">
                                            <asp:Label ID="LblIPK" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td align="left">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table border="1" cellpadding="2" cellspacing="0" style="border-right: #cccccc 1px solid;
                        border-top: #cccccc 1px solid; border-left: #cccccc 1px solid; width: 100%; border-bottom: #cccccc 1px solid" bordercolor="#cccccc">
                        <tr>
                            <td style="width: 60%" valign="top">
                                <table bordercolor="#cccccc" cellpadding="2" cellspacing="0" style="width: 100%">
                                    <caption align="left">
                                        <strong><span style="text-decoration: underline">PENGALAMAN KERJA :</span></strong></caption>
                                    <tr>
                                        <td align="left" colspan="5" valign="top">
                                            <asp:GridView ID="GridPengalaman" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                                DataSourceID="SqlDataSource1" Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="9pt" ForeColor="Black" GridLines="Horizontal">
                                                <Columns>
                                                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True"  ButtonType=Image DeleteImageUrl="http://pama-tala/HRGA/Cuti/Images/Delete.gif" EditImageUrl="http://pama-tala/HRGA/Cuti/Images/Edit.gif" CancelImageUrl="http://pama-tala/HRGA/Cuti/Images/Cancel.gif" UpdateImageUrl="http://pama-tala/HRGA/Cuti/Images/Update.gif"/>
                                                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                                                        SortExpression="ID" Visible="False" />
                                                    <asp:BoundField DataField="KodeLamaran" HeaderText="KodeLamaran" SortExpression="KodeLamaran" Visible="False" />
                                                    <asp:TemplateField HeaderText="Deskripsi" SortExpression="Deskripsi">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Deskripsi") %>' Width="112px"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Deskripsi") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="BidangKerja" SortExpression="BidangKerja">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("BidangKerja") %>' Width="37px"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("BidangKerja") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Posisi" SortExpression="Posisi">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Posisi") %>' Width="112px"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Posisi") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="LamaKerja" SortExpression="LamaKerja">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("LamaKerja") %>' Width="78px"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("LamaKerja") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Keterangan" SortExpression="Keterangan">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Keterangan") %>' Width="132px"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Keterangan") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                                                DeleteCommand="DELETE FROM [tblPelamar_Pengalaman] WHERE [ID] = @ID" InsertCommand="INSERT INTO [tblPelamar_Pengalaman] ([KodeLamaran], [Deskripsi], [BidangKerja], [Posisi], [LamaKerja], [Keterangan]) VALUES (@KodeLamaran, @Deskripsi,@BidangKerja, @Posisi, @LamaKerja, @Keterangan)"
                                                SelectCommand="SELECT [ID], [KodeLamaran], [Deskripsi], [BidangKerja], [Posisi], [LamaKerja], [Keterangan] FROM [tblPelamar_Pengalaman] WHERE [KodeLamaran] = @KodeLamaran UNION &#13;&#10;SELECT '0' AS [ID], '0' AS  [KodeLamaran], '' AS  [Deskripsi],'' AS  [BidangKerja],   '' AS [Posisi],  '' AS [LamaKerja], '' AS  [Keterangan] FROM [tblPelamar_Pengalaman] ORDER BY [ID] DESC"
                                                UpdateCommand="UPDATE [tblPelamar_Pengalaman] SET  [Deskripsi] = @Deskripsi, [BidangKerja] = @BidangKerja, [Posisi] = @Posisi, [LamaKerja] = @LamaKerja, [Keterangan] = @Keterangan WHERE [ID] = @ID">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="lblNomor" Name="KodeLamaran" PropertyName="Text"
                                                        Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                                </td>
            </tr>
        </table>
    </div>
    </div>
    </form>
<%--    <script type="text/javascript">
        var x=window.confirm("Perlu transportasi...?    ")
        if (x)
            window.alert("Silahkan isi nama, umur, tanggal keberanggkatan, dan keterangan lainnya..  ")
        else
            window.close()
    </script>--%>
    <script language="javascript" type="text/javascript">
    if(NiftyCheck()) {
	    Rounded("div#div1","all","#ffffff","#0066cc");
    }
		GridViewHelper.Init(document.all.GridView2, 100,0);
	</script>
</body>
</html>
