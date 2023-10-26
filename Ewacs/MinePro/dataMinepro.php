<?php
require("conn.php");
$con = open_connection();

//echo ($_GET["dateParam"]." ".$_GET["eqnumParam"]);

if (isset($_GET["date1Param"])) {
	$result = mssql_query("SELECT  
					 replace(convert(varchar, CONVERT(DATETIME, '20' + SUBSTRING(REPLACE(plmkode, ' ', ''), 7, 2) + '-' + SUBSTRING(REPLACE(plmkode, ' ', ''), 5, 2) 
					 + '-' + SUBSTRING(REPLACE(plmkode, ' ', ''), 3, 2) + ' ' + SUBSTRING(plmtime, 1, 2) + ':' + SUBSTRING(plmtime, 3, 2) + ':00.000') 
					 ,102),'.','-')+' '+convert(varchar, CONVERT(DATETIME, '20' + SUBSTRING(REPLACE(plmkode, ' ', ''), 7, 2) + '-' + SUBSTRING(REPLACE(plmkode, ' ', ''), 5, 2) 
					  + '-' + SUBSTRING(REPLACE(plmkode, ' ', ''), 3, 2) + ' ' + SUBSTRING(plmtime, 1, 2) + ':' + SUBSTRING(plmtime, 3, 2) + ':00.000') 
					  , 8) AS PLMDateTime, REPLACE(plmkode,' ', '') AS plmkode, plmtime, truckId AS Truck_ID, openId AS Open_ID, payload, emptyTravelTime AS empty_Travel_Time, 
                      emptyTravelDistance AS empty_Travel_Distance, emptySpeedMax AS empty_Speed_Max, emptySpeedAv AS empty_Speed_Av, emptyStopTime AS empty_Stop_Time,
                      loadTime AS load_Time, loadedTravelTime AS loaded_Travel_Time, loadedTravelDistance AS loaded_Travel_Distance, loadedSpeedMax AS loaded_Speed_Max, 
                      loadedSpeedAv AS loaded_Speed_Av, loadedStopTime AS loaded_Stop_Time, dumpingTime AS dumping_Time, limitSpeed AS limit_Speed,
					  (EmptyTravelTime + EmptyStopTime + LoadTime + LoadedTravelTime + LoadedStopTime + DumpingTime) AS cycle_Time,
					  ((EmptyTravelDistance + LoadedTravelDistance) / 2) AS distance,
					  ((EmptySpeedAv + LoadedSpeedAv) / 2) speed_Av,
					  100 AS plan_payload, 22 AS plan_emptySpeed, 1.42 AS plan_emptyStopTime, 20 AS plan_loadedSpeed
				FROM dbo.KPP_PLM
				WHERE (plmkode IS NOT NULL) AND (LEN(REPLACE(plmkode, ' ', '')) = 14) AND (LEN(REPLACE(plmtime, ' ', '')) = 4) AND
				CONVERT(DATETIME, '20' + SUBSTRING(REPLACE(plmkode, ' ', ''), 7, 2) + '-' + SUBSTRING(REPLACE(plmkode, ' ', ''), 5, 2) 
				+ '-' + SUBSTRING(REPLACE(plmkode, ' ', ''), 3, 2) + ' ' + SUBSTRING(plmtime, 1, 2) + ':' + SUBSTRING(plmtime, 3, 2) + ':00.000')
				BETWEEN CONVERT(DATETIME,'".$_GET["date1Param"]."') AND CONVERT(DATETIME,'".$_GET["date2Param"]."') AND
				SUBSTRING(plmkode,9,6) = '".$_GET["eqnumParam"]."' ORDER BY
					  CONVERT(DATETIME, '20' + SUBSTRING(REPLACE(plmkode, ' ', ''), 7, 2) + '-' + SUBSTRING(REPLACE(plmkode, ' ', ''), 5, 2) 
					  + '-' + SUBSTRING(REPLACE(plmkode, ' ', ''), 3, 2) + ' ' + SUBSTRING(plmtime, 1, 2) + ':' + SUBSTRING(plmtime, 3, 2) + ':00.000') 
				");
				
} else {

     $result = mssql_query("SELECT 
					 replace(convert(varchar, CONVERT(DATETIME, '20' + SUBSTRING(REPLACE(plmkode, ' ', ''), 7, 2) + '-' + SUBSTRING(REPLACE(plmkode, ' ', ''), 5, 2) 
					 + '-' + SUBSTRING(REPLACE(plmkode, ' ', ''), 3, 2) + ' ' + SUBSTRING(plmtime, 1, 2) + ':' + SUBSTRING(plmtime, 3, 2) + ':00.000') 
					 ,102),'.','-')+' '+convert(varchar, CONVERT(DATETIME, '20' + SUBSTRING(REPLACE(plmkode, ' ', ''), 7, 2) + '-' + SUBSTRING(REPLACE(plmkode, ' ', ''), 5, 2) 
					  + '-' + SUBSTRING(REPLACE(plmkode, ' ', ''), 3, 2) + ' ' + SUBSTRING(plmtime, 1, 2) + ':' + SUBSTRING(plmtime, 3, 2) + ':00.000') 
					  , 8) AS PLMDateTime, REPLACE(plmkode,' ', '') AS plmkode, plmtime, truckId AS Truck_ID, openId AS Open_ID, payload, emptyTravelTime AS empty_Travel_Time, 
                      emptyTravelDistance AS empty_Travel_Distance, emptySpeedMax AS empty_Speed_Max, emptySpeedAv AS empty_Speed_Av, emptyStopTime AS empty_Stop_Time,
                      loadTime AS load_Time, loadedTravelTime AS loaded_Travel_Time, loadedTravelDistance AS loaded_Travel_Distance, loadedSpeedMax AS loaded_Speed_Max, 
                      loadedSpeedAv AS loaded_Speed_Av, loadedStopTime AS loaded_Stop_Time, dumpingTime AS dumping_Time, limitSpeed AS limit_Speed,
					  (EmptyTravelTime + EmptyStopTime + LoadTime + LoadedTravelTime + LoadedStopTime + DumpingTime) AS cycle_Time,
					  ((EmptyTravelDistance + LoadedTravelDistance) / 2) AS distance,
					  ((EmptySpeedAv + LoadedSpeedAv) / 2) speed_Av,
					  100 AS plan_payload, 22 AS plan_emptySpeed, 1.42 AS plan_emptyStopTime, 20 AS plan_loadedSpeed
				FROM dbo.KPP_PLM
				WHERE (plmkode IS NOT NULL) AND (LEN(REPLACE(plmkode, ' ', '')) = 14) AND (LEN(REPLACE(plmtime, ' ', '')) = 4) AND
					  convert(varchar, CONVERT(DATETIME, '20' + SUBSTRING(REPLACE(plmkode, ' ', ''), 7, 2) + '-' + SUBSTRING(REPLACE(plmkode, ' ', ''), 5, 2) 
					  + '-' + SUBSTRING(REPLACE(plmkode, ' ', ''), 3, 2) + ' ' + SUBSTRING(plmtime, 1, 2) + ':' + SUBSTRING(plmtime, 3, 2) + ':00.000'), 111) = convert(varchar, GETDATE(), 111) AND
					  SUBSTRING(plmkode,9,6) = 'DT7001' ORDER BY
					  CONVERT(DATETIME, '20' + SUBSTRING(REPLACE(plmkode, ' ', ''), 7, 2) + '-' + SUBSTRING(REPLACE(plmkode, ' ', ''), 5, 2) 
					  + '-' + SUBSTRING(REPLACE(plmkode, ' ', ''), 3, 2) + ' ' + SUBSTRING(plmtime, 1, 2) + ':' + SUBSTRING(plmtime, 3, 2) + ':00.000') 
				");
}


while($row = mssql_fetch_array($result)) {
  $uts=strtotime($row['PLMDateTime']);
  $PLMdate=date("l, F j, Y H:i:s",$uts);
  echo $PLMdate . "\t" . $row['payload'] . "\t" . $row['empty_Travel_Time'] . "\t" . $row['empty_Travel_Distance'] . "\t" . $row['empty_Speed_Av'] . "\t" . $row['empty_Stop_Time'] .
				  "\t" . $row['load_Time'] . "\t" . $row['loaded_Travel_Time'] . "\t" . $row['loaded_Travel_Distance'] . "\t" . $row['loaded_Speed_Av'] .
				  "\t" . $row['loaded_Stop_Time'] . "\t" . $row['dumping_Time'] . "\t" . $row['limit_Speed'] .
				  "\t" . $row['cycle_Time'] . "\t" . $row['distance'] . "\t" . $row['speed_Av'] .
				  "\t" . $row['plan_payload'] . "\t" . $row['plan_emptySpeed'] . "\t" . $row['plan_emptyStopTime'] . "\t" . $row['plan_loadedSpeed'] ."\n";
}

mssql_close($con);
?> 