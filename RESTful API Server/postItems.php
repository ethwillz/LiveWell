<?php

	$resposne = array();
	if(isset($_POST['listID']) && isset($_POST['name']) && isset($_POST['imageUrl'])){
		$listID = $_POST['listID'];
		$name = $_POST['name'];
		$imageUrl = $_POST['imageUrl'];
		
		require_once __DIR__.'/connect.php';
		
		$db = new DB_CONNECT();
		
		$result = mysql_query("INSERT INTO tblItem(listID, name, imageUrl) VALUES('$listID', '$name', '$imageUrl'");
		
		if($result){
			$response["success"] = 1;
			$response["message"] = "Request successfully inserted";
			echo json_encode($response);
		}
		else{
			$response["success"] = 0;
			$repsonse["message"] = "Request not inserted, error occured";
			echo json_encode($resposne);
		}
	}

?>