<?
session_start();

require("cek.php");
// ----- ambil isi dari file koneksi.php
require("../koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();

$data1 = mysql_query ("select SecDept.NamaSec, PKH.Status from PKH, SecDept, Departemen where PKH.NoSec=SecDept.NoSec and SecDept.NoDept=Departemen.NoDept and NoPKH='$PKH'") or die ("Terdapat kesalahan pada perintah SQL!");
$d1=mysql_fetch_array($data1);
$NmSec=$d1[NamaSec];
if ((($NmSec==$_SESSION[NamaSec]) and ($d1[Status]=='Close')) or (($_SESSION[User]=='6100077') or ($_SESSION[User]=='KC07103') or ($_SESSION[User]=='KB05005') or ($_SESSION[User]=='6195011') and ($d1[Status]=='Close'))) {
$hapus="DELETE from PKH WHERE NoPKH='$PKH'";
// ------ jalankan perintah SQL untuk memasukkan data ke tabel PKH
$hasil =@mysql_query ($hapus) or die ("Terdapat Kesalahan SQL1");
// ------ putus hubungan dengan database
mysql_close($koneksi);
echo ("<BODY> 
<SCRIPT language='Javascript'> 
alert('Data Telah di Hapus'); 
close();
</SCRIPT> 
</BODY>");
exit();
} else {
echo ("<BODY> 
<SCRIPT language='Javascript'> 
alert('Anda Tidak Berhak Menghapus Data Ini / Status Belum CLOSE...!!!'); 
close();
</SCRIPT> 
</BODY>");
}
?>
