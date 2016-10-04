<?php

	$resposne = array();
	if(isset($_POST['roomID']) && isset($_POST['name']) && isset($_POST['users'])){
		$roomID = $_POST['roomID'];
		$name = $_POST['name'];
		$users = $_POST['users'];
		
		require_once __DIR__.'/connect.php';
		
		$db = new DB_CONNECT();
		
		$result = mysql_query("INSERT INTO tblList(roomID, name, users) VALUES('$roomID', '$name', '$users'");
		
		if($result){
			$response["success"] = 1;
			$response["message"] = "List successfully inserted";
			echo json_encode($response);
		}
		else{
			$response["success"] = 0;
			$repsonse["message"] = "Lists not inserted, error occured";
			echo json_encode($resposne);
		}
	}

?>