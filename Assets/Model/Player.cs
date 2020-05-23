using System;
using System.Collections;
using System.Collections.Generic;
public class Player{
    public string name;
    public string surname;
    public string email;
    public string username;
    public string password;
    List<Profile> profiles;


    public Player(string _username,string _name, string _surname,string _email,string _password){
        this.name = _name;
        this.surname = _surname;
        this.email = _email;
        this.username = _username;
        this.password = _password;

    }

    public  void createProfile(string instrumentName,string tone){
        //TO DO (Create a profile)
    }


}