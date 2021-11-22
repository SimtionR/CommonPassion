using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.ApiModels
{
    public class ApiLeague
    {
        public ResponseLeague[] response { get; set; }
    }

    public class ResponseLeague
    {
        public LeagueL league { get; set; }
    }

    public class LeagueL
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string logo { get; set; }
    }

}
