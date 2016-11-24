<?php
	//Set up for connection to database
	$db = new mysqli('mysql.cs.iastate.edu', 'dbu309la04', 'YTGUxudv7py', 'db309la04');
	
	//Attempts to connect to database which returns an error if unsuccessful
	if($db->connect_errno > 0 ){
		die('Unable to connect to database [' . $db->connect_error . ']');
	}
	
	//If statement checks that HTTP request URI contains residentID parameter
	if(isset($_GET["residentID"])){
		$residentID = $_GET['residentID'];
		
		//Sets value of $result to SQL query and returns an error otherwise
		if(!$initialinfo = $db->query("SELECT * FROM tblResident INNER JOIN tblRoom ON tblResident.roomID = tblRoom.roomID WHERE residentID = $residentID")){
			die('There was an error running the query [' . $db->error . ']');
		}

		while($column = $initialinfo->fetch_assoc()){
				$buildingID = $column['buildingID'];
				$roomID = $column['roomID'];
		}
		
		//Sets value of $result to SQL query and returns an error otherwise
		if(!$result = $db->query("SELECT * FROM tblNotification WHERE (recipient = $residentID AND type = 'payRoom' OR type = 'bought')
OR (recipient = $buildingID AND type = 'payBuilding')
OR (recipient = $roomID AND type = 'fine')")){
			die('There was an error running the query [' . $db->error . ']');
		}
		
		//Goes through all rows returned by query and sets the notification array to the data
		$notification = array();
		while($row = $result->fetch_assoc()){
				$notification[] = $row;
		}
		
		//Encodes the array to json and returns it as an HTTP response
		echo json_encode($notification);
		
		//Closes the SQL connection
		$result->close();
		$db->close();
	}
?>