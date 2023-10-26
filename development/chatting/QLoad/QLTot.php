<?php
			require("../koneksi.php");
			$koneksi=open_connection();
			
			$counAll=mysql_query("select COUNT(*) as ada from User where Stat='1'");
			$CouAll=mysql_fetch_array($counAll);
			
			echo $CouAll[ada].' User  Online . . . ';
			mysql_close($koneksi);
?>