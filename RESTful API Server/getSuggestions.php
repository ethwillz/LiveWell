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
		
		$sql = <<<SQL
SELECT * 
FROM tblList 
INNER JOIN tblItem ON tblItem.listID=tblList.listID 
WHERE residentID1=1 OR residentID2=1 OR residentID3=1 OR residentID4=1
GROUP BY itemName
ORDER BY Count(*) DESC
LIMIT 20
SQL;
		
		//Sets value of $result to SQL query and returns an error otherwise
		if(!$result = $db->query($sql)){
			die('There was an error running the query [' . $db->error . ']');
		}
		
		//Goes through all rows returned by query and sets the list array to the data
		$list = array();
		while($row = $result->fetch_assoc()){
				$list[] = $row;
		}
		
		//Encodes the array to json and returns it as an HTTP response
		echo json_encode($list);
		
		//Closes the SQL connection
		$result->close();
		$db->close();
	}
	
?>