<?php
	//Set up for connection to database
	$db = new mysqli('mysql.cs.iastate.edu', 'dbu309la04', 'YTGUxudv7py', 'db309la04');
	
	//Attempts to connect to database which returns an error if unsuccessful
	if($db->connect_errno > 0 ){
		die('Unable to connect to database [' . $db->connect_error . ']');
	}
	
	if(isset($_GET["residentID"])){
		$residentID = $_GET['residentID'];

		if(!$result = $db->query("SELECT amount1, amount2, amount3, amount4, bAmount FROM tblResident WHERE residentID = $residentID")){
			die('There was an error running the query [' . $db->error . ']');
		}
		$balances = array();
		while($row = $result->fetch_assoc()){
			$balances[] = $row;
		}
		
		echo json_encode($balances);
		
				//Closes the SQL connection
			$result->close();
			$db->close();
	}
?>