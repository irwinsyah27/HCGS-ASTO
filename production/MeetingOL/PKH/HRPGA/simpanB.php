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
$insert="INSERT INTO PKH (TglPK,NoSec,Sejak,Lokasi,Instruksi_Kerja,Laporan_Pelaksanaan,Status,TglUpdate,UserUpdate) VALUES('$TglSkrg','$d1[NoSec]','$mSejak','$mLokasi','$mInstruksi','$mLaporan','$mStatus','$DateTimeSkrg''$d1[jam]','$_SESSION[User]')";
// ------ jalankan perintah SQL untuk memasukkan data ke tabel PKH
$hasil =@mysql_query ($insert) or die ("Terdapat Kesalahan SQL");

if(!$mKepada==$_SESSION[NamaSec]){
	$noS=mysql_query("Select NoPKH from PKH WHERE NoSec= '$d1[NoSec]' AND TglUpdate= '$DateTimeSkrg''$d1[jam]' AND UserUpdate= '$_SESSION[User]'");
	$noPK=mysql_fetch_array($noS);
	require("../../../Tools/config.php");
	//set sudah dibaca = Y kalau sudah dibaca
	$insert = mysql_query("INSERT INTO tabel_pesan VALUES(null,'$DateTimeSkrg''$d1[jam]','PKH','$mKepada','$noPK[NoPKH]','N')"); } else {
	$noS=mysql_query("Select NoPKH from PKH WHERE NoSec= '$d1[NoSec]' AND TglUpdate= '$DateTimeSkrg''$d1[jam]' AND UserUpdate= '$_SESSION[User]'");
	$noPK=mysql_fetch_array($noS);
	require("../../../Tools/config.php");
	//set sudah dibaca = Y kalau sudah dibaca
	$insert = mysql_query("INSERT INTO tabel_pesan VALUES(null,'$DateTimeSkrg''$d1[jam]','PKH','HeadHRPGA','$noPK[NoPKH]','N')"); }
} else {
	// membaca nama file
	$namaFile = $_FILES['mLampiran']['name'];     	 
	// membaca nama file temporary
	$isiFile  = $_FILES['mLampiran']['tmp_name']; 
	// membaca size file
	$sizeFile = $_FILES['mLampiran']['size'];
	// membaca tipe file
	$typeFile = $_FILES['mLampiran']['type'];
   $destination_path = 'Pendukung/data'.$_SESSION[NamaSec].'/';
   $result = 0;
   $target_path = $destination_path . basename( $_FILES['mLampiran']['name']);
   if(@move_uploaded_file($_FILES['mLampiran']['tmp_name'], $target_path)) {
      $result = 1;
   }
   sleep(1);
  $insert="INSERT INTO PKH (TglPK,NoSec,Sejak,Lokasi,Instruksi_Kerja,Laporan_Pelaksanaan,Status,Lampiran,Type,TglUpdate)
  VALUES('$TglSkrg','$d1[NoSec]','$mSejak','$mLokasi','$mInstruksi','$mLaporan','$mStatus','$namaFile','$typeFile','$TglSkrg')";
  // ------ jalankan perintah SQL untuk memasukkan data ke tabel PKH
  $hasil =@mysql_query ($insert) or die ("Terdapat Kesalahan SQL");

if(!$mKepada==$_SESSION[NamaSec]){
	$noS=mysql_query("Select NoPKH from PKH WHERE NoSec= '$d1[NoSec]' AND TglUpdate= '$DateTimeSkrg''$d1[jam]' AND UserUpdate= '$_SESSION[User]'");
	$noPK=mysql_fetch_array($noS);
	require("../../../Tools/config.php");
//set sudah dibaca = Y kalau sudah dibaca
	$insert = mysql_query("INSERT INTO tabel_pesan VALUES(null,'$DateTimeSkrg''$d1[jam]','PKH','$mKepada','$noPK[NoPKH]','N')"); } else {
	$noS=mysql_query("Select NoPKH from PKH WHERE NoSec= '$d1[NoSec]' AND TglUpdate= '$DateTimeSkrg''$d1[jam]' AND UserUpdate= '$_SESSION[User]'");
	$noPK=mysql_fetch_array($noS);
	require("../../../Tools/config.php");
	//set sudah dibaca = Y kalau sudah dibaca
	$insert = mysql_query("INSERT INTO tabel_pesan VALUES(null,'$DateTimeSkrg''$d1[jam]','PKH','HeadHRPGA','$noPK[NoPKH]','N')"); }

}
// ------ putus hubungan dengan database
mysql_close($koneksi);
echo ("<BODY> 
<SCRIPT language='Javascript'> 
alert('Data Sudah Masuk'); 
close();
</SCRIPT> 
</BODY>");
?>
