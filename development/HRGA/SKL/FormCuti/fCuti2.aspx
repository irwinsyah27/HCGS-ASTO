<%@ Page Language="VB" Debug="TRUE"  AutoEventWireup="false" CodeFile="fCuti2.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Form Cuti</title>
    <script src="GridViewHelper.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="1" cellpadding="5" cellspacing="2" style="width: 100%; height: 100%" id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
            <tr>
                <td valign="top" align="center" style="width: 100%">
                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="FORM PERMOHONAN CUTI"></asp:Label><br />
                                            <asp:Label ID="lblNomor" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label></td>
            </tr>
            <tr>
                <td style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; width: 100%;" valign="top">
                    <table border="1" cellpadding="1" cellspacing="0" style="width: 100%">
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="1" style="width: 100%">
                                    <tr>
                                        <td style="width: 161px; height: 19px">
                                            <asp:Label ID="Label22" runat="server" Text="Nrp" Width="104px"></asp:Label></td>
                                        <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="Label23" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="width: 262px">
                                            <asp:Label ID="lblNrp" runat="server" Font-Size="10pt"></asp:Label><asp:TextBox ID="txtNrp" runat="server" Width="104px" AutoPostBack="True"></asp:TextBox>
                                            <A onclick="window.open('PopupNrp.aspx?FormName=' + document.forms[0].name + '&textbox=txtNrp','PopupClass','width=390,height=400,left=300,top=100')"
		            href="javascript:;"><IMG src="Images/GoLtrHS.png" border="0" id="IMG3" runat="server" align="absMiddle" height="16" width="16"></A>
                                            </td>
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
                                        <td align="right">
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
                                        <td style="width: 161px;">
                                            <asp:Label ID="Label3" runat="server" Text="Status Penerimaan" Width="120px"></asp:Label></td>
                                        <td align="center" style="width: 28px;">
                                            <asp:Label ID="Label8" runat="server" Text=" : "></asp:Label></td>
                                        <td align="left" style="width: 262px">
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
                            <td valign="top" style="height: 135px">
                                <table border="0" cellpadding="0" cellspacing="1" style="width: 100%">
                                    <tr>
                                        <td style="width: 100px">
                                            <asp:CheckBox ID="ckLapangan" runat="server" Text="Lapangan" AutoPostBack="True" Enabled="False" /></td>
                                        <td align="right" style="width: 212px">
                                            <asp:TextBox ID="txtLapangan" runat="server" Width="200px" Enabled="False" AutoPostBack="True">0</asp:TextBox>&nbsp;</td>
                                        <td align="left">
                                            <asp:Label ID="Label28" runat="server" Text="hari"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 20px">
                                            <asp:CheckBox ID="ckTahunan" runat="server" Text="Tahunan" AutoPostBack="True" Enabled="False" /></td>
                                        <td align="right" style="width: 212px;">
                                            <asp:TextBox ID="txtTahunan" runat="server" Width="200px" Enabled="False" AutoPostBack="True">0</asp:TextBox>&nbsp;</td>
                                        <td align="left" style="height: 20px">
                                            <asp:Label ID="Label29" runat="server" Text="hari"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 20px">
                                            <asp:CheckBox ID="ckBesar" runat="server" Text="Besar" AutoPostBack="True" Enabled="False" /></td>
                                        <td align="right" style="width: 212px; height: 20px">
                                            <asp:TextBox ID="txtBesar" runat="server" Width="200px" Enabled="False" AutoPostBack="True">0</asp:TextBox>&nbsp;</td>
                                        <td align="left" style="height: 20px">
                                            <asp:Label ID="Label30" runat="server" Text="hari"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 20px">
                                            <asp:CheckBox ID="ckPerjalanan" runat="server" Text="Perjalanan" AutoPostBack="True" Enabled="False" /></td>
                                        <td align="right" style="width: 212px; height: 20px">
                                            <asp:TextBox ID="txtPerjalanan" runat="server" Width="200px" AutoPostBack="True" Enabled="False">0</asp:TextBox>&nbsp;</td>
                                        <td align="left" style="height: 20px">
                                            <asp:Label ID="Label31" runat="server" Text="hari"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px; height: 19px">
                                            <asp:Label ID="Label37" runat="server" Text="Total"></asp:Label></td>
                                        <td align="right" style="width: 212px; height: 19px">
                                            <asp:TextBox ID="txtTotal" runat="server" Width="200px" ReadOnly="True" Enabled="False"></asp:TextBox>&nbsp;</td>
                                        <td align="left">
                                            <asp:Label ID="Label36" runat="server" Text="hari"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 19px" align="right">
                                            <asp:Label ID="Label20" runat="server" Text="Tujuan Cuti"></asp:Label></td>
                                        <td style="width: 212px; height: 19px" align="right">
                                            <asp:TextBox ID="txtTujuan" runat="server" Width="200px" Enabled="False"></asp:TextBox>&nbsp;</td>
                                        <td align="left" style="height: 19px">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top" style="height: 135px; width: 390px;">
                                <table border="0" cellpadding="0" cellspacing="1" style="width: 100%">
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label24" runat="server" Text="Periode Cuti Tahunan : " Width="152px"></asp:Label></td>
                                        <td style="width: 100%" align="right">
                                            &nbsp;<asp:Label ID="lblSisaCuti1" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td align="right" style="width: 100px">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="height: 19px">
                                            <asp:Label ID="Label25" runat="server" Text="Cuti Tahunan : " Width="152px"></asp:Label></td>
                                        <td style="width: 100%;" align="right">
                                            <asp:Label ID="lblSisaCuti2" runat="server" Font-Size="10pt"></asp:Label></td>
                                        <td align="right" style="width: 100px; height: 19px">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="height: 19px">
                                            <asp:Label ID="Label26" runat="server" Text="Total : " Width="152px"></asp:Label></td>
                                        <td style="width: 100%;" align="right">
                                            <asp:Label ID="lblTotal" runat="server" Font-Size="10pt"></asp:Label>
                                            <asp:Label ID="Label42" runat="server" Font-Size="10pt">hari</asp:Label></td>
                                        <td align="right" style="width: 100px; height: 19px">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="height: 19px">
                                            <asp:Label ID="Label27" runat="server" Text="Sisa Cuti Tahunan : " Width="152px"></asp:Label></td>
                                        <td style="width: 100%;" align="right">
                                            <asp:Label ID="lblSisaCuti" runat="server" Font-Size="10pt"></asp:Label>
                                            <asp:Label ID="lblHariCTahunan" runat="server" Font-Size="10pt">hari</asp:Label></td>
                                        <td align="right" style="width: 100px; height: 19px">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="height: 19px">
                                            <asp:Label ID="Label39" runat="server" Text="Sisa Cuti Besar : " Width="152px"></asp:Label></td>
                                        <td align="right" style="width: 100%">
                                            <asp:Label ID="lblSisaCutiBesar" runat="server" Font-Size="10pt"></asp:Label>
                                            <asp:Label ID="lblHariCBesar" runat="server" Font-Size="10pt">hari</asp:Label></td>
                                        <td align="right" style="width: 100px; height: 19px">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <caption align="left">
                                        CUTI DILAKSANAKAN :</caption>
                                    <tr>
                                        <td style="width: 30px; height: 24px;">
                                            <asp:Label ID="Label33" runat="server" Text="Awal" Width="104px"></asp:Label></td>
                                        <td style="width: 47%; height: 24px;">
                                            <asp:TextBox ID="txtAwal" runat="server" Width="136px" AutoPostBack="True" Enabled="False"></asp:TextBox>
                                            <A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=txtAwal','PopupClass','width=215,height=195,left=330,top=300')"
		                            href="javascript:;"><IMG src="Images/Calendar.png" border="0" id="IMG1" runat="server" align="absMiddle" height="20" width="20" visible="false"></A>
                                            </td>
                                        <td style="width: 100%; height: 24px;">
                                            &nbsp;<A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=txtAkhir','PopupClass','width=215,height=195,left=330,top=300')"
		                            href="javascript:;"></A>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px;">
                                            <asp:Label ID="Label34" runat="server" Text="Akhir" Width="104px"></asp:Label></td>
                                        <td colspan="2" style="height: 19px">
                                            <asp:TextBox ID="txtAkhir" runat="server" Width="136px" Enabled="False"></asp:TextBox>
                                            <IMG src="Images/Calendar.png" border="0" id="IMG2" runat="server" align="absMiddle" height="20" width="20" visible="false"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px">
                                            <asp:Label ID="Label35" runat="server" Text="Alamat Cuti" Width="104px"></asp:Label></td>
                                        <td colspan="2" style="height: 19px">
                                            <asp:TextBox ID="txtAlamatCuti" runat="server" Width="80%" Enabled="False"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; height: 19px">
                                            <asp:Label ID="Label38" runat="server" Text="Keterangan" Width="104px"></asp:Label></td>
                                        <td colspan="2" style="height: 19px">
                                            <asp:TextBox ID="txtKeterangan" runat="server" Width="80%" Enabled="False"></asp:TextBox></td>
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
                                        FLIGHT FARE :</caption>
                                    <tr>
                                        <td align="left" colspan="5" style="height: 19px" valign="top">
                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                                DataSourceID="SqlDataSource1" Width="100%" Visible="False">
                                                <Columns>
                                                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True"  ButtonType=Image DeleteImageUrl="~/Images/Delete.gif" EditImageUrl="~/Images/Edit.gif" CancelImageUrl="~/Images/Cancel.gif" UpdateImageUrl="~/Images/Update.gif"/>
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
                                <table border="1" bordercolor="#cccccc" cellpadding="2" cellspacing="0" style="width: 100%;
                                    height: 100%">
                                    <caption align="left">
                                        .</caption>
                                    <tr>
                                        <td style="width: 100px; height: 19px">
                                            PEMOHON :<br />
                                            <asp:Label ID="lblPemohon" runat="server" Font-Bold="True" Width="192px"></asp:Label><br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 19px">
                                            DEPT HEAD :<br />
                                            <asp:Label ID="lblDeptHead" runat="server" Font-Bold="True" Width="192px"></asp:Label><br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 5px">
                                            HR OFFICER :<br />
                                            <asp:Label ID="lblHrOfficer" runat="server" Font-Bold="True" Width="192px"></asp:Label><br />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                                </td>
                        </tr>
                    </table>
                    <br />
                                </td>
            </tr>
        </table>
    
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
		GridViewHelper.Init(document.all.GridView2, 100,0);
	</script>
</body>
</html>
