<?php
	session_start();
	if(!session_is_registered
	("User")){
	echo ("<BODY> <SCRIPT language='Javascript'> alert('Anda Harus Login Dulu . . .!!'); </SCRIPT> </BODY>");
	exit();	
    } else 
	if (($_SESSION[User]=='6100077') or ($_SESSION[User]=='6195011') or ($_SESSION[User]=='KC07103') or ($_SESSION[User]=='6103041')){
	echo ("<BODY> <SCRIPT language='Javascript'> window.open('Menu.php','PKH','resizable=yes,scrollbars=yes,width=400,height=250'); close();</SCRIPT> </BODY>");
	exit();	
	} else {
	echo ("<BODY> <SCRIPT language='Javascript'> window.open('$_SESSION[Dept]/halUtama.php','PKH','resizable=yes,scrollbars=yes,width=1080,height=800'); close();</SCRIPT> </BODY>");
	exit();	
	}
?>
