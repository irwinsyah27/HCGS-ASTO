<script type="text/javascript">
function voting(){
	
		alert('Terima Kasih Anda telah mengikuti Voting');
		return false;
	
}
</script>


<?
if (isset($_POST['polling']))
{
	include "conn.php";
	$pilihan=$_POST['polling'];
	$tanggal;
	
	$polling=mysql_db_query($db,"select * from voting",$koneksi);
	$baris=mysql_fetch_row($polling);
	list($bagus,$jelek,$tidaktahu)=$baris; //fungsi list untuk menampung nilai dari field2 di database ke dalah sebuah variabel. dan variabelnya harus berurutan 
	
	/*penjumlahan*/
	$array1=$bagus+1;
	$array2=$jelek+1;
	$array3=$tidaktahu+1;
	
	switch($pilihan)
	{
	case "bagus";
		echo "<br>";
		$update=mysql_db_query($db,"update voting set bagus='$array1', waktu='$tanggal'",$koneksi);
		echo "<script> document.location.href='voting.php'; </script>";
		break;
		
	case "jelek";
		echo "<br>";
		$update=mysql_db_query($db,"update voting set jelek='$array2', waktu='$tanggal'",$koneksi);
		echo "<script> document.location.href='voting.php'; </script>";
		break;
		
	case "tidak";
		echo "<br>";
		$update=mysql_db_query($db,"update voting set tidaktahu='$array3', waktu='$tanggal'",$koneksi);
		echo "<script> document.location.href='voting.php'; </script>";
		break;
	}	
	
}

?>

<html>
<head><title>Voting</title></head>
<center>
<table width="20%" border="0" cellpadding="0" cellspacing="0" bordercolor="#99CC99">
<tr> 
	<td width="5%" align="right"><img src="./img/kiri.jpg"></td>
	<td width="87%" bgcolor="#5686c6" ><div align="center"><strong><font face="verdana" size="2" color="#FFFFFF">VOTING</font></strong></div></td>
	<td width="6%"><img src="./img/kanan.jpg"></td>
</tr>
<tr>
	<td>&nbsp;</td>
	<td>
	<table width="165" align="center">
		<tr><td width="157"><font face="verdana" size="2">
		</font>
		<form method="post" action="voting.php">
		<font size="2" face="verdana"><b>Apakah situs ini berguna untuk Anda?</b><br>
		
		<input type="Radio" name="polling" value="bagus" checked>
		Ya		<br>
		<input type="Radio" name="polling" value="jelek">
		Tidak		<br>
		<input type="Radio" name="polling" value="tidak">
		Tidak Tahu <br>
		<br>
		<input type="submit" name="polling2" value="Vote" onClick="voting();">
		<form name="scrollwindow">
		<input type=button value="View" onClick="window.open('voting-view.php','scrollwindow','top=200,left=350,width=575,height=400');">
		</form>
		</form>
		</td></tr>
	</table>
	</td>
	<td>&nbsp;</td>
	<td width="2%"></td>
</tr>
<tr> 
	<td align="right"><img src="./img/kib.jpg"></td>
	<td bgcolor="#5686c6" >
	<div align="center"><marquee direction="left" scrollamount="3"><a href="http://ri32.wordpress.com" target="_blank">
	<font face="verdana" size="1" color="#FFFFFF">http://ri32.wordpress.com</font></a></marquee>
	</div>
	</td>
	<td><img src="./img/kab.jpg"></td>
</tr>
</table>
</center>
</html>
