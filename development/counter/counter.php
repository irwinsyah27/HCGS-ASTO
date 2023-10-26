<?
//untuk membuat cookies namanya counter, nilainya visitor, disimpan di browser selama 1 jam
setcookie("counter","visitor",time()+3600);

//untuk koneksi
include "conn.php";

//lihat variable tanggal di file conn.php
$tanggal;

//untuk query mysql
$quey=mysql_db_query($db,"select * from counter",$koneksi);

//ambil nilai di database
while ($rows=mysql_fetch_array($quey))
{
	//ambil data jumlah pengunjung di field jml	
	$visit=$rows['jml'];
}

//jika pertama kali kosong, beri nilai 1
if ($visit=="")
{
	mysql_db_query($db,"insert into counter values('$tanggal',1)",$koneksi);
}

//apakah file cookies "counter" sudah ada di browser
if (!isset($_COOKIE['counter']))
{
	//jika belum ada penambahan satu pada variabel dan lakukan update ke database untuk nilai counter yang baru
	$visit=$visit+1;
	mysql_db_query($db,"update counter set jml='$visit'",$koneksi);
}

?>
<html>
<link rel="shortcut icon" href="favicon.ico" type="image/x-icon">
<table width="100%" border="0" cellpadding="0" cellspacing="0" bordercolor="#99CC99">
<tr> 
	<td bgcolor="#5686c6" ><div align="center"><strong><font face="verdana" size="2" color="#FFFFFF">PENGUNJUNG</font></strong></div></td>
</tr>
<tr>
	<td height="29" colspan="3" align="center"><br>
	<font face="verdana" size="2" color="#FF9933"><b>
	<? 
	
	//untuk menampilkan jumlah pengunjung dengan file gambar angka 0,1,2,3,4..9
	
	//hitung panjang nilai jumlah pengunjung jika ada 23767 = berarti panjangnya 5
	$ulang=strlen($visit);
	echo "Jumlah Pengunjung : <br><br>";
	
	//lakukan perulangan sebanyak variabel $ulang untuk ubah tampilan angka biasa menjadi gambar 0 menjadi 0.gif, 2 menjadi 2.gif
	for ($i=0;$i<$ulang;$i++){
		 //pisahkan serangkaian angka menjadi terpisah. misalnya, 23767 di pecah menjadi 2,3,7,6,dan 7 untuk masing2 di ubah manjadi angka gambar
		 $angka=substr($visit,$i,1);
		 echo "<img src='img/$angka.gif' />";
	}
	
	//jumlah asli angka biasa
	echo "<br>";
	echo $visit;
	?>
	
	</b><br><br></font>	
	</td>
</tr>

<tr> 
	<td bgcolor="#5686c6" ><div align="center"><font face="verdana" size="2" color="#FFFFFF"><? echo $tanggal=date('d-M-Y');?></font></div></td>
</tr>
</table>
</html>
