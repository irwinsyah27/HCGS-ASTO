<?
session_start();
if (($_SESSION[User]=='k6103041') AND ($_SESSION[User]=='kKC10047') AND ($_SESSION[User]=='BERCARANTAU') AND ($_SESSION[User]=='bercarantau')){
echo("<BODY> <SCRIPT language='Javascript'> alert('Tdk ada Akses !!'); close();</SCRIPT> </BODY>");
}
require("koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();



/////////////////////////////////////////////////////////////////////////////////////////////
?>

<title>Insert Asset</title>
	<link rel="stylesheet" href="../../../Tools/themes/south-street/jquery.ui.all.css">
	<link rel="stylesheet" href="../../../Tools/jQ.css">
	<link rel="stylesheet" href="../../../Tools/themes/tooltip-generic.css"><form method="post" name="form1" target="_self" id="form1" ?>
  
  <table width="100%" border="0">
    <tr>
      <td width="93%"><DIV id=inputs><? 
if (($bSave=='Save') and ($tNoAsset!='') and ($tCategory!='') and ($tSite!='') and ($tDept!='') and ($tDept!='') and ($tUser!='') and ($tChek!='')) { 
$insert="INSERT INTO tbl_Asset (NoAsset, Category, Site, Dept, [User], Merk, Type, SN, Start, [Stop], PIC) VALUES('$tNoAsset','$tCategory','$tDept','$tUser','$tMerk','$tType','$tMerk','$tSN','$tStart','$tStop','$tChek')";
$hasil =@mssql_query ($insert) or die ("Terdapat Kesalahan SQL ".$insert);
echo ("<BODY> <SCRIPT language='Javascript'> alert('Saved..!!'); close(); </SCRIPT> </BODY>"); 
exit();
} else
if (($bSave=='Save') and (($tNoAsset=='') or ($tCategory=='') or ($tSite=='') or ($tDept=='') or ($tDept=='') or ($tUser=='') or ($tChek==''))) { 
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
                                      <td bgcolor="#EEEEEE"><div align="center"><strong>NoAsset </strong></div></td>
                                      <td bgcolor="#EEEEEE"><div align="center"><strong>Category</strong></div></td>
                                      <td bgcolor="#EEEEEE"><div align="center"><strong>Site</strong></div></td>
                                      <td bgcolor="#EEEEEE"><div align="center"><strong>Dept</strong></div></td>
                                      <td bgcolor="#EEEEEE"><div align="center"><strong>User</strong></div></td>
                                      <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                      <td width="15%"><input name="tNoAsset" type="text" class="ui-widget-content" id="tKPP" title="KPP (Input 0-9)" value="<? echo $data[NoAsset]; ?>" size="15" /></td>
                                      <td width="19%"><span class="ui-widget-header">
                                        <select name="tCategory" class="ui-state-active" id="tCategory">
                                          <option value="DESKTOP">DESKTOP</option>
                                          <option value="NET&amp;TEL">NET&amp;TEL</option>
                                          <option value="NOTEBOOK">NOTEBOOK</option>
                                          <option value="PRINTER">PRINTER</option>
                                          <option value="SERVER">SERVER</option>
                                          <option value="UPS">UPS</option>
                                                                                                                        </select>
                                      </span></td>
                                      <td width="19%"><input name="tSite" type="text" class="ui-widget-content" id="tSite" title="KPP (Izin)" value="<? echo $data[Site]; ?>" /></td>
                                      <td width="17%"><input name="tDept" type="text" class="ui-widget-content" id="tKPP3" title="KPP (Input 0-9)" value="<? echo $data[Dept]; ?>" /></td>
                                      <td width="15%"><input name="tUser" type="text" class="ui-widget-content" id="tGroup" title="KPP (Input 0-9)" value="<? echo $data[User]; ?>" /></td>
                                      <td width="15%">&nbsp;</td>
                                    </tr>
                                    <tr>
                                      <td bgcolor="#EEEEEE"><div align="center"><strong>Merk</strong></div></td>
                                      <td bgcolor="#EEEEEE"><div align="center"><strong>Type</strong></div></td>
                                      <td bgcolor="#EEEEEE"><div align="center"><strong>SN</strong></div></td>
                                      <td bgcolor="#EEEEEE"><div align="center"><strong>Start</strong></div></td>
                                      <td bgcolor="#EEEEEE"><div align="center"><strong>Stop</strong></div></td>
                                      <td bgcolor="#EEEEEE"><strong>ChekBy</strong></td>
                                    </tr>
                                    <tr>
                                      <td><input name="tMerk" type="text" class="ui-widget-content" id="tGroup2" title="KPP (Input 0-9)" value="<? echo $data[Merk]; ?>" size="15" /></td>
                                      <td><input name="tType" type="text" class="ui-widget-content" id="tGroup3" title="KPP (Input 0-9)" value="<? echo $data[Type]; ?>" /></td>
                                      <td><input name="tSN" type="text" class="ui-widget-content" id="tGroup4" title="KPP (Input 0-9)" value="<? echo $data[SN]; ?>" /></td>
                                      <td><input name="tStart" type="text" class="ui-widget-content" id="tGroup5" title="KPP (Input 0-9)" value="<? echo date('Y-m-d'); ?>" /></td>
                                      <td><input name="tStop" type="text" class="ui-widget-content" id="tGroup6" title="KPP (Input 0-9)" value="<? echo date('Y-m-d'); ?>" /></td>
                                      <td><input name="tChek" type="text" class="ui-widget-content" id="tGroup7" title="KPP (Input 0-9)" value="<? echo $_SESSION[User]; ?>" size="15" /></td>
                                    </tr>
                                    <tr>
                                      <td colspan="6"><div align="right" class="ui-widget-header">
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
        </table>
      </DIV></td>
    </tr>
  </table>
</form>
