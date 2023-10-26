<?php
function open_connection()
{
$host="HJURWSCO404\SQLExpress";
$username="ewacs_apps";
$password="l091n";
$databasename="db_ewacs_hjur_local";
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
