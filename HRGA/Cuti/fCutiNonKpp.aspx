<%@ Page Language="VB" Debug="TRUE"  AutoEventWireup="false" CodeFile="fCutiNonKpp.aspx.vb" Inherits="_fCutiNonKpp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>FORM PENGAJUAN MANIFEST</title>
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
    <div id="div1" style="margin: 0 auto; padding:0; background: #ffcc66; width: 900px; height: 500px;">
    <div>
        <table border="0" cellpadding="5" cellspacing="0" style="width: 100%; height: 100%; border-right: #0066cc 1px solid; border-top: #0066cc 1px solid; border-left: #0066cc 1px solid; border-bottom: #0066cc 1px solid;" id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
            <tr>
                <td valign="top" align="center" style="width: 98%">
                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="FORM PENGAJUAN MANIFEST NON KPP / VISITOR ASTO"></asp:Label><br />
                                            <asp:Label ID="lblNomor" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label></td>
            </tr>
            <tr>
                <td style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; width: 98%; height: 584px;" valign="top">
                    <table border="1" cellpadding="1" cellspacing="0" style="width: 100%">
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="1" style="width: 100%">
								
									<tr>
                                        <td style="width: 161px; height: 19px">
                                            <asp:Label ID="LabelNrp" runat="server" Text="NRP"></asp:Label></td>
									    <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="LabelNrp2" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 212px; height: 19px" >
                                            <asp:TextBox ID="txtNrp" runat="server" Width="200px" MaxLength="30"></asp:TextBox>&nbsp;</td>
                                        <td align="left" style="color:red; height: 19px">
                                            <asp:Label ID="LabelNrp1" runat="server" Text="Isi 'VISITOR' bila Non Kpp"></asp:Label>
                                        </td>
                                    </tr>
                            
									<tr>
                                        <td style="width: 161px; height: 19px">
                                            <asp:Label ID="LabelNama" runat="server" Text="Nama"></asp:Label></td>
									    <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="LabelNama1" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 212px; height: 19px" >
                                            <asp:TextBox ID="txtNama" runat="server" Width="200px" MaxLength="30"></asp:TextBox>&nbsp;</td>
                                        <td align="left" style="height: 19px">
                                        </td>
                                    </tr>
									<tr>
                                        <td style="width: 161px; height: 19px">
                                            <asp:Label ID="LabelJabatan" runat="server" Text="Jabatan"></asp:Label></td>
									    <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="LabelJabatan1" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 212px; height: 19px" >
                                            <asp:TextBox ID="txtJabatan" runat="server" Width="200px" MaxLength="30"></asp:TextBox>&nbsp;</td>
                                        <td align="left" style="height: 19px">
                                        </td>
                                    </tr>
									<tr>
                                        <td style="width: 161px; height: 19px">
                                            <asp:Label ID="LabelDepartemen" runat="server" Text="Departemen"></asp:Label></td>
									    <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="LabelDepartemen1" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 212px; height: 19px" >
											 <asp:SqlDataSource ID="SqlDataDept" runat="server" ConnectionString="<%$ ConnectionStrings:persisConnectionString %>"
											SelectCommand="SELECT [Dept] FROM [Tbl_Dept]"></asp:SqlDataSource>
											 <asp:DropDownList ID="txtDepartemen" runat="server" AutoPostBack="True" DataSourceID="SqlDataDept"
											    DataTextField="Dept" DataValueField="Dept" Width="200px" MaxLength="30">
											 </asp:DropDownList>
                                        </td>
                                        <td align="left" style="height: 19px">
                                        </td>
                                    </tr>
									<tr>
                                        <td style="width: 161px; height: 19px">
                                            <asp:Label ID="LabelPerusahaan" runat="server" Text="Perusahaan"></asp:Label></td>
									    <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="LabelPerusahaan1" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 212px; height: 19px" >
                                            <asp:TextBox ID="txtCompany" runat="server" Width="200px" MaxLength="30"></asp:TextBox>&nbsp;</td>
                                        <td align="left" style="height: 19px">
                                        </td>
                                    </tr>
									
									<tr>
                                        <td style="width: 161px; height: 19px">
                                            <asp:Label ID="LabelAwal" runat="server" Text="Awal"></asp:Label></td>
									    <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="LabelAwal1" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 212px; height: 19px" >
                                             <asp:TextBox ID="txtAwal" runat="server" Width="136px" AutoPostBack="True"></asp:TextBox>
                                            <A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=txtAwal','PopupClass','width=215,height=195,left=330,top=300')"
		                            href="javascript:;"><IMG src="Images/Calendar.png" border="0" id="IMGAwal" runat="server" align="absMiddle" height="20" width="20"></A>
                                          </td>
										 <td align="left" style="color:red; height: 19px">
                                            <asp:Label ID="LabelAwal2" runat="server" Text="Kosongkan bila tidak ada keberangkatan"></asp:Label>
                                        </td>
                                        <td align="left" style="height: 19px">
                                        </td>
                                    </tr>
									
									<tr>
                                        <td style="width: 161px; height: 19px">
                                            <asp:Label ID="LabelAkhirPulang" runat="server" Text="Akhir"></asp:Label></td>
									    <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="LabelAkhirPulang1" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 212px; height: 19px" >
                                             <asp:TextBox ID="txtAkhir" runat="server" Width="136px" AutoPostBack="True"></asp:TextBox>
                                            <A onclick="window.open('PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=txtAkhir','PopupClass','width=215,height=195,left=330,top=300')"
		                            href="javascript:;"><IMG src="Images/Calendar.png" border="0" id="IMGAkhir" runat="server" align="absMiddle" height="20" width="20"></A>
                                          </td>
										 <td align="left" style="color:red; height: 19px">
                                            <asp:Label ID="LabelAkhir2" runat="server" Text="Kosongkan bila tidak kepulangan"></asp:Label>
                                        </td>
                                        <td align="left" style="height: 19px">
                                        </td>
                                    </tr>
											
								   <tr>
                                        <td style="width: 161px; height: 19px">
                                            <asp:Label ID="LabelMess" runat="server" Text="Mess"></asp:Label></td>
									    <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="LabelMess1" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 212px; height: 19px" >
                                            <asp:TextBox ID="txtMess" runat="server" Width="200px" MaxLength="30"></asp:TextBox>&nbsp;</td>
                                        <td align="left" style="height: 19px">
                                        </td>
                                    </tr>
									
									<tr>
                                        <td style="width: 161px; height: 19px">
                                            <asp:Label ID="LabelNoHp" runat="server" Text="No. HP"></asp:Label></td>
									    <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="LabelNoHp1" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 212px; height: 19px" >
                                            <asp:TextBox ID="txtTelepon" runat="server" Width="200px" MaxLength="30"></asp:TextBox>&nbsp;</td>
                                        <td align="left" style="height: 19px">
                                        </td>
                                    </tr>
									
									<tr>
                                        <td style="width: 161px; height: 19px">
                                            <asp:Label ID="LabelKeterangan" runat="server" Text="Keterangan"></asp:Label></td>
									    <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="LabelKeterangan1" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 212px; height: 19px" >
                                            <asp:TextBox ID="txtKeterangan" runat="server" Width="200px" MaxLength="30"></asp:TextBox>&nbsp;</td>
                                        <td align="left" style="height: 19px">
                                        </td>
                                    </tr>
									
									<tr>
                                        <td style="width: 161px; height: 19px">
                                            <asp:Label ID="LabelTujuan" runat="server" Text="Tujuan"></asp:Label></td>
									    <td align="center" style="width: 28px; height: 19px">
                                            <asp:Label ID="LabelTujuan1" runat="server" Text=" : "></asp:Label></td>
                                        <td style="width: 212px; height: 19px" >
                                            <asp:TextBox ID="txtTujuan" runat="server" Width="200px" MaxLength="30"></asp:TextBox>&nbsp;</td>
                                        <td align="left" style="height: 19px">
										 <asp:Button ID="btSave" runat="server" Text="  Simpan  " /></td>
                                        </td>
                                    </tr>
        </table>
    </div>
    </div>
    </form>
    <script language="javascript" type="text/javascript">
     if(NiftyCheck()) {
	    Rounded("div#div1","all","#ffffff","#0066cc");
    }
	</script>
</body>
</html>
