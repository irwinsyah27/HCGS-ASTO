<?
session_start();
require("cek.php");
// ----- ambil isi dari file koneksi.php
require("../koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();

$NmSec=$Sec;
if (($NmSec==$_SESSION[NamaSec]) or (($_SESSION[User]=='KB06005') or ($_SESSION[User]=='kb06005') or ($_SESSION[User]=='6104048') or ($_SESSION[User]=='8402003'))) {

} else {
echo ("<BODY> 
<SCRIPT language='Javascript'> 
alert('Anda Tidak Berhak Menambah Data Ini ...!!!'); 
close();
</SCRIPT> 
</BODY>");
}
/////////////////////////////////////////////////////////////////////////////////////////////
$data1 = mysql_query ("select Departemen.DeptHead from SecDept, Departemen where SecDept.NoDept=Departemen.NoDept and SecDept.NamaSec='$Sec'") or die ("Terdapat kesalahan pada perintah SQL!");
$d1=mysql_fetch_array($data1);
?>

<script>
function pick(tgt)
{
 window.open("../tool/kalender_pick.php?rand="+Math.random()+"&tgt="+tgt,"Kalender","width=500,height=400,alwaysRaised=yes,scrollbars=yes,directories=no,location=no,menubar=no,toolbar=no");
}
//-->
</script>

<style type="text/css">
<!--
.tArea {font-family: "DejaVu Sans"}
.tText {color: #FFFFFF; font-family: "DejaVu Sans"}
.style5 {color: #FFFFFF}
.style6 {color: #000000; font-weight: bold;}
.style7 {color: #FFFFFF; font-family: "Courier New", Courier, monospace; font-weight: bold; font-size: 24px; }
.style8 {color: #FFFFFF; font-weight: bold; }
-->
</style>
<script type="text/JavaScript">
<!--
function MM_popupMsg(msg) { //v1.0
  alert(msg);
}
//-->
</script>
<table width="538" border="5" align="center" bgcolor="#00843B">
  <tr>
    <td width="532"><table width="100%" border="0" bgcolor="#FFFFFF">
      <tr>
        <td><table width="100%" border="0" bgcolor="#00843B">
          <tr>
            <td><form <? echo ("action=simpanB.php?PKH=$d1[NoPKH]"); ?> method="post" enctype="multipart/form-data" name="form1" id="form1">
                  <table width="100%" border="0">
                    <tr>
                      <td class="style7"><div align="center">Form Input PKH </div></td>
                    </tr>
                  </table>
                  <table width="100%" border="0" bordercolor="#FFFFFF">
                    <tr>
                      <td><table width="100%" height="100%" border="0">
                        <tr>
                          <td><table width="100%" border="0" bgcolor="#FFFFFF">
                              <tr>
                                <td><table width="100%" border="0" bgcolor="#00843B">
                                  <tr>
                                    <td class="style5"><strong class="style8">Oleh </strong></td>
                                    <td class="style8"><strong class="style8">: </strong></td>
                                    <td class="style5"><div align="right" class="tText"><?
						echo $d1[DeptHead]
						
								?>
                                        <strong class="style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Kpd : </strong><?php echo $Sec ?>
                                        <input name="mKepada" type="hidden" id="mKepada" value="<?php echo $Sec ?>" />
                                    </div></td>
                                  </tr>
                                    
                                    <tr>
                                      <td width="26%" class="style5"><strong>Lokasi</strong></td>
                                      <td width="2%" class="style8">:</td>
                                      <td width="34%" class="style5"><div align="right">
                                        <input name="mLokasi" type="text" class="tArea" id="mLokasi" size="16" />
                                      </div></td>
                                      </tr>
                                    <tr>
                                      <td class="style8">Sejak</td>
                                      <td class="style8">:</td>
                                      <td class="style5"><div align="right">
                                        <input name="mSejak" type="text" class="tArea" id="mSejak" value="<?php echo date('Y-m-d'); ?>" size="12" />
                                        <input name="button" type="button" style="background-image:url(../images/Calendar.png); background-repeat:no-repeat; background-position:center; border:none;" onclick="pick('mSejak');" value="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" />
                                      </div></td>
                                      </tr>
                                    <tr>
                                      <td class="style8">Instruksi Kerja </td>
                                      <td class="style8">: </td>
                                      <td class="style5"><div align="right">
                                        <textarea name="mInstruksi" cols="70" rows="5" class="tArea" id="mInstruksi"></textarea>
                                      </div></td>
                                      </tr>
                                    <tr>
                                      <td class="style8">Laporan Pelaksanaan </td>
                                      <td class="style8">:</td>
                                      <td class="style5"><div align="right">
                                        <textarea name="mLaporan" cols="70" rows="5" class="tArea" id="mLaporan"></textarea>
                                      </div></td>
                                      </tr>


                                </table></td>
                              </tr>
                          </table></td>
                        </tr>
                        <tr>
                          <td><table width="100%" border="0" bgcolor="#FFFFFF">
                              <tr>
                                <td><table width="100%" border="0" bgcolor="#00843B">
                                    <tr>
                                      <td width="48%" class="style8">Status</td>
                                      <td width="52%" class="style8">:                                        
                                        <select name="mStatus" class="tArea" id="mStatus">
                                          <option value="open" <?php if (!(strcmp("open", "no progress"))) {echo "selected=\"selected\"";} ?>>Open</option>
                                          <option value="close" <?php if (!(strcmp("close", "no progress"))) {echo "selected=\"selected\"";} ?>>Close</option>
                                          <option value="no progress" <?php if (!(strcmp("no progress", "no progress"))) {echo "selected=\"selected\"";} ?>>No Progress</option>
                                        </select>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Kondisi :
<label>
<select name="select" disabled="disabled">
  <option value="0">0</option>
  <option value="1">1</option>
  <option value="2">2</option>
</select>
</label></td>
                                    </tr>
                                    <tr>
                                      <td class="style8">Lampiran</td>
                                      <td class="style8">:
                                        <input name="mLampiran" type="file" id="mLampiran" onclick="MM_popupMsg('Nama File Harus tanpa Spasi . . . !!')" /></td>
                                    </tr>

                                </table></td>
                              </tr>
                          </table></td>
                        </tr>
                      </table></td>
                    </tr>
                    <tr>
                      <td><div align="center">
                        <input name="Submit" type="submit" class="style6"style="background-image:url(../images/b_save.png); background-repeat:no-repeat; background-position:right; border:none;" value="Simpan   " />
                      </div></td>
                    </tr>
                  </table>
                  </form>
                </td>
          </tr>
        </table></td>
      </tr>
    </table></td>
  </tr>
</table>
