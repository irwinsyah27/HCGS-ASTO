<? 
session_start();
require('../koneksi.php');

$koneksi=open_connection();
$Skrg = date('Y-m-d G:i:s');
if (!$foto=='') {
$cek = mysql_query("insert into bHarian (Judul, Gambar, Isi, NRP, User, Tgl, Jenis) values ('$mJudul', '$mJudul', '$mIsi', '$_SESSION[User]', '$_SESSION[Nama]', '$Skrg', '$mJenis')");
copy($foto,"$mJudul");
} else {
$cek = mysql_query("insert into bHarian (Judul, Gambar, Isi, NRP, User, Tgl, Jenis) values ('$mJudul', 'No_Image.gif', '$mIsi', '$_SESSION[User]', '$_SESSION[Nama]', '$Skrg', '$mJenis')");
}
if($cek)
{
	echo ("<BODY> <SCRIPT language='Javascript'>  alert('Berhasil . . .!!'); close(); </SCRIPT> </BODY>");
	exit();
}
else
{ 
echo "Upload gagal";
}
mysql_close($koneksi);
?>
