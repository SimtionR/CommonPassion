using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Domain
{
    public class LeagueModel
    {
        public Response[] response { get; set; }
        public Parameters? parameters { get; set; }
        public Paging paging { get; set; }

        public class Response
        {
            public League league { get; set; }
            public Country country { get; set; }
            public Season[] seasons { get; set; }
        }

        public class Parameters
        {
            public string id { get; set; }
        }

        public class Paging
        {
            public int current { get; set; }
            public int total { get; set; }
        }

        public class League
        {
            public int id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string logo { get; set; }
        }

        public class Country
        {
            public string name { get; set; }
            public string code { get; set; }
            public string flag { get; set; }
        }

        public class Season
        {
            public int year { get; set; }
            public string start { get; set; }
            public string end { get; set; }
            public bool current { get; set; }

        }
    }
}
