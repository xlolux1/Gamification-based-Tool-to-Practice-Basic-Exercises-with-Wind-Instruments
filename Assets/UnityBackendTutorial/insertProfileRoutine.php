<?php
$servername = "sql7.freemysqlhosting.net";
$username = "sql7357116";
$password = "VUvRPyhQ59";
$db = "sql7357116";
$idRoutine = $_POST["idRoutine"];
$creative = $_POST["creative"];
$user = $_POST["username"];
$instrument = $_POST["instrument"];
// Create connection
$conn = mysqli_connect($servername, $username, $password,$db);

// Check connection
if (!$conn) {
  die("Connection failed: " . mysqli_connect_error());
}

$sql ="INSERT INTO ProfileRoutines(idRoutine,creative,username,instrument)
VALUES(" . $idRoutine . "," .$creative.",'" .$user ."','".$instrument."')";
if ($conn->query($sql) === TRUE) {
    echo "New PlayerRoutines created successfully";
    } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
    }
$conn->close();
?>