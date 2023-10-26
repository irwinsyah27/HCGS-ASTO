<?php

	session_start(); 
	
	require("Chatting/koneksi.php");
	$koneksi=open_connection();
	
	$sessions = array();

	$path = realpath(session_save_path());
	$files = array_diff(scandir($path), array('.', '..'));
	
	$Unrp = $_SESSION['UserID'];
	
	foreach ($files as $file)
	{
		$sessions[$file] = unserialize(file_get_contents($path . '/' . $file));
	}
	
	$UChat =  str_replace("sess_", "", "'".implode("', '", array_keys($sessions))."'");
	$UDel=mysql_query("UPDATE User SET Session_ID = NULL, Stat='0', Akses='0' WHERE Session_ID NOT IN ($UChat)") or die ("sessions kd mau dihapus");

	$str = 'sess_'.$PHPSESSID;

	if ($_SESSION['User']) {
		$coun=mysql_query("select COUNT(*) as ada from User where NRP='$Unrp'");
		$Cou=mysql_fetch_array($coun);
		$counAll=mysql_query("select COUNT(*) as ada from User where Stat='1'");
		$CouAll=mysql_fetch_array($counAll);
		if ($Cou[ada]=='0') {
		$INS=mysql_query("INSERT INTO User (Session_ID,Dept,NRP,Nama,Stat,Akses) VALUES ('$PHPSESSID','$_SESSION[Dept]','$Unrp','$_SESSION[SNama]','1','1')") or die ("Insert Gagal"); }
		else {
		$UPD=mysql_query("UPDATE User SET Session_ID='$PHPSESSID', Stat='1', Akses='1', Nama='$_SESSION[SNama]' WHERE NRP='$Unrp'") or die ("Update Gagal"); }
		
	}
	else {
		//ChatClose();
		echo ("<BODY> <SCRIPT language='Javascript'> alert('Anda Harus Login Dulu . . .!!'); </SCRIPT> </BODY>");
		echo ("<meta http-equiv=refresh content=1;url=http://pabbapco401.kppmining.net:83/development/SessionOff.php>");
		exit();	
	}

	
	
	
	
	
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="language" content="en" />

	<title>KPP ASTO</title>

	<link rel="stylesheet" type="text/css" href="http://pabbapco401.kppmining.net:83/development/tools/layout-default-latest.css" />
	<link rel="stylesheet" type="text/css" href="http://pabbapco401.kppmining.net:83/development/tools/themes/south-street/jquery.ui.all.css" />
	<!-- CUSTOMIZE/OVERRIDE THE DEFAULT CSS -->
	<link href="http://pabbapco401.kppmining.net:83/development/Tools/css/style.css" rel="stylesheet" type="text/css" media="screen" />
	<link media="screen" href="http://pabbapco401.kppmining.net:83/development/Tools/jquery.msg.css" rel="stylesheet" type="text/css">
	<link media="screen" href="http://pabbapco401.kppmining.net:83/development/Chatting/css/chat.css" rel="stylesheet" type="text/css">
	<link media="screen" href="http://pabbapco401.kppmining.net:83/development/Chatting/css/screen_ie.css" rel="stylesheet" type="text/css">
	<style type="text/css">

	/* remove padding and scrolling from elements that contain an Accordion OR a content-div */
	.ui-layout-center ,	/* has content-div */
	.ui-layout-west ,	/* has Accordion */
	.ui-layout-east ,	/* has content-div ... */
	.ui-layout-east .ui-layout-content { /* content-div has Accordion */
		padding: 0;
		overflow: hidden;
	}
	.ui-layout-center P.ui-layout-content {
		line-height:	1.4em;
		margin:			0; /* remove top/bottom margins from <P> used as content-div */
	}
	h3, h4 { /* Headers & Footer in Center & East panes */
		font-size:		1.1em;
		background:		#EEF;
		border:			1px solid #BBB;
		border-width:	0 0 1px;
		padding:		7px 10px;
		margin:			0;
	}
	.ui-layout-east h4 { /* Footer in East-pane */
		font-size:		0.9em;
		font-weight:	normal;
		border-width:	1px 0 0;
	}
	
	h2 {
	margin: 0;
	color: #618C04;
	}
	
	.styleHeader {
	font-family: Georgia, "Times New Roman", Times, serif;
	font-size: 18px;
	}
	
	
	</style>

	<!-- REQUIRED scripts for layout widget -->
	<script type="text/javascript" src="http://pabbapco401.kppmining.net:83/development/tools/jquery-latest.js"></script>
	<script type="text/javascript" src="http://pabbapco401.kppmining.net:83/development/tools/jquery-ui-latest.js"></script>
	<script type="text/javascript" src="http://pabbapco401.kppmining.net:83/development/tools/jquery.layout-latest.js"></script>
	<script type="text/javascript" src="http://pabbapco401.kppmining.net:83/development/tools/jquery.layout.resizePaneAccordions-1.0.js"></script>
	<script type="text/javascript" src="http://pabbapco401.kppmining.net:83/development/Tools/jquery.center.min.js"></script>
	<script type="text/javascript" src="http://pabbapco401.kppmining.net:83/development/Tools/jquery.msg.min.js"></script>
	<script type="text/javascript" src="http://pabbapco401.kppmining.net:83/development/Tools/chat.js"></script>
	<!-- compressed: /lib/js/jquery.layout.resizePaneAccordions.min-1.0.js -->

   <!-- <script type="text/javascript" src="themeswitchertool.js"></script> -->
   <!--  <script type="text/javascript" src="debug.js"></script> -->

	<script type="text/javascript">
	$(document).ready( function() {

		myLayout = $('body').layout({
			west__size:			180
		,	east__size:			180
		,	north__size:			80
		,	south__size:			40
			// RESIZE Accordion widget when panes resize
		,	west__onresize:		$.layout.callbacks.resizePaneAccordions
		,	east__onresize:		$.layout.callbacks.resizePaneAccordions
		});

		// ACCORDION - in the West pane
		$("#accordion1").accordion({ fillSpace:	true });
		
		// ACCORDION - in the East pane - in a 'content-div'
		$("#accordion2").accordion({
			fillSpace:	true
		,	active:		1
		});


		// THEME SWITCHER
		addThemeSwitcher('.ui-layout-north',{ top: '12px', right: '5px' });
		// if a new theme is applied, it could change the height of some content,
		// so call resizeAll to 'correct' any header/footer heights affected
		// NOTE: this is only necessary because we are changing CSS *AFTER LOADING* using themeSwitcher
		setTimeout( myLayout.resizeAll, 1000 ); /* allow time for browser to re-render with new theme */

	});
	
	</script>
	
	<script>
            $('.item').hover(
                function(){
                    var $this = $(this);
                    expand($this);
                },
                function(){
                    var $this = $(this);
                    collapse($this);
                }
            );
            function expand($elem){
                var angle = 0;
                var t = setInterval(function () {
                    if(angle == 1440){
                        clearInterval(t);
                        return;
                    }
                    angle += 40;
                    $('.link',$elem).stop().animate({rotate: '+=-40deg'}, 0);
                },10);
                $elem.stop().animate({width:'268px'}, 1000)
                .find('.item_content').fadeIn(400,function(){
                    $(this).find('p').stop(true,true).fadeIn(600);
                });
            }
            function collapse($elem){
                var angle = 1440;
                var t = setInterval(function () {
                    if(angle == 0){
                        clearInterval(t);
                        return;
                    }
                    angle -= 40;
                    $('.link',$elem).stop().animate({rotate: '+=40deg'}, 0);
                },10);
                $elem.stop().animate({width:'52px'}, 1000)
                .find('.item_content').stop(true,true).fadeOut().find('p').stop(true,true).fadeOut();
            }
			
			var autoLoad = setInterval(   function ()   {      $('#QLOPR1').load('chatting/QLoad/QLOPR.php?Unrp=$Unrp').fadeIn("slow");   }, 13000);
			
			
        </script>
		
		


