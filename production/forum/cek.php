<?php
	session_start();
	if(!session_is_registered
	("User")){
	echo ("<BODY> 
    <SCRIPT language='Javascript'> 
    alert('Anda Harus Login Dulu . . .!!');
    </SCRIPT> 
    </BODY>");
	exit();	
    } else {
	echo ("<BODY> <SCRIPT language='Javascript'> window.open('//10.2.167.130:83/forum/forum.php','PKH','resizable=yes,scrollbars=yes,width=1080,height=800'); </SCRIPT> </BODY>");
	
	}
?>