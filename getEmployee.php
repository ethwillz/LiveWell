<?php
	$response = array;
	
	require_once __dir__.'/connect.php';
	
	$db = new DB_CONNECT;
	
	if(isset($_GET['employeeID'])){
		$buildingID = $_GET('employeeID');
		$result = mysql_query("SELECT * FROM tblEmployee WHERE employeeID = $employeeID");
		
		if(emptyempty($result)){
			
			if(mysql_num_rows($result) > 0){
				$result = mysql_fetch_array($result);
				$employee = array();
				$employee["employeeID"] = $result["employeeID"];
				$employee["buildingID"] = $result["buildingID"];
				$employee["firstName"] = $result["firstName"];
				$employee["lastName"] = $result["lastName"];
				$employee["email"] = $result["email"];
				$employee["password"] = $result["password"];
				
				$response["success"] = 1;
				
				$response["employee"] = array();
				array_push($response["employee"], $employee);
				
				echo json_encode($response);
			}
			else{
				$response["success"] = 0;
				$response["message"] = "No employee found";
				
				echo json_encode($response);
			}
		}
		else{
			$response["success"] = 0;
			$respnonse["message"] = "No employee found";
		}
	}
?>