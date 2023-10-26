<?
session_start();
require('koneksi.php');
$koneksi=open_connection();

?>
<html>
<style type="text/css">
<!--
.style6 {color: #000000; font-weight: bold; font-family: "Courier New", Courier, monospace; font-size: 16px; }
#Layer1 {
	position:absolute;
	left:17px;
	top:85px;
	width:991px;
	height:39px;
	z-index:1;
}
.style9 {color: #000000; font-weight: bold; font-family: "Courier New", Courier, monospace; font-size: 18px; font-style: italic; }
.style14 {font-size: 12px}
.style15 {color: #0099FF}
-->
</style>
<body>
<form action="img/prssupload.php" method="post" enctype="multipart/form-data" name="form1" id="form1">
  <table width="600" border="0" bgcolor="#FFCC99">
    <tr>
      <td bgcolor="#CCFF99"><table width="100%" border="0">
          <tr>
            <td><div align="center"><a href="#"><span class="style9">Berita <? echo("$mJenis"); ?></span></a>
              <input name="mJenis" type="hidden" id="mJenis" value="<? echo("$mJenis"); ?>" />
            </div></td>
          </tr>
          <tr>
            <td><div align="center"><span class="style6">Judul</span>
                    <div align="center">
                      <input name="mJudul" type="text" id="mJudul" size="62" />
                    </div>
            </div>
                </label></td>
          </tr>
          <tr>
            <td><label>
                <div align="center" class="style6">Gambar</div>
              <div align="center">
                  <input name="foto" type="file" id="foto" size="48" />
              </div>
              <div align="center" class="style6"></div>
              </label></td>
          </tr>
          <tr>
            <td><label>
                <div align="center" class="style6">Isi</div>
              <div align="right">
                  <textarea name="mIsi" cols="100" rows="10" wrap="virtual" id="mIsi"></textarea>
              </div>
              <div align="center" class="style6"></div>
              </label></td>
          </tr>
          <tr>
            <td>&nbsp;</td>
          </tr>
      </table></td>
    </tr>
    <tr>
      <td bgcolor="#CCFF99"><span class="style14">
        <label>
          <span class="style15">Catatan : untuk Menambah Paragraf baru Ketik &quot; &lt;/p&gt; &quot;. </span></span>
          <div align="center">
            <input name="bSimpan" type="submit" id="bSimpan" value="Simpan" />
          </div>
      </label></td>
    </tr>
  </table>
</form>
</body>
</html>