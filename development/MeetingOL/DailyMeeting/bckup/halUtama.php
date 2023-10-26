<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<title>Daily Meeting</title>
	<link rel="stylesheet" href="../Tools/themes/south-street/jquery.ui.all.css">
	<script src="../Tools/jquery-1.5.1.js"></script>
	<script src="../Tools/ui/jquery.ui.core.js"></script>
	<script src="../Tools/ui/jquery.ui.widget.js"></script>
	<script src="../Tools/ui/jquery.ui.datepicker.js"></script>
	<link rel="stylesheet" href="../Tools/jQ.css">
	<script>
	$(function() {
		$( "#datepicker" ).datepicker({
			showOn: "button",
			buttonImage: "images/calendar.gif",
			buttonImageOnly: true
		});
	});
	</script>
</head>
<body>

<div class="demo">

<p>Date: <input type="text" id="datepicker"></p>
<p>Format options:<br />
	<select id="format">
		<option value="mm/dd/yy">Default - mm/dd/yy</option>
		<option value="yy-mm-dd">ISO 8601 - yy-mm-dd</option>
		<option value="d M, y">Short - d M, y</option>
		<option value="d MM, y">Medium - d MM, y</option>
		<option value="DD, d MM, yy">Full - DD, d MM, yy</option>
		<option value="'day' d 'of' MM 'in the year' yy">With text - 'day' d 'of' MM 'in the year' yy</option>
	</select>
</p>

</div><!-- End demo -->



<div class="demo-description">
<p>"Loading..." label once loaded.</p>
<p></p>
</div><!-- End demo-description -->

</body>
</html>
