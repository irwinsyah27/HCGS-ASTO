<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head> 
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/> 
 
	<link rel="stylesheet" href="js/themes/south-street/jquery.ui.all.css">
	<link rel="stylesheet" href="js/default.css">

	<style>
		#slider-range{width:280px;}
		#etime{width:30px;}
		#stime{width:30px;}
		#slider-range,#time{margin:10px;display:block;}
	</style>

	
<title>MINE-PRO "PLM PAYLOAD"</title>

	<script type="text/javascript" src="js/jquery-1.10.2.js" ></script>
	<script type="text/javascript" src="js/ui/jquery.ui.core.js"></script>
	<script type="text/javascript" src="js/ui/jquery.ui.widget.js"></script>
	<script type="text/javascript" src="js/ui/jquery.ui.datepicker.js"></script>
	<script type="text/javascript" src="js/ui/jquery.ui.accordion.js"></script>
	<script type="text/javascript" src="js/ui/jquery.ui.mouse.js"></script>
	<script type="text/javascript" src="js/ui/jquery.ui.slider.js"></script>

<script type="text/javascript">

function Getlb(lbx) {
	if(lbx === "Payload"){ 
	document.getElementById('elbx').innerHTML=" ton"; 
	}else
	if(lbx === "LoadTime"){ 
	document.getElementById('elbx').innerHTML=" min"; 
	}else
	if(lbx === "DumpingTime"){ 
	document.getElementById('elbx').innerHTML=" min"; 
	}
	
}


	var chart;
			$(document).ready(function() {
				Highcharts.setOptions(Highcharts.theme);
				var options = {
					chart: {
						renderTo: 'containSUMMARY',
						defaultSeriesType: 'line',
						animation: {
							duration: 1000
						},
						marginRight: 130,
						marginBottom: 100,
						events: {
							load: function() {
    
								// set up the updating of the chart each second
								//var series = this.series[0];
								//setInterval(function() {
								//	var x = (new Date()).getTime(), // current time
								//		y = Math.random();
								//	series.addPoint([x, y], true, true);
								//}, 900 * 1000);
							}
						}
					},
					title: {
						text: 'Payload Meter HD785',
						x: -20 //center
					},
					subtitle: {
						text: '<?php echo '.Update'; ?>',
						x: -20
					},
					xAxis: {
						type: 'datetime',
						tickInterval: 3600 * 1000, // one hour
						tickWidth: 0,
						gridLineWidth: 1
					},
					yAxis: {
						title: {
							text: 'Payload'
						},
						plotLines: [{
							value: 0,
							width: 1,
							color: '#808080'
						}]
					},
					tooltip: {
						formatter: function() {
				                return '<b>'+ this.series.name +'</b><br/>'+
								'Hour ' + Highcharts.dateFormat('%H:%M', this.x) +' = <b>'+ Highcharts.numberFormat(this.y, 1); + 
								'<a id="elbx"> ton</a></b>'; Getlb(this.series.name);
						}
					},
					plotOptions: {
						column: {
						dataLabels: {
						enabled: false
							}
						}
					},

					//legend: {
					//	layout: 'vertical',
					//	align: 'right',
					//	verticalAlign: 'top',
					//	x: -10,
					//	y: 120,
					//	borderWidth: 0
					//},
					series: [{
						name: 'Plan',
						color: 'red',
						dashStyle: 'longdash',
						lineWidth: 1,
						visible: false
					}, 	{
						name: 'Payload /ton',
						color: '#26820C',
						type: 'column',
						visible: false
					}, 	{
						name: 'CycleTime /min'
					}, {
						name: 'Distance /km',
						visible: false
					}, {
						name: 'Speed /km'
					}, {
						name: 'EmptySpeed /min',
						visible: false
					}, {
						name: 'EmptyStop /min',
						visible: false
					}, {
						name: 'LoadedSpeed /min',
						visible: false
					}, {
						name: 'LoadTime /min',
						visible: false
					}],
					exporting: {
						buttons: {
							customButton: {
								x: -62,
								onclick: function () {
									alert('Clicked');
								},
								symbol: 'circle'
							}
						}
					}
					
				}
				
				// Load data asynchronously using jQuery. On success, add the data
				// to the options and initiate the chart.
				// This data is obtained by exporting a GA custom report to TSV.
				// http://api.jquery.com/jQuery.get/
				
				
				$(function() {
				
				$("#datepicker").datepicker({
				dateFormat: "yy-mm-dd",
				showOn: "button",
				});

				$("#datepicker").datepicker("setDate", new Date());
				
				$("#scheduleSubmit").on('click', function(){
				var 
				dateText = document.getElementById('datepicker').value,
				strEq = document.getElementById('eqnum').value,
				strStime = document.getElementById('stime').value,
				strEtime = document.getElementById('etime').value;
				//alert("dataMinepro.php?date1Param="+dateText+" "+strStime+":00.000&date2Param="+dateText+" "+strEtime+":00.000&eqnumParam="+strEq);
				
				jQuery.get("dataMinepro.php?date1Param="+dateText+" "+strStime+":00.000&date2Param="+dateText+" "+strEtime+":00.000&eqnumParam="+strEq, null, function(tsv) {
					var lines = [];
						sPayload = [];
						sEmptyTravelTime = [];
						sEmptyTravelDistance = [];
						sEmptySpeedAv = [];
						sEmptyStopTime = [];
						sLoadTime = [];
						sLoadedTravelTime = [];
						sLoadedTravelDistance = [];
						sLoadedSpeedAv = [];
						sLoadedStopTime = [];
						sDumpingTime = [];
						sLimitSpeed = [];
						sCycleTime = [];
						sDistance = [];
						sSpeedAv = [];
						sPlanPayload = [];
						sPlanEmptySpeed = [];
						sPlanEmptyStopTime = [];
						sPlanLoadedSpeed = [];
							try {
								// split the data return into lines and parse them
								tsv = tsv.split(/\n/g);
								jQuery.each(tsv, function(i, line) {
									line = line.split(/\t/);
									date = Date.parse(line[0] +' UTC');
									sPayload.push([
										date,
										parseFloat(line[1].replace(',', ''), 10)
									]);
									sEmptyTravelTime.push([
										date,
										parseFloat(line[2].replace(',', ''), 10)
									]);
									sEmptyTravelDistance.push([
										date,
										parseFloat(line[3].replace(',', ''), 10)
									]);
									sEmptySpeedAv.push([
										date,
										parseFloat(line[4].replace(',', ''), 10)
									]);
									sEmptyStopTime.push([
										date,
										parseFloat(line[5].replace(',', ''), 10)
									]);
									sLoadTime.push([
										date,
										parseFloat(line[6].replace(',', ''), 10)
									]);
									sLoadedTravelTime.push([
										date,
										parseFloat(line[7].replace(',', ''), 10)
									]);
									sLoadedTravelDistance.push([
										date,
										parseFloat(line[8].replace(',', ''), 10)
									]);
									sLoadedSpeedAv.push([
										date,
										parseFloat(line[9].replace(',', ''), 10)
									]);
									sLoadedStopTime.push([
										date,
										parseFloat(line[10].replace(',', ''), 10)
									]);
									sDumpingTime.push([
										date,
										parseFloat(line[11].replace(',', ''), 10)
									]);
									sLimitSpeed.push([
										date,
										parseFloat(line[12].replace(',', ''), 10)
									]);
									
									sCycleTime.push([
										date,
										parseFloat(line[13].replace(',', ''), 10)
									]);
									sDistance.push([
										date,
										parseFloat(line[14].replace(',', ''), 10)
									]);
									sSpeedAv.push([
										date,
										parseFloat(line[15].replace(',', ''), 10)
									]);
									
									sPlanPayload.push([
										date,
										parseFloat(line[16].replace(',', ''), 10)
									]);
									sPlanEmptySpeed.push([
										date,
										parseFloat(line[17].replace(',', ''), 10)
									]);
									sPlanEmptyStopTime.push([
										date,
										parseFloat(line[18].replace(',', ''), 10)
									]);
									sPlanLoadedSpeed.push([
										date,
										parseFloat(line[19].replace(',', ''), 10)
									]);
								});
							} catch (e) {  }
							options.series[0].data = sPlanPayload;
							options.series[1].data = sPayload;
							
							options.series[2].data = sCycleTime;
							
							options.series[3].data = sDistance;
							
							options.series[4].data = sSpeedAv;
							
							options.series[5].data = sEmptySpeedAv;
							options.series[6].data = sEmptyStopTime;
							options.series[7].data = sLoadedSpeedAv;
							options.series[8].data = sLoadTime;
							options.title.text = 'Payload Meter ( '+strEq+' )';
							options.subtitle.text = dateText+' '+strStime+'-'+strEtime;
							chart = new Highcharts.Chart(options);
					});
				
				});
				
			});
				
});

