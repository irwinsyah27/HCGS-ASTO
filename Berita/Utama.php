<?
session_start();
?>
<html>
<style type="text/css">
<!--
.style6 {color: #000000; font-weight: bold; font-family: "Courier New", Courier, monospace; font-size: 18px; }
.style7 {
	color: #000000;
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
.style5 {color: #FFFFFF; font-family: "DejaVu Sans"}
body {
	background-color: #F7F7F7;
}
-->
</style>
<script type="text/javascript" src="stmenu.js"></script>
<body>
<form action="" method="post" name="form1" target="_self">
  <table width="100%" height="200" border="0">
    <tr>
      <td height="45"><label> </label>
        <div align="center"><span class="style6"><span><a href="http://www.dhtml-menu-builder.com"  style="display:none;visibility:hidden;">Javascript DHTML Drop Down Menu Powered by dhtml-menu-builder.com</a>
                  <script id="sothink_widgets:dwwidget_dhtmlmenu2_29_2011.pgt" type="text/javascript">
<!--
stm_bm(["menu6b59",900,"","blank.gif",0,"","",0,0,200,0,1000,1,0,0,"","",0,0,1,2,"default","hand","",1,25],this);
stm_bp("p0",[0,4,0,0,2,3,12,0,100,"",-2,"",-2,50,0,0,"#999999","transparent","",3,4,1,"#CCCCCC"]);
stm_ai("p0i0",[0,"Terbaru","","",-1,-1,0,"Utama.php?mJenis=All","_self","","","060418icon.gif","060418icon1.gif",12,12,0,"","",0,0,0,0,1,"#FFFFF7",1,"#B5BED6",1,"060418button.gif","060418button1.gif",0,0,0,0,"#FFFFF7","#000000","#000000","#FFFFFF","bold 7pt Verdana","bold 7pt Verdana",0,0,"","","","",0,0,0],112,28);
stm_aix("p0i1","p0i0",[0,"Nasional","","",-1,-1,0,"Utama.php?mJenis=Nasional","_self","","","060418icon.gif","060418icon1.gif",12,12,0,"","",0,0,0,0,1,"#FFFFF7",1,"#B5BED6",1,"060418button.gif","060418button1up.gif"],112,28);
stm_aix("p0i2","p0i1",[0,"OlahRaga","","",-1,-1,0,"Utama.php?mJenis=Olahraga"],112,28);
stm_aix("p0i3","p0i1",[0,"Pengetahuan","","",-1,-1,0,"Utama.php?mJenis=Pengetahuan"],112,28);
stm_aix("p0i4","p0i1",[0,"Teknologi","","",-1,-1,0,"Utama.php?mJenis=Teknologi"],112,28);
stm_aix("p0i5","p0i1",[0,"Otomotif","","",-1,-1,0,"Utama.php?mJenis=Otomotif"],112,28);
stm_aix("p0i6","p0i1",[0,"Kesehatan","","",-1,-1,0,"Utama.php?mJenis=Kesehatan"],112,28);
stm_aix("p0i7","p0i1",[0,"Selebritis","","",-1,-1,0,"Utama.php?mJenis=Selebritis"],112,28);
stm_aix("p0i8","p0i1",[0,"Others","","",-1,-1,0,"Utama.php?mJenis=Others"],112,28);
stm_ep();
stm_em();
function MM_openBrWindow(theURL,winName,features) { //v2.0
  window.open(theURL,winName,features);
}
//-->
            </script>
            </span></span>
              <?
				  if (($_SESSION[User]='KC10047') or ($_SESSION[User]='6103041')) {
				  echo ("<input type=button onClick=MM_openBrWindow('baru.php?mJenis=$mJenis','Baru','width=850,height=400') value=News>");
				  }
				  ?>
      </div></td>
    </tr>
    <tr>
      <td height="657"><?   if($mJenis=='Nasional'){include('BeritaJenis.php');} else
	   if($mJenis=='Pengetahuan'){include('BeritaJenis.php');} else
	   if($mJenis=='Teknologi'){include('BeritaJenis.php');} else
	   if($mJenis=='Kesehatan'){include('BeritaJenis.php');} else
	   if($mJenis=='Makanan'){include('BeritaJenis.php');} else
	   if($mJenis=='Otomotif'){include('BeritaJenis.php');} else
	   if($mJenis=='Others'){include('BeritaJenis.php');} else
	   if($mJenis=='Olahraga'){include('BeritaJenis.php');} else
	   if($mJenis=='All'){include('BeritaAll.php');} else
	   if($mJenis==''){include('NilaiInti.php');}
	 ?></td>
    </tr>
  </table>
</form>
</body>
</html>
