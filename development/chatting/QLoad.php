<?php
			require("koneksi.php");
			$koneksi=open_connection();
			$ca=mysql_query("select Akses from User where NRP='$_SESSION[User]'");
			$Ca=mysql_fetch_array($ca);
			$ca=mysql_query("select Akses from User where NRP='$Unrp'");
			$Ca=mysql_fetch_array($ca);
			$selDOPR=mysql_query("select * from User where Stat='1' and NRP<>'$Unrp' AND Dept='OPR' ORDER BY DATE DESC")
			or die ("Salah SQL!");
			$selDENG=mysql_query("select * from User where Stat='1' and NRP<>'$Unrp' AND Dept='ENG' ORDER BY DATE DESC")
			or die ("Salah SQL!");
			$selDPROD=mysql_query("select * from User where Stat='1' and NRP<>'$Unrp' AND Dept='PROD' ORDER BY DATE DESC")
			or die ("Salah SQL!");
			$selDPLANT=mysql_query("select * from User where Stat='1' and NRP<>'$Unrp' AND Dept='PLANT' ORDER BY DATE DESC")
			or die ("Salah SQL!");
			$selDHRPGA=mysql_query("select * from User where Stat='1' and NRP<>'$Unrp' AND Dept='HRPGA' ORDER BY DATE DESC")
			or die ("Salah SQL!");
			$selDFAT=mysql_query("select * from User where Stat='1' and NRP<>'$Unrp' AND Dept='FAT' ORDER BY DATE DESC")
			or die ("Salah SQL!");
			$selDLOG=mysql_query("select * from User where Stat='1' and NRP<>'$Unrp' AND Dept='LOG' ORDER BY DATE DESC")
			or die ("Salah SQL!");
			$selDSHE=mysql_query("select * from User where Stat='1' and NRP<>'$Unrp' AND Dept='SHE' ORDER BY DATE DESC")
			or die ("Salah SQL!");
			$selDTC=mysql_query("select * from User where Stat='1' and NRP<>'$Unrp' AND Dept='TC' ORDER BY DATE DESC")
			or die ("Salah SQL!");
?>
	<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="language" content="en" />
	<link rel="stylesheet" type="text/css" href="http://rantappu401:83/tools/layout-default-latest.css" />
	<link rel="stylesheet" type="text/css" href="http://rantappu401:83/tools/themes/south-street/jquery.ui.all.css" />
	<style type="text/css">
	.ui-layout-east .ui-layout-content { /* content-div has Accordion */
		padding: 0;
		overflow: hidden;
	}
	</style>
	
	<!-- REQUIRED scripts for layout widget -->
	<script type="text/javascript" src="http://rantappu401:83/tools/jquery-latest.js"></script>
	<script type="text/javascript" src="http://rantappu401:83/tools/jquery-ui-latest.js"></script>
	<script type="text/javascript" src="http://rantappu401:83/tools/jquery.layout-latest.js"></script>
	<script type="text/javascript" src="http://rantappu401:83/tools/jquery.layout.resizePaneAccordions-1.0.js"></script>
	
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

		
		// ACCORDION - in the East pane - in a 'content-div'
		$("#acc").accordion({
			fillSpace:	true
		,	active:		1
		});



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
        </script>
		
	
	
	</head>
	
	<body>	


	<div class="ui-layout-center" style="display: none;">
	<h3 class="ui-widget-header"><?php echo "OnlineLoad . . .";?></h3>

	<div class="ui-layout-content">
		<div id="acc" class="basic">
		
			<h3><a href="#">Dept. OPR</a></h3>
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

			<h3><a href="#">Dept. HRPGA</a></h3>
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

			<h3><a href="#">Dept. ENG</a></h3>
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

			<h3><a href="#">Dept. PLANT</a></h3>
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

			<h3><a href="#">Dept. PROD</a></h3>
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
			
			<h3><a href="#">Dept. FAT</a></h3>
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
			
			<h3><a href="#">Dept. LOG</a></h3>
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
			
			<h3><a href="#">Dept. SHE</a></h3>
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
			
			<h3><a href="#">Dept. TC</a></h3>
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
	
	
	</body>
