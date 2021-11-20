using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.ApiModels
{
    public class ApiTeam
    {
        public ResponseTeam[] response { get; set; }
    }


    public class ResponseTeam
    {
        public Team team { get; set; }
        public Venue venue { get; set; }
    }

    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public int founded { get; set; }
        public bool national { get; set; }
        public string logo { get; set; }
    }

    public class Venue
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public int capacity { get; set; }
        public string surface { get; set; }
        public string image { get; set; }
    }
}


