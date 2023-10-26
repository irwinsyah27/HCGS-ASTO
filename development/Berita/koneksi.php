<?php
function open_connection()
{
$host="localhost";
$username="root";
$password="P@ssw0rdSQL";
$databasename="Berita";
$koneksi=@mysql_connect
($host,$username,
$password);
if ($koneksi)
$db=@mysql_select_db
($databasename,$koneksi)
or die ("Database
<b>$databasename</b> Tidak Ditemukan");
return $koneksi;
}
?>
