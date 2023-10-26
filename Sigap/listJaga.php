<?
session_start();
//require("cek.php");
// ----- ambil isi dari file koneksi.php
require("tools/koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Untitled Document</title>
<style type="text/css">
<!--
body {
	background-image: url();
}
.style1 {
	font-size: 18px;
	font-weight: bold;
	color: #3333FF;
}
.text {font-size: 14px; font-family: "DejaVu Sans"}
.style2 {color: #EEEEEE}
-->
</style>
<script language="javascript">     
function Delete(No)
	{
	var konfirmasi = confirm("Anda Yakin ?");
	if (konfirmasi == true)
	  {
	  alert("Data dihapus !");
	  location.href="listJaga.php?bDelete="+No; 
	  }
	else
	  {
	  location.href="listJaga.php";
	  }
	}
</script>
<script type="text/javascript" src="stmenu.js"></script>
</head>
<body>
<table width="699" border="0" align="center" background="Images/MainPageBackground.jpg">
  <tr>
    <td width="671"><form action="" method="get" name="form1" target="_self" id="form1">
      <table width="100%" border="0">
        <tr>
          <td><table width="100%" border="0">
              <tr>
                <td width="59%"><div align="right"><span class="style1">
                  <input name="hDate" type="hidden" id="hDate" value="<?  if($hDate=='') { echo $Date; } else { echo $hDate; } ?>" />
                  <input name="hPos" type="hidden" id="hPos" value="<? if($hPos=='') { echo $Pos; } else { echo $hPos; } ?>" />
                  SECURITY POS <? if($hPos=='') { echo $Pos; } else { echo $hPos; } ?></span> </div></td>
                <td width="41%"><div align="right"><span class="style1">
                    <? if(($hDate=='') and ($hPos=='')) {$hDate=$Date; $hPos=$Pos;} ?>
                    <?
		  if (($_SESSION[User]=='KC10047') or ($_SESSION[User]=='TA11014') or ($_SESSION[User]=='6103041')) {
		  echo ("<input name=bInsert type=submit id=bInsert value=Insert /></p>");
		  } ?>
                    <input type="submit" name="Submit" value="F5 (Refresh)" accesskey="r" />
                  </span></div></td>
              </tr>
          </table></td>
        </tr>
        <tr>
          <td>
<? if($bInsert=='Insert'){ echo ("</p>
<table width=450 border=0 align=center>
  <tr>
    <td width=49>NRP</td>
    <td width=173><strong>:</strong><select name=tNrp id=tNrp>");
  $sCB1=mssql_query("Select NRP from Petugas");
  while ($row2 = mssql_fetch_object($sCB1))
  {
	$NRP=$row2->NRP;
	echo("<option value='$NRP'>$NRP</option>");
  }
  echo ("</select>
  </td>
    <td width=53>Mulai</td>
    <td width=182><strong>:</strong> 
    <input name=tJam1 type=text id=tJam1 value=''/></td>
  </tr>
  <tr>
    <td>POS</td>
    <td><strong>:</strong><select name=tJaga id=tJaga>");
  $sCB2=mssql_query("Select NamaPos from POS where NamaPos LIKE '%$hPos%'");
  while ($row3 = mssql_fetch_object($sCB2))
  {
	$NamaPos=$row3->NamaPos;
	echo("<option value='$NamaPos'>$NamaPos</option>");
  }
  echo ("</select></td>
    <td>Sampai</td>
    <td><strong>: 
    </strong>
    <input name=tJam2 type=text id=tJam2 value=''/></td>
  </tr>
  <tr>
    <td colspan=4><div align=center>
      <input name=bSave type=submit id=bSave value=Save />
    </div></td>
  </tr>
</table>
");} ?>
<?
if ($Pos=='BRE') { $Pos='POS BRE';}
$sJagaP=mssql_query("select Petugas.NRP, Petugas.Nama, Petugas.Jabatan, Petugas.Anggota, PetugasJaga.No, CAST(CAST(datepart(HOUR,PetugasJaga.Jam1) as varchar)+':'+CAST(datepart(MINUTE,PetugasJaga.Jam1) as varchar) AS varchar) AS Jam1, CAST(CAST(datepart(HOUR,PetugasJaga.Jam2) as varchar)+':'+CAST(datepart(MINUTE,PetugasJaga.Jam2) as varchar) AS varchar) AS Jam2, Jaga FROM petugasJaga, Petugas WHERE PETUGASJAGA.NRP=PETUGAS.NRP and PETUGASJAGA.Jaga LIKE '%$hPos%' and PETUGASJAGA.Jam1 BETWEEN '$hDate' and '$hDate 23:59:59.000'");
// ------ buat tampilan tabel
echo("<table width=100%  border=0 bgcolor=#99CCFF>");
echo("<td bgcolor=#336699><div align=center><span class=style2>No</span></td>
							  <td bgcolor=#336699><div align=center><span class=style2>NRP</span></td>
							  <td bgcolor=#336699><div align=center><span class=style2>Nama</span></td>
                              <td bgcolor=#336699><div align=center><span class=style2>Jabatan</span></td>
                              <td bgcolor=#336699><div align=center><span class=style2>Anggota</span></td>
                              <td bgcolor=#336699><div align=center><span class=style2>Mulai</span></td>
                              <td bgcolor=#336699><div align=center><span class=style2>Sampai</span></td>
							  <td bgcolor=#336699><div align=center><span class=style2>Pos</span></td>");
                              if (($_SESSION[User]=='KC10047') or ($_SESSION[User]=='TA11014') or ($_SESSION[User]=='6103041')) {
							  echo ("<td bgcolor=#336699><div align=center><span class=style2>@</span></td>");
							  }
		  					  
// ------ ambil isi masing-masing record
while ($row = mssql_fetch_object($sJagaP))
{
		// ----- mengambil isi setiap kolom
		
		$No=$row->No;
		$Nomor = $Nomor + 1;
		$NRP=$row->NRP;
		$Nama=$row->Nama;
		$Jabatan=$row->Jabatan;
		$Anggota=$row->Anggota;
		$Jam1=$row->Jam1;
		$Jam2=$row->Jam2;
		$Jaga=$row->Jaga;

		// ------ menampilkan di layar browser
		echo("<tr><div align=center>
		    <td bgcolor=#CFFFFF class=text><div align=Center>$Nomor</td>
			<td bgcolor=#CFFFFF class=text><div align=Center>$NRP</td>
			<td bgcolor=#CFFFFF class=text><div align=Center>$Nama</td>
			<td bgcolor=#CFFFFF class=text><div align=Center>$Jabatan</td>
			<td bgcolor=#CFFFFF class=text><div align=Center>$Anggota</td>
			<td bgcolor=#CFFFFF class=text><div align=Center>$Jam1</td>
			<td bgcolor=#CFFFFF class=text><div align=Center>$Jam2</td>
			<td bgcolor=#CFFFFF class=text><div align=Center>$Jaga</td>");
            if (($_SESSION[User]=='KC10047') or ($_SESSION[User]=='TA11014') or ($_SESSION[User]=='6103041') or ($_SESSION[User]=='0108748') or ($_SESSION[User]=='0108750')) {
			echo("<td width=23% bgcolor=#CFFFFF class=style5><div align=Center>
				  <input type=Button name=bDelete value=Delete onClick=Delete('$No'+'&hDate=$hDate&hPos=$hPos')>
			</td>");
			}
			echo ("</tr>");
}
echo("</table>");
?>
<?
if($bSave=='Save') {
$DateNow= Date('m-d-Y');
echo ("INSERT INTO PetugasJaga (NRP, Jam1, Jam2, Jaga) VALUES('$tNrp','$DateNow $tJam1','$DateNow $tJam2','$tJaga')");
$insert="INSERT INTO PetugasJaga (NRP, Jam1, Jam2, Jaga) VALUES('$tNrp','$DateNow $tJam1','$DateNow $tJam2','$tJaga')";
$hasil =@mssql_query ($insert) or die ("Terdapat Kesalahan Insert");
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data Tersimpan.!!'); </SCRIPT> </BODY>");
}
if(!$bDelete=='') {
$delete="DELETE From PetugasJaga WHERE No='$bDelete'";
$hasil =@mssql_query ($delete) or die ("Terdapat Kesalahan Update");
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data sudah dihapus.!!'); </SCRIPT> </BODY>");
}
$mati=@mssql_close($koneksi);
?></td>
        </tr>
      </table>
        </form>
    </td>
  </tr>
</table>

</body>
</html>
