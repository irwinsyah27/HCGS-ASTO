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
          <p align="center" class="style1"><a>Investment</a><a class="style1"> Tahun;
              <input name="mThn" type="text" id="mThn" value="<? if($mThn==''){ echo DAte('Y');}else {echo $mThn ;} ?>" size="5">
          </a>Smstr;
            
            <span class="style5">
            <select name="mSmstr" id="mSmstr" lang="" onChange="this.form.submit()">
              <option value="" <?php if (!(strcmp("", $mSmstr))) {echo "selected=\"selected\"";} ?>></option>
              <option value="1" <?php if (!(strcmp(1, $mSmstr))) {echo "selected=\"selected\"";} ?>>1</option>
              <option value="2" <?php if (!(strcmp(2, $mSmstr))) {echo "selected=\"selected\"";} ?>>2</option>
            </select>
            </span>Kategori;
		
		<span class="style5">
		<select name="mKategori" id="mKategori" lang="" onChange="this.form.submit()">
		  <option value="" <?php if (!(strcmp("", $mKategori))) {echo "selected=\"selected\"";} ?>></option>
          <option value="All" <?php if (!(strcmp(All, $mKategori))) {echo "selected=\"selected\"";} ?>>All</option>
          <option value="Summary" <?php if (!(strcmp(Summary, $mKategori))) {echo "selected=\"selected\"";} ?>>Summary</option>
        </select>
		</span></p></td>
    </tr>
    <tr>
      <td>
	  <? 
	  if (($mSmstr=='1') and ($mKategori=='All')) { 
	$sel1=mssql_query("Select Kategori from Investment where Thn='$mThn' Group By Kategori order by Kategori DESC") or die ("Terdapat kesalahan SQL!");	  
	echo ("<table width=100% border=0 align=center bgcolor=#CCCCFF>
		  <tr>	<td width=15% bgcolor=#FFFF99><div align=center class=style2><a href=# class=style2>Kategori</a></div></td>
			<td width=13% bgcolor=#FFFF99><div align=center class=style2><a href=# class=style2>Type</a></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><a href=# class=style2>EGI_Model</a></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Price/Unit</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Jan</a> </strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Feb</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Mar</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Apr</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Mei</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Jun</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Total</a></strong></div></td>");    
	while ($row = mssql_fetch_object($sel1))
	  {
	  $Kategori=$row->Kategori;
	  		  
		  $sel2=mssql_query("Select DATEPART(YEAR,Thn) AS Thn, Kategori, Type, Price, EGIModel, Jan, Feb, Mar, Apr, Mei, Jun
		  from Investment where Thn='$mThn' and Kategori='$Kategori'") or die ("Terdapat kesalahan pada perintah SQL!");	  
		  
		   echo("<table width=100% border=0 align=center bgcolor=#CCCCFF>
			 <td width=15% align=center rowspan=30 bgcolor=#FFFFCC>$Kategori</td>");
		  
		  while ($row = mssql_fetch_object($sel2))
		  {
			// ----- mengambil isi setiap kolom
			$Thn=$row->Thn;
			$Kategori=$row->Kategori;
			$Type=$row->Type;
			$Price=$row->Price;
			$EGIModel=$row->EGIModel;
			$Jan=$row->Jan;
			$Feb=$row->Feb;
			$Mar=$row->Mar;
			$Apr=$row->Apr;
			$Mei=$row->Mei;
			$Jun=$row->Jun;
			$lsTot = mssql_query ("Select  (Jan + Feb + Mar + Apr + Mei + Jun) as Total FROM Investment where Thn='$Thn' and
									Kategori='$Kategori' and Type='$Type' and EGIModel='$EGIModel'");
			$sTot=mssql_fetch_array($lsTot);
			
		  echo ("
		  <tr>
			<td width=13% bgcolor=#FFFFCC>$Type</td>
			<td width=8% bgcolor=#FFFFCC>$EGIModel</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Price</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Jan</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Feb</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Mar</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Apr</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Mei</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Jun</td>
			<td width=8% align=right bgcolor=#FFFFCC>$sTot[Total]</td>
			</tr>
			");
			}
			$TotLok = mssql_query ("Select (SELECT SUM(Jan + Feb + Mar + Apr + Mei + Jun) FROM Investment where Thn='$mThn' and 
										    Kategori='$Kategori')as sTotal,
										   (SELECT SUM(Jan) FROM Investment where Thn='$mThn' and Kategori='$Kategori')as jJan,
										   (SELECT SUM(Feb) FROM Investment where Thn='$mThn' and Kategori='$Kategori')as jFeb,
										   (SELECT SUM(Mar) FROM Investment where Thn='$mThn' and Kategori='$Kategori')as jMar,
										   (SELECT SUM(Apr) FROM Investment where Thn='$mThn' and Kategori='$Kategori')as jApr,
										   (SELECT SUM(Mei) FROM Investment where Thn='$mThn' and Kategori='$Kategori')as jMei,
										   (SELECT SUM(Jun) FROM Investment where Thn='$mThn' and Kategori='$Kategori')as jJun");
			$dTot=mssql_fetch_array($TotLok);
			echo ("<tr><td align=center bgcolor=#FFFFCC colspan=3>Total :</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jJan]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jFeb]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jMar]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jApr]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jMei]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jJun]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[sTotal]</td></tr>");
			}
		}
		
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	
	
		 if (($mSmstr=='2') and ($mKategori=='All')) { 
	$sel1=mssql_query("Select Kategori from Investment where Thn='$mThn' Group By Kategori order by Kategori DESC") or die ("Terdapat kesalahan SQL!");	  
	echo ("<table width=100% border=0 align=center bgcolor=#CCCCFF>
		  <tr>	<td width=15% bgcolor=#FFFF99><div align=center class=style2><a href=# class=style2>Kategori</a></div></td>
			<td width=13% bgcolor=#FFFF99><div align=center class=style2><a href=# class=style2>Type</a></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><a href=# class=style2>EGI_Model</a></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Price/Unit</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Jul</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Agu</a> </strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Sep</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Okt</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Nov</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Des</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Total</a></strong></div></td>");    
	while ($row = mssql_fetch_object($sel1))
	  {
	  $Kategori=$row->Kategori;
	  		  
		  $sel2=mssql_query("Select DATEPART(YEAR,Thn) AS Thn, Kategori, Type, Price, EGIModel, Jul, Agu, Sep, Okt, Nov, Des
		   from Investment where Thn='$mThn' and Kategori='$Kategori'") or die ("Terdapat kesalahan pada perintah SQL!");	  
		  
		   echo("<table width=100% border=0 align=center bgcolor=#CCCCFF>
			 <td width=15% align=center rowspan=30 bgcolor=#FFFFCC>$Kategori</td>");
		  
		  while ($row = mssql_fetch_object($sel2))
		  {
			// ----- mengambil isi setiap kolom
			$Thn=$row->Thn;
			$Kategori=$row->Kategori;
			$Type=$row->Type;
			$Price=$row->Price;
			$EGIModel=$row->EGIModel;
			$Jul=$row->Jul;
			$Agu=$row->Agu;
			$Sep=$row->Sep;
			$Okt=$row->Okt;
			$Nov=$row->Nov;
			$Des=$row->Des;
			$lsTot = mssql_query ("Select  (Jul + Agu + Sep + Okt + Nov + [Des]) as Total FROM Investment where Thn='$Thn' and
									Kategori='$Kategori' and Type='$Type' and EGIModel='$EGIModel'");
			$sTot=mssql_fetch_array($lsTot);
			
		  echo ("
		  <tr>
			<td width=13% bgcolor=#FFFFCC>$Type</td>
			<td width=8% bgcolor=#FFFFCC>$EGIModel</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Price</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Jul</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Agu</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Sep</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Okt</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Nov</td>
			<td width=8% align=right bgcolor=#FFFFCC>$Des</td>
			<td width=8% align=right bgcolor=#FFFFCC>$sTot[Total]</td>
			</tr>
			");
			}
			$TotLok = mssql_query ("Select (SELECT SUM(Jul + Agu + Sep + Okt + Nov + [Des]) FROM Investment where Thn='$mThn' and 
										    Kategori='$Kategori')as sTotal,
										   (SELECT SUM(Jul) FROM Investment where Thn='$mThn' and Kategori='$Kategori')as jJul,
										   (SELECT SUM(Agu) FROM Investment where Thn='$mThn' and Kategori='$Kategori')as jAgu,
										   (SELECT SUM(Sep) FROM Investment where Thn='$mThn' and Kategori='$Kategori')as jSep,
										   (SELECT SUM(Okt) FROM Investment where Thn='$mThn' and Kategori='$Kategori')as jOkt,
										   (SELECT SUM(Nov) FROM Investment where Thn='$mThn' and Kategori='$Kategorii')as jNov,
										   (SELECT SUM(Des) FROM Investment where Thn='$mThn' and Kategori='$Kategori')as jDes");
			$dTot=mssql_fetch_array($TotLok);
			echo ("<tr><td align=center bgcolor=#FFFFCC colspan=3>Total :</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jJul]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jAgu]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jSep]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jOkt]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jNov]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[jDes]</td>
				   <td align=right bgcolor=#FFFFCC>$dTot[sTotal]</td></tr>");
			}
		}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	
	
		 if (($mSmstr=='2') and ($mKategori=='Summary')) { 
	$sel1=mssql_query("SELECT Kategori, SUM(Jul) as Jul, SUM(Agu) as Agu, SUM(Sep) as Sep, SUM(Okt) as Okt, SUM(Nov) as Nov, SUM(Des) as Des, SUM(Jul + Agu + Sep + Okt + Nov + [Des]) as Total FROM Investment where Thn='$mThn' group by Kategori order by Kategori DESC") or die ("Terdapat kesalahan SQL!");	  
	echo ("<table width=100% border=0 align=center bgcolor=#CCCCFF>
		<tr><td width=28% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Kategori</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Jul</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Agu</a> </strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Sep</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Okt</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Nov</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Des</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Total</a></strong></div></td></tr>");    
	while ($row = mssql_fetch_object($sel1))
	  {
	  // ----- mengambil isi setiap kolom
			$Kategori=$row->Kategori;
			$Jul=$row->Jul;
			$Agu=$row->Agu;
			$Sep=$row->Sep;
			$Okt=$row->Okt;
			$Nov=$row->Nov;
			$Des=$row->Des;
			$Total=$row->Total;
			echo ("<tr><td width=28% align=Center bgcolor=#FFFFCC>$Kategori</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$Jul</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$Agu</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$Sep</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$Okt</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$Nov</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$Des</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$Total</td></tr>");
			}
			$gTot=mssql_query("SELECT SUM(Jul) as Jul, SUM(Agu) as Agu, SUM(Sep) as Sep, SUM(Okt) as Okt, SUM(Nov) as Nov, SUM(Des) as
							   Des, SUM(Jul + Agu + Sep + Okt + Nov + [Des]) as GTotal FROM Investment where Thn='$mThn'");
			$gnTotal=mssql_fetch_array($gTot);
			echo ("<tr><td width=28% align=Center bgcolor=#FFFFCC>Total :</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$gnTotal[Jul]</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$gnTotal[Agu]</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$gnTotal[Sep]</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$gnTotal[Okt]</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$gnTotal[Nov]</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$gnTotal[Des]</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$gnTotal[GTotal]</td></tr>");
		}
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	
	
		 if (($mSmstr=='1') and ($mKategori=='Summary')) { 
	$sel1=mssql_query("SELECT Kategori, SUM(Jan) as Jan, SUM(Feb) as Feb, SUM(Mar) as Mar, SUM(Apr) as Apr, SUM(Mei) as Mei, SUM(Jun) as Jun, SUM(Jan + Feb + Mar + Apr + Mei + Jun) as Total FROM Investment where Thn='$mThn' group by Kategori order by Kategori DESC") or die ("Terdapat kesalahan SQL!");	  
	echo ("<table width=100% border=0 align=center bgcolor=#CCCCFF>
		<tr><td width=28% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Kategori</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Jan</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Feb</a> </strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Mar</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Apr</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Mei</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Jun</a></strong></div></td>
			<td width=8% bgcolor=#FFFF99><div align=center class=style2><strong><a href=# class=style2>Total</a></strong></div></td></tr>");    
	while ($row = mssql_fetch_object($sel1))
	  {
	  // ----- mengambil isi setiap kolom
			$Kategori=$row->Kategori;
			$Jan=$row->Jan;
			$Feb=$row->Feb;
			$Mar=$row->Mar;
			$Apr=$row->Apr;
			$Mei=$row->Mei;
			$Jun=$row->Jun;
			$Total=$row->Total;
			echo ("<tr><td width=28% align=Center bgcolor=#FFFFCC>$Kategori</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$Jan</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$Feb</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$Mar</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$Apr</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$Mei</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$Jun</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$Total</td></tr>");
			}
			$gTot=mssql_query("SELECT SUM(Jan) as Jan, SUM(Feb) as Feb, SUM(Mar) as Mar, SUM(Apr) as Apr, SUM(Mei) as Mei, SUM(Jun) as 
							   Jun, SUM(Jan + Feb + Mar + Apr + Mei + Jun) as GTotal FROM Investment where Thn='$mThn'");
			$gnTotal=mssql_fetch_array($gTot);
			echo ("<tr><td width=28% align=Center bgcolor=#FFFFCC>Total</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$gnTotal[Jan]</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$gnTotal[Feb]</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$gnTotal[Mar]</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$gnTotal[Apr]</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$gnTotal[Mei]</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$gnTotal[Jun]</td>
				   <td width=8% align=right bgcolor=#FFFFCC>$gnTotal[GTotal]</td></tr>");
		}
	?></td>
    </tr>
  </table>
</form>

</body>
</html>