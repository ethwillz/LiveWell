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
		
		$buildingID = $input['buildingID'];
		$ownerID = $input['ownerID'];
		$address = mysqli_real_escape_string($db, $input['address']);
		$numRooms = $input['numRooms'];
		$bankNum = $input['bankNum'];
		$routingNum = $input['routingNum'];
		$imageUrl = mysqli_real_escape_string($db, $input['imageUrl']);
		
		//Sets value of $result to SQL query and returns an error otherwise
		if(!$result = $db->query("INSERT INTO tblBuilding (buildingID, ownerID, address, numRooms, bankNum, routingNum, imageUrl) VALUES($buildingID, $ownerID, '$address', $numRooms, $bankNum, $routingNum, '$imageUrl')")){
			die('There was an error running the query [' . $db->error . ']');
		}
		
		//Closes the SQL connection
		$result->close();
		$db->close();
	}

?>