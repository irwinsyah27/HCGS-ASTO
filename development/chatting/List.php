<?
session_start();
require("koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();
///////////////////////////
?>

<?
$coun=mysql_query("select COUNT(*) as ada from User where NRP='$_SESSION[User]'");
$Cou=mysql_fetch_array($coun);
if ($Cou[ada]=='0') {
$INS=mysql_query("INSERT INTO User (NRP,Stat) VALUES ('$_SESSION[User]','1')"); }
else {
$UPD=mysql_query("UPDATE User SET Stat='1' WHERE NRP='$_SESSION[User]'"); }
?>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/loose.dtd" >

<html>
<head>
<title>Chatting Box</title>
<style>
body {
	background-color: #eeeeee;
	padding:0;
	margin:0 auto;
	font-family:"Lucida Grande",Verdana,Arial,"Bitstream Vera Sans",sans-serif;
	font-size:11px;
}
</style>

<link type="text/css" rel="stylesheet" media="all" href="css/chat.css" />
<link type="text/css" rel="stylesheet" media="all" href="css/screen_ie.css" />

<!--[if lte IE 7]>
<link type="text/css" rel="stylesheet" media="all" href="css/screen_ie.css" />
<![endif]-->

</head>
<body>
<div align="center"><a href="#" >Online</a> &lt; - - - - - - - - - - - - - - - - &gt; <a href="#" >Offline</a></div>
<div id="main_container">

<?
$sel2=mysql_query("select * from User where Stat='1' and NRP<>'$_SESSION[User]'")
or die ("Salah SQL!");
// ------ ambil isi masing-masing record
while ($row = mysql_fetch_object($sel2))
{
		// ----- mengambil isi setiap kolom
		$NRP=$row->NRP;
		$Nama=$row->Nama;

		// ------ menampilkan di layar browser
		
								   echo("<a align=center href=javascript:void(0) 
								   		onClick=javascript:chatWith('$NRP')>($NRP)</a> ");
}
?>
</div>

<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/chat.js"></script>

</body>
</html>

