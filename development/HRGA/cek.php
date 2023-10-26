<?php
	/*session_start();
	if(!session_is_registered
	("User")){
	echo ("<BODY> 
    <SCRIPT language='Javascript'> 
    alert('Anda Harus Login Dulu . . .!!');
    alert('Silahkan Tekan Tombol Merah Pada Pojok Kanan Atas . . .!!');
    </SCRIPT> 
    </BODY>");
	session_destroy();
    } else {
echo ("<BODY> <SCRIPT language='Javascript'> window.open('//pabbapco401.kppmining.net/Logout.aspx','LOGIN','resizable=yes,scrollbars=yes,width=1200,height=800'); </SCRIPT> </BODY>"); 
exit();	
	} */
	session_start();
	if(!$_SESSION['User']){
	echo ("<BODY> <SCRIPT language='Javascript'> alert('Anda Harus Login Dulu . . .!!'); alert('Silahkan Tekan Tombol Merah Pada Pojok Kanan Atas . . .!!');
    </SCRIPT> 
    </BODY>");
	session_destroy();
    } else {
echo ("<BODY> <SCRIPT language='Javascript'> window.open('//pabbapco401.kppmining.net/Logout.aspx','LOGIN','resizable=yes,scrollbars=yes,width=1200,height=800'); </SCRIPT> </BODY>"); 
exit();	
	}
?>