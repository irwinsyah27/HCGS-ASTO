<?
	session_start();
	if(!session_is_registered("User"))
	{
	echo ("<BODY> <SCRIPT language='Javascript'> alert('Anda Harus Login Dulu . . .!!'); </SCRIPT> </BODY>");
	echo ("<div align=center><a href=Login.php>Login</a></div>");
	exit();	
    }
	if (($_SESSION[User]=='6100077') or ($_SESSION[User]=='6195011') or ($_SESSION[User]=='KC07103') or ($_SESSION[User]=='6103041') or ($_SESSION[User]=='KC10047') or ($_SESSION[User]=='KB05002') or ($_SESSION[User]=='KB09014') or ($_SESSION[User]=='KC05132')){
	echo ("<BODY> <SCRIPT language='Javascript'> window.open('//10.2.167.130:83/SHES/Utama.php','ShEBOX',',,scrollbars=yes,width=1000,height=700'); </SCRIPT> </BODY>");
	exit();
	} else {
	exit();
	}
?>
