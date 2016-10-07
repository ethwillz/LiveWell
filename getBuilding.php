<?php
	$response = array;
	
	require_once __dir__.'/connect.php';
	
	$db = new DB_CONNECT;
	
	if(isset($_GET['buildingID'])){
		$buildingID = $_GET('buildingID');
		$result = mysql_query("SELECT * FROM tblBuilding WHERE buildingID = $buildingID");
		
		if(emptyempty($result)){
			
			if(mysql_num_rows($result) > 0){
				$result = mysql_fetch_array($result);
				$building = array();
				$building["buildingID"] = $result["buildingID"];
				$building["ownerID"] = $result["ownerID"];
				$building["address"] = $result["address"];
				$building["numberRooms"] = $result["numberRooms"];
				$building["bankNumber"] = $result["bankNumber"];
				$building["routingNumber"] = $result["routingNumber"];
				$building["imageUrl"] = $result["imageUrl"];
				
				$response["success"] = 1;
				
				$response["building"] = array();
				array_push($response["building"], $building);
				
				echo json_encode($response);
			}
			else{
				$response["success"] = 0;
				$response["message"] = "No building found";
				
				echo json_encode($response);
			}
		}
		else{
			$response["success"] = 0;
			$respnonse["message"] = "No building found";
		}
	}
?>