</head>
<div id="QLoad">
		<?php
			$ca=mysql_query("select Akses from User where NRP='".$Unrp."'");
			$Ca=mysql_fetch_array($ca);
			$selDOPR=mysql_query("select * from User where Stat='1' and NRP<>'".$Unrp."' AND Dept='OPR' ORDER BY DATE DESC")
			or die ("Salah SQL!");
			$selDENG=mysql_query("select * from User where Stat='1' and NRP<>'".$Unrp."' AND Dept='ENG' ORDER BY DATE DESC")
			or die ("Salah SQL!");
			$selDPROD=mysql_query("select * from User where Stat='1' and NRP<>'".$Unrp."' AND Dept='HAULING' ORDER BY DATE DESC")
			or die ("Salah SQL!");
			$selDPLANT=mysql_query("select * from User where Stat='1' and NRP<>'".$Unrp."' AND Dept='PLANT' ORDER BY DATE DESC")
			or die ("Salah SQL!");
			$selDHRPGA=mysql_query("select * from User where Stat='1' and NRP<>'".$Unrp."' AND Dept='HRGA' ORDER BY DATE DESC")
			or die ("Salah SQL!");
			$selDFAT=mysql_query("select * from User where Stat='1' and NRP<>'".$Unrp."' AND Dept='FAT' ORDER BY DATE DESC")
			or die ("Salah SQL!");
			$selDLOG=mysql_query("select * from User where Stat='1' and NRP<>'".$Unrp."' AND Dept='SM' ORDER BY DATE DESC")
			or die ("Salah SQL!");
			$selDSHE=mysql_query("select * from User where Stat='1' and NRP<>'".$Unrp."' AND Dept='SHE' ORDER BY DATE DESC")
			or die ("Salah SQL!");
			$selDTC=mysql_query("select * from User where Stat='1' and NRP<>'".$Unrp."' AND Dept='TC' ORDER BY DATE DESC")
			or die ("Salah SQL!");
		?>
