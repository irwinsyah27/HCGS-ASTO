<?
session_start();
if(!session_is_registered("User"))
	{
	echo ("<BODY> <SCRIPT language='Javascript'> alert('Anda Harus Login Dulu . . .!!'); </SCRIPT> </BODY>");
	echo ("<div align=center><a href=Login.php>Login</a></div>");
	exit();	
    }
if (($_SESSION[User]=='k6103041') or ($_SESSION[User]=='kKC10047') or ($_SESSION[User]=='kKB10006') or ($_SESSION[User]=='kKB10087') or ($_SESSION[User]=='kKB08004')){
		
	} else {
	echo("<BODY> <SCRIPT language='Javascript'> alert('Tdk ada Akses !!'); close();</SCRIPT> </BODY>");
	exit();
	}
?>