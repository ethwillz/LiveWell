<?php
	header("Content-Type", "application/json");

	//Set up for connection to database
	$db = new mysqli('mysql.cs.iastate.edu', 'dbu309la04', 'YTGUxudv7py', 'db309la04');
	
	//Attempts to connect to database which returns an error if unsuccessful
	if($db->connect_errno > 0 ){
		die('Unable to connect to database [' . $db->connect_error . ']');
	}
	
	if(isset($_GET["resident"])){
		$input = json_decode(file_get_contents('php://input'), true);
		
		$residentID = $input['residentID'];
		$summary = mysqli_real_escape_string($db, $input['summary']);
		$description = mysqli_real_escape_string($db, $input['explanation']);
		$date = mysqli_real_escape_string($db, $input['date']);
		
		//Sets value of $result to SQL query and returns an error otherwise
		if(!$result = $db->query("INSERT INTO tblMaintenance (roomID, residentID, summary, description, date, resolved) SELECT tblResident.roomID, $residentID, '$summary', '$description', '$date', 0 FROM tblResident WHERE residentID = $residentID")){
			die('There was an error running the query [' . $db->error . ']');
		}
		
		//Closes the SQL connection
		$result->close();
		$db->close();
	}
	
	if(isset($_GET["employee"])){
		$input = json_decode(file_get_contents('php://input'), true);
		
		$date = mysqli_real_escape_string($db, $input['date']);
		$employeeID = $input['employeeID'];
		$requestID = $input['requestID'];
		
		//Sets value of $result to SQL query and returns an error otherwise
		if(!$result = $db->query("UPDATE tblMaintenance SET scheduledDate='$date', employeeID=$employeeID, resolved=1 WHERE maintenanceID = $requestID")){
			die('There was an error running the query [' . $db->error . ']');
		}
		
		//Closes the SQL connection
		$result->close();
		$db->close();
	}

?>