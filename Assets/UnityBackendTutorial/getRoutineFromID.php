<?php
$servername = "sql7.freemysqlhosting.net";
$username = "sql7357116";
$password = "VUvRPyhQ59";
$db = "sql7357116";
$idRoutine = $_POST["idRoutine"];
// Create connection
$conn = mysqli_connect($servername, $username, $password,$db);

// Check connection
if (!$conn) {
  die("Connection failed: " . mysqli_connect_error());
}

$sql = "Select * from Routines Where idRoutine = '" . $idRoutine . "'";
$result = $conn->query($sql);
if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
     $arr = array('idRoutine' => $row['idRoutine'], 'description' => $row['description'], 'finalDate' => $row['finalDate']);
     echo json_encode($arr);
   }
} else {
  echo "No Routine found";
}
$conn->close();
?>