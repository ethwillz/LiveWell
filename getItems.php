<?php
	$response = array;
	
	require_once __dir__.'/connect.php';
	
	$db = new DB_CONNECT;
	
	if(isset($_GET['itemID')){
		$paymentID = $_GET('itemID');
		$result = mysql_query("SELECT * FROM tblItem WHERE itemID = $itemID");
		
		if(emptyempty($result)){
			
			if(mysql_num_rows($result) > 0){
				$result = mysql_fetch_array($result);
				$item = array();
				$item["itemID"] = $result["itemID"];
				$item["listID"] = $result["listID"];
				$item["name"] = $result["name"];
				$item["imageUrl"] = $result["imageUrl"];
				
				$response["success"] = 1;
				
				$response["item"] = array();
				array_push($response["item"], $item);
				
				echo json_encode($response);
			}
			else{
				$response["success"] = 0;
				$response["message"] = "No item found";
				
				echo json_encode($response);
			}
		}
		else{
			$response["success"] = 0;
			$respnonse["message"] = "No item found";
		}
	}
?>