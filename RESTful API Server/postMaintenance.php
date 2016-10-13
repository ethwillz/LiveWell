<?php

	//Set up for connection to database
	$db = new mysqli('mysql.cs.iastate.edu', 'dbu309la04', 'YTGUxudv7py', 'db309la04');
	
	//Attempts to connect to database which returns an error if unsuccessful
	if($db->connect_errno > 0 ){
		die('Unable to connect to database [' . $db->connect_error . ']');
	}

	if(isset($_POST['roomID']) && isset($_POST['residentID']) && isset($_POST['employeeID']) && isset($_POST['summary']) && isset($_POST['description']) && isset($_POST['date'])){
		$roomID = $_POST['roomID'];
		$residentID = $_POST['residentID'];
		$employeeID = $_POST['employeeID'];
		$summary = $_POST['summary'];
		$description = $_POST['date'];
		
		//Sets value of $result to SQL query and returns an error otherwise
		if(!$result = $db->query("INSERT INTO tblMaintenance (roomID, residentID, employeeID, summary, date) VALUES($roomID, $residentID, $employeeID, $summary, $date)")){
			die('There was an error running the query [' . $db->error . ']');
		}
		
		//Closes the SQL connection
		$result->close();
		$db->close();
	}

?>