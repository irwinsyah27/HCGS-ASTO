<?php
session_start();
include "config.php";
$userid = $_SESSION[NamaSec];
$pesan = mysql_query("SELECT * FROM tabel_pesan WHERE kepada='$userid' and sudahbaca='N'");
$j = mysql_num_rows($pesan);
if($j>0){
    echo "<table border=0 width=100% style=\"font-size:10pt\">";
}else{
    die("<font color=red size=1>Tidak ada Notif baru</font>");
}
while($p = mysql_fetch_array($pesan)){
    echo "<tr><td onmouseover=\"this.style.backgroundColor='#efefef'\"
     onmouseout=\"this.style.backgroundColor='#009900'\">
     <a href=# onClick=MM_openBrWindow('../".$p['dari']."/$_SESSION[Dept]/halUtama.php?mKepada=".$p['kepada']."&Pesan=".$p['pesan']."&noPesan=".$p['nomor']."','Edit','resizable=yes,scrollbars=yes,width=1080,height=800') >Pesan dari : ".$p['dari']."</a><br>
     Waktu : ".$p['waktu']."</td></tr>";
}
echo "</table>";
?>
