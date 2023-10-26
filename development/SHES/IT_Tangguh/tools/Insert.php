<?
session_start();
require("koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();

if (($_SESSION[User]!='KB05002') and ($_SESSION[User]!='KC10047') and ($_SESSION[User]!='6103041') AND ($_SESSION[User]!='KB09014') AND ($_SESSION[User]!='KC05132')){
echo("<BODY> <SCRIPT language='Javascript'> alert('Tdk ada Akses !!'); close();</SCRIPT> </BODY>");
}

/////////////////////////////////////////////////////////////////////////////////////////////
?>

<title>Daily Meeting</title>
	<link rel="stylesheet" href="../../../Tools/themes/south-street/jquery.ui.all.css">
	<link rel="stylesheet" href="../../../Tools/jQ.css">
	<link rel="stylesheet" href="../../../Tools/themes/tooltip-generic.css"><form method="post" name="form1" target="_self" id="form1" ?>
  
  <table width="100%" border="0">
    <tr>
      <td width="93%"><DIV id=inputs><? 
if (($bSave=='Save') and ($tGroup!='') and ($tNrp!='') and ($tNama!='') and ($tJabatan!='') and ($tDept!='') and ($tLN!='') and ($tHP!='')) { 
$insert="INSERT INTO Persis.dbo.tblLotusNotes (Nrp, Nama, Jabatan, Departemen, LotusNotes, NoHP) VALUES('$tNrp','$tNama','$tJabatan','$tDept','$tLN','$tHP')";
$hasil =@mssql_query ($insert) or die ("Terdapat Kesalahan SQL ".$insert);
$eNoID=mssql_query("SELECT ID from Persis.dbo.tblLotusNotes ORDER BY ID DESC") or die ("Salah SQL!");
$dID=mssql_fetch_array($eNoID);
	$insert="INSERT INTO tbl_PIC (ref_PIC, Group_PIC) VALUES($dID[ID],'$tGroup')";
	$hasil =@mssql_query ($insert) or die ("Terdapat Kesalahan SQL ".$insert);
echo ("<BODY> <SCRIPT language='Javascript'> alert('Saved..!!'); close() </SCRIPT> </BODY>");
} else
if (($bSave=='Save') and (($tNrp=='') or ($tNama=='') or ($tJabatan=='') or ($tDept=='') or ($tLN=='') or ($tHP==''))) { 
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data Belum Lengkap..!!'); </SCRIPT> </BODY>"); 
}
?>
        <table width="704" align="center" bgcolor="#CCFF99">
        <tr>
          <td width="696"><table width="100%" border="0" bgcolor="#FFFFFF">
              <tr>
                <td><table width="100%" border="0" bgcolor="#BBBBBB">
                    <tr>
                      <td><table width="100%" border="0">
                          <tr>
                            <td class="style7"><div align="center" class="ui-widget-header">Form Insert </div></td>
                          </tr>
                        </table>
                          <table width="100%" border="0" bordercolor="#FFFFFF">
                            <tr>
                              <td bgcolor="#DDDDDD"><table width="97%" border="0">
                                  <tr>
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>Group PIC </strong></div></td>
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>Nrp</strong></div></td>
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>Nama</strong></div></td>
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>Jabatan</strong></div></td>
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>Dept</strong></div></td>
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>LotusNotes</strong></div></td>
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>No HP </strong></div></td>
                                    </tr>
                                  <tr>
                                    <td width="9%"><input name="tGroup" type="text" class="ui-widget-content" id="tKPP" title="KPP (Input 0-9)" value="<? echo $tGroup; ?>" size="15" /></td>
                                    <td width="9%"><input name="tNrp" type="text" class="ui-widget-content" id="Input" title="KPP (Input 0-9)" value="<? echo $tNrp; ?>" size="10" /></td>
                                    <td width="23%"><input name="tNama" type="text" class="ui-widget-content" id="tNama" title="KPP (Sakit)" value="<? echo $tNama; ?>" size="25" /></td>
                                    <td width="14%"><input name="tJabatan" type="text" class="ui-widget-content" id="tJabatan" title="KPP (Izin)" value="<? echo $tJabatan; ?>" size="20" /></td>
                                    <td width="14%"><input name="tDept" type="text" class="ui-widget-content" id="tDept" title="KPP (Alpha)" value="<? echo $tDept; ?>" size="10" /></td>
                                    <td width="14%"><input name="tLN" type="text" class="ui-widget-content" id="tKPP2" title="KPP (Input 0-9)" value="<? echo $tLN; ?>" /></td>
                                    <td width="17%"><input name="tHP" type="text" class="ui-widget-content" id="tKPP3" title="KPP (Input 0-9)" value="<? echo $tHP; ?>" size="15" /></td>
                                    </tr>
                                  <tr>
                                    <td colspan="7">
                                      <div align="right" class="ui-widget-header">
                                        <input name="bSave" type="submit" class="ui-state-hover" id="bSave" value="Save" />
                                        </div></td>
                                    </tr>
                              </table></td>
                            </tr>
                        </table></td>
                    </tr>
                </table></td>
              </tr>
          </table></td>
        </tr>
      </table></DIV></td>
    </tr>
  </table>
</form>
