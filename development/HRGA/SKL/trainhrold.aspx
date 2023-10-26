<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="trainhr.aspx.vb" Inherits="trainhr" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
</script>

    <table id="TABLE1" border="0" cellpadding="0" cellspacing="0" style="background-color: azure"
        width="100%" onclick="return TABLE1_onclick()">
        <tr>
            <td style="width: 10%; height: 19px">
            </td>
            <td style="width: 70%; height: 19px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; position: static">
                    <tr>
                        <td align="center" colspan="3" style="border-right: black 2px solid; border-top: black 2px solid;
                            font-weight: normal; text-transform: uppercase; border-left: black 2px solid;
                            color: blue; font-family: 'Berlin Sans FB'; height: 19px; background-color: lemonchiffon;
                            text-decoration: underline">
                            SURAT PERMOHONAN TRAINING SITE</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3" style="border-right: black 2px solid; border-left: black 2px solid;
                            border-bottom: black 1px double">
                            <asp:Label ID="LblNoSKL" runat="server" Enabled="False" Style="border-left-width: 2px;
                                border-left-color: black; border-bottom-width: 1px; border-bottom-color: black;
                                background-color: lemonchiffon; border-right-width: 2px; border-right-color: black"
                                Text="No TRN : Auto Number........." Width="100%"></asp:Label></td>
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
                        <td style="border-right: black 2px solid; width: 70%; border-bottom: maroon 1px solid;
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
                        <td style="border-right: black 2px solid; width: 70%; border-bottom: maroon 1px solid;
                            background-color: floralwhite">
                            <asp:Label ID="LblNamarequestor" runat="server" Width="100%"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="border-left: black 2px solid; width: 5%; border-bottom: maroon 1px solid;
                            background-color: floralwhite">
                            <asp:Label ID="LblTglCreated" runat="server" Text="Tanggal " Width="100%"></asp:Label></td>
                        <td align="center" style="width: 5%; border-bottom: maroon 1px solid; background-color: floralwhite">
                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                Text=":" Width="100%"></asp:Label></td>
                        <td style="border-right: black 2px solid; width: 70%; border-bottom: maroon 1px solid;
                            background-color: floralwhite">
                            <asp:Label ID="LblTanggalCreated" runat="server" Width="100%"></asp:Label></td>
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
                            <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource2" ForeColor="#333333"
                                GridLines="None">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:CommandField EditText="validate" ShowEditButton="True" UpdateText="OK" Visible="False" />
                                    <asp:BoundField DataField="notrs" HeaderText="NOTRS" ReadOnly="True" SortExpression="notrs" />
                                    <asp:BoundField DataField="nrp" HeaderText="nrp" ReadOnly="True" SortExpression="nrp" />
                                    <asp:BoundField DataField="nama" HeaderText="nama" ReadOnly="True" SortExpression="nama" />
                                    <asp:BoundField DataField="dept" HeaderText="Dept" ReadOnly="True" SortExpression="dept" />
                                    <asp:BoundField DataField="awaltrain" HeaderText="Awal Training" SortExpression="awaltrain" />
                                    <asp:BoundField DataField="akhirtrain" HeaderText="Akhir Training" ReadOnly="True"
                                        SortExpression="akhirtrain" />
                                    <asp:CheckBoxField DataField="validateHR" HeaderText="Validate" SortExpression="validateHR" />
                                </Columns>
                                <RowStyle BackColor="#EFF3FB" />
                                <EditRowStyle BackColor="#C0FFC0" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Data_abs1ConnectionString %>"
                                DeleteCommand="DELETE FROM [Tbl_subSKL] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Tbl_subSKL] ([NoSKL], [Nrp], [AwalLembur], [akhirLembur], [Aprove], [Total]) VALUES (@NoSKL, @Nrp, @AwalLembur, @akhirLembur, @Aprove, @Total)"
                                SelectCommand="SELECT tbl_subtrain.id, tbl_subtrain.NOTRS, tbl_subtrain.nrp, Karyawan.NAMA, Karyawan.Dept, tbl_subtrain.awaltrain, tbl_subtrain.akhirtrain, tbl_subtrain.ValidateHR FROM tbl_subtrain INNER JOIN Karyawan ON tbl_subtrain.nrp = Karyawan.Nrp WHERE (tbl_subtrain.NOTRS = @Notrs)"
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
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="Notrs" QueryStringField="n" Type="String" />
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
                    </tr>
                    <tr>
                        <td style="border-left: black 2px solid; width: 5%; border-bottom: maroon 1px solid;
                            background-color: floralwhite">
                            <asp:Label ID="lbluraian" runat="server" Style="border-top: maroon 1px solid" Text="Lokasi Training"
                                Width="100%"></asp:Label></td>
                        <td align="center" style="width: 5%; border-bottom: maroon 1px solid; background-color: floralwhite">
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                Style="border-top: maroon 1px solid" Text=":" Width="100%"></asp:Label></td>
                        <td style="border-right: black 2px solid; width: 70%; border-bottom: maroon 1px solid;
                            background-color: floralwhite">
                            <asp:Label ID="lbllokasi1" runat="server" Style="border-top: maroon 1px solid" Width="100%"></asp:Label></td>
                        <td style="width: 20%; height: 19px">
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left: black 2px solid; width: 5%; border-bottom: maroon 1px solid;
                            background-color: floralwhite">
                            <asp:Label ID="Label2" runat="server" Style="border-top: maroon 1px solid" Text="Training"
                                Width="100%"></asp:Label></td>
                        <td align="center" style="width: 5%; border-bottom: maroon 1px solid; background-color: floralwhite">
                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                Style="border-top: maroon 1px solid" Text=":" Width="100%"></asp:Label></td>
                        <td style="border-right: black 2px solid; width: 70%; border-bottom: maroon 1px solid;
                            background-color: floralwhite">
                            <asp:Label ID="lbltraining1" runat="server" Style="border-top: maroon 1px solid" Width="100%"></asp:Label></td>
                        <td style="width: 20%; height: 19px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="border-right: black 2px solid; border-top: black 2px solid;
                            font-weight: bold; text-transform: uppercase; border-left: black 2px solid; color: maroon;
                            border-bottom: silver 1px dashed; font-family: 'Baskerville Old Face', Fantasy;
                            height: 19px; background-color: silver; text-decoration: underline">
                            HRGA :</td>
                    </tr>
                    <tr>
                        <td id="RR" align="center" colspan="3" style="border-right: black 2px solid; border-left: black 2px solid;
                            width: 5%; color: floralwhite; border-bottom: maroon 1px solid; height: 19px;
                            background-color: floralwhite">
                            <asp:Label ID="Label9" runat="server" Style="color: black" Visible="False"></asp:Label>111</td>
                    </tr>
                    <tr>
                        <td style="border-top-width: 1px; border-bottom-width: 1px; border-bottom-color: maroon;
                            border-left: black 2px solid; width: 5%; color: floralwhite; border-top-color: maroon;
                            background-color: floralwhite; border-right-width: 1px; border-right-color: maroon">
                            <asp:Label ID="lblnama" runat="server" Style="color: black" Text="Nama" Visible="False"></asp:Label>nama</td>
                        <td align="center" style="border-top-width: 1px; border-bottom-width: 1px; border-bottom-color: maroon;
                            width: 5%; color: floralwhite; border-top-color: maroon; background-color: floralwhite;
                            border-right-width: 1px; border-right-color: maroon">
                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                Text=":" Visible="False" Width="50%"></asp:Label></td>
                        <td style="border-top-width: 1px; border-right: black 2px solid; border-left-width: 1px;
                            border-left-color: maroon; border-bottom-width: 1px; border-bottom-color: maroon;
                            width: 55%; color: floralwhite; border-top-color: maroon; height: 21px; background-color: floralwhite">
                            <asp:Label ID="lblnama1" runat="server" Style="color: black" Visible="False"></asp:Label>kk</td>
                    </tr>
                    <tr>
                        <td style="border-top: maroon 1px solid; border-left: black 2px solid; width: 20%;
                            border-bottom: maroon 1px solid; height: 21px; background-color: floralwhite;
                            border-right-width: 1px; border-right-color: maroon">
                            <asp:Label ID="lblnrp" runat="server" Text="Nrp" Visible="False"></asp:Label></td>
                        <td align="center" style="border-top: maroon 1px solid; width: 5%; border-bottom: maroon 1px solid;
                            height: 21px; background-color: floralwhite; border-right-width: 1px; border-right-color: maroon">
                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                Style="border-top-width: 1px; border-top-color: maroon" Text=":" Visible="False"
                                Width="50%"></asp:Label></td>
                        <td style="border-right: black 2px solid; border-top: maroon 1px solid; width: 55%;
                            border-bottom: maroon 1px solid; height: 21px; background-color: floralwhite">
                            <asp:Label ID="lblnrp1" runat="server" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="border-top-width: 1px; border-left: black 2px solid; width: 20%; border-top-color: maroon;
                            border-bottom: maroon 1px solid; background-color: floralwhite; border-right-width: 1px;
                            border-right-color: maroon">
                            <asp:Label ID="lbltgl" runat="server" Text="Tanggal Validasi" Visible="False"></asp:Label></td>
                        <td align="center" style="border-top-width: 1px; width: 5%; border-top-color: maroon;
                            border-bottom: maroon 1px solid; background-color: floralwhite; border-right-width: 1px;
                            border-right-color: maroon">
                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                Text=":" Visible="False" Width="50%"></asp:Label></td>
                        <td style="border-right: black 2px solid; width: 55%; border-bottom: maroon 1px solid;
                            background-color: floralwhite">
                            <asp:Label ID="lbltgl1" runat="server" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="border-left: black 2px solid; width: 20%; border-bottom: black 2px solid;
                            height: 19px; background-color: floralwhite; border-right-width: 1px; border-right-color: maroon">
                            <asp:Label ID="lblCatatan" runat="server" Text="Catatan HR" Visible="False" Width="98%"></asp:Label></td>
                        <td align="center" style="width: 5%; border-bottom: black 2px solid; background-color: floralwhite;
                            border-right-width: 1px; border-right-color: maroon">
                            <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                Text=":" Visible="False" Width="50%"></asp:Label></td>
                        <td style="border-right: black 2px solid; width: 55%; border-bottom: black 2px solid;
                            height: 21px; background-color: floralwhite">
                            <asp:TextBox ID="txtcatatan" runat="server" AutoPostBack="True" Height="90px" Visible="False"
                                Width="98%"></asp:TextBox>
                            <asp:Label ID="LBLCAT1" runat="server" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3" style="border-top-width: 2px; border-right: black 2px solid;
                            border-left: black 2px solid; width: 5%; border-top-color: black; border-bottom: black 2px solid;
                            height: 31px; background-color: floralwhite">
                            <asp:Label ID="Label14" runat="server" ForeColor="Red" Style="color: black" Visible="False"></asp:Label>
                            <asp:Button ID="btnvalidate" runat="server" Enabled="False" Text="Validate" Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%">
                        </td>
                        <td style="width: 5%">
                        </td>
                        <td style="width: 70%">
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 11%; height: 19px">
            </td>
        </tr>
    </table>
</asp:Content>

