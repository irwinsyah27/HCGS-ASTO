<?
session_start();
?>
<script>
function Pesan(x) {
	if(x=='1'){
	alert("Data Telah id Update !!");
	} else {
	alert("Data Gagal di Update !!");
	}
}
</script>
<?
require("cek.php");
// ----- ambil isi dari file koneksi.php
require("../koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();

$TglSkrg=date('Y-m-d');
$DateTimeSkrg=date('Y-m-d ');

//////////////////////////////////////////////////////////////////////////////////////////////////
$data1 = mysql_query ("select SecDept.NoSec, (SELECT time(now()))as jam from SecDept where NamaSec='$mKepada'") or die ("Terdapat kesalahan 1!");
$d1=mysql_fetch_array($data1);

if($mLampiran=='') {
$update="UPDATE PKH SET TglUpdate='$DateTimeSkrg''$d1[jam]', UserUpdate='$_SESSION[User]', NoSec='$d1[NoSec]', Lokasi='$mLokasi', Sejak='$mSejak', Lokasi='$mLokasi', Instruksi_kerja='$mInstruksi', Laporan_Pelaksanaan='$mLaporan', Status='$mStatus', Kondisi='$mKondisi' WHERE NoPKH='$PKH'";
// ------ jalankan perintah SQL untuk memasukkan data ke tabel PKH
$hasil =@mysql_query ($update) or die ("Terdapat Kesalahan SQL 1");

if($mKepada!=$_SESSION[NamaSec]){
	require("../../Tools/config.php");
	//set sudah dibaca = Y kalau sudah dibaca
	$insert = mysql_query("INSERT INTO tabel_pesan VALUES(null,'$DateTimeSkrg''$d1[jam]','PKH','$mKepada','$PKH','N')"); } else {
	require("../../Tools/config.php");
	//set sudah dibaca = Y kalau sudah dibaca
	$insert = mysql_query("INSERT INTO tabel_pesan VALUES(null,'$DateTimeSkrg''$d1[jam]','PKH','HeadPLANT','$PKH','N')"); }
	
} else {
  // membaca nama file
  $namaFile = $_FILES['mLampiran']['name'];     
 
  // membaca nama file temporary
  $isiFile  = $_FILES['mLampiran']['tmp_name']; 
 
  // membaca size file
  $sizeFile = $_FILES['mLampiran']['size'];
 
  // membaca tipe file
  $typeFile = $_FILES['mLampiran']['type'];

  $fp      = fopen($isiFile, 'r');
  $content = fread($fp, filesize($isiFile));
  $content = addslashes($content);
  fclose($fp);
  
  $update="UPDATE PKH SET TglUpdate='$TglSkrg', NoSec='$d1[NoSec]', Lokasi='$mLokasi', Sejak='$mSejak', Lokasi='$mLokasi',
  Instruksi_kerja='$mInstruksi', Laporan_Pelaksanaan='$mLaporan', Status='$mStatus', Lampiran='$namaFile', File='$content',
  Type='$typeFile' WHERE NoPKH='$PKH'";
  // ------ jalankan perintah SQL untuk memasukkan data ke tabel PKH
  $hasil =@mysql_query ($update) or die ("Terdapat Kesalahan SQL 2");
  }
// ------ putus hubungan dengan database
mysql_close($koneksi);
echo ("<BODY> 
<SCRIPT language='Javascript'> 
alert('Data di Simpan'); 
close();
</SCRIPT> 
</BODY>");
?>
 
