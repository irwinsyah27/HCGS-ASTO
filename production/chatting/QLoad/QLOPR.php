<?php
			$Unrp = $_GET["Unrp"];
			require("../koneksi.php");
			$koneksi=open_connection();
			$ca=mysql_query("select Akses from User where NRP='".$Unrp."'");
			$Ca=mysql_fetch_array($ca);
			$selDOPR=mysql_query("select * from User where Stat='1' and NRP<>'".$Unrp."' AND Dept='OPR' ORDER BY DATE DESC")
			or die ("Salah SQL!");
			
				// ------ ambil isi masing-masing record
				while ($row = mysql_fetch_object($selDOPR))
			{
			// ----- mOPRambil isi setiap kolom
			$NRP=strtoupper($row->NRP);
			$Nama=str_replace(" ", "_",strtoupper($row->Nama));
			$Akses=$row->Akses;
			// ------ menampilkan di layar browser
			
			echo("<a align=center href=javascript:void(0) 
				onClick=javascript:chatWith('".$NRP."')>( ".$NRP." )</a><ul><li>".$Nama."</h5></li></ul></p>");
			
			}
			mysql_close($koneksi);
?>