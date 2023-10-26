<%@ Page Language="VB" Debug="TRUE"  AutoEventWireup="false" CodeFile="InputPosisiPelamar.aspx.vb" Inherits="_fCuti1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Form Input Posisi Pelamar</title>
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
                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="FORM INPUT POSISI PELAMAR"></asp:Label><br />
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
                                            <td align="center" rowspan="1" style="width: 20px" valign="top">
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
                                        <td style="width: 40px">
                                        </td>
                                        <td style="width: 119px">
                                            <asp:Label ID="Label24" runat="server" Text="Sekolah" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 6px">
                                            <asp:Label ID="Label48" runat="server" Text=" : "></asp:Label></td>
                                        <td align="right" style="width: 655px; text-align: left">
                                            <asp:Label ID="LblSekolah" runat="server" Font-Size="10pt" Font-Bold="True"></asp:Label>&nbsp;</td>
                                        <td align="left">
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
                                            <asp:Label ID="LblJurusan" runat="server" Font-Size="10pt" Font-Bold="True"></asp:Label>&nbsp;</td>
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
                    <table border="1" cellpadding="1" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="vertical-align: top; height: 89px; text-align: left">
                                <asp:Panel ID="Panel2" runat="server" Width="900px" Font-Bold="False" Font-Underline="False">
                                    <table border="0" cellpadding="0" cellspacing="1" style="width: 100%">
                                        <tr>
                                            <td colspan="6" style="font-weight: bold; height: 19px; text-decoration: underline">
                                                PENGALAMAN KERJA :</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 1px; height: 68px">
                                            </td>
                                            <td colspan="1" style="width: 24px; height: 68px">
                                            </td>
                                            <td style="height: 68px" colspan="3">
                                 <asp:GridView ID="GridPengalaman" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                                DataSourceID="SqlDataSource1" Width="96%" BackColor="LightGray" BorderStyle="None" CellPadding="2" Font-Size="9pt" ForeColor="Black" GridLines="Horizontal" PageSize="4">
                                                <Columns>
                                                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                                                        SortExpression="ID" Visible="False" />
                                                    <asp:BoundField DataField="KodeLamaran" HeaderText="KodeLamaran" SortExpression="KodeLamaran" Visible="False" />
                                                    <asp:TemplateField HeaderText="Deskripsi" SortExpression="Deskripsi">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox1000" runat="server" Text='<%# Bind("Deskripsi") %>' Width="112px"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1000" runat="server" Text='<%# Bind("Deskripsi") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="BidangKerja" SortExpression="BidangKerja">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox2000" runat="server" Text='<%# Bind("BidangKerja") %>' Width="37px"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label2000" runat="server" Text='<%# Bind("BidangKerja") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Posisi" SortExpression="Posisi">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Posisi") %>' Width="112px"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3000" runat="server" Text='<%# Bind("Posisi") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="LamaKerja" SortExpression="LamaKerja">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox4000" runat="server" Text='<%# Bind("LamaKerja") %>' Width="78px"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label4000" runat="server" Text='<%# Bind("LamaKerja") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Keterangan" SortExpression="Keterangan">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox5000" runat="server" Text='<%# Bind("Keterangan") %>' Width="132px"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label5000" runat="server" Text='<%# Bind("Keterangan") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
                                                SelectCommand="SELECT [ID], [KodeLamaran], [Deskripsi], [BidangKerja], [Posisi], [LamaKerja], [Keterangan] FROM [tblPelamar_Pengalaman] WHERE [KodeLamaran] = @KodeLamaran "
                                                UpdateCommand="UPDATE [tblPelamar_Pengalaman] SET  [Deskripsi] = @Deskripsi, [BidangKerja] = @BidangKerja, [Posisi] = @Posisi, [LamaKerja] = @LamaKerja, [Keterangan] = @Keterangan WHERE [ID] = @ID">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="lblNomor" Name="KodeLamaran" PropertyName="Text"
                                                        Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>          
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
                                <asp:Panel ID="PanelPosisi" runat="server" Width="450px">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <caption align="left" style="font-weight: bold; text-decoration: underline">
                                        POSISI LAMARAN :</caption>
                                    <tr>
                                        <td style="width: 50px; height: 2px">
                                            <asp:Label ID="Label5" runat="server" Text="Site" Width="104px"></asp:Label></td>
                                        <td style="width: 30px; height: 2px">
                                        </td>
                                        <td style="width: 6px; height: 2px; text-align: left">
                                            <asp:Label ID="Label6" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 47%; height: 2px; text-align: left">
                                            <asp:DropDownList ID="DDLSite" runat="server">
                                                <asp:ListItem>KPP Rantau</asp:ListItem>
                                                <asp:ListItem>KPP Taja</asp:ListItem>
                                                <asp:ListItem>KPP Port</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50px; height: 2px">
                                            <asp:Label ID="Label32" runat="server" Text="Departemen" Width="104px"></asp:Label></td>
                                        <td style="width: 30px; height: 2px">
                                        </td>
                                        <td style="width: 6px; height: 2px; text-align: left">
                                            <asp:Label ID="Label39" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 47%; height: 2px; text-align: left">
                                            <asp:DropDownList ID="DDLDept" runat="server" AutoPostBack="True" DataSourceID="SqlDataDept"
                                                DataTextField="Dept" DataValueField="Dept">
                                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataDept" runat="server" ConnectionString="<%$ ConnectionStrings:PersisConnectionString %>"
                                                SelectCommand="SELECT DISTINCT [Dept] FROM [Tbl_Dept] UNION SELECT 'Others' AS [Dept]"></asp:SqlDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50px; height: 2px;">
                                            <asp:Label ID="Label35" runat="server" Text="Jabatan" Width="104px"></asp:Label></td>
                                        <td style="width: 30px; height: 2px">
                                        </td>
                                        <td style="width: 6px; height: 2px; text-align: left">
                                            <asp:Label ID="Label12" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 47%; height: 2px; text-align: left;">
                                            <asp:DropDownList ID="DDLJabatan" runat="server" DataSourceID="SqlDataJabatan" DataTextField="Jabatan"
                                                DataValueField="Jabatan">
                                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataJabatan" runat="server" ConnectionString="<%$ ConnectionStrings:PersisConnectionString %>"
                                                SelectCommand="SELECT DISTINCT [Jabatan] FROM [tblKaryawan] WHERE ([Departemen] = @Departemen)">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="DDLDept" Name="Departemen" PropertyName="SelectedValue"
                                                        Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50px; height: 19px">
                                        </td>
                                        <td style="width: 30px; height: 19px">
                                        </td>
                                        <td colspan="1" style="width: 6px; height: 19px">
                                        </td>
                                        <td colspan="1" style="height: 19px">
                                            <asp:TextBox ID="txtJabatan" runat="server" Visible="False" Width="299px"></asp:TextBox></td>
                                        <td colspan="1" style="height: 19px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50px; height: 19px;">
                                            <asp:Label ID="Label34" runat="server" Text="Referensi" Width="104px"></asp:Label></td>
                                        <td style="width: 30px; height: 19px">
                                        </td>
                                        <td colspan="1" style="width: 6px; height: 19px">
                                            <asp:Label ID="Label13" runat="server" Text=" : "></asp:Label></td>
                                        <td colspan="1" style="height: 19px">
                                            <asp:TextBox ID="TxtReff" runat="server" Width="299px"></asp:TextBox></td>
                                        <td colspan="1" style="height: 19px">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50px; height: 19px">
                                            <asp:Label ID="Label38" runat="server" Text="Resource" Width="104px"></asp:Label></td>
                                        <td style="width: 30px; height: 19px">
                                        </td>
                                        <td colspan="1" style="width: 6px; height: 19px">
                                            <asp:Label ID="Label14" runat="server" Text=" : "></asp:Label></td>
                                        <td colspan="1" style="height: 19px">
                                            <asp:TextBox ID="TxtResources" runat="server" Width="400px" MaxLength="200"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50px; height: 13px">
                                            </td>
                                        <td style="width: 30px; height: 13px">
                                        </td>
                                        <td colspan="1" style="width: 6px; height: 13px">
                                        </td>
                                        <td colspan="1" style="height: 13px">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                                            <asp:Button ID="btSave" runat="server" Text="  Simpan  " /></asp:Panel><asp:Panel ID="PanelPosisi1" runat="server" Width="900px" Visible="False">
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                    <caption align="left" style="font-weight: bold; text-decoration: underline">
                                                        POSISI LAMARAN :</caption>
                                                    <tr>
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
                                                            <asp:Label ID="Label9" runat="server" Text="Departemen" Width="104px"></asp:Label></td>
                                                        <td style="width: 30px; height: 2px">
                                                        </td>
                                                        <td style="width: 6px; height: 2px; text-align: left">
                                                            <asp:Label ID="Label15" runat="server" Text=" : "></asp:Label></td>
                                                        <td style="width: 47%; height: 2px; text-align: left">
                                                            <asp:Label ID="LblDept" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
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
                                                        <td style="width: 30px; height: 19px">
                                                        </td>
                                                        <td colspan="1" style="width: 6px; height: 19px">
                                                        </td>
                                                        <td colspan="1" style="height: 19px">
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                                <asp:Label ID="Label43" runat="server" Text="Input by : " Width="104px"></asp:Label>
                                                <asp:Label ID="LblInput" runat="server"></asp:Label></asp:Panel>
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
