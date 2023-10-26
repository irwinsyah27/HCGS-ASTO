<?
session_start();
//require("cek.php");
// ----- ambil isi dari file koneksi.php
require("../koneksi.php");
if(!$tInf=='') {
// ----- hubungkan ke database
$koneksi=open_connection();

	// membaca nama file
	$namaFile = $_FILES['File']['name'];     	 
	// membaca nama file temporary
	$isiFile  = $_FILES['File']['tmp_name']; 
	// membaca size file
	$sizeFile = $_FILES['File']['size'];
	// membaca tipe file
	$typeFile = $_FILES['File']['type'];
   $destination_path = '../'.$_SESSION[Dept].'/lampiranData/C/';
   $result = 0;
   $target_path = $destination_path . basename( $_FILES['File']['name']);
   if(@move_uploaded_file($_FILES['File']['tmp_name'], $target_path)) {
      $result = 1;
   }
   sleep(1);

$insert="UPDATE DailyMeeting SET Information='$tInf',FileC='$namaFile' WHERE NoDM='$NoDM'";

// ------ jalankan perintah SQL untuk memasukkan data ke tabel PKH
$hasil =@mysql_query ($insert) or die ("Terdapat Kesalahan SQL");
// ------ putus hubungan dengan database
mysql_close($koneksi);
echo ("<BODY> 
<SCRIPT language='Javascript'> 
alert('Data Sudah Masuk'); 
close();
</SCRIPT> 
</BODY>"); } 
else {
echo ("<BODY> 
<SCRIPT language='Javascript'> 
alert('Anda Belum Mengisi data. . !!'); 
close();
</SCRIPT> 
</BODY>");
}

?>
