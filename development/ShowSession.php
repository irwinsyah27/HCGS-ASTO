<?php
session_start();
$sessions = array();

$path = realpath(session_save_path());
$files = array_diff(scandir($path), array('.', '..'));

foreach ($files as $file)
{
    $sessions[$file] = unserialize(file_get_contents($path . '/development/' . $file));
}

echo '<pre>';
print_r($sessions);

echo '</pre>';

$str = 'sess_'.$PHPSESSID;

if(array_key_exists($str,$sessions)) {
echo $str.' Ada';
echo '<pre>';
print_r($_SESSION);
echo '</pre>';

echo str_replace("sess_", "", "'".implode("', '", array_keys($sessions))."'");


}
else {
echo $str.' Tdk Ada';
}


?>


