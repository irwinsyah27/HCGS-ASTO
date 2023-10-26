<%@ Page Language="VB" debug="true"AutoEventWireup="false" CodeFile="vwskl1.aspx.vb" Inherits="vwskl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <table width="100%">
            <tr>
                <td style="width: 100px">
                    <table style="width: 7.5in">
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td style="border-right: maroon 1px solid; border-top: maroon 1px solid; border-left: maroon 1px solid;
                                width: 96%; border-bottom: maroon 1px solid">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 30px;">
                                    <tr>
                                        <td colspan="4" style="height: 45px">
                                            &nbsp;
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 5%; height: 21px">
                                                        <asp:Image ID="Image1" runat="server" Height="56px" ImageUrl="~/HRGA/Images/Logo_KPP.JPG" Width="56px" /></td>
                                                    <td style="width: 70%; height: 21px" valign="top">
                                                        PT. KALIMANTAN PRIMA PERSADA</td>
                                                    <td align="right" style="width: 25%; height: 21px" valign="top">
                                                        <asp:Label ID="Label12" runat="server" Style="color: black; font-family: Latha; text-decoration: underline"
                                                            Text="Revisi 1.0"></asp:Label></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" style="border-right: black 2px solid; border-top: black 2px solid;
                                            font-weight: normal; text-transform: uppercase; border-left: black 2px solid;
                                            color: blue; font-family: 'Berlin Sans FB'; height: 22px; background-color: lemonchiffon;
                                            text-decoration: underline">
                                            SURAT KESEPAKATAN LEMBUR HARIAN</td>
                                        <td style="width: 20%; height: 22px">
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
                                            border-bottom: silver 1px dotted; height: 20px">
                                            <asp:Label ID="Lblrequestor" runat="server" Font-Size="Medium" Font-Underline="True"
                                                Style="font-weight: bold; text-transform: uppercase; color: maroon; font-family: 'Berlin Sans FB';
                                                background-color: silver; text-decoration: underline" Text="REQUESTOR" Width="100%"></asp:Label></td>
                                        <td style="width: 20%; height: 20px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border-left: black 2px solid; width: 20%; border-bottom: maroon 1px solid;
                                            height: 20px; background-color: floralwhite">
                                            <asp:Label ID="LblNRPR" runat="server" Text="NRP" Width="100%"></asp:Label></td>
                                        <td align="center" style="border-bottom: maroon 1px solid; height: 20px; background-color: floralwhite">
                                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                                Text=":" Width="100%"></asp:Label></td>
                                        <td style="border-right: black 2px solid; width: 70%; border-bottom: maroon 1px solid;
                                            height: 20px; background-color: floralwhite">
                                            <asp:Label ID="lblrequest" runat="server" Width="100%"></asp:Label></td>
                                        <td style="width: 20%; height: 20px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border-left: black 2px solid; width: 20%; border-bottom: maroon 1px solid;
                                            background-color: floralwhite">
                                            <asp:Label ID="LblNamaR" runat="server" Style="border-left-width: 2px; border-left-color: black"
                                                Text="Nama " Width="100%"></asp:Label></td>
                                        <td align="center" style="border-bottom: maroon 1px solid; background-color: floralwhite">
                                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                                Text=":" Width="100%"></asp:Label></td>
                                        <td style="border-right: black 2px solid; width: 70%; border-bottom: maroon 1px solid;
                                            background-color: floralwhite">
                                            <asp:Label ID="LblNamarequestor" runat="server" Width="100%"></asp:Label></td>
                                        <td style="width: 20%; height: 19px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border-left: black 2px solid; width: 20%; border-bottom: maroon 1px solid;
                                            height: 20px; background-color: floralwhite">
                                            <asp:Label ID="LblTglCreated" runat="server" Text="Tanggal " Width="100%"></asp:Label></td>
                                        <td align="center" style="border-bottom: maroon 1px solid; height: 20px; background-color: floralwhite">
                                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                                Text=":" Width="100%"></asp:Label></td>
                                        <td style="border-right: black 2px solid; width: 70%; border-bottom: maroon 1px solid;
                                            height: 20px; background-color: floralwhite">
                                            <asp:Label ID="LblTanggalCreated" runat="server" Width="100%"></asp:Label></td>
                                        <td style="width: 20%; height: 20px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="border-right: black 2px solid; border-top: black 1px double;
                                            border-left: black 2px solid">
                                            <asp:Label ID="LblKaryawan" runat="server" Style="border-top-width: 1px; font-weight: bold;
                                                border-left-width: 2px; border-left-color: black; text-transform: uppercase;
                                                color: maroon; border-top-color: black; font-family: 'Berlin Sans FB'; background-color: silver;
                                                border-right-width: 2px; text-decoration: underline; border-right-color: black"
                                                Text="KARYAWAN" Width="100%"></asp:Label></td>
                                        <td style="width: 20%; height: 19px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="border-right: black 2px solid; border-top: black 2px solid;
                                            border-left: black 2px solid; color: maroon; border-bottom: silver 1px dashed;
                                            height: 24px">
                                            &nbsp;<asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource2" ForeColor="#333333"
                                                GridLines="None">
                                                <Columns>
                                                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                                                        SortExpression="ID" Visible="False" />
                                                    <asp:BoundField DataField="Nrp" HeaderText="Nrp" ReadOnly="True" SortExpression="Nrp" />
                                                    <asp:BoundField DataField="Nama" HeaderText="Nama" ReadOnly="True" SortExpression="Nama" />
                                                    <asp:BoundField DataField="Harike7" HeaderText="Harike7" ReadOnly="True" SortExpression="Harike7" />
                                                    <asp:BoundField DataField="AwalLembur" HeaderText="AwalLembur" SortExpression="AwalLembur" />
                                                    <asp:BoundField DataField="akhirLembur" HeaderText="akhirLembur" SortExpression="akhirLembur" />
                                                    <asp:CheckBoxField DataField="Reject" HeaderText="Reject" SortExpression="Reject" />
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
                                                SelectCommand="SELECT Tbl_subSKL1.ID, Tbl_subSKL1.NoSKL, Tbl_subSKL1.Nrp, Tbl_subSKL1.AwalLembur, Tbl_subSKL1.akhirLembur, Tbl_subSKL1.Reject, Tbl_subSKL1.Total, Karyawan.NAMA, Karyawan.Harike7 FROM Tbl_subSKL1 INNER JOIN Karyawan ON Tbl_subSKL1.Nrp = Karyawan.Nrp WHERE (Tbl_subSKL1.NoSKL = @NoSKL)"
                                                UpdateCommand="UPDATE [Tbl_subSKL1] SET  [AwalLembur] = @AwalLembur, [akhirLembur] = @akhirLembur, [reject] = @reject  WHERE [ID] = @ID">
                                                <DeleteParameters>
                                                    <asp:Parameter Name="ID" Type="Int32" />
                                                </DeleteParameters>
                                                <UpdateParameters>
                                                    <asp:Parameter Name="NoSKL" Type="String" />
                                                    <asp:Parameter Name="Nrp" Type="String" />
                                                    <asp:Parameter Name="AwalLembur" Type="DateTime" />
                                                    <asp:Parameter Name="akhirLembur" Type="DateTime" />
                                                    <asp:Parameter Name="Total" Type="String" />
                                                    <asp:Parameter Name="ID" Type="Int32" />
                                                    <asp:Parameter Name="reject" />
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
                                        <td style="width: 20%; height: 24px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border-left: black 2px solid; width: 5%; border-bottom: maroon 1px solid;
                                            background-color: floralwhite; height: 40px;">
                                            <asp:Label ID="lbluraian" runat="server" Style="border-top: maroon 1px solid; height: 100%;" Text="Uraian Pekerjaan "
                                                Width="100%" Height="100%"></asp:Label></td>
                                        <td align="center" style="width: 5%; border-bottom: maroon 1px solid; background-color: floralwhite; height: 40px;">
                                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                                Style="border-top: maroon 1px solid; height: 100%;" Text=":" Width="100%" Height="100%"></asp:Label></td>
                                        <td style="border-right: black 2px solid; width: 70%; border-bottom: maroon 1px solid;
                                            background-color: floralwhite; height: 40px;">
                                            <asp:Label ID="lbluraian1" runat="server" Style="border-top: maroon 1px solid" Width="100%" Height="100%"></asp:Label></td>
                                        <td style="width: 20%; height: 30px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="border-top-width: 2px; font-weight: bold; border-left-width: 2px;
                                            border-left-color: black; border-bottom-width: 1px; border-bottom-color: silver;
                                            text-transform: uppercase; color: maroon; border-top-color: black; font-family: 'Baskerville Old Face', Fantasy;
                                            height: 22px; border-right-width: 2px; text-decoration: underline; border-right-color: black">
                                            <asp:Label ID="Label13" runat="server" Height="62%" Style="border-right: black 2px solid;
                                                border-top: black 2px solid; border-left: black 2px solid; color: maroon; border-bottom: silver 1px dashed;
                                                font-family: 'Berlin Sans FB'; background-color: silver" Width="99.4%">ATASAN</asp:Label></td>
                                        <td style="height: 22px; border-top-width: 2px; font-weight: bold; border-left-width: 2px; border-left-color: black; border-bottom-width: 1px; border-bottom-color: silver; text-transform: uppercase; color: maroon; border-top-color: black; font-family: 'Baskerville Old Face', Fantasy; border-right-width: 2px; text-decoration: underline; border-right-color: black;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="RR" align="center" colspan="3" style="border-right: black 2px solid; border-left: black 2px solid;
                                            width: 5%; color: black; border-bottom: maroon 1px solid; height: 19px">
                                            <asp:Label ID="Label5" runat="server" Height="100%" Style="color: black; background-color: floralwhite"
                                                Width="99.75%"></asp:Label></td>
                                        <td style="width: 20%; height: 19px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border-top-width: 1px; border-left-width: 2px; border-left-color: black;
                                            border-bottom-width: 1px; border-bottom-color: maroon; width: 20%; color: floralwhite;
                                            border-top-color: maroon; height: 19px; border-right-width: 1px; border-right-color: maroon">
                                            <asp:Label ID="lblnama" runat="server" Height="100%" Style="border-left: black 2px solid;
                                                color: black; background-color: floralwhite" Text="Nama" Width="99.5%"></asp:Label></td>
                                        <td align="center" style="border-top-width: 1px; border-bottom-width: 1px; border-bottom-color: maroon;
                                            color: floralwhite; border-top-color: maroon; height: 19px; border-right-width: 1px;
                                            border-right-color: maroon">
                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                                Style="background-color: floralwhite" Text=":" Width="99.5%"></asp:Label></td>
                                        <td style="border-top-width: 1px; border-left-width: 1px; border-left-color: maroon;
                                            border-bottom-width: 1px; border-bottom-color: maroon; width: 70%; color: floralwhite;
                                            border-top-color: maroon; height: 19px; border-right-width: 2px; border-right-color: black">
                                            <asp:Label ID="lblnama1" runat="server" Height="100%" Style="border-right: black 2px solid;
                                                color: black; background-color: floralwhite" Width="99.5%"></asp:Label></td>
                                        <td style="width: 20%; height: 19px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border-top: maroon 1px solid; border-left: black 2px solid; width: 20%;
                                            color: black; border-bottom: maroon 1px solid; height: 21px; border-right-width: 1px;
                                            border-right-color: maroon">
                                            <asp:Label ID="lblnrp" runat="server" Height="100%" Style="background-color: floralwhite"
                                                Text="Nrp" Width="99.5%"></asp:Label></td>
                                        <td align="center" style="border-top: maroon 1px solid; border-bottom: maroon 1px solid;
                                            height: 21px; border-right-width: 1px; border-right-color: maroon">
                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                                Style="border-top-width: 1px; border-top-color: maroon; background-color: floralwhite"
                                                Text=":" Width="99.5%"></asp:Label></td>
                                        <td style="border-top: maroon 1px solid; width: 70%; border-bottom: maroon 1px solid;
                                            height: 21px; border-right-width: 2px; border-right-color: black">
                                            <asp:Label ID="lblnrp1" runat="server" Height="100%" Style="border-right: black 2px solid;
                                                background-color: floralwhite" Width="99.5%"></asp:Label></td>
                                        <td style="width: 20%; height: 21px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border-top-width: 1px; border-left: black 2px solid; width: 20%; border-top-color: maroon;
                                            border-bottom: maroon 1px solid; height: 20px; border-right-width: 1px; border-right-color: maroon">
                                            <asp:Label ID="lbltgl" runat="server" Height="100%" Style="background-color: floralwhite"
                                                Text="Tanggal Persetujuan" Width="99.5%"></asp:Label></td>
                                        <td align="center" style="border-top-width: 1px; border-top-color: maroon; border-bottom: maroon 1px solid;
                                            height: 20px; border-right-width: 1px; border-right-color: maroon">
                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                                Style="background-color: floralwhite" Text=":" Width="99.5%"></asp:Label></td>
                                        <td style="width: 70%; border-bottom: maroon 1px solid; height: 20px; border-right-width: 2px;
                                            border-right-color: black">
                                            <asp:Label ID="lbltgl1" runat="server" Height="100%" Style="border-right: black 2px solid;
                                                background-color: floralwhite" Width="99.5%"></asp:Label></td>
                                        <td style="width: 20%; height: 20px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border-bottom-width: 2px; border-bottom-color: black; border-left: black 2px solid;
                                            width: 20%; border-right-width: 1px; border-right-color: maroon; height: 50px;">
                                            <asp:Label ID="lblCatatan" runat="server" Height="100%" Style="border-bottom: maroon 1px solid;
                                                background-color: floralwhite" Text="Catatan" Width="100%"></asp:Label></td>
                                        <td align="center" style="border-bottom-width: 2px; border-bottom-color: black;
                                            border-right-width: 1px; border-right-color: maroon; height: 50px;">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                                Style="border-bottom: maroon 1px solid; background-color: floralwhite" Text=":"
                                                Width="100%" Height="100%"></asp:Label></td>
                                        <td style="border-bottom-width: 2px; border-bottom-color: black; width: 70%;
                                            border-right-width: 2px; border-right-color: black; height: 50px;">
                                            <asp:Label ID="LBLCAT1" runat="server" Height="100%" Style="border-right: black 2px solid;
                                                border-bottom: maroon 1px solid; background-color: floralwhite" Width="99.5%"></asp:Label></td>
                                        <td style="width: 20%;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="border-top-width: 2px; font-weight: bold; border-left-width: 2px;
                                            border-left-color: black; border-bottom-width: 1px; border-bottom-color: silver;
                                            text-transform: uppercase; color: maroon; border-top-color: black; font-family: 'Baskerville Old Face', Fantasy;
                                            height: 22px; border-right-width: 2px; text-decoration: underline; border-right-color: black">
                                            <asp:Label ID="LBLHRGA" runat="server" Height="62%" Style="border-right: black 2px solid;
                                                border-top: black 2px solid; border-left: black 2px solid; color: maroon; border-bottom: silver 1px dashed;
                                                font-family: 'Berlin Sans FB'; background-color: silver" Width="99.4%">HRGA</asp:Label></td>
                                        <td style="height: 22px; border-top-width: 2px; font-weight: bold; border-left-width: 2px; border-left-color: black; border-bottom-width: 1px; border-bottom-color: silver; text-transform: uppercase; color: maroon; border-top-color: black; font-family: 'Baskerville Old Face', Fantasy; border-right-width: 2px; text-decoration: underline; border-right-color: black;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="3" style="width: 5%; color: floralwhite;
                                            height: 19px; border-right: black 2px solid; border-top: black 2px solid; border-left: black 2px solid; border-bottom: black 2px solid;" valign="top">
                                            &nbsp;
                                            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                                                CellSpacing="1" DataKeyNames="ID" DataSourceID="SqlDataSource1" GridLines="None"
                                                Style="border-right: black 2px solid; border-top: maroon 1px solid; border-left: black 2px solid;
                                                border-bottom: maroon 1px solid">
                                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                <Columns>
                                                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                                                        SortExpression="ID" Visible="False" />
                                                    <asp:BoundField DataField="Nrp" HeaderText="Nrp" ReadOnly="True" SortExpression="Nrp" />
                                                    <asp:BoundField DataField="Nama" HeaderText="Nama" ReadOnly="True" SortExpression="Nama" />
                                                    <asp:BoundField DataField="AwalLembur" HeaderText="Awal" ReadOnly="True" SortExpression="AwalLembur" />
                                                    <asp:BoundField DataField="akhirLembur" HeaderText="akhir" ReadOnly="True" SortExpression="akhirLembur" />
                                                    <asp:CheckBoxField DataField="Reject" HeaderText="Reject" ReadOnly="True" SortExpression="Reject" />
                                                    <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True" SortExpression="Total" />
                                                    <asp:BoundField DataField="in" HeaderText="Act. In" ReadOnly="True" SortExpression="in" />
                                                    <asp:BoundField DataField="Out" HeaderText="Act. Out" ReadOnly="True" SortExpression="Out" />
                                                    <asp:CheckBoxField DataField="RejectHR" HeaderText="RejectHR" SortExpression="RejectHR" />
                                                    <asp:BoundField DataField="TotalHR" HeaderText="total HR" ReadOnly="True" SortExpression="TotalHR" />
                                                    <asp:CommandField ShowEditButton="True" UpdateText="OK" Visible="False" />
                                                    <asp:CheckBoxField DataField="Aprove" HeaderText="Aprove" ReadOnly="True" SortExpression="Aprove"
                                                        Visible="False" />
                                                    <asp:CheckBoxField DataField="AproveHR" HeaderText="Aprove HR" SortExpression="AproveHR"
                                                        Visible="False" />
                                                </Columns>
                                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Data_abs1ConnectionString %>"
                                                DeleteCommand="DELETE FROM [Tbl_subSKL] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Tbl_subSKL] ([NoSKL], [Nrp], [AwalLembur], [akhirLembur], [Aprove], [Total]) VALUES (@NoSKL, @Nrp, @AwalLembur, @akhirLembur, @Aprove, @Total)"
                                                SelectCommand="SELECT Tbl_subSKL1.ID, Tbl_subSKL1.NoSKL, Tbl_subSKL1.Nrp, Tbl_subSKL1.AwalLembur, Tbl_subSKL1.akhirLembur, Tbl_subSKL1.reject, Tbl_subSKL1.Total, Karyawan.NAMA, CAST(DATEPART(hh, lembarkerja.[in]) AS Varchar) + ':' + CAST(DATEPART(mi, lembarkerja.[in]) AS Varchar) AS [in], CAST(DATEPART(hh, lembarkerja.out) AS Varchar) + ':' + CAST(DATEPART(mi, lembarkerja.out) AS Varchar) AS out, Tbl_subSKL1.HariKe7, Tbl_subSKL1.rejectHR, Tbl_subSKL1.totalHR FROM Tbl_subSKL1 INNER JOIN Karyawan ON Tbl_subSKL1.Nrp = Karyawan.Nrp INNER JOIN lembarkerja ON lembarkerja.nrp = Tbl_subSKL1.Nrp AND CAST(MONTH(Tbl_subSKL1.AwalLembur) AS Varchar) + '/' + CAST(DAY(Tbl_subSKL1.AwalLembur) AS Varchar) + '/' + CAST(YEAR(Tbl_subSKL1.AwalLembur) AS Varchar) = CAST(MONTH(lembarkerja.tanggal) AS Varchar) + '/' + CAST(DAY(lembarkerja.tanggal) AS Varchar) + '/' + CAST(YEAR(lembarkerja.tanggal) AS Varchar) WHERE (Tbl_subSKL1.NoSKL = @NoSKL) AND (Tbl_subSKL1.reject = '0')"
                                                UpdateCommand="UPDATE Tbl_subSKL1 SET rejectHR = @rejectHR WHERE (ID = @ID)">
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
                                                    <asp:Parameter Name="newparameter" />
                                                    <asp:Parameter Name="@AproveHR" />
                                                    <asp:Parameter Name="rejectHR" />
                                                </UpdateParameters>
                                                <SelectParameters>
                                                    <asp:QueryStringParameter Name="NoSKL" QueryStringField="n" Type="String" />
                                                </SelectParameters>
                                                <InsertParameters>
                                                    <asp:Parameter Name="NoSKL" Type="String" />
                                                    <asp:Parameter Name="Nrp" Type="String" />
                                                    <asp:Parameter Name="AwalLembur" Type="DateTime" />
                                                    <asp:Parameter Name="akhirLembur" Type="DateTime" />
                                                    <asp:Parameter Name="Aprove" Type="Boolean" />
                                                    <asp:Parameter Name="Total" Type="String" />
                                                </InsertParameters>
                                            </asp:SqlDataSource>
                                        </td>
                                        <td style="width: 20%; height: 19px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="Td1" align="center" colspan="3" style="border-left-width: 2px; border-left-color: black;
                                            border-bottom-width: 1px; border-bottom-color: maroon; width: 5%; color: floralwhite;
                                            height: 19px; border-right-width: 2px; border-right-color: black">
                                            <asp:Label ID="Label9" runat="server" Height="100%" Style="border-right: black 2px solid;
                                                border-top: black 2px solid; border-left: black 2px solid; color: black; border-bottom: maroon 1px solid;
                                                background-color: floralwhite" Width="99.4%"></asp:Label></td>
                                        <td style="width: 20%; height: 19px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border-top-width: 1px; border-left-width: 2px; border-left-color: black;
                                            border-bottom-width: 1px; border-bottom-color: maroon; width: 20%; color: floralwhite;
                                            border-top-color: maroon; height: 21px; border-right-width: 1px; border-right-color: maroon">
                                            <asp:Label ID="Lblnamahr" runat="server" Height="100%" Style="border-left: black 2px solid;
                                                color: black; border-bottom: maroon 1px solid; background-color: floralwhite"
                                                Text="Nama" Width="99.75%"></asp:Label></td>
                                        <td align="center" style="border-top-width: 1px; border-bottom-width: 1px; border-bottom-color: maroon;
                                            color: floralwhite; border-top-color: maroon; height: 21px; border-right-width: 1px;
                                            border-right-color: maroon">
                                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                                Height="100%" Style="border-bottom: maroon 1px solid; background-color: floralwhite"
                                                Text=":" Width="99.75%"></asp:Label></td>
                                        <td style="border-top-width: 1px; border-left-width: 1px; border-left-color: maroon;
                                            border-bottom-width: 1px; border-bottom-color: maroon; width: 70%; color: floralwhite;
                                            border-top-color: maroon; height: 21px; border-right-width: 2px; border-right-color: black">
                                            <asp:Label ID="lblnamahr1" runat="server" Height="100%" Style="border-right: black 2px solid;
                                                color: black; border-bottom: maroon 1px solid; background-color: floralwhite"
                                                Width="99.5%"></asp:Label></td>
                                        <td style="width: 20%; height: 21px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border-top-width: 1px; border-left-width: 2px; border-left-color: black;
                                            border-bottom-width: 1px; border-bottom-color: maroon; width: 20%; border-top-color: maroon;
                                            height: 21px; border-right-width: 1px; border-right-color: maroon">
                                            <asp:Label ID="Lblnrphr" runat="server" Height="100%" Style="border-left: black 2px solid;
                                                border-bottom: maroon 1px solid; background-color: floralwhite" Text="Nrp" Width="99.75%"></asp:Label></td>
                                        <td align="center" style="border-top-width: 1px; border-bottom-width: 1px; border-bottom-color: maroon;
                                            border-top-color: maroon; height: 21px; border-right-width: 1px; border-right-color: maroon">
                                            <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                                Height="100%" Style="border-top-width: 1px; border-top-color: maroon; border-bottom: maroon 1px solid;
                                                background-color: floralwhite" Text=":" Width="99.75%"></asp:Label></td>
                                        <td style="border-top-width: 1px; border-bottom-width: 1px; border-bottom-color: maroon;
                                            width: 70%; border-top-color: maroon; height: 21px; border-right-width: 2px;
                                            border-right-color: black">
                                            <asp:Label ID="lblnrphr1" runat="server" Height="100%" Style="border-right: black 2px solid;
                                                border-bottom: maroon 1px solid; background-color: floralwhite" Width="99.5%"></asp:Label></td>
                                        <td style="width: 20%; height: 21px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border-top-width: 1px; border-left-width: 2px; border-left-color: black;
                                            border-bottom-width: 1px; border-bottom-color: maroon; width: 20%; border-top-color: maroon;
                                            height: 21px; border-right-width: 1px; border-right-color: maroon">
                                            <asp:Label ID="lbltglhr" runat="server" Height="100%" Style="border-left: black 2px solid;
                                                border-bottom: maroon 1px solid; background-color: floralwhite" Text="Tanggal Validasi"
                                                Width="99.75%"></asp:Label></td>
                                        <td align="center" style="border-top-width: 1px; border-bottom-width: 1px; border-bottom-color: maroon;
                                            border-top-color: maroon; height: 21px; border-right-width: 1px; border-right-color: maroon">
                                            <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                                Height="100%" Style="border-bottom: maroon 1px solid; background-color: floralwhite"
                                                Text=":" Width="99.75%"></asp:Label></td>
                                        <td style="border-bottom-width: 1px; border-bottom-color: maroon; width: 70%; height: 21px;
                                            border-right-width: 2px; border-right-color: black">
                                            <asp:Label ID="lbltglhr1" runat="server" Height="100%" Style="border-right: black 2px solid;
                                                border-bottom: maroon 1px solid; background-color: floralwhite" Width="99.5%"></asp:Label></td>
                                        <td style="width: 20%; height: 21px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border-left-width: 2px; border-left-color: black; border-bottom-width: 2px;
                                            border-bottom-color: black; width: 20%; height: 31px; border-right-width: 1px;
                                            border-right-color: maroon">
                                            <asp:Label ID="lblcathr" runat="server" Height="100%" Style="border-left: black 2px solid;
                                                border-bottom: black 2px solid; background-color: floralwhite" Text="Catatan"
                                                Width="99.75%"></asp:Label></td>
                                        <td align="center" style="border-bottom-width: 2px; border-bottom-color: black; height: 31px;
                                            border-right-width: 1px; border-right-color: maroon">
                                            <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                                Height="100%" Style="border-bottom: black 2px solid; background-color: floralwhite"
                                                Text=":" Width="99.75%"></asp:Label></td>
                                        <td align="left" style="border-bottom-width: 2px; border-bottom-color: black; width: 70%;
                                            height: 31px; border-right-width: 2px; border-right-color: black">
                                            <asp:Label ID="lblcathr1" runat="server" Height="100%" Style="border-right: black 2px solid;
                                                border-bottom: black 2px solid; background-color: floralwhite" Width="99.5%"></asp:Label>
                                        </td>
                                        <td style="width: 20%; height: 31px">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 2%">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
