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

		$firstName = $input['firstName'];
		$lastName = $input['lastName'];
		$email = $input['email'];
		$password = $input['password'];


		//Sets value of $result to SQL query and returns an error otherwise
		if(!$result = $db->query("INSERT INTO tblResident (firstName,lastName,email,password)
      VALUES ('$firstName','$lastName','$email','$password')")){
			die('There was an error running the query [' . $db->error . ']');
		}

		//Closes the SQL connection
		$result->close();
		$db->close();
	}

?>
