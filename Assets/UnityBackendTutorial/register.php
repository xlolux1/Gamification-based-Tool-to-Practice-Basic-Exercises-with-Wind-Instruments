<?php
$servername = "sql7.freemysqlhosting.net";
$username = "sql7357116";
$password = "VUvRPyhQ59";
$db = "sql7357116";
$loginUser = $_POST["loginUser"];
$loginName = $_POST["loginName"];
$loginSurname = $_POST["loginSurname"];
$loginEmail = $_POST["loginEmail"];
$loginPass = $_POST["loginPass"];
// Create connection
$conn = mysqli_connect($servername, $username, $password,$db);

// Check connection
if (!$conn) {
  die("Connection failed: " . mysqli_connect_error());
}

$sql = "Select * from Player Where username = '" . $loginUser . "'";
$result = $conn->query($sql);
if ($result->num_rows > 0) {
    echo "Username is already taken.";
} else {
    $sql = "Insert into Player(username,name,surname,email,password)
    VALUES('" . $loginUser . "','" .$loginName."','" .$loginSurname."','" .$loginEmail."','" .$loginPass."')";
    if ($conn->query($sql) === TRUE) {
        echo "New player created successfully";
      } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
      }
}
$conn->close();
?>