//========================================================================================================


			$(document).ready(function() {
				Highcharts.setOptions(Highcharts.theme);
				var options = {
					chart: {
						renderTo: 'containPLM',
						defaultSeriesType: 'line',
						animation: {
							duration: 1000
						},
						marginRight: 130,
						marginBottom: 100,
						events: {
							load: function() {
    
								// set up the updating of the chart each second
								//var series = this.series[0];
								//setInterval(function() {
								//	var x = (new Date()).getTime(), // current time
								//		y = Math.random();
								//	series.addPoint([x, y], true, true);
								//}, 900 * 1000);
							}
						}
					},
					title: {
						text: 'Payload Meter HD785',
						x: -20 //center
					},
					subtitle: {
						text: '<?php echo '.Update'; ?>',
						x: -20
					},
					xAxis: {
						type: 'datetime',
						tickInterval: 3600 * 1000, // one hour
						tickWidth: 0,
						gridLineWidth: 1
					},
					yAxis: {
						title: {
							text: 'Payload'
						},
						plotLines: [{
							value: 0,
							width: 1,
							color: '#808080'
						}]
					},
					tooltip: {
						formatter: function() {
				                return '<b>'+ this.series.name +'</b><br/>'+
								'Hour ' + Highcharts.dateFormat('%H:%M', this.x) +' = <b>'+ Highcharts.numberFormat(this.y, 1); + 
								'<a id="elbx"> ton</a></b>'; Getlb(this.series.name);
						}
					},
					plotOptions: {
						column: {
						dataLabels: {
						enabled: false
							}
						}
					},

					//legend: {
					//	layout: 'vertical',
					//	align: 'right',
					//	verticalAlign: 'top',
					//	x: -10,
					//	y: 120,
					//	borderWidth: 0
					//},
					series: [{
						name: 'Plan',
						color: 'red',
						dashStyle: 'longdash',
						lineWidth: 1
					}, 	{
						name: 'Payload /ton',
						color: '#26820C',
						type: 'column'
					}, 	{
						name: 'EmptyTravelTime /min',
						visible: false
					},  {
						name: 'LoadedTravelTime /min',
						visible: false
					}, {
						name: 'CycleTime /min',
						visible: false
					}, {
						name: 'EmptyTravelDistance /km',
						visible: false
					},  {
						name: 'LoadedTravelDistance /km',
						visible: false
					}, {
						name: 'Distance /km',
						visible: false
					}, {
						name: 'EmptySpeed /km',
						visible: false
					},  {
						name: 'LoadedSpeed /km',
						visible: false
					}, {
						name: 'SpeedAverage /km',
						visible: false
					}, {
						name: 'EmptyStopTime /min',
						visible: false
					}, {
						name: 'LoadTime /min',
						visible: false
					}, {
						name: 'LoadedStopTime /min',
						visible: false
					}, {
						name: 'DumpingTime /min',
						visible: false
					}, {
						name: 'LimitSpeed /km',
						visible: false
					}],
					exporting: {
						buttons: {
							customButton: {
								x: -62,
								onclick: function () {
									alert('Clicked');
								},
								symbol: 'circle'
							}
						}
					}
					
				}
				
				// Load data asynchronously using jQuery. On success, add the data
				// to the options and initiate the chart.
				// This data is obtained by exporting a GA custom report to TSV.
				// http://api.jquery.com/jQuery.get/
				
				
				$(function() {
				
				$("#datepicker").datepicker({
				dateFormat: "yy-mm-dd",
				showOn: "button",
				});

				$("#datepicker").datepicker("setDate", new Date());
				
				$("#scheduleSubmit").on('click', function(){
				var 
				dateText = document.getElementById('datepicker').value,
				strEq = document.getElementById('eqnum').value,
				strStime = document.getElementById('stime').value,
				strEtime = document.getElementById('etime').value;
				//alert("dataMinepro.php?date1Param="+dateText+" "+strStime+":00.000&date2Param="+dateText+" "+strEtime+":00.000&eqnumParam="+strEq);
				
				jQuery.get("dataMinepro.php?date1Param="+dateText+" "+strStime+":00.000&date2Param="+dateText+" "+strEtime+":00.000&eqnumParam="+strEq, null, function(tsv) {
					var lines = [];
						sPayload = [];
						sEmptyTravelTime = [];
						sEmptyTravelDistance = [];
						sEmptySpeedAv = [];
						sEmptyStopTime = [];
						sLoadTime = [];
						sLoadedTravelTime = [];
						sLoadedTravelDistance = [];
						sLoadedSpeedAv = [];
						sLoadedStopTime = [];
						sDumpingTime = [];
						sLimitSpeed = [];
						sCycleTime = [];
						sDistance = [];
						sSpeedAv = [];
						sPlanPayload = [];
						sPlanEmptySpeed = [];
						sPlanEmptyStopTime = [];
						sPlanLoadedSpeed = [];
							try {
								// split the data return into lines and parse them
								tsv = tsv.split(/\n/g);
								jQuery.each(tsv, function(i, line) {
									line = line.split(/\t/);
									date = Date.parse(line[0] +' UTC');
									sPayload.push([
										date,
										parseFloat(line[1].replace(',', ''), 10)
									]);
									sEmptyTravelTime.push([
										date,
										parseFloat(line[2].replace(',', ''), 10)
									]);
									sEmptyTravelDistance.push([
										date,
										parseFloat(line[3].replace(',', ''), 10)
									]);
									sEmptySpeedAv.push([
										date,
										parseFloat(line[4].replace(',', ''), 10)
									]);
									sEmptyStopTime.push([
										date,
										parseFloat(line[5].replace(',', ''), 10)
									]);
									sLoadTime.push([
										date,
										parseFloat(line[6].replace(',', ''), 10)
									]);
									sLoadedTravelTime.push([
										date,
										parseFloat(line[7].replace(',', ''), 10)
									]);
									sLoadedTravelDistance.push([
										date,
										parseFloat(line[8].replace(',', ''), 10)
									]);
									sLoadedSpeedAv.push([
										date,
										parseFloat(line[9].replace(',', ''), 10)
									]);
									sLoadedStopTime.push([
										date,
										parseFloat(line[10].replace(',', ''), 10)
									]);
									sDumpingTime.push([
										date,
										parseFloat(line[11].replace(',', ''), 10)
									]);
									sLimitSpeed.push([
										date,
										parseFloat(line[12].replace(',', ''), 10)
									]);
									
									sCycleTime.push([
										date,
										parseFloat(line[13].replace(',', ''), 10)
									]);
									sDistance.push([
										date,
										parseFloat(line[14].replace(',', ''), 10)
									]);
									sSpeedAv.push([
										date,
										parseFloat(line[15].replace(',', ''), 10)
									]);
									
									sPlanPayload.push([
										date,
										parseFloat(line[16].replace(',', ''), 10)
									]);
									sPlanEmptySpeed.push([
										date,
										parseFloat(line[17].replace(',', ''), 10)
									]);
									sPlanEmptyStopTime.push([
										date,
										parseFloat(line[18].replace(',', ''), 10)
									]);
									sPlanLoadedSpeed.push([
										date,
										parseFloat(line[19].replace(',', ''), 10)
									]);
								});
							} catch (e) {  }
							options.series[0].data = sPlanPayload;
							options.series[1].data = sPayload;
							
							options.series[2].data = sEmptyTravelTime;
							options.series[3].data = sLoadedTravelTime;
							options.series[4].data = sCycleTime;
							
							options.series[5].data = sEmptyTravelDistance;
							options.series[6].data = sLoadedTravelDistance;
							options.series[7].data = sDistance;
							
							options.series[8].data = sEmptySpeedAv;
							options.series[9].data = sLoadedSpeedAv;
							options.series[10].data = sSpeedAv;
							
							options.series[11].data = sEmptyStopTime;
							options.series[12].data = sLoadTime;
							options.series[13].data = sLoadedStopTime;
							options.series[14].data = sDumpingTime;
							options.series[15].data = sLimitSpeed;
							options.title.text = 'Payload Meter ( '+strEq+' )';
							options.subtitle.text = dateText+' '+strStime+'-'+strEtime;
							chart = new Highcharts.Chart(options);
					});
				
				});
				
			});
				
});


