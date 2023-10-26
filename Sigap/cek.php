<?
	session_start();
	if(!session_is_registered("User"))
	{
	echo ("<BODY> <SCRIPT language='Javascript'> alert('Anda Harus Login Dulu . . .!!'); </SCRIPT> </BODY>");
	echo ("<div align=center><a href=Login.php>Login</a></div>");
	exit();	
    }  else {
	echo ("<BODY> <SCRIPT language='Javascript'> window.open('//10.2.167.130:83/Sigap/Utama.php','Security','resizable=yes,,scrollbars=yes,width=1000,height=700'); </SCRIPT> </BODY>");
	}
?>
