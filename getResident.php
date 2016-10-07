<?php
	$response = array;
	
	require_once __dir__.'/connect.php';
	
	$db = new DB_CONNECT;
	
	if(isset($_GET['residentID'])){
		$buildingID = $_GET('residentID');
		$result = mysql_query("SELECT * FROM tblResident WHERE residentID = $residentID");
		
		if(emptyempty($result)){
			
			if(mysql_num_rows($result) > 0){
				$result = mysql_fetch_array($result);
				$resident = array();
				$resident["residentID"] = $result["residentID"];
				$resident["roomID"] = $result["roomID"];
				$resident["firstName"] = $result["firstName"];
				$resident["lastName"] = $result["lastName"];
				$resident["email"] = $result["email"];
				$resident["password"] = $result["password"];
				$resident["cardNumber"] = $result["cardNumber"];\
				$resident["expireMonth"] = $result["expireMonth"];
				$resident["expireYear"] = $result["expireYear"];
				$resident["cvv2"] = $result["cvv2"];
				$resident["bankNumber"] = $result["bankNumber"];
				$resident["routingNumber"] = $result["routingNumber"];
				
				$response["success"] = 1;
				
				$response["resident"] = array();
				array_push($response["resident"], $resident);
				
				echo json_encode($response);
			}
			else{
				$response["success"] = 0;
				$response["message"] = "No resident found";
				
				echo json_encode($response);
			}
		}
		else{
			$response["success"] = 0;
			$respnonse["message"] = "No resident found";
		}
	}
?>