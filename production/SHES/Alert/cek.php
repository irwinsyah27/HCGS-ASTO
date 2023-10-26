<?
session_start();
if(!session_is_registered("User"))
	{
	echo ("<BODY> <SCRIPT language='Javascript'> alert('Anda Harus Login Dulu . . .!!'); </SCRIPT> </BODY>");
	echo ("<div align=center><a href=Login.php>Login</a></div>");
	exit();	
    }
if (($_SESSION[User]=='6100077') or ($_SESSION[User]=='6195011') or ($_SESSION[User]=='KC07103') or 
	($_SESSION[User]=='6103041') or ($_SESSION[User]=='KC10047') or 
	($_SESSION[User]=='KB05002') or ($_SESSION[User]=='KB09014') or ($_SESSION[User]=='KC05132') or
	($_SESSION[User]=='KB07014') or ($_SESSION[User]=='6110766')){	
	
	} else {
	echo("<BODY> <SCRIPT language='Javascript'> alert('Tdk ada Akses !!'); close();</SCRIPT> </BODY>");
	exit();
	}
?>