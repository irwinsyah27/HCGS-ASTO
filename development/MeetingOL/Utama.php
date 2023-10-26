<?
session_start();
//require("cek.php");
// ----- ambil isi dari file koneksi.php
//require("tools/koneksi.php");
// ----- hubungkan ke database
//$koneksi=open_connection();
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
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
<title>Untitled Document</title>
<STYLE type=text/css>BODY {
	PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; FONT: 10px/1.8em Verdana, Arial, Helvetica, sans-serif; BACKGROUND: url(bg.jpg) #1d1d1d; PADDING-TOP: 0px
}
H1 {
	TEXT-ALIGN: center; PADDING-BOTTOM: 20px; LINE-HEIGHT: 1.2em; MARGIN: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; FONT-FAMILY: Georgia, "Times New Roman", Times, serif; FONT-SIZE: 4em; FONT-WEIGHT: normal; PADDING-TOP: 20px
}
H1 SMALL {
	DISPLAY: block; COLOR: #999; FONT-SIZE: 0.5em
}
IMG {
	BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none
}
UL.columns {
	PADDING-BOTTOM: 0px; LIST-STYLE-TYPE: none; MARGIN: 0px auto; PADDING-LEFT: 0px; WIDTH: 960px; PADDING-RIGHT: 0px; PADDING-TOP: 0px
}
UL.columns LI {
	POSITION: relative; PADDING-BOTTOM: 0px; MARGIN: 10px; PADDING-LEFT: 0px; WIDTH: 220px; PADDING-RIGHT: 0px; DISPLAY: inline; FLOAT: left; PADDING-TOP: 0px
}
UL.columns LI:hover {
	Z-INDEX: 99
}
UL.columns LI IMG {
	POSITION: relative; FILTER: alpha(opacity=30); opacity: 0.3
}
UL.columns LI:hover IMG {
	Z-INDEX: 999; FILTER: alpha(opacity=100); opacity: 1
}
UL.columns LI .info {
	POSITION: absolute; PADDING-BOTTOM: 20px; PADDING-LEFT: 10px; WIDTH: 220px; PADDING-RIGHT: 10px; DISPLAY: none; BACKGROUND: #fff; FONT-SIZE: 1.2em; TOP: -10px; PADDING-TOP: 210px; LEFT: -10px; -webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px
}
UL.columns LI:hover .info {
	DISPLAY: block
}
UL.columns LI H2 {
	PADDING-BOTTOM: 10px; TEXT-TRANSFORM: uppercase; MARGIN: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; FONT-SIZE: 1.2em; FONT-WEIGHT: normal; PADDING-TOP: 10px
}
UL.columns LI P {
	PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; FONT-SIZE: 0.9em; PADDING-TOP: 0px
}
</STYLE>
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
	left:105px;
	top:374px;
	width:28px;
	height:27px;
	z-index:1;
}
#Layer2 {
	position:absolute;
	left:359px;
	top:47px;
	width:392px;
	height:46px;
	z-index:2;
}
#Layer3 {
	position:absolute;
	left:492px;
	top:547px;
	width:26px;
	height:25px;
	z-index:3;
}
#Layer4 {
	position:absolute;
	left:770px;
	top:282px;
	width:16px;
	height:20px;
	z-index:4;
}
#Layer5 {
	position:absolute;
	left:775px;
	top:625px;
	width:19px;
	height:20px;
	z-index:5;
}
#Layer6 {
	position:absolute;
	left:379px;
	top:827px;
	width:26px;
	height:27px;
	z-index:6;
}
#Layer7 {
	position:absolute;
	left:390px;
	top:1085px;
	width:22px;
	height:28px;
	z-index:7;
}
#Layer8 {
	position:absolute;
	left:330px;
	top:1180px;
	width:26px;
	height:24px;
	z-index:8;
}
#Layer9 {
	position:absolute;
	left:574px;
	top:450px;
	width:18px;
	height:21px;
	z-index:9;
}
#Layer10 {
	position:absolute;
	left:609px;
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
<META name=GENERATOR content="MSHTML 8.00.7600.16588"></HEAD>
<BODY>
<H1><A style="COLOR: #fff; TEXT-DECORATION: none" 
href="Utama"></A> <SMALL class="ui-state-hover"><A style="COLOR: #999" 
href="http://www.sohtanaka.com/"></A><a style="COLOR: #fff; TEXT-DECORATION: none" 
href="Utama">Reports Meeting </a></SMALL></H1>
<UL class=columns>
  <LI><A href="Utama"><IMG 
  src="Images/kosong.gif" alt="" width="220" height="200" border="0" ></A> 

  <DIV class=info>
  <H2>InBuilding</H2>
  <P>Kosong. . . . . </P></DIV></LI>
  <LI><A href="Utama"><IMG 
  src="Images/DailyMeeting.png" alt="DailyMeeting" width="220" height="200" onclick="MM_openBrWindow('DailyMeeting/Cek.php','MenuAlert','status=yes,scrollbars=yes,width=1000,height=700')"></A> 

  <DIV class=info>
  <H2 align="center" class="ui-state-active">Daily Meeting</H2>
  <P>Meeting Level Management. . </P></DIV></LI>
  <LI>
  
  <A href="Utama"><IMG 
  src="Images/PKH.png" 
  alt="Perintah Kerja Harian" width="220" height="200" onclick="MM_openBrWindow('PKH/Cek.php','MenuAlert','status=yes,scrollbars=yes,width=1000,height=700')"></A>

  <DIV class=info>
  <H2 align="center" class="ui-state-active">KPH Meeting</H2>
  <P>Meeting Level Dept Head - GroupLeader </P></DIV></LI>
  <LI><A href="Utama"><IMG 
  src="Images/kosong.gif" 
  alt="" width="220" height="200"></A> 

  <DIV class=info>
  <H2>InBuilding</H2>
  <P>Kosong. . . . . </P></DIV></LI>
  <LI><A href="Utama"><IMG 
  src="Images/kosong.gif" 
  alt="" width="220" height="200"></A> 

  <DIV class=info>
  <H2>InBuilding</H2>
  <P>Kosong. . . . . </P></DIV></LI>
  <LI><A href="Utama"><IMG 
  src="Images/kosong.gif" 
  alt="" width="220" height="200"></A> 

  <DIV class=info>
  <H2>InBuilding</H2>
  <P>Kosong. . . . . </P></DIV></LI>
  <LI><A href="Utama"><IMG 
  src="Images/kosong.gif" 
  alt="" width="220" height="200"></A> 
  
  <DIV class=info>
  <H2>InBuilding</H2>
  <P>Kosong. . . . . </P></DIV></LI>
  <LI><A href="Utama"><IMG 
  src="Images/kosong.gif" 
  alt="" width="220" height="200"></A> 
</UL>
<p>&nbsp;</p>
<p>&nbsp;</p>
</BODY></HTML> 

</body>
</html>
