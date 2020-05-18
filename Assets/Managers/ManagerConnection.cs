using System;
using MySql.Data.MySqlClient;
public class ManagerConnection{

            public static void prueba()
        {
            string connetionString = null;
            MySqlConnection cnn=null ;
			connetionString = "server=sql7.freemysqlhosting.net;database=sql7340480;uid=sql7340480;pwd=kp5Jv9EDj2;port=3306";
            cnn = new MySqlConnection(connetionString);
            string idnumber="";
                cnn.Open();
                            
            MySqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "select * from Player";
                MySqlDataReader reader = cmd.ExecuteReader();

                UnityEngine.Debug.Log("CONNECTION");
                while (reader.Read())
                {
                idnumber = reader.GetString(0);
                }
                UnityEngine.Debug.Log("HI"+ idnumber);

        }
        public static void prueba1(){
            /**
            string server = "database-music.cszyigxlid5s.us-east-1.rds.amazonaws.com";
            string database = "database-music";
            string uid = "admin";
            string password = "nane123*";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

           MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                  MySqlCommand cmd = connection.CreateCommand();
                  cmd.CommandText = "Create TABLE Player(username varchar(255),name varchar(255),surname varchar(255),email varchar(255),password varchar(255),PRIMARY KEY (username))";
                MySqlDataReader reader = cmd.ExecuteReader();

                connection.Close();
                 UnityEngine.Debug.Log(" CONNECTION");
                UnityEngine.Debug.Log("FAIL CONNECTION");
                **/
            
        }
        
}
