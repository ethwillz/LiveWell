<?php

	//Set up for connection to database
	$db = new mysqli('mysql.cs.iastate.edu', 'dbu309la04', 'YTGUxudv7py', 'db309la04');
	
	//Attempts to connect to database which returns an error if unsuccessful
	if($db->connect_errno > 0 ){
		die('Unable to connect to database [' . $db->connect_error . ']');
	}

	$paymentType = $_POST["paymentType"];
	$residentID = $_POST["residentID"];
	
	if($paymentType == 'both'){
		//Sets value of $result to SQL query and returns an error otherwise
		if(!$result = $db->query("INSERT INTO tblResident (amount1, amount2, amount3, amount4, bAmount) VALUES(0, 0, 0, 0, 0) WHERE residentID = $residentID")){
			die('There was an error running the query [' . $db->error . ']');
		}
	}
	
	if($paymentType == 'roommates'){
		//Sets value of $result to SQL query and returns an error otherwise
		if(!$result = $db->query("INSERT INTO tblResident (amount1, amount2, amount3, amount4) VALUES(0, 0, 0, 0) WHERE residentID = $residentID")){
			die('There was an error running the query [' . $db->error . ']');
		}
	}
	
	if($paymentType == 'building'){
		//Sets value of $result to SQL query and returns an error otherwise
		if(!$result = $db->query("INSERT INTO tblResident (bAmount) VALUES(0) WHERE residentID = $residentID")){
			die('There was an error running the query [' . $db->error . ']');
		}
	}
	
	//Closes the SQL connection
	$result->close();
	$db->close();
	
?>