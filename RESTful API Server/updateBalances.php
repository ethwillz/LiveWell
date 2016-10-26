<?php
	header("Content-Type", "application/json");

	//Set up for connection to database
	$db = new mysqli('mysql.cs.iastate.edu', 'dbu309la04', 'YTGUxudv7py', 'db309la04');
	
	//Attempts to connect to database which returns an error if unsuccessful
	if($db->connect_errno > 0 ){
		die('Unable to connect to database [' . $db->connect_error . ']');
	}

	if(isset($_POST)){
		$paymentType = mysqli_real_escape_string($db, $_GET['paymentType']);
		$residentID = $_GET['residentID'];
		
		if($paymentType === 'both'){
			//Sets value of $result to SQL query and returns an error otherwise
			if(!$result = $db->query("UPDATE tblResident SET amount1=0, amount2=0, amount3=0, amount4=0, bAmount=0 WHERE residentID = $residentID")){
				die('There was an error running the query [' . $db->error . ']');
			}
		}
		
		if($paymentType === 'roommates'){
			//Sets value of $result to SQL query and returns an error otherwise
			if(!$result = $db->query("UPDATE tblResident SET amount1=0, amount2=0, amount3=0, amount4=0 WHERE residentID = $residentID")){
				die('There was an error running the query [' . $db->error . ']');
			}
		}
		
		if($paymentType === 'building'){
			//Sets value of $result to SQL query and returns an error otherwise
			if(!$result = $db->query("UPDATE tblResident SET bAmount=0 WHERE residentID = $residentID")){
				die('There was an error running the query [' . $db->error . ']');
			}
		}
		
		//Closes the SQL connection
		$result->close();
		$db->close();
	}
	
?>