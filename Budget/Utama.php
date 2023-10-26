<?
session_start();
//require("cek.php");
// ----- ambil isi dari file koneksi.php
//require("tools/koneksi.php");
// ----- hubungkan ke database
//$koneksi=open_connection();
?>

<html>
<style type="text/css">
<!--
.style6 {color: #000000; font-weight: bold; font-family: "Courier New", Courier, monospace; font-size: 18px; }
.style7 {
	color: #CCCCFF;
	font-size: 24px;
	font-weight: bold;
	font-family: Arial, Helvetica, sans-serif;
}
#Layer1 {
	position:absolute;
	left:17px;
	top:85px;
	width:991px;
	height:39px;
	z-index:1;
}
.style8 {color: #CCCCFF; font-weight: bold; font-family: "Courier New", Courier, monospace; font-size: 18px; }
-->
</style>
<script language="JavaScript">
<!--
function mmLoadMenus() {
  if (window.mm_menu_0114141821_0) return;
      window.mm_menu_0114141821_0 = new Menu("root",110,18,"",12,"#CCCCFF","#9999FF","#FFFF99","#CCFF66","left","middle",3,0,1000,-5,7,true,false,true,0,true,true);
  mm_menu_0114141821_0.addMenuItem("Budget","window.open('?mm=101', '_self');");
  mm_menu_0114141821_0.addMenuItem("Highlight&nbsp;PLO","window.open('?mm=102', '_self');");
   mm_menu_0114141821_0.fontWeight="bold";
   mm_menu_0114141821_0.hideOnMouseOut=true;
   mm_menu_0114141821_0.bgColor='#555555';
   mm_menu_0114141821_0.menuBorder=1;
   mm_menu_0114141821_0.menuLiteBgColor='#FFFFFF';
   mm_menu_0114141821_0.menuBorderBgColor='#777777';
      window.mm_menu_0114141921_0 = new Menu("root",148,18,"",12,"#CCCCFF","#9999FF","#FFFF99","#CCFF66","left","middle",3,0,1000,-5,7,true,false,true,0,true,true);
  mm_menu_0114141921_0.addMenuItem("ProductionSchedulle","window.open('?mm=201', '_self');");
  mm_menu_0114141921_0.addMenuItem("Investment","window.open('?mm=202', '_self');");
  mm_menu_0114141921_0.addMenuItem("PLO","window.open('?mm=203', '_self');");
   mm_menu_0114141921_0.fontWeight="bold";
   mm_menu_0114141921_0.hideOnMouseOut=true;
   mm_menu_0114141921_0.bgColor='#555555';
   mm_menu_0114141921_0.menuBorder=1;
   mm_menu_0114141921_0.menuLiteBgColor='#FFFFFF';
   mm_menu_0114141921_0.menuBorderBgColor='#777777';
  window.mm_menu_0114142000_0 = new Menu("root",102,18,"",12,"#CCCCFF","#9999FF","#FFFF99","#CCFF66","left","middle",3,0,1000,-5,7,true,false,true,0,true,true);
  mm_menu_0114142000_0.addMenuItem("Management","window.open('?mm=301', '_self');");
  mm_menu_0114142000_0.addMenuItem("HRPGA","window.open('?mm=302', '_self');");
  mm_menu_0114142000_0.addMenuItem("ENG","window.open('?mm=303', '_self');");
  mm_menu_0114142000_0.addMenuItem("PROD","window.open('?mm=304', '_self');");
  mm_menu_0114142000_0.addMenuItem("PLANT","window.open('?mm=305', '_self');");
  mm_menu_0114142000_0.addMenuItem("LOG","window.open('?mm=306', '_self');");
  mm_menu_0114142000_0.addMenuItem("FAT","window.open('?mm=307', '_self');");
  mm_menu_0114142000_0.addMenuItem("SHE","window.open('?mm=308', '_self');");
   mm_menu_0114142000_0.fontWeight="bold";
   mm_menu_0114142000_0.hideOnMouseOut=true;
   mm_menu_0114142000_0.bgColor='#555555';
   mm_menu_0114142000_0.menuBorder=1;
   mm_menu_0114142000_0.menuLiteBgColor='#FFFFFF';
   mm_menu_0114142000_0.menuBorderBgColor='#777777';
  window.mm_menu_0114142031_0 = new Menu("root",72,18,"",12,"#CCCCFF","#9999FF","#FFFF99","#CCFF66","left","middle",3,0,1000,-5,7,true,false,true,0,true,true);
  mm_menu_0114142031_0.addMenuItem("####01","window.open('?mm=401', '_self');");
  mm_menu_0114142031_0.addMenuItem("####02","window.open('?mm=402', '_self');");
   mm_menu_0114142031_0.fontWeight="bold";
   mm_menu_0114142031_0.hideOnMouseOut=true;
   mm_menu_0114142031_0.bgColor='#555555';
   mm_menu_0114142031_0.menuBorder=1;
   mm_menu_0114142031_0.menuLiteBgColor='#FFFFFF';
   mm_menu_0114142031_0.menuBorderBgColor='#777777';
  window.mm_menu_0114142053_0 = new Menu("root",121,18,"",12,"#CCCCFF","#9999FF","#FFFF99","#CCFF66","left","middle",3,0,1000,-5,7,true,false,true,0,true,true);
  mm_menu_0114142053_0.addMenuItem("PIT&nbsp;BRE","window.open('?mm=501', '_self');");
  mm_menu_0114142053_0.addMenuItem("PIT&nbsp;EBL","window.open('?mm=502', '_self');");
  mm_menu_0114142053_0.addMenuItem("PIT&nbsp;PEMT","window.open('?mm=503', '_self');");
  mm_menu_0114142053_0.addMenuItem("PIT&nbsp;CABE","window.open('?mm=504', '_self');");
  mm_menu_0114142053_0.addMenuItem("PIT&nbsp;PERSADA","window.open('?mm=505', '_self');");
   mm_menu_0114142053_0.fontWeight="bold";
   mm_menu_0114142053_0.hideOnMouseOut=true;
   mm_menu_0114142053_0.bgColor='#555555';
   mm_menu_0114142053_0.menuBorder=1;
   mm_menu_0114142053_0.menuLiteBgColor='#FFFFFF';
   mm_menu_0114142053_0.menuBorderBgColor='#777777';
  window.mm_menu_0114142232_0 = new Menu("root",95,18,"",12,"#CCCCFF","#9999FF","#FFFF99","#CCFF66","left","middle",3,0,1000,-5,7,true,false,true,0,true,true);
  mm_menu_0114142232_0.addMenuItem("OB","location='?mm=601'");
  mm_menu_0114142232_0.addMenuItem("SALE","location='?mm=602'");
  mm_menu_0114142232_0.addMenuItem("COAL","location='?mm=603'");
  mm_menu_0114142232_0.addMenuItem("HOULING","location='?mm=604'");
   mm_menu_0114142232_0.fontWeight="bold";
   mm_menu_0114142232_0.hideOnMouseOut=true;
   mm_menu_0114142232_0.bgColor='#555555';
   mm_menu_0114142232_0.menuBorder=1;
   mm_menu_0114142232_0.menuLiteBgColor='#FFFFFF';
   mm_menu_0114142232_0.menuBorderBgColor='#777777';

mm_menu_0114142232_0.writeMenus();
} // mmLoadMenus()
//-->
</script>
<script type="text/javascript" language="javascript">
	<!--
	/*
	 * Copyright(c) 1998-99. Teg Workz. All Rights Reserved.
	 *
	 * 	The script is for public use w/o warranty or support
	 *	of any kind. No function or any portion thereof aside 
	 *	from writeOnText() and txtTyper() shall be used
	 *	or copied anywhere else without the author's consent.
	 *	Violators will be prosecuted by the full extent of
	 *	the law.
	 *
	 *		script title	: Text Typer 1.0b
	 *		script domain	: public
	 *		date created	: 8/25/98 9:31PM
	 *		last update	: 8/26/98
	 *
	 * 			Emmanuel C. Halos - agent_teg@ThePentagon.com
	 *				"MABUHAY ang PILIPINAS!!!"
	 *
	 *	http://home.talkcity.com/TechnologyWay/teg%60/
	 *	http://www2.mozcom.com/~halos/
	 *
	 * End of Copyright u may remove the ff lines:
	 *	HISTORY: 1.0 	only type texts... no support for
	 *		 	WAVs/other audio format
	 *		 1.0b	support for NS plugins
	 *		 1.0c	support for NS/IE plugins/activeX.
	 *			no activeX detection procedure was 
	 *			made.
	 *		 2.0    rewrote the script. no support for sound.
	 *			different function
	 *		 2.5	added a parser so html tags could be used
	 *			(to a limited degree)
	 *
	 *	DESCRIPTION: Mediocre script ;) This one types 
	 *		     a series of text letter-by-letter.
	 *
	 *	SYNTAX: txtTyper('string', 0, 'style1', 'style2', 'normalcolor', 'typedcolor', delay, playsound);
	 *		string - the message to be displayed
	 *		style1 - ID style
	 *		style2 - style of text inside style1
	 *		normalcolor - final color of texts (unless string has html tags)
	 *		typedcolor - color of text while being written
	 *		delay - pause in millisecond between typing
	 *		playsound - 0 - no sound and 1 - play sound
	 *
	 */

	var layers = document.layers, style = document.all, both = layers || style, idme=908601;
	if (layers) { layerRef = 'document.layers'; styleRef = ''; } if (style) { layerRef = 'document.all'; styleRef = '.style'; }

	function writeOnText(obj, str) {
	  if (layers) with (document[obj]) { document.open();  document.write(str); document.close(); }
	  if (style) eval(obj+'.innerHTML= str');
	}

	var dispStr = new Array(
		"<b>Selamat datang di <font color=#00FF00>Budget Report System</font> . . .</b> &nbsp; &nbsp; &nbsp; &nbsp; <br> <br> . . .&nbsp; v e r s i. . . . <font color=#00FF00>1.0</font> <br><br>  . . . . &nbsp;  . . . . <font color=#00FF00>. .</font> <br> <br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> &nbsp; &copy; Copyright IT rantau &nbsp;. . . ."
	);

	var overMe=0;

	function txtTyper(str, idx, idObj, spObj, clr1, clr2, delay, plysnd) {
	  var tmp0 = tmp1 = '', skip = 0;
	    if (both && idx <= str.length) {
		if (str.charAt(idx) == '<') { while (str.charAt(idx) != '>') idx++; idx++; }
		if (str.charAt(idx) == '&' && str.charAt(idx+1) != ' ') { while (str.charAt(idx) != ';') idx++; idx++; }
		tmp0 = str.slice(0,idx);
		tmp1 = str.charAt(idx++);

		if (overMe==0 && plysnd==1) {
		  if (navigator.plugins[0]) {
		    if (navigator.plugins["LiveAudio"][0].type=="audio/basic" && navigator.javaEnabled()) {
			document.embeds[0].stop();
			setTimeout("document.embeds[0].play(false)",100); }
		  } else if (document.all) {
			ding.Stop();
			setTimeout("ding.Run()",100);
		  }
		  overMe=1;
		} else overMe=0;

		writeOnText(idObj, "<span class="+spObj+"><font color='"+clr1+"'>"+tmp0+"</font><font color='"+clr2+"'>"+tmp1+"</font></span>");
		setTimeout("txtTyper('"+str+"', "+idx+", '"+idObj+"', '"+spObj+"', '"+clr1+"', '"+clr2+"', "+delay+" ,"+plysnd+")",delay);
	  }
	}

	function init() {
		txtTyper(dispStr[0], 0, 'ttl0', 'ttl1', '#339933', '#99FF33', 50, 0);
	}

	// -->
	</script>

<script language="JavaScript" src="mm_menu.js"></script>
<script type="text/javascript" src="stmenu.js"></script>
<body bgcolor="" text="#339933" link="#33FF00" alink="#666666" vlink="#666666" onLoad="init()">
<script language="JavaScript1.2">mmLoadMenus();</script>
<table width="100%" border="0" bgcolor="#FFCC99">
  <tr>
    <td height="45" bgcolor="#000000"><table width="100%" border="0">
      <tr>
        <td width="9%"><span class="style7">Budget</span></td>
        <td width="73%"><div align="center"><span><a href="http://www.dhtml-menu-builder.com"  style="display:none;visibility:hidden;">Javascript DHTML Drop Down Menu Powered by dhtml-menu-builder.com</a>
                    <script id="sothink_widgets:dwwidget_dhtmlmenu2_17_2011.pgt" type="text/javascript">
<!--
stm_bm(["menu1a91",900,"","blank.gif",0,"","",0,0,250,0,1000,1,0,0,"","",0,0,1,2,"default","hand","",1,25],this);
stm_bp("p0",[0,4,0,0,0,7,5,0,100,"",-2,"",-2,50,0,0,"#999999","transparent","bg_01.gif",3,1,1,"#000000"]);
stm_ai("p0i0",[0,"HighLight","","",-1,-1,0,"#","_self","","","","",5,5,0,"","",-1,-1,0,1,1,"#FFFFF7",1,"#993333",1,"","bg_02.gif",3,1,0,0,"#FFFFF7","#000000","#FFFFFF","#FFFFFF","bold 9pt Arial","bold 9pt Arial",0,0,"","","","",0,0,0],135,0);
stm_bpx("p1","p0",[1,4,0,2,0,5,0,0,80,"progid:DXImageTransform.Microsoft.RandomDissolve(,enabled=0,Duration=0.30)",12,"progid:DXImageTransform.Microsoft.RandomDissolve(,enabled=0,Duration=0.30)",12,80,0,0,"#666666","#000000",""]);
stm_aix("p1i0","p0i0",[0,"List Budget","","",-1,-1,0,"?mm=101","_self","","","","",0,0,0,"","",0,0,0,0,1,"#F9E0CA",1,"#666666",0,"","",3,1,0,0,"#FFFFFF","#FFFFFF","#FFFFFF","#FFFFFF","9pt Arial","9pt Arial"],135,18);
stm_aix("p1i1","p1i0",[0,"PLO","","",-1,-1,0,"?mm=102"],135,18);
stm_ep();
stm_ai("p0i1",[6,1,"#000000","",-1,-1,0]);
stm_aix("p0i2","p0i0",[0,"IBS","","",-1,-1,0,"#","_self","","","","",5,5,0,"","",-1,-1,0,1,1,"#FFFFF7",1,"#993333",1,"","bg_02.gif",1],135,0);
stm_bpx("p2","p1",[]);
stm_aix("p2i0","p1i0",[0,"Production Shedulle","","",-1,-1,0,"http://HJURWSCO404/ReportServer/Pages/ReportViewer.aspx?%2fBudgetSystem%2fProdSchedulle&rs:Command=Render"],135,0);
stm_aix("p2i1","p1i0",[0,"Investment","","",-1,-1,0,"http://HJURWSCO404/ReportServer/Pages/ReportViewer.aspx?%2fBudgetSystem%2fInvestment&rs:Command=Render"],135,0);
stm_aix("p2i2","p1i0",[0,"PLO","","",-1,-1,0,"http://HJURWSCO404/ReportServer/Pages/ReportViewer.aspx?%2fBudgetSystem%2fPLO&rs:Command=Render"],135,0);
stm_ep();
stm_aix("p0i3","p0i1",[]);
stm_aix("p0i4","p0i2",[0,"Proposal","","",-1,-1,0,"http://HJURWSCO404/ReportServer/Pages/ReportViewer.aspx?%2fBudgetSystem%2fProposal&rs:Command=Render"],135,0);
stm_bpx("p3","p1",[]);
stm_aix("p3i0","p1i0",[0,"MGT","","",-1,-1,0,"http://HJURWSCO404/ReportServer/Pages/ReportViewer.aspx?%2fBudgetSystem%2fProposalByDept&rs:Command=Render&Dept=MGT"],135,0);
stm_aix("p3i1","p1i0",[0,"ENG","","",-1,-1,0,"http://HJURWSCO404/ReportServer/Pages/ReportViewer.aspx?%2fBudgetSystem%2fProposalByDept&rs:Command=Render&Dept=ENG"],135,0);
stm_aix("p3i2","p1i0",[0,"PRO","","",-1,-1,0,"http://HJURWSCO404/ReportServer/Pages/ReportViewer.aspx?%2fBudgetSystem%2fProposalByDept&rs:Command=Render&Dept=PRO"],135,0);
stm_aix("p3i3","p1i0",[0,"LOG","","",-1,-1,0,"http://HJURWSCO404/ReportServer/Pages/ReportViewer.aspx?%2fBudgetSystem%2fProposalByDept&rs:Command=Render&Dept=LOG"],135,0);
stm_aix("p3i4","p1i0",[0,"PLA","","",-1,-1,0,"http://HJURWSCO404/ReportServer/Pages/ReportViewer.aspx?%2fBudgetSystem%2fProposalByDept&rs:Command=Render&Dept=PLA"],135,0);
stm_aix("p3i5","p1i0",[0,"SHE","","",-1,-1,0,"http://HJURWSCO404/ReportServer/Pages/ReportViewer.aspx?%2fBudgetSystem%2fProposalByDept&rs:Command=Render&Dept=SHE"],135,0);
stm_aix("p3i6","p1i0",[0,"FAT","","",-1,-1,0,"http://HJURWSCO404/ReportServer/Pages/ReportViewer.aspx?%2fBudgetSystem%2fProposalByDept&rs:Command=Render&Dept=FAT"],135,0);
stm_aix("p3i7","p1i0",[0,"HRPGA","","",-1,-1,0,"http://HJURWSCO404/ReportServer/Pages/ReportViewer.aspx?%2fBudgetSystem%2fProposalByDept&rs:Command=Render&Dept=HRPGA"],135,0);
stm_ep();
stm_aix("p0i5","p0i1",[]);
stm_aix("p0i6","p0i2",[0,"GR"],135,0);
stm_bpx("p4","p1",[]);
stm_aix("p4i0","p1i0",[0,"Glanda","","",-1,-1,0,"#"],135,0);
stm_aix("p4i1","p4i0",[0,"Decompiler"],135,0);
stm_aix("p4i2","p4i0",[0,"Quicker"],135,0);
stm_ep();
stm_aix("p0i7","p0i1",[]);
stm_aix("p0i8","p0i2",[0,"Revenue"],135,0);
stm_bpx("p5","p1",[]);
stm_aix("p5i0","p1i0",[0,"PTI BRE","","",-1,-1,0,"?mm=501"],135,18);
stm_aix("p5i1","p1i0",[0,"PIT EBL","","",-1,-1,0,"?mm=502"],135,18);
stm_aix("p5i2","p1i0",[0,"PIT CABE","","",-1,-1,0,"?mm=503"],135,18);
stm_aix("p5i3","p1i0",[0,"PIT PEMT","","",-1,-1,0,"?mm=504"],135,18);
stm_aix("p5i4","p1i0",[0,"PIT PERSADA","","",-1,-1,0,"?mm=505"],135,18);
stm_ep();
stm_aix("p0i9","p0i1",[]);
stm_aix("p0i10","p0i2",[0,"Production"],135,0);
stm_bpx("p6","p1",[]);
stm_aix("p6i0","p1i0",[0,"OB","","",-1,-1,0,"?mm=601"],135,0);
stm_aix("p6i1","p6i0",[0,"Sale"],135,0);
stm_aix("p6i2","p6i0",[0,"Coal"],135,0);
stm_aix("p6i3","p6i0",[0,"Houling"],135,0);
stm_ep();
stm_aix("p0i11","p0i1",[]);
stm_aix("p0i12","p0i0",[0,"","","",-1,-1,0,"","_self","","","","",5,5,0,"","",0,0],135,0);
stm_aix("p0i13","p0i1",[]);
stm_aix("p0i14","p0i2",[0,"Setting"],135,0);
stm_bpx("p7","p1",[]);
stm_aix("p7i0","p1i0",[0,"Acounts","","",-1,-1,0,"http://HJURWSCO404/ReportServer/Pages/ReportViewer.aspx?%2fBudgetSystem%2fAcounts&rs:Command=Render"],135,0);
stm_aix("p7i1","p1i0",[0,"Admin","","",-1,-1,0,"?mm=701"],135,0);
stm_aix("p7i2","p1i0",[0,"Logout","","",-1,-1,0,"?mm=702"],135,0);
stm_ep();
stm_aix("p0i15","p0i1",[]);
stm_ep();
stm_em();
//-->
          </script>
        </span></div></td>
      </tr>
    </table></td>
  </tr>
</table>
<p>
  <? /*  if($mm=='101'){include('menu11.php');} else
	   if($mm=='102'){include('menu12.php');} else
	   if($mm=='201'){include('menu21.php');} else
	   if($mm=='202'){include('menu22.php');} else
	   if($mm=='203'){include('menu23.php');} else
	   if($mm=='301'){include('menu31.php');} else
	   if($mm=='302'){include('menu32.php');} else
	   if($mm=='401'){include('menu41.php');} else
	   if($mm=='402'){include('menu42.php');} else
	   if($mm=='501'){include('menu51.php');} else
	   if($mm=='502'){include('menu52.php');} */
	   echo "<div id=ttl0 class=ttl1></div>";
	   echo ("<BODY> <SCRIPT language='Javascript'> window.open('http://HJURWSCO404/ReportServer/Pages/ReportViewer.aspx?%2fBudgetSystem%2fMenuUtama&rs:Command=Render','MenuUtama','resizable=yes,scrollbars=yes,width=1080,height=800'); </SCRIPT> </BODY>");
	//exit();
	   ?>
<p>
<p>
<p>
</body>
</html>
