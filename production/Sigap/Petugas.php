<?
session_start();
//require("cek.php");
// ----- ambil isi dari file koneksi.php
require("tools/koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Untitled Document</title>
<script language="javascript">     
function Delete(No)
	{
	var konfirmasi = confirm("Anda Yakin ?");
	if (konfirmasi == true)
	  {
	  alert("Data dihapus !");
	  location.href="Petugas.php?bDelete="+No; 
	  }
	else
	  {
	  location.href="Petugas.php";
	  }
	}
</script>
<style type="text/css">
<!--
.text {font-size: 14px; font-family: "DejaVu Sans"}
.style2 {color: #EEEEEE}
body {
	background-image: url();
}
-->
</style>
<script type="text/javascript" src="stmenu.js"></script>
</head>
<body>
<table width="699" border="0" align="center" background="Images/MainPageBackground.jpg">
  <tr>
    <td width="671"><table width="512" border="0" align="center">
      <tr>
        <td width="108"><a href="Utama.php"><img src="Images/police027.gif" width="100" height="150" border="0" /></a></td>
        <td width="394"><span><a href="http://www.dhtml-menu-builder.com"  style="display:none;visibility:hidden;">Javascript DHTML Drop Down Menu Powered by dhtml-menu-builder.com</a></span>
              <table width="200" border="0" bgcolor="#004400">
                <tr>
                  <th bgcolor="#FFFFFF" scope="col"><script id="sothink_widgets:dwwidget_dhtmlmenu3_8_2011.pgt" type="text/javascript">
<!--
stm_bm(["menu45ba",900,"","blank.gif",0,"","",0,0,250,0,1000,1,0,0,"","",0,0,1,2,"default","hand","",1,25],this);
stm_bp("p0",[0,4,0,0,2,0,0,9,100,"",-2,"",-2,50,2,3,"#999999","transparent","bg_00.gif",1,1,1,"#000000 #666666 #B4C8B4"]);
stm_ai("p0i0",[0,"Security","","",-1,-1,0,"Petugas.php","_self","","Petugas Security","","",0,0,0,"","",0,0,0,0,1,"#FFFFF7",1,"#B5BED6",1,"","bg2.gif",3,3,0,0,"#FFFFF7","#000000","#FFFFFF","#FFFFFF","9pt Verdana","9pt Verdana",0,0,"","bg1.gif","","bg3.gif",6,6,25],85,25);
stm_aix("p0i1","p0i0",[0,"Aktivitas","","",-1,-1,0,"#","_self","","","","",0,0,0,"0604arroldw.gif","0604arroldw.gif",9,7,0,1,1,"#00CCFF"],120,25);
stm_bp("p1",[1,4,0,0,5,5,0,0,100,"",-2,"",-2,50,2,3,"#999999","#333333","",0,1,1,"#B4C8B4"]);
stm_ai("p1i0",[0,"Petugas Jaga","","",-1,-1,0,"Absensi.php","_self","","Input Absensi","","",0,0,0,"","",0,0,0,0,1,"#00CCFF",1,"#B4C8B4",0,"","",3,0,0,0,"#FFFFF7","#000000","#FFFFFF","#000000","8pt Verdana","8pt Verdana",0,0,"","","","",0,0,0]);
stm_aix("p1i1","p1i0",[0,"Aktivitas Patroli","","",-1,-1,0,"Aktivitas.php","_self","","Input Aktivitas Patroli"]);
stm_aix("p1i2","p1i0",[0,"Harian ke PM","","",-1,-1,0,"HtoPM.php","_self","","Input Harian PM"]);
stm_aix("p1i3","p1i0",[0,"Harian ke HRPGA","","",-1,-1,0,"HtoHRPGA.php","_self","","Input Harian HRPGA"]);
stm_ep();
stm_aix("p0i2","p0i0",[0,"Laporan","","",-1,-1,0,"#","_self","","","","",0,0,0,"0604arroldw.gif","0604arroldw.gif",9,7,0,1],120,25);
stm_bpx("p2","p1",[]);
stm_aix("p2i0","p1i0",[0,"Petugas Jaga","","",-1,-1,0,"http://10.2.167.130/ReportServer/Pages/ReportViewer.aspx?%2fSecurity%2fDPJ&rs:Command=Render","_self","","Absensi Petugas Jaga"],110,0);
stm_aix("p2i1","p1i0",[0,"Lap PM","","",-1,-1,0,"http://10.2.167.130/ReportServer/Pages/ReportViewer.aspx?%2fSecurity%2fLaporanPM&rs:Command=Render","_self","","Laporan Harian PM"],110,0);
stm_aix("p2i2","p1i0",[0,"Lap HRPGA","","",-1,-1,0,"http://10.2.167.130/ReportServer/Pages/ReportViewer.aspx?%2fSecurity%2fLaporanHarian&rs%3aCommand=Render","_self","","Laporan Harian HRPGA"],110,0);
stm_ep();
stm_ep();
stm_em();
//-->
                    </script></th>
                </tr>
            </table></td>
      </tr>
      <tr>
        <td colspan="2"><table width="100%" border="0">
          <tr>
            <th scope="col"><form action="" method="get" name="form1" target="_self" id="form1">
              <table width="200" border="0">
                <tr>
                  <td><div align="center">
                    <?
		  if (($_SESSION[User]=='KC10047') or ($_SESSION[User]=='TA11014') or ($_SESSION[User]=='6103041')) {
		  echo ("<input name=bInsert type=submit id=bInsert value=Insert /></p>");
		  } ?>
                  </div></td>
                  <td><div align="center">
                    <?
		  if (($_SESSION[User]=='KC10047') or ($_SESSION[User]=='TA11014') or ($_SESSION[User]=='6103041')) {
		  echo ("<input name=bSwitch type=submit id=bSwitch value=Switch /></p>");
		  } ?>
                  </div></td>
                </tr>
              </table>
              <table width="555" border="0" align="center" bgcolor="#99CCFF">
                <tr>
                  <td width="549" bgcolor="#FFFFFF"><? if($bInsert=='Insert'){ echo ("</p>
<table width=450 border=0 align=center>
  <tr>
    <td width=49>NRP</td>
    <td width=173><strong>:</strong> 
    <input name=tNrp type=text id=tNrp value='$dEd[NRP]'/></td>
    <td width=53>Jabatan</td>
    <td width=182><strong>:</strong> 
    <input name=tJabatan type=text id=tJabatan value='$dEd[Jabatan]'/></td>
  </tr>
  <tr>
    <td>Nama</td>
    <td><strong>:</strong> 
    <input name=tNama type=text id=tNama value='$dEd[Nama]'/></td>
    <td>Anggota</td>
    <td><strong>: 
    </strong>
    <input name=tAnggota type=text id=tAnggota value='$dEd[Anggota]'/></td>
  </tr>
  <tr>
    <td colspan=4><div align=center>
      <input name=bSave type=submit id=bSave value=Save />
    </div></td>
  </tr>
</table>
");} ?>
                            <? if(!$bEdit==''){
$Sel1 = mssql_query ("Select NRP, Nama, Jabatan, Anggota from Petugas where No='$bEdit'") or die ("Terdapat kesalahan Update!");
$dEd=mssql_fetch_array($Sel1);
echo ("</p> <input type=hidden name=hID value='$bEdit'>
<table width=475 border=0 align=center>
  <tr>
    <td width=49>NRP</td>
    <td width=173><strong>:</strong> 
    <input name=tNrp type=text id=tNrp value='$dEd[NRP]'/></td>
    <td width=53>Jabatan</td>
    <td width=182><strong>:</strong> 
    <input name=tJabatan type=text id=tJabatan value='$dEd[Jabatan]'/></td>
  </tr>
  <tr>
    <td>Nama</td>
    <td><strong>:</strong> 
    <input name=tNama type=text id=tNama value='$dEd[Nama]'/></td>
    <td>Anggota</td>
    <td><strong>: 
    </strong>
    <input name=tAnggota type=text id=tAnggota value='$dEd[Anggota]'/></td>
  </tr>
  <tr>
    <td colspan=4><div align=center>
      <input name=bUpdate type=submit id=bUpdate value=Update />
    </div></td>
  </tr>
</table>
");
} ?></td>
                </tr>
              </table>
              <p></p>
              <?
$sel2=mssql_query("select No, NRP, Nama, Jabatan, Anggota from Petugas");
$sel3=mssql_query("Select COUNT(NRP) as [Tot] from Petugas");
$dSum=mssql_fetch_array($sel3);
// ------ buat tampilan tabel
echo("<table width=100%  border=0 bgcolor=#99CCFF>");
echo("<td bgcolor=#336699><div align=center><span class=style2>No</span></td>
							  <td bgcolor=#336699><div align=center><span class=style2>NRP</span></td>
							  <td bgcolor=#336699><div align=center><span class=style2>Nama</span></td>
                              <td bgcolor=#336699><div align=center><span class=style2>Jabatan</span></td>
							  <td bgcolor=#336699><div align=center><span class=style2>Anggota</span></td>");
                              if (($_SESSION[User]=='KC10047') or ($_SESSION[User]=='TA11014') or ($_SESSION[User]=='6103041')) {
							  echo ("<td bgcolor=#336699><div align=center><span class=style2>@</span></td>");
							  }
		  					  
// ------ ambil isi masing-masing record
while ($row = mssql_fetch_object($sel2))
{
		// ----- mengambil isi setiap kolom
		
		$No=$row->No;
		$Nomor = $Nomor + 1;
		$NRP=$row->NRP;
		$Nama=$row->Nama;
		$Jabatan=$row->Jabatan;
		$Anggota=$row->Anggota;

		// ------ menampilkan di layar browser
		echo("<tr><div align=center>
		    <td bgcolor=#CFFFFF class=text><div align=Center>$Nomor</td>
			<td bgcolor=#CFFFFF class=text><div align=Center>$NRP</td>
			<td bgcolor=#CFFFFF class=text><div align=Center>$Nama</td>
			<td bgcolor=#CFFFFF class=text><div align=Center>$Jabatan</td>
			<td bgcolor=#CFFFFF class=text><div align=Center>$Anggota</td>");
            if (($_SESSION[User]=='KC10047') or ($_SESSION[User]=='TA11014') or ($_SESSION[User]=='6103041')) {
			echo("<td width=23% bgcolor=#CFFFFF class=style5><div align=Center><input type=submit name=bEdit value=Edit onClick=value='$No'>
				  <input type=Button name=bDelete value=Delete onClick=Delete('$No')>
			</td>");
			}
			echo ("</tr>");
}
echo("</table>");
?>
              <?
if($bUpdate=='Update') {
$update="UPDATE Petugas SET NRP='$tNrp', Nama='$tNama', Jabatan='$tJabatan', Anggota='$tAnggota' WHERE No='$hID'";
$hasil =@mssql_query ($update) or die ("Terdapat Kesalahan Update");
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data TerUpdate.!!'); </SCRIPT> </BODY>");
}
if($bSave=='Save') {
$insert="INSERT INTO Petugas (NRP, Nama, Jabatan, Anggota) VALUES('$tNrp','$tNama','$tJabatan','$tAnggota')";
$hasil =@mssql_query ($insert) or die ("Terdapat Kesalahan Insert");
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data Tersimpan.!!'); </SCRIPT> </BODY>");
}
if(!$bDelete=='') {
$delete="DELETE From Petugas WHERE No='$bDelete'";
$hasil =@mssql_query ($delete) or die ("Terdapat Kesalahan Update");
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data sudah dihapus.!!'); </SCRIPT> </BODY>");
}
if($bSwitch=='00') {
$update="UPDATE Petugas SET Anggota='Anggota I' WHERE No='$hID'";
$hasil =@mssql_query ($update) or die ("Terdapat Kesalahan Update");
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data TerUpdate.!!'); </SCRIPT> </BODY>");
}
$mati=@mssql_close($koneksi);
?>
            </form></th>
          </tr>
          <tr>
            <td>&nbsp;</td>
          </tr>
        </table></td>
      </tr>
    </table></td>
  </tr>
</table>
</body>
</html>
