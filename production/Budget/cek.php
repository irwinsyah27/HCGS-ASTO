<?
	session_start();
	if(!session_is_registered("User"))
	{
	echo ("<BODY> <SCRIPT language='Javascript'> alert('Anda Harus Login Dulu . . .!!'); </SCRIPT> </BODY>");
	echo ("<div align=center><a href=http://RANTAPPU401>Login</a></div>");
	exit();	
    }  
?>
