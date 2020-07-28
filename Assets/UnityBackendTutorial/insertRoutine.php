<?php
$servername = "sql7.freemysqlhosting.net";
$username = "sql7357116";
$password = "VUvRPyhQ59";
$db = "sql7357116";
$idRoutine = $_POST["idRoutine"];
$description = $_POST["description"];
$finalDate = $_POST["finalDate"];
// Create connection
$conn = mysqli_connect($servername, $username, $password,$db);

// Check connection
if (!$conn) {
  die("Connection failed: " . mysqli_connect_error());
}

$sql ="INSERT INTO Routines(idRoutine,description,finalDate) 
VALUES(" . $idRoutine . ",'" .$description."','" .$finalDate ."')";
if ($conn->query($sql) === TRUE) {
    echo "New routine created successfully";
    } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
}

$conn->close();
?>