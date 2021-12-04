namespace CommonPassion_Backend.Data.ApiModels
{
    public class ApiFixture
    {
            public string get { get; set; }
            public ParametersFixture parameters { get; set; }
            
            public int results { get; set; }
            public Paging paging { get; set; }
            public ResponseFixture[] response { get; set; }
        }

        public class ParametersFixture
        {
            public string date { get; set; }
        }

     

        public class ResponseFixture
        {
            public Fixture fixture { get; set; }
            public League league { get; set; }
            public Teams teams { get; set; }
            public GoalsLive goals { get; set; }
            public Score score { get; set; }
        }

        public class Fixture
        {
            public int id { get; set; }
            public string referee { get; set; }
            public string timezone { get; set; }
            public DateTime date { get; set; }
            public int timestamp { get; set; }
            public Periods periods { get; set; }
            public Venue venue { get; set; }
            public Status status { get; set; }
        }

        public class Periods
        {
            public int? first { get; set; }
            public int? second { get; set; }
        }

        public class Venue
        {
            public int? id { get; set; }
            public string name { get; set; }
            public string city { get; set; }
        }

        public class Status
        {
            public string _long { get; set; }
            public string _short { get; set; }
            public int? elapsed { get; set; }
        }

        public class League
        {
            public int id { get; set; }
            public string name { get; set; }
            public string country { get; set; }
            public string logo { get; set; }
            public string flag { get; set; }
            public int season { get; set; }
            public string round { get; set; }
        }

        public class Teams
        {
            public HomeLive home { get; set; }
            public AwayLive away { get; set; }
        }

        public class HomeLive
        {
            public int id { get; set; }
            public string name { get; set; }
            public string logo { get; set; }
            public bool? winner { get; set; }
        }

        public class AwayLive
        {
            public int id { get; set; }
            public string name { get; set; }
            public string logo { get; set; }
            public bool? winner { get; set; }
        }

        public class GoalsLive
        {
            public int? home { get; set; }
            public int? away { get; set; }
        }

        public class Score
        {
            public Halftime halftime { get; set; }
            public Fulltime fulltime { get; set; }
            public Extratime extratime { get; set; }
            public PenaltyLive penalty { get; set; }
        }

        public class Halftime
        {
            public int? home { get; set; }
            public int? away { get; set; }
        }

        public class Fulltime
        {
            public int? home { get; set; }
            public int? away { get; set; }
        }

        public class Extratime
        {
            public object home { get; set; }
            public object away { get; set; }
        }

        public class PenaltyLive
        {
            public object home { get; set; }
            public object away { get; set; }
        }

    }

