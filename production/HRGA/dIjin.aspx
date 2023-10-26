<%@ Page Language="VB" Debug="TRUE" MasterPageFile="~/HRGA/MasterHrga.master" AutoEventWireup="false" CodeFile="dIjin.aspx.vb" Inherits="HRGA_dIjin" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td style="width: 100px" valign="top" Height="776">
                <fieldset>
                    <asp:TreeView ID="TreeView1" runat="server" Font-Bold="True" Font-Size="10pt" ImageSet="Arrows"
                        Width="176px">
                        <ParentNodeStyle Font-Bold="False" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                            VerticalPadding="0px" />
                        <Nodes>
                            <asp:TreeNode Text="STATUS IJIN JOB SITE" Value="STATUS IJIN JOB SITE">
                                <asp:TreeNode NavigateUrl="status1.aspx" Text="PROSES" Value="PROSES"></asp:TreeNode>
                                <asp:TreeNode NavigateUrl="status2.aspx" Text="DISETUJUI" Value="DISETUJUI"></asp:TreeNode>
                                <asp:TreeNode NavigateUrl="status3.aspx" Text="TIDAK DISETUJUI" Value="TIDAK DISETUJUI">
                                </asp:TreeNode>
                            </asp:TreeNode>
                        </Nodes>
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                </fieldset>
            </td>
            <td style="width: 700px" valign="top">
                <br />
                <asp:Panel ID="Panel2" runat="server" Height="300px" Width="300px">
        <fieldset id="Panel1" style="margin-left: 5px; width: 664px; margin-right: 5px; text-align: left">
            <legend style="color: #000033">Diisi oleh karyawan / Adm departemen</legend>
            <table border="0" cellpadding="2" cellspacing="0" style="width: 100%">
                <tr>
                    <td colspan="2" style="height: 68px; text-align: center">
                        <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Size="24pt" Text="Ijin Meninggalkan Job Site"></asp:Label><br />
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="width: 154px">
                        <asp:Label ID="Label2" runat="server" Text="Nrp " Font-Bold="True"></asp:Label></td>
                    <td style="width: 500px">
                        &nbsp;<asp:Label ID="lblNrp" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Bold="False" Width="488px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 154px; height: 19px">
                        <asp:Label ID="Label6" runat="server" Text="Nama" Font-Bold="True"></asp:Label></td>
                    <td style="width: 500px; height: 19px">
                        &nbsp;<asp:Label ID="lblNama" runat="server" Font-Bold="False" BorderStyle="Solid" BorderWidth="1px" Width="488px"></asp:Label>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 154px">
                        <asp:Label ID="Label8" runat="server" Text="Dept." Font-Bold="True"></asp:Label></td>
                    <td style="width: 500px">
                        &nbsp;<asp:Label ID="lblDepartemen" runat="server" Font-Bold="False" BorderStyle="Solid" BorderWidth="1px" Width="488px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 154px; height: 19px">
                        <asp:Label ID="Label3" runat="server" Text="Dari Tanggal" Width="88px" Font-Bold="True"></asp:Label></td>
                    <td style="width: 500px; height: 19px">
                        &nbsp;<asp:Label ID="lblAwal" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Bold="False" Width="488px"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 154px; height: 19px">
                        <asp:Label ID="Label4" runat="server" Text="s/d Tanggal " Font-Bold="True"></asp:Label></td>
                    <td style="width: 500px; height: 19px">
                        &nbsp;<asp:Label ID="lblAkhir" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Bold="False" Width="488px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 154px">
                    </td>
                    <td style="width: 500px">
                        &nbsp;<asp:RadioButton ID="RadioButton1" runat="server" Enabled="False" GroupName="IJIN"
                            Text="Ijin" Width="56px" /><asp:RadioButton ID="RadioButton2" runat="server" Enabled="False"
                                GroupName="IJIN" Text="Surat Keterangan Dokter " /><asp:RadioButton ID="RadioButton3"
                                    runat="server" Enabled="False" GroupName="IJIN" Text="Sakit Tanpa Keterangan Dokter"
                                    Width="213px" /></td>
                </tr>
                <tr>
                    <td style="width: 154px">
                        <asp:Label ID="Label5" runat="server" Text="Keperluan" Font-Bold="True"></asp:Label></td>
                    <td style="width: 100px">
                        &nbsp;<asp:Label ID="lblKeperluan" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Bold="False" Width="488px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 154px; height: 23px">
                    </td>
                    <td style="width: 100px; height: 23px; text-align: left">
                    </td>
                </tr>
            </table>
            <br />
        </fieldset>
    </asp:Panel>
    <asp:Panel ID="Panel0" runat="server" Height="50px" Width="125px">
                <fieldset style="margin-left: 5px; width: 664px; margin-right: 5px">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 663px">
                        <tr>
                            <td style="width: 100px; height: 16px">
                                <p style="width: 663px">
                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Sisa Cuti Tahunan : "
                                        Width="142px"></asp:Label>
                                    <asp:Label ID="lblSisaCuti" runat="server" Font-Bold="True" Width="99px"></asp:Label></p>
                            </td>
                        </tr>
                    </table>
                </fieldset>
    </asp:Panel> 
                <br />
    <asp:Panel ID="Panel3" runat="server" Height="50px" Width="125px" Enabled="False">
    <fieldset style="margin-left: 5px; width: 664px; margin-right: 5px;">
        <legend style="color: #000033">Persetujuan Atasan</legend>
        <br />
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" id="TABLE1">
            <tr>
                <td style="width: 30%; text-align: right">
                    <asp:Label ID="Label9" runat="server" Text="Persetujuan :"></asp:Label></td>
                <td style="width: 70%">
                    &nbsp;<asp:RadioButton ID="RadioPersetujuan1" runat="server" Text="Menyetujui" GroupName="PersetujuanAtasan" AutoPostBack="True" />
        <asp:RadioButton ID="RadioPersetujuan2" runat="server" Text="Tidak Menyetujui" GroupName="PersetujuanAtasan" AutoPostBack="True" /></td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">
                    <asp:Label ID="Label11" runat="server" Text="disetujui/ditolak oleh :"></asp:Label></td>
                <td style="width: 70%">
                    &nbsp;
                    <asp:Label ID="lblAtasan" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">
                    <asp:Label ID="Label10" runat="server" Text="Catatan :"></asp:Label></td>
                <td style="width: 70%">
                    &nbsp;
        <asp:Label ID="lblCatatanAtasan" runat="server" Font-Bold="True"></asp:Label>&nbsp;
        <asp:TextBox ID="txtCatatanAtasan" runat="server" Width="256px" Enabled="False" AutoPostBack="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCatatanAtasan"
                        ErrorMessage="Harap diisi.."></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">
                </td>
                <td style="width: 70%">
                    &nbsp;
        <asp:Button ID="btn2" runat="server" Text=" Send " Visible="False" /></td>
            </tr>
        </table>
        <br />
    </fieldset>
        <br />
    </asp:Panel>
    <asp:Panel ID="Panel4" runat="server" Height="50px" Width="125px" Visible="False" Enabled="False">
    <fieldset style="margin-left: 5px; width: 664px; margin-right: 5px;">
        <legend style="color: #000033">HR / Personnel Admin.&nbsp;</legend>
        <br />
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 30%; text-align: right">
                    <asp:Label ID="Label12" runat="server" Text="Validasi :"></asp:Label></td>
                <td style="width: 70%">
                    &nbsp;<asp:RadioButton ID="RadioValidasi1" runat="server" Text="Sesuai PKB" GroupName="status" AutoPostBack="True" /><asp:RadioButton ID="RadioValidasi2" runat="server" Text="Tidak Sesuai PKB" GroupName="status" AutoPostBack="True" /></td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">
                </td>
                <td style="width: 70%">
                    &nbsp;<asp:RadioButton ID="RadioPotongCuti" runat="server" GroupName="Potong" Text="Potong Cuti Tahunan"
                        Visible="False" />
                    <asp:RadioButton ID="RadioPotongOff" runat="server" GroupName="Potong" Text="Potong Hari Off"
                        Visible="False" /></td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">
                    <asp:Label ID="Label13" runat="server" Text="Divalidasi oleh :"></asp:Label></td>
                <td style="width: 70%">
                    &nbsp;
                    <asp:Label ID="lblHR" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">
                    <asp:Label ID="Label15" runat="server" Text="Catatan :"></asp:Label></td>
                <td style="width: 70%">
                    &nbsp;
        <asp:Label ID="lblCatatanHR" runat="server" Font-Bold="True"></asp:Label>
        <asp:TextBox ID="txtCatatanHR" runat="server" Width="256px" Enabled="False" AutoPostBack="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCatatanHR"
                        ErrorMessage="Harap diisi.."></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">
                </td>
                <td style="width: 70%">
        <asp:Button ID="btn3" runat="server" Text=" Send " Visible="False" /></td>
            </tr>
        </table>
        <br />
    </fieldset>
    </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

