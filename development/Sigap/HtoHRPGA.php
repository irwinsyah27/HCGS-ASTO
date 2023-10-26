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
<title>Harian To HRPGA</title>
<script language="javascript">     
function Delete(No,date)
	{
	var konfirmasi = confirm("Anda Yakin ?");
	if (konfirmasi == true)
	  {
	  alert("Data dihapus !");
	  location.href="HtoHRPGA.php?bDelete="+No+"&pick_date="+date; 
	  }
	else
	  {
	  location.href="HtoHRPGA.php";
	  }
	}
function pick(tgt)
{
 window.open("tools/kalender_pick.php?rand="+Math.random()+"&tgt="+tgt,"Kalender","width=500,height=400,alwaysRaised=yes,scrollbars=yes,directories=no,location=no,menubar=no,toolbar=no");
}
</script>
<style type="text/css">
<!--
.text {font-size: 14px; font-family: "DejaVu Sans"}
body {
	background-image: url();
}
.style2 {color: #EEEEEE}
body {
	background-image: url();
}
.style1 {font-size: 14px; font-family: "DejaVu Sans"; font-weight: bold; }
.style3 {	font-size: 18px;
	font-weight: bold;
	color: #3333FF;
}
.style4 {font-size: 16px; color: #FFFFFF; font-family: "DejaVu Sans", Courier, monospace; font-weight: bold; }
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
                  <th bgcolor="#FFFFFF" scope="col"><span>
                    <script id="sothink_widgets:dwwidget_dhtmlmenu3_8_2011.pgt" type="text/javascript">
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
stm_aix("p2i0","p1i0",[0,"Petugas Jaga","","",-1,-1,0,"http://10.13.17.55/ReportServer/Pages/ReportViewer.aspx?%2fSecurity%2fDPJ&rs:Command=Render","_self","","Absensi Petugas Jaga"],110,0);
stm_aix("p2i1","p1i0",[0,"Lap PM","","",-1,-1,0,"http://10.13.17.55/ReportServer/Pages/ReportViewer.aspx?%2fSecurity%2fLaporanPM&rs:Command=Render","_self","","Laporan Harian PM"],110,0);
stm_aix("p2i2","p1i0",[0,"Lap HRPGA","","",-1,-1,0,"http://10.13.17.55/ReportServer/Pages/ReportViewer.aspx?%2fSecurity%2fLaporanHarian&rs%3aCommand=Render","_self","","Laporan Harian HRPGA"],110,0);
stm_ep();
stm_ep();
stm_em();
//-->
                    </script>
                  </span></th>
                </tr>
            </table></td>
      </tr>
      <tr>
        <td colspan="2"></td>
      </tr>
    </table>
        <div align="center"><span class="style3">Laporan Harian ke HRPGA</span> </div>
      <form action="" method="get" name="form1" target="_self" id="form1">
          <div align="center">
            <?
		  if (($_SESSION[User]=='KC10047') or ($_SESSION[User]=='TA11014') or ($_SESSION[User]=='6103041')) {
		  echo ("<div align=center><input name=bInsert type=submit id=bInsert value=Insert /></div></p>");
		  } 
		  $date1 =  $pick_date.' 23:59:59.000';
	  ?>
            Tanggal :<span class="style3">
              <label><span class="style4">
                <input name="pick_date" type="text" id="pick_date" value="<? if($pick_date==''){echo date('Y-m-d');} else echo $pick_date; ?>" size="12" />
                <input name="Button" type="button" style="background-image:url(Images/Calendar.png); background-repeat:no-repeat; background-position:center; border:none;" onclick="pick('pick_date');" value="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" />
                </span></label>
              <input type="submit" name="Submit" value="F5 (Refresh)" accesskey="r" />
            </span> </div>
        <table width="555" border="0" align="center" bgcolor="#99CCFF">
            <tr>
              <td width="549" bgcolor="#FFFFFF"><table width="400" border="0" align="center">
                  <tr>
                    <td width="174"><p align="right"><strong>Nomor : </strong></p></td>
                    <td width="174"><input name="mNo" type="text" id="mNo" value="<? $SNo=mssql_query("Select No from Lap_Harian WHERE Tanggal BETWEEN '$pick_date' and '$date1' order by no desc"); $sNo=mssql_fetch_array($SNo); if($sNo[No]=='') {echo 'LH/091/..-../SEC-KPP/20..';} else {echo $sNo[No];} ?>" size="25" /></td>
                  </tr>
                </table>
                  <? if(!$bEdit==''){
$Sel1 = mssql_query ("select Id, No, Shift, CAST(CAST(datepart(HOUR,[Tanggal]) as varchar)+':'+CAST(datepart(MINUTE,[Tanggal]) as varchar) AS varchar) AS Tanggal, Kegiatan, Keterangan from Lap_Harian where Id='$bEdit'") or die ("Terdapat kesalahan Update!");
$dEd=mssql_fetch_array($Sel1);
echo ("</p> <input type=hidden name=hID value='$bEdit'>
<table width=600 border=0 align=center>
  <tr>
    <td width=49>Shift</td>
    <td width=173><strong>:</strong> 
    <input name=tShift type=text id=tShift value='$dEd[Shift]'/></td>
    <td width=53>Kegiatan</td>
    <td width=200> 
    <textarea name=tKegiatan id=tKegiatan cols=30>$dEd[Kegiatan]</textarea></td>
  </tr>
  <tr>
    <td>Jam</td>
    <td><strong>:</strong> 
    <input name=tJam type=text id=tJam value='$dEd[Tanggal]'/></td>
    <td>Keterangan</td>
    <td>
    <textarea name=tKeterangan id=tKeterangan cols=30>$dEd[Keterangan]</textarea></td>
  </tr>
  <tr>
    <td colspan=4><div align=center>
      <input name=bUpdate type=submit id=bUpdate value=Update />
    </div></td>
  </tr>
</table>
");
} 
?>
                  <?
if($bUpdate=='Update') {
$Tgl= $tJam.':000';
$update="UPDATE Lap_Harian SET No='$mNo', Tanggal='$pick_date $Tgl', Shift='$tShift', Kegiatan='$tKegiatan', Keterangan='$tKeterangan' WHERE Id='$hID'";
$hasil =@mssql_query ($update) or die ("Terdapat Kesalahan Update");
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data TerUpdate.!!'); </SCRIPT> </BODY>");
}
if($bSave=='Save') {
$Tgl= $tJam.':000';
$insert="INSERT INTO Lap_Harian (No, Tanggal, Shift, Kegiatan, Keterangan) VALUES('$mNo','$pick_date $Tgl','$tShift','$tKegiatan','$tKeterangan')";
$hasil =@mssql_query ($insert) or die ("Terdapat Kesalahan Insert INSERT INTO Lap_Harian (No, Tanggal, Shift, Kegiatan, Keterangan) VALUES('$mNo','$pick_date ''$Tgl','$tShift','$tKegiatan','$tKeterangan')");
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data Tersimpan.!!'); </SCRIPT> </BODY>");
}
if(!$bDelete=='') {
$delete="DELETE From Lap_harian WHERE Id='$bDelete'";
$hasil =@mssql_query ($delete) or die ("Terdapat Kesalahan Update");
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data sudah dihapus.!!'); </SCRIPT> </BODY>");
}
?>
                  <?
 if($bInsert=='Insert'){ echo ("</p>
<table width=600 border=0 align=center>
  <tr>
    <td width=49>Shift</td>
    <td width=173><strong>:</strong> 
    <input name=tShift type=text id=tShift /></td>
    <td width=53>Kegiatan</td>
    <td width=200> 
    <textarea name=tKegiatan id=tKegiatan cols=30></textarea></td>
  </tr>
  <tr>
    <td>Jam</td>
    <td><strong>:</strong> 
    <input name=tJam type=text id=tJam /></td>
    <td>Keterangan</td>
    <td>
    <textarea name=tKeterangan id=tKeterangan cols=30></textarea></td>
  </tr>
  <tr>
    <td colspan=4><div align=center>
      <input name=bSave type=submit id=bSave value=Save />
    </div></td>
  </tr>
</table>
");} ?></td>
            </tr>
          </table>
        <table width="100%" border="0" align="center">
            <tr>
              <td><div align="center" class="style1">&#8212; Shift I &#8212;</div></td>
            </tr>
            <tr>
              <td><? 
$sel2=mssql_query("select Id, No, Shift, CAST(CAST(datepart(HOUR,[Tanggal]) as varchar)+':'+CAST(datepart(MINUTE,[Tanggal]) as varchar) AS varchar) AS Tanggal, Kegiatan, Keterangan from Lap_Harian where Shift=1 and Tanggal BETWEEN '$pick_date' and '$date1'");
$sel3=mssql_query("Select COUNT(NRP) as [Tot] from Petugas");
$dSum=mssql_fetch_array($sel3);
// ------ buat tampilan tabel
echo("<table width=100%  border=0 bgcolor=#99CCFF>");
echo("<td bgcolor=#336699><div align=center><span class=style2>No</span></td>
							  <td width=10% bgcolor=#336699><div align=center><span class=style2>Jam</span></td>
							  <td width=40% bgcolor=#336699><div align=center><span class=style2>Uraian Kejadian / Kegiatan</span></td>
                              <td width=40% bgcolor=#336699><div align=center><span class=style2>Keterangan</span></td>");
                              if (($_SESSION[User]=='KC10047') or ($_SESSION[User]=='TA11014') or ($_SESSION[User]=='6103041')) {
							  echo ("<td bgcolor=#336699><div align=center><span class=style2>@@@@@@@</span></td>");
							  }
		  					  
// ------ ambil isi masing-masing record
while ($row = mssql_fetch_object($sel2))
{
		// ----- mengambil isi setiap kolom
		
		$Id=$row->Id;
		$No=$row->No;
		$Nomor = $Nomor + 1;
		$Shift=$row->Shift;
		$Tanggal=$row->Tanggal;
		$Kegiatan=$row->Kegiatan;
		$Keterangan=$row->Keterangan;

		// ------ menampilkan di layar browser
		echo("<tr><div align=center>
		    <td bgcolor=#CFFFFF class=text><div align=Center>$Nomor</td>
			<td bgcolor=#CFFFFF class=text><div align=Center>$Tanggal</td>
			<td bgcolor=#CFFFFF class=text><div align=Justify>$Kegiatan</td>
			<td bgcolor=#CFFFFF class=text><div align=Justify>$Keterangan</td>");
            if (($_SESSION[User]=='KC10047') or ($_SESSION[User]=='TA11014') or ($_SESSION[User]=='6103041')) {
			echo("<td width=23% bgcolor=#CFFFFF class=style5><div align=Center><input type=submit name=bEdit value=Edit onClick=value='$Id'>
				  <input type=Button name=bDelete value=Delete onClick=Delete('$Id','$pick_date')>
			</td>");
			}
			echo ("</tr>");
}
echo("</table>");
?></td>
            </tr>
            <tr>
              <td><div align="center" class="style1">&#8212; Shift II &#8212;</div></td>
            </tr>
            <tr>
              <td><?
$sel2=mssql_query("select Id, No, Shift, CAST(CAST(datepart(HOUR,[Tanggal]) as varchar)+':'+CAST(datepart(MINUTE,[Tanggal]) as varchar) AS varchar) AS Tanggal, Kegiatan, Keterangan from Lap_Harian where Shift=2 and Tanggal BETWEEN '$pick_date' and '$date1'");
$sel3=mssql_query("Select COUNT(NRP) as [Tot] from Petugas");
$dSum=mssql_fetch_array($sel3);
// ------ buat tampilan tabel
echo("<table width=100%  border=0 bgcolor=#99CCFF>");
echo("<td bgcolor=#336699><div align=center><span class=style2>No</span></td>
							  <td width=10% bgcolor=#336699><div align=center><span class=style2>Jam</span></td>
							  <td width=40% bgcolor=#336699><div align=center><span class=style2>Uraian Kejadian / Kegiatan</span></td>
                              <td width=40% bgcolor=#336699><div align=center><span class=style2>Keterangan</span></td>");
                              if (($_SESSION[User]=='KC10047') or ($_SESSION[User]=='TA11014') or ($_SESSION[User]=='6103041')) {
							  echo ("<td bgcolor=#336699><div align=center><span class=style2>@@@@@@@</span></td>");
							  }
		  					  
// ------ ambil isi masing-masing record
while ($row = mssql_fetch_object($sel2))
{
		// ----- mengambil isi setiap kolom
		
		$Id=$row->Id;
		$No=$row->No;
		$Nomor2 = $Nomor2 + 1;
		$Shift=$row->Shift;
		$Tanggal=$row->Tanggal;
		$Kegiatan=$row->Kegiatan;
		$Keterangan=$row->Keterangan;

		// ------ menampilkan di layar browser
		echo("<tr><div align=center>
		    <td bgcolor=#CFFFFF class=text><div align=Center>$Nomor2</td>
			<td bgcolor=#CFFFFF class=text><div align=Center>$Tanggal</td>
			<td bgcolor=#CFFFFF class=text><div align=Justify>$Kegiatan</td>
			<td bgcolor=#CFFFFF class=text><div align=Justify>$Keterangan</td>");
            if (($_SESSION[User]=='KC10047') or ($_SESSION[User]=='TA11014') or ($_SESSION[User]=='6103041')) {
			echo("<td width=23% bgcolor=#CFFFFF class=style5><div align=Center><input type=submit name=bEdit value=Edit onClick=value='$Id'>
				  <input type=Button name=bDelete value=Delete onClick=Delete('$Id')>
			</td>");
			}
			echo ("</tr>");
}
echo("</table>");
$mati=@mssql_close($koneksi);
?></td>
            </tr>
          </table>
      </form></td>
  </tr>
</table>
</body>
</html>
