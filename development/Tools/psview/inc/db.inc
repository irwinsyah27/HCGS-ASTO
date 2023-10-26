<? /* Set up connection to mysql database. */

	$hst = "localhost"; // Host
	$usr = "root";          // User
	$pwd = "rantkppit";          // Password
	$db  = "psview";          // Database name

	@mysql_connect($hst,$usr,$pwd)
		or exit("Cannot connect to database");
	mysql_select_db($db)
		or exit("Cannot open database!");
?>