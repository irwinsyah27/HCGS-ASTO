<?
include("cek.php");
		require("tools/koneksi.php");
		// ----- hubungkan ke database
		$koneksi=open_connection();
		if ($pDate=='') {
		$pDate= date('Y/m/d');}

?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>SMS ALERT</title>
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
    <td width="110"><div align="center"><img src="../Images/Mirror-Be-Alert-Safety-Sign-S-6704.gif" width="110" height="122" /></div></td>
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
                    <option value="BRE" <?php if (!(strcmp("BRE", $lArea))) {echo "selected=\"selected\"";} ?>>BRE</option>
                    <option value="EBL" <?php if (!(strcmp("EBL", $lArea))) {echo "selected=\"selected\"";} ?>>EBL</option>
                    <option value="PERSADA" <?php if (!(strcmp("PERSADA", $lArea))) {echo "selected=\"selected\"";} ?>>PERSADA</option>
                    <option value="CABE" <?php if (!(strcmp("CABE", $lArea))) {echo "selected=\"selected\"";} ?>>CABE</option>
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
    <td class=ui-state-hover><div align=center onClick=MM_openBrWindow('tools/Insert.php','','status=yes,scrollbars=yes,width=931,height=190')><a href=#>New</a></div></td>
  </tr>
</table>
	<table width=80% border=0 bgcolor=#BBBBBB>
      <tr>
        <td width=3% bgcolor=#CCFF99 class=tHead><div align=center>No</div></td>
        <td width=10% bgcolor=#CCFF99 class=tHead><div align=center>Group_PIC</div></td>
        <td width=10% bgcolor=#CCFF99 class=tHead><div align=center>Nrp</div></td>
        <td width=55% bgcolor=#CCFF99 class=tHead><div align=center> Nama </div></td>
        <td width=10% bgcolor=#CCFF99 class=tHead><div align=center>Dept</div></td>
        <td width=10% bgcolor=#CCFF99 class=tHead><div align=center>Jabatan</div></td>
        <td width=10% bgcolor=#CCFF99 class=tHead><div align=center>Email</div></td>
        <td width=10% bgcolor=#CCFF99 class=tHead><div align=center>NoHP</div></td>
      </tr>");
