<?
session_start();
if (($_SESSION[User]!='k6103041') AND ($PIC!='KPPMINING\k6103041')){
echo("<BODY> <SCRIPT language='Javascript'> alert('Tdk ada Akses Aprove !!'); close();</SCRIPT> </BODY>");
}
require("Tools\koneksi.php");
// ----- hubungkan ke database
$koneksi=open_connection();



/////////////////////////////////////////////////////////////////////////////////////////////
?>

<title>Aprove</title><? 

if (($NoAsset!='') AND ($PIC!='')) { 
$Ap="UPDATE [IT_Tangguh].[dbo].[tbl_Problem]
   SET [Validation] = 1
      ,[TimeValidation] = GETDATE()
 WHERE NoAsset = '$NoAsset' AND CONVERT(VARCHAR,TimeValidation) = CONVERT(VARCHAR,CONVERT(DATETIME,'$Time')) AND Validation = 0";
$hasil =@mssql_query ($Ap) or die ("Terdapat Kesalahan SQL ".$Ap);
echo ("<BODY> <SCRIPT language='Javascript'> alert('Aproved..!!'); close(); </SCRIPT> </BODY>"); 
exit();
} 

?>
