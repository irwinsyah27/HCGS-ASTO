<? 
include "conn.php";
session_start();

if(isset($_POST['nama']))
{
	$nama=$_POST['nama'];
	$email=$_POST['email'];
	$topik=$_POST['topik'];
	$isi=$_POST['isi'];
	$tanggal;
	
	
	if (empty($nama) || empty($email) || empty($topik) || empty($isi))
	{
		echo "<script> document.location.href='forum-new.php?status=Maaf, Data Anda belum lengkap!!'; </script>";
	}else{
		
		$query=mysql_db_query($db,"insert into forum(nama,email,topik,isi,tanggal) values('$nama','$email','$topik','$isi','$tanggal')",$koneksi);
		
		if($query)
		{
			echo "<script> document.location.href='forum.php?status=Berhasil Membuat Topik Baru'; </script>";
		}else{
			echo "<script> alert('Gagal Query!!'); </script>";
		}
	}

}else{
	unset($_POST['nama']);
}


?>
<html><head><title>Forum Ri32</title></head><br>
<center>

<table width="22%" border="0" cellpadding="0" cellspacing="0" bordercolor="#99CC99">
<tr> 
	<td width="22%" align="right"><img src="./img/kiri.jpg"></td>
	<td width="60%" bgcolor="#009933" ><div align="center"><strong><font face="verdana" size="2" color="#FFFFFF">New Forum</font></strong></div></td>
	<td width="2%"><img src="./img/kanan.jpg"></td>
</tr>
<tr>
	<td>&nbsp;</td>
	<td>
	<table width="331" align="center">
		<tr><td width="269">
		<center>
		<font color="#FF0000" face='verdana' size='2'><blink><? echo $_GET['status'] ?></blink></font><br><br>
		<form action="forum-new.php" method="post" name="form1">
		
		<table width="100%" border="0" align="center">
		<tr >
			<td align="left"><font face="verdana" size="2">Nama</font></td><td>:</td><td align="left">
			<input name="nama" type="text" value="<? echo ("$_SESSION[Nama]");  ?>" size="20"></td>
		</tr>
		
		<tr>
			<td align="left"><font face="verdana" size="2">Email</font></td><td>:</td><td align="left">
			<input type="text" size="20" name="email"></td>
		</tr>
		
		<tr>
			<td align="left"><font face="verdana" size="2">TOPIK</font></td><td>:</td><td align="left">
			<input type="text" name="topik" size="20"></td>
		</tr>
		
		<tr>
			<td align="left"><font face="verdana" size="2">Isi</font></td><td>:</td><td align="left"><textarea name="isi" cols="100" rows="10"></textarea></td>
		</tr>
		
		<tr>
			<td><a href="forum.php" title="Kembali"><img src="./img/back.png" border="0"></a></td>
			<td></td>
			<td><div align="center">
			  <input type="submit" name="submit" value="Kirim">
			  </div></td>
		</tr>
		</table>
		</center>
		</form>
		
		</td></tr>
	</table>
	</td>
	<td>&nbsp;</td>
	<td width="16%"></td>
</tr>
<tr> 
	<td align="right"><img src="./img/kib.jpg"></td>
	<td bgcolor="#009933" ><div align="center"><strong><font face="verdana" size="3"></font></strong></div></td>
	<td><img src="./img/kab.jpg"></td>
</tr>
</table>
</center>
</html>
