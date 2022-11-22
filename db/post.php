<?php
require "DB.php";

// get post data in json form
//$body = json_decode(file_get_contents("php://input"));
//$body = $_POST["id"];

try{
/*	
    $id = intval($body->id);
    $player = ($body->player % 2) + 1;
    $x = $body->x % 3;
    $y = $body->y % 3;
*/
    $id = $_POST["id"];
    $player = ($_POST["player"] % 2) + 1;
    $x = $_POST["x"] % 3;
    $y = $_POST["y"] % 3;

}catch (Exception $e){
    // throw error if inputs are not integers
    echo '{"status":"Input error"}';
    return;
}

// update data
$db = DB::get();
$statement = $db->prepare('UPDATE game SET p'.$player.'x = ?, p'.$player.'y = ? WHERE id = ?');
$statement->execute([$x, $y, $id]);

$response = array(
	"status" => "OK",
	"id" => $id,
	"player" => $player,
	"x" => $x,
	"y" => $y,
);
echo json_encode($response);
