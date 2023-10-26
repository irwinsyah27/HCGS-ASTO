<?
session_start();
if(!session_is_registered("User"))
	{
	echo ("<BODY> <SCRIPT language='Javascript'> alert('Anda Harus Login Dulu . . .!!'); </SCRIPT> </BODY>");
	echo ("<div align=center><a href=Login.php>Login</a></div>");
	exit();	
    }
if (($_SESSION[User]=='6103041') or ($_SESSION[User]=='KC10047') or ($_SESSION[User]=='KB10006') or ($_SESSION[User]=='KB06005') or ($_SESSION[User]=='KB08004') or ($_SESSION[User]=='KB12028')){
		
	} else {
	echo("<BODY> <SCRIPT language='Javascript'> alert('Tdk ada Akses !!'); close();</SCRIPT> </BODY>");
	exit();
	}
?>