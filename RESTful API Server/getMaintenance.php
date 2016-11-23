<?php
	//Set up for connection to database
	$db = new mysqli('mysql.cs.iastate.edu', 'dbu309la04', 'YTGUxudv7py', 'db309la04');
	
	//Attempts to connect to database which returns an error if unsuccessful
	if($db->connect_errno > 0 ){
		die('Unable to connect to database [' . $db->connect_error . ']');
	}
	
	//If statement checks that HTTP request URI contains residentID parameter
	if(isset($_GET["maintenanceID"])){
		$maintenanceID = $_GET['maintenanceID'];
		
		//Sets value of $result to SQL query and returns an error otherwise
		if(!$result = $db->query("SELECT * FROM tblMaintenance WHERE maintenanceID = $maintenanceID")){
			die('There was an error running the query [' . $db->error . ']');
		}
		
		//Goes through all rows returned by query and sets the maintenance array to the data
		$maintenance = array();
		while($row = $result->fetch_assoc()){
				$maintenance[] = $row;
		}
		
		//Encodes the array to json and returns it as an HTTP response
		echo json_encode($maintenance);
		
		//Closes the SQL connection
		$result->close();
		$db->close();
	}
	
	//If statement checks that HTTP request URI contains residentID parameter
	if(isset($_GET["buildingID"])){
		$buildingID = $_GET['buildingID'];
		
		//Sets value of $result to SQL query and returns an error otherwise
		if(!$result = $db->query("SELECT maintenanceID, tblRoom.number, residentID, employeeID, summary, description, date FROM tblMaintenance INNER JOIN tblRoom ON tblRoom.roomID = tblMaintenance.roomID WHERE buildingID = $buildingID AND resolved = 0")){
			die('There was an error running the query [' . $db->error . ']');
		}
		
		//Goes through all rows returned by query and sets the maintenance array to the data
		$maintenance = array();
		while($row = $result->fetch_assoc()){
				$maintenance[] = $row;
		}
		
		//Encodes the array to json and returns it as an HTTP response
		echo json_encode($maintenance);
		
		//Closes the SQL connection
		$result->close();
		$db->close();
	}
?>