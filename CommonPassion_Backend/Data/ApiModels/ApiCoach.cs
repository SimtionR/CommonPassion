namespace CommonPassion_Backend.Data.ApiModels
{
    public class ApiCoach
    {


        public string get { get; set; }
        public ParametersCoach parameters { get; set; }
        public int results { get; set; }
        public Paging paging { get; set; }
        public ResponseCoach[] response { get; set; }
    }

        public class ParametersCoach
        {
            public string team { get; set; }
        }

        public class ResponseCoach
        {
            public int id { get; set; }
            public string name { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public int age { get; set; }
            public Birth birth { get; set; }
            public string nationality { get; set; }
            public string height { get; set; }
            public string weight { get; set; }
            public string photo { get; set; }
            public Team team { get; set; }
            public Career[] career { get; set; }
        }

    


        public class Career
        {
            public Team1 team { get; set; }
            public string start { get; set; }
            public string end { get; set; }
        }

        public class Team1
        {
            public int id { get; set; }
            public string name { get; set; }
            public string logo { get; set; }
        }

    }

