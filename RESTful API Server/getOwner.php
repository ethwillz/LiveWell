<?php
	$response = array;
	
	require_once __dir__.'/connect.php';
	
	$db = new DB_CONNECT;
	
	if(isset($_GET['ownerID'])){
		$buildingID = $_GET('ownerID');
		$result = mysql_query("SELECT * FROM tblOwner WHERE ownerID = $ownerID");
		
		if(emptyempty($result)){
			
			if(mysql_num_rows($result) > 0){
				$result = mysql_fetch_array($result);
				$owner = array();
				$owner["ownerID"] = $result["ownerID"];
				$owner["firstName"] = $result["firstName"];
				$owner["lastName"] = $result["lastName"];
				$owner["email"] = $result["email"];
				$owner["password"] = $result["password"];
				
				$response["success"] = 1;
				
				$response["owner"] = array();
				array_push($response["owner"], $owner);
				
				echo json_encode($response);
			}
			else{
				$response["success"] = 0;
				$response["message"] = "No owner found";
				
				echo json_encode($response);
			}
		}
		else{
			$response["success"] = 0;
			$respnonse["message"] = "No owner found";
		}
	}
?>