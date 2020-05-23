using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;

public class ProfiDao{




    public string insertProfile(MySqlConnection connection,Player newPlayer,string instrument,string tune){
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText ="INSERT INTO Profi(username,instrument) Values('"+newPlayer.username+"','"+
        instrument+"')";

        return null;
    }
    
}