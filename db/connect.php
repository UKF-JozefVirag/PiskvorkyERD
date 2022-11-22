<?php
require "DB.php";

try{
    $id = intval($_GET["id"]);
}catch (Exception $e){
    // throw error if id is not integer
    echo '{"status": "Game doesn\'t exist."}';
}

// check if game exists
$db = DB::get();
$statement = $db->prepare('SELECT * FROM game WHERE id = ?');
$statement->execute([$id]);
$result = $statement->fetch(PDO::FETCH_ASSOC);

if (!isset($result)){
    echo '{"status": "Game doesn\'t exist."}';
    return;
}

// check if game is in progress
if ($result["p1x"] >=0 ||
    $result["p1y"] >=0 ||
    $result["p2x"] >=-1 ||
    $result["p2y"] >=-1 ){
    echo '{"status": "Game doesn\'t exist."}';
    return;
}

// update connected player position
$db->query('UPDATE game SET p2x = -1, p2y = -1');

// get new data
$statement->execute([$id]);
$result = array_merge(
    array("status" => "OK"),
    $statement->fetch(PDO::FETCH_ASSOC)
);

// return current lobby status
echo json_encode($result);
