<?
require("tools/koneksi2.php");
$koneksi=open_connection();
$insert="INSERT INTO Inbox (SenderNumber, Coding, TextDecoded, Processed) VALUES('$NoHP','Default_No_Compression','$Text','false')";
$hasil =@mssql_query ($insert) or die ("Terdapat Kesalahan INSERT INTO Inbox (SenderNumber, Coding, TextDecoded, Processed) VALUES('$NoHP','Default_No_Compression','$Text','false')");
$mati=@mysql_close($koneksi);
exit();	
?>
