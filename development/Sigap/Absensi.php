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
<style type="text/css">
<!--
body {
	background-image: url();
}
.style1 {
	font-size: 18px;
	font-weight: bold;
	color: #3333FF;
}
.text {font-size: 14px; font-family: "DejaVu Sans"}
.style2 {color: #EEEEEE}
.style3 {font-size: 16px; color: #FFFFFF; font-family: "DejaVu Sans", Courier, monospace; font-weight: bold; }
-->
</style>
<script language="javascript">     
function Delete(No)
	{
	var konfirmasi = confirm("Anda Yakin ?");
	if (konfirmasi == true)
	  {
	  alert("Data dihapus !");
	  location.href="Absensi.php?bDelete="+No; 
	  }
	else
	  {
	  location.href="Absensi.php";
	  }
	}
function pick(tgt)
{
 window.open("tools/kalender_pick.php?rand="+Math.random()+"&tgt="+tgt,"Kalender","width=500,height=400,alwaysRaised=yes,scrollbars=yes,directories=no,location=no,menubar=no,toolbar=no");
}
</script>
<script type="text/javascript" src="stmenu.js"></script>
</head>
<body>
<table width="699" border="0" align="center" background="Images/MainPageBackground.jpg">
  <tr>
    <td width="671"><form action="" method="get" name="form1" target="_self" id="form1">
      <table width="565" border="0" align="center">
        <tr>
          <td width="108"><a href="Utama.php"><img src="Images/police027.gif" width="100" height="150" border="0" /></a></td>
          <td width="418"><span><a href="http://www.dhtml-menu-builder.com"  style="display:none;visibility:hidden;">Javascript DHTML Drop Down Menu Powered by dhtml-menu-builder.com</a></span>
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
              <td><table width="100%" border="0">
                <tr>
                  <td colspan="2"><div align="center"><span class="style1"> SECURITY POS JAGA</span></div></td>
                </tr>
                <tr>
                  <td width="84%"><div align="center"><span class="style1">
                    <? if($pick_date=='') {$pick_date= Date('Y-m-d');} $date1 =  $pick_date.' 23:59:59.000';?>
                    </span>Tanggal :
                    <label><span class="style3">
                      <input name="pick_date" type="text" id="pick_date" value="<? if($pick_date==''){echo date('Y-m-d');} else echo $pick_date; ?>" size="12" />
                      <input name="Button" type="button" style="background-image:url(Images/Calendar.png); background-repeat:no-repeat; background-position:center; border:none;" onclick="pick('pick_date');" value="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" />
                      <?
		  if (($_SESSION[User]=='KC10047') or ($_SESSION[User]=='TA11014') or ($_SESSION[User]=='6103041')) {
		  echo ("<input name=bInsert type=submit id=bInsert value=Insert /></p>");
		  } ?> 
                      <span class="style1">
                        <? if(($hDate=='') and ($hPos=='')) {$hDate=$Date; $hPos=$Pos;} ?>
                        </span> </span></label>
                  </div>
                            <label></label></td>
                  <td width="16%"><span class="style1">
                    <input type="submit" name="Submit" value="F5 (Refresh)" accesskey="r" />
                  </span></td>
                </tr>
              </table></td>
            </tr>
            <tr>
              <td><? if($bInsert=='Insert'){ echo ("</p>
<table width=450 border=0 align=center>
  <tr>
    <td width=49>NRP</td>
    <td width=173><strong>:</strong><select name=tNrp id=tNrp>");
  $sCB1=mssql_query("Select NRP from Petugas");
  while ($row2 = mssql_fetch_object($sCB1))
  {
	$NRP=$row2->NRP;
	echo("<option value='$NRP'>$NRP</option>");
  }
  echo ("</select>
  </td>
    <td width=53>Mulai</td>
    <td width=182><strong>:</strong> 
    <input name=tJam1 type=text id=tJam1 value=''/></td>
  </tr>
  <tr>
    <td>Status</td>
    <td><strong>:</strong><select name=tJaga id=tJaga>");
  $sCB2=mssql_query("Select NamaPos from POS");
  while ($row3 = mssql_fetch_object($sCB2))
  {
	$NamaPos=$row3->NamaPos;
	echo("<option value='$NamaPos'>$NamaPos</option>");
  }
  echo ("</select></td>
    <td>Sampai</td>
    <td><strong>: 
    </strong>
    <input name=tJam2 type=text id=tJam2 value=''/></td>
  </tr>
  <tr>
    <td colspan=4><div align=center>
      <input name=bSave type=submit id=bSave value=Save />
    </div></td>
  </tr>
</table>
");} ?>
                      <?
$sJagaP=mssql_query("select Petugas.NRP, Petugas.Nama, Petugas.Jabatan, Petugas.Anggota, PetugasJaga.No, CAST(CAST(datepart(HOUR,PetugasJaga.Jam1) as varchar)+':'+CAST(datepart(MINUTE,PetugasJaga.Jam1) as varchar) AS varchar) AS Jam1, CAST(CAST(datepart(HOUR,PetugasJaga.Jam2) as varchar)+':'+CAST(datepart(MINUTE,PetugasJaga.Jam2) as varchar) AS varchar) AS Jam2, Jaga FROM petugasJaga, Petugas WHERE PETUGASJAGA.NRP=PETUGAS.NRP and PETUGASJAGA.Jam1 BETWEEN '$pick_date' and '$date1'");
// ------ buat tampilan tabel
echo("<table width=100%  border=0 bgcolor=#99CCFF>");
echo("<td bgcolor=#336699><div align=center><span class=style2>No</span></td>
							  <td bgcolor=#336699><div align=center><span class=style2>NRP</span></td>
							  <td bgcolor=#336699><div align=center><span class=style2>Nama</span></td>
                              <td bgcolor=#336699><div align=center><span class=style2>Jabatan</span></td>
                              <td bgcolor=#336699><div align=center><span class=style2>Anggota</span></td>
                              <td bgcolor=#336699><div align=center><span class=style2>Mulai</span></td>
                              <td bgcolor=#336699><div align=center><span class=style2>Sampai</span></td>
							  <td bgcolor=#336699><div align=center><span class=style2>Status</span></td>");
                              if (($_SESSION[User]=='KC10047') or ($_SESSION[User]=='TA11014') or ($_SESSION[User]=='6103041')) {
							  echo ("<td bgcolor=#336699><div align=center><span class=style2>@</span></td>");
							  }
		  					  
// ------ ambil isi masing-masing record
while ($row = mssql_fetch_object($sJagaP))
{
		// ----- mengambil isi setiap kolom
		
		$No=$row->No;
		$Nomor = $Nomor + 1;
		$NRP=$row->NRP;
		$Nama=$row->Nama;
		$Jabatan=$row->Jabatan;
		$Anggota=$row->Anggota;
		$Jam1=$row->Jam1;
		$Jam2=$row->Jam2;
		$Jaga=$row->Jaga;

		// ------ menampilkan di layar browser
		echo("<tr><div align=center>
		    <td bgcolor=#CFFFFF class=text><div align=Center>$Nomor</td>
			<td bgcolor=#CFFFFF class=text><div align=Center>$NRP</td>
			<td bgcolor=#CFFFFF class=text><div align=Center>$Nama</td>
			<td bgcolor=#CFFFFF class=text><div align=Center>$Jabatan</td>
			<td bgcolor=#CFFFFF class=text><div align=Center>$Anggota</td>
			<td bgcolor=#CFFFFF class=text><div align=Center>$Jam1</td>
			<td bgcolor=#CFFFFF class=text><div align=Center>$Jam2</td>
			<td width=23% bgcolor=#CFFFFF class=text><div align=Center>$Jaga</td>");
            if (($_SESSION[User]=='KC10047') or ($_SESSION[User]=='TA11014') or ($_SESSION[User]=='6103041')) {
			echo("<td bgcolor=#CFFFFF class=style5><div align=Center>
				  <input type=Button name=bDelete value=Delete onClick=Delete('$No'+'&pick_date=$pick_date')>
			</td>");
			}
			echo ("</tr>");
}
echo("</table>");
?>
                      <?
if($bSave=='Save') {
echo ("INSERT INTO PetugasJaga (NRP, Jam1, Jam2, Jaga) VALUES('$tNrp','$pick_date $tJam1','$pick_date $tJam2','$tJaga')");
$insert="INSERT INTO PetugasJaga (NRP, Jam1, Jam2, Jaga) VALUES('$tNrp','$pick_date $tJam1','$pick_date $tJam2','$tJaga')";
$hasil =@mssql_query ($insert) or die ("Terdapat Kesalahan Insert");
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data Tersimpan.!!'); </SCRIPT> </BODY>");
}
if(!$bDelete=='') {
$delete="DELETE From PetugasJaga WHERE No='$bDelete'";
$hasil =@mssql_query ($delete) or die ("Terdapat Kesalahan Update");
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data sudah dihapus.!!'); </SCRIPT> </BODY>");
}
?></td>
            </tr>
          </table></td>
        </tr>
      </table>
    </form></td>
  </tr>
</table>
</body>
</html>
