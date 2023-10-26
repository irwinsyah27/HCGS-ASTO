<?php
	
	session_start();
	
	$R=$_GET['R'];
	$A=$_GET['A'];
	$S=$_GET['S'];
	$T=$_GET['T'];
	
	if ($R!="")
    {		
	$_SESSION['LogIn']=date("Y-m-d H:i:s");
	$_SESSION['User']=strtoupper($R);
	$_SESSION['UserID']=strtoupper($R);
	$_SESSION['SNama']=strtoupper($A);
	$_SESSION['Dept']=$T;
	$_SESSION['Site']=$S;
	
	require("Chatting/koneksi.php");
	$koneksi=open_connection();
	$UPD=mysql_query("UPDATE User SET Data = '$P' WHERE NRP = '$R'") or die ("kd mau SessOn"); 
	mysql_close($koneksi);
	
	header("location://pabbapco401.kppmining.net:83/development/KPPApps.php");
	exit();		
    } else {
	header("location://pabbapco401.kppmining.net:83/development/SessionOff.php");
	exit();	
	}
?>