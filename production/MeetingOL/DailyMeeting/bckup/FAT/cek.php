<?php
	session_start();
	if(!$_SESSION[Dept]=='HRPGA'){
	echo "<h3>Akses Ditolak...
	</h3> <a href=//HJURWSCO404/KPP_INDEX class=style2>LogiN</a>";
	exit;
}
?>