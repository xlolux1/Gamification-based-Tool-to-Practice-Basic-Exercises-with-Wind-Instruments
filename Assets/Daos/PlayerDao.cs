using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;

namespace daos
{
    public class PlayerDao{

    public List<Player> getAllPlayers(MySqlConnection connection){
        List<Player> playersList = new List<Player>();
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = "select * from Player";
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()){
            string _username = reader.GetString(0);
            string _name = reader.GetString(1);
            string _surname = reader.GetString(2);
            string _email = reader.GetString(3);
            string _password = reader.GetString(4);
            Player newPlayer = new Player(_username,_name,_surname,_email,_password);
            playersList.Add(newPlayer);
        }
        return playersList;
    }

    public Player getPlayer_User_Password(MySqlConnection connection,string username,string password){
        Player selectedPlayer = null;
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = "Select * from Player Where username ="+"'"+username+"'"+" AND password="+"'"+password+"';";
         MySqlDataReader reader = cmd.ExecuteReader();
         UnityEngine.Debug.Log("Select * from Player Where username ="+"'"+username+"'"+" AND password="+"'"+password+"';");

        while (reader.Read()){
            string _username = reader.GetString(0);
            string _name = reader.GetString(1);
            string _surname = reader.GetString(2);
            string _email = reader.GetString(3);
            string _password = reader.GetString(4);
            UnityEngine.Debug.Log(_username+_name+_surname+_email+_password);

            selectedPlayer = new Player(_username,_name,_surname,_email,_password);
            
        }
        return selectedPlayer;
    }

    public string insertPlayer(MySqlConnection connection,Player newPlayer){
        string response = "OK";
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText= "INSERT INTO Player(username,name,surname,email,password) Values('"+newPlayer.username+"','"+
        newPlayer.name+"','"+newPlayer.surname+"','"+newPlayer.email+"','"+newPlayer.password+"');";
        UnityEngine.Debug.Log("INSERT INTO Player(username,name,surname,email,password) Values('"+newPlayer.username+"','"+
        newPlayer.name+"','"+newPlayer.surname+"','"+newPlayer.email+"','"+newPlayer.password+"');");
        MySqlDataReader reader = cmd.ExecuteReader();
        
        return response;
    }
}

}
