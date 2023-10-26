<?
session_start();
if (($_SESSION[User]=='k6103041') AND ($_SESSION[User]=='kKC10047') AND ($_SESSION[User]=='BERCARANTAU') AND ($_SESSION[User]=='bercarantau')){
echo("<BODY> <SCRIPT language='Javascript'> alert('Tdk ada Akses !!'); close();</SCRIPT> </BODY>");
}
require("Tools\koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();



/////////////////////////////////////////////////////////////////////////////////////////////
?>

<title>InsertProblem</title>
	<link rel="stylesheet" href="../../Tools/themes/south-street/jquery.ui.all.css">
	<link rel="stylesheet" href="../../Tools/jQ.css">
	<link rel="stylesheet" href="../../Tools/themes/tooltip-generic.css"><form method="post" name="form1" target="_self" id="form1" ?>
  
  <table width="90%" border="0">
    <tr>
      <td width="93%"><DIV id=inputs><? 
if (($bSave=='Save') and ($tNoAsset!='') and ($tCategory!='') and ($tProblem!='') and ($tPenyebab!='') and ($tStart!='')) { 
$insert="INSERT INTO tbl_Problem (Category, NoAsset, Problem, Penyebab, Solusi, Status, PIC, Start, PA, UA) VALUES('$tCategory','$tNoAsset','$tProblem','$tPenyebab','$tSolusi','$tStatus','$tPIC','$tStart','$tPA','$tUA')";
$hasil =@mssql_query ($insert) or die ("Terdapat Kesalahan SQL ".$insert);
echo ("<BODY> <SCRIPT language='Javascript'> alert('Saved..!!'); close(); </SCRIPT> </BODY>"); 
exit();
} else
if (($bSave=='Save') and (($tNoAsset=='') or ($tCategory=='') or ($tProblem=='') or ($tPenyebab=='') or ($tStart==''))) { 
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data Belum Lengkap..!!'); </SCRIPT> </BODY>"); 
}

?>
        <table width="918" align="center" bgcolor="#CCFF99">
          <tr>
            <td width="910"><table width="84%" border="0" bgcolor="#FFFFFF">
                <tr>
                  <td><table width="89%" border="0" bgcolor="#BBBBBB">
                      <tr>
                        <td><table width="100%" border="0">
                            <tr>
                              <td class="style7"><div align="center" class="ui-widget-header">Problem Maitenance &amp; Breakdown </div></td>
                            </tr>
                          </table>
                            <table width="89%" border="0" bordercolor="#FFFFFF">
                              <tr>
                                <td bgcolor="#DDDDDD"><table width="94%" border="0">
                                    <tr>
                                      <td bgcolor="#EEEEEE"><div align="center"><strong>Category</strong></div></td>
                                      <td bgcolor="#EEEEEE"><div align="center"><strong>NoAsset </strong></div></td>
                                      <td bgcolor="#EEEEEE"><div align="center"><strong>Problem</strong></div></td>
                                      <td bgcolor="#EEEEEE"><div align="center"><strong>Penyebab</strong></div></td>
                                      <td bgcolor="#EEEEEE"><div align="center"><strong>Solusi</strong></div></td>
                                    </tr>
                                    <tr>
                                      <td width="10%" class="ui-widget-content"><span class="ui-widget-header">
                                        <select name="tCategory" class="ui-state-active" id="tCategory">
                                          <option value="Maintenance">Maintenance</option>
                                          <option value="Breakdown">Breakdown</option>
                                        </select>
                                      </span></td>
                                      <td width="14%" class="ui-widget-content"><input name="tNoAsset" type="text" class="ui-widget-content" id="tNoAsset" title="KPP (Sakit)" size="25" /></td>
                                      <td width="22%"><textarea name="tProblem" cols="30" class="ui-widget-content" id="tProblem"></textarea></td>
                                      <td width="21%"><textarea name="tPenyebab" cols="30" class="ui-widget-content" id="tPenyebab"></textarea></td>
                                      <td width="33%"><textarea name="tSolusi" cols="30" class="ui-widget-content" id="tSolusi"></textarea></td>
                                    </tr>
                                    <tr>
                                      <td bgcolor="#EEEEEE"><div align="center"><strong>Status</strong></div></td>
                                      <td bgcolor="#EEEEEE"><div align="center"><strong>PIC</strong></div></td>
                                      <td bgcolor="#EEEEEE"><div align="center"><strong>Start</strong></div></td>
                                      <td bgcolor="#EEEEEE"><div align="center"><strong>PA</strong></div></td>
                                      <td bgcolor="#EEEEEE"><div align="center"><strong>UA</strong></div></td>
                                    </tr>
                                    <tr>
                                      <td><div align="right" class="ui-widget-content"><span class="ui-widget-header">
                                        <select name="tStatus" class="ui-state-active" id="tStatus">
                                          <option value="Open">Open</option>
                                          <option value="Close">Close</option>
                                        </select>
                                      </span></div></td>
                                      <td><div align="center" class="ui-widget-content">
                                        <input name="tPIC" type="text" class="ui-widget-content" id="tGroup3" title="KPP (Input 0-9)" value="<? echo $_SESSION[User]; ?>" />
                                      </div></td>
                                      <td><div align="center" class="ui-widget-content">
                                        <input name="tStart" type="text" class="ui-widget-content" id="tGroup4" title="KPP (Input 0-9)" value="<? echo date('Y-m-d G:i.000'); ?>" />
                                      </div></td>
                                      <td><div align="center" class="ui-widget-content">
                                        <input name="tPA" type="text" class="ui-widget-content" id="tGroup5" title="KPP (Input 0-9)" value="<? echo date('Y-m-d G:i.000'); ?>" />
                                      </div></td>
                                      <td><div align="center" class="ui-widget-content">
                                        <input name="tUA" type="text" class="ui-widget-content" id="tGroup6" title="KPP (Input 0-9)" value="<? echo date('Y-m-d G:i.000'); ?>" />
                                      </div></td>
                                    </tr>
                                    <tr>
                                      <td colspan="5"><div align="right" class="ui-widget-header">
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
