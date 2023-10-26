<?
include("cek.php");
require("koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();
/////////////////////////////////////////////////////////////////////////////////////////////
$ePIC=mssql_query("SELECT * from tbl_PIC where Id = '$Id'") or die ("Salah SQL!");
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
        <input name="Id" type="hidden" id="Id" value="<? echo $Id; ?>" />
        <? 
if (($bSave=='Save') and ($tGroup!='')) { 
	$update="UPDATE tbl_PIC SET GroupPIC='$tGroup', UserName='$tNama', Area='$tArea', HP='$tHP' WHERE Id='$Id'";
	$hasil =@mssql_query ($update) or die ("Terdapat Kesalahan SQL ".$update);
	
	echo ("<BODY> <SCRIPT language='Javascript'> alert('Saved..!!'); close(); </SCRIPT> </BODY>"); 
	exit();
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
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>Nama</strong></div></td>
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>Area</strong></div></td>
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>No HP </strong></div></td>
                                    </tr>
                                  <tr>
                                    <td width="9%"><input name="tGroup" type="text" class="ui-widget-content" id="tKPP" title="KPP (Input 0-9)" value="<? echo $data[GroupPIC]; ?>" size="15" /></td>
                                    <td width="23%"><input name="tNama" type="text" class="ui-widget-content" id="tNama" title="KPP (Sakit)" value="<? echo $data[UserName]; ?>" size="25" /></td>
                                    <td width="14%"><input name="tArea" type="text" class="ui-widget-content" id="tArea" title="KPP (Izin)" value="<? echo $data[Area]; ?>" size="20" /></td>
                                    <td width="17%"><input name="tHP" type="text" class="ui-widget-content" id="tKPP3" title="KPP (Input 0-9)" value="<? echo $data[HP]; ?>" size="15" /></td>
                                    </tr>
                                  <tr>
                                    <td colspan="4">
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
