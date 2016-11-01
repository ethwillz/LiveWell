<?php
	header("Content-Type", "application/json");

	//Set up for connection to database
	$db = new mysqli('mysql.cs.iastate.edu', 'dbu309la04', 'YTGUxudv7py', 'db309la04');
	
	//Attempts to connect to database which returns an error if unsuccessful
	if($db->connect_errno > 0 ){
		die('Unable to connect to database [' . $db->connect_error . ']');
	}

	if(isset($_POST)){
		$input = json_decode(file_get_contents('php://input'), true);
		
		$listName = mysqli_real_escape_string($db, $input['listName']);
		$residentID1 = $input['residentID1'];
		$residentID2 = $input['residentID2'];
		$residentID3 = $input['residentID3'];
		$residentID4 = $input['residentID4'];
		
		if($residentID2 == 0){
			$sql = "INSERT INTO tblList (listName, residentID1, residentID2, residentID3, residentID4) VALUES ('$listName', $residentID1, NULL, NULL, NULL)";
		}
		else if($residentID3 == 0){
			$sql = "INSERT INTO tblList (listName, residentID1, residentID2, residentID3, residentID4) VALUES ('$listName', $residentID1, $residentID2, NULL, NULL)";
		}
		else if($residentID4 == 0){
			$sql = "INSERT INTO tblList (listName, residentID1, residentID2, residentID3, residentID4) VALUES ('$listName', $residentID1, $residentID2, $residentID3, NULL)";
		}
		else{
			$sql = "INSERT INTO tblList (listName, residentID1, residentID2, residentID3, residentID4) VALUES ('$listName', $residentID1, $residentID2, $residentID3, $resident4)";
		}
		
		//Sets value of $result to SQL query and returns an error otherwise
		if(!$result = $db->query($sql)){
			die('There was an error running the query [' . $db->error . ']');
		}
		
		//Closes the SQL connection
		$result->close();
		$db->close();
	}

?>