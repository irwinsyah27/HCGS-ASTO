<?
session_start();
require("koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();

	// buat fungsi PHP //
	
		function makeLink($str,$url,$bold="false"){
		if($bold){
			$str="<b>".$str."</b>";
		}
		return '<a class=style51 href="'.$url.'">'.$str.'</a>';
		
	}

	function paging($curRec,$totalRec,$maxRec,$lkPost){
		$totalPage=ceil($totalRec/$maxRec);
		$curPage=ceil(($curRec+1)/$maxRec);
		$str="";
		
		/*--------------------------prev button-----------------------*/
		if($curPage>1){
			$rec=($curPage-2)*$maxRec;					
			$str.=" ".makeLink("Prev","?cur=".$rec."&".$lkPost,$bold)." ";			
		}
		
		/*-------------------------generate page number----------------*/
		for($i=1;$i<=$totalPage;$i++){
			if($i==$curPage){
				$bold=true;
			}else{
				$bold=false;
			}
			$rec=($i-1)*$maxRec;					
			$str.=" ".makeLink($i,"?cur=".$rec."&".$lkPost,$bold)." ";
		}
		
		/*--------------------------next button-----------------------*/
		if($curPage<$totalPage){
			$rec=($curPage*$maxRec);					
			$str.=" ".makeLink("Next","?cur=".$rec."&".$lkPost,$bold)." ";			
		}
		
		return $str;
		
	}
?>

<html>
<style type="text/css">
<!--
.judul {
	font-size: 20px;
	font-weight: bold;
	font-family: "DejaVu Sans";
}
.isi {
	font-family: "DejaVu Sans";
	font-size: 15px;
}
.read {font-family: "DejaVu Sans"}
.publis {
	font-size: 10px;
	color: #444444;
}
-->
</style>
<body>
<p>
  <script type="text/JavaScript">
<!--
function MM_openBrWindow(theURL,winName,features) { //v2.0
  window.open(theURL,winName,features);
}
</script>
</p>
<p>
  <?php
$maxRec=3;// maximum record per page
	$curRec=($_GET['cur']==null)?"0":$_GET['cur'];
// ----- SQL data PKH
$sel2=mysql_query("select No, bHarian.Judul, bHarian.Gambar, bHarian.Isi, bHarian.Tgl, bHarian.Jenis, bHarian.NRP from bHarian order by bHarian.Tgl Desc limit $curRec,$maxRec")
or die ("Salah SQL 1!");
// ------ ambil isi masing-masing record
while ($row = mysql_fetch_object($sel2))
{
		// ----- mengambil isi setiap kolom
		$No=$row->No;
		$Judul=$row->Judul;
		$Gambar=$row->Gambar;
		$Isi=$row->Isi;
		$Tgl=$row->Tgl;
		$Jenis=$row->Jenis;
		$NRP=$row->NRP;
		$List=substr($Isi,0,150);

		// ------ menampilkan di layar browser
		echo("<table width=1020 border=0 align=center bgcolor=#78b103><tr><td bgcolor=#FFFFFF>");
		echo("<table width=100% border=0 ><tr><td><div align=center>$Jenis</td></tr>");
								   echo("<tr><td width=30% class=judul><div align=center>$Judul</td></tr>");
								   
								   echo("<tr><td width=30%><div align=center><img src='img/$Gambar' width=400 height=200/></td></tr>");
								   echo("<tr><td width=90% class=isi><div align=justify>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$List ");
								   echo("<a class=read href='Item.php?No=$No'>Selengkapnya</td></tr>");
								   echo("<tr><td width=10% class=publis><div align=center>Tanggal, $Tgl</td></tr></table>");
		echo("</td></tr></table></p>");
}
?>
  </td>
  </tr>
</p>
<tr>
                <td bgcolor="#666666"><div align="right">
                  <table width="100%" border="0" bgcolor="#78b103">
                    <tr>
                      <td><p><span class="style51">
                      <?
				  // get total Record from your table in database
					$tot=mysql_query("select count(*) as tot from bHarian")or die ("Salah SQL 2!");	
					$tot=mysql_fetch_row($tot);
					$tot=$tot[0];
					$lkPost="mJenis=".$mJenis;
					?>
                      <?=paging($curRec,$tot,$maxRec,$lkPost)?>
                        
                      </span></p></td>
                      <td><div align="right"></div></td>
                    </tr>
                  </table>

</body>
</html>