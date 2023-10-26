<%@ Page Language="VB" MasterPageFile="MasterHrga.master" AutoEventWireup="false" CodeFile="fIjin.aspx.vb" Inherits="HRGA_fIjin" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td style="width: 100px; height: 385px;" valign="top">
                <fieldset>
                    <asp:TreeView ID="TreeView1" runat="server" Font-Bold="True" Font-Size="10pt" ImageSet="Arrows" Width="127px">
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
                &nbsp;<br />
                <br />
            </td>
            <td style="width: 100px; height: 385px;" valign="top">
                &nbsp;<br />
                <asp:Panel ID="Panel2" runat="server" Height="50px" Width="125px">
    <fieldset style="margin-left: 5px; width: 664px; margin-right: 5px;" id="Panel1">
        <legend style="color: #000033">Diisi oleh karyawan / Adm departemen</legend>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td colspan="2" style="height: 68px;" align="center">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Size="24pt" Text="Ijin Meninggalkan Job Site"></asp:Label>
                    <hr />
                </td>
            </tr>
             <tr>
                <td colspan="2" style="height: 50px;" align="center">
              
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                <asp:Label ID="Label2" runat="server" Text="Nrp "></asp:Label></td>
                <td style="width: 500px">
                <asp:TextBox ID="txtNrp" runat="server" Width="200px" AutoPostBack="True"></asp:TextBox>
                <A onclick="window.open('./cuti/PopupNrp.aspx?FormName=' + document.forms[0].name + '&textbox=ctl00$ContentPlaceHolder1$txtNrp','PopupClass','width=390,height=400,left=300,top=100')"
		            href="javascript:;"><IMG src="Images/GoLtrHS.png" border="0" id="IMG3" runat="server" align="absMiddle" height="20" width="20"></A>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNrp"
                        ErrorMessage="mohon diisi..!"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 19px;">
                    <asp:Label ID="Label6" runat="server" Text="Nama"></asp:Label></td>
                <td style="width: 500px; height: 19px;">
                    <asp:Label ID="lblNama" runat="server" Font-Bold="True"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label8" runat="server" Text="Dept."></asp:Label></td>
                <td style="width: 500px">
                    <asp:Label ID="lblDepartemen" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px">
                <asp:Label ID="Label3" runat="server" Text="Dari Tanggal" Width="96px"></asp:Label></td>
                <td style="width: 500px">
                <asp:TextBox ID="txtAwal" runat="server" Width="200px"></asp:TextBox>
                <A onclick="window.open('./cuti/PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=ctl00$ContentPlaceHolder1$txtAwal','PopupClass','width=215,height=195,left=500,top=400')"
		                            href="javascript:;"><IMG src="Images/Calendar.png" border="0" id="IMG1" runat="server" align="absMiddle" height="20" width="20"></A>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAwal"
                        ErrorMessage="mohon diisi..!"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px">
                <asp:Label ID="Label4" runat="server" Text="s/d Tanggal "></asp:Label></td>
                <td style="width: 500px">
                <asp:TextBox ID="txtAkhir" runat="server" Width="200px"></asp:TextBox>
                <A onclick="window.open('./cuti/PopupCal.aspx?FormName=' + document.forms[0].name + '&textbox=ctl00$ContentPlaceHolder1$txtAkhir','PopupClass','width=215,height=195,left=500,top=400')"
		                            href="javascript:;"><IMG src="Images/Calendar.png" border="0" id="IMG2" runat="server" align="absMiddle" height="20" width="20"></A>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAkhir"
                        ErrorMessage="mohon diisi..!"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 20px">
                </td>
                <td style="width: 500px; height: 20px">
                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="IJIN" Text="Ijin" Width="56px" AutoPostBack="True" />
                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="IJIN" Text="Surat Keterangan Dokter " AutoPostBack="True" />
                    <asp:RadioButton ID="RadioButton3" runat="server" GroupName="IJIN" Text="Sakit Tanpa Keterangan Dokter"
                        Width="213px" AutoPostBack="True" /></td>
            </tr>
            <tr>
                <td style="width: 100px">
                <asp:Label ID="Label5" runat="server" Text="Keterangan"></asp:Label></td>
                <td style="width: 100px">
                <asp:TextBox ID="txtKeperluan" runat="server" Width="560px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px; text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtKeperluan"
                        ErrorMessage="mohon diisi..!"></asp:RequiredFieldValidator></td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btn1" runat="server" Text=" Send " Enabled="False" /><br />
        </fieldset>
    </asp:Panel>
                <br />
                <fieldset style="width: 664px; margin-left: 5px; margin-right: 5px;">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 663px">
                    <tr>
                        <td style="width: 100px; height: 16px;">
                            <p style="width: 663px">
                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Sisa Cuti Tahunan : "
                                    Width="142px"></asp:Label>
                                <asp:Label ID="lblSisaCuti" runat="server" Font-Bold="True" Width="99px"></asp:Label></p>
                           </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 16px;">
                            <p style="width: 663px">
                                <asp:Label ID="LabelCutiBesar" runat="server" Font-Bold="True" Text="Sisa Cuti Besar : "
                                    Width="142px"></asp:Label>
                                <asp:Label ID="lblSisaCutiBesar" runat="server" Font-Bold="True" Width="99px"></asp:Label></p>
                           </td>
                    </tr>
                </table>
                </fieldset>
                &nbsp;&nbsp;</td>
        </tr>
    </table>
    &nbsp;<br />
</asp:Content>

