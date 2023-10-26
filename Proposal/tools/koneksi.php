<?php
function open_connection()
{
$host="bdmaapco401\SQLEXPRESS";
$username="sa";
$password="SQLP@ssw0rd";
$databasename="BudgetSystem";
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
