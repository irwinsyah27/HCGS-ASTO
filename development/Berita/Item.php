<?
session_start();
require("koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();
?>

<html>
<style type="text/css">
<!--
.judul {
	font-size: 20px;
	font-weight: bold;
	font-family: "DejaVu Sans";
}
.isi {
	font-family: "DejaVu Sans";
	font-size: 15px;
}
.read {font-family: "DejaVu Sans"}
.publis {
	font-size: 10px;
	color: #444444;
}
-->
</style>
<body>
<p>
  <?php
$sel2=mysql_query("select No, User, bHarian.Judul, bHarian.Gambar, bHarian.Isi, bHarian.Tgl, bHarian.Jenis, bHarian.NRP from bHarian where  No='$No'")
or die ("Salah SQL 1!");
// ------ ambil isi masing-masing record
while ($row = mysql_fetch_object($sel2))
{
		// ----- mengambil isi setiap kolom
		$No=$row->No;
		$Judul=$row->Judul;
		$Gambar=$row->Gambar;
		$Isi=$row->Isi;
		$Tgl=$row->Tgl;
		$Jenis=$row->Jenis;
		$NRP=$row->NRP;
		$User=$row->User;

		// ------ menampilkan di layar browser
		echo("<table width=800 border=0 align=center bgcolor=#78b103><tr><td bgcolor=#FFFFFF>");
		echo("<table width=100% border=0 ><tr><td><div align=center>$Jenis</td></tr>");
								   echo("<tr><td width=30% class=judul><div align=center>$Judul</td></tr>");
								   
								   echo("<tr><td width=30%><div align=center><img src='img/$Gambar' width=400 height=200/></td></tr>");
								   echo("<tr><td width=100% class=isi><div align=justify>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$Isi</td></tr>");
								   echo("<tr><td width=10% class=publis><div align=center>Tanggal, $Tgl</td></tr>");
								   echo("<tr><td width=10% class=publis><div align=center>Autor: $User ($NRP)</td></tr></table>");
		echo("</td></tr></table></p>");
}
mysql_close($koneksi);
?>  
</p>
<div align="center"><a href="Utama.php?mJenis=All"><strong>Back..</strong></a>
</div>
</body>
</html>