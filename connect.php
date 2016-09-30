define('DB_USER', "dbu309la04");
define('DB_PASSWORD', "YTGUxudv7py");
define('DB_DATABASE', "db309la04");
define('DB_SERVER', "mysql.cs.iastate.edu");

<?php

class DATABASE_CONNECT {

function __connect{
	$this->connect();
}

function --destruct{
	$this->close();
}

function connect{
	$con = mysql_connect(DB_SERVER, DB_USER, DB_PASSWORD) or die (mysql_error());
	$db = mysql_select_db(DB_DATABASE) or die (mysql_error());
	return $con;
}

function close{
	
}
}
?>

$MY_DB = new DB_CONNECT();