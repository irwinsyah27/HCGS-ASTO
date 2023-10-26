<%@ Page Language="VB" Debug="TRUE" AutoEventWireup="false" CodeFile="harike7.aspx.vb" Inherits="HRGA_SKL_SKaEl_Ha" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; position: static">
            <tr>
                <td align="center" colspan="3" style="border-right: black 2px solid; border-top: black 2px solid;
                    font-weight: normal; text-transform: uppercase; border-left: black 2px solid;
                    color: blue; font-family: 'Berlin Sans FB'; height: 19px; background-color: lemonchiffon;
                    text-decoration: underline">
                    SURAT KESEPAKATAN LEMBUR HARIAN</td>
            </tr>
            <tr>
                <td align="center" colspan="3" style="border-right: black 2px solid; border-left: black 2px solid;
                    border-bottom: black 1px double">
                    <asp:Label ID="LblNoSKL" runat="server" Enabled="False" Style="border-left-width: 2px;
                        border-left-color: black; border-bottom-width: 1px; border-bottom-color: black;
                        background-color: lemonchiffon; border-right-width: 2px; border-right-color: black"
                        Text="No SKL : Auto Number........." Width="100%"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3" style="border-right: black 2px solid; border-left: black 2px solid;
                    border-bottom: silver 1px dotted">
                    <asp:Label ID="Lblrequestor" runat="server" Style="font-weight: bolder; font-size: medium;
                        text-transform: uppercase; color: maroon; font-family: 'Baskerville Old Face', Fantasy;
                        background-color: silver; text-decoration: underline" Text="REQUESTOR" Width="100%"></asp:Label></td>
            </tr>
            <tr>
                <td style="border-left: black 2px solid; width: 5%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:Label ID="LblNRPR" runat="server" Text="NRP" Width="100%"></asp:Label></td>
                <td align="center" style="width: 5%; border-bottom: maroon 1px solid; background-color: floralwhite">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                        Text=":" Width="100%"></asp:Label></td>
                <td style="border-right: black 2px solid; width: 48%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:Label ID="LblNRPRequestor" runat="server" Width="100%"></asp:Label></td>
            </tr>
            <tr>
                <td style="border-left: black 2px solid; width: 5%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:Label ID="LblNamaR" runat="server" Style="border-left-width: 2px; border-left-color: black"
                        Text="Nama " Width="100%"></asp:Label></td>
                <td align="center" style="width: 5%; border-bottom: maroon 1px solid; background-color: floralwhite">
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                        Text=":" Width="100%"></asp:Label></td>
                <td style="border-right: black 2px solid; width: 48%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:Label ID="LblNamarequestor" runat="server" Width="100%"></asp:Label></td>
            </tr>
            <tr>
                <td style="border-left: black 2px solid; width: 5%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:Label ID="Label11" runat="server" Text="Tanggal " Width="100%"></asp:Label></td>
                <td align="center" style="width: 5%; border-bottom: maroon 1px solid; background-color: floralwhite">
                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                        Text=":" Width="100%"></asp:Label></td>
                <td style="border-right: black 2px solid; width: 48%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:Label ID="LblTanggalCreated" runat="server" Width="100%"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3" style="border-left: black 2px solid; border-bottom: maroon 1px solid;
                    background-color: silver; font-weight: bold; text-transform: uppercase; color: maroon; font-family: 'Baskerville Old Face', Fantasy; text-decoration: underline;">
                    JAM LEMBUR :</td>
            </tr>
            <tr>
                <td style="border-left: black 2px solid; width: 25%; border-bottom: maroon 1px solid;
                    background-color: floralwhite; border-right-width: 2px; border-right-color: black">
                    <asp:Label ID="lblawalskl" runat="server" Text="Awal SKL" Width="100%"></asp:Label></td>
                <td align="center" style="width: 5%; border-bottom: maroon 1px solid; background-color: floralwhite">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                        Text=":" Width="100%"></asp:Label></td>
                <td align="left" style="border-right: black 2px solid; width: 48%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:TextBox ID="TxtAwalSKL" runat="server" Enabled="False" Visible="False" Width="98%"></asp:TextBox>
                    <asp:Button ID="btnawallbr" runat="server" Text="Awal Lembur" />
                    <asp:Calendar ID="calawallbr" runat="server" BackColor="White" BorderColor="#3366CC"
                        BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
                        Font-Size="8pt" ForeColor="#003399" Height="164px" Visible="False" Width="194px">
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
                            Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                    </asp:Calendar>
                    <asp:TextBox ID="txttglawal" runat="server" ReadOnly="True" Visible="False" Width="136px"></asp:TextBox>
                    <asp:Label ID="lblawallbr" runat="server" Text="Jam " Visible="False"></asp:Label><asp:DropDownList
                        ID="ddlawal1" runat="server" Visible="False" AutoPostBack="True">
                        <asp:ListItem>-</asp:ListItem>
						<asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
						<asp:ListItem>22</asp:ListItem>
					    <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                    </asp:DropDownList><asp:Label ID="Label1" runat="server" Text=":" Visible="False"></asp:Label><asp:DropDownList
                        ID="ddlawal2" runat="server" AutoPostBack="True" Visible="False">
                        <asp:ListItem>-</asp:ListItem>
                        <asp:ListItem>00</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="border-left: black 2px solid; width: 25%; border-bottom: maroon 1px solid;
                    height: 19px; background-color: floralwhite">
                    <asp:Label ID="lblakhirSKL" runat="server" Text="Akhir SKL" Visible="False" Width="100%"></asp:Label></td>
                <td align="center" style="width: 5%; border-bottom: maroon 1px solid; font-family: FloralWhite;
                    height: 19px; background-color: floralwhite">
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                        Text=":" Visible="False" Width="100%"></asp:Label></td>
                <td align="left" style="border-right: black 2px solid; width: 48%; border-bottom: maroon 1px solid;
                    font-family: FloralWhite; height: 19px; background-color: floralwhite">
                    <asp:TextBox ID="TxtAkhirSKL" runat="server" Enabled="False" Visible="False" Width="98%"></asp:TextBox>
                    <asp:Button ID="btnakhirlbr" runat="server" Text="Akhir Lembur" Visible="False" />
                    <asp:Calendar ID="calakhirlbr" runat="server" BackColor="White" BorderColor="#3366CC"
                        BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
                        Font-Size="8pt" ForeColor="#003399" Height="164px" Visible="False" Width="194px">
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
                            Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                    </asp:Calendar>
                    <asp:TextBox ID="txttglakhir" runat="server" Enabled="False" ReadOnly="True" Visible="False"
                        Width="128px"></asp:TextBox>
                    <asp:Label ID="lblakhirlbr" runat="server" Text="Jam" Visible="False"></asp:Label><asp:DropDownList
                        ID="ddlakhir1" runat="server" AutoPostBack="True" Visible="False">
                        <asp:ListItem>-</asp:ListItem>
                        <asp:ListItem>00</asp:ListItem>
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                    </asp:DropDownList><asp:Label ID="Label2" runat="server" Text=":" Visible="False"></asp:Label><asp:DropDownList
                        ID="ddlakhir2" runat="server" AutoPostBack="True" Enabled="False" Visible="False">
                        <asp:ListItem>-</asp:ListItem>
                        <asp:ListItem>00</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="3" style="border-right: black 2px solid; border-top: black 1px double;
                    border-left: black 2px solid">
                    <asp:Label ID="LblKaryawan" runat="server" Style="border-top-width: 1px; font-weight: bold;
                        border-left-width: 2px; border-left-color: black; text-transform: uppercase;
                        color: maroon; border-top-color: black; font-family: 'Baskerville Old Face', Fantasy;
                        background-color: silver; border-right-width: 2px; text-decoration: underline;
                        border-right-color: black" Text="KARYAWAN" Width="100%"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3" style="border-right: black 2px solid; border-top: silver 1px dotted;
                    border-left: black 2px solid; background-color: floralwhite">
                    &nbsp; &nbsp;&nbsp;
                    <asp:TextBox ID="txtnrp" runat="server" AutoPostBack="True" Visible="False"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="..add" Visible="False" />
                    <asp:Button ID="btnadd1" runat="server" Text="....Select Karyawan..." Visible="False" />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Data_abs1ConnectionString %>"
                        DeleteCommand="DELETE FROM [Karyawan] WHERE [Nrp] = @Nrp" InsertCommand="INSERT INTO [Karyawan] ([Nrp], [NAMA], [Dept]) VALUES (@Nrp, @NAMA, @Dept)"
                        SelectCommand="SELECT Nrp, NAMA, Harike7, Dept FROM Karyawan WHERE (Dept = @Dept) AND (LEFT (Golongan, 1) <> '4') AND (LEFT (Golongan, 1) <> '5') AND (Onsite = '1') OR (Dept = @Dept) AND (Onsite = '1') AND (Golongan IS NULL)"
                        UpdateCommand="UPDATE [Karyawan] SET [NAMA] = @NAMA, [Dept] = @Dept WHERE [Nrp] = @Nrp">
                        <DeleteParameters>
                            <asp:Parameter Name="Nrp" Type="String" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="NAMA" Type="String" />
                            <asp:Parameter Name="Dept" Type="String" />
                            <asp:Parameter Name="Nrp" Type="String" />
                        </UpdateParameters>
                        <SelectParameters>
                            <asp:SessionParameter Name="Dept" SessionField="dept" Type="String" />
                        </SelectParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Nrp" Type="String" />
                            <asp:Parameter Name="NAMA" Type="String" />
                            <asp:Parameter Name="Dept" Type="String" />
                        </InsertParameters>
                    </asp:SqlDataSource>
                    <asp:GridView ID="Gridkaryawan1" runat="server" AllowPaging="True" AllowSorting="True"
                        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
                        Visible="False">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                        <RowStyle BackColor="#EFF3FB" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="3" rowspan="2" style="border-right: black 2px solid; border-top: maroon 1px solid;
                    border-left: black 2px solid; border-bottom: maroon 1px solid; background-color: floralwhite"
                    valign="middle">
                    <table border="0" cellpadding="0" cellspacing="0" style="height: 100%" width="100%">
                        <tr>
                            <td style="border-right: maroon 1px solid; width: 30%; border-bottom: maroon 1px solid">
                                <asp:Label ID="LblNrp" runat="server" Text="NRP :" Width="100%" Visible="False"></asp:Label></td>
                            <td style="width: 30%; border-bottom: maroon 1px solid">
                                <asp:Label ID="lblnama" runat="server" Text="Nama :" Width="75%" Visible="False"></asp:Label>
                                <asp:Label ID="Labelhari7" runat="server" Text="Hari ke 7 :" Visible="False" Width="23%"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 30%; height: 96px">
                                <asp:ListBox ID="listnrp" runat="server" AutoPostBack="True" Height="110px" Width="100%" Visible="False">
                                </asp:ListBox></td>
                            <td style="width: 70%; height: 96px">
                                <asp:ListBox ID="listnama" runat="server" Height="110px" Width="75%" Visible="False">
                                </asp:ListBox>
                                <asp:ListBox ID="listharike7" runat="server" Height="110px" Width="23%" Visible="False">
                                </asp:ListBox></td>
                        </tr>
                    </table>
                    &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="btnremove" runat="server" Text="Remove" Visible="False" />
                    <asp:Button ID="Button2" runat="server" Text="Add" Visible="False" /></td>
            </tr>
            <tr>
            </tr>
            <tr>
                <td style="border-left: black 2px solid; border-bottom: maroon 1px solid;
                    background-color: silver; border-right-width: 2px; border-right-color: black; font-family: 'Baskerville Old Face', Fantasy; height: 5px;" colspan="3">
                    </td>
            </tr>
            <tr>
                <td style="border-left: black 2px solid; width: 25%; border-bottom: maroon 1px solid;
                    height: 100px; background-color: floralwhite">
                    <asp:Label ID="lblUraianKerja" runat="server" Text="Uraian Pekerjaan" Visible="False"
                        Width="100%"></asp:Label></td>
                <td align="center" style="width: 5%; border-bottom: maroon 1px solid; height: 100px;
                    background-color: floralwhite">
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                        Text=":" Visible="False" Width="100%"></asp:Label></td>
                <td style="border-right: black 2px solid; width: 48%; border-bottom: maroon 1px solid;
                    height: 100px; background-color: floralwhite">
                    <asp:TextBox ID="txturaian" runat="server" AutoPostBack="True" Height="100px" Visible="False"
                        Width="98%"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" colspan="3" style="border-left-width: 2px; border-left-color: black;
                    border-bottom-width: 2px; border-bottom-color: black; border-right-width: 2px;
                    border-right-color: black">
                    &nbsp;<asp:Button ID="btnsend" runat="server" Enabled="False" Text="Send To Dept Head"
                        Visible="False" />
                    <asp:Label ID="Label10" runat="server" ForeColor="Red" Text="* Uraian Pekerjaan Wajib Diisi"
                        Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 25%">
                </td>
                <td style="width: 5%">
                </td>
                <td style="width: 48%">
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                </td>
                <td style="width: 5%">
                </td>
                <td style="width: 48%">
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                </td>
                <td style="width: 5%">
                </td>
                <td style="width: 48%">
                </td>
            </tr>
            <tr>
                <td style="width: 25%; height: 19px">
                </td>
                <td style="width: 5%; height: 19px">
                </td>
                <td style="width: 48%; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                </td>
                <td style="width: 5%">
                </td>
                <td style="width: 48%">
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                </td>
                <td style="width: 5%">
                </td>
                <td style="width: 48%">
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                </td>
                <td style="width: 5%">
                </td>
                <td style="width: 48%">
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                </td>
                <td style="width: 5%">
                </td>
                <td style="width: 48%">
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                </td>
                <td style="width: 5%">
                </td>
                <td style="width: 48%">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
