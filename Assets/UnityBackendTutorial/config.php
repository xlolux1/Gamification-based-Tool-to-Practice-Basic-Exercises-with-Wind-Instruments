


<?php
$servername="sql7.freemysqlhosting.net"; //replace with your hostname

$username = "sql7350526"; //replace with your admin username

$password = "aBYDFDS6pD"; //password of your admin

$db = "sql7350526";
// Create connection
$conn = mysqli_connect($servername, $username, $password,$db);
// Check connection
if (!$conn) {
   die("Connection failed: " . mysqli_connect_error());
}
echo "Connected successfully";

$sql = "SELECT count(*) FROM Player";
$result = $conn->query($sql);
if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    echo "id: " . $row["id"]. " - Name: " . $row["firstname"]. " " . $row["lastname"]. "<br>";
  }
} else {
  echo "0 results";
}
$conn->close();
?>