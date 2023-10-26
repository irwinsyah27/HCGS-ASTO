<?php
	session_start();
	if(!session_is_registered
	("User")){
	echo ("<BODY> <SCRIPT language='Javascript'> alert('Anda Harus Login Dulu . . .!!'); close(); </SCRIPT> </BODY>");
	exit();	
    } else 
	if (($_SESSION[User]=='6104048') or ($_SESSION[User]=='8402003') or ($_SESSION[User]=='KB06005') or ($_SESSION[User]=='6103041') or ($_SESSION[User]=='KC09069') or ($_SESSION[User]=='kc09069') or ($_SESSION[User]=='kC09069') or ($_SESSION[User]=='KB10037') or ($_SESSION[User]=='KC10047')){
	echo ("<BODY> <SCRIPT language='Javascript'> window.open('$_SESSION[Dept]/halUtama.php','DailyMeeting','resizable=yes,,scrollbars=yes,width=1200,height=800'); close(); </SCRIPT> </BODY>");
	exit();	
	} else {
	echo ("<BODY> <SCRIPT language='Javascript'> alert('Anda Tidak Ada Akses Untuk Ini . . .!!'); close(); </SCRIPT> </BODY>");
	exit();	
	}
?>
