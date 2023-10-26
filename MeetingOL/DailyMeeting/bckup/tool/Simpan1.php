<?
session_start();
//require("cek.php");
// ----- ambil isi dari file koneksi.php
require("../koneksi.php");
if((!$tPlan1=='0') and (!$tPlan2=='0') and (!$tPlan3=='0') and (!$tActual1=='0') and (!$tActual2=='0') and (!$tActual3=='0')) {
// ----- hubungkan ke database
$koneksi=open_connection();
$data = mysql_query ("select NoDM from DailyMeeting where TglDM='$pTgl'");
$sCek=mysql_fetch_array($data);
$data1 = mysql_query ("select NoDept, (SELECT date(now()))as jam from Departemen where NamaDept='$Dept'") or die ("Terdapat kesalahan 1!");
$d1=mysql_fetch_array($data1);
if ($sCek[NoDM]=='') {
$insert="INSERT INTO DailyMeeting (NoDept,TglDM,Items,Plan1,Plan2,Plan3,Actual1,Actual2,Actual3,Remark1,Remark2,Remark3,FileA) VALUES('$d1[NoDept]','$pTgl','A',REPLACE('$tPlan1','.',''),REPLACE('$tPlan2','.',''),REPLACE('$tPlan3','.',''),REPLACE('$tActual1','.',''),REPLACE('$tActual2','.',''),REPLACE('$tActual3','.',''),'$tRemark1','$tRemark2','$tRemark3','$File')";
} else {
    // membaca nama file
	$namaFile = $_FILES['File']['name'];     	 
	// membaca nama file temporary
	$isiFile  = $_FILES['File']['tmp_name']; 
	// membaca size file
	$sizeFile = $_FILES['File']['size'];
	// membaca tipe file
	$typeFile = $_FILES['File']['type'];
   $destination_path = '../'.$_SESSION[Dept].'/lampiranData/A/';
   $result = 0;
   $target_path = $destination_path . basename( $_FILES['File']['name']);
   if(@move_uploaded_file($_FILES['File']['tmp_name'], $target_path)) {
      $result = 1;
   }
   sleep(1);
$insert="UPDATE DailyMeeting SET Plan1=REPLACE('$tPlan1','.',''),Plan2=REPLACE('$tPlan2','.',''),Plan3=REPLACE('$tPlan3','.',''),Actual1=REPLACE('$tActual1','.',''),Actual2=REPLACE('$tActual2','.',''),Actual3=REPLACE('$tActual3','.',''),Remark1='$tRemark1',Remark2='$tRemark2',Remark3='$tRemark3',FileA='$namaFile' WHERE NoDM='$sCek[NoDM]'";
}
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
