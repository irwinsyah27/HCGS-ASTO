<?
session_start();
//require("cek.php");
// ----- ambil isi dari file koneksi.php
require("tools/koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();
?>
<html>
<head>
<title>Barging KPP</title>

<?
	// buat fungsi PHP //
	
		function makeLink($str,$url,$bold="false"){
		if($bold){
			$str="<b>".$str."</b>";
		}
		return '<a class=style51 href="'.$url.'">'.$str.'</a>';
		
	}

	function paging($curRec,$totalRec,$maxRec,$lkPost){
		$totalPage=ceil($totalRec/$maxRec);
		$curPage=ceil(($curRec+1)/$maxRec);
		$str="";
		
		/*--------------------------prev button-----------------------*/
		if($curPage>1){
			$rec=($curPage-2)*$maxRec;					
			$str.=" ".makeLink("Prev","?cur=".$rec."&".$lkPost,$bold)." ";			
		}
		
		/*-------------------------generate page number----------------*/
		for($i=1;$i<=$totalPage;$i++){
			if($i==$curPage){
				$bold=true;
			}else{
				$bold=false;
			}
			$rec=($i-1)*$maxRec;					
			$str.=" ".makeLink($i,"?cur=".$rec."&".$lkPost,$bold)." ";
		}
		
		/*--------------------------next button-----------------------*/
		if($curPage<$totalPage){
			$rec=($curPage*$maxRec);					
			$str.=" ".makeLink("Next","?cur=".$rec."&".$lkPost,$bold)." ";			
		}
		
		return $str;
		
	}
?>

<script type="text/javascript" language="javascript">
<!--
function pick(tgt)
{
 window.open("tools/kalender_pick.php?rand="+Math.random()+"&tgt="+tgt,"Kalender","width=500,height=400,alwaysRaised=yes,scrollbars=yes,directories=no,location=no,menubar=no,toolbar=no");
}

function MM_displayStatusMsg(msgStr) { //v1.0
  status=msgStr;
  document.MM_returnValue = true;
}

function MM_openBrWindow(theURL,winName,features) { //v2.0
  window.open(theURL,winName,features);
}
//-->
</script>

<style type="text/css">
<!--
.style2 {font-size: 16px; color: #FFFFFF; font-family: "DejaVu Sans", Courier, monospace; font-weight: bold; }
.style52 {
	color: #9999FF;
	font-size: 36px;
}
.style54 {font-size: 16}
.style55 {
	color: #3399FF;
	font-weight: bold;
}
-->
</style>
</head>

<body>
<table width="100%" border="0" align="center">
  <tr>
    <td><div align="center" class="style52">
      <p>ACTUAL BARGING PIT <? echo $mPit ; ?></p>
      </div></td>
  </tr>
  <tr>
    <td><div align="center" class="style52 style54">Periode <? echo $pick_date ; ?> s/d <? echo $pick_date2 ; ?> </div></td>
  </tr>
  <tr>
    <td><form action="" method="get" name="form1" target="_self">
      <table width="100%" border="0" bgcolor="#CCCCFF">
        <tr>
          <td bgcolor="#CCFFFF"><div align="right">
              <table width="738" border="0" align="center">
                <tr>
                  <td width="197">Tanggal :
                    <label><span class="style2">
                      <input name="pick_date" type="text" id="pick_date" value="<? if($pick_date==''){echo date('Y-m-d');} else echo $pick_date; ?>" size="12" />
                      <input name="Button" type="button" style="background-image:url(images/Calendar.png); background-repeat:no-repeat; background-position:center; border:none;" onClick="pick('pick_date');" value="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" />
                    </span></label></td>
                  <td width="174"><label>s/d : <span class="style2">
                    <input name="pick_date2" type="text" id="pick_date2" value="<? if($pick_date==''){echo date('Y-m-d');} else echo $pick_date2; ?>" size="12" />
                    <input name="Button2" type="button" style="background-image:url(images/Calendar.png); background-repeat:no-repeat; background-position:center; border:none;" onClick="pick('pick_date2');" value="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" />
                  </span></label></td>
                  <td width="223">PIT :
                    <label>
                      <select name="mPit" id="mPit" onChange="this.form.submit()">
                        <option value="All PIT" <?php if (!(strcmp("All PIT", $mPit))) {echo "selected=\"selected\"";} ?>>All PIT</option>
                        <option value="EBL" <?php if (!(strcmp("EBL", $mPit))) {echo "selected=\"selected\"";} ?>>EBL</option>
                        <option value="BRE" <?php if (!(strcmp("BRE", $mPit))) {echo "selected=\"selected\"";} ?>>BRE</option>
                        <option value="TMN" <?php if (!(strcmp("TMN", $mPit))) {echo "selected=\"selected\"";} ?>>TMN</option>
                        <option value="CABE" <?php if (!(strcmp("CABE", $mPit))) {echo "selected=\"selected\"";} ?>>CABE</option>
                        <option value="PERSADA" <?php if (!(strcmp("PERSADA", $mPit))) {echo "selected=\"selected\"";} ?>>PERSADA</option>
                      </select>
                    </label></td>
                  <td width="64"><a href="#" onMouseOver="MM_displayStatusMsg('Update By . .');return document.MM_returnValue">
                    <input name="bIns" type="submit" id="bIns" value="Insert">
                  </a></td>
                  <td width="58"><A href="http://10.2.167.130/ReportServer/Pages/ReportViewer.aspx?%2fBarging%2fBarging_Periode_Pit&rs:Command=Render">
                    <input name="Submit" type="submit" onClick="MM_openBrWindow('http://10.2.167.130/ReportServer/Pages/ReportViewer.aspx?%2fBarging%2fBarging_Periode_Pit&amp;rs:Command=Render','Report','status=yes,scrollbars=yes,width=1000,height=600')" value="Report">
                  </A></td>
                </tr>
              </table>
          </div>
              <div align="left"></div></td>
        </tr>
        <tr>
          <td bgcolor="#CCFFFF">
<? if($bIns=='Insert'){ echo ("
<table width=456 border=0>
  <tr>
    <td width=52>PIT</td>
    <td width=151> :
	<select name=mPitIns id=mPitIns>
	  <option value=EBL>EBL</option>
	  <option value=BRE>BRE</option>
	  <option value=TMN>TMN</option>
	  <option value=CABE>CABE</option>
	  <option value=PERSADA>PERSADA</option>
	</select>
          </td>
    <td width=69>Barge</td>
    <td width=166>: 
    <input name=mBarge type=text size=16></td>
  </tr>
  <tr>
    <td>Date</td>
    <td> :
	<input name=pick_dateIns type=text id=pick_dateIns size=12 />
<input name=Button3 type=button style=background-image:url(images/Calendar.png); background-repeat:no-repeat; background-position:center; border:none; onClick=pick('pick_dateIns'); value=&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /> </td>
    <td>TogBoat</td>
    <td>: 
    <input name=mTB type=text id=mTB size=16></td>
  </tr>
  <tr>
    <td>TA</td>
    <td>:
	<input name=pick_dateInsTA type=text id=pick_dateInsTA size=1 />
<input name=Button3 type=button style=background-image:url(images/Calendar.png); background-repeat:no-repeat; background-position:center; border:none; onClick=pick('pick_dateInsTA'); value=&nbsp;&nbsp; />
      <input name=mTA1 type=text id=mTA1 size=1>
:
<input name=mTA2 type=text id=mTA2 size=1></td>
    <td>Cargo</td>
    <td>: 
    <input name=mCargo type=text id=mCargo size=16></td>
  </tr>
  <tr>
    <td>TD</td>
    <td>:
	<input name=pick_dateInsTD type=text id=pick_dateInsTD size=1 />
<input name=Button3 type=button style=background-image:url(images/Calendar.png); background-repeat:no-repeat; background-position:center; border:none; onClick=pick('pick_dateInsTD'); value=&nbsp;&nbsp; />
      <input name=mTD1 type=text id=mTD1 size=1>
:
<input name=mTD2 type=text id=mTD2 size=1></td>
    <td>Shipping</td>
    <td>: 
    <input name=mShip type=text id=mShip size=16></td>
  </tr>
</table>
<input name=bSave type=submit id=bSave value=Save>
");} ?>

<? if(!$bEdit==''){
$Sel1 = mssql_query ("select CAST(CAST(YEAR([Date]) AS VARCHAR) + '-' + CAST(MONTH([Date]) AS VARCHAR) + '-' + CAST(DAY([Date])AS VARCHAR) AS Varchar) AS [Date], CAST(CAST(datepart(HOUR,[TA]) as varchar)+':'+CAST(datepart(MINUTE,[TA]) as varchar) AS varchar) AS [TA], CAST(CAST(datepart(HOUR,[TD]) as varchar)+':'+CAST(datepart(MINUTE,[TD]) as varchar) AS varchar) AS [TD], Barge, TogBoat, Cargo, Shipping from Barging where Id='$bEdit'") or die ("Terdapat kesalahan Update!");
$dUp=mssql_fetch_array($Sel1);
$TA1=SubStr($dUp[TA],0,2);
$TA2=SubStr($dUp[TA],3,2);
$TD1=SubStr($dUp[TD],0,2);
$TD2=SubStr($dUp[TD],3,2);
echo ("<input type=hidden name=hID value='$bEdit'>
<table width=500 border=0>
  <tr>
    <td width=52>Date</td>
    <td width=151> :
      <input name=pick_dateIns type=text id=pick_dateIns size=12 value='$dUp[Date]' />
<input name=Button3 type=button style=background-image:url(images/Calendar.png); background-repeat:no-repeat; background-position:center; border:none; onClick=pick('pick_dateIns'); value=&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; />    </td>
    <td width=69>TogBoat</td>
    <td width=166>: 
    <input name=mTB type=text id=mTB size=16 value='$dUp[TogBoat]'></td>
  </tr>
  <tr>
    <td>TA</td>
    <td> :
<input name=mTA1 type=text id=mTA1 size=1 value='$TA1'> 
      : 
      <input name=mTA2 type=text id=mTA2 size=1 value='$TA2'></td>
    <td>Cargo</td>
    <td>: 
    <input name=mCargo type=text id=mCargo size=16 value='$dUp[Cargo]' ></td>
  </tr>
  <tr>
    <td>TD</td>
    <td>:
      <input name=mTD1 type=text id=mTD1 size=1 value='$TD1'>
:
<input name=mTD2 type=text id=mTD2 size=1 value='$TD2'></td>
    <td>Shipping</td>
    <td>: 
    <input name=mShip type=text id=mShip size=25 value='$dUp[Shipping]'></td>
  </tr>
  <tr>
    <td>Barge</td>
    <td>: 
    <input name=mBarge type=text size=16 value='$dUp[Barge]'></td>
    <td><input name=bUpdate type=submit id=bUpdate value=Update></td>
    <td></td>
  </tr>
</table>
");
} ?>

<?
if($bUpdate=='Update') {
$Date=$pick_dateIns.' '.'00:00.000';
$TA=$pick_dateIns.' '.$mTA1.':'.$mTA2.'.000';
$TD=$pick_dateIns.' '.$mTD1.':'.$mTD2.'.000';
$update="UPDATE Barging SET Date='$Date', TA='$TA', TD='$TD', Barge='$mBarge', TogBoat='$mTB', Cargo='$mCargo', Shipping='$mShip' WHERE Id='$hID'";
$hasil =@mssql_query ($update) or die ("Terdapat Kesalahan Update");
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data TerUpdate.!!'); </SCRIPT> </BODY>");
}
if($bSave=='Save') {
$Date=$pick_dateIns.' '.'00:00.000';
$TA=$pick_dateIns.' '.$mTA1.':'.$mTA2.'.000';
$TD=$pick_dateIns.' '.$mTD1.':'.$mTD2.'.000';
$insert="INSERT INTO Barging (Date,TA,TD,Barge,TogBoat,Shipping,Cargo,PIT) VALUES('$Date','$TA','$TD','$mBarge','$mTB','$mShip','$mCargo','$mPitIns')";
$hasil =@mssql_query ($insert) or die ("Terdapat Kesalahan Insert");
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data Tersimpan.!!'); </SCRIPT> </BODY>");
}
?>
 
 <?php
$Awal  = $pick_date.' 00:00.000';
$Akhir = $pick_date2.' 00:00.000';

if($mPit=='All PIT'){
$sel2=mssql_query("select CAST(CAST(YEAR([Date]) AS VARCHAR) + '-' + CAST(MONTH([Date]) AS VARCHAR) + '-' + CAST(DAY([Date])AS VARCHAR) AS Varchar) AS [Date], CAST(CAST(datepart(HOUR,[TA]) as varchar)+':'+CAST(datepart(MINUTE,[TA]) as varchar) AS varchar) AS [TA], CAST(CAST(datepart(HOUR,[TD]) as varchar)+':'+CAST(datepart(MINUTE,[TD]) as varchar) AS varchar) AS [TD], Barge, TogBoat, Cargo, Shipping, Id, PIT from Barging where Barging.date >='$Awal' and Barging.date <='$Akhir' order by Barging.Date")
or die ("Terdapat kesalahan pada perintah SQL!");
$sel3=mssql_query("Select SUM(CARGO) as [Tot] from Barging where Barging.date >='$Awal' and Barging.date <='$Akhir'")
or die ("Terdapat kesalahan pada perintah SQL!");
$dSum=mssql_fetch_array($sel3);
} else {
$sel2=mssql_query("select CAST(CAST(YEAR([Date]) AS VARCHAR) + '-' + CAST(MONTH([Date]) AS VARCHAR) + '-' + CAST(DAY([Date])AS VARCHAR) AS Varchar) AS [Date], CAST(CAST(datepart(HOUR,[TA]) as varchar)+':'+CAST(datepart(MINUTE,[TA]) as varchar) AS varchar) AS [TA], CAST(CAST(datepart(HOUR,[TD]) as varchar)+':'+CAST(datepart(MINUTE,[TD]) as varchar) AS varchar) AS [TD], Barge, TogBoat, Cargo, Shipping, Id, PIT from Barging where Barging.date >='$Awal' and Barging.date <='$Akhir' and Barging.Pit='$mPit' order by Barging.Id")
or die ("Terdapat kesalahan pada perintah SQL!");
$sel3=mssql_query("Select SUM(CARGO) as [Tot] from Barging where Barging.date >='$Awal' and Barging.date <='$Akhir' and Barging.Pit='$mPit'")
or die ("Terdapat kesalahan pada perintah SQL!");
$dSum=mssql_fetch_array($sel3);
}
// ------ buat tampilan tabel
echo("<table width=100%  border=0 bgcolor=#99CCFF>");
echo("<td bgcolor=#336699><div align=center><span class=style2>PIT</span></td>
							  <td bgcolor=#336699><div align=center><span class=style2>Date</span></td>
                              <td bgcolor=#336699><div align=center><span class=style2>TA</span></td>
							  <td bgcolor=#336699><div align=center><span class=style2>TD</span></td>
                              <td bgcolor=#336699><div align=center><span class=style2>Barge</span></td>
                              <td bgcolor=#336699><div align=center><span class=style2>TogBoat</span></td>
                              <td bgcolor=#336699><div align=center><span class=style2>Shipping (Destination)</span></td>
							  <td bgcolor=#336699><div align=center><span class=style2>Cargo</span></td>
                              <td bgcolor=#336699><div align=center><span class=style2>@</span></td>");
// ------ ambil isi masing-masing record
while ($row = mssql_fetch_object($sel2))
{
		// ----- mengambil isi setiap kolom
		
		$Id=$row->Id;
		$Pit=$row->PIT;
		$Date=SubStr($row->Date,0,11);
		$TA=$row->TA;
		$TD=$row->TD;
		$Barge=$row->Barge;
		$TogBoat=$row->TogBoat;
		$Cargo=$row->Cargo;
		$Shipping=$row->Shipping;

		// ------ menampilkan di layar browser
		echo("<tr><div align=center>
		    <td bgcolor=#CFFFFF class=style5><div align=Center>$Pit</td>
			<td bgcolor=#CFFFFF class=style5><div align=Center>$Date</td>
			<td bgcolor=#CFFFFF class=style5><div align=Center>$TA</td>
			<td bgcolor=#CFFFFF class=style5><div align=Center>$TD</td>
			<td bgcolor=#CFFFFF class=style5><div align=Center>$Barge</td>
			<td bgcolor=#CFFFFF class=style5><div align=Center>$TogBoat</td>
			<td bgcolor=#CFFFFF class=style5><div align=Center>$Shipping</td>
			<td bgcolor=#CFFFFF class=style5><div align=Right>$Cargo</td>");
			echo("<td bgcolor=#CFFFFF class=style5><div align=Center><input type=submit name=bEdit value=Edit onClick=value=$Id>
			</td>
			</tr>");
}
echo("</table>");
?></td>
        </tr>
        <tr>
          <td bgcolor="#CCFFFF"><table width="100%" border="0">
            <tr>
              <td width="877"><div align="right" class="style55">
                Total : </a></div></td>
              <td width="107">
			  <a class=style55><a href="#">
			  <? echo $dSum[Tot] ; ?></td>
            </tr>
          </table></td>
        </tr>
      </table>
        </form></td>
  </tr>
</table>

</body>
</html>
