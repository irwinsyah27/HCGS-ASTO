<?
session_start();
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Header</title>
<link rel="stylesheet" href="gaya.css" type="text/css" />
<script type="text/javascript" src="jquery-1.4.3.min.js"></script>
<script type="text/javascript" src="notifikasi.js"></script>
<style type="text/css">
<!--
.style1 {
	font-size: 36px;
	color: #FFFFFF;
}
.style2 {color: #FFFFFF;
	font-family: "Courier New", Courier, monospace;
	font-weight: bold;
}
.style2 {font-size: 16px; color: #FFFFFF; font-family: "Courier New", Courier, monospace; font-weight: bold; }
.style21 {font-size: 12px; color: #FFFFFF; font-family: "DejaVu Sans", Courier, monospace; font-weight: bold; }
.style23 {font-style: italic}
.style24 {font-size: 14px; color: #FFFFFF;}
body {
	background-image: url(../Images/bg.jpg);
	background-repeat: repeat-x;
}
-->
</style>
<script type="text/javascript">
<!-- Begin
/* This script and many more are available free online at
The JavaScript Source!! http://javascript.internet.com
Created by: HaganeNoKokoro :: http://tinyurl.com/buvp9 */

/*
 * Notes on hue
 *
 * This script uses hue rotation in the following manner:
 * hue=0   is red (#FF0000)
 * hue=60  is yellow (#FFFF00)
 * hue=120 is green (#00FF00)
 * hue=180 is cyan (#00FFFF)
 * hue=240 is blue (#0000FF)
 * hue=300 is magenta (#FF00FF)
 * hue=360 is hue=0 (#FF0000)
 *
 * Notes on the script
 *
 * This script should function in any browser that supports document.getElementById
 * It has been tested in Netscape7, Mozilla Firefox 1.0, and Internet Explorer 6
 *
 * Accessibility
 *
 * The script does not write the string out, but rather takes it from an existing
 * HTML element. Therefore, users with javascript disabled will not be adverely affected.
 * They just won't get the pretty colors.
 */

/*
 * splits par.firstChild.data into 1 span for each letter
 * ARGUMENTS
 *   span - HTML element containing a text node as the only element
 */
function toSpans(span) {
  var str=span.firstChild.data;
  var a=str.length;
  span.removeChild(span.firstChild);
  for(var i=0; i<a; i++) {
    var theSpan=document.createElement("SPAN");
    theSpan.appendChild(document.createTextNode(str.charAt(i)));
    span.appendChild(theSpan);
  }
}

/*
 * creates a rainbowspan object
 * whose letters will be colored [deg] degrees of hue
 * ARGUMENTS
 *   span - HTML element to apply the effect to (text only, no HTML)
 *   hue - what degree of hue to start at (0-359)
 *   deg - how many hue degrees should be traversed from beginning to end of the string (360 => once around, 720 => twice, etc)
 *   brt - brightness (0-255, 0 => black, 255 => full color)
 *   spd - how many ms between moveRainbow calls (less => faster)
 *   hspd - how many hue degrees to move every time moveRainbow is called (0-359, closer to 180 => faster)
 */
function RainbowSpan(span, hue, deg, brt, spd, hspd) {
    this.deg=(deg==null?360:Math.abs(deg));
    this.hue=(hue==null?0:Math.abs(hue)%360);
    this.hspd=(hspd==null?3:Math.abs(hspd)%360);
    this.length=span.firstChild.data.length;
    this.span=span;
    this.speed=(spd==null?50:Math.abs(spd));
    this.hInc=this.deg/this.length;
    this.brt=(brt==null?255:Math.abs(brt)%256);
    this.timer=null;
    toSpans(span);
    this.moveRainbow();
}

/*
 * sets the colors of the children of [this] as a hue-rotating rainbow starting at this.hue;
 * requires something to manage ch externally
 * I had to make the RainbowSpan class because M$IE wouldn't let me attach this prototype to [Object]
 */
RainbowSpan.prototype.moveRainbow = function() {
  if(this.hue>359) this.hue-=360;
  var color;
  var b=this.brt;
  var a=this.length;
  var h=this.hue;

  for(var i=0; i<a; i++) {

    if(h>359) h-=360;

    if(h<60) { color=Math.floor(((h)/60)*b); red=b;grn=color;blu=0; }
    else if(h<120) { color=Math.floor(((h-60)/60)*b); red=b-color;grn=b;blu=0; }
    else if(h<180) { color=Math.floor(((h-120)/60)*b); red=0;grn=b;blu=color; }
    else if(h<240) { color=Math.floor(((h-180)/60)*b); red=0;grn=b-color;blu=b; }
    else if(h<300) { color=Math.floor(((h-240)/60)*b); red=color;grn=0;blu=b; }
    else { color=Math.floor(((h-300)/60)*b); red=b;grn=0;blu=b-color; }

    h+=this.hInc;

    this.span.childNodes[i].style.color="rgb("+red+", "+grn+", "+blu+")";
  }
  this.hue+=this.hspd;
}
// End -->
</script>
<script language="JavaScript">
<!--
function mmLoadMenus() {
  if (window.mm_menu_0112130920_0) return;
              window.mm_menu_0112130920_0 = new Menu("root",73,18,"",12,"#FFFFFF","#000000","#009933","#999999","left","middle",3,0,1000,-5,7,true,false,true,0,true,true);
  mm_menu_0112130920_0.addMenuItem("Home","location='#1'");
  mm_menu_0112130920_0.addMenuItem("Aplikasi","location='#2'");
   mm_menu_0112130920_0.fontWeight="bold";
   mm_menu_0112130920_0.hideOnMouseOut=true;
   mm_menu_0112130920_0.bgColor='#555555';
   mm_menu_0112130920_0.menuBorder=1;
   mm_menu_0112130920_0.menuLiteBgColor='#FFFFFF';
   mm_menu_0112130920_0.menuBorderBgColor='#777777';
    window.mm_menu_0112142917_0 = new Menu("root",99,18,"",12,"#FFFFFF","#000000","#009933","#999999","left","middle",3,0,1000,-5,7,true,false,true,0,true,true);
  mm_menu_0112142917_0.addMenuItem("ITHelpDesk","location='#1'");
   mm_menu_0112142917_0.fontWeight="bold";
   mm_menu_0112142917_0.hideOnMouseOut=true;
   mm_menu_0112142917_0.bgColor='#555555';
   mm_menu_0112142917_0.menuBorder=1;
   mm_menu_0112142917_0.menuLiteBgColor='#FFFFFF';
   mm_menu_0112142917_0.menuBorderBgColor='#777777';

mm_menu_0112142917_0.writeMenus();
} // mmLoadMenus()

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}
//-->
</script>
<script language="JavaScript" src="mm_menu.js"></script>
</head>

<script type="text/JavaScript">
<!--
function MM_openBrWindow(theURL,winName,features) { //v2.0
  window.open(theURL,winName,features);
}
</script>

<body onload="MM_preloadImages('PKH/Images/lol.gif')">
<script language="JavaScript1.2">mmLoadMenus();</script>
<table width="100%" border="0" bgcolor="#FFFFFF">
  <tr>
    <td><table width="100%" border="0" align="center" background="../Images/bg.jpg">
      <tr>
        <td width="49%" background="../Images/tg1.jpg"><div align="center" class="style2"><a href="../halUtama.php" class="style2"></a> <span class="style1"><p id="r2">PT.KPP District Rantau</p>
        </span></div>
		<script type="text/javascript">
		var r2=document.getElementById("r2"); //get span to apply rainbow
		var myRainbowSpan2=new RainbowSpan(r2, 0, 360, 255, 50, 348); //apply static rainbow effect
		myRainbowSpan2.timer=window.setInterval("myRainbowSpan2.moveRainbow()", myRainbowSpan2.speed);
		</script>
		</td>
        <td width="13%" background="../Images/tg1.jpg" class="style2"><div align="center">
          <script type="text/javascript">
				// 1 detik = 1000
				window.setTimeout("waktu()",1000);
				function waktu()
				{
				var tanggal = new Date();
				setTimeout("waktu()",1000);
				document.getElementById("output").innerHTML = tanggal.getHours()+":"+
				tanggal.getMinutes()+":"+tanggal.getSeconds();
				}
				  </script>
          Jam : <a name="output" id="output" bgcolor="white" text="black" onload="waktu()"> </a> </div></td>
        <td width="38%" background="../Images/tg1.jpg" class="style2"><div align="center" class="style23"><span class="style21">
          <a href="#"><span id="pesan"> <img src="../Images/infoIconWin.gif" name="image1" width="28" height="25" border="0" id="image1" /> <span id="notifikasi"></span> </span><div id="info">
    <div id="loading"><br>Loading...<img src="loading.gif"></div>
    <div id="konten-info">
    </div>
</div></a>
          <? if(!session_is_registered
	("User")){
	echo ("<a href=# class= style24 onClick=MM_openBrWindow('//10.2.167.130/KPP_Index/logout.aspx','Hapus','width=370,height=320')
	onClick=this.form.submit() >.:: LogIn ::.</a>"); } else {
	echo (".:: <a class=style19> $_SESSION[User] ::.  || .:: $_SESSION[SNama] ::. || .:: <a href=# class= style24 onClick=MM_openBrWindow('../SessionOff.php','Hapus','width=670,height=620')  onClick=this.form.submit() >LogOut</a><a class=style19> ::.</a>"); } ?>
        </span><a href="#"><img src="../Images/confirmIcon.gif" name="image2" width="27" height="25" border="0" id="image2" onmouseover="MM_showMenu(window.mm_menu_0112142917_0,0,25,null,'image2')" onmouseout="MM_startTimeout();" /></a> <a href="#" onmouseover="MM_swapImage('image1','','PKH/Images/lol.gif',1)" onmouseout="MM_swapImgRestore()"></a> </div></td>
      </tr>
      
    </table></td>
  </tr>
</table>
</body>
</html>
