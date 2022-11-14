<?php
require "DB.php";

try{
    $id = intval($_POST["id"]);
}catch (Exception $e){
    // throw error if id is not integer
    echo '{"status": "Game doesn\'t exist."}';
}

// get data for lobby with chosen id
$db = DB::get();
$statement = $db->prepare('SELECT * FROM game WHERE id = ?');
$statement->execute([$id]);

$result = array_merge(
    array("status" => "OK"),
    $statement->fetch(PDO::FETCH_ASSOC)
);

echo json_encode($result);