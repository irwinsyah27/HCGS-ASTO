<?
session_start();
//require("cek.php");
// ----- ambil isi dari file koneksi.php
require("../tools/koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();

$mmSDept = $_SESSION[Dept];

$mmDept = $SDept;

if ($mmPIT == 'PIT-BRE') {
$mmSPIT = '201';
} else if ($mmPIT == 'PIT-GPM') {
$mmSPIT = '226';
} else if ($mmPIT == 'PIT-EBL') {
$mmSPIT = '232';
} else {
$mmSPIT = 'parai';
}

 $q1 = mssql_query("SELECT [Dept]
      ,[Kategori]
      ,[Acount]
      ,[Descr]
      ,[List]
      ,[ID]
	  ,CASE when [List] = 'No List' then 0 else 1 end AS Urut 
  FROM [BudgetSystem].[dbo].[v_Proposal] where Acount = '$mmAcount' AND Dept = '$mmDept'
  ORDER BY Urut");
  
//$row1 = mssql_fetch_array($q1);
?>
 <?php
if($bDel=='Delete') {
$delete="DELETE Proposal WHERE ID='$hID'";
$hasil =@mssql_query ($delete) or die ("Terdapat Kesalahan Delete");
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data TerHapus.!!'); </SCRIPT> </BODY>");
}
if($bUpdate=='Update') {
$update="UPDATE Proposal SET Nominal='$eNominal', TNominal='$eTNominal' WHERE ID='$hID'";
$hasil =@mssql_query ($update) or die ("Terdapat Kesalahan Update");
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data TerUpdate.!!'); </SCRIPT> </BODY>");
}
if($bSave=='Save') {
$selRef=mssql_query("
SELECT     CAST(DATEPART(YEAR, Start) AS VARCHAR) + '-' + CASE WHEN len(CAST(DATEPART(MONTH, Start) AS VARCHAR)) = 1 THEN '0' + CAST(DATEPART(MONTH, Start) 
                      AS VARCHAR) ELSE CAST(DATEPART(MONTH, Start) AS VARCHAR) END + '-' + CASE WHEN len(CAST(DATEPART(DAY, Start) AS VARCHAR)) 
                      = 1 THEN '0' + CAST(DATEPART(DAY, Start) AS VARCHAR) ELSE CAST(DATEPART(DAY, Start) AS VARCHAR) END AS Start, CAST(DATEPART(YEAR, Stop) AS VARCHAR) 
                      + '-' + CASE WHEN len(CAST(DATEPART(MONTH, Stop) AS VARCHAR)) = 1 THEN '0' + CAST(DATEPART(MONTH, Stop) AS VARCHAR) ELSE CAST(DATEPART(MONTH, 
                      Stop) AS VARCHAR) END + '-' + CASE WHEN len(CAST(DATEPART(DAY, Stop) AS VARCHAR)) = 1 THEN '0' + CAST(DATEPART(DAY, Stop) AS VARCHAR) 
                      ELSE CAST(DATEPART(DAY, Stop) AS VARCHAR) END AS Stop, CAST(DATEPART(YEAR, Periode) AS VARCHAR) + '-' + CASE WHEN len(CAST(DATEPART(MONTH, 
                      Periode) AS VARCHAR)) = 1 THEN '0' + CAST(DATEPART(MONTH, Periode) AS VARCHAR) ELSE CAST(DATEPART(MONTH, Periode) AS VARCHAR) 
                      END + '-' + CASE WHEN len(CAST(DATEPART(DAY, Periode) AS VARCHAR)) = 1 THEN '0' + CAST(DATEPART(DAY, Periode) AS VARCHAR) ELSE CAST(DATEPART(DAY, 
                      Periode) AS VARCHAR) END AS Periode,(SELECT Acount FROM dbo.v_COA_L4 WHERE (Descr = '$mmDept')) AS NoDept
FROM         dbo.ref_Proposal Where Start = '".$mmStart."' AND Stop ='".$mmStop."'");
$rowRef = mssql_fetch_array($selRef);
$Peri=$rowRef[Periode];
$insert="INSERT INTO Proposal (Periode,Start,Stop,PIT,Dept,DeptAdd,Acount,List,Nominal,TNominal) VALUES('$Peri','$mmStart','$mmStop','$mmSPIT','$rowRef[NoDept]',$SDeptAdd,'$mmAcount',$mmLi,'$mNominal','$mTNominal')";
$hasil =@mssql_query ($insert) or die ("Terdapat Kesalahan Insert");
echo ("<BODY> <SCRIPT language='Javascript'> alert('Data Tersimpan.!!'); </SCRIPT> </BODY>");
}
?>

<title>ListProposal</title>
<style type="text/css">
<!--
.style2 {color: #FFFFFF}
.styleProp {color: #FF0000}
.styleIBS {color: #009933}
-->
</style>
<table width="100%" border="0" bgcolor="#FF0000">
  <tr>
    <td bgcolor="#FFFFFF"><div align="center">
	<?
	echo $SDept.' - '.$mmPIT;
	?></div></td>
  </tr>
  <tr>
    <td bgcolor="#FFFFFF"><form action="" method="post" name="FormIn" target="_self" id="FormIn">
      <?php if(!$bNew==''){ echo ("
<table width=456 border=0 bgcolor=#99CCFF>
  <tr>
    <td width=52>List :</td>
    <td width=350>
	<select name=mmLi id=mmLi>");
							 // echo "<option value= '$row1[ID]' "; if ($row1[ID]==$mmLi){echo"selected=selected";} echo">$row1[List]
							 // </option>";
							  while ($row1 = mssql_fetch_array($q1)){
							  echo "<option value= '$row1[ID]' "; if ($row1[ID]==$mmLi){echo"selected=selected";} echo">$row1[List]
							  </option>"; 							  
							  }
							  echo("</select>
          </td>
    <td width=100>Mining:</td>
    <td width=166>
    <input name=mNominal type=text size=20></td>
	<td width=100>Trading:</td>
    <td width=166>
    <input name=mTNominal type=text size=20></td>
  </tr>
  <tr>
    <td></td>
	<td></td>
	<td></td>
    <td></td>
	<td></td>
	<td></td>
    <td><div align=right><input name=bSave type=submit id=bSave value=Save></td>
  </tr>
</table>
");} 
else if(!$bEdit==''){
$Sel1 = mssql_query ("SELECT [IDProp]
      ,[Periode]
      ,[Start]
      ,[Stop]
      ,[TotalHari]
      ,[PIT]
      ,[Dept]
      ,[DeptAdd]
      ,[Kategori]
      ,[Acount]
      ,[Descr]
      ,[List]
      ,[Nominal]
      ,[TNominal]
      ,[Urut]
      ,[StatusClosing]
  FROM [BudgetSystem].[dbo].[v_Proposal_List]
					  Where IDProp = '$bEdit'") or die ("Terdapat kesalahan Update!");
$dUp=mssql_fetch_array($Sel1);
echo ("<table width=456 border=0 bgcolor=#99CCFF>
  <tr>
    <td width=52>List :</td>
    <td width=550>
	<select name=mmLi>
  	<option value=$dUp[List]>$dUp[List]</option>
	</select>
          </td>
    <td width=100>Mining:</td>
    <td width=166>
    <input name=eNominal value =$dUp[Nominal] type=text size=20></td>
    <td width=100>Trading:</td>
    <td width=166>
    <input name=eTNominal value =$dUp[TNominal] type=text size=20></td>
  </tr>
  <tr>
    <td></td>
	<td></td>
	<td></td>
	<td></td>
	<td></td>
	<td><div align=right><input name=bDel type=submit id=bDel value=Delete></td>
    <td><div align=right><input name=bUpdate type=submit id=bUpdate value=Update></td>
  </tr>
</table>
");
} ?>
      <?

  $q2 = mssql_query("SELECT [IDProp]
      ,[Periode]
      ,[Start]
      ,[Stop]
      ,[TotalHari]
      ,[NoPIT]
      ,[PIT]
      ,[Dept]
      ,[DeptAdd]
      ,[Kategori]
      ,[Acount]
      ,[Descr]
      ,[List]
      ,[Nominal]
      ,[TNominal]
      ,[Urut]
      ,[StatusClosing]
  FROM [BudgetSystem].[dbo].[v_Proposal_List]
	Where Periode = '$mmPeriode' AND NoPIT = '$mmSPIT' AND Dept = '$mmDept' and Acount = '$mmAcount' AND (DeptAdd = 'All' OR DeptAdd = 'GA')");
	
echo("<table width=100%  border=0 bgcolor=#99CCFF>");
							  
							  echo("
                              <td bgcolor=#336699><div align=center><span class=style2>List</span></td>
                              <td bgcolor=#336699><div align=center><span class=style2>Mining</span></td>
                              <td bgcolor=#336699><div align=center><span class=style2>Trading</span></td>
                              <td bgcolor=#336699><div align=center><span class=style2>@</span></td>");
// ------ ambil isi masing-masing record
while ($row = mssql_fetch_object($q2))
{
		// ----- mengambil isi setiap kolom
		
		$ID=$row->IDProp;
		$Dept=$row->Dept;
		//$Date=SubStr($row->Date,0,11);
		$Kategori=$row->Kategori;
		$Acount=$row->Acount;
		$Descr=$row->Descr;
		$List=$row->List;
		if($row->Kategori!='Production') {
		$Nominal= 'Rp. '.number_format($row->Nominal,0,",",".").',-';
		$TNominal= 'Rp. '.number_format($row->TNominal,0,",",".").',-'; }
		else {
		$Nominal= number_format($row->Nominal,0,",",".");
		$TNominal= number_format($row->TNominal,0,",",".");
		}
		$Status=$row->Status;
		$aNominal=$aNominal+$row->Nominal;
		$aTNominal=$aTNominal+$row->TNominal;

		// ------ menampilkan di layar browser
		echo("<tr><div align=center>
			<td bgcolor=#CFFFFF class=style5><div align=Center>$List</td>
			<td bgcolor=#CFFFFF class=style5><div align=Right>$Nominal</td>
			<td bgcolor=#CFFFFF class=style5><div align=Right>$TNominal</td>");
			echo("<td bgcolor=#CFFFFF class=style5><div align=Center><input type=submit name=bEdit value=Edit onClick='value=$ID'>
			</td>
			</tr>");
}
		if($Kategori!='Production') {
		$aNominal='Rp. '.number_format($aNominal,0,",",".").',-';
		$aTNominal='Rp. '.number_format($aTNominal,0,",",".").',-';
		$mSIBS='Rp. '.number_format($mIBS,0,",",".").',-';
		$tSIBS='Rp. '.number_format($tIBS,0,",",".").',-';
		} else
		{
		$aNominal=number_format($aNominal,0,",",".");
		$aTNominal=number_format($aTNominal,0,",",".");
		$mSIBS=number_format($mIBS,0,",",".");
		$tSIBS=number_format($tIBS,0,",",".");		
		}
echo("
<tr>
	<td bgcolor=#CFFFFF class=style5><div align=Center ><b>Proposal All Items :</td>
	<td bgcolor=#CFFFFF class=style5><div align=Right ><b "); if (is_float($mIBS)>=($aNominal)) {echo 'class=styleProp';} echo(">$aNominal</td>
	<td bgcolor=#CFFFFF class=style5><div align=Right ><b "); if (is_float($tIBS)>=($aTNominal)) {echo 'class=styleProp';} echo(">$aTNominal</td>
    <td bgcolor=#CFFFFF class=style5 colspan=4><div align=Center class=style55></td>
	<tr>
	<td bgcolor=#CFFFFF class=style5><div align=Center ><b class=styleIBS>IBS All Items :</td>
	<td bgcolor=#CFFFFF class=style5><div align=Right ><b class=styleIBS>$mSIBS</td>
	<td bgcolor=#CFFFFF class=style5><div align=Right ><b class=styleIBS>$tSIBS</td>
    <td bgcolor=#CFFFFF class=style5 colspan=4><div align=Center class=style55><input type=submit name=bNew value=New></td>");
    echo("</tr>
</table>");
?>
      <?
	  
$qIBS= mssql_query("SELECT *, PlanMining-(ActualMining+2000) AS OverMining, PlanTrading-(ActualTrading+2000) AS OverTrading, CASE WHEN PlanMining-(ActualMining+2000)>=0 THEN 'OK' ELSE 'OVER' END AS OM, CASE WHEN PlanTrading-(ActualTrading+2000)>=0 THEN 'OK' ELSE 'OVER' END AS OT 
FROM (
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
GROUP BY dbo.v_PLO.Periode, dbo.v_PLO.Kategori, dbo.v_PLO.Acount, dbo.v_PLO.Descr, dbo.v_PLO.Urut) AS IBS Where PIT = '$mmPIT' AND Acount = '$mmAcount'");
$rIBS = mssql_fetch_array($qIBS);
  

	  
mssql_close($koneksi);
echo is_float($mIBS);
?>
      <input name="hTipe" type="hidden" id="hTipe" value="<?php echo $mmTipe; ?>" />
      <input name="hPIT" type="hidden" id="hPIT" value="<?php echo $mmPIT; ?>" />
      <input name="hAcount" type="hidden" id="hAcount" value="<?php echo $mmAcount; ?>" />
      <input name="hPeriode" type="hidden" id="hPeriode" value="<?php echo $mmPeriode; ?>" />
      <input name="hID" type="hidden" id="hID" value="<?php echo $bEdit; ?>" />
    </form></td>
  </tr>
</table>