</script>


	<script>
	$(function() {
		$( "#accordion" ).accordion({
			heightStyle: "content",
			collapsible: true
		});		
		
		$("#slider-range").slider({
				range: true,
				min: 0,
				max: 1439,
				values: [0, 1439],
				slide: slideTime
		});
			
		
	});
	
	function slideTime(event, ui){
		var val0 = $("#slider-range").slider("values", 0),
			val1 = $("#slider-range").slider("values", 1),
			minutes0 = parseInt(val0 % 60, 10),
			hours0 = parseInt(val0 / 60 % 24, 10),
			minutes1 = parseInt(val1 % 60, 10),
			hours1 = parseInt(val1 / 60 % 24, 10);
		startTime = getTime(hours0, minutes0);
		endTime = getTime(hours1, minutes1);
		//$("#time").text('Time : ' + startTime + ' - ' + endTime);
		$("#stime").val(startTime);
		$("#etime").val(endTime);
	}
		
	function getTime(hours, minutes) {
		var time = null;
			minutes = minutes + "";
			if (minutes.length == 1) {
				minutes = "0" + minutes;
			}
			return hours + ":" + minutes;
	}
		
	//slideTime();

	
	</script>

</head>
<body>

	<script type="text/javascript" src="js/highcharts.js" ></script>
	<script type="text/javascript" src="js/highcharts-more.js" ></script>	
	<script type="text/javascript" src="js/exporting.js" ></script>
