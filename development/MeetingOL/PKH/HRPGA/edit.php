<?
session_start();
require("cek.php");
// ----- ambil isi dari file koneksi.php
require("../koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();
/////////////////////////////////////////////////////////////////////////////////////////////
$data1 = mysql_query ("select PKH.NoPKH, Departemen.DeptHead, PKH.nopkh, PKH.TglPK, SecDept.NamaSec, PKH.lokasi, PKH.sejak, PKH.instruksi_kerja, PKH.laporan_pelaksanaan, PKH.status, PKH.kondisi, PKH.lampiran from PKH, SecDept, Departemen where PKH.NoSec=SecDept.NoSec and SecDept.NoDept=Departemen.NoDept and NoPKH='$PKH'") or die ("Terdapat kesalahan pada perintah SQL!");
$d1=mysql_fetch_array($data1);
$NmSec=$d1[NamaSec];
if (($NmSec==$_SESSION[NamaSec]) or (($_SESSION[User]='KC08090') or ($_SESSION[User]='KB10035') or ($_SESSION[User]='KA06049') or ($_SESSION[User]='KC10047') or ($_SESSION[User]='6103041') or ($NmSec=='PIC'))) {

} 
else {
echo ("<BODY> 
<SCRIPT language='Javascript'> 
alert('Anda Tidak Berhak Mengedit Data Ini ...!!!'); 
close();
</SCRIPT> 
</BODY>");
}
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
            <td><form method="post" enctype="multipart/form-data" name="form1" target="upload_targetupload_target" id="form1" <? echo ("action=simpanU.php?PKH=$d1[NoPKH]"); ?>>
                  <table width="100%" border="0">
                    <tr>
                      <td class="style7"><div align="center">Form Edit PKH 
                        
                      </div></td>
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
                                      <td class="tText">
                                        
                                        <div align="right">
                                          <?
						echo $d1[DeptHead]
						
								?> 
                                          <strong class="style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Kpd : </strong><?php echo $NmSec ?>
                                          <input name="mKepada" type="hidden" id="mKepada" value="<?php echo $NmSec ?>" />
                                          </div></td></tr>
                                    <tr>
                                      <td width="26%" class="style5"><strong>Lokasi</strong></td>
                                      <td width="2%" class="style8">:</td>
                                      <td width="34%" class="style5"><div align="right">
                                        <input name="mLokasi" type="text" class="tArea" id="mLokasi" value="<?php echo $d1[lokasi]; ?>" size="16" />
                                      </div></td>
                                      </tr>
                                    <tr>
                                      <td class="style8">Sejak</td>
                                      <td class="style8">:</td>
                                      <td class="style5"><div align="right">
                                        <input name="mSejak" type="text" class="tArea" id="mSejak" value="<?php echo $d1[sejak]; ?>" size="12" />
                                        <input name="button" type="button" style="background-image:url(../images/Calendar.png); background-repeat:no-repeat; background-position:center; border:none;" onclick="pick('mSejak');" value="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" />
                                      </div></td>
                                      </tr>
                                    <tr>
                                      <td class="style8">Instruksi Kerja </td>
                                      <td class="style8">: </td>
                                      <td class="style5"><div align="right">
                                        <textarea name="mInstruksi" cols="70" rows="5" class="tArea" id="mInstruksi" style=""><?php echo $d1[instruksi_kerja]; ?></textarea>
                                      </div></td>
                                      </tr>
                                    <tr>
                                      <td class="style8">Laporan Pelaksanaan </td>
                                      <td class="style8">:</td>
                                      <td class="style5"><div align="right">
                                        <textarea name="mLaporan" cols="70" rows="5" class="tArea" id="mLaporan"><?php echo $d1[laporan_pelaksanaan]; ?></textarea>
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
                                          <option value="Open" <?php if (!(strcmp("Open", $d1[status]))) {echo "selected=\"selected\"";} ?>>open</option>
                                          <option value="Close" <?php if (!(strcmp("Close", $d1[status]))) {echo "selected=\"selected\"";} ?>>close</option>
                                          <option value="No Progress" <?php if (!(strcmp("No Progress", $d1[status]))) {echo "selected=\"selected\"";} ?>>no progress</option>
                                        </select>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Kondisi :
                                        <select name="mKondisi" id="mKondisi">
                                          <option value="0" <?php if (!(strcmp(0, $d1[kondisi]))) {echo "selected=\"selected\"";} ?>>0</option>
                                          <option value="1" <?php if (!(strcmp(1, $d1[kondisi]))) {echo "selected=\"selected\"";} ?>>1</option>
                                          <option value="2" <?php if (!(strcmp(2, $d1[kondisi]))) {echo "selected=\"selected\"";} ?>>2</option>
                                        </select></td>
                                    </tr>
                                    <tr>
                                      <td class="style8">Lampiran</td>
                                      <td class="style8">:
                                        <input name="mLampiran" type="file" onclick="MM_popupMsg('Nama File Harus tanpa Spasi . . . !!')" /></td>
                                    </tr>
                                    <tr>
                                      <td class="style8">&nbsp;</td>
                                      <td class="style8">&nbsp;</td>
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
