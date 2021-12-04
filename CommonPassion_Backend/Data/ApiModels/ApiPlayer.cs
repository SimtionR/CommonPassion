﻿using System;
namespace CommonPassion_Backend.Data.ApiModels
{
    public class ApiPlayer
    {
    
        
            public string get { get; set; }
            public Parameters parameters { get; set; }
            public object[] errors { get; set; }
            public int results { get; set; }
            public Paging paging { get; set; }
            public Response[] response { get; set; }
        
    }
        public class Parameters
        {
            public string league { get; set; }
            public string search { get; set; }
            public string id { get; set; }
            public string page { get; set; }
            public string team { get; set; }
            public string season { get; set; }
            public string fixture { get; set; }
        }
    public class Paging
    {
        public int current { get; set; }
        public int total { get; set; }
    }

    public class Response
    {
        public Player player { get; set; }
        public Statistic[] statistics { get; set; }
        public Team team { get; set; }  // in plus de la inGame req
        public Players[] players { get; set; } // same
    }

    public class Players
    { 
        public Player1 player { get; set; }
        public Statistic[] statistics { get; set; }
    }
    public class Player1 // clasa in plus
    {
        public int id { get; set; }
        public string name { get; set; }
        public string photo { get; set; }
    }

public class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int? age { get; set; }
        public Birth birth { get; set; }
        public string nationality { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public bool injured { get; set; }
        public string photo { get; set; }
    }

    public class Birth
    {
        public string date { get; set; }
        public string place { get; set; }
        public string country { get; set; }
    }

    public class Statistic
    {
        public Team team { get; set; }
        public LeagueWithStanding league { get; set; }
        public Games games { get; set; }
        public int? offsides { get; set; } // in plus de la in game
        public Substitutes substitutes { get; set; }
        public Shots shots { get; set; }
        public Goals goals { get; set; }
        public Passes passes { get; set; }
        public Tackles tackles { get; set; }
        public Duels duels { get; set; }
        public Dribbles dribbles { get; set; }
        public Fouls fouls { get; set; }
        public Cards cards { get; set; }
        public Penalty penalty { get; set; }
    }

    public class Team
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
        public string country { get; set; }//added team
        public int? founded { get; set; }// added teamApi
        public bool national { get; set; }//same
    }

    public class LeagueWithStanding
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string logo { get; set; }
        public string flag { get; set; }
        public object season { get; set; }
        public Standing[][] standings { get; set; } // added from standings 
    }

    public class Games
    {
        public int? appearences { get; set; }
        public int? lineups { get; set; }
        public int? minutes { get; set; }
        public object number { get; set; }
        public string position { get; set; }
        public string rating { get; set; }
        public bool captain { get; set; }
        public bool substitute { get; set; }// 1 
    }

    public class Substitutes
    {
        public int? _in { get; set; }
        public int? _out { get; set; }
        public int? bench { get; set; }
    }

    public class Shots
    {
        public int? total { get; set; }
        public int? on { get; set; }
    }

    public class Goals
    {
        public int? total { get; set; }
        public int? conceded { get; set; }
        public int? assists { get; set; }
        public object saves { get; set; }
    }

    public class Passes
    {
        public int? total { get; set; }
        public int? key { get; set; }
        public Object? accuracy { get; set; } // changed to object because it can be eitehr int/ string
        

    }

    public class Tackles
    {
        public int? total { get; set; }
        public int? blocks { get; set; }
        public int? interceptions { get; set; }
    }

    public class Duels
    {
        public int? total { get; set; }
        public int? won { get; set; }
    }

    public class Dribbles
    {
        public int? attempts { get; set; }
        public int? success { get; set; }
        public object past { get; set; }
    }

    public class Fouls
    {
        public int? drawn { get; set; }
        public int? committed { get; set; }
    }

    public class Cards
    {
        public int? yellow { get; set; }
        public int? yellowred { get; set; }
        public int? red { get; set; }
    }

    public class Penalty
    {
        public object won { get; set; }
        public object commited { get; set; }
        public int? scored { get; set; }
        public int? missed { get; set; }
        public object saved { get; set; }
    }



}

