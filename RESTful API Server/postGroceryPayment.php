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
		
		$amount = mysqli_real_escape_string($db, $input['amount']);
		$sender = $input['sender'];
		$roommates = array();
		$roommates = $input['roommates'];
		$listID = $input['listID']);
		$listName = mysqli_real_escape_string($db, $input['listName']);
		
		if(count($roommates) == 1){
			//Sets value of $result to SQL query and returns an error otherwise
			if(!$result = $db->query("INSERT INTO tblNotification (residentID, type, amount, sender, details, recipient) VALUES ($roommates[0], 'groceries', $sender, $listName, 0")){
				die('There was an error running the query [' . $db->error . ']');
			}
		}
		
		if(count($roommates) == 2){
			//Sets value of $result to SQL query and returns an error otherwise
			if(!$result = $db->query("INSERT INTO tblNotification (residentID, type, amount, sender, details, recipient) VALUES ($roommates[0], 'groceries', $sender, $listName, 0")){
				die('There was an error running the query [' . $db->error . ']');
			}
			//Sets value of $result to SQL query and returns an error otherwise
			if(!$result = $db->query("INSERT INTO tblNotification (residentID, type, amount, sender, details, recipient) VALUES ($roommates[1], 'groceries', $sender, $listName, 0")){
				die('There was an error running the query [' . $db->error . ']');
			}
		}
		
		if(count($roommates) == 3){
			//Sets value of $result to SQL query and returns an error otherwise
			if(!$result = $db->query("INSERT INTO tblNotification (residentID, type, amount, sender, details, recipient) VALUES ($roommates[0], 'groceries', $sender, $listName, 0")){
				die('There was an error running the query [' . $db->error . ']');
			}
			//Sets value of $result to SQL query and returns an error otherwise
			if(!$result = $db->query("INSERT INTO tblNotification (residentID, type, amount, sender, details, recipient) VALUES ($roommates[1], 'groceries', $sender, $listName, 0")){
				die('There was an error running the query [' . $db->error . ']');
			}
			//Sets value of $result to SQL query and returns an error otherwise
			if(!$result = $db->query("INSERT INTO tblNotification (residentID, type, amount, sender, details, recipient) VALUES ($roommates[2], 'groceries', $sender, $listName, 0")){
				die('There was an error running the query [' . $db->error . ']');
			}
		}
		
		
		//Sets value of $result to SQL query and returns an error otherwise
		if(!$result = $db->query("DELETE FROM tblList WHERE listID = $listID")){
			die('There was an error running the query [' . $db->error . ']');
		}
		
		//Closes the SQL connection
		$result->close();
		$db->close();
	}

?>