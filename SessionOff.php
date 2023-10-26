<?php
	session_start();
	require("Chatting/koneksi.php");
	$koneksi=open_connection();
	$UPD=mysql_query("UPDATE User SET Session_ID = NULL, Stat='0', Akses='0' WHERE NRP='".$_SESSION['UserID']."'") or die ("kd mau Sessoff"); 
	mysql_close($koneksi);
	session_destroy();
	header("location://pabbapco401.kppmining.net/logout.aspx");
	?>