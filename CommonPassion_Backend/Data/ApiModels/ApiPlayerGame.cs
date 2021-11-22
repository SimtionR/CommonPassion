using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.ApiModels
{
    public class ApiPlayerGame
    {
            public string get { get; set; }
            public ParametersPGame parameters { get; set; }
            public object[] errors { get; set; }
            public int results { get; set; }
            public Paging paging { get; set; }
            public ResponsePGame[] response { get; set; }
        }

        public class ParametersPGame
        {
            public string fixture { get; set; }
        }

      

        public class ResponsePGame
        {
            public TeamGame team { get; set; }
            public PlayerGame[] players { get; set; }
        }

        public class TeamGame
        {
            public int id { get; set; }
            public string name { get; set; }
            public string logo { get; set; }
            public DateTime update { get; set; }
        }

        public class PlayerGame
        {
            public Player1 player { get; set; }
            public StatisticGame[] statistics { get; set; }
        }

        public class Player1
        {
            public int id { get; set; }
            public string name { get; set; }
            public string photo { get; set; }
        }

        public class StatisticGame
        {
            public GamesG games { get; set; }
            public int? offsides { get; set; }
            public ShotsG shots { get; set; }
            public GoalsG goals { get; set; }
            public PassesG passes { get; set; }
            public TacklesG tackles { get; set; }
            public DuelsG duels { get; set; }
            public DribblesG dribbles { get; set; }
            public FoulsG fouls { get; set; }
            public CardsG cards { get; set; }
            public PenaltyG penalty { get; set; }
        }

        public class GamesG
        {
            public int minutes { get; set; }
            public int number { get; set; }
            public string position { get; set; }
            public string rating { get; set; }
            public bool captain { get; set; }
            public bool substitute { get; set; }
        }

        public class ShotsG
        {
            public int total { get; set; }
            public int on { get; set; }
        }

        public class GoalsG
        {
            public int? total { get; set; }
            public int conceded { get; set; }
            public int? assists { get; set; }
            public int? saves { get; set; }
        }

        public class PassesG
        {
            public int total { get; set; }
            public int key { get; set; }
            public string accuracy { get; set; }
        }

        public class TacklesG
        {
            public int? total { get; set; }
            public int blocks { get; set; }
            public int interceptions { get; set; }
        }

        public class DuelsG
        {
            public int total { get; set; }
            public int won { get; set; }
        }

        public class DribblesG
        {
            public int attempts { get; set; }
            public int success { get; set; }
            public int? past { get; set; }
        }

        public class FoulsG
        {
            public int drawn { get; set; }
            public int committed { get; set; }
        }

        public class CardsG
        {
            public int yellow { get; set; }
            public int red { get; set; }
        }

        public class PenaltyG
        {
            public int? won { get; set; }
            public int? commited { get; set; }
            public int scored { get; set; }
            public int missed { get; set; }
            public int? saved { get; set; }
        }

    }

