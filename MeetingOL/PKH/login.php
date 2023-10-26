<?
session_start();
require("koneksi.php");
$koneksi=open_connection();
$data1=mysql_query("select nrp, NamaSec, User.Nama from User, Secdept where User.NoSec=SecDept.NoSec and User.nrp='$nrp' and User.password='$pass'")or die ("Terdapat kesalahan pada perintah SQL!");
$d1=mysql_num_rows($data1);
$d2=mysql_fetch_array($data1);

if ($d2[nrp]!=""&&$Dept=="HRPGA")
{		
	$_SESSION[User]=$nrp;
	$_SESSION[Nama]=$d2[Nama];
	$_SESSION[NamaSec]=$d2[NamaSec];
	$_SESSION[Dept]=$Dept;
	header("location:HRPGA/halUtama.php");
	exit();	
}
elseif ($d2[nrp]!=""&&$Dept=="ENG")
{		
	session_register("ENG");
}
elseif ($d2[nrp]!=""&&$Dept=="PROD")
{
	session_register("PROD");
}
?>
