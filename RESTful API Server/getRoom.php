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
		if(!$queryOne = $db->query("SELECT roomID FROM tblResident WHERE tblResident.residentID = $residentID")){
			die('There was an error running the query [' . $db->error . ']');
		}
		$id = $queryOne->fetch_assoc();
		$roomID = $id['roomID'];
		
		//Sets value of $result to SQL query and returns an error otherwise
		if(!$queryTwo = $db->query("SELECT address, number, residentID, firstName, lastName FROM tblResident INNER JOIN tblRoom ON tblResident.roomID = tblRoom.roomID INNER JOIN tblBuilding ON tblBuilding.buildingID = tblRoom.buildingID WHERE tblRoom.roomID = $roomID")){
			die('There was an error running the query [' . $db->error . ']');
		}
		
		//Goes through all rows returned by query and sets the notification array to the data
		$notification = array();
		while($row = $queryTwo->fetch_assoc()){
				$notification[] = $row;
		}
		
		//Encodes the array to json and returns it as an HTTP response
		echo json_encode($notification);
		
		//Closes the SQL connection
		$result->close();
		$db->close();
	}
	
	//If statement checks that HTTP request URI contains residentID parameter
	if(isset($_GET["buildingID"])){
		$roomID = $_GET['buildingID'];
		
		//Sets value of $result to SQL query and returns an error otherwise
		if(!$result = $db->query("SELECT address, number, residentID, firstName, lastName FROM tblResident INNER JOIN tblRoom ON tblResident.roomID = tblRoom.roomID INNER JOIN tblBuilding ON tblBuilding.buildingID = tblRoom.buildingID WHERE tblBuilding.buildingID = $buildingID")){
			die('There was an error running the query [' . $db->error . ']');
		}
		
		//Goes through all rows returned by query and sets the room array to the data
		$room = array();
		while($row = $result->fetch_assoc()){
				$room[] = $row;
		}
		
		//Encodes the array to json and returns it as an HTTP response
		echo json_encode($room);
		
		//Closes the SQL connection
		$result->close();
		$db->close();
	}
?>