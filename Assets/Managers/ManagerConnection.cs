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
    }


    public  void closeConnection(){
        this.connection.Close();
    }
        
}
