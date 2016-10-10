<?php

	$response = array();

	if(isset($_POST['residentID'])){
		$residentID = $_POST['residentID'];

		require_once __DIR__.'/connect.php';

		$db = new DB_CONNECT();

		$result = mysql_query("DELETE FROM tblResident WHERE residentID = $residentID");

		if(mysql_affected_rows > 0){
			$response["success"] = 1;
			$response["message"] = "Item sucessfully deleted";
			echo json_encode($reponse);
		}
		else{
			$response["success"] = 0;
			$response["mesage"] = "No item found";
			echo json_encode($resposne);
		}
	}

?>
