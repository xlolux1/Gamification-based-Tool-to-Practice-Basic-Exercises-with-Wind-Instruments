<?php
$servername = "sql7.freemysqlhosting.net";
$username = "sql7357116";
$password = "VUvRPyhQ59";
$db = "sql7357116";
$user = $_POST["user"];
$collection = array();
// Create connection
$conn = mysqli_connect($servername, $username, $password,$db);

// Check connection
if (!$conn) {
  die("Connection failed: " . mysqli_connect_error());
}

$sql = "Select * from Profile Where username = '" . $user . "' AND instrument ='" .$instrument;
$result = $conn->query($sql);
if ($result->num_rows > 0) {
    while($row = $result->fetch_assoc()) {
          $arr = array('_instrument' => $row['_instrument']);
          echo json_encode($arr);
       }
} else {
  echo "No instruments for this user"

}
$conn->close();
?>