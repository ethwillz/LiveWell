<?php
	$db = new mysqli('mysql.cs.iastate.edu', 'dbu309la04', 'YTGUxudv7py', 'db309la04');
	
	if($db->connect_errno > 0 ){
		die('Unable to connect to database [' . $db->connect_error . ']');
	}
	
	if(isset($_GET["residentID"])){
		$residentID = $_GET['residentID'];
		
		if(!$result = $db->query("SELECT notificationID, tblResident.residentID, type, amount, sender, details FROM tblNotification INNER JOIN tblResident ON tblNotification.residentID = tblResident.residentID WHERE tblResident.residentID = $residentID")){
			die('There was an error running the query [' . $db->error . ']');
		}
		
		$notification = array();
		while($row = $result->fetch_assoc()){
				$notification[] = $row;
		}
		
		echo json_encode($notification);
		
		$result->close();
		$db->close();
	}
?>