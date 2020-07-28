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

$sql = "Select count(*) as total FROM ScaleExercise Where idExercise=".$idExercise+";";
$result = $conn->query($sql);
if ($result->num_rows > 0) {
    while($row = $result->fetch_assoc()) {
    echo ($row['total']);
    }
}
$conn->close();