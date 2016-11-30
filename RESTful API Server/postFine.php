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

    $room = $input['room'];
    $buildingID = $input['buildingID'];
    $description = mysqli_real_escape_string($db, $input['description']);
    $amount = mysqli_real_escape_string($db, $input['amount']);

    echo("SELECT * FROM tblRoom INNER JOIN tblBuilding ON tblRoom.buildingID = tblBuilding.buildingID WHERE number = $room AND tblRoom.buildingID = $buildingID");

    //Sets value of $result to SQL query and returns an error otherwise
    if(!$initialinfo = $db->query("SELECT * FROM tblRoom INNER JOIN tblBuilding ON tblRoom.buildingID = tblBuilding.buildingID WHERE number = $room AND tblRoom.buildingID = $buildingID")){
        die('There was an error running the query [' . $db->error . ']');
    }

    while($column = $initialinfo->fetch_assoc()){
        $roomID = $column['roomID'];
    }

    //Sets value of $result to SQL query and returns an error otherwise
    if(!$result = $db->query("INSERT INTO tblNotification (type, sender, recipient, description, amount) VALUES ('fine', $buildingID, $roomID, '$description', '$amount')")){
        die('There was an error running the query [' . $db->error . ']');
    }

    //Closes the SQL connection
    $result->close();
    $db->close();
}
?>