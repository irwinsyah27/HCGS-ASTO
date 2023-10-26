<?
session_start();
if (($_SESSION[User]!='6104048') and ($_SESSION[User]!='8402003') and ($_SESSION[User]!='KB06005') and ($_SESSION[User]!='6103041') and ($_SESSION[User]!='KB10037') and ($_SESSION[User]!='KC10047')){
echo("<BODY> <SCRIPT language='Javascript'> alert('Tdk ada Akses !!'); close();</SCRIPT> </BODY>");
}

/////////////////////////////////////////////////////////////////////////////////////////////
if ($NoDM=='') {
echo ("<BODY> 
<SCRIPT language='Javascript'> 
alert('Overhead Cost Harus di Isi dulu . . !!'); 
close();
</SCRIPT> 
</BODY>");
}
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
	
	function HitungMPP() {
		 var a = document.forms["form1"].tKPP.value; 
		 var b = document.forms["form1"].tMM.value; 
		 var c = document.forms["form1"].tMIKAD.value;  
         var x = parseInt(a) + parseInt(b) + parseInt(c);
		 document.forms["form1"].tTOTAL.value=x; 
	} 
	function HitungSakit() {
		 var d = document.forms["form1"].tKPP2.value; 
		 var e = document.forms["form1"].tMM2.value; 
		 var f = document.forms["form1"].tMIKAD2.value;  
         var g = parseInt(d) + parseInt(e) + parseInt(f);
		 document.forms["form1"].tTOTAL2.value=g; 
	} 
	function HitungIzin() {
		 var h = document.forms["form1"].tKPP3.value; 
		 var i = document.forms["form1"].tMM3.value; 
		 var j = document.forms["form1"].tMIKAD3.value;  
         var k = parseInt(h) + parseInt(i) + parseInt(j);
		 document.forms["form1"].tTOTAL3.value=k; 
	} 
	function HitungAlpha() {
		 var l = document.forms["form1"].tKPP4.value; 
		 var m = document.forms["form1"].tMM4.value; 
		 var n = document.forms["form1"].tMIKAD4.value;  
         var o = parseInt(l) + parseInt(m) + parseInt(n);
		 document.forms["form1"].tTOTAL4.value=o; 
	}
//-->
</script>
<form method="post" enctype="multipart/form-data" name="form1" id="form1" <? echo ("action=Simpan2.php?NoDM=$NoDM"); ?>>
  
  <table width="100%" border="0">
    <tr>
      <td width="93%"><DIV id=inputs>
        <input name="NoDM" type="hidden" id="NoDM" value="<? echo $NoDM; ?>" />
        <table width="704" align="center" bgcolor="#CCFF99">
        <tr>
          <td width="696"><table width="100%" border="0" bgcolor="#FFFFFF">
              <tr>
                <td><table width="100%" border="0" bgcolor="#BBBBBB">
                    <tr>
                      <td><table width="100%" border="0">
                          <tr>
                            <td class="style7"><div align="center" class="ui-widget-header">Form Man Power <? echo $Dept; ?></div></td>
                          </tr>
                        </table>
                          <table width="100%" border="0" bordercolor="#FFFFFF">
                            <tr>
                              <td bgcolor="#DDDDDD"><table width="100%" border="0">
                                  <tr>
                                    <td>&nbsp;</td>
                                    <td bgcolor="#EEEEEE"><div align="center">Karyawan</div></td>
                                    <td bgcolor="#EEEEEE"><div align="center">Sakit</div></td>
                                    <td bgcolor="#EEEEEE"><div align="center">Izin</div></td>
                                    <td bgcolor="#EEEEEE"><div align="center">Alpha</div></td>
                                  </tr>
                                  <tr>
                                    <td width="37%" bgcolor="#EEEEEE">Attendace Ratio (KPP)</td>
                                    <td width="26%"><strong>:</strong> Orang
                                      <input name="tKPP" type="text" class="ui-widget-content" id="Input" title="KPP (Input 0-9)" onblur="this.value = '' + formatNumber(this.value, 0, 0, true)" onchange="HitungMPP()" value="0" size="10" /></td>
                                    <td width="10%"><input name="tKPP2" type="text" class="ui-widget-content" id="tKPP2" title="KPP (Sakit)" onblur="this.value = '' + formatNumber(this.value, 0, 0, true)" onchange="HitungSakit()" value="0" size="10" /></td>
                                    <td width="10%"><input name="tKPP3" type="text" class="ui-widget-content" id="tKPP3" title="KPP (Izin)" onblur="this.value = '' + formatNumber(this.value, 0, 0, true)" onchange="HitungIzin()" value="0" size="10" /></td>
                                    <td width="17%"><input name="tKPP4" type="text" class="ui-widget-content" id="tKPP4" title="KPP (Alpha)" onblur="this.value = '' + formatNumber(this.value, 0, 0, true)" onchange="HitungAlpha()" value="0" size="10" /></td>
                                  </tr>
                                  <tr>
                                    <td bgcolor="#EEEEEE">Attendace Ratio  (MAGANG)</td>
                                    <td><strong>:</strong> Orang
                                      <input name="tMM" type="text" class="ui-widget-content" id="Input" title="MM (Input 0-9)" onblur="this.value = '' + formatNumber(this.value, 0, 0, true)" onchange="HitungMPP()" value="0" size="10"/></td>
                                    <td><input name="tMM2" type="text" class="ui-widget-content" id="tMM2" title="MM (Sakit)" onblur="this.value = '' + formatNumber(this.value, 0, 0, true)" onchange="HitungSakit()" value="0" size="10"/></td>
                                    <td><input name="tMM3" type="text" class="ui-widget-content" id="tMM3" title="MM (Izin)" onblur="this.value = '' + formatNumber(this.value, 0, 0, true)" onchange="HitungIzin()" value="0" size="10"/></td>
                                    <td><input name="tMM4" type="text" class="ui-widget-content" id="tMM4" title="MM (Alpha)" onblur="this.value = '' + formatNumber(this.value, 0, 0, true)" onchange="HitungAlpha()" value="0" size="10"/></td>
                                  </tr>
                                  <tr>
                                    <td bgcolor="#EEEEEE">Attendace Ratio  (MIKAD)</td>
                                    <td><strong>:</strong> Orang
                                      <input name="tMIKAD" type="text" class="ui-widget-content" id="Input" title="MIKAD (Input 0-9)" onblur="this.value = '' + formatNumber(this.value, 0, 0, true)" onchange="HitungMPP()" value="0" size="10"/></td>
                                    <td><input name="tMIKAD2" type="text" class="ui-widget-content" id="tMIKAD2" title="MIKAD (Sakit)" onblur="this.value = '' + formatNumber(this.value, 0, 0, true)" onchange="HitungSakit()" value="0" size="10"/></td>
                                    <td><input name="tMIKAD3" type="text" class="ui-widget-content" id="tMIKAD3" title="MIKAD (Izin)" onblur="this.value = '' + formatNumber(this.value, 0, 0, true)" onchange="HitungIzin()" value="0" size="10"/></td>
                                    <td><input name="tMIKAD4" type="text" class="ui-widget-content" id="tMIKAD4" title="MIKAD (Alpha)" onblur="this.value = '' + formatNumber(this.value, 0, 0, true)" onchange="HitungAlpha()" value="0" size="10"/></td>
                                  </tr>
                                  <tr>
                                    <td bgcolor="#EEEEEE"><div align="center">Total</div></td>
                                    <td><strong>:</strong> Orang
                                      <input name="tTOTAL" type="text" class="ui-widget-content" id="hIBS" onblur="this.value = '' + formatNumber(this.value, 0, 0, true)" size="10" /></td>
                                    <td><input name="tTOTAL2" type="text" class="ui-widget-content" id="tTOTAL2" onblur="this.value = '' + formatNumber(this.value, 0, 0, true)" size="10" /></td>
                                    <td><input name="tTOTAL3" type="text" class="ui-widget-content" id="tTOTAL3" onblur="this.value = '' + formatNumber(this.value, 0, 0, true)" size="10" /></td>
                                    <td><input name="tTOTAL4" type="text" class="ui-widget-content" id="tTOTAL4" onblur="this.value = '' + formatNumber(this.value, 0, 0, true)" size="10" /></td>
                                  </tr>
                                  <tr>
                                    <td bgcolor="#EEEEEE"><div align="center">Attach</div></td>
                                    <td colspan="4"><div align="center">
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
      </table></DIV></td>
      <td width="7%"><div align="center">
	  
        <input name="Submit" type="submit" class="style6"style="background-image:url(../images/next.png); background-repeat:no-repeat; background-position:right; border:none;" value="Next   " />
      </div></td>
    </tr>
  </table>
</form>
