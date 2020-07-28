<?php
$servername = "sql7.freemysqlhosting.net";
$username = "sql7357116";
$password = "VUvRPyhQ59";
$db = "sql7357116";
$idExercise = $_POST["idExercise"];
$difficulty = $_POST["difficulty"];
$description = $_POST["description"];
$timeSignature = $_POST["timeSignature"];
$tune = $_POST["tune"];
$beats = $_POST["beats"];
// Create connection
$conn = mysqli_connect($servername, $username, $password,$db);

// Check connection
if (!$conn) {
  die("Connection failed: " . mysqli_connect_error());
}

$sql = "Select * from Exercise Where idExercise = " . $idExercise . ";";
$result = $conn->query($sql);
if ($result->num_rows > 0) {
    echo "idExercise is already taken.";
} else {
    $sql = "INSERT INTO Exercise(idExercise,difficulty,description,tune,signature,beats)
    VALUES(" . $idExercise . ",'" .$difficulty."','" .$description."','" .$tune."','" .$timeSignature."',".$beats.");";
    if ($conn->query($sql) === TRUE) {
        echo "New Exercise created successfully";
      } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
      }
}
$conn->close();
?>