<html>
<head>
<title>Berita dinding kpp index</title>
<style>
#papan{width:1000;height:800;border:#efefef 1px solid;
overflow:hidden}
.p{height:100;text-align:left;
border-bottom:#cdcdcd 1px solid;padding:5}
.x{height:100;text-align:left;
border-bottom:#cdcdcd 1px solid;display:none;padding:5}
a{color:#306DA3;text-decoration:none}
</style>

<script type="text/javascript" src="../Tools/jquery-1.4.3.min.js"></script>
<script>
var i = 8;
var jumlah;
var brt = new Array();
var rotasi = 8;
var nomorakhir;
var posisiar;
$(document).ready(function(){
    jumlah = $("#jumlahberita").html();
    jumlah = parseInt(jumlah);
    nomorakhir = $("#nomorakhir").html();
    for(x=1;x<=jumlah;x++){
        brt[x] = $("#drz"+x).html(); //mengambil berita ,menjadi array brt[]
    }
    cek();
    putar();
});
function cek(){
    $.ajax({
        url: "cekdata.php",
        data: "akhir="+nomorakhir,
        cache: false,
        success: function(msg){
            if(msg!=""){
                data = msg.split("||");
                nomorakhir = data[0];
                brt.push(data[1]); //tambahkan berita baru ke array brt[] di posisi akhir
                jumlah++;
                rotasi = jumlah;
            }
        }
    });
    var waktucek = setTimeout("cek()",4000);
}

function putar(){
    if(jumlah>7){                   //kita putar atau scroll jika jumlah berita lebih dari 4
        $("#papan").prepend("<div id=drz"+i+" class=x><span id=s"+i+">"+brt[rotasi]+"<br></span></div>");
        $("#s"+i).hide();
        $("#drz"+i).slideDown(400); //fungsi untuk melakuan scrolldown
        $("#s"+i).fadeIn(3000);     //fungdi untuk menampilkan berita secara fade in
        rotasi--;
        i++;
        if(rotasi<=(jumlah - 8)){
            rotasi = jumlah;
        }
    }
    var waktuputar = setTimeout("putar()",4000);
}
</script>

</head>
<body>
<center>
<br>
<div id=papan>
<?php
include "koneksi.php";
$koneksi=open_connection();
$i = 1;

//mengambil 5 berita terbaru dari database

$berita = mysql_query("SELECT * FROM bHarian ORDER BY No DESC LIMIT 8");
while($b = mysql_fetch_array($berita)){
    echo "<div class=p id=drz$i>";
    echo "<img src='img/".$b['Gambar']."' align=left width=48 height=48><b>".$b['Jenis']."</b><font size=1> (".$b['Tgl'].")</font><div align=left><b><a href=Item.php?No=".$b['No'].">".$b['Judul']."</a></b></div> ";
    echo "<br>".substr($b['Isi'],0,150)." .....<br>";
    echo "</div>\n";
    $i++;
}

//mengambil nomor terakhir, yang nanti berguna untuk pengecekan

$akhir = mysql_query("SELECT No FROM bHarian ORDER BY No DESC LIMIT 1");
$a = mysql_fetch_array($akhir);
$akhirnya = $a['No'];
?>
</div>
<?php
$j = $i - 1;
echo "<span id=jumlahberita style='display:none'>$j</span>";
echo "<span id=nomorakhir style='display:none'>$akhirnya</span>";
mysql_close($koneksi);
?>
<p>
<script>
function buka(id,no){
    window.open("formberita.php?userid="+id+"&no="+no,"","width=500,height=400,toolbar=0");
}
</script>
</body>
</html>
