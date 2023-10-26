<%@ Page Language="VB" AutoEventWireup="false" CodeFile="aprove.aspx.vb" Inherits="aprove" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3" style="border-right: black 2px solid; border-top: black 2px solid;
                    font-weight: normal; text-transform: uppercase; border-left: black 2px solid;
                    color: blue; font-family: 'Berlin Sans FB'; height: 19px; background-color: lemonchiffon;
                    text-decoration: underline">
                    SURAT KESEPAKATAN LEMBUR HARIAN</td>
                <td style="width: 20%; height: 19px">
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3" style="border-right: black 2px solid; border-left: black 2px solid;
                    border-bottom: black 1px double; height: 20px">
                    <asp:Label ID="LblNoSKL" runat="server" Style="border-left-width: 2px; border-left-color: black;
                        border-bottom-width: 1px; border-bottom-color: black; text-transform: uppercase;
                        font-family: 'Berlin Sans FB Demi'; background-color: lemonchiffon; border-right-width: 2px;
                        text-decoration: underline; border-right-color: black" Width="100%"></asp:Label></td>
                <td style="width: 20%; height: 20px">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="border-right: black 2px solid; border-left: black 2px solid;
                    border-bottom: silver 1px dotted">
                    <asp:Label ID="Lblrequestor" runat="server" Style="font-weight: bolder; font-size: medium;
                        text-transform: uppercase; color: maroon; font-family: 'Baskerville Old Face', Fantasy;
                        background-color: silver; text-decoration: underline" Text="REQUESTOR" Width="100%"></asp:Label></td>
                <td style="width: 20%; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="border-left: black 2px solid; width: 5%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:Label ID="LblNRPR" runat="server" Text="NRP" Width="100%"></asp:Label></td>
                <td align="center" style="width: 5%; border-bottom: maroon 1px solid; background-color: floralwhite">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                        Text=":" Width="100%"></asp:Label></td>
                <td style="border-right: black 2px solid; width: 70%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:Label ID="lblrequest" runat="server" Width="100%"></asp:Label></td>
                <td style="width: 20%; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="border-left: black 2px solid; width: 5%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:Label ID="LblNamaR" runat="server" Style="border-left-width: 2px; border-left-color: black"
                        Text="Nama " Width="100%"></asp:Label></td>
                <td align="center" style="width: 5%; border-bottom: maroon 1px solid; background-color: floralwhite">
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                        Text=":" Width="100%"></asp:Label></td>
                <td style="border-right: black 2px solid; width: 70%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:Label ID="LblNamarequestor" runat="server" Width="100%"></asp:Label></td>
                <td style="width: 20%; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="border-left: black 2px solid; width: 5%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:Label ID="LblTglCreated" runat="server" Text="Tanggal " Width="100%"></asp:Label></td>
                <td align="center" style="width: 5%; border-bottom: maroon 1px solid; background-color: floralwhite">
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                        Text=":" Width="100%"></asp:Label></td>
                <td style="border-right: black 2px solid; width: 70%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:Label ID="LblTanggalCreated" runat="server" Width="100%"></asp:Label></td>
                <td style="width: 20%; height: 19px">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="border-right: black 2px solid; border-top: black 1px double;
                    border-left: black 2px solid">
                    <asp:Label ID="LblKaryawan" runat="server" Style="border-top-width: 1px; font-weight: bold;
                        border-left-width: 2px; border-left-color: black; text-transform: uppercase;
                        color: maroon; border-top-color: black; font-family: 'Baskerville Old Face', Fantasy;
                        background-color: silver; border-right-width: 2px; text-decoration: underline;
                        border-right-color: black" Text="KARYAWAN" Width="100%"></asp:Label></td>
                <td style="width: 20%; height: 19px">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="border-right: black 2px solid; border-top: black 2px solid;
                    border-left: black 2px solid; color: maroon; border-bottom: silver 1px dashed;
                    height: 19px">
                    <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource2" ForeColor="#333333"
                        GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                                SortExpression="ID" Visible="False" />
                            <asp:BoundField DataField="Nrp" HeaderText="Nrp" ReadOnly="True" SortExpression="Nrp" />
                            <asp:BoundField DataField="Nama" HeaderText="Nama" ReadOnly="True" SortExpression="Nama" />
                            <asp:BoundField DataField="AwalLembur" HeaderText="AwalLembur" SortExpression="AwalLembur" />
                            <asp:BoundField DataField="akhirLembur" HeaderText="akhirLembur" SortExpression="akhirLembur" />
                            <asp:CheckBoxField DataField="Aprove" HeaderText="Aprove" SortExpression="Aprove" />
                            <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True" SortExpression="Total" />
                            <asp:CommandField ShowEditButton="True" UpdateText="OK" Visible="False" />
                        </Columns>
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#EFF3FB" />
                        <EditRowStyle BackColor="#C0FFC0" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Data_abs1ConnectionString %>"
                        DeleteCommand="DELETE FROM [Tbl_subSKL] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Tbl_subSKL] ([NoSKL], [Nrp], [AwalLembur], [akhirLembur], [Aprove], [Total]) VALUES (@NoSKL, @Nrp, @AwalLembur, @akhirLembur, @Aprove, @Total)"
                        SelectCommand="SELECT Tbl_subSKL.ID, Tbl_subSKL.NoSKL, Tbl_subSKL.Nrp, Tbl_subSKL.AwalLembur, Tbl_subSKL.akhirLembur, Tbl_subSKL.Aprove, Tbl_subSKL.Total, Karyawan.NAMA FROM Tbl_subSKL INNER JOIN Karyawan ON Tbl_subSKL.Nrp = Karyawan.Nrp WHERE (Tbl_subSKL.NoSKL = @NoSKL)"
                        UpdateCommand="UPDATE [Tbl_subSKL] SET  [AwalLembur] = @AwalLembur, [akhirLembur] = @akhirLembur, [Aprove] = @Aprove  WHERE [ID] = @ID">
                        <DeleteParameters>
                            <asp:Parameter Name="ID" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="NoSKL" Type="String" />
                            <asp:Parameter Name="Nrp" Type="String" />
                            <asp:Parameter Name="AwalLembur" Type="DateTime" />
                            <asp:Parameter Name="akhirLembur" Type="DateTime" />
                            <asp:Parameter Name="Aprove" Type="Boolean" />
                            <asp:Parameter Name="Total" Type="String" />
                            <asp:Parameter Name="ID" Type="Int32" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="NoSKL" Type="String" />
                            <asp:Parameter Name="Nrp" Type="String" />
                            <asp:Parameter Name="AwalLembur" Type="DateTime" />
                            <asp:Parameter Name="akhirLembur" Type="DateTime" />
                            <asp:Parameter Name="Aprove" Type="Boolean" />
                            <asp:Parameter Name="Total" Type="String" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:QueryStringParameter Name="NoSKL" QueryStringField="n" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td style="width: 20%; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="border-left: black 2px solid; width: 5%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:Label ID="lbluraian" runat="server" Style="border-top: maroon 1px solid" Text="Uraian Pekerjaan "
                        Width="100%"></asp:Label></td>
                <td align="center" style="width: 5%; border-bottom: maroon 1px solid; background-color: floralwhite">
                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                        Style="border-top: maroon 1px solid" Text=":" Width="100%"></asp:Label></td>
                <td style="border-right: black 2px solid; width: 70%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:Label ID="lbluraian1" runat="server" Style="border-top: maroon 1px solid" Width="100%"></asp:Label></td>
                <td style="width: 20%; height: 19px">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="border-right: black 2px solid; border-top: black 2px solid;
                    font-weight: bold; text-transform: uppercase; border-left: black 2px solid; color: maroon;
                    border-bottom: silver 1px dashed; font-family: 'Baskerville Old Face', Fantasy;
                    height: 19px; background-color: silver; text-decoration: underline">
                    ATASAN :</td>
                <td style="width: 20%; height: 19px">
                </td>
            </tr>
            <tr>
                <td id="RR" align="center" colspan="3" style="border-right: black 2px solid; border-left: black 2px solid;
                    width: 5%; color: floralwhite; border-bottom: maroon 1px solid; height: 19px;
                    background-color: floralwhite">
                    <asp:Label ID="Label5" runat="server" Style="color: black" Visible="False"></asp:Label>111</td>
                <td style="width: 20%; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="border-top-width: 1px; border-bottom-width: 1px; border-bottom-color: maroon;
                    border-left: black 2px solid; width: 5%; color: floralwhite; border-top-color: maroon;
                    background-color: floralwhite; border-right-width: 1px; border-right-color: maroon">
                    <asp:Label ID="lblnama" runat="server" Style="color: black" Text="Nama" Visible="False"></asp:Label>nama</td>
                <td align="center" style="border-top-width: 1px; border-bottom-width: 1px; border-bottom-color: maroon;
                    width: 5%; color: floralwhite; border-top-color: maroon; background-color: floralwhite;
                    border-right-width: 1px; border-right-color: maroon">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                        Text=":" Visible="False" Width="50%"></asp:Label></td>
                <td style="border-top-width: 1px; border-right: black 2px solid; border-left-width: 1px;
                    border-left-color: maroon; border-bottom-width: 1px; border-bottom-color: maroon;
                    width: 55%; color: floralwhite; border-top-color: maroon; height: 21px; background-color: floralwhite">
                    <asp:Label ID="lblnama1" runat="server" Style="color: black" Visible="False"></asp:Label>kk</td>
                <td style="width: 20%; height: 19px">
                </td>
            </tr>
            <tr>
                <td style="border-top: maroon 1px solid; border-left: black 2px solid; width: 20%;
                    border-bottom: maroon 1px solid; height: 13px; background-color: floralwhite;
                    border-right-width: 1px; border-right-color: maroon">
                    <asp:Label ID="lblnrp" runat="server" Text="Nrp" Visible="False"></asp:Label></td>
                <td align="center" style="border-top: maroon 1px solid; width: 5%; border-bottom: maroon 1px solid;
                    height: 13px; background-color: floralwhite; border-right-width: 1px; border-right-color: maroon">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                        Style="border-top-width: 1px; border-top-color: maroon" Text=":" Visible="False"
                        Width="50%"></asp:Label></td>
                <td style="border-right: black 2px solid; border-top: maroon 1px solid; width: 55%;
                    border-bottom: maroon 1px solid; height: 13px; background-color: floralwhite">
                    <asp:Label ID="lblnrp1" runat="server" Visible="False"></asp:Label></td>
                <td style="width: 20%; height: 13px">
                </td>
            </tr>
            <tr>
                <td style="border-top-width: 1px; border-left: black 2px solid; width: 20%; border-top-color: maroon;
                    border-bottom: maroon 1px solid; background-color: floralwhite; border-right-width: 1px;
                    border-right-color: maroon">
                    <asp:Label ID="lbltgl" runat="server" Text="Tanggal Persetujuan" Visible="False"></asp:Label></td>
                <td align="center" style="border-top-width: 1px; width: 5%; border-top-color: maroon;
                    border-bottom: maroon 1px solid; background-color: floralwhite; border-right-width: 1px;
                    border-right-color: maroon">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                        Text=":" Visible="False" Width="50%"></asp:Label></td>
                <td style="border-right: black 2px solid; width: 55%; border-bottom: maroon 1px solid;
                    background-color: floralwhite">
                    <asp:Label ID="lbltgl1" runat="server" Visible="False"></asp:Label></td>
                <td style="width: 20%">
                </td>
            </tr>
            <tr>
                <td style="border-left: black 2px solid; width: 20%; border-bottom: black 2px solid;
                    height: 19px; background-color: floralwhite; border-right-width: 1px; border-right-color: maroon">
                    <asp:Label ID="lblCatatan" runat="server" Text="Catatan" Width="98%"></asp:Label></td>
                <td align="center" style="width: 5%; border-bottom: black 2px solid; background-color: floralwhite;
                    border-right-width: 1px; border-right-color: maroon">
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                        Text=":" Width="50%"></asp:Label></td>
                <td style="border-right: black 2px solid; width: 55%; border-bottom: black 2px solid;
                    height: 21px; background-color: floralwhite">
                    <asp:TextBox ID="txtcatatan" runat="server" AutoPostBack="True" Height="90px"
                        Width="98%"></asp:TextBox>
                    <asp:Label ID="LBLCAT1" runat="server" Visible="False"></asp:Label></td>
                <td style="width: 20%; height: 19px">
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3" style="border-top-width: 2px; border-right: black 2px solid;
                    border-left: black 2px solid; width: 5%; border-top-color: black; border-bottom: black 2px solid;
                    height: 31px; background-color: floralwhite">
                    <asp:Label ID="lblcat" runat="server" Font-Underline="True" ForeColor="Red" Visible="False"></asp:Label>
                    <asp:Button ID="btnsend" runat="server" Enabled="False" Text="SEND TO HR" Visible="False" />
                    <asp:Button ID="btnreject" runat="server" Enabled="False" Text="REJECT" Visible="False" /></td>
                <td style="width: 20%; height: 31px">
                </td>
            </tr>
            <tr>
                <td style="width: 20%; height: 19px">
                </td>
                <td align="center" style="width: 5%">
                </td>
                <td style="border-bottom-width: 1px; border-bottom-color: maroon; width: 55%; height: 21px;
                    border-right-width: 2px; border-right-color: black">
                </td>
                <td style="width: 20%; height: 19px">
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3" style="height: 19px">
                </td>
                <td style="width: 20%; height: 19px">
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3" style="height: 19px">
                </td>
                <td style="width: 20%; height: 19px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
