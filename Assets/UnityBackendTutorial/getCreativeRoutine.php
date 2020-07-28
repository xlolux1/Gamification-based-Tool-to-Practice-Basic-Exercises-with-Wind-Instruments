<?php
$servername = "sql7.freemysqlhosting.net";
$username = "sql7357116";
$password = "VUvRPyhQ59";
$db = "sql7357116";
$user = $_POST["user"];
$instrument = $_POST["instrument"];
// Create connection
$conn = mysqli_connect($servername, $username, $password,$db);

// Check connection
if (!$conn) {
  die("Connection failed: " . mysqli_connect_error());
}

$sql = "Select idRoutine from ProfileRoutines Where username ='".$user."' AND instrument='" .$instrument. "' AND creative=1;";
$result = $conn->query($sql);
if ($result->num_rows > 0) {
    while($row = $result->fetch_assoc()) {
    echo ($row['idRoutine']);
    }
}
$conn->close();