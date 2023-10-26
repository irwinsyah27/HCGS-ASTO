<?php
session_start();
require("cek.php");
// ----- ambil isi dari file koneksi.php
require("../koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();

// query untuk mencari data file yang akan didownload dalam database
$query   = "SELECT Lampiran, Type FROM PKH WHERE NoPKH='$NPK'";
 
$hasil   = mysql_query($query);
$data    = mysql_fetch_array($hasil);
 
// mencocokkan username pemilik file  dengan username yang sedang login

// bila usernamenya cocok maka file boleh didownload
   
header("Content-type: ".$data['Type']);
   
echo $data['Lampiran'];

?>