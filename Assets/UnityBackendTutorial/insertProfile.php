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

$sql = "Select * from Profi Where username = '" . $user . "' AND instrument ='" .$instrument."';";
$result = $conn->query($sql);
if ($result->num_rows > 0) {
    echo "Profile already created.";
} else {
    $sql = "Insert into Profi(username,instrument)
    VALUES('" . $user . "','" .$instrument."')";
    if ($conn->query($sql) === TRUE) {
        echo "New profile created successfully";
      } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
      }
}
$conn->close();
?>