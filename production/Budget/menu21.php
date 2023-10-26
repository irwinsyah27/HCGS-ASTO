<html>
<style type="text/css">
<!--
.style1 {	font-size: 16px;
	font-weight: bold;
	font-family: Georgia, "Times New Roman", Times, serif;
	color: #CCCCFF;
}
.style2 {	color: #9999FF;
	font-weight: bold;
}
.style5 {color: #FFFFFF; font-family: "DejaVu Sans"}
-->
</style>
<body>
<form name="form1" method="post" action="">
  <table width="100%" border="0">
    <tr>
      <td><p align="center" class="style1">PT.    KALIMANTAN PRIMA PERSADA</p>
          <p align="center" class="style1"><a>Production Schedulle</a><a class="style1"> Tahun;
            <input name="mThn" type="text" id="mThn" value="<? if($mThn==''){ echo DAte('Y');}else {echo $mThn ;} ?>" size="5">
          </a>Smstr;
            
            <span class="style5">
            <select name="mSmstr" id="mSmstr" lang="" onChange="this.form.submit()">
              <option value="" <?php if (!(strcmp("", $mSmstr))) {echo "selected=\"selected\"";} ?>></option>
              <option value="1" <?php if (!(strcmp(1, $mSmstr))) {echo "selected=\"selected\"";} ?>>1</option>
              <option value="2" <?php if (!(strcmp(2, $mSmstr))) {echo "selected=\"selected\"";} ?>>2</option>
            </select>
        </span></p></td>
    </tr>
    <tr>
      <td>
	  <? 
	  $TotAll = mssql_query ("SELECT SUM(Jan) as tJan, SUM(Feb) as tFeb, SUM(Mar) as tMar, SUM(Apr) as tApr, SUM(Mei) as tMei,
								     SUM(Jun) as tJun, SUM(Jul) as tJul, SUM(Agu) as tAgu, SUM(Sep) as tSep, SUM(Okt) as tokt,
								     SUM(Nov) as tNov, SUM(Des) as tDes FROM ProdSchedulle where Thn='$mThn'");
	  $dTotAll=mssql_fetch_array($TotAll);
	  
	  if ($mSmstr=='1') { 
	$sel1=mssql_query("Select Lokasi from ProdSchedulle where Thn='$mThn' Group By Lokasi order by Lokasi DESC") or die ("Terdapat kesalahan SQL!");	  
	echo ("<table width=100% border=0 align=center bgcolor=#CCCCFF>
		  <tr>	<td width=20% bgcolor=#FFFF99><div align=center class=style2><a href=# class=style2>Lokasi</a></div></td>
			<td width=13% bgcolor=#FFFF99><div align=center class=style2><a href=# class=style2>Desc</a></div></td>
			<td width=5% bgcolor=#FFFF99><div align=center class=style2><a href=# class=style2>Unit</a></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Jan</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Feb</a> </strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Mar</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Apr</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Mei</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Jun</a></strong></div></td>");    
	while ($row = mssql_fetch_object($sel1))
	  {
	  $Lokasi=$row->Lokasi;
	  		  
		  $sel2=mssql_query("Select DATEPART(YEAR,Thn) AS Thn, Lokasi, Descr, Unit, Jan, Feb, Mar, Apr, Mei, Jun
		  from ProdSchedulle where Thn='$mThn' and Lokasi='$Lokasi'") or die ("Terdapat kesalahan pada perintah SQL!");	  
		  
		   echo("<table width=100% border=0 align=center bgcolor=#CCCCFF>
			 <td width=20% align=center rowspan=20 bgcolor=#FFFFCC>$Lokasi</td>");
		  
		  while ($row = mssql_fetch_object($sel2))
		  {
			// ----- mengambil isi setiap kolom
			$Thn=$row->Thn;
			$Lokasi=$row->Lokasi;
			$Descr=$row->Descr;
			$Unit=$row->Unit;
			$Jan=$row->Jan;
			$jJan=$row->jJan;
			$Feb=$row->Feb;
			$Mar=$row->Mar;
			$Apr=$row->Apr;
			$Mei=$row->Mei;
			$Jun=$row->Jun;
			
		  echo ("
		  <tr>
			<td width=13% bgcolor=#FFFFCC>$Descr</td>
			<td width=5% bgcolor=#FFFFCC>$Unit</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Jan</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Feb</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Mar</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Apr</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Mei</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Jun</td>
			</tr>
			");
			}
			$TotAll = mssql_query ("Select (SELECT SUM(Jan) FROM ProdSchedulle where Thn='$mThn' and Lokasi='$Lokasi')as jJan,
										   (SELECT SUM(Feb) FROM ProdSchedulle where Thn='$mThn' and Lokasi='$Lokasi')as jFeb,
										   (SELECT SUM(Mar) FROM ProdSchedulle where Thn='$mThn' and Lokasi='$Lokasi')as jMar,
										   (SELECT SUM(Apr) FROM ProdSchedulle where Thn='$mThn' and Lokasi='$Lokasi')as jApr,
										   (SELECT SUM(Mei) FROM ProdSchedulle where Thn='$mThn' and Lokasi='$Lokasi')as jMei,
										   (SELECT SUM(Jun) FROM ProdSchedulle where Thn='$mThn' and Lokasi='$Lokasi')as jJun");
			$dTot=mssql_fetch_array($TotAll);
			echo ("<tr><td align=center bgcolor=#FFFFCC colspan=2>Total :</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jJan]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jFeb]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jMar]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jApr]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jMei]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jJun]</td></tr>");
			}
			echo ("</table>
				   <table width=100% border=0 align=center bgcolor=#CCCCFF><tr>
				   <td width=46% align=center bgcolor=#FFFFCC colspan=3>Grand Total :</td>
				   <td width=9% align=right bgcolor=#FFFFCC>$dTotAll[tJan]</td>
				   <td width=9% align=right bgcolor=#FFFFCC>$dTotAll[tFeb]</td>
				   <td width=9% align=right bgcolor=#FFFFCC>$dTotAll[tMar]</td>
				   <td width=9% align=right bgcolor=#FFFFCC>$dTotAll[tApr]</td>
				   <td width=9% align=right bgcolor=#FFFFCC>$dTotAll[tMei]</td>
				   <td width=9% align=right bgcolor=#FFFFCC>$dTotAll[tJun]</td>
				</tr>");
		}
		
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	
	
		 if ($mSmstr=='2') { 
	$sel1=mssql_query("Select Lokasi from ProdSchedulle where Thn='$mThn' Group By Lokasi order by Lokasi DESC") or die ("Terdapat kesalahan SQL!");	  
	echo ("<table width=100% border=0 align=center bgcolor=#CCCCFF>
		  <tr>	<td width=20% bgcolor=#FFFF99><div align=center class=style2><a href=# class=style2>Lokasi</a></div></td>
			<td width=13% bgcolor=#FFFF99><div align=center class=style2><a href=# class=style2>Desc</a></div></td>
			<td width=5% bgcolor=#FFFF99><div align=center class=style2><a href=# class=style2>Unit</a></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Jul</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Agu</a> </strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Sep</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Okt</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Nov</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Des</a></strong></div></td>");    
	while ($row = mssql_fetch_object($sel1))
	  {
	  $Lokasi=$row->Lokasi;
	  		  
		  $sel2=mssql_query("Select DATEPART(YEAR,Thn) AS Thn, Lokasi, Descr, Unit, Jul, Agu, Sep, Okt, Nov, Des
		  from ProdSchedulle where Thn='$mThn' and Lokasi='$Lokasi'") or die ("Terdapat kesalahan pada perintah SQL!");	  
		  
		   echo("<table width=100% border=0 align=center bgcolor=#CCCCFF>
			 <td width=20% align=center rowspan=20 bgcolor=#FFFFCC>$Lokasi</td>");
		  
		  while ($row = mssql_fetch_object($sel2))
		  {
			// ----- mengambil isi setiap kolom
			$Thn=$row->Thn;
			$Lokasi=$row->Lokasi;
			$Descr=$row->Descr;
			$Unit=$row->Unit;
			$Jul=$row->Jul;
			$jJul=$row->jJul;
			$Agu=$row->Agu;
			$Sep=$row->Sep;
			$Okt=$row->Okt;
			$Nov=$row->Nov;
			$Des=$row->Des;
			
		  echo ("
		  <tr>
			<td width=13% bgcolor=#FFFFCC>$Descr</td>
			<td width=5% bgcolor=#FFFFCC>$Unit</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Jul</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Agu</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Sep</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Okt</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Nov</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Des</td>
			</tr>
			");
			}
			$TotLok = mssql_query ("Select (SELECT SUM(Jul) FROM ProdSchedulle where Thn='$mThn' and Lokasi='$Lokasi')as jJul,
										   (SELECT SUM(Agu) FROM ProdSchedulle where Thn='$mThn' and Lokasi='$Lokasi')as jAgu,
										   (SELECT SUM(Sep) FROM ProdSchedulle where Thn='$mThn' and Lokasi='$Lokasi')as jSep,
										   (SELECT SUM(Okt) FROM ProdSchedulle where Thn='$mThn' and Lokasi='$Lokasi')as jOkt,
										   (SELECT SUM(Nov) FROM ProdSchedulle where Thn='$mThn' and Lokasi='$Lokasi')as jNov,
										   (SELECT SUM(Des) FROM ProdSchedulle where Thn='$mThn' and Lokasi='$Lokasi')as jDes");
			$dTot=mssql_fetch_array($TotLok);
			echo ("<tr><td align=center bgcolor=#FFFFCC colspan=2>Total :</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jJul]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jAgu]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jSep]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jOkt]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jNov]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jDes]</td></tr>");
			}
			echo ("</table>
				   <table width=100% border=0 align=center bgcolor=#CCCCFF><tr>
				   <td width=44% align=center bgcolor=#FFFFCC colspan=3>Grand Total :</td>
				   <td width=9% align=right bgcolor=#FFFFCC>$dTotAll[tJul]</td>
				   <td width=9% align=right bgcolor=#FFFFCC>$dTotAll[tAgu]</td>
				   <td width=9% align=right bgcolor=#FFFFCC>$dTotAll[tSep]</td>
				   <td width=9% align=right bgcolor=#FFFFCC>$dTotAll[tOkt]</td>
				   <td width=9% align=right bgcolor=#FFFFCC>$dTotAll[tNov]</td>
				   <td width=9% align=right bgcolor=#FFFFCC>$dTotAll[tDes]</td>
				</tr>");
		}
	?></td>
    </tr>
  </table>
</form>

</body>
</html>