</div>
<body onLoad="myLayout.close('west');myLayout.close('south')">

<div class="ui-layout-north ui-widget-content" style="display: none;">
			<div class="item">
                <a class="link icon_logoff"></a>
                <div class="item_content">
                    <h2>LogOff</h2>
                    <pM>
                        <a href="http://pabbapco401.kppmining.net:83/development/SessionOff.php" onclick="$.msg({fadeIn : 200, fadeOut : 200, timeOut : 500});">Logoff</a>
					</pM>
				</div>
            </div>
			<div class="item">
                <a class="link icon_find"></a>
                <div class="item_content">
                    <h2>Search</h2>
                    <pM>
                        <input type="text"></input>
                        <a href="http://pabbapco401.kppmining.net:83/development/Tools/extlpn.pdf" target="kanan" onclick="$.msg({fadeIn : 200, fadeOut : 200, timeOut : 500});">Go</a>
					</pM>
				</div>
            </div>
			<div class="item">
                <a class="link icon_apps2"></a>
                <div class="item_content">
                    <h2>Application Interface</h2>
                    <pM>
                        <a href="//pabbapco401.kppmining.net:83/development/MeetingOL/Utama" target="kanan" onclick="$.msg({fadeIn : 200, fadeOut : 200, timeOut : 500});">Meeting</a>
                        <a href="http://pabbapco401.kppmining.net:83/development/TaskFlow/Utama.php" target="kanan" onclick="$.msg({fadeIn : 200, fadeOut : 200, timeOut : 500});">TaskFlow</a>
                        <a href="http://pabbapco401.kppmining.net:83/development/SHES/Utama.php" target="kanan" onclick="$.msg({fadeIn : 200, fadeOut : 200, timeOut : 500});">SMS</a>
                        <a href="http://webserver/webtop/" target="kanan" onclick="$.msg({fadeIn : 500, fadeOut : 500, timeOut : 3000});">DMS</a>
                    </pM>
                </div>
            </div>
			<div class="item">
                <a class="link icon_apps1"></a>
                <div class="item_content">
                    <h2>Application By Dept</h2>
                    <pM>
					    <a href="//pabbapco401.kppmining.net:81/HRGA" target="kanan" onclick="$.msg({fadeIn : 200, fadeOut : 200, timeOut : 500});">Hrga-OL</a>
                        <a href="http://pabbapco401.kppmining.net:83/development/EWACS/Index.htm" target="kanan" onclick="$.msg({fadeIn : 200, fadeOut : 200, timeOut : 500});">Ewacs</a>
                        <a href="http://pabbapco401.kppmining.net:83/development/Budget/Screen.php" target="kanan" onclick="$.msg({fadeIn : 500, fadeOut : 500, timeOut : 5000});">R-bu-S</a>
                        <a href="http://pabbapco401.kppmining.net:83/development/Sigap/Utama.php" target="kanan" onclick="$.msg({fadeIn : 200, fadeOut : 200, timeOut : 500});">Security</a>
                    </pM>
                </div>
            </div>
            <div class="item">
                <a class="link icon_profile"></a>
                <div class="item_content">
                    <h2>Profile</h2>
                    <pM>
                        <a href="http://kppweb/overview.aspx" target="kanan" onclick="$.msg({fadeIn : 200, fadeOut : 200, timeOut : 500});">Overview</a>
                        <a href="http://kppweb/visimisi.aspx" target="kanan" onclick="$.msg({fadeIn : 200, fadeOut : 200, timeOut : 500});">Visi&MIsi</a>
                    </pM>
                </div>
            </div>
            <div class="item">
                <a class="link icon_home"></a>
                <div class="item_content">
                    <h2>HOME</h2>
                    <pM>
                        <a href="//pabbapco401.kppmining.net:83/development/Berita/Utama.php?mJenis=All" target="kanan" onclick="$.msg({fadeIn : 200, fadeOut : 200, timeOut : 500});">News</a>
                        <a href="" target="kanan" onclick="$.msg({fadeIn : 200, fadeOut : 200, timeOut : 500});">CSR</a>
                        <a href="https://mail.runagworld.net/owa" target="kanan" onclick="$.msg({fadeIn : 500, fadeOut : 500, timeOut : 5000});">Mail</a>                   
					</pM>
                </div>
        </div>
		
