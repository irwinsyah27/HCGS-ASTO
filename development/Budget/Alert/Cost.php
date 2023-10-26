<?php
session_start();
//require("cek.php");
// ----- ambil isi dari file koneksi.php
require("../tools/koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Untitled Document</title>
<style type="text/css">
<!--
.sRed {
	color: #FF0000;
}
-->
</style>
</head>

<body>
<?php
// ------ buat tampilan tabel
$Dt = Date('m/Y');
$q1 = mssql_query("SELECT     [Periode]
      ,[Tahun]
      ,[NoBulan]
      ,[Bulan]
      ,[PIT]
      ,[Kategori]
      ,[Acount]
      ,[Descr]
      ,[Actual]
      ,[Plan]
      ,[Prop]
      ,[%Actual]*100 AS [ID_Actual]
      ,[%Plan]*100 AS [ID_Plan]
      ,[%Prop]*100 AS [ID_Prop]
      ,[%PlanDeviasi]*100 AS [ID_PlanDeviasi]
      ,[%PropDeviasi]*100 AS [ID_PropDeviasi] 
      ,[Urut]
FROM       _ActualPeriode_HighLight_All_Group  
WHERE     (Site = '$Site') AND (Kategori <> 'Revenue') AND (Kategori <> 'Production') AND 
                      (Kategori <> 'Cost Of Port Facility') AND (Periode = CONVERT(varchar,'$Per')) AND Kategori LIKE '%$Kt%'");
					  
$q2 = mssql_query("SELECT     
      SUM([Actual]) AS Actual
      ,SUM([Plan]) AS [Plan]
      ,SUM([Prop]) AS Prop
FROM       _ActualPeriode_HighLight_All_Group  
WHERE     (Kategori <> 'Revenue') AND (Kategori <> 'Production') AND 
                      (Kategori <> 'Cost Of Port Facility') AND (Periode = CONVERT(varchar,'$Per')) AND Kategori LIKE '%$Kt%'");
$sSUM = mssql_fetch_array($q2);
?>
<table border="1" cellspacing="0" cellpadding="0" width="1274">
  <colgroup>
  <col span="2" width="64" />
  <col width="190" />
  <col width="124" />
  <col width="105" />
  <col width="73" />
  <col width="105" />
  <col width="73" />
  <col width="48" />
  <col width="214" />
  <col width="172" />
  <col width="106" />
  </colgroup>
  <tbody>
    <tr height="17">
      <td height="17" colspan="11"><strong>Review Budget Cost <? echo $Kt." "; echo Date('M'); echo " "; echo Date('Y') ?></strong></td>
    </tr>
    <tr height="19">
      <td width="64" rowspan="2"><div align="center"><strong>Account</strong></div></td>
      <td width="190" rowspan="2"><div align="center"><strong>Item   Cost</strong></div></td>
      <td width="124" rowspan="2"><div align="center"><strong>Proposal</strong></div></td>
      <td height="19" colspan="2"><div align="center"><strong>IBS</strong></div></td>
      <td colspan="2"><div align="center">Actual</div></td>
      <td width="48" rowspan="2"><div align="center"><strong>Over</strong></div></td>
      <td colspan="2"><div align="center"><strong>PICA</strong></div></td>
      <td width="106" rowspan="2"><div align="center"><strong>Dept</strong></div></td>
    </tr>
    <tr height="17">
      <td width="105" height="17"><div align="center"><strong>Nominal</strong></div></td>
      <td width="73"><div align="center"><strong>Persentase</strong></div></td>
      <td width="105"><div align="center"><strong>Nominal</strong></div></td>
      <td width="73"><div align="center"><strong>Persentase</strong></div></td>
      <td width="214"><div align="center"><strong>Problem identiication</strong></div></td>
      <td width="172"><div align="center"><strong>Corective action</strong></div></td>
	  <?php
	  while ($row = mssql_fetch_object($q1))
{
		// ----- mengambil isi setiap kolom
		
		$Acount=$row->Acount;
		$Descr=$row->Descr;
		$Prop='Rp.'.number_format($row->Prop,0,",",".");
		$Plan='Rp.'.number_format($row->Plan,0,",",".");
		$Actual='Rp.'.number_format($row->Actual,0,",",".");
		$ID_Prop=number_format($row->ID_Prop,2,",",".").' %';
		$ID_Plan=number_format($row->ID_Plan,2,",",".").' %';
		$ID_Actual=number_format($row->ID_Actual,2,",",".").' %';
	    $ID_PlanDeviasi=number_format($row->ID_PlanDeviasi,2,",",".").' %';
		
		$q3 = mssql_query("SELECT DISTINCT dbo.ref_Acounts.Acount, dbo.v_COA_L4.Descr AS Dept
						   FROM         dbo.ref_Acounts INNER JOIN
                      	   dbo.v_COA_L4 ON dbo.ref_Acounts.Dept = dbo.v_COA_L4.Acount Where dbo.ref_Acounts.Acount='$Acount'");
		
echo ("</tr>
    <tr height=17>
      <td height=17>$Acount</td>
      <td>$Descr</td>
      <td align=right>$Prop</td>
      <td align=right>$Plan</td>
      <td align=center>$ID_Plan</td>
      <td align=right>$Actual</td>
      <td align=center>$ID_Actual</td>
      <td class=sRed align=center><a href=#>");
	  IF (SUBSTR($ID_PlanDeviasi,0,1)=='-') {echo ("$ID_PlanDeviasi</a></td>
      <td><textarea name=Prob></textarea></td>
      <td><textarea name=Core></textarea></td>");
	  echo ("<td align=center>");
	  while ($row2 = mssql_fetch_object($q3)){
	  echo $row2->Dept."-";
	  }
	  echo("</td>");} Else {
	  echo("</a></td>
      <td></td>
      <td></td><td></td>");}
	  echo("
    </tr>");
	}
?>
    <tr height="26">
      <td height="26" colspan="2"><div align="center"><strong>Total</strong></div></td>
      <td align="right"><? echo 'Rp.'.number_format($sSUM[Prop],0,",","."); ?> </td>
      <td align="right"><? echo 'Rp.'.number_format($sSUM[Plan],0,",","."); ?> </td>
      <td>&nbsp;</td>
      <td align="right"><? echo 'Rp.'.number_format($sSUM[Actual],0,",","."); ?> </td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td></td>
    </tr>
  </tbody>
</table>
</body>
</html>
