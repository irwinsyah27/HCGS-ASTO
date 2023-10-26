<?
session_start();
if (($_SESSION[User]=='k6103041') AND ($_SESSION[User]=='kKC10047') AND ($_SESSION[User]=='BERCARANTAU') AND ($_SESSION[User]=='bercarantau')){
echo("<BODY> <SCRIPT language='Javascript'> alert('Tdk ada Akses !!'); close();</SCRIPT> </BODY>");
}
require("koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();
/////////////////////////////////////////////////////////////////////////////////////////////
$ePIC=mssql_query("SELECT * from tbl_Asset where NoAsset = '$NoAsset'") or die ("Salah SQL!");
$data=mssql_fetch_array($ePIC);
?>

<script language="javascript">     
function Delete1(NoID)
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

<title>Update Asset</title>
	<link rel="stylesheet" href="../../../Tools/themes/south-street/jquery.ui.all.css">
	<link rel="stylesheet" href="../../../Tools/jQ.css">
	<link rel="stylesheet" href="../../../Tools/themes/tooltip-generic.css"><form method="post" name="form1" target="_self" id="form1" ?>
  
  <table width="100%" border="0">
    <tr>
      <td width="93%"><DIV id=inputs>
        <input name="NoAsset" type="hidden" id="NoAsset" value="<? echo $NoAsset; ?>" />
        <? 
if (($bSave=='Save') and ($tNoAsset!='')) { 
	$update="UPDATE tbl_Asset SET Category='$tCategory', Site='$tSite', Dept='$tDept', [User]='$tUser', Merk='$tMerk', Type='$tType', SN='$tSN', Start='$tStart', Stop='$tStop', PIC='$tChek', Remark='$tRemark' WHERE NoAsset='$tNoAsset'";
	$hasil =@mssql_query ($update) or die ("Terdapat Kesalahan SQL ".$update);
	
	echo ("<BODY> <SCRIPT language='Javascript'> alert('Saved..!!'); close(); </SCRIPT> </BODY>"); 
	exit();
	}
if (($tNoAsset!='') and ($bDel=='Delete')) { 
	$del="DELETE From tbl_Asset WHERE NoAsset='$tNoAsset'";
	$hasil =@mssql_query ($del) or die ("Terdapat Kesalahan SQL ".$del);
	
	echo ("<BODY> <SCRIPT language='Javascript'> alert('Deleted..!!'); close(); </SCRIPT> </BODY>"); 
	exit();
	}
	$mati=@mssql_close($koneksi);
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
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>NoAsset </strong></div></td>
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>Category</strong></div></td>
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>Site</strong></div></td>
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>Dept</strong></div></td>
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>User</strong></div></td>
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>Merk</strong></div></td>
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>Type</strong></div></td>
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>SN</strong></div></td>
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>Start</strong></div></td>
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>Stop</strong></div></td>
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>Stat</strong></div></td>
                                    <td bgcolor="#EEEEEE"><div align="center"><strong>ChekBy</strong></div></td>
                                  </tr>
                                  <tr>
                                    <td width="9%"><input name="tNoAsset" type="text" class="ui-widget-content" id="tKPP" title="KPP (Input 0-9)" value="<? echo $data[NoAsset]; ?>" size="15" /></td>
                                    <td width="23%"><input name="tCategory" type="text" class="ui-widget-content" id="tCategory" title="KPP (Sakit)" value="<? echo $data[Category]; ?>" size="25" /></td>
                                    <td width="14%"><input name="tSite" type="text" class="ui-widget-content" id="tSite" title="KPP (Izin)" value="<? echo $data[Site]; ?>" size="20" /></td>
                                    <td width="17%"><input name="tDept" type="text" class="ui-widget-content" id="tKPP3" title="KPP (Input 0-9)" value="<? echo $data[Dept]; ?>" size="15" /></td>
                                    <td width="17%"><input name="tUser" type="text" class="ui-widget-content" id="tGroup" title="KPP (Input 0-9)" value="<? echo $data[User]; ?>" size="15" /></td>
                                    <td width="17%"><input name="tMerk" type="text" class="ui-widget-content" id="tGroup2" title="KPP (Input 0-9)" value="<? echo $data[Merk]; ?>" size="15" /></td>
                                    <td width="17%"><input name="tType" type="text" class="ui-widget-content" id="tGroup3" title="KPP (Input 0-9)" value="<? echo $data[Type]; ?>" size="15" /></td>
                                    <td width="17%"><input name="tSN" type="text" class="ui-widget-content" id="tGroup4" title="KPP (Input 0-9)" value="<? echo $data[SN]; ?>" size="15" /></td>
                                    <td width="17%"><input name="tStart" type="text" class="ui-widget-content" id="tGroup5" title="KPP (Input 0-9)" value="<? echo $data[Start]; ?>" size="15" /></td>
                                    <td width="17%"><input name="tStop" type="text" class="ui-widget-content" id="tGroup6" title="KPP (Input 0-9)" value="<? echo $data[Stop]; ?>" size="15" /></td>
                                    <td width="17%"><input name="tRemark" type="text" class="ui-widget-content" id="tGroup8" title="KPP (Input 0-9)" value="<? echo $data[Remark]; ?>" size="15" /></td>
                                    <td width="17%"><input name="tChek" type="text" class="ui-widget-content" id="tGroup7" title="KPP (Input 0-9)" value="<? echo $data[PIC]; ?>" size="15" /></td>
                                  </tr>
                                  <tr>
                                    <td colspan="11">
                                      <div align="right" class="ui-widget-header">
                                        <input name="bSave" type="submit" class="ui-state-hover" id="bSave" value="Save" />
                                        <input name="bDel" type="submit" class="ui-state-hover" id="bDel" value="Delete" />
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
