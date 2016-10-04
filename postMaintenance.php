<?php

	$resposne = array();
	if(isset($_POST['roomID']) && isset($_POST['residentID']) && isset($_POST['employeeID']) && isset($_POST['summary']) && isset($_POST['description']) && isset($_POST['date'])){
		$roomID = $_POST['roomID'];
		$residentID = $_POST['residentID'];
		$employeeID = $_POST['employeeID'];
		$summary = $_POST['summary'];
		$description = $_POST['date'];
		
		require_once __DIR__.'/connect.php';
		
		$db = new DB_CONNECT();
		
		$result = mysql_query("INSERT INTO tblMaintenance(roomID, residentID, employeeID, summary, description, date) VALUES('$roomID', '$residentID', '$employeeID', 'summary', 'description', 'date'");
		
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