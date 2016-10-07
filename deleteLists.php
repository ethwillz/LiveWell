<?php

	$response = array();
	
	if(isset($_POST['listID'])){
		$listID = $_POST['listID'];
		
		require_once __DIR__.'/connect.php';
		
		$db = new DB_CONNECT();
		
		$result = mysql_query("DELETE FROM tblList WHERE listID = $listID");
		
		if(mysql_affected_rows > 0){
			$response["success"] = 1;
			$response["message"] = "List sucessfully deleted";
			echo json_encode($reponse);
		}
		else{
			$response["success"] = 0;
			$response["mesage"] = "No list found";
			echo json_encode($resposne);
		}
	}

?>