using System;
namespace CommonPassion_Backend.Data.ApiModels
{
    public class ApiStanding
    {
        public string get { get; set; }
        public ParametersStanding parameters { get; set; }
        public object[] errors { get; set; }
        public int results { get; set; }
        public Paging paging { get; set; }
        public ResponseStanding[] response { get; set; }
    }

    public class ParametersStanding
    {
        public string league { get; set; }
        public string season { get; set; }
    }


    public class ResponseStanding
    {
        public LeagueWithStanding league { get; set; }
    }


    public class Standing
    {
        public int rank { get; set; }
        public Team team { get; set; }
        public int points { get; set; }
        public int goalsDiff { get; set; }
        public string group { get; set; }
        public string form { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public All all { get; set; }
        public Home home { get; set; }
        public Away away { get; set; }
        public DateTime update { get; set; }
    }

   

    public class All
    {
        public int played { get; set; }
        public int win { get; set; }
        public int draw { get; set; }
        public int lose { get; set; }
        public GoalsTotal goals { get; set; }
    }

    public class GoalsTotal
    {
        public int _for { get; set; }
        public int against { get; set; }
    }

    public class Home
    {
        public int played { get; set; }
        public int win { get; set; }
        public int draw { get; set; }
        public int lose { get; set; }
        public GoalsHome goals { get; set; }
    }

    public class GoalsHome
    {
        public int _for { get; set; }
        public int against { get; set; }
    }

    public class Away
    {
        public int played { get; set; }
        public int win { get; set; }
        public int draw { get; set; }
        public int lose { get; set; }
        public GoalsAway goals { get; set; }
    }

    public class GoalsAway
    {
        public int _for { get; set; }
        public int? against { get; set; }
    }

    }

