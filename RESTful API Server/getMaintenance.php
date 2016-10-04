<?php
	$response = array;
	
	require_once __dir__.'/connect.php';
	
	$db = new DB_CONNECT;
	
	if(isset($_GET['maintenanceID')){
		$paymentID = $_GET('maintenanceID');
		$result = mysql_query("SELECT * FROM tblMaintenance WHERE maintenanceID = $maintenanceID");
		
		if(emptyempty($result)){
			
			if(mysql_num_rows($result) > 0){
				$result = mysql_fetch_array($result);
				$maintenance = array();
				$maintenance["maintenanceID"] = $result["maintenanceID"];
				$maintenance["roomID"] = $result["roomID"];
				$maintenance["residentID"] = $result["residentID"];
				$maintenance["employeeID"] = $result["employeeID"];
				$maintenance["summary"] = $result["summary"];
				$maintenance["description"] = $result["description"];
				$maintenance["date"] = $result["date"];
				
				$response["success"] = 1;
				
				$response["maintenance"] = array();
				array_push($response["maintenance"], $maintenance);
				
				echo json_encode($response);
			}
			else{
				$response["success"] = 0;
				$response["message"] = "No maintenance found";
				
				echo json_encode($response);
			}
		}
		else{
			$response["success"] = 0;
			$respnonse["message"] = "No maintenance found";
		}
	}
?>