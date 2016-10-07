<?php

	$resposne = array();
	if(isset($_POST['amount']) && isset($_POST['recipient']) && isset($_POST['type'])){
		$amount = $_POST['amount'];
		$recipient = $_POST['recipient'];
		$reason = $_POST['reason'];
		
		require_once __DIR__.'/connect.php';
		
		$db = new DB_CONNECT();
		
		$result = mysql_query("INSERT INTO tblList(amount, recipient, type) VALUES('$amount', '$recipient', '$reason'");
		
		if($result){
			$response["success"] = 1;
			$response["message"] = "Payment successfully inserted";
			echo json_encode($response);
		}
		else{
			$response["success"] = 0;
			$repsonse["message"] = "Payment not inserted, error occured";
			echo json_encode($resposne);
		}
	}

?>