using System;
using MySql.Data.MySqlClient;
public class ManagerConnection{
    string connectionString;
    MySqlConnection connection;

    public  MySqlConnection getConnection(){
        this.connection.Open();
        return this.connection;
    }
    public ManagerConnection(string _connectionString){
        this.connectionString = _connectionString;
        this.connection = new MySqlConnection(this.connectionString);
        //this.connection.Open();
    }


    public  void closeConnection(){
        this.connection.Close();
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