<p><a class="styleHeader">KPPMINING</a></p>
<p>PT. Kalimantan Prima Persada district <?PHP IF($_SESSION[Site]=='KPTO') { echo 'ASTO ('.$_SESSION[Site].')'; } ELSE { echo 'ASTO ('.$_SESSION[Site].')'; };?></p>
</div>

<div class="ui-layout-south ui-widget-content ui-state-error" style="display: none;"> Notification !! </div>

<div class="ui-layout-center" style="display: none;"> 
	<h3 class="ui-widget-header">Center Page</h3>
	<!-- <div class="ui-layout-content ui-widget-content"> -->
		<iframe src="<?php if($Link!=''){echo $Link;} else { echo "http://pabbapco401.kppmining.net:83/development/Berita/NilaiInti.php";} ?>" id="kanan" name="kanan" width="100%" height="100%" align="Center" hspace="0" vspace="0" scrollbar="yes"> </iframe>
	<!-- </div> -->
</div>

<div class="ui-layout-west" style="display: none;">
	<div id="accordion1" class="basic">

			<h3><a href="#">Section 1</a></h3>
			<div>
				<h5></h5>
				<p></p>
				<p></p>
			</div>

			<h3><a href="#">Section 2</a></h3>
			<div>
				<h5></h5>
				<p></p>
				<p></p>
			</div>

			<h3><a href="#">Section 3</a></h3>
			<div>
				<p></p>
				<p></p>
				<ul>
					<li></li>
					<li></li>
					<li></li>
				</ul>
			</div>

			<h3><a href="#">Section 4</a></h3>
			<div>
				<p></p>
				<p></p>
				<p></p>
			</div>
		
	</div>
</div>


