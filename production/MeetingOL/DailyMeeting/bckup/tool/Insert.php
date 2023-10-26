<?
session_start();
//require("cek.php");
if (($_SESSION[User]!='6104048') and ($_SESSION[User]!='8402003') and ($_SESSION[User]!='KB06005') and ($_SESSION[User]!='6103041') and ($_SESSION[User]!='kC09069') and ($_SESSION[User]!='KC09069') and ($_SESSION[User]!='KC10047')){
echo("<BODY> <SCRIPT language='Javascript'> alert('Tdk ada Akses !!'); close();</SCRIPT> </BODY>");
}
// ----- ambil isi dari file koneksi.php
require("../koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();

///////////////////////////////////////////////////
$data = mysql_query ("select * from DailyMeeting where TglDM='$pTgl'");
$sCek=mysql_fetch_array($data);
?>

<title>Daily Meeting</title>
	<link rel="stylesheet" href="../../../Tools/themes/south-street/jquery.ui.all.css">
	<script src="../../../Tools/jquery-1.5.1.js"></script>
	<script src="../../../Tools/ui/jquery.ui.core.js"></script>
	<script src="../../../Tools/ui/jquery.ui.widget.js"></script>
	<script src="../../../Tools/ui/jquery.ui.datepicker.js"></script>
	<script src="../../../Tools/external/jquery.bgiframe-2.1.2.js"></script>
	<script src="../../../Tools/ui/jquery.ui.mouse.js"></script>
	<script src="../../../Tools/ui/jquery.ui.draggable.js"></script>
	<script src="../../../Tools/ui/jquery.ui.position.js"></script>
	<script src="../../../Tools/ui/jquery.ui.resizable.js"></script>
	<script src="../../../Tools/ui/jquery.ui.Sdialog.js"></script>
	<link rel="stylesheet" href="../../../Tools/jQ.css">
	<link rel="stylesheet" href="../../../Tools/themes/tooltip-generic.css">
	<script>
<!--

// increase the default animation speed to exaggerate the effect
	$.fx.speeds._default = 2000;
	$(function() {
		$( "#dialog1" ).dialog({
			autoOpen: false,
			show: "Scale",
			hide: "Scale"
		});

		$( "#opener1" ).click(function() {
			$( "#dialog1" ).dialog( "open" );
			return false;
		});
		
		$( "#dialog2" ).dialog({
			autoOpen: false,
			show: "blind",
			hide: "explode"
		});

		$( "#opener2" ).click(function() {
			$( "#dialog2" ).dialog( "open" );
			return false;
		});
	});
	
	$(function() {
		$( "#datepicker" ).datepicker();
	});
	
	function MM_openBrWindow(theURL,winName,features) { //v2.0
 	window.open(theURL,winName,features);
	}
	
	// execute your scripts when the DOM is ready. this is a good habit
	$(function() {

	// select all desired input fields and attach tooltips to them
	$("#myform :input").tooltip({

	// place tooltip on the right edge
	position: "center right",

	// a little tweaking of the position
	offset: [-2, 10],

	// use the built-in fadeIn/fadeOut effect
	effect: "fade",

	// custom opacity setting
	opacity: 0.7

	});
	});
	
	function formatNumber(number, digits, decimalPlaces, withCommas) 
	{ 
        number       = number.toString(); 
    var simpleNumber = ''; 
    // Strips out the dollar sign and commas. 
    for (var i = 0; i < number.length; ++i) 
    { 
        if ("0123456789.".indexOf(number.charAt(i)) >= 0) 
            simpleNumber += number.charAt(i); 
    } 
    number = parseFloat(simpleNumber); 
    if (isNaN(number))      number     = 0; 
    if (withCommas == null) withCommas = false; 
    if (digits     == 0)    digits     = 1; 
    var integerPart = (decimalPlaces > 0 ? Math.floor(number) : Math.round(number)); 
    var string      = ""; 
    for (var i = 0; i < digits || integerPart > 0; ++i) 
    { 
        // Insert a comma every three digits. 
        if (withCommas && string.match(/^\d\d\d/)) 
            string = "." + string; 
        string      = (integerPart % 10) + string; 
        integerPart = Math.floor(integerPart / 10); 
    } 
    if (decimalPlaces > 0) 
    { 
        number -= Math.floor(number); 
        number *= Math.pow(10, decimalPlaces); 
        string += "," + formatNumber(number, decimalPlaces, 0); 
    } 
    return string; 
	}
	function HitungP() {
		 var a = document.forms["form1"].tPlan1.value; 
		 var b = document.forms["form1"].tPlan2.value;  
         var x = parseInt(a) + parseInt(b);
		 document.forms["form1"].tPlan3.value=x; 
	} 
	function HitungA() {
		 var d = document.forms["form1"].tActual1.value; 
		 var e = document.forms["form1"].tActual2.value;  
         var g = parseInt(d) + parseInt(e);
		 document.forms["form1"].tActual3.value=g; 
	}
//-->
</script>
	

<form method="post" enctype="multipart/form-data" name="form1" id="form1" <? echo ("action=Simpan1.php?Dept=$Dept"); ?>>
  <input name="pTgl" type="hidden" id="pTgl" value="<? echo $pTgl; ?>" />
  <table width="80%" border="0" align="center">
    <tr>
      <td width="92%"><DIV id=inputs>
        <table width="100%" border="0" bgcolor="#CCFF99">
          <tr>
            <td><table width="100%" border="0" bgcolor="#FFFFFF">
              <tr>
                <td><table width="100%" border="0" bgcolor="#BBBBBB">
                  <tr>
                    <td><table width="100%" border="0">
                        <tr>
                          <td class="style7"><div align="center" class="ui-widget-header">Form Overhead Cost <? echo $Dept; ?></div></td>
                        </tr>
                      </table>
                        <table width="100%" border="0" bordercolor="#FFFFFF">
                          <tr>
                            <td bgcolor="#DDDDDD"><table width="100%" border="0">
                                <tr>
                                  <td width="27%">Transportation (IBS)</td>
                                  <td width="29%"><strong>:</strong> Rp.
                                    <input name="tPlan1" type="text" class="ui-widget-content" id="Input" title="Plan . . (Input 0-9)" onblur="this.value = '' + formatNumber(this.value, 0, 0, false)" onchange="HitungP()" value="<? if(!$sCek[NoDM]=='') { echo $sCek[Plan1]; } else { echo '0'; } ?>" /></td>
                                  <td width="27%">Rp.
                                    <input name="tActual1" type="text" class="ui-widget-content" id="Input" title="Actual . . (Input 0-9)" onblur="this.value = '' + formatNumber(this.value, 0, 0, false)" onchange="HitungA()" value="<? if(!$sCek[NoDM]=='') { echo $sCek[Actual1];  } else { echo '0'; } ?>"/></td>
                                  <td width="17%"><select name="tRemark1" class="ui-widget-content" id="tRemark1" title="Remark . .">
                                    <option value="IBS" <?php if (!(strcmp("IBS", $sCek[Remark1]))) {echo "selected=\"selected\"";} ?>>IBS</option><option value="PROPOSAL" <?php if (!(strcmp("PROPOSAL", $sCek[Remark1]))) {echo "selected=\"selected\"";} ?>>PROPOSAL</option>
                                    </select>
                                  </td>
                                </tr>
                                <tr>
                                  <td>Overhead Cost (IBS)</td>
                                  <td><strong>:</strong> Rp.
                                    <input name="tPlan2" type="text" class="ui-widget-content" id="Input" title="Plan . . (Input 0-9)" onblur="this.value = '' + formatNumber(this.value, 0, 0, false)" onchange="HitungP()" value="<? if(!$sCek[NoDM]=='') { echo $sCek[Plan2];  } else { echo '0'; } ?>"/></td>
                                  <td>Rp.
                                    <input name="tActual2" type="text" class="ui-widget-content" id="Input" title="Actual . . (Input 0-9)" onblur="this.value = '' + formatNumber(this.value, 0, 0, false)" onchange="HitungA()" value="<? if(!$sCek[NoDM]=='') { echo $sCek[Actual2];  } else { echo '0'; } ?>"/></td>
                                  <td><select name="tRemark2" class="ui-widget-content" id="tRemark2">
                                    <option value="IBS" <?php if (!(strcmp("IBS", $sCek[Remark2]))) {echo "selected=\"selected\"";} ?>>IBS</option>
<option value="PROPOSAL" <?php if (!(strcmp("PROPOSAL", $sCek[Remark2]))) {echo "selected=\"selected\"";} ?>>PROPOSAL</option>
                                  </select></td>
                                </tr>
                                <tr>
                                  <td>O/H Cost (??)</td>
                                  <td><strong>:</strong> Rp.
                                    <input name="tPlan3" type="text" class="ui-widget-content" id="Input" title="Plan . . (Input 0-9)" onblur="this.value = '' + formatNumber(this.value, 0, 0, true)" value="<? if(!$sCek[NoDM]=='') { echo $sCek[Plan3];  } else { echo '0'; } ?>"/></td>
                                  <td>Rp.
                                    <input name="tActual3" type="text" class="ui-widget-content" id="Input" title="Actual . . (Input 0-9)" onblur="this.value = '' + formatNumber(this.value, 0, 0, true)" value="<? if(!$sCek[NoDM]=='') { echo $sCek[Actual3];  } else { echo '0'; } ?>"/></td>
                                  <td><select name="tRemark3" class="ui-widget-content" id="tRemark3">
                                    <option value="IBS" <?php if (!(strcmp("IBS", $sCek[Remark3]))) {echo "selected=\"selected\"";} ?>>IBS</option><option value="PROPOSAL" <?php if (!(strcmp("PROPOSAL", $sCek[Remark3]))) {echo "selected=\"selected\"";} ?>>PROPOSAL</option>
                                  </select></td>
                                </tr>
                                <tr>
                                  <td>&nbsp;</td>
                                  <td colspan="3"><div align="center">Attach
                                    <input name="File" type="file" class="ui-widget-content" id="File" />
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
      <td width="8%"><div align="center">
	  
        <input name="Submit" type="submit" class="style6"style="background-image:url(../images/next.png); background-repeat:no-repeat; background-position:right; border:none;" value="Next   " />
      </div></td>
    </tr>
  </table>
</form>
