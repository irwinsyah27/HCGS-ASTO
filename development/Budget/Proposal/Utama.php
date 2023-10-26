<?php
session_start();
//require("../cek.php");
// ----- ambil isi dari file koneksi.php
require("../tools/koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();
?>
<html>
<head>
<title>Proposal Budget</title>
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
<?php 
$SDept = $_SESSION[Dept];
//$SDept = "HRPGA";

if ($SDeptAdd!='')  {
if (($SDept!='HRPGA') AND ($SDeptAdd!='11')) {echo ("<BODY> <SCRIPT language='Javascript'> alert('Dept $SDept, DeptAdd Harus ALL..!!'); </SCRIPT> </BODY>"); $SDeptAdd=11;}
} else {$SDeptAdd=11;}

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

function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
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
.style5 {color: Black; font-family: "DejaVu Sans"}
.style56 {color: #FFFFFF}
.style57 {color: #3399FF; font-size: 36px; }
-->
</style>
</head>

<body>
<table width="100%" border="0" bgcolor="#FF0000">
  <tr>
    <td><table width="100%" border="0" bgcolor="#FFFFFF">
      <tr>
        <td><form name="form1" method="post" action="">
          <?php
// ------ buat tampilan tabel

$qPeriode = mssql_query("SELECT CAST(DATEPART(MONTH, Periode) AS VARCHAR) + '/' + CAST(DATEPART(YEAR, Periode) AS VARCHAR) AS Periode, CONVERT(DATE,Start) AS Start, CONVERT(DATE,Stop) AS Stop, Status FROM dbo.ref_Closing WHERE Status = 1");
$rowPeriode = mssql_fetch_array($qPeriode);

$qPeriodeW = mssql_query("SELECT * FROM(SELECT CAST(DATEPART(MONTH, Periode) AS VARCHAR) + '/' + CAST(DATEPART(YEAR, Periode) AS VARCHAR) AS Periode, CONVERT(DATE,Start) AS Start, CONVERT(DATE,Stop) AS Stop, Status FROM dbo.ref_Closing) AS Tbl WHERE Status = 1 AND Periode = '$mmPeriode'");
$rowPeriodeW = mssql_fetch_array($qPeriodeW);

IF ($_SESSION[User] == 'KC10047' OR $_SESSION[User] == 'KC07103' OR $_SESSION[User] == 'KB10033' OR $_SESSION[User] == '6195011') {
$qDept = mssql_query("SELECT    ID, Dept AS Descr
FROM         (SELECT     dbo.v_COA_L4.Acount AS ID, dbo.v_COA_L4.Descr AS Dept, dbo.v_COA_L5.Kategori, dbo.v_COA_L5.Acount, dbo.v_COA_L5.Descr, 
                      dbo.ref_Acounts.Descr AS List
FROM         dbo.ref_Acounts INNER JOIN
                      dbo.v_COA_L4 ON dbo.v_COA_L4.Acount LIKE dbo.ref_Acounts.Dept INNER JOIN
                      dbo.v_COA_L5 ON dbo.ref_Acounts.Acount = dbo.v_COA_L5.Acount
GROUP BY dbo.v_COA_L4.Descr, dbo.v_COA_L5.Kategori, dbo.v_COA_L5.Acount, dbo.v_COA_L5.Descr, dbo.ref_Acounts.Descr, dbo.v_COA_L4.Acount) AS Proposal
GROUP BY ID, Dept");
} else {
$qDept = mssql_query("SELECT    ID, Dept AS Descr
FROM         (SELECT     dbo.v_COA_L4.Acount AS ID, dbo.v_COA_L4.Descr AS Dept, dbo.v_COA_L5.Kategori, dbo.v_COA_L5.Acount, dbo.v_COA_L5.Descr, 
                      dbo.ref_Acounts.Descr AS List
FROM         dbo.ref_Acounts INNER JOIN
                      dbo.v_COA_L4 ON dbo.v_COA_L4.Acount LIKE dbo.ref_Acounts.Dept INNER JOIN
                      dbo.v_COA_L5 ON dbo.ref_Acounts.Acount = dbo.v_COA_L5.Acount
GROUP BY dbo.v_COA_L4.Descr, dbo.v_COA_L5.Kategori, dbo.v_COA_L5.Acount, dbo.v_COA_L5.Descr, dbo.ref_Acounts.Descr, dbo.v_COA_L4.Acount) AS Proposal
Where Dept = '$SDept'
GROUP BY ID, Dept");}
$rDept = mssql_fetch_array($qDept);

$qPIT= mssql_query("SELECT * FROM(SELECT DISTINCT PIT FROM [BudgetSystem].[dbo].[v_PLO] UNION ALL SELECT 'ALL PIT' AS PIT) AS PIT ORDER BY PIT");
$qPIT1= mssql_query("SELECT * FROM(SELECT DISTINCT PIT FROM [BudgetSystem].[dbo].[v_PLO] UNION ALL SELECT 'ALL PIT' AS PIT) AS PIT Where PIT = '$mmPIT' ORDER BY PIT DESC");
$qPIT2= mssql_query("SELECT * FROM(SELECT DISTINCT PIT FROM [BudgetSystem].[dbo].[v_PLO] UNION ALL SELECT 'ALL PIT' AS PIT) AS PIT Where PIT = '$mmPIT' ORDER BY PIT DESC");
$qPIT3= mssql_query("SELECT * FROM(SELECT DISTINCT PIT FROM [BudgetSystem].[dbo].[v_PLO] UNION ALL SELECT 'ALL PIT' AS PIT) AS PIT Where PIT = '$mmPIT' ORDER BY PIT DESC");
$qPIT4= mssql_query("SELECT * FROM(SELECT DISTINCT PIT FROM [BudgetSystem].[dbo].[v_PLO] UNION ALL SELECT 'ALL PIT' AS PIT) AS PIT Where PIT = '$mmPIT' ORDER BY PIT DESC");
$rowPIT = mssql_fetch_array($qPIT);
$rowPIT4 = mssql_num_rows($qPIT4);
$rowPIT5 = mssql_num_rows($qPIT4)-1;


$qProposal= mssql_query("SELECT dbo.v_Proposal.ID, PIT.PIT, dbo.v_Proposal.Dept, dbo.v_Proposal.Kategori, dbo.v_Proposal.Acount, dbo.v_Proposal.Descr, dbo.v_Proposal.List, 0 AS Nominal FROM (SELECT DISTINCT PIT FROM dbo.v_PLO) AS PIT CROSS JOIN dbo.v_Proposal Where dbo.v_Proposal.Dept = '$mmDept'");
$rowProposal = mssql_fetch_array($qProposal);

$qIBS= mssql_query("SELECT     dbo.v_PLO.Periode, dbo.v_PLO.Kategori, dbo.v_PLO.Acount, dbo.v_PLO.Descr, dbo.v_PLO.Urut, SUM(dbo.v_PLO.Nominal) 
                      AS PlanMining, SUM(dbo.v_PLO.Trading) AS PlanTrading, SUM(ISNULL(dbo.v_Proposal_List.Nominal, 0)) AS ActualMining, 
                      SUM(ISNULL(dbo.v_Proposal_List.TNominal, 0)) AS ActualTrading
FROM         dbo.v_PLO LEFT OUTER JOIN
                      dbo.v_Proposal_List ON dbo.v_PLO.Acount = dbo.v_Proposal_List.Acount AND dbo.v_PLO.PIT = dbo.v_Proposal_List.PIT AND 
                      dbo.v_PLO.Periode = dbo.v_Proposal_List.Periode
Where dbo.v_PLO.Periode = '$rowPeriodeW[Periode]' AND dbo.v_PLO.Acount IN (SELECT DISTINCT Acount FROM dbo.v_Proposal Where dbo.v_Proposal.Dept = '$mmDept')
GROUP BY dbo.v_PLO.Periode, dbo.v_PLO.Kategori, dbo.v_PLO.Acount, dbo.v_PLO.Descr, dbo.v_PLO.Urut");

$qIBSPIT= mssql_query("SELECT * FROM (
SELECT     dbo.v_PLO.Periode, dbo.v_PLO.PIT, dbo.v_PLO.Kategori, dbo.v_PLO.Acount, dbo.v_PLO.Descr, dbo.v_PLO.Urut, SUM(dbo.v_PLO.Nominal) 
                      AS PlanMining, SUM(dbo.v_PLO.Trading) AS PlanTrading, SUM(ISNULL(dbo.v_Proposal_List.Nominal, 0)) AS ActualMining, 
                      SUM(ISNULL(dbo.v_Proposal_List.TNominal, 0)) AS ActualTrading
FROM         dbo.v_PLO LEFT OUTER JOIN
                      dbo.v_Proposal_List ON dbo.v_PLO.Acount = dbo.v_Proposal_List.Acount AND dbo.v_PLO.PIT = dbo.v_Proposal_List.PIT AND 
                      dbo.v_PLO.Periode = dbo.v_Proposal_List.Periode
Where dbo.v_PLO.Periode = '$rowPeriodeW[Periode]' AND dbo.v_PLO.Acount IN (SELECT DISTINCT Acount FROM dbo.v_Proposal Where dbo.v_Proposal.Dept = '$mmDept')
GROUP BY dbo.v_PLO.Periode, dbo.v_PLO.Kategori, dbo.v_PLO.Acount, dbo.v_PLO.Descr, dbo.v_PLO.Urut, dbo.v_PLO.PIT
UNION ALL
SELECT     dbo.v_PLO.Periode, 'ALL PIT' AS PIT, dbo.v_PLO.Kategori, dbo.v_PLO.Acount, dbo.v_PLO.Descr, dbo.v_PLO.Urut, SUM(dbo.v_PLO.Nominal) 
                      AS PlanMining, SUM(dbo.v_PLO.Trading) AS PlanTrading, SUM(ISNULL(dbo.v_Proposal_List.Nominal, 0)) AS ActualMining, 
                      SUM(ISNULL(dbo.v_Proposal_List.TNominal, 0)) AS ActualTrading
FROM         dbo.v_PLO LEFT OUTER JOIN
                      dbo.v_Proposal_List ON dbo.v_PLO.Acount = dbo.v_Proposal_List.Acount AND dbo.v_PLO.PIT = dbo.v_Proposal_List.PIT AND 
                      dbo.v_PLO.Periode = dbo.v_Proposal_List.Periode
Where dbo.v_PLO.Periode = '$rowPeriodeW[Periode]' AND dbo.v_PLO.Acount IN (SELECT DISTINCT Acount FROM dbo.v_Proposal Where dbo.v_Proposal.Dept = '$mmDept')
GROUP BY dbo.v_PLO.Periode, dbo.v_PLO.Kategori, dbo.v_PLO.Acount, dbo.v_PLO.Descr, dbo.v_PLO.Urut) AS IBS Where PIT = '$mmPIT' ORDER BY Urut, Acount, PIT DESC");

//$qIBS= mssql_query("SELECT Nominal AS Mining, Trading, Periode, Kategori, Acount, Urut FROM dbo.v_PLO Where Periode = '$rowPeriodeW[Periode]' AND Acount IN (SELECT DISTINCT Acount FROM dbo.v_Proposal Where dbo.v_Proposal.Dept = '$SDept') GROUP BY Periode, Kategori, Acount, Nominal, Trading, Urut ORDER BY Urut");
//$rowIBSPIT = mssql_fetch_array($qIBSPIT);

//secho $rowPIT4;
//$qPIT= mssql_query("SELECT DISTINCT PIT FROM [BudgetSystem].[dbo].[v_PLO]");
//$rowPIT = mssql_fetch_array($qPeriode);

//$qPIT= mssql_query("SELECT DISTINCT PIT FROM [BudgetSystem].[dbo].[v_PLO]");
//$rowPIT = mssql_fetch_array($qPeriode);

//$qPIT= mssql_query("SELECT DISTINCT PIT FROM [BudgetSystem].[dbo].[v_PLO]");
//$rowPIT = mssql_fetch_array($qPeriode);
?>
          <table width="100%" border="0" align="center">
            <tr>
              <td><div class="style55">
                  <table cellspacing="0" cellpadding="0">
                    <tr height="20">
                      <td colspan="10" class="style55">PT.   KALIMANTAN PRIMA PERSADA</td>
                    </tr>
                    <tr height="20">
                      <td height="20" colspan="10" class="style55">BUDGET COST AND CASH   OUT</td>
                      <td width="4">&nbsp;</td>
                      <td colspan="3"></td>
                    </tr>
                    <tr height="20">
                      <td width="286" height="20" class="style55">PERIODs</td>
                      <td colspan="5" class="style55">: 
					  <?php   echo "<select name=mmPeriode id=mmPeriode onChange=this.form.submit()>";
							  echo "<option value=></option>";
							  echo "<option value= '$rowPeriode[Periode]' "; if ($rowPeriode[Periode]==$mmPeriode){echo"selected=selected";} echo">$rowPeriode[Periode]
							  </option>";
							  while ($rowPeriode = mssql_fetch_array($qPeriode)){
							  echo "<option value= '$rowPeriode[Periode]' "; if ($rowPeriode[Periode]==$mmPeriode){echo"selected=selected";} echo">$rowPeriode[Periode]
							  </option>"; } echo"</select>"; ?>
					  <?php echo " ( $rowPeriodeW[Start]" ; ?> s/d <?php echo " $rowPeriodeW[Stop] )" ; ?> </td>
                    </tr>
                    <tr height="20">
                      <td height="20" class="style55">DISTRICT</td>
                      <td colspan="5" class="style55">: RANTAU</td>
                    </tr>
                    <tr class="style55" height="20">
                      <td height="20">DEPARTMENT</td>
                      <td>: 
					  <?php
echo("<select name=mmDept id=mmDept onChange=this.form.submit()>");
							  echo "<option value= '$rDept[Descr]' "; if ($rDept[Descr]==$mmDept){echo"selected=selected";} 
							  echo">$rDept[Descr]</option>";
							  while ($rDept = mssql_fetch_array($qDept)){
							  echo "<option value= '$rDept[Descr]' "; if ($rDept[Descr]==$mmDept){echo"selected=selected";} 
							  echo">$rDept[Descr]</option>";}
					          echo("</select>");
	  	  
$selIBS=mssql_query("SELECT     SUM(Nominal)+SUM(Trading) AS IBS, Periode, Kategori, Acount
FROM         dbo.v_PLO
Where Periode = '".$fClosing."' AND Acount ='".$mmAc."'
GROUP BY Periode, Kategori, Acount
 ");

$rowIBS = mssql_fetch_array($selIBS);
if($rowIBS[Kategori]!='Production') {
$TNominal = 'Rp. '.number_format($rowProp[Nominal],0,",",".").',-';
$TIBS = 'Rp. '.number_format($rowIBS[IBS],0,",",".").',-'; }
else {
$TNominal = number_format($rowProp[Nominal],0,",",".");
$TIBS = number_format($rowIBS[IBS],0,",","."); 
}
	   
	  if (strval($rowProp[Nominal]) > strval($rowIBS[IBS])) { $Dev = (strval($rowProp[Nominal])-strval($rowIBS[IBS]))/strval($rowProp[Nominal])*100 ; echo " Deviasi ".$Dev."%"; } 
	  else {}
	  
	  ?><span class="style5"> <span class="style56"></span>
                            <select name="SDeptAdd" id="SDeptAdd" lang="" onChange="this.form.submit()">
                              <option value="11" selected <?php if (!(strcmp("11", $SDeptAdd))) {echo "selected=\"selected\"";} ?>>All</option>
                              <option value="1" <?php if (!(strcmp("1", $SDeptAdd))) {echo "selected=\"selected\"";} ?>>HR</option>
                              <option value="2" <?php if (!(strcmp("2", $SDeptAdd))) {echo "selected=\"selected\"";} ?>>PERS</option>
                              <option value="3" <?php if (!(strcmp("3", $SDeptAdd))) {echo "selected=\"selected\"";} ?>>GA</option>
                              <option value="4" <?php if (!(strcmp("4", $SDeptAdd))) {echo "selected=\"selected\"";} ?>>CIVIL</option>
                              <option value="5" <?php if (!(strcmp("5", $SDeptAdd))) {echo "selected=\"selected\"";} ?>>CDV</option>
                              <option value="6" <?php if (!(strcmp("6", $SDeptAdd))) {echo "selected=\"selected\"";} ?>>IT</option>
                              <option value="7" <?php if (!(strcmp("7", $SDeptAdd))) {echo "selected=\"selected\"";} ?>>INS</option>
                              <option value="10" <?php if (!(strcmp("10", $SDeptAdd))) {echo "selected=\"selected\"";} ?>>SEC</option>
                            </select>
                            <label for="textfield"></label>
							<?php   echo "<select name=mmPIT id=mmPIT onChange=this.form.submit()>";
							  echo "<option value=></option>";
							  echo "<option value= '$rowPIT[PIT]' "; if ($rowPIT[PIT]==$mmPIT){echo"selected=selected";} echo">$rowPIT[PIT]
							  </option>";
							  while ($rowPIT = mssql_fetch_array($qPIT)){
							  echo "<option value= '$rowPIT[PIT]' "; if ($rowPIT[PIT]==$mmPIT){echo"selected=selected";} echo">$rowPIT[PIT]
							  </option>"; } echo"</select>"; ?>
					  </td>
                      </span></td>
                    </tr>
                    <tr class="style55" height="20">
                      <td height="20">TOTAL BUDGET COST </td>
                      <td width="363">: <? echo ' [ Rp. '.number_format($rowProp2[Nominal],0,",",".").',- ]'; ?></td>
                    </tr>
                  </table>
              </div></td>
            </tr>
            <tr>
              <td><div align="center" class="style52 style54"></div></td>
            </tr>
            <tr>
              <td><table width="100%" border="0">
                <tr>
                  <td bgcolor="#919191">
				  <?php
				  echo("<table width=100%  border=0 ><tr>");
				  echo("<td rowspan=3 bgcolor=#336699><div align=center><span class=style2>DEPT</span></td>
                        <td rowspan=3 bgcolor=#336699><div align=center><span class=style2>CATEGORY</span></td>
                        <td rowspan=3 bgcolor=#336699><div align=center><span class=style2>COA</span></td>
                        <td rowspan=3 bgcolor=#336699><div align=center><span class=style2>DESCRIPTION</span></td>");
						while ($rowP1 = mssql_fetch_object($qPIT1))
						{
						echo("<td colspan=4 bgcolor=#336699><div align=center><span class=style2>$rowP1->PIT</span></td>");
						}
						echo("</tr><tr>");
						while ($rowP2 = mssql_fetch_object($qPIT2))
						{
						echo("<td colspan=2 bgcolor=#336699><div align=center><span class=style2>PLAN</span></td>
							  <td colspan=2 bgcolor=#336699><div align=center><span class=style2>ACTUAL</span></td>");
						}
						echo("</tr><tr>");
						while ($rowP3 = mssql_fetch_object($qPIT3))
						{
						echo("<td bgcolor=#336699><div align=center><span class=style2>MINING</span></td>
							  <td bgcolor=#336699><div align=center><span class=style2>TRADING</span></td>
							  <td bgcolor=#336699><div align=center><span class=style2>MINING</span></td>
							  <td bgcolor=#336699><div align=center><span class=style2>TRADING</span></td>");
						}
						echo("</tr>");
				  // ------ ambil isi masing-masing record
				while ($row = mssql_fetch_object($qIBSPIT))
				{
				$No=$No+1;
				$Next1=$No%$rowPIT4;
				$Next2=($No-1)%$rowPIT4;
				$Periode=$row->Periode;
				$PIT=$row->PIT;
				$mPIT=str_replace(" ","","$PIT");
				$Kategori=$row->Kategori;
				$Acount=$row->Acount;
				$Descr=$row->Descr;
				$Urut=$row->Urut;				
				if($row->Kategori!='Production') {
				$PNominal= 'Rp.'.number_format($row->PlanMining,0,",",".").',-';
				$PTNominal= 'Rp.'.number_format($row->PlanTrading,0,",",".").',-'; 
				$ANominal= 'Rp.'.number_format($row->ActualMining,0,",",".").',-';
				$ATNominal= 'Rp.'.number_format($row->ActualTrading,0,",",".").',-'; 
				}
				else {
				$PNominal= number_format($row->PlanMining,0,",",".");
				$PTNominal= number_format($row->PlanTrading,0,",",".");
				$ANominal= number_format($row->ActualMining,0,",",".");
				$ATNominal= number_format($row->ActualTrading,0,",",".");
				}
				$Status=$row->Status;
				
				$mIBS= number_format($row->PlanMining,"",",","");
				$tIBS= number_format($row->PlanTrading,"",",","");
				
				$Link1='mmTipe=Mining&mmAcount='.$Acount.'&mmPIT='.$mPIT.'&mmPeriode='.$mmPeriode.'&mmStart='.$rowPeriodeW[Start].'&mmStop='.$rowPeriodeW[Stop].'&SDept='.$mmDept.'&mIBS='.$mIBS.'&tIBS='.$tIBS.'&SDeptAdd='.$SDeptAdd;
				$Link2='mmTipe=Trading&mmAcount='.$Acount.'&mmPIT='.$mPIT.'&mmPeriode='.$mmPeriode.'&mmStart='.$rowPeriodeW[Start].'&mmStop='.$rowPeriodeW[Stop].'&SDept='.$mmDept.'&mIBS='.$mIBS.'&tIBS='.$tIBS.'&SDeptAdd='.$SDeptAdd;
				
				echo("<div align=center>");
				if(($Next2 == 0)) {
				echo("<td bgcolor=#D6D6D6 class=style5><div align=Center>$mmDept</td>
				<td bgcolor=#D6D6D6 class=style5><div align=LEFT>$Kategori</td>
				<td bgcolor=#D6D6D6 class=style5><div align=Center>($Acount)</td>
				<td bgcolor=#D6D6D6 class=style5><div align=LEFT>$Descr</td>");
				}
				echo("<td bgcolor=#D6D6D6 class=style5><div align=Right><input name=tPNominal type=text id=tPNominal value=$PNominal readonly=true title=PlanMining></td>
				<td bgcolor=#D6D6D6 class=style5><div align=Right><input name=tPTNominal type=text id=tPTNominal value=$PTNominal readonly=true title=PlanTrading></td>
				<td bgcolor=#D6D6D6 class=style5><div align=Right><input name=tANominal type=text id=tANominal value=$ANominal readonly=true title=ClickToInsert onClick=MM_openBrWindow('Ins.php?$Link1','Insert','location=no,status=yes,scrollbars=yes,width=1000,height=300');return document.MM_returnValue></td>
				<td bgcolor=#D6D6D6 class=style5><div align=Right><input align=RIGHT name=tATNominal type=text id=tATNominal value=$ATNominal readonly=true title=ClickToInsert onClick=MM_openBrWindow('Ins.php?$Link2','Insert','location=no,status=yes,scrollbars=yes,width=1000,height=300');return document.MM_returnValue></td>");
				if($Next1 == 0) {
					echo("<tr>");
					}
				}
				echo("
					<tr>
					<td bgcolor=#D6D6D6 class=style5 colspan=4><div align=right class=style55>Compare ->></td>
					<td bgcolor=#D6D6D6 class=style5><div align=Right>");
					if ($rowProp[Nominal] > $rowIBS[IBS]) {	echo("<span class=styleRed>$TNominal</span></td>"); } 
					else { echo("<span class=styleGren>$TNominal</span></td>"); }
					echo("<td bgcolor=#D6D6D6 class=style5><div align=Right>$TIBS</td>
					<td bgcolor=#D6D6D6 class=style5><div align=Right>$TActual</td>
					<td bgcolor=#D6D6D6 class=style5><div align=Center><<-</td>
					</tr></table>");
				  ?>
                </tr>
              </table></td>
            </tr>
          </table>
        </form>
          <?php
IF ($View==1) {
echo ("
<iframe src=http://RANTAPPU401/ReportServer/Pages/ReportViewer.aspx?%2fBudgetSystem%2f_Proposal_Read&rs:Command=Render&Periode=$rowBln[Periode]&ID=$SDeptAdd&Dept=$mmDept id=kanan name=kanan width=97.5% height=480 align=Center hspace=0 vspace=5 scrollbar=yes></iframe>");
}
?></td>
      </tr>
    </table></td>
  </tr>
</table>

</body>
</html>
