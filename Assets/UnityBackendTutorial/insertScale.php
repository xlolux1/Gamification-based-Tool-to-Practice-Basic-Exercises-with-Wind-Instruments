<?php
$servername = "sql7.freemysqlhosting.net";
$username = "sql7357116";
$password = "VUvRPyhQ59";
$db = "sql7357116";
$idExercise = $_POST["idExercise"];
$scaleTypes = $_POST["scaleTypes"];
$firstNote = $_POST["firstNote"];
$duration = $_POST["duration"];
// Create connection
$conn = mysqli_connect($servername, $username, $password,$db);

// Check connection
if (!$conn) {
  die("Connection failed: " . mysqli_connect_error());
}

$sql = "Select * from ScaleExercise Where idExercise = " . $idExercise.";";
$result = $conn->query($sql);
if ($result->num_rows > 0) {
    echo "Scale already created.";
} else {
    $sql = "INSERT INTO ScaleExercise(idExercise,typeScale,firstNote,duration)
    VALUES('" . $idExercise . "','" .$scaleTypes."','" .$firstNote."','" .$duration."')";
    if ($conn->query($sql) === TRUE) {
        echo "New Scale created successfully";
      } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
      }
}
$conn->close();
?>