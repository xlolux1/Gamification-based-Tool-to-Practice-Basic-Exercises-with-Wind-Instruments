<?php
$servername = "sql7.freemysqlhosting.net";
$username = "sql7357116";
$password = "VUvRPyhQ59";
$db = "sql7357116";
$idExercise = $_POST["idExercise"];
// Create connection
$conn = mysqli_connect($servername, $username, $password,$db);

// Check connection
if (!$conn) {
  die("Connection failed: " . mysqli_connect_error());
}

$sql = "Select * from ScaleExercise Where idExercise = '" . $idExercise . "'";
$result = $conn->query($sql);
if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
     $arr = array('typeScale' => $row['typeScale'], 'firstNote' => $row['firstNote'], 'duration' => $row['duration']);
     echo json_encode($arr);
  }
} else {
  echo "Wrong";
}
$conn->close();
?>