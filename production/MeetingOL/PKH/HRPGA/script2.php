<?php
require("cek.php");
// ----- ambil isi dari file koneksi.php
require("../koneksi.php");

include ("../chart/modul/jpgraph.php");
include ("../chart/modul/jpgraph_line.php");
include ("../chart/modul/jpgraph_bar.php");

$dataJum = array();
$dataTh = array();

mysql_connect("localhost","root","rantkppit");
mysql_select_db("Grafik");

$query = "SELECT tahun, jmlpria + jmlwanita as jum FROM sensus WHERE negara = 'A'";
$hasil = mysql_query($query);
while ($data = mysql_fetch_array($hasil))
{
	array_unshift($dataJum, $data['jum']);
	array_unshift($dataTh, $data['tahun']);
}

$graph = new Graph(800,600,"auto");    
$graph->SetScale("textlin");

// menampilkan plot batang dari data jumlah penduduk
$bplot = new BarPlot($dataJum);
$graph->Add($bplot);

// menampilkan plot garis dari data jumlah penduduk
$lineplot=new LinePlot($dataJum);
$graph->Add($lineplot);


$graph->img->SetMargin(40,20,20,40);
$graph->title->Set("Grafik Jumlah Penduduk Negara A");
$graph->xaxis->title->Set("Tahun");
$graph->yaxis->title->Set("Jumlah");
$graph->xaxis->SetTickLabels($dataTh);

$graph->title->SetFont(FF_FONT1,FS_BOLD);

$lineplot->SetColor("blue");
$bplot->SetFillColor("red");

$graph->SetShadow();
$graph->Stroke();
?>