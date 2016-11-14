<?php
	//Set up for connection to database
	$db = new mysqli('mysql.cs.iastate.edu', 'dbu309la04', 'YTGUxudv7py', 'db309la04');

	//Attempts to connect to database which returns an error if unsuccessful
	if($db->connect_errno > 0 ){
		die('Unable to connect to database [' . $db->connect_error . ']');
	}

	if(isset($_GET["userType"]) && isset($_GET["email"]) && isset($_GET["password"]))
	{
		$userType = $_GET['userType'];
		$email = $_GET['email'];
		$password = $_GET['password'];

		if($userType=="Resident"){
			if(!$result = $db->query("SELECT * FROM tblResident
				WHERE tblResident.email = '$email' AND tblResident.password ='$password'")){
					die('There was an error running the query [' . $db->error . ']');
				}
		}
		else if ($userType=="Employee"){
			if(!$result = $db->query("SELECT * FROM tblEmployee
				WHERE tblEmployee.email = '$email' AND tblEmployee.password ='$password'")){
					die('There was an error running the query [' . $db->error . ']');
				}
		}
		else if ($userType=="Owner"){
			if(!$result = $db->query("SELECT * FROM tblOwner
				WHERE tblOwner.email = '$email' AND tblOwner.password ='$password'")){
					die('There was an error running the query [' . $db->error . ']');
				}
		}

		//Goes through all rows returned by query and sets the building array to the data
		$user = array();
		while($row = $result->fetch_assoc()){
				$user[] = $row;
		}

		//Encodes the array to json and returns it as an HTTP response
		echo json_encode($user);

		//Closes the SQL connection
		$result->close();
		$db->close();

	}

?>
