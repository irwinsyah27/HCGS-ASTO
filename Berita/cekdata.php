<?php
include "koneksi.php";
$koneksi=open_connection();
$a = $_GET['akhir'];

$berita = mysql_query("SELECT * FROM bHarian
WHERE No>$a");

while($b = mysql_fetch_array($berita)){
    echo $b[0]."||";
    echo "<img src='img/".$b['Gambar']."' align=left width=20 height=20><b>".$b['Jenis']."</b><font size=1> (".$b['Tgl'].")</font><div align=left><b><a href=#>".$b['Judul']."</a></b></div> ";
    echo "<br>".substr($b['Isi'],0,150)." .....<br>\n";
}
mysql_close($koneksi);
?>
