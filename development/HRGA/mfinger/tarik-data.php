<html>
<head><title>Download Data Absen Finger</title></head>
<body bgcolor="#caffcb">

<?
$IP=$HTTP_GET_VARS["ip"];
$Key=$HTTP_GET_VARS["key"];
$Machine=$HTTP_GET_VARS["machine"];
$Path=$HTTP_GET_VARS["dir"];
if($IP=="") $IP="192.168.1.201";
if($Key=="") $Key="0";

$dts = new DateTime(); //this returns the current date time
$Tgl = date_format($dts, 'Ymd');
//$Path = "D:\\HRGA-OL\\upload_09Digit\\S1\\bima\\data\\";
$Tgl = $Path.$Tgl.".txt";

?>

<form action="tarik-data.php">
IP Address: <input type="Text" name="ip" value="<?=$IP?>" size=15 readonly="false">
No Machine: <input type="Text" name="Machine" value="<?=$Machine?>" size=2 readonly="false">
Comm Key: <input type="Text" name="key" size="2" value="<?=$Key?>" readonly="false">

</form>

<?
if($HTTP_GET_VARS["ip"]!=""){?>
	<table cellspacing="2" cellpadding="2" border="1">
	<tr align="center">
	    <td><B>Data</B></td>
	    <td><B>UserID</B></td>
	    <td width="200"><B>Tanggal & Jam</B></td>
	    <td><B>Status</B></td>
	    <td><B>No Mesin</B></td>
	</tr>
	<?
	$Connect = fsockopen($IP, "80", $errno, $errstr, 1);
	if($Connect){
		$soap_request="<GetAttLog><ArgComKey xsi:type=\"xsd:integer\">".$Key."</ArgComKey><Arg><PIN xsi:type=\"xsd:integer\">All</PIN></Arg></GetAttLog>";
		$newLine="\r\n";
		fputs($Connect, "POST /iWsService HTTP/1.0".$newLine);
	    fputs($Connect, "Content-Type: text/xml".$newLine);
	    fputs($Connect, "Content-Length: ".strlen($soap_request).$newLine.$newLine);
	    fputs($Connect, $soap_request.$newLine);
		$buffer="";
		while($Response=fgets($Connect, 1024)){
			$buffer=$buffer.$Response;
		}
	}else echo "Koneksi Gagal";
	
	include("parse.php");
	$buffer=Parse_Data($buffer,"<GetAttLogResponse>","</GetAttLogResponse>");
	$buffer=explode("\r\n",$buffer);
	for($a=1;$a<count($buffer);$a++){
		$data=Parse_Data($buffer[$a],"<Row>","</Row>");
		$PIN=Parse_Data($data,"<PIN>","</PIN>");
		$DateTime=Parse_Data($data,"<DateTime>","</DateTime>");
		$Verified=Parse_Data($data,"<Verified>","</Verified>");
		$Status=Parse_Data($data,"<Status>","</Status>");
		$dt01=str_replace("-","",$DateTime);
		$dt02=str_replace(":","",$dt01);
		$dt03=str_replace(" ","",$dt02);
		$dt04=substr($dt03,0,12);
		
		$fData=$PIN.$dt04.$Status.$Machine;
		$oData=$fData.PHP_EOL;
		
		if (strlen($oData) >= 24) {
		file_put_contents($Tgl, $oData, FILE_APPEND | FILE_SKIP_EMPTY_LINES | FILE_IGNORE_NEW_LINES | LOCK_EX);
		}
			
		
	?>
	<tr align="center">
		    <td><?if (strlen($fData) >= 24) {echo $fData;}?></td>
		    <td><?=$PIN?></td>
		    <td><?=$DateTime?></td>
		    <td><?=$Status?></td>
		    <td><?if (strlen($fData) >= 24) {echo $Machine;}?></td>
		</tr>
	<?}

	if(count($buffer)>2) {
	echo "Total Record : <strong>".count($buffer)."</strong>";
	echo "</br> Data tersimpan (".$Tgl.")"; 
	} {
	echo "<strong>Data Kosong</strong>";}
	echo "<BR><BR>";
	
	?>
	</table>
<?}

	  if (($HTTP_GET_VARS["ip"]!="") and (count($buffer)>2)){
	  	$Connect = fsockopen($IP, "80", $errno, $errstr, 1);
	 	if($Connect){
	 		$soap_request="<ClearData><ArgComKey xsi:type=\"xsd:integer\">".$Key."</ArgComKey><Arg><Value xsi:type=\"xsd:integer\">3</Value></Arg></ClearData>";
	 		$newLine="\r\n";
	 		fputs($Connect, "POST /iWsService HTTP/1.0".$newLine);
	 		fputs($Connect, "Content-Type: text/xml".$newLine);
	 		fputs($Connect, "Content-Length: ".strlen($soap_request).$newLine.$newLine);
	 		fputs($Connect, $soap_request.$newLine);
	 		$buffer="";
	 		while($Response=fgets($Connect, 1024)){
	 			$buffer=$buffer.$Response;
	 		}
	 	}else echo "Koneksi Gagal";
	 	$buffer=Parse_Data($buffer,"<Information>","</Information>");
	 	echo "<B>Result:</B><BR>";
	 	echo $buffer;
		echo "</br> Log sudah dibersihkan";
	  }	

	

?>

</body>
</html>
