<?
session_start();
require("cek.php");
// ----- ambil isi dari file koneksi.php
require("../koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();
/*=====================================================================*/
$sel1=mysql_query("select nrp, NamaSec, User.NoSec, SecDept.NoDept, Departemen.DeptHead from User, SecDept, Departemen where User.NoSec=SecDept.NoSec and User.nrp='$_SESSION[User]' and SecDept.NoDept=Departemen.NoDept")or die ("Terdapat kesalahan pada perintah SQL!");
$d1=mysql_fetch_array($sel1);
//========================================
?>

<?
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

<script type="text/javascript" language="javascript">
<!--
function pick(tgt)
{
 window.open("../tool/kalender_pick.php?rand="+Math.random()+"&tgt="+tgt,"Kalender","width=500,height=400,alwaysRaised=yes,scrollbars=yes,directories=no,location=no,menubar=no,toolbar=no");
}
//-->
</script>
<html>
<style type="text/css">
<!--
.style2 {font-size: 16px; color: #FFFFFF; font-family: "DejaVu Sans", Courier, monospace; font-weight: bold; }
.style16 {color: #FFFFFF; font-family: "DejaVu Sans", Courier, monospace; font-size: 18px;}
.style9 {	font-size: 30px;
	color: #FFFFFF;
	font-family: "DejaVu Sans", Courier, monospace;
	font-weight: bold;
}
.style5 {color: #FFFFFF; font-family: "DejaVu Sans"}
.style51 {color: #333333; font-family: "DejaVu Sans"}
.style17 {color: #FFFFFF; font-family: "DejaVu Sans", Courier, monospace; font-size: 16px;}
.stylebtFile {background-image:url(../images/b_file.png); background-repeat:no-repeat; background-position:center; border:none;}
.stylebtEdit {background-image:url(../images/b_edit.png); background-repeat:no-repeat; background-position:center; border:none;}
.stylebtHapus {background-image:url(../images/b_drop.png); background-repeat:no-repeat; background-position:center; border:none;}
.style19 {color: #FFFFFF; font-style: italic; }
.style21 {font-family: "DejaVu Sans", Courier, monospace; font-weight: bold; font-size: 16px;}
-->
</style>

<!-- load css facebox style -->
<link rel="stylesheet" href="facebox/facebox.css" media="screen" type="text/css"/>

<!-- Load Jquery dan Facebox plugin -->
<script src="facebox/jquery.js" type="text/javascript"></script>
<script src="facebox/facebox.js" type="text/javascript"></script>

<!-- inisiasi -->
<script type="text/javascript">
	jQuery(document).ready(function($) {
	$('a[rel*=facebox]').facebox({
	loading_image : 'facebox/loading.gif',
	close_image   : 'facebox/closelabel.gif'
	}) 
})
</script>

<script type="text/JavaScript">
<!--
function MM_openBrWindow(theURL,winName,features) { //v2.0
  window.open(theURL,winName,features);
}

function MM_jumpMenu(theURL,winName,features){ //v3.0
  window.open(theURL.options[theURL.selectedIndex].value,winName,features);
  if (restore) theURL.selectedIndex=0;
}
//-->
</script>
<body bgcolor="#009933">

<table width="100%" border="0" bgcolor="#009900">
  <tr>

  </tr>
  <table width="100%" border="0" align="center" bgcolor="#FFFFFF">
    <tr>
      <td><table width="100%" border="0" align="center" bgcolor="#00843B">
          <tr>
            <td height="28"><form action=""post" name="fFilter" target="_self" id="fFilter">
              <table width="100%" border="0" bgcolor="#FFFFFF">
                <tr>
                  <td><table width="100%" border="0" bgcolor="#333333">
                      <tr>
                        <td width="47%" class="style2"> <span class="style19">.:: PKH <a class="style2"> ::.</a></span></td>
                        <td width="39%"><div align="right" class="style2"><span class="style19">.::</span> Report <a class="style2">::. </a></div></td>
                        <td width="14%"><div align="right">
                            <select name="Jmenu" onChange="MM_jumpMenu(this,'Report','width=1000,height=590,scrollbars=yes')">
                              <option value="#"> </option>
                              <option value="../../ReportServer/PKH/PKH_Allrpt.php">Lap_PKH</option>
                              <option value="../../ReportServer/PKH/Diagram_Secctb.php">Chart_StatusLaporan</option>
                            </select>
                        </div></td>
                      </tr>
                  </table></td>
                </tr>
              </table>
              <table width="100%" border="0" bgcolor="#FFFFFF">
                <tr>
                  <td><table width="100%" border="0" bgcolor="#333333">
                    <tr>
                      <td width="309" height="59"><div align="center"><img src="../Images/logo1.JPG" width="288" height="35"></div></td>
                      <td width="531"><div align="center"><span class="style9"><marquee>PERINTAH KERJA HARIAN(PKH)</marquee></span></div></td>
                      <td width="220"><table width="220" border="0">
                          <tr>
                            <td width="214"><div align="center"><span class="style17">Area: All</span><span class="style2"> &nbsp;&nbsp;&nbsp;</span></div></td>
                          </tr>
                          <tr>
                            <td height="29"><div align="right"><span class="style16">Tgl :<span class="style2">
                              <input name="pick_date" type="text" id="pick_date" value="<? if($pick_date==''){echo date('Y-m-d');} else echo $pick_date; ?>" size="12" />
                              <input name="Button" type="button" style="background-image:url(../images/Calendar.png); background-repeat:no-repeat; background-position:center; border:none;" onClick="pick('pick_date');" value="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" />
                            </span></span></div></td>
                          </tr>
                      </table></td>
                    </tr>
                  </table></td>
                </tr>
                <tr>
                  <td><table width="100%" border="0" bgcolor="#333333">
                    <tr>
                      <td width="41%"><span class="style2"><a>Dari </a>: <? if($mDeptHead==''){echo $d1[DeptHead];} else echo $mDeptHead ?></span>:
                        
                        <input name="mDeptHead" type="hidden" id="mDeptHead" value="<? if($mDeptHead==''){echo $d1[DeptHead];} else echo $mDeptHead ?>"></td>
                      <td width="43%"><span class="style5">Kepada :
                          <select name="mKepada" id="mKepada" lang="" onChange="this.form.submit()">
                            <option value="" <?php if (!(strcmp("", $mKepada))) {echo "selected=\"selected\"";} ?>></option>
                            <option value="HR" <?php if (!(strcmp("HR", $mKepada))) {echo "selected=\"selected\"";} ?>>HR</option>
                            <option value="PERS" <?php if (!(strcmp("PERS", $mKepada))) {echo "selected=\"selected\"";} ?>>PERS</option>
                            <option value="OTD" <?php if (!(strcmp("OTD", $mKepada))) {echo "selected=\"selected\"";} ?>>OTD</option>
                            <option value="GA" <?php if (!(strcmp("GA", $mKepada))) {echo "selected=\"selected\"";} ?>>GA</option>
                            <option value="CIVIL" <?php if (!(strcmp("CIVIL", $mKepada))) {echo "selected=\"selected\"";} ?>>CIVIL</option>
                            <option value="IT" <?php if (!(strcmp("IT", $mKepada))) {echo "selected=\"selected\"";} ?>>IT</option>
                            <option value="INS" <?php if (!(strcmp("INS", $mKepada))) {echo "selected=\"selected\"";} ?>>INS</option>
                            <option value="CDV" <?php if (!(strcmp("CDV", $mKepada))) {echo "selected=\"selected\"";} ?>>CDV</option>
                            <option value="SEC" <?php if (!(strcmp("SEC", $mKepada))) {echo "selected=\"selected\"";} ?>>SEC</option>
                            <option value="PIC" <?php if (!(strcmp("PIC", $mKepada))) {echo "selected=\"selected\"";} ?>>PIC</option>
                          </select>
                      </span></td>
                      <td width="16%"><div align="right"></div></td>
                      </tr>
                  </table>                  </td>
                </tr>
              </table>
              </form></td>
          </tr>
          <tr>
            <td height="28"><table width="100%" border="0" bgcolor="#FFFFFF">
              <tr>
                <td>
<?php

$maxRec=10;// maximum record per page
	$curRec=($_GET['cur']==null)?"0":$_GET['cur'];
// ----- SQL data PKH
$sel2=mysql_query("select PKH.nopkh, PKH.TglPK, SecDept.NamaSec, PKH.lokasi, PKH.sejak, PKH.instruksi_kerja, PKH.laporan_pelaksanaan, PKH.status, PKH.kondisi, PKH.lampiran, PKH.file, PKH.type from PKH, SecDept, Departemen where PKH.NoSec=SecDept.NoSec and SecDept.NoDept=Departemen.NoDept and SecDept.NamaSec='$mKepada' and Departemen.DeptHead='$mDeptHead' and PKH.TglPK<='$pick_date' order by PKH.Sejak limit $curRec,$maxRec")
or die ("Terdapat kesalahan pada perintah SQL!");
// ------ buat tampilan tabel
echo("<table width=100%  border=0 bgcolor=#009900>");
echo("<td bgcolor=#333333><div align=center><span class=style2>No</span></td>
                              <td bgcolor=#333333><div align=center><span class=style2>&nbsp;&nbsp;&nbsp;&nbsp;Lokasi&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
							  <td bgcolor=#333333><div align=center><span class=style2>&nbsp;&nbsp;&nbsp;&nbsp;Sejak&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
                              <td width=35% bgcolor=#333333><div align=center><span class=style2>Instruksi Kerja</span></td>
                              <td width=35% bgcolor=#333333><div align=center><span class=style2>Laporan Pelaksanaan</span></td>
                              <td width=10% bgcolor=#333333><div align=center><span class=style2>Pendukung</span></td>
                              <td bgcolor=#333333><div align=center><span class=style2>Edit</span></td>");
// ------ ambil isi masing-masing record
while ($row = mysql_fetch_object($sel2))
{
		// ----- mengambil isi setiap kolom
		$nomor = $nomor + 1;
		$nopkh=$row->nopkh;
		$lokasi=$row->lokasi;
		$sejak=$row->sejak;
		$instruksi_kerja=$row->instruksi_kerja;
		$laporan_pelaksanaan=$row->laporan_pelaksanaan;
		$status=$row->status;
		$type=$row->type;

		// ------ menampilkan di layar browser
		echo("<tr><div align=center><td bgcolor=#666666 class=style5>$nomor</td>
			<td bgcolor=#666666 class=style5>$lokasi</td>");
			if(date('Y-m-d')==$sejak){
			    echo("<td bgcolor=#66FFFF class=style51>$sejak</td>");
				} else {
				echo("<td bgcolor=#666666 class=style5>$sejak</td>");
				}
			echo("<td bgcolor=#666666 class=style5>$instruksi_kerja</td>");
			if($status=='Close'){
				echo("<td bgcolor=#CCFF99 class=style51>$laporan_pelaksanaan</td>");
				} else
			if($status=='Open'){
			    echo("<td bgcolor=#FFFF99 class=style51>$laporan_pelaksanaan</td>");
				} else
			if($status=='No Progress'){
			    echo("<td bgcolor=#FFCCFF class=style51>$laporan_pelaksanaan</td>");
				}
			echo("<td bgcolor=#666666 class=style5><a class=style5 href='download.php?NPK=$nopkh'>$type</a></td>
			<td bgcolor=#D4D0C8 class=style5><a href=edit.php?PKH=$nopkh rel=facebox><img src=../images/b_Edit.png></a>&nbsp;<a href=hapus.php?PKH=$nopkh rel=facebox><img src=../images/b_Drop.png></a>
			</td>
			</tr>");
}
echo("</table>");
?></td>
              </tr>
              <tr>
                <td bgcolor="#666666"><div align="right">
                  <table width="100%" border="0" bgcolor="#D4D0C8">
                    <tr>
                      <td><span class="style51">Halaman : </span> <span class="style51">
                      <?
				  // get total Record from your table in database
					$tot=mysql_query("select count(NoPKH) as tot from PKH, SecDept, Departemen where PKH.NoSec=SecDept.NoSec and SecDept.NoDept=Departemen.NoDept and SecDept.NamaSec='$mKepada' and Departemen.DeptHead='$mDeptHead' and PKH.TglPK<='$pick_date'");	
					$tot=mysql_fetch_row($tot);
					$tot=$tot[0];
					$lkPost="pick_date=".$pick_date."&mDeptHead=".$mDeptHead."&mKepada=".$mKepada;
					?>
                      <?=paging($curRec,$tot,$maxRec,$lkPost)?>

					  </span></td>
                      <td><div align="right"><span class="style5">
                        <?
				  echo ("<input name=btTambah type=submit id=btTambah onClick=MM_openBrWindow('baru.php?Sec=$mKepada','Baru','width=700,height=480') value=Tambah>");
				  ?>
                      </span></div></td>
                    </tr>
                  </table>
                  </div></td>
              </tr>
            </table></td>
          </tr>
      </table>
        <table width="100%" border="0" bgcolor="#00843B">
          <tr>
            <td><table width="100%" border="0" bgcolor="#FFFFFF">
                <tr>
                  <td width="50%"><table width="100%" border="0" bgcolor="#009933">
                    <tr>
                      <td colspan="2"><table width="100%" border="0" bgcolor="#666666">
                        <tr>
                          <td class="style19">Catatatan :</td>
                        </tr>
                        <tr>
                          <td class="style17"><table width="100%" border="0">
                              <tr>
                                <td class="style19">* Update progress dan laporkan kepada DH</td>
                              </tr>
                          </table></td>
                        </tr>
                      </table></td>
                    </tr>
                    <tr>
                      <td><table width="100%" border="0" bgcolor="#666666">
                        <tr>
                          <td class="style5">Dibuat,</td>
                        </tr>
                        <tr>
                          <td class="style5">Oleh &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:
                            <?
						if($mDeptHead==''){echo $d1[DeptHead];} else echo $mDeptHead

								?></td>
                        </tr>
                        <tr>
                          <td class="style5">Kepada &nbsp;:
                            <?
						if($mKepada==''){echo $d1[NamaSec];}else echo $mKepada;

								?></td>
                        </tr>
                      </table></td>
                      <td><table width="100%" height="71" border="0" bgcolor="#666666">
                        <tr>
                          <td class="style5">Paraf :</td>
                        </tr>
                        <tr>
                          <td>&nbsp;</td>
                        </tr>
                      </table></td>
                    </tr>
                  </table></td>
                  <td width="50%"><table width="100%" border="0" bgcolor="#009933">
                    <tr>
                      <td colspan="2"><table width="100%" border="0" bgcolor="#666666">
                        <tr>
                          <td><span class="style19">Catatatan :</span></td>
                        </tr>
                        <tr>
                          <td>
                            
                            <div align="right">
                              <table width="80%" border="0">
                                <tr>
                                  <td width="9%" bgcolor="#66FFFF">&nbsp;</td>
                                    <td width="13%"><span class="style19">: New </span></td>
                                    <td width="9%" bgcolor="#CCFF99">&nbsp;</td>
                                    <td width="15%"><span class="style19">: Close</span></td>
                                    <td width="9%" bgcolor="#FFFF99">&nbsp;</td>
                                    <td width="13%"><span class="style19"> : Open</span></td>
                                    <td width="8%" bgcolor="#FFCCFF">&nbsp;</td>
                                    <td width="24%"><span class="style19">: No Progress</span></td>
                                  </tr>
                              </table>
                            </div></td></tr>
                      </table></td>
                    </tr>
                    <tr>
                      <td><table width="100%" border="0" bgcolor="#666666">
                        <tr>
                          <td><span class="style5">Dilaporakan,</span></td>
                        </tr>
                        <tr>
                          <td><span class="style5">Oleh &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:
                            PIC </span></td>
                        </tr>
                        <tr>
                          <td><span class="style5">Kepada &nbsp;:

                              <?
						if($mDeptHead==''){echo $d1[DeptHead];} else echo $mDeptHead

								?>
                          </span></td>
                        </tr>
                      </table></td>
                      <td><table width="100%" height="71" border="0" bgcolor="#666666">
                        <tr>
                          <td class="style5">Paraf :</td>
                        </tr>
                        <tr>
                          <td>&nbsp;</td>
                        </tr>
                      </table></td>
                    </tr>
                  </table></td>
                </tr>
              </table></td>
          </tr>
        </table></td>
    </tr>
</table>
</body>
</html>