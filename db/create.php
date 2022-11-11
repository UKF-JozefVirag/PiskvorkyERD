<?php
require "DB.php";

// create a new game
$db = DB::get();
$statement = $db->query('INSERT INTO game (p1x, p1y, firstplayer) VALUES (-1, -1, FLOOR(RAND()*2))');
$id = $db->lastInsertId();

// return status with game id
echo '{"status":"OK","id":"'.$id.'"}';