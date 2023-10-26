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
<title>Proposal Budget</title>

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
.styleRed {
	color: #FF0000;
	font-weight: bold;
}
.styleGren{
	color: #006600;
	font-weight: bold;
}
-->
</style>
</head>

<body>
<?
// ------ buat tampilan tabel
$q1 = mssql_query("SELECT    ID, Dept AS Descr
FROM         (SELECT     dbo.v_COA_L4.Acount AS ID, dbo.v_COA_L4.Descr AS Dept, dbo.v_COA_L5.Kategori, dbo.v_COA_L5.Acount, dbo.v_COA_L5.Descr, 
                      dbo.ref_Acounts.Descr AS List
FROM         dbo.ref_Acounts INNER JOIN
                      dbo.v_COA_L4 ON dbo.v_COA_L4.Acount LIKE dbo.ref_Acounts.Dept INNER JOIN
                      dbo.v_COA_L5 ON dbo.ref_Acounts.Acount = dbo.v_COA_L5.Acount
GROUP BY dbo.v_COA_L4.Descr, dbo.v_COA_L5.Kategori, dbo.v_COA_L5.Acount, dbo.v_COA_L5.Descr, dbo.ref_Acounts.Descr, dbo.v_COA_L4.Acount) AS Proposal
					   GROUP BY ID, Dept");
$row1 = mssql_fetch_array($q1);
$q2 = mssql_query("SELECT     Kategori
FROM         (SELECT     dbo.v_COA_L4.Acount AS ID, dbo.v_COA_L4.Descr AS Dept, dbo.v_COA_L5.Kategori, dbo.v_COA_L5.Acount, dbo.v_COA_L5.Descr, 
                      dbo.ref_Acounts.Descr AS List
FROM         dbo.ref_Acounts INNER JOIN
                      dbo.v_COA_L4 ON dbo.v_COA_L4.Acount LIKE dbo.ref_Acounts.Dept INNER JOIN
                      dbo.v_COA_L5 ON dbo.ref_Acounts.Acount = dbo.v_COA_L5.Acount
GROUP BY dbo.v_COA_L4.Descr, dbo.v_COA_L5.Kategori, dbo.v_COA_L5.Acount, dbo.v_COA_L5.Descr, dbo.ref_Acounts.Descr, dbo.v_COA_L4.Acount) AS Proposal Where ID = '".$mmDept."' GROUP BY Kategori");
$row2 = mssql_fetch_array($q2);
$q3 = mssql_query("SELECT Acount, Descr
FROM         (SELECT     dbo.v_COA_L4.Acount AS ID, dbo.v_COA_L4.Descr AS Dept, dbo.v_COA_L5.Kategori, dbo.v_COA_L5.Acount, dbo.v_COA_L5.Descr, 
                      dbo.ref_Acounts.Descr AS List
FROM         dbo.ref_Acounts INNER JOIN
                      dbo.v_COA_L4 ON dbo.v_COA_L4.Acount LIKE dbo.ref_Acounts.Dept INNER JOIN
                      dbo.v_COA_L5 ON dbo.ref_Acounts.Acount = dbo.v_COA_L5.Acount
GROUP BY dbo.v_COA_L4.Descr, dbo.v_COA_L5.Kategori, dbo.v_COA_L5.Acount, dbo.v_COA_L5.Descr, dbo.ref_Acounts.Descr, dbo.v_COA_L4.Acount) AS Proposal Where ID = '".$mmDept."' AND Kategori = '".$mmKat."' GROUP BY Acount, Descr ORDER BY Acount");
$row3 = mssql_fetch_array($q3);
if ($mmAc!=''){
$q4 = mssql_query("SELECT ID, List AS Descr
FROM         (SELECT     dbo.v_COA_L4.Acount AS IDDept, dbo.v_COA_L4.Descr AS Dept, dbo.v_COA_L5.Kategori, dbo.v_COA_L5.Acount, dbo.v_COA_L5.Descr, 
                      dbo.ref_Acounts.ID, dbo.ref_Acounts.Descr AS List
FROM         dbo.ref_Acounts INNER JOIN
                      dbo.v_COA_L4 ON dbo.v_COA_L4.Acount LIKE dbo.ref_Acounts.Dept INNER JOIN
                      dbo.v_COA_L5 ON dbo.ref_Acounts.Acount = dbo.v_COA_L5.Acount
GROUP BY dbo.v_COA_L4.Descr, dbo.v_COA_L5.Kategori, dbo.v_COA_L5.Acount, dbo.v_COA_L5.Descr, dbo.ref_Acounts.Descr, dbo.ref_Acounts.ID, 
                      dbo.v_COA_L4.Acount) AS Proposal
					   Where IDDept = '".$mmDept."' AND Kategori = '".$mmKat."' AND Acount = ".$mmAc." GROUP BY ID, List ORDER BY List");
					   } else {
$q4 = mssql_query("SELECT ID, List AS Descr
FROM         (SELECT     dbo.ref_Acounts.ID, dbo.v_COA_L4.Descr AS Dept, dbo.v_COA_L5.Kategori, dbo.v_COA_L5.Acount, dbo.v_COA_L5.Descr, 
                      dbo.ref_Acounts.Descr AS List
FROM         dbo.ref_Acounts INNER JOIN
                      dbo.v_COA_L4 ON dbo.v_COA_L4.Acount LIKE dbo.ref_Acounts.Dept INNER JOIN
                      dbo.v_COA_L5 ON dbo.ref_Acounts.Acount = dbo.v_COA_L5.Acount
GROUP BY dbo.v_COA_L4.Descr, dbo.v_COA_L5.Kategori, dbo.v_COA_L5.Acount, dbo.v_COA_L5.Descr, dbo.ref_Acounts.Descr, dbo.ref_Acounts.ID) AS Proposal
					   Where 1+1=1 GROUP BY ID, List ORDER BY List");}
$row4 = mssql_fetch_array($q4);
?>
<table width="100%" border="0" align="center">
  <tr>
    <td><div align="center" class="style52">
      <p>
        PROPOSAL BUDGET DEPT.  <? echo $mmDept ;
	  	  
$selIBS=mssql_query("SELECT     SUM(Nominal) AS IBS, Periode, Kategori, Acount
FROM         dbo.v_PLO
Where Periode = '".$fClosing."' AND Acount ='".$mmAc."'
GROUP BY Periode, Kategori, Acount
 ");
 $selProp=mssql_query("SELECT     Periode, Kategori, Acount, Descr, SUM(Nominal) AS Nominal, Dept
FROM         (SELECT     Tbl.ID, Tbl.Periode, Tbl.Start, Tbl.Stop, Tbl.IDDept, dbo.v_Proposal.Dept, dbo.v_Proposal.Kategori, dbo.v_Proposal.Acount, dbo.v_Proposal.Descr, 
                      dbo.v_Proposal.List, ISNULL(Tbl.Nominal, 0) AS Nominal, ISNULL(Tbl.StatusClosing, 0) AS StatusClosing
FROM         (SELECT     dbo.Proposal.ID, CAST(DATEPART(MONTH, dbo.ref_Closing.Periode) AS VARCHAR) + '/' + CAST(DATEPART(YEAR, dbo.ref_Closing.Periode) 
                                              AS VARCHAR) AS Periode, dbo.Proposal.Start, dbo.Proposal.Stop, DATEDIFF(DAY, dbo.Proposal.Start, dbo.Proposal.Stop) AS TotalHari, 
                                              dbo.v_COA_L4.Descr AS Dept, dbo.ref_Dept.NamaDept AS DeptAdd, dbo.v_COA_L5.Kategori, dbo.Proposal.Acount, dbo.v_COA_L5.Descr, 
                                              dbo.ref_Acounts.Descr AS List, SUM(dbo.Proposal.Nominal) AS Nominal, ISNULL(dbo.ref_Closing.Status, 0) AS StatusClosing, 
                                              dbo.v_COA_L4.Acount AS IDDept
                       FROM          dbo.Proposal INNER JOIN
                                              dbo.v_COA_L5 ON dbo.Proposal.Acount = dbo.v_COA_L5.Acount INNER JOIN
                                              dbo.v_COA_L4 ON dbo.Proposal.Dept = dbo.v_COA_L4.Acount LEFT OUTER JOIN
                                              dbo.ref_Acounts ON dbo.Proposal.List = dbo.ref_Acounts.ID LEFT OUTER JOIN
                                              dbo.ref_Dept ON dbo.Proposal.DeptAdd = dbo.ref_Dept.ID LEFT OUTER JOIN
                                              dbo.ref_Closing ON dbo.Proposal.Periode = dbo.ref_Closing.Periode
                       GROUP BY dbo.Proposal.Acount, dbo.Proposal.Nominal, dbo.v_COA_L5.Descr, dbo.v_COA_L5.Kategori, dbo.ref_Closing.Periode, 
                                              dbo.ref_Closing.Status, dbo.Proposal.Stop, dbo.Proposal.Start, dbo.v_COA_L4.Descr, dbo.ref_Dept.NamaDept, dbo.ref_Acounts.Descr, 
                                              dbo.Proposal.ID, dbo.v_COA_L4.Acount) AS Tbl INNER JOIN
                      dbo.v_Proposal ON Tbl.Dept = dbo.v_Proposal.Dept AND Tbl.Acount = dbo.v_Proposal.Acount AND Tbl.List = dbo.v_Proposal.List) AS Tbl
Where Start = '".$pick_date."' AND Stop = '".$pick_date2."' AND IDDept = '".$mmDept."' AND Acount ='".$mmAc."'
GROUP BY Periode, Kategori, Acount, Descr, Dept
 ");
$rowIBS = mssql_fetch_array($selIBS);
$rowProp = mssql_fetch_array($selProp);
if($rowIBS[Kategori]!='Production') {
$TNominal = 'Rp. '.number_format($rowProp[Nominal],0,",",".").',-';
$TIBS = 'Rp. '.number_format($rowIBS[IBS],0,",",".").',-'; }
else {
$TNominal = number_format($rowProp[Nominal],0,",",".");
$TIBS = number_format($rowIBS[IBS],0,",","."); 
}
	   
	  if (strval($rowProp[Nominal]) > strval($rowIBS[IBS])) { $Dev = (strval($rowProp[Nominal])-strval($rowIBS[IBS]))/strval($rowProp[Nominal])*100 ; echo " Deviasi ".$Dev."%"; } 
	  else {}
	  ?></p>
      </div></td>
  </tr>
  <tr>
    <td><div align="center" class="style52 style54">Periode <? echo $pick_date ; ?> s/d <? echo $pick_date2 ; ?> </div></td>
  </tr>
  <tr>
    <td><form action="" method="post" name="form1" target="_self">
      <table width="100%" border="0" bgcolor="#CCCCFF">
        <tr>
          <td bgcolor="#CCFFFF"><div align="right">
              <table width="738" border="0" align="center">
                <tr>
                  <td width="197">Periode :
                    <label><span class="style2">
                    <input name="pick_date" type="text" id="pick_date" value="<? if($pick_date==''){echo date('Y-m-d');} else echo $pick_date; ?>" size="12" />
                    <input name="Button" type="button" style="background-image:url(images/Calendar.png); background-repeat:no-repeat; background-position:center; border:none;" onClick="pick('pick_date');" value="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" />
                    </span></label></td>
                  <td width="174"><label>s/d : <span class="style2">
                    <input name="pick_date2" type="text" id="pick_date2" value="<? if($pick_date2==''){echo date('Y-m-d');} else echo $pick_date2; ?>" size="12" />
                    <input name="Button2" type="button" style="background-image:url(images/Calendar.png); background-repeat:no-repeat; background-position:center; border:none;" onClick="pick('pick_date2');" value="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" />
                  </span></label></td>
                  <td width="223">Bulan :
				  <?
				  $selBln=mssql_query("SELECT CAST(DATEPART(MONTH, Periode) AS VARCHAR) + '/' + CAST(DATEPART(YEAR, 
				  Periode) AS VARCHAR) AS Periode from Proposal Where Start = '".$pick_date."' AND Stop ='".$pick_date2."'
				   GROUP BY Periode");
				   $rowBln = mssql_fetch_array($selBln);
					?>				  
                    <input name="fClosing" type="text" id="fClosing" value="<? echo $rowBln[Periode]; ?>">
                    <label></label></td>
                  <td width="64"><a href="#" onMouseOver="MM_displayStatusMsg('Update By . .');return document.MM_returnValue">
                    <input name="bIns" type="submit" id="bIns" value="Insert">
                  </a></td>
                  <td width="58">
                    <input name="Submit2" type="submit" value="refresh"></td>
                </tr>
              </table>
          </div>
              <div align="left"></div></td>
        </tr>
        <tr>
          <td bgcolor="#CCFFFF">
<input name="hID" type="hidden" id="hID" value="<? echo $bEdit; ?>">
 <? if($bIns=='Insert'){ echo ("
<table width=456 border=0 bgcolor=#99CCFF>
  <tr>
    <td width=52>List :</td>
    <td width=350>
	<select name=mmLi id=mmLi >");
							  echo "<option value= '$row4[ID]' "; if ($row4[ID]==$mmLi){echo"selected=selected";} echo">$row4[Descr]
							  </option>";
							  while ($row4 = mssql_fetch_array($q4)){
							  echo "<option value= '$row4[ID]' "; if ($row4[ID]==$mmLi){echo"selected=selected";} echo">$row4[Descr]
							  </option>"; }
							  echo("</select>
          </td>
    <td width=100>Nominal_Rp.</td>
    <td width=166>
    <input name=mNominal type=text size=20></td>
  </tr>
  <tr>
    <td></td>
	<td></td>
	<td></td>
    <td><div align=right><input name=bSave type=submit id=bSave value=Save></td>
  </tr>
</table>
");} 
?>

<? if(!$bEdit==''){
$Sel1 = mssql_query ("Select * from (
SELECT     Tbl.ID, Tbl.Periode, Tbl.Start, Tbl.Stop, Tbl.IDDept, dbo.v_Proposal.Dept, dbo.v_Proposal.Kategori, dbo.v_Proposal.Acount, dbo.v_Proposal.Descr, 
                      dbo.v_Proposal.List, ISNULL(Tbl.Nominal, 0) AS Nominal, ISNULL(Tbl.StatusClosing, 0) AS StatusClosing
FROM         (SELECT     dbo.Proposal.ID, CAST(DATEPART(MONTH, dbo.ref_Closing.Periode) AS VARCHAR) + '/' + CAST(DATEPART(YEAR, dbo.ref_Closing.Periode) 
                                              AS VARCHAR) AS Periode, dbo.Proposal.Start, dbo.Proposal.Stop, DATEDIFF(DAY, dbo.Proposal.Start, dbo.Proposal.Stop) AS TotalHari, 
                                              dbo.v_COA_L4.Descr AS Dept, dbo.ref_Dept.NamaDept AS DeptAdd, dbo.v_COA_L5.Kategori, dbo.Proposal.Acount, dbo.v_COA_L5.Descr, 
                                              dbo.ref_Acounts.Descr AS List, SUM(dbo.Proposal.Nominal) AS Nominal, ISNULL(dbo.ref_Closing.Status, 0) AS StatusClosing, 
                                              dbo.v_COA_L4.Acount AS IDDept
                       FROM          dbo.Proposal INNER JOIN
                                              dbo.v_COA_L5 ON dbo.Proposal.Acount = dbo.v_COA_L5.Acount INNER JOIN
                                              dbo.v_COA_L4 ON dbo.Proposal.Dept = dbo.v_COA_L4.Acount LEFT OUTER JOIN
                                              dbo.ref_Acounts ON dbo.Proposal.List = dbo.ref_Acounts.ID LEFT OUTER JOIN
                                              dbo.ref_Dept ON dbo.Proposal.DeptAdd = dbo.ref_Dept.ID LEFT OUTER JOIN
                                              dbo.ref_Closing ON dbo.Proposal.Periode = dbo.ref_Closing.Periode
                       GROUP BY dbo.Proposal.Acount, dbo.Proposal.Nominal, dbo.v_COA_L5.Descr, dbo.v_COA_L5.Kategori, dbo.ref_Closing.Periode, 
                                              dbo.ref_Closing.Status, dbo.Proposal.Stop, dbo.Proposal.Start, dbo.v_COA_L4.Descr, dbo.ref_Dept.NamaDept, dbo.ref_Acounts.Descr, 
                                              dbo.Proposal.ID, dbo.v_COA_L4.Acount) AS Tbl INNER JOIN
                      dbo.v_Proposal ON Tbl.Dept = dbo.v_Proposal.Dept AND Tbl.Acount = dbo.v_Proposal.Acount AND Tbl.List = dbo.v_Proposal.List) AS Tbl
					  Where ID = '$bEdit'") or die ("Terdapat kesalahan Update!");
$dUp=mssql_fetch_array($Sel1);
echo ("<table width=456 border=0 bgcolor=#99CCFF>
  <tr>
    <td width=52>List :</td>
    <td width=350>$dUp[List]
          </td>
    <td width=100>Nominal_Rp.</td>
    <td width=166>
    <input name=eNominal value =$dUp[Nominal] type=text size=20></td>
  </tr>
  <tr>
    <td></td>
	<td></td>
	<td><div align=right><input name=bDel type=submit id=bDel value=Delete></td>
    <td><div align=right><input name=bUpdate type=submit id=bUpdate value=Update></td>
  </tr>
</table>
");
} ?>

<?
if($bDel=='Delete') {
$delete="DELETE Proposal WHERE ID='$hID'";
$hasil =@mssql_query ($delete) or die ("Terdapat Kesalahan Delete");
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data TerHapus.!!'); </SCRIPT> </BODY>");
}
if($bUpdate=='Update') {
$update="UPDATE Proposal SET Nominal='$eNominal' WHERE ID='$hID'";
$hasil =@mssql_query ($update) or die ("Terdapat Kesalahan Update");
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data TerUpdate.!!'); </SCRIPT> </BODY>");
}
if($bSave=='Save') {
$selRef=mssql_query("
SELECT (CAST(DATEPART(YEAR, Start) AS VARCHAR) + '-' + 
CASE WHEN len(CAST(DATEPART(MONTH, Start) AS VARCHAR)) = 1 THEN
'0'+CAST(DATEPART(MONTH, Start) AS VARCHAR) ELSE CAST(DATEPART(MONTH, Start) AS VARCHAR) END
 + '-' +
CASE WHEN len(CAST(DATEPART(DAY, Start) AS VARCHAR)) = 1 THEN
'0'+CAST(DATEPART(DAY, Start) AS VARCHAR) ELSE CAST(DATEPART(DAY, Start) AS VARCHAR) END)
 AS Start,
(CAST(DATEPART(YEAR, Stop) AS VARCHAR) + '-' + 
CASE WHEN len(CAST(DATEPART(MONTH, Stop) AS VARCHAR)) = 1 THEN
'0'+CAST(DATEPART(MONTH, Stop) AS VARCHAR) ELSE CAST(DATEPART(MONTH, Stop) AS VARCHAR) END
 + '-' +
CASE WHEN len(CAST(DATEPART(DAY, Stop) AS VARCHAR)) = 1 THEN
'0'+CAST(DATEPART(DAY, Stop) AS VARCHAR) ELSE CAST(DATEPART(DAY, Stop) AS VARCHAR) END)
 AS Stop, Periode
 from ref_Proposal Where Start = '".$pick_date."' AND Stop ='".$pick_date2."'");
$rowRef = mssql_fetch_array($selRef);
if(($rowRef[Start]==$pick_date) AND ($rowRef[Stop]==$pick_date2)) {
$Peri=$rowRef[Periode];
$insert="INSERT INTO Proposal (Periode,Start,Stop,Dept,Acount,List,Nominal) VALUES('$Peri','$pick_date','$pick_date2','$mmDept','$mmAc','$mmLi','$mNominal')";
$hasil =@mssql_query ($insert) or die ("Terdapat Kesalahan Insert");
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data Tersimpan.!!'); </SCRIPT> </BODY>");}
else {
echo ("<BODY> <SCRIPT language='Javascript'> alert('Periode tdk diIjinkan.!!'); </SCRIPT> </BODY>");}
}
?>
<?php
$Awal  = $pick_date.' 00:00.000';
$Akhir = $pick_date2.' 00:00.000';

/*
$sel2=mssql_query("select CAST(CAST(YEAR([Date]) AS VARCHAR) + '-' + CAST(MONTH([Date]) AS VARCHAR) + '-' + CAST(DAY([Date])AS VARCHAR) AS Varchar) AS [Date], CAST(CAST(datepart(HOUR,[TA]) as varchar)+':'+CAST(datepart(MINUTE,[TA]) as varchar) AS varchar) AS [TA], CAST(CAST(datepart(HOUR,[TD]) as varchar)+':'+CAST(datepart(MINUTE,[TD]) as varchar) AS varchar) AS [TD], Barge, TogBoat, Cargo, Shipping, Id, PIT from Barging where Barging.date >='$Awal' and Barging.date <='$Akhir' order by Barging.Date")
*/
$sel2=mssql_query(" Select * from (
SELECT     Tbl.ID, Tbl.Periode, Tbl.Start, Tbl.Stop, Tbl.IDDept, dbo.v_Proposal.Dept, dbo.v_Proposal.Kategori, dbo.v_Proposal.Acount, dbo.v_Proposal.Descr, 
                      dbo.v_Proposal.List, ISNULL(Tbl.Nominal, 0) AS Nominal, ISNULL(Tbl.StatusClosing, 0) AS StatusClosing
FROM         (SELECT     dbo.Proposal.ID, CAST(DATEPART(MONTH, dbo.ref_Closing.Periode) AS VARCHAR) + '/' + CAST(DATEPART(YEAR, dbo.ref_Closing.Periode) 
                                              AS VARCHAR) AS Periode, dbo.Proposal.Start, dbo.Proposal.Stop, DATEDIFF(DAY, dbo.Proposal.Start, dbo.Proposal.Stop) AS TotalHari, 
                                              dbo.v_COA_L4.Descr AS Dept, dbo.ref_Dept.NamaDept AS DeptAdd, dbo.v_COA_L5.Kategori, dbo.Proposal.Acount, dbo.v_COA_L5.Descr, 
                                              dbo.ref_Acounts.Descr AS List, SUM(dbo.Proposal.Nominal) AS Nominal, ISNULL(dbo.ref_Closing.Status, 0) AS StatusClosing, 
                                              dbo.v_COA_L4.Acount AS IDDept
                       FROM          dbo.Proposal INNER JOIN
                                              dbo.v_COA_L5 ON dbo.Proposal.Acount = dbo.v_COA_L5.Acount INNER JOIN
                                              dbo.v_COA_L4 ON dbo.Proposal.Dept = dbo.v_COA_L4.Acount LEFT OUTER JOIN
                                              dbo.ref_Acounts ON dbo.Proposal.List = dbo.ref_Acounts.ID LEFT OUTER JOIN
                                              dbo.ref_Dept ON dbo.Proposal.DeptAdd = dbo.ref_Dept.ID LEFT OUTER JOIN
                                              dbo.ref_Closing ON dbo.Proposal.Periode = dbo.ref_Closing.Periode
                       GROUP BY dbo.Proposal.Acount, dbo.Proposal.Nominal, dbo.v_COA_L5.Descr, dbo.v_COA_L5.Kategori, dbo.ref_Closing.Periode, 
                                              dbo.ref_Closing.Status, dbo.Proposal.Stop, dbo.Proposal.Start, dbo.v_COA_L4.Descr, dbo.ref_Dept.NamaDept, dbo.ref_Acounts.Descr, 
                                              dbo.Proposal.ID, dbo.v_COA_L4.Acount) AS Tbl INNER JOIN
                      dbo.v_Proposal ON Tbl.Dept = dbo.v_Proposal.Dept AND Tbl.Acount = dbo.v_Proposal.Acount AND Tbl.List = dbo.v_Proposal.List) AS Tbl
					  Where (Start = '".$pick_date."' AND Stop = '".$pick_date2."') AND IDDept = '".$mmDept."' AND Kategori = '".$mmKat."' AND Acount = '".$mmAc."'
				  ")
or die ("Terdapat kesalahan pada perintah SQL!");
/*
$sel3=mssql_query("Select SUM(CARGO) as [Tot] from Barging where Barging.date >='$Awal' and Barging.date <='$Akhir'")
or die ("Terdapat kesalahan pada perintah SQL!");
$dSum=mssql_fetch_array($sel3);
*/
/*
$sel3=mssql_query("Select SUM(CARGO) as [Tot] from Barging where Barging.date >='$Awal' and Barging.date <='$Akhir' and Barging.Pit='$mPit'")
or die ("Terdapat kesalahan pada perintah SQL!"); 
$dSum=mssql_fetch_array($sel3); */

echo("<table width=100%  border=0 bgcolor=#99CCFF>");
echo("<td bgcolor=#336699><div align=center><span class=style2>
							  <select name=mmDept id=mmDept onChange=this.form.submit()>");
							  echo "<option value= '$row1[ID]' "; if ($row1[ID]==$mmDept){echo"selected=selected";} 
							  echo">$row1[Descr]</option>";
							  while ($row1 = mssql_fetch_array($q1)){
							  echo "<option value= '$row1[ID]' "; if ($row1[ID]==$mmDept){echo"selected=selected";} 
							  echo">$row1[Descr]</option>";}
					          echo("</select></span></td><td bgcolor=#336699><div align=center><span class=style2>
							  <select name=mmKat id=mmKat onChange=this.form.submit()>");
							  echo "<option value=></option>";
							  echo "<option value= '$row2[Kategori]' "; if ($row2[Kategori]==$mmKat){echo"selected=selected";} echo">$row2[Kategori]
							  </option>";
							  while ($row2 = mssql_fetch_array($q2)){
							  echo "<option value= '$row2[Kategori]' "; if ($row2[Kategori]==$mmKat){echo"selected=selected";} echo">$row2[Kategori]
							  </option>"; }
							  echo("</select>
							  </span></td><td bgcolor=#336699><div align=center><span class=style2>
							  <select name=mmAc id=mmAc onChange=this.form.submit()>");
							  echo "<option value=></option>";
							  echo "<option value= '$row3[Acount]' "; if ($row3[Acount]==$mmAc){echo"selected=selected";} echo">($row3[Acount]) 
							  $row3[Descr]</option>";
							  while ($row3 = mssql_fetch_array($q3)){
							  echo "<option value= '$row3[Acount]' "; if ($row3[Acount]==$mmAc){echo"selected=selected";} echo">($row3[Acount]) 
							  $row3[Descr]</option>"; }
							  echo("</span></td>
                              <td bgcolor=#336699><div align=center><span class=style2>List</span></td>
                              <td bgcolor=#336699><div align=center><span class=style2>Proposal</span></td>
                              <td bgcolor=#336699><div align=center><span class=style2>IBS</span></td>
							  <td bgcolor=#336699><div align=center><span class=style2>Actual</span></td>
                              <td bgcolor=#336699><div align=center><span class=style2>@</span></td>");
// ------ ambil isi masing-masing record
while ($row = mssql_fetch_object($sel2))
{
		// ----- mengambil isi setiap kolom
		
		$ID=$row->ID;
		$Dept=$row->Dept;
		//$Date=SubStr($row->Date,0,11);
		$Kategori=$row->Kategori;
		$Acount=$row->Acount;
		$Descr=$row->Descr;
		$List=$row->List;
		if($row->Kategori!='Production') {
		$Nominal= 'Rp. '.number_format($row->Nominal,0,",",".").',-'; }
		else {
		$Nominal= number_format($row->Nominal,0,",",".");
		}
		$Status=$row->Status;

		// ------ menampilkan di layar browser
		echo("<tr><div align=center>
		    <td bgcolor=#CFFFFF class=style5><div align=Center>$Dept</td>
			<td bgcolor=#CFFFFF class=style5><div align=Center>$Kategori</td>
			<td bgcolor=#CFFFFF class=style5><div align=Center>($Acount) $Descr</td>
			<td bgcolor=#CFFFFF class=style5><div align=Center>$List</td>
			<td bgcolor=#CFFFFF class=style5><div align=Right>$Nominal</td>
			<td bgcolor=#CFFFFF class=style5><div align=Center> ~ </td>
			<td bgcolor=#CFFFFF class=style5><div align=Center> ~ </td>");
			echo("<td bgcolor=#CFFFFF class=style5><div align=Center><input type=submit name=bEdit value=Edit onClick='value=$row->ID'>
			</td>
			</tr>");
}
echo("
<tr>
    <td bgcolor=#CFFFFF class=style5 colspan=4><div align=right class=style55>Compare ->></td>
    <td bgcolor=#CFFFFF class=style5><div align=Right>");
	if ($rowProp[Nominal] > $rowIBS[IBS]) {	echo("<span class=styleRed>$TNominal</span></td>"); } 
	else { echo("<span class=styleGren>$TNominal</span></td>"); }
    echo("<td bgcolor=#CFFFFF class=style5><div align=Right>$TIBS</td>
    <td bgcolor=#CFFFFF class=style5><div align=Right>$TActual</td>
    <td bgcolor=#CFFFFF class=style5><div align=Center><<-</td>
  </tr>
</table>");
mssql_close($koneksi)
?></td>
        </tr>
        <tr>
          <td bgcolor="#CCFFFF"><table width="100%" border="0">
            <tr>
              <td width="877"><div align="right" class="style55">
                Total : </a></div></td>
              <td width="107">
			  <a class=style55><a href="#">
			  <? echo $rowIBS[IBS]-$rowIBS[Nominal]/$rowIBS[IBS]*100 ; 
			  ?></td>
            </tr>
          </table></td>
        </tr>
      </table>
        </form></td>
  </tr>
</table>

</body>
</html>
