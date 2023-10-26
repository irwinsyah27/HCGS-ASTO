<?
session_start();
//require("cek.php");
// ----- ambil isi dari file koneksi.php
require("../koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();
?>
<?php
    function rupiah($uang)
    { if(!$uang=='') {
    $rupiah = 'Rp '.number_format($uang , 0 , ',' , '.' );
	return $rupiah;
	}
    }
	
	function persent($dat1,$dat2)
	{ if(!$dat1=='') {
	$persent = round(($dat2/$dat1)*100, 2).' %';
	return $persent;
	}
	}
	
	function persent2($dat1,$dat2)
	{  if(!$dat1=='') {
	$persent2 = 100 - round(($dat2/$dat1)*100, 2).' %';
	return $persent2;
	}
	}
?>
<html>
<head>
<title>Daily Meeting</title>
	<link rel="stylesheet" href="../../../Tools/themes/south-street/jquery.ui.all.css">
	<script src="../../../Tools/jquery-1.5.1.js"></script>
	<script src="../../../Tools/ui/jquery.ui.core.js"></script>
	<script src="../../../Tools/ui/jquery.ui.widget.js"></script>
	<script src="../../../Tools/ui/jquery.ui.datepicker.js"></script>
	<script src="../../../Tools/external/jquery.bgiframe-2.1.2.js"></script>
	<script src="../../../Tools/ui/jquery.ui.mouse.js"></script>
	<script src="../../../Tools/ui/jquery.ui.draggable.js"></script>
	<script src="../../../Tools/ui/jquery.ui.position.js"></script>
	<script src="../../../Tools/ui/jquery.ui.resizable.js"></script>
	<script src="../../../Tools/ui/jquery.ui.Sdialog.js"></script>
	<link rel="stylesheet" href="../../../Tools/jQ.css">
	<script>
	// increase the default animation speed to exaggerate the effect
	$.fx.speeds._default = 2000;
	$(function() {
		$( "#dialog1" ).dialog({
			autoOpen: false,
			show: "Scale",
			hide: "Scale"
		});

		$( "#opener1" ).click(function() {
			$( "#dialog1" ).dialog( "open" );
			return false;
		});
		
		$( "#dialog2" ).dialog({
			autoOpen: false,
			show: "blind",
			hide: "explode"
		});

		$( "#opener2" ).click(function() {
			$( "#dialog2" ).dialog( "open" );
			return false;
		});
	});
	
	$(function() {
		$( "#datepicker" ).datepicker();
	});
	
	function MM_openBrWindow(theURL,winName,features) { //v2.0
 	window.open(theURL,winName,features);
	}
	
	</script>
<script type="text/javascript" src="stmenu.js"></script>
<style type="text/css">
<!--
.style17 {font-size: 2em}
-->
</style>
</head>
<body>

<div id="dialog1" title="Complaint Comdev">
	<? echo ("
	<table width=80% border=0 bgcolor=#BBBBBB>
      <tr>
        <td width=3% bgcolor=#CCFF99 class=tHead><div align=center>No</div></td>
        <td width=25% bgcolor=#CCFF99 class=tHead><div align=center>Complaint</div></td>
        <td width=10% bgcolor=#CCFF99 class=tHead><div align=center>Number</div></td>
        <td width=10% bgcolor=#CCFF99 class=tHead><div align=center>Result</div></td>
        <td width=25% bgcolor=#CCFF99 class=tHead><div align=center>Remarks</div></td>
      </tr>");
$sCM=mysql_query("select C2.* from DailyMeeting, C2, Departemen where DailyMeeting.NoDept=Departemen.NoDept and DailyMeeting.NoDept=C2.NoDept and Departemen.NamaDept='HRPGA' and DailyMeeting.TglDM ='$pDate' and Tipe='CM'") or die ("Salah SQL!");
	  while ($row = mysql_fetch_object($sCM))
	  {
		// ----- mengambil isi setiap kolom
		$No1 = $No1 + 1;
		$Complaint=$row->Complaint;
		$NumberCm=$row->NumberCm;
		$ResultCm=$row->ResultCm;
		$Remark=$row->Remark;
		echo("
      <tr>
        <td bgcolor=#EEEEEE align=center>$No1</td>");
		if($NumberCm!=$ResultCm) {
		echo ("<td bgcolor=#FFFF99 align=Justify>$Complaint</td>"); } else {
		echo ("<td bgcolor=#CCFF99 align=Justify>$Complaint</td>"); }
		echo ("
        <td bgcolor=#EEEEEE align=center>$NumberCm</td>
        <td bgcolor=#EEEEEE align=center>$ResultCm</td>
        <td bgcolor=#EEEEEE align=Justify>$Remark</td>
      </tr>");
	  }
    echo("<tr>
        <td colspan=2 bgcolor=#EEEEEE align=center>Total</td>
        <td bgcolor=#EEEEEE align=center>$JNumberCm</td>
        <td bgcolor=#EEEEEE align=center>$JResultCm</td>
        <td bgcolor=#EEEEEE align=center></td></tr></table>
	"); ?></div>
<div id="dialog2" title="Case Internal & External">
	<? echo ("
	<table width=80% border=0 bgcolor=#BBBBBB>
      <tr>
        <td width=3% bgcolor=#CCFF99 class=tHead><div align=center>No</div></td>
        <td width=25% bgcolor=#CCFF99 class=tHead><div align=center>Case</div></td>
        <td width=10% bgcolor=#CCFF99 class=tHead><div align=center>Number</div></td>
        <td width=10% bgcolor=#CCFF99 class=tHead><div align=center>Result</div></td>
        <td width=25% bgcolor=#CCFF99 class=tHead><div align=center>Remarks</div></td>
      </tr>");
$sC=mysql_query("select C2.* from DailyMeeting, C2, Departemen where DailyMeeting.NoDept=Departemen.NoDept and DailyMeeting.NoDept=C2.NoDept and Departemen.NamaDept='HRPGA' and DailyMeeting.TglDM ='$pDate' and Tipe='C'") or die ("Salah SQL!");	  
	  while ($row = mysql_fetch_object($sC))
	  {
		// ----- mengambil isi setiap kolom
		$No2 = $No2 + 1;
		$Complaint=$row->Complaint;
		$NumberC=$row->NumberC;
		$ResultC=$row->ResultC;
		$Remark=$row->Remark;
		echo("
      <tr>
        <td bgcolor=#EEEEEE align=center>$No2</td>
        <td bgcolor=#EEEEEE align=center>$Complaint</td>
        <td bgcolor=#EEEEEE align=center>$NumberC</td>
        <td bgcolor=#EEEEEE align=center>$ResultC</td>
        <td bgcolor=#EEEEEE align=Justify>$Remark</td>
      </tr>");
	  }
    echo("<tr>
        <td colspan=2 bgcolor=#EEEEEE align=center>Total</td>
        <td bgcolor=#EEEEEE align=center>$JNumberC</td>
        <td bgcolor=#EEEEEE align=center>$JResultC</td>
        <td bgcolor=#EEEEEE align=center></td></tr></table>
	"); ?></div>

<form action="" method="post" name="form1" target="_self">
  <table width="100%" border="0">
    <tr>
      <td height="71"><div align="center">
	  <p align="center" class="ui-widget-header style17">Dept. HRPGA
	  <p align="center" class="ui-widget-header">Tgl :
          <input name="pDate" type="text" id="datepicker" onChange="this.form.submit()" value="<? if($pDate==''){echo date('Y/m/d');} else echo $pDate; ?>" size="15">
    </tr>
    <tr>
      <td><?
	// ----- SQL data PKH
	if ($Pesan=='') {
	$sDailyMeeting=mysql_query("select DailyMeeting.*, SUM(C2.ResultC) as ResultC, SUM(C2.NumberC) as NumberC, SUM(C2.ResultCm) as ResultCm, SUM(C2.NumberCm) as NumberCm, Departemen.NamaDept, Departemen.DeptHead, date(now()) as tglskrg, date(now())-date(DailyMeeting.tglupdate) as updateby, DailyMeeting.tglupdate,DailyMeeting.userupdate from DailyMeeting, C2, Departemen where DailyMeeting.NoDept=Departemen.NoDept and DailyMeeting.NoDept=C2.NoDept and Departemen.NamaDept='HRPGA' and DailyMeeting.TglDM ='$pDate' group by NoDept")
	or die ("Terdapat kesalahan pada perintah SQL Utama!"); } else {
	$sDailyMeeting=mysql_query("select DailyMeeting.*, SUM(C2.Result) as Result, SUM(C2.Number) as Number, Departemen.NamaDept, Departemen.DeptHead, date(now()) as tglskrg, date(now())-date(DailyMeeting.tglupdate) as updateby, DailyMeeting.tglupdate,DailyMeeting.userupdate from DailyMeeting, C2, Departemen where DailyMeeting.NoDept=Departemen.NoDept and DailyMeeting.NoDept=C2.NoDept and Departemen.NamaDept='HRPGA' and DailyMeeting.TglDM ='$pDate' group by NoDept")
	or die ("Terdapat kesalahan pada perintah SQL 1!"); 
	require("../../Tools/config.php");
	//set sudah dibaca = Y kalau sudah dibaca
	$update = mysql_query("UPDATE tabel_pesan SET sudahbaca='Y'
	WHERE nomor='$noPesan' AND kepada='$_SESSION[NamaSec]'"); }

	// ------ ambil isi masing-masing record
	$row = mysql_fetch_object($sDailyMeeting);
		// ----- mengambil isi setiap kolom
		$NoDM=$row->NoDM;
		$TglDM=$row->TglDM;
		$Items=$row->Items;
		$Plant1=rupiah($row->Plan1);
		$Plant2=rupiah($row->Plan2);
		$Plant3=rupiah($row->Plan3);
		$Actual1=rupiah($row->Actual1);
		$Actual2=rupiah($row->Actual2);
		$Actual3=rupiah($row->Actual3);
		$Tage1=persent($row->Plan1, $row->Actual1);
		$Tage2=persent($row->Plan2, $row->Actual2);
		$Tage3=persent($row->Plan3, $row->Actual3);
		$Remark1=$row->Remark1;
		$Remark2=$row->Remark2;
		$Remark3=$row->Remark3;
		$Sakit=$row->Sakit;
		$Izin=$row->Izin;
		$Alpha=$row->Alpha;
		$Tage4=persent2($row->MPP, $Sakit + $Izin + $Alpha);
		$Information=$row->Information;
		$Target=$row->Target;
		$Remarks=$row->Remarks;
		$NumberC=$row->NumberC;
		$ResultC=$row->ResultC;
		$NumberCm=$row->NumberCm;
		$ResultCm=$row->ResultCm;
		$FileA=$row->FileA;
		$FileB=$row->FileB;
		$FileC=$row->FileC;
		$FileD=$row->FileD;
		$userupdate=$row->userupdate;
		$tglskrg=$row->tglskrg;
		$tglupdate=$row->tglupdate;
		$updateby=$row->updateby;
	?>
          <? echo ("
<table width=100% border=0 bgcolor=#BBBBBB>
  <tr>
    <td width=5% rowspan=4 bgcolor=#CCFF99><div align=center class=ui-state-hover><a href=# class=tHead2 onClick=MM_openBrWindow('../Tool/Insert.php?pTgl=$pDate','Insert','width=1000,height=200')>A</a></div></td>
    <td width=30% bgcolor=#CCFF99><div align=center class=tHead>Overhead Cost</div></td>
    <td width=15% bgcolor=#CCFF99 class=tHead><div align=center>PLAN (RP)</div></td>
    <td width=15% bgcolor=#CCFF99 class=tHead><div align=center>ACTUAL (RP)</div></td>
    <td width=10% bgcolor=#CCFF99 class=tHead><div align=center>% TAGE</div></td>
    <td width=14% bgcolor=#CCFF99 class=tHead><div align=center>REMARKS</div></td>
    <td width=9% bgcolor=#CCFF99 class=tHead><div align=center >Attach..</div></td>
  </tr>
  <tr>
    <td bgcolor=#EEEEEE>Transportation (IBS)</td>
    <td bgcolor=#EEEEEE align=Right>$Plant1 </td>
    <td bgcolor=#EEEEEE align=Right>$Actual1 </td>
    <td bgcolor=#EEEEEE align=Right>$Tage1 </td>
    <td bgcolor=#EEEEEE>$Remark1 </td>
    <td rowspan=3 bgcolor=#EEEEEE align=Center><button id=lnk1 onClick=MM_openBrWindow('../HRPGA/lampiranData/A/$FileA','File','width=1000,height=800')>Attach</button></td>
  </tr>
  <tr>
    <td bgcolor=#EEEEEE>Overhead Cost (IBS)</td>
    <td bgcolor=#EEEEEE align=Right>$Plant2 </td>
    <td bgcolor=#EEEEEE align=Right>$Actual2</td>
    <td bgcolor=#EEEEEE align=Right>$Tage2 </td>
    <td bgcolor=#EEEEEE >$Remark2 </td>
  </tr>
  <tr>
    <td bgcolor=#EEEEEE>O/H Cost (??)</td>
    <td bgcolor=#EEEEEE align=Right>$Plant3 </td>
    <td bgcolor=#EEEEEE align=Right>$Actual3 </td>
    <td bgcolor=#EEEEEE align=Right>$Tage3 </td>
    <td bgcolor=#EEEEEE>$Remark3 </td>
  </tr>
  <tr>
    <td colspan=7 bgcolor=#FFFFFF><div align=center>-</div></td>
  </tr>
  <tr>
    <td rowspan=2 bgcolor=#CCFF99><div align=center class=ui-state-hover><a href=# class=tHead2 onClick=MM_openBrWindow('../Tool/Insert2.php?NoDM=$NoDM','Insert','width=900,height=220')>B</a></div></td>
    <td bgcolor=#CCFF99 class=tHead><div align=center>Man Power</div></td>
    <td bgcolor=#CCFF99 class=tHead><div align=center>% TAGE</div></td>
    <td bgcolor=#CCFF99 class=tHead><div align=center>SAKIT</div></td>
    <td bgcolor=#CCFF99 class=tHead><div align=center>IZIN</div></td>
    <td bgcolor=#CCFF99 class=tHead><div align=center>ALPHA</div></td>
    <td width=9% bgcolor=#CCFF99 class=tHead><div align=center>Attach..</div></td>
  </tr>
  <tr>
    <td bgcolor=#EEEEEE>Attendace Ratio</td>
    <td bgcolor=#EEEEEE align=Center>$Tage4 </td>
    <td bgcolor=#EEEEEE align=Center>$Sakit </td>
    <td bgcolor=#EEEEEE align=Center>$Izin </td>
    <td bgcolor=#EEEEEE align=Center>$Alpha </td>
    <td bgcolor=#EEEEEE align=Center><button id=lnk2 onClick=MM_openBrWindow('../HRPGA/lampiranData/B/$FileB','File','width=1000,height=800')>Attach</button></td>
  </tr>
  <tr>
    <td colspan=7 bgcolor=#FFFFFF><div align=center>-</div></td>
  </tr>
  <tr>
    <td bgcolor=#CCFF99><div align=center class=ui-state-hover><a href=# class=tHead2 onClick=MM_openBrWindow('../Tool/ComdevIn.php?Dept=HRPGA','Insert','resizable=yes,,scrollbars=yes,width=1000,height=700')>C</a></div></td>
    <td bgcolor=#CCFF99 class=tHead><div align=center>Complaint Comdev</div></td>
    <td bgcolor=#FFCCFF class=tHead><div align=center>OPEN</div></td>
	<td bgcolor=#EEEEEE align=Center>$NumberCm </td>
    <td bgcolor=#CCFFFF class=tHead><div align=center>CLOSE</div></td>
    <td bgcolor=#EEEEEE align=Center>$ResultCm </td>
    <td bgcolor=#CCFF99 class=tHead><div align=center><button id=opener1>Attach</button></div></td>
  </tr>
  <tr>
    <td colspan=7 bgcolor=#FFFFFF><div align=center>-</div></td>
  </tr>
  <tr>
    <td bgcolor=#CCFF99><div align=center class=ui-state-hover><a href=# class=tHead2 onClick=MM_openBrWindow('../Tool/CaseIn.php?Dept=HRPGA','Insert','resizable=yes,,scrollbars=yes,width=1000,height=500')>D</a></div></td>
    <td bgcolor=#CCFF99 class=tHead><div align=center>Case Internal &amp; External</div></td>
    <td bgcolor=#FFCCFF class=tHead><div align=center>OPEN</div></td>
	<td bgcolor=#EEEEEE align=Center>$NumberC </td>
    <td bgcolor=#CCFFFF class=tHead><div align=center>CLOSE</div></td>
    <td bgcolor=#EEEEEE align=Center>$ResultC </td>
    <td bgcolor=#CCFF99 class=tHead><div align=center><button id=opener2>Attach</button></div></td>
  </tr>
  <tr>
    <td colspan=7 bgcolor=#FFFFFF><div align=center>-</div></td>
  </tr>
  <tr>
    <td rowspan=10 bgcolor=#CCFF99><div align=center class=ui-state-hover><a href=# class=tHead2 onClick=MM_openBrWindow('../Tool/Information.php?Dept=HRPGA','Insert','width=1000,height=600')>E</a></div></td>
    <td colspan=5 bgcolor=#CCFF99 class=tHead><div align=center>Information</div></td>
    <td width=9% bgcolor=#CCFF99 class=tHead><div align=center>Attach..</div></td>
  </tr>");
$sC2=mysql_query("select Information.*, Departemen.NamaDept, Departemen.DeptHead, date(now()) as tglskrg, date(now())-date(DailyMeeting.tglupdate) as updateby, DailyMeeting.tglupdate,DailyMeeting.userupdate from DailyMeeting, Information, Departemen where DailyMeeting.NoDept=Departemen.NoDept and DailyMeeting.NoDept=Information.NoDept and Departemen.NamaDept='HRPGA' AND Information.OnDelete=0 GROUP BY Information.NoINfo") or die ("Terdapat kesalahan pada perintah SQL 2!");
while ($row = mysql_fetch_object($sC2))
{
		// ----- mengambil isi setiap kolom
		$nomor = $nomor + 1;
		$NoInfo=$row->NoInfo;
		$Keterangan=$row->Keterangan;
		$NamaDept=$row->NamaDept;
		$FileE=$row->FileE;
		echo ("
  <tr>
    <td colspan=5 bgcolor=#EEEEEE><li>$Keterangan </td>
    <td bgcolor=#EEEEEE align=Center><button id=lnk3 onClick=MM_openBrWindow('../HRPGA/lampiranData/E/$FileE','File','width=1000,height=800')>Attach</button></td>
  </tr>"); 
  } echo("
  <tr>
    <td colspan=7 bgcolor=#FFFFFF><div align=center>-</div></td>
  </tr>
  <tr>
    <td colspan=7 bgcolor=#BBBBBB><div align=center class=tHead>
      <div align=right></div>
    </div></td>
  </tr>
</table>
");
mysql_close($koneksi);
?></td>
    </tr>
  </table>
</form>
		
		
</body>
</html>