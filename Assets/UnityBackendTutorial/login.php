<?php
$servername = "sql7.freemysqlhosting.net";
$username = "sql7357116";
$password = "VUvRPyhQ59";
$db = "sql7357116";
$loginUser = $_POST["loginUser"];
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
  // output data of each row
  while($row = $result->fetch_assoc()) {
   if($row["password"] == $loginPass){
     $arr = array('username' => $row['username'], 'name' => $row['name'], 'surname' => $row['surname'], 'email' => $row['email'], 'password' => $row['password']);
     echo json_encode($arr);
   }else{
     echo "Wrong";
   }
  }
} else {
  echo "Wrong";
}
$conn->close();
?>