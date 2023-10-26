<?php
function open_connection()
{
$host="HJURWSCO404\SQLEXPRESS";
$username="sa";
$password="PAMA.456";
$databasename="SIGAP";
$koneksi=@mssql_connect
($host,$username,
$password);
if ($koneksi)
$db=@mssql_select_db
($databasename,$koneksi)
or die ("Database
<b>$databasename</b> Tidak Ditemukan");
return $koneksi;
}
?>
