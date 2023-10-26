<?
session_start();
require("cek.php");
// ----- ambil isi dari file koneksi.php
require("../koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();
$IDUser = $_SESSION[USER];
/*=====================================================================*/
if ((!$_SESSION[User]=='6100077') or (!$_SESSION[User]=='KC07103') or (!$_SESSION[User]=='6195011')) {
$sel1=mysql_query("select nrp, NamaSec, User.NoSec, SecDept.NoDept, Departemen.DeptHead from User, SecDept, Departemen where User.NoSec=SecDept.NoSec and User.nrp='$_SESSION[User]' and SecDept.NoDept=Departemen.NoDept")or die ("Terdapat kesalahan pada perintah SQL!"); } else {
$sel1=mysql_query("Select Departemen.DeptHead from Departemen where Departemen.NoDept='2'")or die ("Terdapat kesalahan pada perintah SQL!");
}
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
.txUp1 {font-size: 10px; color: #66FFFF; font-family: "DejaVu Sans"}
.txUp2 {font-size: 10px; color: #FFFFFF; font-family: "DejaVu Sans"}
.style51 {color: #333333; font-family: "DejaVu Sans"}
.style17 {color: #FFFFFF; font-family: "DejaVu Sans", Courier, monospace; font-size: 16px;}
.stylebtKondisi1 {background-image:url(../images/Danger1.png); background-repeat:no-repeat; background-position:center; border:none;}
.stylebtKondisi2 {background-image:url(../images/Danger2.png); background-repeat:no-repeat; background-position:center; border:none;}
.stylebtEdit {background-image:url(../images/b_edit.png); background-repeat:no-repeat; background-position:center; border:none;}
.stylebtHapus {background-image:url(../images/b_drop.png); background-repeat:no-repeat; background-position:center; border:none;}
.style19 {color: #FFFFFF; font-style: italic; }
.style21 {font-family: "DejaVu Sans", Courier, monospace; font-weight: bold; font-size: 16px;}
body {
	background-image: url(../Images/bg1.jpg);
	background-repeat: repeat-x;
}
-->
</style>
<script type="text/JavaScript">
<!--
function MM_openBrWindow(theURL,winName,features) { //v2.0
  window.open(theURL,winName,features);
}

function MM_jumpMenu(theURL,winName,features){ //v3.0
  window.open(theURL.options[theURL.selectedIndex].value,winName,features);
  if (restore) theURL.selectedIndex=0;
}

function MM_displayStatusMsg(msgStr) { //v1.0
  status=msgStr;
  document.MM_returnValue = true;
}
//-->
</script>
<body bgcolor="">

<table width="100%" border="0" bgcolor="#009900">
  <tr>

  </tr>
  <table width="100%" border="0" align="center" bgcolor="#FFFFFF">
    <tr>
      <td><table width="100%" border="0" align="center" background="../Images/bg1.jpg">
          <tr>
            <td height="28"><form action=""post" name="fFilter" target="_self" id="fFilter">
              <table width="100%" border="0" bgcolor="#FFFFFF">
                <tr>
                  <td><table width="100%" border="0" bgcolor="#333333">
                      <tr>
                        <td width="47%" class="style2"><a class="style2"> <span class="style19">.::</span><? echo ("<a class=style19> $_SESSION[User]</a>"); ?> ::. </a> || <span class="style19">.::</span><a class="style2"><? echo ("<a class=style19> $_SESSION[SNama]</a>"); ?> ::.</a></td>
                        <td width="39%"><div align="right" class="style2"><span class="style19">.::</span> Report :<a class="style2">:.</a> </div></td>
                        <td width="14%"><div align="right">
                            <select name="Jmenu" onChange="MM_jumpMenu(this,'Report','width=1000,height=590,scrollbars=yes')">
                              <option value="#"> </option>
                              <option value="../../ReportServer/PKH/FAT/Open_PerPerioderpt.php">PKH_Open</option>
                              <option value="../../ReportServer/PKH/FAT/Close_PerPerioderpt.php">PKH_CloseOff</option>
                              <option value="../../ReportServer/PKH/FAT/Diagram_Secctb.php">Chart_StatusLaporan</option>
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
                            <td width="214"><span class="style17">Area: All</span><span class="style2"> &nbsp;&nbsp;&nbsp;</span></td>
                          </tr>
                          <tr>
                            <td height="29"><span class="style16">Tgl :<span class="style2">
                              <input name="pick_date" type="text" id="pick_date" value="<? if($pick_date==''){echo date('Y-m-d');} else echo $pick_date; ?>" size="12" />
                              <input name="Button" type="button" style="background-image:url(../images/Calendar.png); background-repeat:no-repeat; background-position:center; border:none;" onClick="pick('pick_date');" value="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" />
                            </span></span></td>
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
                      <td width="37%"><span class="style2">Kepada : <span class="style5">
                      <label></label>
                      <select name="mKepada" id="mKepada" lang="" onChange="this.form.submit()">
					    <option value="" <?php if (!(strcmp("", $mKepada))) {echo "selected=\"selected\"";} ?>></option>
                        <option value="Finance-Tax" <?php if (!(strcmp("Finance-Tax", $mKepada))) {echo "selected=\"selected\"";} ?>>Finance &amp; Tax</option>
                        <option value="Cashier" <?php if (!(strcmp("Cashier", $mKepada))) {echo "selected=\"selected\"";} ?>>Cashier</option>
                        <option value="Cost-AP" <?php if (!(strcmp("Cost-AP", $mKepada))) {echo "selected=\"selected\"";} ?>>Cost &amp; AP</option>
                        <option value="Budget" <?php if (!(strcmp("Budget", $mKepada))) {echo "selected=\"selected\"";} ?>>Budget</option>
			<option value="DC" <?php if (!(strcmp("DC", $mKepada))) {echo "selected=\"selected\"";} ?>>DC</option>
                      </select>
                      </span></span></td>
                      <td width="22%"><label>
                        <div align="right">
                          <input type="submit" name="Submit" value="F5 (Refresh)" accesskey="r">
                          </div>
                      </label></td>
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
if ($Pesan=='') {
$sel2=mysql_query("select PKH.nopkh, PKH.TglPK, SecDept.NamaSec, PKH.lokasi, PKH.sejak, PKH.instruksi_kerja, PKH.laporan_pelaksanaan, PKH.status, PKH.kondisi, PKH.lampiran, PKH.file, PKH.type, date(now()) as tglskrg, date(now())-date(PKH.tglupdate) as updateby, PKH.tglupdate,PKH.userupdate from PKH, SecDept, Departemen where PKH.NoSec=SecDept.NoSec and SecDept.NoDept=Departemen.NoDept and PKH.On<>0 and SecDept.NamaSec='$mKepada' and Departemen.DeptHead='$mDeptHead' and PKH.TglPK<='$pick_date' order by PKH.Sejak limit $curRec,$maxRec")
or die ("Terdapat kesalahan pada perintah SQL!"); } else {
$sel2=mysql_query("select PKH.nopkh, PKH.TglPK, SecDept.NamaSec, PKH.lokasi, PKH.sejak, PKH.instruksi_kerja, PKH.laporan_pelaksanaan, PKH.status, PKH.kondisi, PKH.lampiran, PKH.file, PKH.type, date(now()) as tglskrg, date(now())-date(PKH.tglupdate) as updateby, PKH.tglupdate,PKH.userupdate from PKH, SecDept, Departemen where PKH.NoSec=SecDept.NoSec and SecDept.NoDept=Departemen.NoDept and Departemen.DeptHead='$d1[DeptHead]' and PKH.TglPK<= Date(Now()) and nopkh='$Pesan' order by PKH.Sejak limit $curRec,$maxRec")
or die ("Terdapat kesalahan pada perintah SQL!"); 
require("../../Tools/config.php");
//set sudah dibaca = Y kalau sudah dibaca
$update = mysql_query("UPDATE tabel_pesan SET sudahbaca='Y'
WHERE nomor='$noPesan' AND kepada='$_SESSION[NamaSec]'"); }
// ------ buat tampilan tabel
echo("<table width=100%  border=0 bgcolor=#009900>");
echo("<td bgcolor=#333333><div align=center><span class=style2>No</span></td>
                              <td bgcolor=#333333><div align=center><span class=style2>&nbsp;&nbsp;&nbsp;&nbsp;Lokasi&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
							  <td bgcolor=#333333><div align=center><span class=style2>&nbsp;&nbsp;&nbsp;&nbsp;Sejak&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
                              <td width=35% bgcolor=#333333><div align=center><span class=style2>Instruksi Kerja</span></td>
                              <td width=35% bgcolor=#333333><div align=center><span class=style2>Laporan Pelaksanaan</span></td>
                              <td width=5% bgcolor=#333333><div align=center><span class=style2>Pendukung</span></td>
							  <td width=5% bgcolor=#333333><div align=center><span class=style2>Update</span></td>
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
		$kondisi=$row->kondisi;
		$type=$row->type;
		$userupdate=$row->userupdate;
		$tglskrg=$row->tglskrg;
		$tglupdate=$row->tglupdate;
		$updateby=$row->updateby;

		// ------ menampilkan di layar browser
		echo("<tr><div align=center><td bgcolor=#666666 class=style5>$nomor</td>
			<td bgcolor=#666666 class=style5>$lokasi</td>");
			if($tglskrg==$sejak){
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
			if($kondisi=='1'){	
				echo("<td bgcolor=#666666 class=stylebtKondisi1><a class=style5 href='download.php?NPK=$nopkh'>$type</a></td>");
			} else if($kondisi=='2'){
				echo("<td bgcolor=#666666 class=stylebtKondisi2><a class=style5 href='download.php?NPK=$nopkh'>$type</a></td>");
			} else {
				echo("<td bgcolor=#666666 class=style5><a class=style5 href='download.php?NPK=$nopkh'>$type</a></td>");
			}
			if($updateby<='1'){
			echo("<td bgcolor=#666666 class=txUp1><div align=center>$userupdate $tglupdate</td>");
			} else {
			echo("<td bgcolor=#666666 class=txUp2><div align=center>$userupdate $tglupdate</td>");
			}
			echo("<td bgcolor=#D4D0C8 class=style5><input type=submit class=stylebtEdit onClick=MM_openBrWindow('edit.php?PKH=$nopkh','Edit','width=700,height=460') value=&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;>&nbsp;<input type=submit class=stylebtHapus onClick=MM_openBrWindow('hapus.php?PKH=$nopkh','Hapus','width=600,height=390') value=&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;>
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
					$tot=mysql_query("select count(NoPKH) as tot from PKH, SecDept, Departemen where PKH.NoSec=SecDept.NoSec and SecDept.NoDept=Departemen.NoDept and PKH.On<>0 and SecDept.NamaSec='$mKepada' and Departemen.DeptHead='$mDeptHead' and PKH.TglPK<='$pick_date'");	
					$tot=mysql_fetch_row($tot);
					$tot=$tot[0];
					$lkPost="pick_date=".$pick_date."&mDeptHead=".$mDeptHead."&mKepada=".$mKepada;
					?>
                      <?=paging($curRec,$tot,$maxRec,$lkPost)?>

					  <a href="#" onMouseOver="MM_displayStatusMsg('Update By . .');return document.MM_returnValue"></a></span></td>
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
                          <td class="style19">Catatan :</td>
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
                  <td width="50%"><table width="100%" border="0" background="../Images/bg1.jpg">
                    <tr>
                      <td colspan="2"><table width="100%" border="0" bgcolor="#666666">
                        <tr>
                          <td><span class="style19">Catatan :</span></td>
                        </tr>
                        <tr>
                          <td>
                            
                            <div align="right">
                              <table width="82%" border="0">
                                <tr>
                                  <td width="10%" bgcolor="#66FFFF">&nbsp;</td>
                                    <td width="13%"><span class="style19">: New </span></td>
                                    <td width="9%" bgcolor="#CCFF99">&nbsp;</td>
                                    <td width="13%"><span class="style19">: Close</span></td>
                                    <td width="9%" bgcolor="#FFFF99">&nbsp;</td>
                                    <td width="13%"><span class="style19"> : Open</span></td>
                                    <td width="9%" bgcolor="#FFCCFF">&nbsp;</td>
                                    <td width="24%"><span class="style19">: No Progress</span></td>
                                  </tr>
                              </table>
                            </div></td></tr>
                      </table></td>
                    </tr>
                    <tr>
                      <td><table width="100%" border="0" bgcolor="#666666">
                        <tr>
                          <td><span class="style5">Dilaporkan,</span></td>
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