$sPIC=mssql_query("SELECT ISNULL(dbo.tbl_PIC.Group_PIC,'&nbsp;') as Group_PIC, dbo.tbl_PIC.ref_PIC, Persis.dbo.tblLotusNotes.ID, Persis.dbo.tblLotusNotes.Nrp, Persis.dbo.tblLotusNotes.Nama, Persis.dbo.tblLotusNotes.Departemen, Persis.dbo.tblLotusNotes.Jabatan, Persis.dbo.tblLotusNotes.LotusNotes, Persis.dbo.tblLotusNotes.NoHP
FROM Persis.dbo.tblLotusNotes LEFT OUTER JOIN dbo.tbl_PIC ON Persis.dbo.tblLotusNotes.ID = dbo.tbl_PIC.ref_PIC  ORDER BY dbo.tbl_PIC.Group_PIC") or die ("Salah SQL!");
	  while ($row = mssql_fetch_object($sPIC))
	  {
		// ----- mengambil isi setiap kolom
		$No = $No + 1;
		$Group_PIC=$row->Group_PIC;
		$ID=$row->ID;
		$ref_PIC=$row->ref_PIC;
		$Nrp=$row->Nrp;
		$Nama=$row->Nama;
		$Departemen=$row->Departemen;
		$Jabatan=$row->Jabatan;
		$LotusNotes=$row->LotusNotes;
		$NoHP=$row->NoHP;
		echo("
      <tr> 
        <td bgcolor=#EEEEEE align=center>$No</td>
		<td bgcolor=#FFFF99 align=center><p onClick=MM_openBrWindow('tools/Edit.php?ID=$ID','','status=yes,scrollbars=yes,width=931,height=190')><a href=#>$Group_PIC</a></p></td>
        <td bgcolor=#EEEEEE align=center>$Nrp</td>
        <td bgcolor=#EEEEEE align=Justify>$Nama</td>
        <td bgcolor=#EEEEEE align=Justify>$Departemen</td>
        <td bgcolor=#EEEEEE align=Justify>$Jabatan</td>
        <td bgcolor=#EEEEEE align=Justify>$LotusNotes</td>
        <td bgcolor=#EEEEEE align=Justify>$NoHP</td>
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
          <td colspan="2"><div align="center" class="tHeadTittle">
              <div align="center" class="ui-widget-header"> <span class="style18">Group PIC :</span>
                  <?
			  echo ("<select name=sPIC class=ui-state-active id=sPIC onchange=document.forms[&quot;form1&quot;].hPIC.value=document.forms[&quot;form1&quot;].sPIC.value; >
			  <option value=- >-</option>");
			  $sCBG=mssql_query("Select Group_PIC from tbl_PIC group by Group_PIC");
  				while ($row = mssql_fetch_object($sCBG))
  				{
				$Group_PIC=$row->Group_PIC;
				echo("<option value=".$Group_PIC." >".$Group_PIC."</option>");
  				}
              echo ("</select>");
			  ?>
                  <span class="style18">Via :</span>
                  <select name="sVia" class="ui-state-active" id="sVia">
                    <option value="-" <?php if (!(strcmp("-", $sVia))) {echo "selected=\"selected\"";} ?>>-</option>
                    <option value="Email" <?php if (!(strcmp("Email", $sVia))) {echo "selected=\"selected\"";} ?>Email</option>
                    <option value="SMS" <?php if (!(strcmp("SMS", $sVia))) {echo "selected=\"selected\"";} ?>>SMS</option>
                  </select>
              </div></td>
        </tr>
        <tr>
          <td><div align="center"><a href="#"></a><a href="#"></a> <span class="style18">( Descr</span> ) </div>
              <div align="center"></div></td>
          <td><div align="center"><span class="style18">( Action </span>)</div></td>
        </tr>
        <tr>
          <td><div align="center">
              <textarea name="tDescr" cols="58" rows="10" class="ui-state-active" id="tDescr"></textarea>
          </div></td>
          <td><div align="center">
              <textarea name="tAction" cols="58" rows="10" class="ui-state-active" id="tAction"></textarea>
          </div></td>
        </tr>
        <tr>
          <td colspan="2"><div align="center">
              <p align="right" class="ui-state-hover">
                <input name="bKirim" type="submit" class="ui-state-hover" value="SEND" />
              </p>
          </div></td>
        </tr>
      </table>
      <? 
if (($bKirim=='SEND') and ($sVia=='SMS')) {
$insert="INSERT INTO tbl_Alert (Area, Descr, Action, PIC) VALUES('$lArea','$tDescr','$tAction','$hPIC')";
$hasil =@mssql_query ($insert) or die ("Terdapat Kesalahan Insert INSERT INTO tbl_Alert (Area, Descr, Action, PIC) VALUES('$lArea','$tDescr','$tAction','$sPIC')");
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
    <td width=40% class=ui-widget-header><div align=center>Desrc</div></td>
    <td width=40% class=ui-widget-header><div align=center>Action</div></td>
    <td width=10% class=ui-widget-header><div align=center>Nrp</div></td>
    <td width=20% class=ui-widget-header><div align=center>Nama</div></td>
    <td width=20% class=ui-widget-header><div align=center>Email</div></td>
    <td width=20% class=ui-widget-header><div align=center>NoHP</div></td>
  </tr>");
  $date2 =  $pDate.' 23:59:59.000';
$sC2=mssql_query("select Descr, Action, Group_PIC, Nrp, Nama, Departemen, Jabatan, LotusNotes, NoHP, Status, Area, CAST(CAST(DATEPART(Year, Waktu) AS varchar) + '/' + CAST(DATEPART(MONTH, Waktu) AS varchar) + '/' + CAST(DATEPART(Day, Waktu) AS varchar) + ' ' + CAST(DATEPART(HOUR, Waktu) AS varchar) + ':' + CAST(DATEPART(MINUTE, Waktu) AS varchar) + ':' + CAST(DATEPART(SECOND, Waktu) AS varchar) AS varchar) AS Waktu from vw_Alert where waktu BETWEEN '$pDate' and '$date2'") or die ("Terdapat kesalahan pada perintah SQL!");
while ($row = mssql_fetch_object($sC2))
{
		// ----- mengambil isi setiap kolom
		$nomor = $nomor + 1;
		$Area=$row->Area;
		$Descr=$row->Descr;
		$Action=$row->Action;
		$Group_PIC=$row->Group_PIC;
		$Nrp=$row->Nrp;
		$Nama=$row->Nama;
		$Departemen=$row->Departemen;
		$Jabatan=$row->Jabatan;
		$LotusNotes=$row->LotusNotes;
		$Waktu=$row->Waktu;
		$NoHP=$row->NoHP;
		echo ("
		<tr>
		<td align=Center class=ui-state-highlight>$nomor</td>");
		echo ("<td class=ui-state-highlight align=Justify>$Area</td>
		<td class=ui-state-highlight align=Justify>$Descr</td>
		<td class=ui-state-highlight align=Justify>$Action</td>
		<td class=ui-state-highlight align=Center>$Nrp</td>
		<td class=ui-state-highlight align=Center>$Nama</td>
		<td class=ui-state-highlight align=Justify>$LotusNotes</td>
		<td class=ui-state-highlight align=Justify>$NoHP</td></tr>");	
//$mati=@mssql_close($koneksi);
require("tools/koneksi2.php");
//$koneksi=open_connection();
$Text = 'AlertSHE;<'.$Area.'> '.$Descr.'-'.$Action;
/*$insert="INSERT INTO outbox (DestinationNumber, TextDecoded, SenderID)
		 VALUES ('$NoHP', '$Text', 'modemSHE')";*/
/*=============================================================================*/		 
// menghitung jumlah pecahan
$jmlSMS = ceil(strlen($Text)/153);
// memecah pesan asli
$pecah  = str_split($Text, 153);
// proses untuk mendapatkan ID record yang akan disisipkan ke tabel OUTBOX
$query = "SHOW TABLE STATUS LIKE 'outbox'";
$hasil = mysql_query($query);
$data  = mysql_fetch_array($hasil);
$newID = $data['Auto_increment'];
// proses penyimpanan ke tabel mysql untuk setiap pecahan
for ($i=1; $i<=$jmlSMS; $i++)
{
   // membuat UDH untuk setiap pecahan, sesuai urutannya
   $udh = "050003A7".sprintf("%02s", $jmlSMS).sprintf("%02s", $i);

   // membaca text setiap pecahan
   $msg = $pecah[$i-1];
   if ($i == 1)
   {
      // jika merupakan pecahan pertama, maka masukkan ke tabel OUTBOX
      $query = "INSERT INTO outbox (DestinationNumber, UDH, TextDecoded, ID, SenderID, MultiPart, CreatorID)
                VALUES ('$NoHP', '$udh', '$msg', '$newID', 'modemSHE', 'true', 'SHEA')";
   }
   else
   {
      // jika bukan merupakan pecahan pertama, simpan ke tabel OUTBOX_MULTIPART
      $query = "INSERT INTO outbox_multipart(UDH, TextDecoded, ID, SequencePosition)
                VALUES ('$udh', '$msg', '$newID', '$i')";
   }
   // jalankan query
   mysql_query($query) or die ("Terdapat Kesalahan Insert");
}
/*=============================================================================*/

//$hasil =@mysql_query ($insert) or die ("Terdapat Kesalahan INSERT INTO outbox (DestinationNumber, TextDecoded, SenderID) VALUES ('$NoHP', '$Text', 'modemSHE')");

$koneksi=open_connection();
$update="UPDATE tbl_Alert SET Status='true' WHERE Status='false'";
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
