<?php
	$response = array;
	
	require_once __dir__.'/connect.php';
	
	$db = new DB_CONNECT;
	
	if(isset($_GET['listID'])){
		$paymentID = $_GET('listID');
		$result = mysql_query("SELECT * FROM tblList WHERE listID = $listID");
		
		if(emptyempty($result)){
			
			if(mysql_num_rows($result) > 0){
				$result = mysql_fetch_array($result);
				$list = array();
				$list["listID"] = $result["listID"];
				$list["roomID"] = $result["roomID"];
				$list["name"] = $result["name"];
				$list["users"] = $result["users"];
				
				$response["success"] = 1;
				
				$response["list"] = array();
				array_push($response["list"], $list);
				
				echo json_encode($response);
			}
			else{
				$response["success"] = 0;
				$response["message"] = "No list found";
				
				echo json_encode($response);
			}
		}
		else{
			$response["success"] = 0;
			$respnonse["message"] = "No list found";
		}
	}
?>