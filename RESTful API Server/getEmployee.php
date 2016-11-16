<?php
	//Set up for connection to database
	$db = new mysqli('mysql.cs.iastate.edu', 'dbu309la04', 'YTGUxudv7py', 'db309la04');
	
	//Attempts to connect to database which returns an error if unsuccessful
	if($db->connect_errno > 0 ){
		die('Unable to connect to database [' . $db->connect_error . ']');
	}
	
	//If statement checks that HTTP request URI contains residentID parameter
	if(isset($_GET["employeeID"])){
		$employeeID = $_GET['employeeID'];
		
		//Sets value of $result to SQL query and returns an error otherwise
		if(!$result = $db->query("SELECT firstName, lastName, tblEmployee.buildingID, address FROM tblEmployee INNER JOIN tblBuilding ON tblEmployee.buildingID = tblBuilding.buildingID WHERE employeeID = $employeeID")){
			die('There was an error running the query [' . $db->error . ']');
		}
		
		//Goes through all rows returned by query and sets the list array to the data
		$employee = array();
		while($row = $result->fetch_assoc()){
				$employee[] = $row;
		}
		
		//Encodes the array to json and returns it as an HTTP response
		echo json_encode($employee);
		
		//Closes the SQL connection
		$result->close();
		$db->close();
	}
	
?>