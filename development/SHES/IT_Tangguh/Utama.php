<?
include("cek.php");
require("tools/koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();
if ($pDate=='') {
	$pDate= date('Y/m/d');
	}
	
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>SMS CCR Info</title>
	<link rel="stylesheet" href="../../Tools/themes/south-street/jquery.ui.all.css">
	<script src="../../Tools/jquery-1.5.1.js"></script>
	<script src="../../Tools/ui/jquery.ui.core.js"></script>
	<script src="../../Tools/ui/jquery.ui.widget.js"></script>
	<script src="../../Tools/ui/jquery.ui.datepicker.js"></script>
	<script src="../../Tools/external/jquery.bgiframe-2.1.2.js"></script>
	<script src="../../Tools/ui/jquery.ui.mouse.js"></script>
	<script src="../../Tools/ui/jquery.ui.draggable.js"></script>
	<script src="../../Tools/ui/jquery.ui.position.js"></script>
	<script src="../../Tools/ui/jquery.ui.resizable.js"></script>
	<script src="../../Tools/ui/jquery.ui.SdialogAlert.js"></script>
	<link rel="stylesheet" href="../../Tools/jQ.css">
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
.style18 {color: #005500}
.style26 {font-size: 6em}
-->
</style>
</head>
<body>
<table width="100%" border="0" align="center" background="Images/MainPageBackground.jpg">
  <tr>
    <td width="110"><div align="center"><img src="Images/CCRInfo.png" width="110" height="116" /></div></td>
    <td width="891"><div align="center"><a href="http://www.dhtml-menu-builder.com"  style="display:none;visibility:hidden;">Javascript DHTML Drop Down Menu Powered by dhtml-menu-builder.com</a><span class="ui-state-active style26">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></div></td>
  </tr>
  <tr>
    <td colspan="2"><form action="" method="post" name="form1" target="_self" id="form1">
      <table width="100%" border="1">
        <tr>
          <td width="50%"><div align="center" class="ui-widget-header">Tgl :
                <input name="pDate" type="text" class="ui-state-active" id="datepicker" onchange="this.form.submit()" value="<? if($pDate==''){echo date('Y/m/d');} else echo $pDate; ?>" size="15" />
          </div></td>
          <td width="50%"><div align="center" class="ui-widget-header"> <span class="style18">Lokasi :</span>
                  <select name="lArea" class="ui-state-active" id="lArea">
                    <option value="-" <?php if (!(strcmp("-", $lArea))) {echo "selected=\"selected\"";} ?>>-</option>
                    <option value="OFFICE" <?php if (!(strcmp("OFFICE", $lArea))) {echo "selected=\"selected\"";} ?>>OFFICE</option>
                  </select>
          </div></td>
        </tr>
      </table>
      <table width="100%" border="0">
        <tr>
          <td width="45%"><p align="center" class="ui-state-hover" id="opener1" ><strong><a href="#">List PIC</a> </strong></p></td>
        </tr>
        <tr>
          <td><div id="dialog1" title=" List PIC "> <? echo ("
	<table width=99%>
  <tr>
    <td class=ui-state-hover><div align=center ><a href=#>~</a></div></td>
  </tr>
</table>
	<table width=80% border=0 bgcolor=#BBBBBB>
      <tr>
        <td width=3% bgcolor=#CCFF99 class=tHead><div align=center>No</div></td>
        <td width=20% bgcolor=#CCFF99 class=tHead><div align=center>GroupPIC</div></td>
        <td width=55% bgcolor=#CCFF99 class=tHead><div align=center> Nama </div></td>
        <td width=20% bgcolor=#CCFF99 class=tHead><div align=center>Area</div></td>
        <td width=20% bgcolor=#CCFF99 class=tHead><div align=center>NoHP</div></td>
      </tr>");
$sPIC=mssql_query("SELECT * FROM tbl_PIC") or die ("Salah SQL!");
	  while ($row = mssql_fetch_object($sPIC))
	  {
		// ----- mengambil isi setiap kolom
		$No = $No + 1;
		$GroupPIC=$row->GroupPIC;
		$Id=$row->Id;
		$UserName=$row->UserName;
		$Area=$row->Area;
		$HP=$row->HP;
		echo("
      <tr> 
        <td bgcolor=#EEEEEE align=center>$No</td>
		<td bgcolor=#FFFF99 align=center><p onClick=MM_openBrWindow('tools/Edit.php?Id=$Id','','status=yes,scrollbars=yes,width=931,height=190')><a href=#>$GroupPIC</a></p></td>
        <td bgcolor=#EEEEEE align=Justify>$UserName</td>
        <td bgcolor=#EEEEEE align=Justify>$Area</td>
        <td bgcolor=#EEEEEE align=Justify>$HP</td>
      </tr>");
	  }
    echo("<tr>
        <td colspan=2 bgcolor=#EEEEEE align=center>Total</td>
        <td bgcolor=#EEEEEE align=center>$JNumberCm</td>
        <td bgcolor=#EEEEEE align=center>$JResultCm</td>
        <td bgcolor=#EEEEEE align=center></td></tr></table>
	"); ?> </div></td>
        </tr>
      </table>
      <table width="100%" border="0">
        <tr>
          <td><div align="center" class="tHeadTittle">
              <div align="center" class="ui-widget-header"> <span class="style18">Group PIC :</span>
                  <?
			  echo ("<select name=sPIC class=ui-state-active id=sPIC onchange=document.forms[&quot;form1&quot;].hPIC.value=document.forms[&quot;form1&quot;].sPIC.value; >
			  <option value=- >-</option>");
			  $sCBG=mssql_query("Select GroupPIC from tbl_PIC group by GroupPIC");
  				while ($row = mssql_fetch_object($sCBG))
  				{
				$GroupPIC=$row->GroupPIC;
				echo("<option value=".$GroupPIC." >".$GroupPIC."</option>");
  				}
              echo ("</select>");
			  ?>
                  <span class="style18">Via :</span>
                  <select name="sVia" class="ui-state-active" id="sVia">
                    <option value="-" <?php if (!(strcmp("-", $sVia))) {echo "selected=\"selected\"";} ?>>-</option>
                    <option value="SMS" <?php if (!(strcmp("SMS", $sVia))) {echo "selected=\"selected\"";} ?>>SMS</option>
                  </select>
              </div></td>
        </tr>
        <tr>
          <td><div align="center"><a href="#"></a><a href="#"></a> <span class="style18">( CCR Info </span> ) </div>
              <div align="center"></div>              <div align="center"></div></td>
          </tr>
        <tr>
          <td><div align="center">
              <textarea name="tDescr" cols="100" rows="10" class="ui-state-active" id="tDescr"></textarea>
          </div></td>
          </tr>
        <tr>
          <td><div align="center">
              <p align="right" class="ui-state-hover">
                <input name="bKirim" type="submit" class="ui-state-hover" value="SEND" />
              </p>
          </div></td>
        </tr>
      </table>
      <? 
if (($bKirim=='SEND') and ($sVia=='SMS')) {
$wahini = $pDate.' '.date('G:s:00');
$insert="INSERT INTO tbl_Info (Area, Descr, Action, PIC) VALUES('$lArea','$tDescr','..','$hPIC')";
$hasil =@mssql_query ($insert) or die ("Terdapat Kesalahan Insert INSERT INTO tbl_Info (Waktu, Area, Descr, Action, PIC) VALUES('$pDate','$lArea','$tDescr','..','$hPIC')");
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data Terkirim.!!'); </SCRIPT> </BODY>");
}
if (($bKirim=='SEND') and ($sVia=='LNotes')) {
//////////////
echo ("<BODY> <SCRIPT language='Javascript'> alert('Pengiriman Via LNotes Belum Selesai.!!'); </SCRIPT> </BODY>");
}
?>
      <?
echo ("
<table width=100% border=0 bgcolor=#DDDDDD>
  <tr>
    <td width=5% class=ui-widget-header><div align=center>No</div></td>
    <td width=15% class=ui-widget-header><div align=center>Area</div></td>
    <td width=40% class=ui-widget-header><div align=center>Waktu</div></td>
    <td width=10% class=ui-widget-header><div align=center>Desrc</div></td>
    <td width=20% class=ui-widget-header><div align=center>Nama</div></td>
    <td width=20% class=ui-widget-header><div align=center>NoHP</div></td>
  </tr>");
  $date2 =  $pDate.' 23:59:59.000';
$sC2=mssql_query("select Descr, GroupPIC, UserName, HP, Status, Area, CAST(CAST(DATEPART(Year, Waktu) AS varchar) + '/' + CAST(DATEPART(MONTH, Waktu) AS varchar) + '/' + CAST(DATEPART(Day, Waktu) AS varchar) + ' ' + CAST(DATEPART(HOUR, Waktu) AS varchar) + ':' + CAST(DATEPART(MINUTE, Waktu) AS varchar) + ':' + CAST(DATEPART(SECOND, Waktu) AS varchar) AS varchar) AS Waktu from v_CCRInfo where waktu BETWEEN '$pDate' and '$date2'") or die ("Terdapat kesalahan pada perintah SQL!");
while ($row = mssql_fetch_object($sC2))
{
		// ----- mengambil isi setiap kolom
		$nomor = $nomor + 1;
		$Area=$row->Area;
		$Descr=$row->Descr;
		$GroupPIC=$row->GroupPIC;
		$Nrp=$row->Nrp;
		$UserName=$row->UserName;
		$Waktu=$row->Waktu;
		$HP=$row->HP;
		echo ("
		<tr>
		<td align=Center class=ui-state-highlight>$nomor</td>");
		echo ("<td class=ui-state-highlight align=Justify>$Area</td>
		<td class=ui-state-highlight align=Justify>$Waktu</td>
		<td class=ui-state-highlight align=Justify>$Descr</td>
		<td class=ui-state-highlight align=Center>$UserName</td>
		<td class=ui-state-highlight align=Justify>$HP</td></tr>");	
//$mati=@mssql_close($koneksi);
require("tools/koneksi2.php");
//$koneksi=open_connection();
$Text = 'CCRInfo;'.$Descr.'-';
$insert="INSERT INTO Inbox (ReceivingDateTime, SenderNumber, Coding, TextDecoded, Processed) VALUES('$Waktu','$HP','Default_No_Compression','$Text','false')";
$hasil =@mysql_query ($insert) or die ("Terdapat Kesalahan Insert INSERT INTO Inbox (ReceivingDateTime, SenderNumber, Coding, TextDecoded, Processed) VALUES('$Waktu','$NoHP','Default_No_Compression','$Text','false')");

$koneksi=open_connection();
$update="UPDATE tbl_Info SET Status='true' WHERE Status='false'";
$hasil =@mssql_query ($update) or die ("Terdapat Kesalahan UPDATE tbl_Alert SET Status='true' WHERE Status='false'");


//$mati=@mysql_close($koneksi);
//$koneksi=open_connection();
		}
		echo ("
		<tr>
		<td colspan=3 class=ui-widget-header><div align=center>Total</div></td>
		<td>$TNumberCm</td>
		<td>$TResultCm</td>
		<td></td>
	  </tr>
	</table>");
$mati=@mssql_close($koneksi);
?>
      <input name="hPIC" type="hidden" id="hPIC" value="<? echo $hPIC; ?>" />
    </form></td>
  </tr>
</table>
</body>
</html>
