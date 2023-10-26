<?
session_start();
require("koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();

if (($_SESSION[User]!='KB05002') and ($_SESSION[User]!='KC10047') and ($_SESSION[User]!='6103041') AND ($_SESSION[User]!='KB09014') AND ($_SESSION[User]!='KC05132')){
echo("<BODY> <SCRIPT language='Javascript'> alert('Tdk ada Akses !!'); close();</SCRIPT> </BODY>");
}

/////////////////////////////////////////////////////////////////////////////////////////////
$ePIC=mssql_query("SELECT dbo.tbl_PIC.Group_PIC, dbo.tbl_PIC.ref_PIC, Persis.dbo.tblLotusNotes.ID, Persis.dbo.tblLotusNotes.Nrp, Persis.dbo.tblLotusNotes.Nama, Persis.dbo.tblLotusNotes.Departemen, Persis.dbo.tblLotusNotes.Jabatan, Persis.dbo.tblLotusNotes.LotusNotes, Persis.dbo.tblLotusNotes.NoHP
FROM Persis.dbo.tblLotusNotes LEFT OUTER JOIN dbo.tbl_PIC ON Persis.dbo.tblLotusNotes.ID = dbo.tbl_PIC.ref_PIC Where Persis.dbo.tblLotusNotes.ID = $ID") or die ("Salah SQL!");
$data=mssql_fetch_array($ePIC);
?>

<script language="javascript">     
function Delete(NoID)
	{
	var konfirmasi = confirm("Anda Yakin ?");
	if (konfirmasi == true)
	  {
	  location.href="Edit.php?ID="+NoID+"&bDel=true"; 
	  }
	else
	  {
	  location.href="Edit.php?ID="+NoID
	  }
	}
</script>

<title>Daily Meeting</title>
	<link rel="stylesheet" href="../../../Tools/themes/south-street/jquery.ui.all.css">
	<link rel="stylesheet" href="../../../Tools/jQ.css">
	<link rel="stylesheet" href="../../../Tools/themes/tooltip-generic.css"><form method="post" name="form1" target="_self" id="form1" ?>
  
  <table width="100%" border="0">
    <tr>
      <td width="93%"><DIV id=inputs>
        <input name="NoID" type="hidden" id="NoID" value="<? echo $ID; ?>" />
        <? 
if (($bSave=='Save') and ($tGroup!='')) { 
$eNoID=mssql_query("SELECT Count(*) as Cek from tbl_PIC Where ref_PIC = $NoID") or die ("Salah SQL!");
$dID=mssql_fetch_array($eNoID);
	if ($dID[Cek]!='0') {	
	$update="UPDATE tbl_PIC SET Group_PIC='$tGroup' WHERE ref_PIC=$NoID";
	$hasil =@mssql_query ($update) or die ("Terdapat Kesalahan SQL ".$update);
	} Else {
	$insert="INSERT INTO tbl_PIC (ref_PIC, Group_PIC) VALUES($NoID,'$tGroup')";
	$hasil =@mssql_query ($insert) or die ("Terdapat Kesalahan SQL ".$insert);
	}
$update="UPDATE Persis.dbo.tblLotusNotes SET Nrp='$tNrp', Nama='$tNama', Jabatan='$tJabatan', Departemen='$tDept', LotusNotes='$tLN', NoHP='$tHP' WHERE ID=$NoID";
$hasil =@mssql_query ($update) or die ("Terdapat Kesalahan SQL ".$update);
echo ("<BODY> <SCRIPT language='Javascript'> alert('Saved..!!'); close(); </SCRIPT> </BODY>");
} else
if (($bSave=='Save') and ($tGroup=='')) { 
$update="UPDATE Persis.dbo.tblLotusNotes SET Nrp='$tNrp', Nama='$tNama', Jabatan='$tJabatan', Departemen='$tDept', LotusNotes='$tLN', NoHP='$tHP' WHERE ID=$NoID";
$hasil =@mssql_query ($update) or die ("Terdapat Kesalahan SQL ".$update);
echo ("<BODY> <SCRIPT language='Javascript'> alert('Saved..!!'); close(); </SCRIPT> </BODY>"); 
} else
if ($bDel=='true') {  
$delete1="Delete tbl_PIC WHERE ref_PIC=$ID";
$hasil =@mssql_query ($delete1) or die ("Terdapat Kesalahan SQL ".$update);
$delete2="Delete Persis.dbo.tblLotusNotes WHERE ID=$ID";
$hasil =@mssql_query ($delete2) or die ("Terdapat Kesalahan SQL ".$update);
echo ("<BODY> <SCRIPT language='Javascript'> alert('Deleted..!!'); close(); </SCRIPT> </BODY>"); 
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
                            <td class="style7"><div align="center" class="ui-widget-header">Form Edit </div></td>
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
                                    <td width="9%"><input name="tGroup" type="text" class="ui-widget-content" id="tKPP" title="KPP (Input 0-9)" value="<? echo $data[Group_PIC]; ?>" size="15" /></td>
                                    <td width="9%"><input name="tNrp" type="text" class="ui-widget-content" id="Input" title="KPP (Input 0-9)" value="<? echo $data[Nrp]; ?>" size="10" /></td>
                                    <td width="23%"><input name="tNama" type="text" class="ui-widget-content" id="tNama" title="KPP (Sakit)" value="<? echo $data[Nama]; ?>" size="25" /></td>
                                    <td width="14%"><input name="tJabatan" type="text" class="ui-widget-content" id="tJabatan" title="KPP (Izin)" value="<? echo $data[Jabatan]; ?>" size="20" /></td>
                                    <td width="14%"><input name="tDept" type="text" class="ui-widget-content" id="tDept" title="KPP (Alpha)" value="<? echo $data[Departemen]; ?>" size="10" /></td>
                                    <td width="14%"><input name="tLN" type="text" class="ui-widget-content" id="tKPP2" title="KPP (Input 0-9)" value="<? echo $data[LotusNotes]; ?>" /></td>
                                    <td width="17%"><input name="tHP" type="text" class="ui-widget-content" id="tKPP3" title="KPP (Input 0-9)" value="<? echo $data[NoHP]; ?>" size="15" /></td>
                                    </tr>
                                  <tr>
                                    <td colspan="7">
                                      <div align="right" class="ui-widget-header">
                                        <input name="bSave" type="submit" class="ui-state-hover" id="bSave" value="Save" />
                                        <input name="bDel" type="button" class="ui-state-hover" id="bDel" onclick="onClick=Delete(<? echo $ID; ?>)" value="Delete" />
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
