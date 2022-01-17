namespace CommonPassion_Backend.Data.ApiModels
{
    public class ApiLeague
    {
        public ResponseLeague[] response { get; set; }
        public ParametersLeague? parameters { get; set; }
        public Paging paging { get; set; }
    }

    public class ResponseLeague
    {
        public LeagueL league { get; set; }
        public Country country { get; set; }
        public Season[] seasons { get; set; }
    }

    public class ParametersLeague
    {
        public string id { get; set; }
    }
    public class LeagueL
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
        public Coverage coverage { get; set; }
    }

    public class Coverage
    {
        public Fixtures fixtures { get; set; }
        public bool standings { get; set; }
        public bool players { get; set; }
        public bool top_scorers { get; set; }
        public bool top_assists { get; set; }
        public bool top_cards { get; set; }
        public bool injuries { get; set; }
        public bool predictions { get; set; }
        public bool odds { get; set; }
    }

    public class Fixtures
    {
        public bool events { get; set; }
        public bool lineups { get; set; }
        public bool statistics_fixtures { get; set; }
        public bool statistics_players { get; set; }
    }

}
