<?
session_start();
if (($_SESSION[User]=='6104048') or ($_SESSION[User]=='8402003') or ($_SESSION[User]=='KB06005') or ($_SESSION[User]=='6103041') or ($_SESSION[User]=='KC10047')) {
   } Else { exit(); }
// ----- ambil isi dari file koneksi.php
require("../koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();

///////////////////////////////////////////////////
$data = mysql_query ("select Information from DailyMeeting where NoDM='$NoDM'");
$sCek=mysql_fetch_array($data);

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
	<link rel="stylesheet" href="../../Tools/themes/south-street/jquery.ui.all.css">
	<script src="../../Tools/jquery-1.5.1.js"></script>
	<script src="../../Tools/ui/jquery.ui.core.js"></script>
	<script src="../../Tools/ui/jquery.ui.widget.js"></script>
	<script src="../../Tools/ui/jquery.ui.datepicker.js"></script>
	<script src="../../Tools/external/jquery.bgiframe-2.1.2.js"></script>
	<script src="../../Tools/ui/jquery.ui.mouse.js"></script>
	<script src="../../Tools/ui/jquery.ui.draggable.js"></script>
	<script src="../../Tools/ui/jquery.ui.position.js"></script>
	<script src="../../Tools/ui/jquery.ui.resizable.js"></script>
	<script src="../../Tools/ui/jquery.ui.Sdialog.js"></script>
	<script src="../../Tools/jquery-1.4.3.min.js"></script>
	<link rel="stylesheet" href="../../Tools/jQ.css">
	<link rel="stylesheet" href="../../Tools/themes/tooltip-generic.css">
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

function MM_popupMsg(msg) { //v1.0
  alert(msg);
}
//-->
</script>
	

<form method="post" enctype="multipart/form-data" name="form1" id="form1" <? echo ("action=Simpan3.php?NoDM=$NoDM"); ?>>
  
  <table width="100%" border="0">
    <tr>
      <td width="91%"><DIV id=inputs>
        <input name="tTOTAL" type="hidden" id="tTOTAL" value="<? echo $tTOTAL; ?>" />
        <table width="100%" border="0">
          <tr>
            <td><table width="778" align="center" bgcolor="#CCFF99">
              <tr>
                <td width="770"><table width="100%" border="0" bgcolor="#FFFFFF">
                    <tr>
                      <td><table width="100%" border="0" bgcolor="#BBBBBB">
                          <tr>
                            <td><table width="100%" border="0">
                                <tr>
                                  <td class="style7"><div align="center" class="ui-widget-header">Form Information <? echo $Dept; ?></div></td>
                                </tr>
                              </table>
                                <table width="100%" border="0" bordercolor="#FFFFFF">
                                  <tr>
                                    <td bgcolor="#DDDDDD"><table width="100%" border="0">
                                        <tr>
                                          <td width="36%"><p>Information </p>
                                              <p>For List {<span class="ui-widget-content">&lt;li&gt;</span> } </p></td>
                                          <td width="33%"><textarea name="tInf" cols="80" rows="10" class="ui-widget-content" id="tInf"><? echo $sCek[Information]; ?></textarea></td>
                                        </tr>
                                        <tr>
                                          <td><div align="center">Attach</div></td>
                                          <td><div align="center">
                                            <input name="File" type="file" class="ui-widget-content" id="File" onclick="MM_popupMsg('Nama File Harus tanpa Spasi . . . !!')" />
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
            </table></td>
            <td><input name="Submit2" type="submit" class="style6"style="background-image:url(../images/next.png); background-repeat:no-repeat; background-position:right; border:none;" value="Next   " /></td>
          </tr>
        </table>
        </DIV></td>
    </tr>
  </table>
  </div>
</form>
