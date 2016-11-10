<?php
	header("Content-Type", "application/json");

	//Set up for connection to database
	$db = new mysqli('mysql.cs.iastate.edu', 'dbu309la04', 'YTGUxudv7py', 'db309la04');
	
	$hub = new NotificationHub("AIzaSyDtFwZO35AOSu0eJcfBmdkHS86zFlZwwnk", "LA-04-LiveWell"); 
	
	//Attempts to connect to database which returns an error if unsuccessful
	if($db->connect_errno > 0 ){
		die('Unable to connect to database [' . $db->connect_error . ']');
	}

	if(isset($_POST)){
		$input = json_decode(file_get_contents('php://input'), true);
		
		$amount = mysqli_real_escape_string($db, $input['amount']);
		$sender = $input['sender'];
		$roommates = array();
		$roommates = $input['roommates'];
		$listID = $input['listID'];
		$listName = mysqli_real_escape_string($db, $input['listName']);
		
		if(count($roommates) == 1){
			//Sets value of $result to SQL query and returns an error otherwise
			if(!$result = $db->query("INSERT INTO tblNotification (residentID, type, amount, sender, details, recipient) VALUES ($roommates[0], 'groceries', $sender, $listName, 0")){
				die('There was an error running the query [' . $db->error . ']');
			}
		}
		
		if(count($roommates) == 2){
			//Sets value of $result to SQL query and returns an error otherwise
			if(!$result = $db->query("INSERT INTO tblNotification (residentID, type, amount, sender, details, recipient) VALUES ($roommates[0], 'groceries', $sender, $listName, 0")){
				die('There was an error running the query [' . $db->error . ']');
			}
			//Sets value of $result to SQL query and returns an error otherwise
			if(!$result = $db->query("INSERT INTO tblNotification (residentID, type, amount, sender, details, recipient) VALUES ($roommates[1], 'groceries', $sender, $listName, 0")){
				die('There was an error running the query [' . $db->error . ']');
			}
		}
		
		if(count($roommates) == 3){
			//Sets value of $result to SQL query and returns an error otherwise
			if(!$result = $db->query("INSERT INTO tblNotification (residentID, type, amount, sender, details, recipient) VALUES ($roommates[0], 'groceries', $sender, $listName, 0")){
				die('There was an error running the query [' . $db->error . ']');
			}
			//Sets value of $result to SQL query and returns an error otherwise
			if(!$result = $db->query("INSERT INTO tblNotification (residentID, type, amount, sender, details, recipient) VALUES ($roommates[1], 'groceries', $sender, $listName, 0")){
				die('There was an error running the query [' . $db->error . ']');
			}
			//Sets value of $result to SQL query and returns an error otherwise
			if(!$result = $db->query("INSERT INTO tblNotification (residentID, type, amount, sender, details, recipient) VALUES ($roommates[2], 'groceries', $sender, $listName, 0")){
				die('There was an error running the query [' . $db->error . ']');
			}
		}
		
		$message = '{"data":{"msg":"Standard notification about something"}}';
		$notification = new Notification("gcm", $message);
		$hub->sendNotification($notification, null);
		
		
		//Sets value of $result to SQL query and returns an error otherwise
		if(!$result = $db->query("DELETE FROM tblList WHERE listID = $listID")){
			die('There was an error running the query [' . $db->error . ']');
		}
		
		//Closes the SQL connection
		$result->close();
		$db->close();
	}
	
	class NotificationHub {
		const API_VERSION = "?api-version=2013-10";

		private $endpoint;
		private $hubPath;
		private $sasKeyName;
		private $sasKeyValue;

		function __construct($connectionString, $hubPath) {
			$this->hubPath = $hubPath;

			$this->parseConnectionString($connectionString);
		}

		private function parseConnectionString($connectionString) {
			$parts = explode(";", $connectionString);
			if (sizeof($parts) != 3) {
				throw new Exception("Error parsing connection string: " . $connectionString);
			}

			foreach ($parts as $part) {
				if (strpos($part, "Endpoint") === 0) {
					$this->endpoint = "https" . substr($part, 11);
				} else if (strpos($part, "SharedAccessKeyName") === 0) {
					$this->sasKeyName = substr($part, 20);
				} else if (strpos($part, "SharedAccessKey") === 0) {
					$this->sasKeyValue = substr($part, 16);
				}
			}
		}
		
		private function generateSasToken($uri) {
			$targetUri = strtolower(rawurlencode(strtolower($uri)));

			$expires = time();
			$expiresInMins = 60;
			$expires = $expires + $expiresInMins * 60;
			$toSign = $targetUri . "\n" . $expires;

			$signature = rawurlencode(base64_encode(hash_hmac('sha256', $toSign, $this->sasKeyValue, TRUE)));

			$token = "SharedAccessSignature sr=" . $targetUri . "&sig="
						. $signature . "&se=" . $expires . "&skn=" . $this->sasKeyName;

			return $token;
		}
		
		class Notification {
			public $format;
			public $payload;

			# array with keynames for headers
			# Note: Some headers are mandatory: Windows: X-WNS-Type, WindowsPhone: X-NotificationType
			# Note: For Apple you can set Expiry with header: ServiceBusNotification-ApnsExpiry in W3C DTF, YYYY-MM-DDThh:mmTZD (for example, 1997-07-16T19:20+01:00).
			public $headers;

			function __construct($format, $payload) {
				if (!in_array($format, ["template", "apple", "windows", "gcm", "windowsphone"])) {
					throw new Exception('Invalid format: ' . $format);
				}

				$this->format = $format;
				$this->payload = $payload;
			}
		}
	}

?>