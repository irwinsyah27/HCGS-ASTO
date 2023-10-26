<?
include("cek.php");
require("tools/koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();
if ($pDate=='') {
	$pDate= date('Y/m/d');
	}
	
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>KPI IT</title>
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
	<script src="../../Tools/ui/SdialogAlertIT.js"></script>
	<link rel="stylesheet" href="../../Tools/jQ.css">
	<script>
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
		
		$( "#dialog3" ).dialog({
			autoOpen: false,
			show: "blind",
			hide: "explode"
		});

		$( "#opener3" ).click(function() {
			$( "#dialog3" ).dialog( "open" );
			return false;
		});
	});
	
	$(function() {
		$( "#datepicker" ).datepicker();
	});
	
	function MM_callJS(jsStr) { //v2.0
  	return eval(jsStr)
  	}
	
	function MM_openBrWindow(theURL,winName,features) { //v2.0
 	window.open(theURL,winName,features);
	}
	
	function MM_jumpMenu(theURL,winName,features){ //v3.0
  window.open(theURL.options[theURL.selectedIndex].value,winName,features);
  if (restore) theURL.selectedIndex=0;
  }
	
	</script>
<script type="text/javascript" src="stmenu.js"></script>

<style type="text/css">
<!--
.style18 {color: #005500}
.style26 {font-size: 6em}
-->
</style>
</head>
<body>
<table width="100%" border="0" align="center" background="Images/MainPageBackground.jpg">
  <tr>
    <td width="110"><div align="center"><a href="SessionOff">LogOut</a></div></td>
    <td width="891"><div align="center"><a href="#"  style="display:none;visibility:hidden;">Javascript DHTML Drop Down Menu Powered by dhtml-menu-builder.com</a><span class="ui-state-active style26">KPI_ICT_SiteOfficer </span></div></td>
  </tr>
  <tr>
    <td colspan="2"><form action="" method="post" name="form1" target="_self" id="form1">
      <table width="100%" border="1">
        <tr>
          <td width="50%"><div align="center" class="ui-widget-header"><a href="#">Problem</a> :
                
              <select name="Jmenu" onChange="MM_jumpMenu(this,'Report','width=1170,height=250,scrollbars=yes')">
                              <option value="#"> </option>
							  <option value="Maintenance.php?tCategory=Maintenance">Maintenance</option>
                              <option value="Breakdown.php?tCategory=Breakdown">Breakdown</option>
                            </select>
          </div></td>
          <td width="50%"><div align="center" class="ui-widget-header" id="opener2" > <a href="#">Asset</a></div></td>
        </tr>
      </table>
      <table width="100%" border="0">
        <tr>
          <td width="45%"><p align="center" class="ui-state-hover" id="opener1" ><strong><a href="#">Master KPI </a> </strong></p></td>
        </tr>
        <tr>
          <td><div id="dialog1" title=" Aprove Activity Maint-Break "> <iframe src="http://10.13.17.55/Reportserver/Pages/Report.aspx?%2fIT_Tangguh%2f_MaintBreak(Activity)&rs:Command=Render" id="Asset" name="Asset" width="97.5%" height="700" align="Center" hspace="0" vspace="0" scrollbar="yes">
</iframe> 
<input name="hPIC" type="hidden" id="hPIC" value="<? echo $hPIC; ?>" />
    </form></td>
  </tr>
  <tr>
    <td><div id="dialog2" title=" Asset "> <iframe src="http://10.13.17.55/Reportserver?%2fIT_Tangguh%2f_Asset&rs:Command=Render" id="Asset" name="Asset" width="97.5%" height="700" align="Center" hspace="0" vspace="0" scrollbar="yes">
</iframe>
</form></td>
  </tr>
  <tr>
    <td><div id="dialog3" title=" Asset "> <iframe src="http://10.13.17.55/Reports/Pages/Report.aspx?ItemPath=%2fIT_Tangguh%2f_MaintBreak(Activity)" id="Problem" name="Problem" width="100%" height="700" align="Center" hspace="0" vspace="0" scrollbar="yes">
</iframe>
</form></td>
  </tr>
</table>
<iframe src="http://10.13.17.55/Reportserver?%2fIT_Tangguh%2f_MasterKPI&rs:Command=Render" id="Master" name="Master" width="97.5%" height="700" align="Center" hspace="0" vspace="0" scrollbar="yes">
</iframe>
</body>
<?
$mati=@mssql_close($koneksi);
?>
</html>
