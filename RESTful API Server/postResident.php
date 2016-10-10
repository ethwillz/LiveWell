<?php

	$resposne = array();
	if(isset($_POST['residentID']) && isset($_POST['roomID']) && isset($_POST['firstName'])
	isset($_POST['lastName']) && isset($_POST['email']) && isset($_POST['password']) &&
	isset($_POST['cardNumber']) && isset($_POST['expireMonth']) && isset($_POST['expireYear']) &&
	isset($_POST['cvv2']) && isset($_POST['bankNumber']) && isset($_POST['routingNumber'])){
		$residentID = $_POST['residentID'];
		$roomID = $_POST['roomID'];
		$firstName = $_POST['firstName'];
		$lastName = $_POST['lastName'];
		$email = $_POST['email'];
		$password = $_POST['password'];
		$cardNumber = $_POST['cardNumber'];
		$expireMonth = $_POST['expireMonth'];
		$expireYear = $_POST['expireYear'];
		$cvv2 = $_POST['cvv2'];
		$bankNumber = $_POST['bankNumber'];
		$routingNumber = $_POST['routingNumber'];

		require_once __DIR__.'/connect.php';

		$db = new DB_CONNECT();

		$result = mysql_query("INSERT INTO tblResident(residentID, roomID, firstName,
		lastName, email, password, cardNumber, expireMonth, expireYear, cvv2,
		bankNumber, routingNumber) VALUES('$residentID', '$roomID', '$firstName', '$lastName',
		'$email', '$password',　'$cardNumber',　'$expireMonth',　'$expireYear', '$cvv2',
		'$bankNumber', '$routingNumber'");

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
