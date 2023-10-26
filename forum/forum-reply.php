<? 
include "conn.php";
session_start();
if(isset($_POST['nama']))
{
	$nama=$_POST['nama'];
	$email=$_POST['email'];
	$topik=$_POST['topik'];
	$isi=$_POST['isi'];
	$ID_topik=$_POST['ID_topik'];
	
	if (empty($nama) || empty($email) || empty($topik) || empty($isi))
	{
		?><script language="javascript">document.location.href='forum-reply.php?ID_topik=<? echo $ID_topik;?>&topik=<? echo $topik;?>&status=Maaf, Data Anda masih kosong!!'; </script>";</script><?
	}else{
		$query=mysql_db_query($db,"insert into forum(nama,email,topik,isi,tanggal,ID_replay) values('$nama','$email','$topik','$isi','$tanggal','$ID_topik')",$koneksi);
	
		
		if($query)
		{
			echo "<script>alert('Berhasil mengisi reply!!');</script>";
			?><script language="javascript">document.location.href='forum-view.php?ID_topik=<? echo $ID_topik;?>'; </script>";</script><?
		}else{
			echo "<script>alert('gagal!!');</script>";
		}
	}
}else{
	unset($_POST['nama']);
}


?>
<html> 
<head><title>Forum Ri32</title></head><br>
<center><br>
<table width="25%" border="0" cellpadding="0" cellspacing="0" bordercolor="#99CC99">
<tr> 
	<td width="2%" align="right"><img src="./img/kiri.jpg"></td>
	<td width="90%" bgcolor="#009933" ><div align="center"><strong><font face="verdana" size="2" color="#FFFFFF">Reply Forum</font></strong></div></td>
	<td width="6%"><img src="./img/kanan.jpg"></td>
</tr>
<tr>
	<td>&nbsp;</td>
	<td>
	<table width="331" align="center">
		<tr><td width="269">
		<center><font color="#FF0000" face='verdana' size='2'><blink><? echo $_GET['status'] ?></blink></font><br><br></center>
		<form action="forum-reply.php" method="post" name="form1">
		<table width="100%" border="0">
		<tr >
			<td align="left"><font face="verdana" size="2">ID</font></td><td>:</td><td align="left">
			<input type="hidden" value="<? echo $_GET['ID_topik']; ?>" name="ID_topik"><font face="verdana" size="2"><? echo $_GET['ID_topik']; ?></font></td>
		</tr>
		
		
		
		<tr >
			<td align="left"><font face="verdana" size="2">Nama</font></td><td>:</td><td align="left">
			<input name="nama" type="text" value="<? echo ("$_SESSION[Nama]");  ?>" size="20"></td>
		</tr>
		
		<tr>
			<td align="left"><font face="verdana" size="2">Email</font></td><td>:</td><td align="left">
			<input type="text" name="email" size="20"></td>
		</tr>
		
		<tr>
			<td align="left"><font face="verdana" size="2">Topik</font></td><td>:</td><td align="left">
			<input type="text" value="<? echo $_GET['topik']; ?>" name="topik" size="33"></td>
		</tr>
		
		
		
		<tr>
			<td align="left"><font face="verdana" size="2">Isi</font></td><td>:</td><td align="left"><textarea name="isi" cols="25" rows="10"></textarea></td>
		</tr>
		
		<tr>
			<td>
			<a href="forum-view.php?ID_topik=<? echo $_GET['ID_topik']; ?>&topik=<? echo $_GET['topik'];?>" style="text-decoration:none" title="Kembali">
			<img src="./img/back.png" border="0">
			</a>
			</td>
			<td></td>
			<td><input type="submit" name="submit" value="POST"></td>
		</tr>
		</table>
		</form>
		
		
		</td></tr>
	</table>
	</td>
	<td>&nbsp;</td>
	<td width="2%"></td>
</tr>
<tr> 
	<td align="right"><img src="./img/kib.jpg"></td>
	<td bgcolor="#009933" ><div align="center"><strong><font face="verdana" size="3"></font></strong></div></td>
	<td><img src="./img/kab.jpg"></td>
</tr>
</table>
</center>
</html>
