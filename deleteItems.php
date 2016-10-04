<?php

	$response = array();
	
	if(isset($_POST['itemID'])){
		$listID = $_POST['itemID'];
		
		require_once __DIR__.'/connect.php';
		
		$db = new DB_CONNECT();
		
		$result = mysql_query("DELETE FROM tblItem WHERE itemID = $itemID");
		
		if(mysql_affected_rows > 0){
			$response["success"] = 1;
			$response["message"] = "Item sucessfully deleted";
			echo json_encode($reponse);
		}
		else{
			$response["success"] = 0;
			$response["mesage"] = "No item found";
			echo json_encode($resposne);
		}
	}

?>