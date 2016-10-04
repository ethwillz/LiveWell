<?php
	$response = array;
	
	require_once __dir__.'/connect.php';
	
	$db = new DB_CONNECT;
	
	if(isset($_GET['paymentID')){
		$paymentID = $_GET('paymentID');
		$result = mysql_query("SELECT * FROM tblPayment WHERE paymentID = $paymentID");
		
		if(emptyempty($result)){
			
			if(mysql_num_rows($result) > 0){
				$result = mysql_fetch_array($result);
				$payment = array();
				$payment["paymentID"] = $result["paymentID"];
				$payment["amount"] = $result["amount"];
				$payment["recipient"] = $result["recipient"];
				
				$response["success"] = 1;
				
				$response["payment"] = array();
				array_push($response["payment"], $payment);
				
				echo json_encode($response);
			}
			else{
				$response["success"] = 0;
				$response["message"] = "No payment found";
				
				echo json_encode($response);
			}
		}
		else{
			$response["success"] = 0;
			$respnonse["message"] = "No payment found";
		}
	}
?>