<div class="ui-state-active">
  <h3 class="styleHeader">&nbsp;</h3>
  <table width="100%" border="0">
    <tr>
      <td width="26%"><span class="styleHeader"><img src="gfx/mine-pro.png" alt="MINE-PRO" width="266" height="128" align="left" /></span></td>
      <td width="74%"><table width="100%" border="0">
        <tr>
          <td width="78%"><table width="100%" height="78" border="0">
            <tr>
              <td width="5%">EqNum</td>
              <td width="20%">:
                <select name="eqnum" class="ui-state-active" id="eqnum">
                  <option value="DT7017">~ HD785 - DT7017 ~</option>
                  <option value="DT7016">~ HD785 - DT7016 ~</option>
                  <option value="DT7015">~ HD785 - DT7015 ~</option>
                  <option value="DT7014">~ HD785 - DT7014 ~</option>
                  <option value="DT7013">~ HD785 - DT7013 ~</option>
                  <option value="DT7005">~ HD785 - DT7005 ~</option>
                  <option value="DT7004">~ HD785 - DT7004 ~</option>
                  <option value="DT7003">~ HD785 - DT7003 ~</option>
                  <option value="DT7002">~ HD785 - DT7002 ~</option>
                  <option value="DT7001" selected="selected">~ HD785 - DT7001 ~</option>
                  <option value="DT2760">~ HD465 - DT2760 ~</option>
                  <option value="DT2759">~ HD465 - DT2759 ~</option>
                  <option value="DT2758">~ HD465 - DT2758 ~</option>
                  <option value="DT2753">~ HD465 - DT2753 ~</option>
                  <option value="DT2747">~ HD465 - DT2747 ~</option>
                  <option value="DT2746">~ HD465 - DT2746 ~</option>
                  <option value="DT2743">~ HD465 - DT2743 ~</option>
                  <option value="DT2742">~ HD465 - DT2742 ~</option>
                  <option value="DT2741">~ HD465 - DT2741 ~</option>
                  <option value="DT2740">~ HD465 - DT2740 ~</option>
                  <option value="DT2737">~ HD465 - DT2737 ~</option>
                  <option value="DT2732">~ HD465 - DT2732 ~</option>
                  <option value="DT2730">~ HD465 - DT2730 ~</option>
                  <option value="DT2729">~ HD465 - DT2729 ~</option>
                  <option value="DT2727">~ HD465 - DT2727 ~</option>
                  <option value="DT2662">~ HD465 - DT2662 ~</option>
                  <option value="DT2595">~ HD465 - DT2595 ~</option>
                  <option value="DT2594">~ HD465 - DT2594 ~</option>
                  <option value="DT2593">~ HD465 - DT2593 ~</option>
                  <option value="DT2575">~ HD465 - DT2575 ~</option>
                  <option value="DT2542">~ HD465 - DT2542 ~</option>
                  <option value="DT2526">~ HD465 - DT2526 ~</option>
                  <option value="DT2512">~ HD465 - DT2512 ~</option>
                </select></td>
              <td width="42%"> Time Range :
                <input class="ui-state-active" id="stime" value="0:00" maxlength="5" />
                </input>
                -
                <input class="ui-state-active" id="etime" value="23:59" maxlength="5" />
                </input></td>
            </tr>
            <tr>
              <td>Date</td>
              <td>:
                <input name="dateParam" type="text" class="ui-state-active" id="datepicker" /></td>
              <td><div id="slider-range"></div></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td><input type="submit" name="scheduleSubmit" value="View" id="scheduleSubmit" class="ui-button ui-state-default ui-corner-all"/></td>
              <td>&nbsp;</td>
            </tr>
          </table></td>
          <td width="22%"><img src="gfx/TowerAnimation.gif" alt="MINE-PRO" width="135" height="148" align="right" /></td>
        </tr>
      </table></td>
    </tr>
  </table>
</div>
        
<div id="accordion">
<h3 align="center">SPEED - CYCLE TIME</h3>
	<div>	
	<h3>SPEED - CYCLE TIME</h3>
	<p id="containSUMMARY" style="width: 100%; height: 400px; margin: 0 auto"></p>
	</div>
	
	<h3 align="center">PAYLOAD METER</h3>
	<div>		
	<h3>PAYLOAD METER</h3>
	<p id="containPLM" style="width: 100%; height: 400px; margin: 0 auto"></p>
	</div>
	
	<h3 align="center">FUEL BURNING</h3>
	<div>		
	<h3>FUEL BURNING</h3>
	<p id="containFUEL-BURN" style="width: 100%; height: 400px; margin: 0 auto"></p>
	</div>
	
	<h3 align="center">TYRE REAR-FRONT</h3>
	<div>		
	<h3>REAR</h3>
	<p id="containTKPH-REAR" style="width: 100%; height: 400px; margin: 0 auto"></p>
	<h3>FRONT</h3>
	<p id="containTKPH-FRONT" style="width: 100%; height: 400px; margin: 0 auto"></p>
	</div>
	
	
</div class="default-description">	
				
</body>
</html>