<?php

	$response = array();
	
	if(isset($_POST['maintenanceID'])){
		$listID = $_POST['maintenanceID'];
		
		require_once __DIR__.'/connect.php';
		
		$db = new DB_CONNECT();
		
		$result = mysql_query("DELETE FROM tblMaintenance WHERE maintenanceID = $maintenanceID");
		
		if(mysql_affected_rows > 0){
			$response["success"] = 1;
			$response["message"] = "Request sucessfully deleted";
			echo json_encode($reponse);
		}
		else{
			$response["success"] = 0;
			$response["mesage"] = "No request found";
			echo json_encode($resposne);
		}
	}

?>