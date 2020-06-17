using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;

public class ProfiDao{




    public string insertProfile(MySqlConnection connection,Player newPlayer,string instrument){
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText ="INSERT INTO Profi(username,instrument) Values('"+newPlayer.username+"','"+
        instrument+"')";
        UnityEngine.Debug.Log("INSERT INTO Profi(username,instrument) Values('"+newPlayer.username+"','"+
        instrument+"')");
        MySqlDataReader reader = cmd.ExecuteReader();
         reader.Close();

        return null;
    }

    public List<string> getInstruments(MySqlConnection connection,Player currentPlayer){
         List<string> listInstruments = new List<string>();
        MySqlCommand cmd = connection.CreateCommand();
        
        cmd.CommandText = "SELECT instrument FROM Profi Where username='"+currentPlayer.username+"';";
        
        MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read()){
            string _instrument = reader.GetString(0);
            UnityEngine.Debug.Log("INSTRUMENT"+_instrument);
            listInstruments.Add(_instrument);
        }
        reader.Close();
        return listInstruments;

    }

    public int selectProfile(MySqlConnection connection,Player currentPlayer,string instrument){
        int count = -1;
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT count(*) FROM Profi Where username='"+currentPlayer.username+"' AND instrument='"+instrument+"';";
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()){
             count = reader.GetInt32(0);
        }
        reader.Close();
        return count;
    }
}