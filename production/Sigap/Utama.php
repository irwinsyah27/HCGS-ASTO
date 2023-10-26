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
	<link rel="stylesheet" href="../Tools/themes/south-street/jquery.ui.all.css">
	<script src="../Tools/jquery-1.5.1.js"></script>
	<script src="../Tools/ui/jquery.ui.core.js"></script>
	<script src="../Tools/ui/jquery.ui.widget.js"></script>
	<script src="../Tools/ui/jquery.ui.datepicker.js"></script>
	<script src="../Tools/external/jquery.bgiframe-2.1.2.js"></script>
	<script src="../Tools/ui/jquery.ui.mouse.js"></script>
	<script src="../Tools/ui/jquery.ui.draggable.js"></script>
	<script src="../Tools/ui/jquery.ui.position.js"></script>
	<script src="../Tools/ui/jquery.ui.resizable.js"></script>
	<script src="../Tools/ui/jquery.ui.SdialogAlert.js"></script>
	<link rel="stylesheet" href="../../Tools/jQ.css">
<script language="javascript">
<!--

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

function MM_openBrWindow(theURL,winName,features) { //v2.0
  window.open(theURL,winName,features);
}

function pick(tgt)
{
 window.open("tools/kalender_pick.php?rand="+Math.random()+"&tgt="+tgt,"Kalender","width=500,height=400,alwaysRaised=yes,scrollbars=yes,directories=no,location=no,menubar=no,toolbar=no");
}
//-->
</script>
<style type="text/css">
<!--
.text {font-size: 14px; font-family: "DejaVu Sans"}
.style2 {color: #EEEEEE}
body {
	background-image: url();
}
#Layer1 {
	position:absolute;
	left:243px;
	top:375px;
	width:28px;
	height:27px;
	z-index:1;
}
#Layer2 {
	position:absolute;
	left:455px;
	top:48px;
	width:392px;
	height:46px;
	z-index:2;
}
#Layer3 {
	position:absolute;
	left:628px;
	top:553px;
	width:26px;
	height:25px;
	z-index:3;
}
#Layer4 {
	position:absolute;
	left:971px;
	top:275px;
	width:16px;
	height:20px;
	z-index:4;
}
#Layer5 {
	position:absolute;
	left:913px;
	top:625px;
	width:19px;
	height:20px;
	z-index:5;
}
#Layer6 {
	position:absolute;
	left:562px;
	top:831px;
	width:26px;
	height:27px;
	z-index:6;
}
#Layer7 {
	position:absolute;
	left:524px;
	top:1084px;
	width:22px;
	height:28px;
	z-index:7;
}
#Layer8 {
	position:absolute;
	left:484px;
	top:1193px;
	width:26px;
	height:24px;
	z-index:8;
}
#Layer9 {
	position:absolute;
	left:717px;
	top:456px;
	width:18px;
	height:21px;
	z-index:9;
}
#Layer10 {
	position:absolute;
	left:738px;
	top:420px;
	width:20px;
	height:19px;
	z-index:10;
}
.style3 {font-size: 16px; color: #FFFFFF; font-family: "DejaVu Sans", Courier, monospace; font-weight: bold; }
-->
</style>
<script type="text/javascript" src="stmenu.js"></script>
</head>
<body>
<? if($pick_date=='') { $pick_date=date('Y-m-d'); }?>
<div id="Layer2">
  <table width="200" border="0" align="center" bgcolor="#004400">
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
stm_aix("p2i0","p1i0",[0,"Petugas Jaga","","",-1,-1,0,"http://10.13.17.55/ReportServer/Pages/ReportViewer.aspx?%2fSecurity%2fDPJ&rs:Command=Render","_self","","Absensi Petugas Jaga"],110,0);
stm_aix("p2i1","p1i0",[0,"Lap PM","","",-1,-1,0,"http://10.13.17.55/ReportServer/Pages/ReportViewer.aspx?%2fSecurity%2fLaporanPM&rs:Command=Render","_self","","Laporan Harian PM"],110,0);
stm_aix("p2i2","p1i0",[0,"Lap HRPGA","","",-1,-1,0,"http://10.13.17.55/ReportServer/Pages/ReportViewer.aspx?%2fSecurity%2fLaporanHarian&rs%3aCommand=Render","_self","","Laporan Harian HRPGA"],110,0);
stm_ep();
stm_ep();
stm_em();
//-->
                    </script></th>
    </tr>
  </table>
  <div align="center"></div>
</div>
<div id="Layer1"> 
<? $date1 =  $pick_date.' 23:59:59.000';
$sP1=mssql_query("Select COUNT(NRP) as [Tot] from petugasJaga WHERE PETUGASJAGA.Jam1 BETWEEN '$pick_date' and '$date1' and Jaga LIKE '%Bypass%'");
   $P1=mssql_fetch_array($sP1);
   if(!$P1[Tot]=='0') { 
   echo ("<a href=#><img src=Images/Jaga1.gif width=29 height=28 border=0 onClick=MM_openBrWindow('listJaga.php?Pos=Bypass&Date=$pick_date','Edit','width=800,height=600') /></a>"); } 
   else echo ("<a href=#><img src=Images/Jaga2.gif width=29 height=28 border=0/></a>"); 
   ?></div>
<div id=Layer3 >
<? $sP2=mssql_query("Select COUNT(NRP) as [Tot] from petugasJaga WHERE PETUGASJAGA.Jam1 BETWEEN '$pick_date' and '$date1' and Jaga LIKE '%INDUK%'");
   $P2=mssql_fetch_array($sP2);
   if(!$P2[Tot]=='0') { 
   echo ("<a href=#><img src=Images/Jaga1.gif width=29 height=28 border=0 onClick=MM_openBrWindow('listJaga.php?Pos=INDUK&Date=$pick_date','Edit','width=800,height=600') /></a>"); } 
   else echo ("<a href=#><img src=Images/Jaga2.gif width=29 height=28 border=0/></a>"); 
   ?></div>
<div id="Layer4">
<? $sP3=mssql_query("Select COUNT(NRP) as [Tot] from petugasJaga WHERE PETUGASJAGA.Jam1 BETWEEN '$pick_date' and '$date1' and Jaga LIKE '%HANDAK%'");
   $P3=mssql_fetch_array($sP3);
   if(!$P3[Tot]=='0') { 
   echo ("<a href=#><img src=Images/Jaga1.gif width=29 height=28 border=0 onClick=MM_openBrWindow('listJaga.php?Pos=HANDAK&Date=$pick_date','Edit','width=800,height=600') /></a>"); } 
   else echo ("<a href=#><img src=Images/Jaga2.gif width=29 height=28 border=0/></a>"); 
   ?></div>
<div id="Layer5">
<? $sP4=mssql_query("Select COUNT(NRP) as [Tot] from petugasJaga WHERE PETUGASJAGA.Jam1 BETWEEN '$pick_date' and '$date1' and Jaga LIKE '%Membangun%'");
   $P4=mssql_fetch_array($sP4);
   if(!$P4[Tot]=='0') { 
   echo ("<a href=#><img src=Images/Jaga1.gif width=29 height=28 border=0 onClick=MM_openBrWindow('listJaga.php?Pos=Membangun&Date=$pick_date','Edit','width=800,height=600') /></a>"); } 
   else echo ("<a href=#><img src=Images/Jaga2.gif width=29 height=28 border=0/></a>"); 
   ?></div>
<div id="Layer6">
<? $sP5=mssql_query("Select COUNT(NRP) as [Tot] from petugasJaga WHERE PETUGASJAGA.Jam1 BETWEEN '$pick_date' and '$date1' and Jaga LIKE '%Cabe%'");
   $P5=mssql_fetch_array($sP5);
   if(!$P5[Tot]=='0') { 
   echo ("<a href=#><img src=Images/Jaga1.gif width=29 height=28 border=0 onClick=MM_openBrWindow('listJaga.php?Pos=Cabe&Date=$pick_date','Edit','width=800,height=600') /></a>"); } 
   else echo ("<a href=#><img src=Images/Jaga2.gif width=29 height=28 border=0/></a>"); 
   ?></div>
<div id="Layer7">
<? $sP6=mssql_query("Select COUNT(NRP) as [Tot] from petugasJaga WHERE PETUGASJAGA.Jam1 BETWEEN '$pick_date' and '$date1' and Jaga LIKE '%Persada Utara%'");
   $P6=mssql_fetch_array($sP6);
   if(!$P6[Tot]=='0') { 
   echo ("<a href=#><img src=Images/Jaga1.gif width=29 height=28 border=0 onClick=MM_openBrWindow('listJaga.php?Pos=Utara','Edit','width=800,height=600') /></a>"); } 
   else echo ("<a href=#><img src=Images/Jaga2.gif width=29 height=28 border=0/></a>"); 
   ?></div>
<div id="Layer8">
<? $sP7=mssql_query("Select COUNT(NRP) as [Tot] from petugasJaga WHERE PETUGASJAGA.Jam1 BETWEEN '$pick_date' and '$date1' and Jaga LIKE '%Persada Selatan%'");
   $P7=mssql_fetch_array($sP7);
   if(!$P7[Tot]=='0') { 
   echo ("<a href=#><img src=Images/Jaga1.gif width=29 height=28 border=0 onClick=MM_openBrWindow('listJaga.php?Pos=Selatan&Date=$pick_date','Edit','width=800,height=600') /></a>"); } 
   else echo ("<a href=#><img src=Images/Jaga2.gif width=29 height=28 border=0/></a>"); 
   ?></div>
<div id="Layer9">
  <? $sP1=mssql_query("Select COUNT(NRP) as [Tot] from petugasJaga WHERE PETUGASJAGA.Jam1 BETWEEN '$pick_date' and '$date1' and Jaga LIKE '%TC%'");
   $P1=mssql_fetch_array($sP1);
   if(!$P1[Tot]=='0') { 
   echo ("<a href=#><img src=Images/Jaga1.gif width=29 height=28 border=0 onClick=MM_openBrWindow('listJaga.php?Pos=TC&Date=$pick_date','Edit','width=800,height=600') /></a>"); } 
   else echo ("<a href=#><img src=Images/Jaga2.gif width=29 height=28 border=0/></a>"); 
   ?>
</div>
<div id="Layer10">
  <? $sP1=mssql_query("Select COUNT(NRP) as [Tot] from petugasJaga WHERE PETUGASJAGA.Jam1 BETWEEN '$pick_date' and '$date1' and Jaga LIKE '%WS/BRE%'");
   $P1=mssql_fetch_array($sP1);
   if(!$P1[Tot]=='0') { 
   echo ("<a href=#><img src=Images/Jaga1.gif width=29 height=28 border=0 onClick=MM_openBrWindow('listJaga.php?Pos=WS/BRE&Date=$pick_date','Edit','width=800,height=600') /></a>"); } 
   else echo ("<a href=#><img src=Images/Jaga2.gif width=29 height=28 border=0/></a>"); 
   $mati=@mssql_close($koneksi);
   ?>
</div>
<table width="799" border="0" align="center" background="Images/MainPageBackground.jpg">
  <tr>
    <td width="793"><table width="100%" border="0" align="center">
      <tr>
        <td width="142"><a href="Utama.php"><img src="Images/police027.gif" width="100" height="150" border="0" /></a></td>
        <td width="526"><span><a href="http://www.dhtml-menu-builder.com"  style="display:none;visibility:hidden;">Javascript DHTML Drop Down Menu Powered by dhtml-menu-builder.com</a></span></td>
      </tr>
      <tr>
        <td height="401" colspan="2"><table width="100%" height="115%" border="1" class="ui-state-highlight">
          <tr>
            <td height="29"><form action="" method="get" name="form1" target="_self" id="form1">
              <p align="center">Tanggal :
                <label><span class="style3">
                <input name="pick_date" type="text" id="pick_date" value="<? if($pick_date==''){echo date('Y-m-d');} else echo $pick_date; ?>" size="12" />
                <input name="Button" type="button" style="background-image:url(Images/Calendar.png); background-repeat:no-repeat; background-position:center; border:none;" onclick="pick('pick_date');" value="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" />
                </span></label>
                <input type="submit" name="Submit" value="Go" />
              </p>
              </form></td>
          </tr>
          <tr>
            <td height="423" background="Images/Peta1.jpg">&nbsp;</td>
          </tr>
          <tr>
            <td height="658" background="Images/Peta2.jpg">&nbsp;</td>
          </tr>
        </table></td>
      </tr>
    </table></td>
  </tr>
</table>
</body>
</html>
