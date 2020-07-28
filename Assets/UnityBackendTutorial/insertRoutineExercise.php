<?php
$servername = "sql7.freemysqlhosting.net";
$username = "sql7357116";
$password = "VUvRPyhQ59";
$db = "sql7357116";
$idRoutine = $_POST["idRoutine"];
$idExercise = $_POST["idExercise"];
// Create connection
$conn = mysqli_connect($servername, $username, $password,$db);

// Check connection
if (!$conn) {
  die("Connection failed: " . mysqli_connect_error());
}

$sql = "Select * from ExercisesInRoutines Where idRoutine =".$idRoutine. " AND idExercise =".$idExercise;
$result = $conn->query($sql);
if ($result->num_rows > 0) {
    echo "ExercisesInRoutines already created";
} else {
    $sql = "INSERT INTO ExercisesInRoutines(idRoutine,idExercise)
    VALUES(". $idRoutine .",".$idExercise.")";
    if ($conn->query($sql) === TRUE) {
        echo "New ExercisesInRoutines created successfully";
      } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
      }
}
$conn->close();
?>