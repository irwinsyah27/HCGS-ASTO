<?
session_start();
//require("cek.php");
// ----- ambil isi dari file koneksi.php
require("../koneksi.php");
if($Dept=='HRPGA') {
// ----- hubungkan ke database
$koneksi=open_connection();
?><head>
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
</head>
<form method="post" name="form1" target="_self">
  <div align="center">
    <p>&nbsp;    </p>
    <table width="100%" border="0">
      <tr>
        <td><div align="center">
          <input name="bInsert" type="submit" id="bInsert" value="Insert" />
          <input name="bCancel" type="submit" id="bCancel" value="Cancel" />
        </div></td>
      </tr>
      <tr>
        <td><? 
if(!$bInsert==''){
echo ("
<table width=100% border=0 bgcolor=#DDDDDD>
  <tr>
    <td colspan=4><div align=center><strong>Form insert </strong></div></td>
  </tr>
  <tr>
    <td>Case :</td>
    <td><textarea name=tComplaint cols=45 rows=5 class=ui-widget-content ></textarea></td>
    <td>Remarks :</td>
    <td><textarea name=tRemark cols=45 rows=5 class=ui-widget-content ></textarea></td>
  </tr>
  <tr>
    <td>Number</td>
    <td>:
      <input name=tNumber type=text class=ui-widget-content size=57  />    </td>
    <td>Result</td>
    <td>:<strong>
      <input name=tResult type=text class=ui-widget-content size=57  />
    </strong></td>
  </tr>
  <tr>
    <td colspan=4><div align=center class=ui-widget-content>
      <input type=submit name=bSimpanIn value=Simpan />
    </div></td>
  </tr>
</table>
<table width=100% border=0>
  <tr>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td>");
}
if(!$bEdit==''){
$Sel1 = mysql_query ("Select * from C2 where NoC2='$bEdit'") or die ("Terdapat kesalahan Update!");
$dEd = mysql_fetch_array($Sel1);
echo ("
<input type=hidden name=uNoInfo value='$bEdit'>
<table width=100% border=0 bgcolor=#DDDDDD>
  <tr>
    <td colspan=4><div align=center><strong>Form edit </strong></div></td>
  </tr>
  <tr>
    <td>Keterangan :</td>
    <td><textarea name=tKeterangan cols=45 rows=5 class=ui-widget-content >$dEd[Keterangan]</textarea></td>
    <td>Attach.. :</td>
    <td><textarea name=tFileD cols=45 rows=5 class=ui-widget-content >$dEd[FileD]</textarea></td>
  </tr>
  <tr>
    <td colspan=4><div align=center class=ui-widget-content>
      <input type=submit name=bSimpan value=Simpan />
    </div></td>
  </tr>
</table>
<table width=100% border=0>
  <tr>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td>");
}
?>
          <?
echo ("
<table width=100% border=0 bgcolor=#DDDDDD>
  <tr>
    <td width=5% class=ui-widget-header><div align=center>Tools</div></td>
    <td width=5% class=ui-widget-header><div align=center>No</div></td>
    <td width=40% class=ui-widget-header><div align=center>Information</div></td>
    <td width=10% class=ui-widget-header><div align=center>Attach..</div></td>
  </tr>");
$sC2=mysql_query("select Information.*, Departemen.NamaDept, Departemen.DeptHead, date(now()) as tglskrg, date(now())-date(DailyMeeting.tglupdate) as updateby, DailyMeeting.tglupdate,DailyMeeting.userupdate from DailyMeeting, Information, Departemen where DailyMeeting.NoDept=Departemen.NoDept and DailyMeeting.NoDept=Information.NoDept and Departemen.NamaDept='HRPGA'
GROUP BY Information.NoINfo") or die ("Terdapat kesalahan pada perintah SQL!");
while ($row = mysql_fetch_object($sC2))
{
		// ----- mengambil isi setiap kolom
		$nomor = $nomor + 1;
		$Keterangan=$row->Keterangan;
		$NamaDept=$row->NamaDept;
		$FileD=$row->FileD;
		echo ("
		<tr>
		<td><div align=center class=ui-widget-content><button class=ui-accordion type=submit name=bEdit onClick=value='$NoInfo' >edit</button></div></td>
		<td align=Center>$nomor</td>");
		echo ("
		<td align=Center>$nomor</td>
		<td bgcolor=#FFFF99 align=Justify>$Keterangan</td>
		<td align=Center>$FileD</td>
	  </tr>
	</table>");
?></td>
      </tr>
    </table>
  </div>
</form>

<?
if($bSimpan=='Simpan') {
$update="UPDATE Information SET Keterangan='$tComplaint',FileD='$tNumber' WHERE NoInfo='$uNoInfo'";
// ------ jalankan perintah SQL untuk memasukkan data ke tabel PKH
$hasil =@mysql_query ($update) or die ("Terdapat Kesalahan SQL");
// ------ putus hubungan dengan database
mysql_close($koneksi);
echo ("<BODY> 
<SCRIPT language='Javascript'> 
alert('Data Sudah Masuk');
this.form.submit();
</SCRIPT> 
</BODY>"); }
}
if($bSimpanIn=='Simpan') {
$data1 = mysql_query ("select NoDept, (SELECT date(now()))as jam from Departemen where NamaDept='$Dept'");
$dDept=mysql_fetch_array($data1);
$insert="INSERT INTO Information (NoDept,Keterangan,FileD) VALUES('$dDept[NoDept]','$tKeterangan','$tFileD')";
// ------ jalankan perintah SQL untuk memasukkan data ke tabel PKH
$hasil =@mysql_query ($insert) or die ("Terdapat Kesalahan SQL");
// ------ putus hubungan dengan database
mysql_close($koneksi);
echo ("<BODY> 
<SCRIPT language='Javascript'> 
alert('Data Sudah Masuk');
this.form.submit();
</SCRIPT> 
</BODY>"); }
?>
