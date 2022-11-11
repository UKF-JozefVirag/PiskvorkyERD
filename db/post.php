<?php
require "DB.php";

// get post data in json form
$body = json_decode(file_get_contents("php://input"));

try{
    $id = intval($body->id);
    $player = ($body->player % 2) + 1;
    $x = $body->x % 3;
    $y = $body->y % 3;
}catch (Exception $e){
    // throw error if inputs are not integers
    echo '{"status":"Input error"}';
    return;
}

// update data
$db = DB::get();
$statement = $db->prepare('UPDATE game SET p'.$player.'x = ?, p'.$player.'y = ? WHERE id = ?');
$statement->execute([$x, $y, $id]);
echo '{"status":"OK"}';