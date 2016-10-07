<?php

	$resposne = array();
	if(isset($_POST['residentID']) && isset($_POST['roomID']) && isset($_POST['firstName'])
	isset($_POST['lastName']) && isset($_POST['email']) && isset($_POST['password']) &&
	isset($_POST['cardNumber']) && isset($_POST['expireMonth']) && isset($_POST['expireYear']) &&
	isset($_POST['cvv2']) && isset($_POST['bankNumber']) && isset($_POST['routingNumber'])){
		$residentID = $_POST['residentID'];
		$roomID = $_POST['roomID'];
		$firstName = $_POST['firstName'];

		require_once __DIR__.'/connect.php';

		$db = new DB_CONNECT();

		$result = mysql_query("INSERT INTO tblItem(listID, name, imageUrl) VALUES('$listID', '$name', '$imageUrl'");

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