<div class="ui-layout-east" style="display: none;">
	<h3 class="ui-widget-header"><div id="QLTot"><?php echo $CouAll[ada].' User  Online . . .'?></div></h3>

	<div class="ui-layout-content">
		<div id="accordion2" class="basic">
		
			<h3><a href="#" onClick=loadIDOPR(<?php echo $Unrp; ?>);loadTot(<?php echo $Unrp; ?>);>Dept. OPR</a></h3>
			<div id="QLOPR">
			<?php
				// ------ ambil isi masing-masing record
				while ($row = mysql_fetch_object($selDOPR))
			{
			// ----- mengambil isi setiap kolom
			$NRP=strtoupper($row->NRP);
			$Nama=str_replace(" ", "_",strtoupper($row->Nama));
			$Akses=$row->Akses;
			// ------ menampilkan di layar browser
			IF($Ca[Akses]=='1') {
			echo("<a align=center href=javascript:void(0) 
				onClick=javascript:chatWith('$NRP')>( $NRP )</a><ul><li>$Nama</li></ul></p>");
			} Else {
			echo("<a align=center href=javascript:void(0) 
				onClick=PesanChat()>[ $NRP ]</a><img src='Images/KPP/chat.png'/>  ");
			}
			}
			?>
			</div>

			<h3><a href="#" onClick=loadIDHRPGA(<?php echo $Unrp; ?>);loadTot(<?php echo $Unrp; ?>);>Dept. HRPGA</a></h3>
			<div id="QLHRPGA">
			<?php
				// ------ ambil isi masing-masing record
				while ($row = mysql_fetch_object($selDHRPGA))
			{
			// ----- mengambil isi setiap kolom
			$NRP=strtoupper($row->NRP);
			$Nama=str_replace(" ", "_",strtoupper($row->Nama));
			$Akses=$row->Akses;
			// ------ menampilkan di layar browser
			IF($Ca[Akses]=='1') {
			echo("<a align=center href=javascript:void(0) 
				onClick=javascript:chatWith('$NRP')>( $NRP )</a><ul><li>$Nama</h5></li></ul></p>");
			} Else {
			echo("<a align=center href=javascript:void(0) 
				onClick=PesanChat()>[ $NRP ]</a><img src='Images/KPP/chat.png'/>  ");
			}
			}
			?>
			</div>

			<h3><a href="#" onClick=loadIDENG(<?php echo $Unrp; ?>);loadTot(<?php echo $Unrp; ?>);>Dept. ENG</a></h3>
			<div id="QLENG">
			<?php
				// ------ ambil isi masing-masing record
				while ($row = mysql_fetch_object($selDENG))
			{
			// ----- mengambil isi setiap kolom
			$NRP=strtoupper($row->NRP);
			$Nama=str_replace(" ", "_",strtoupper($row->Nama));
			$Akses=$row->Akses;
			// ------ menampilkan di layar browser
			IF($Ca[Akses]=='1') {
			echo("<a align=center href=javascript:void(0) 
				onClick=javascript:chatWith('$NRP')>( $NRP )</a><ul><li>$Nama</h5></li></ul></p>");
			} Else {
			echo("<a align=center href=javascript:void(0) 
				onClick=PesanChat()>[ $NRP ]</a><img src='Images/KPP/chat.png'/>  ");
			}
			}
			?>
			</div>

			<h3><a href="#" onClick=loadIDPLANT(<?php echo $Unrp; ?>);loadTot(<?php echo $Unrp; ?>);>Dept. PLANT</a></h3>
			<div id="QLPLANT">
			<?php
				// ------ ambil isi masing-masing record
				while ($row = mysql_fetch_object($selDPLANT))
			{
			// ----- mengambil isi setiap kolom
			$NRP=strtoupper($row->NRP);
			$Nama=str_replace(" ", "_",strtoupper($row->Nama));
			$Akses=$row->Akses;
			// ------ menampilkan di layar browser
			IF($Ca[Akses]=='1') {
			echo("<a align=center href=javascript:void(0) 
				onClick=javascript:chatWith('$NRP')>( $NRP )</a><ul><li>$Nama</li></ul></p>");
			} Else {
			echo("<a align=center href=javascript:void(0) 
				onClick=PesanChat()>[ $NRP ]</a><img src='Images/KPP/chat.png'/>  ");
			}
			}
			?>
			</div>

			<h3><a href="#" onClick=loadIDPROD(<?php echo $Unrp; ?>);loadTot(<?php echo $Unrp; ?>);>Dept. PROD</a></h3>
			<div id="QLPROD">
			<?php
				// ------ ambil isi masing-masing record
				while ($row = mysql_fetch_object($selDPROD))
			{
			// ----- mengambil isi setiap kolom
			$NRP=strtoupper($row->NRP);
			$Nama=str_replace(" ", "_",strtoupper($row->Nama));
			$Akses=$row->Akses;
			// ------ menampilkan di layar browser
			IF($Ca[Akses]=='1') {
			echo("<a align=center href=javascript:void(0) 
				onClick=javascript:chatWith('$NRP')>( $NRP )</a><ul><li>$Nama</li></ul></p>");
			} Else {
			echo("<a align=center href=javascript:void(0) 
				onClick=PesanChat()>[ $NRP ]</a><img src='Images/KPP/chat.png'/>  ");
			}
			}
			?>
			</div>
			
			<h3><a href="#" onClick=loadIDFAT(<?php echo $Unrp; ?>);loadTot(<?php echo $Unrp; ?>);>Dept. FAT</a></h3>
			<div id="QLFAT">
			<?php
				// ------ ambil isi masing-masing record
				while ($row = mysql_fetch_object($selDFAT))
			{
			// ----- mengambil isi setiap kolom
			$NRP=strtoupper($row->NRP);
			$Nama=str_replace(" ", "_",strtoupper($row->Nama));
			$Akses=$row->Akses;
			// ------ menampilkan di layar browser
			IF($Ca[Akses]=='1') {
			echo("<a align=center href=javascript:void(0) 
				onClick=javascript:chatWith('$NRP')>( $NRP )</a><ul><li>$Nama</li></ul></p>");
			} Else {
			echo("<a align=center href=javascript:void(0) 
				onClick=PesanChat()>[ $NRP ]</a><img src='Images/KPP/chat.png'/>  ");
			}
			}
			?>
			</div>
			
			<h3><a href="#" onClick=loadIDLOG(<?php echo $Unrp; ?>);loadTot(<?php echo $Unrp; ?>);>Dept. LOG</a></h3>
			<div id="QLLOG">
			<?php
				// ------ ambil isi masing-masing record
				while ($row = mysql_fetch_object($selDLOG))
			{
			// ----- mengambil isi setiap kolom
			$NRP=strtoupper($row->NRP);
			$Nama=str_replace(" ", "_",strtoupper($row->Nama));
			$Akses=$row->Akses;
			// ------ menampilkan di layar browser
			IF($Ca[Akses]=='1') {
			echo("<a align=center href=javascript:void(0) 
				onClick=javascript:chatWith('$NRP')>( $NRP )</a><ul><li>$Nama</li></ul></p>");
			} Else {
			echo("<a align=center href=javascript:void(0) 
				onClick=PesanChat()>[ $NRP ]</a><img src='Images/KPP/chat.png'/>  ");
			}
			}
			?>
			</div>
			
			<h3><a href="#" onClick=loadIDSHE(<?php echo $Unrp; ?>);loadTot(<?php echo $Unrp; ?>);>Dept. SHE</a></h3>
			<div id="QLSHE">
			<?php
				// ------ ambil isi masing-masing record
				while ($row = mysql_fetch_object($selDSHE))
			{
			// ----- mengambil isi setiap kolom
			$NRP=strtoupper($row->NRP);
			$Nama=str_replace(" ", "_",strtoupper($row->Nama));
			$Akses=$row->Akses;
			// ------ menampilkan di layar browser
			IF($Ca[Akses]=='1') {
			echo("<a align=center href=javascript:void(0) 
				onClick=javascript:chatWith('$NRP')>( $NRP )</a><ul><li>$Nama</li></ul></p>");
			} Else {
			echo("<a align=center href=javascript:void(0) 
				onClick=PesanChat()>[ $NRP ]</a><img src='Images/KPP/chat.png'/>  ");
			}
			}
			?>
			</div>
			
			<h3><a href="#" onClick=loadIDTC(<?php echo $Unrp; ?>);loadTot(<?php echo $Unrp; ?>);>Dept. TC</a></h3>
			<div id="QLSHE">
			<?php
				// ------ ambil isi masing-masing record
				while ($row = mysql_fetch_object($selDTC))
			{
			// ----- mengambil isi setiap kolom
			$NRP=strtoupper($row->NRP);
			$Nama=str_replace(" ", "_",strtoupper($row->Nama));
			$Akses=$row->Akses;
			// ------ menampilkan di layar browser
			IF($Ca[Akses]=='1') {
			echo("<a align=center href=javascript:void(0) 
				onClick=javascript:chatWith('$NRP')>( $NRP )</a><ul><li>$Nama</li></ul></p>");
			} Else {
			echo("<a align=center href=javascript:void(0) 
				onClick=PesanChat()>[ $NRP ]</a><img src='Images/KPP/chat.png'/>  ");
			}
			}
			?>
			</div>

		</div>
	</div>

	<h4 class="ui-widget-content ui-state-hover"><?php echo $Unrp; echo" [ "; echo $_SESSION[SNama]; echo" ]";?></h4>
</div>
	
	<!-- script untuk Menu -->
    <script type="text/javascript" src="http://pabbapco401.kppmining.net:83/development/tools/jquery-animate-css-rotate-scale.js"></script>
	<script>
            $('.item').hover(
                function(){
                    var $this = $(this);
                    expand($this);
                },
                function(){
                    var $this = $(this);
                    collapse($this);
                }
            );
            function expand($elem){
                var angle = 0;
                var t = setInterval(function () {
                    if(angle == 1440){
                        clearInterval(t);
                        return;
                    }
                    angle += 40;
                    $('.link',$elem).stop().animate({rotate: '+=-40deg'}, 0);
                },10);
                $elem.stop().animate({width:'268px'}, 1000)
                .find('.item_content').fadeIn(400,function(){
                    $(this).find('p').stop(true,true).fadeIn(600);
                });
            }
            function collapse($elem){
                var angle = 1440;
                var t = setInterval(function () {
                    if(angle == 0){
                        clearInterval(t);
                        return;
                    }
                    angle -= 40;
                    $('.link',$elem).stop().animate({rotate: '+=40deg'}, 0);
                },10);
                $elem.stop().animate({width:'52px'}, 1000)
                .find('.item_content').stop(true,true).fadeOut().find('p').stop(true,true).fadeOut();
            }
			
	
        </script>

		<!-- script untuk load page -->
		<script type="text/javascript" charset="utf-8">
      // wrap everything in document ready event
      $( function(){
        
        $( '#default' ).bind( 'click', function(){
          $.msg();
        });
        
        $( '#custom-content' ).bind( 'click', function(){
          $.msg({ content: 'blah blah' });
        });
        
        $( '#disable-auto-unblock' ).bind( 'click', function(){
          $.msg({ autoUnblock : false });
        });
        
        $( '#custom-speed' ).bind( 'click', function(){
          $.msg({ 
            fadeIn : 500,
            fadeOut : 200,
            timeOut : 5000 
          });
        });
        
        $( '#switch-theme' ).bind( 'click', function(){
          $.msg({ klass : 'white-on-black' });
        });
        
        $( '#custom-theme' ).bind( 'click', function(){
          $.msg({ klass : 'custom-theme' });
        });
        
        // block the screen to show msg when click on #replace-content btn
        $( '#replace-content' ).bind( 'click', function(){
          $.msg({ 
            autoUnblock : false,
            clickUnblock : false,
            content: '<p>Delete this user?</p>' +
                     '<p class="btn-wrap">' + 
                       '<span id="yes">Yes</span>' + 
                       '<span id="no">no</span>' + 
                     '</p>',
            afterBlock : function(){
              // store 'this' for other scope to use
              var self = this;
              
              // delete user and auto unblock the screen after 1 second
              // when click #yes btn
              $( '#yes' ).bind( 'click', function(){
                
                // self.method is not chainable
                self.replace( 'User deleted.' );
                self.unblock( 2000 );
                // this equals to 
                // $.msg( 'replace', 'User deleted.' ).
                //   msg( 'unblock', 2000 );
                
                $( '#the-user' ).empty();
              });
              
              $( '#no' ).bind( 'click', function(){
                
                // this equals to $.msg( 'unblock' );
                self.unblock();
              });
            },
            beforeUnblock : function(){
              alert( 'This is a callback from beforeUnblock event handler :)' )
            }
          });
        });
        
        $( '#restore-user' ).bind( 'click', function(){
          $( '#the-user' ).text( 'I am the user' );
        });
        
      });
      	
		function PesanChat() {
		alert("NotAccsess");
		}
		
		function loadTot(nrp){
                 $('#QLTot').load('chatting/QLoad/QLTot.php?Unrp='+nrp).fadeIn("slow");
			}
		function loadIDOPR(nrp){
                 $('#QLOPR').load('chatting/QLoad/QLOPR.php?Unrp='+nrp).fadeIn("slow");
            }
		function loadIDHRPGA(nrp){
                 $('#QLHRPGA').load('chatting/QLoad/QLHRPGA.php?Unrp='+nrp).fadeIn("slow");
            }
		function loadIDENG(nrp){
                 $('#QLENG').load('chatting/QLoad/QLENG.php?Unrp='+nrp).fadeIn("slow");
            }
		function loadIDPLANT(nrp){
                 $('#QLPLANT').load('chatting/QLoad/QLPLANT.php?Unrp='+nrp).fadeIn("slow");
            }
		function loadIDLOG(nrp){
                 $('#QLLOG').load('chatting/QLoad/QLLOG.php?Unrp='+nrp).fadeIn("slow");
            }
		function loadIDFAT(nrp){
                 $('#QLFAT').load('chatting/QLoad/QLFAT.php?Unrp='+nrp).fadeIn("slow");
            }
		function loadIDSHE(nrp){
                 $('#QLSHE').load('chatting/QLoad/QLSHE.php?Unrp='+nrp).fadeIn("slow");
            }
		function loadIDTC(nrp){
                 $('#QLTC').load('chatting/QLoad/QLTC.php?Unrp='+nrp).fadeIn("slow");
            }
		
        </script>
	
</body>
<?
mysql_close($koneksi);
?>
</html> 