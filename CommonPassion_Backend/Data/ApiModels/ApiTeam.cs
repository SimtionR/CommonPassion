using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.ApiModels
{
    public class ApiTeam
    {
        public string get { get; set; }
        public ParametersTeam parameters { get; set; }
        public object[] errors { get; set; }
        public int results { get; set; }
        public Paging paging { get; set; }

        public ResponseTeam[] response { get; set; } //ResponseTeam from ApiTeam
     

        public class ApiAvaialbleSeasons
        {
            public Paging paging { get; set; }
            public int[] response { get; set; }

        }

        public class ParametersTeam
        {
            public string id { get; set; }
            public string league { get; set; }
            public string season { get; set; }
            public string team { get; set; }
        }


        public class ResponseTeam // Rp from ApiTeam
        {
            public Team? team { get; set; }
            public Venue? venue { get; set; }
            public string? leagueN { get; set; }
            public string ?season { get; set; }
            public League? league { get; set; }
            public string? form { get; set; }
            public Fixtures? fixtures { get; set; }
            public GoalsTeam? goals { get; set; }
            public Biggest? biggest { get; set; }
            public Clean_Sheet? clean_sheet { get; set; }
            public Failed_To_Score? failed_to_score { get; set; }
            public PenaltyT? penalty { get; set; }
            public Lineup[]? lineups { get; set; }
            //public CardsT cards { get; set; }
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

        public class LeagueStats
        {
            public int id { get; set; }
            public string name { get; set; }
            public string country { get; set; }
            public string logo { get; set; }
            public string flag { get; set; }
            public int season { get; set; }
        }



        public class Fixtures
        {
            public Played played { get; set; }
            public Wins wins { get; set; }
            public Draws draws { get; set; }
            public Loses loses { get; set; }
        }

        public class Played
        {
            public int home { get; set; }
            public int away { get; set; }
            public int total { get; set; }
        }

        public class Wins
        {
            public int home { get; set; }
            public int away { get; set; }
            public int total { get; set; }
        }

        public class Draws
        {
            public int home { get; set; }
            public int away { get; set; }
            public int total { get; set; }
        }

        public class Loses
        {
            public int home { get; set; }
            public int away { get; set; }
            public int total { get; set; }
        }

        public class GoalsTeam
        {
            public For _for { get; set; }
            public Against against { get; set; }
        }

        public class For
        {
            public Total total { get; set; }
            public Average average { get; set; }
            // public Minute minute { get; set; }
        }

        public class Total
        {
            public int home { get; set; }
            public int away { get; set; }
            public int total { get; set; }
        }

        public class Average
        {
            public string home { get; set; }
            public string away { get; set; }
            public string total { get; set; }
        }

        /* public class Minute
         {
             public _015 _015 { get; set; }
             public _1630 _1630 { get; set; }
             public _3145 _3145 { get; set; }
             public _4660 _4660 { get; set; }
             public _6175 _6175 { get; set; }
             public _7690 _7690 { get; set; }
             public _91105 _91105 { get; set; }
             public _106120 _106120 { get; set; }
         }

         public class _015
         {
             public int total { get; set; }
             public string percentage { get; set; }
         }

         public class _1630
         {
             public int total { get; set; }
             public string percentage { get; set; }
         }

         public class _3145
         {
             public int total { get; set; }
             public string percentage { get; set; }
         }

         public class _4660
         {
             public int total { get; set; }
             public string percentage { get; set; }
         }

         public class _6175
         {
             public int total { get; set; }
             public string percentage { get; set; }
         }

         public class _7690
         {
             public int total { get; set; }
             public string percentage { get; set; }
         }

         public class _91105
         {
             public int total { get; set; }
             public string percentage { get; set; }
         }

         public class _106120
         {
             public object total { get; set; }
             public object percentage { get; set; }
         }
     */
        public class Against
        {
            public Total1 total { get; set; }
            //public Average1 average { get; set; }
            //public Minute1 minute { get; set; }
        }

        public class Total1
        {
            public int home { get; set; }
            public int away { get; set; }
            public int total { get; set; }
        }

        /*public class Average1
        {
            public string home { get; set; }
            public string away { get; set; }
            public string total { get; set; }
        }

        public class Minute1
        {
            public _0151 _015 { get; set; }
            public _16301 _1630 { get; set; }
            public _31451 _3145 { get; set; }
            public _46601 _4660 { get; set; }
            public _61751 _6175 { get; set; }
            public _76901 _7690 { get; set; }
            public _911051 _91105 { get; set; }
            public _1061201 _106120 { get; set; }
        }

        public class _0151
        {
            public int total { get; set; }
            public string percentage { get; set; }
        }

        public class _16301
        {
            public int total { get; set; }
            public string percentage { get; set; }
        }

        public class _31451
        {
            public int total { get; set; }
            public string percentage { get; set; }
        }

        public class _46601
        {
            public int total { get; set; }
            public string percentage { get; set; }
        }

        public class _61751
        {
            public int total { get; set; }
            public string percentage { get; set; }
        }

        public class _76901
        {
            public int total { get; set; }
            public string percentage { get; set; }
        }

        public class _911051
        {
            public int total { get; set; }
            public string percentage { get; set; }
        }

        public class _1061201
        {
            public object total { get; set; }
            public object percentage { get; set; }
        }*/

        public class Biggest
        {
            public Streak streak { get; set; }
            public Wins1 wins { get; set; }
            public Loses1 loses { get; set; }
            public Goals1 goals { get; set; }
        }

        public class Streak
        {
            public int wins { get; set; }
            public int draws { get; set; }
            public int loses { get; set; }
        }

        public class Wins1
        {
            public string home { get; set; }
            public string away { get; set; }
        }

        public class Loses1
        {
            public string home { get; set; }
            public object away { get; set; }
        }

        public class Goals1
        {
            public For1 _for { get; set; }
            public Against1 against { get; set; }
        }

        public class For1
        {
            public int home { get; set; }
            public int away { get; set; }
        }

        public class Against1
        {
            public int home { get; set; }
            public int away { get; set; }
        }

        public class Clean_Sheet
        {
            public int home { get; set; }
            public int away { get; set; }
            public int total { get; set; }
        }

        public class Failed_To_Score
        {
            public int home { get; set; }
            public int away { get; set; }
            public int total { get; set; }
        }

        public class PenaltyT
        {
            public Scored scored { get; set; }
            public Missed missed { get; set; }
            public int total { get; set; }
        }

        public class Scored
        {
            public int total { get; set; }
            public string percentage { get; set; }
        }

        public class Missed
        {
            public int total { get; set; }
            public string percentage { get; set; }
        }

        /*    public class CardsT
            {
                public Yellow yellow { get; set; }
                public Red red { get; set; }
            }

            public class Yellow
            {
                public _0152 _015 { get; set; }
                public _16302 _1630 { get; set; }
                public _31452 _3145 { get; set; }
                public _46602 _4660 { get; set; }
                public _61752 _6175 { get; set; }
                public _76902 _7690 { get; set; }
                public _911052 _91105 { get; set; }
                public _1061202 _106120 { get; set; }
            }

            public class _0152
            {
                public int total { get; set; }
                public string percentage { get; set; }
            }

            public class _16302
            {
                public int total { get; set; }
                public string percentage { get; set; }
            }

            public class _31452
            {
                public int total { get; set; }
                public string percentage { get; set; }
            }

            public class _46602
            {
                public int total { get; set; }
                public string percentage { get; set; }
            }

            public class _61752
            {
                public int total { get; set; }
                public string percentage { get; set; }
            }

            public class _76902
            {
                public int total { get; set; }
                public string percentage { get; set; }
            }

            public class _911052
            {
                public object total { get; set; }
                public object percentage { get; set; }
            }

            public class _1061202
            {
                public object total { get; set; }
                public object percentage { get; set; }
            }

            public class Red
            {
                public _0153 _015 { get; set; }
                public _16303 _1630 { get; set; }
                public _31453 _3145 { get; set; }
                public _46603 _4660 { get; set; }
                public _61753 _6175 { get; set; }
                public _76903 _7690 { get; set; }
                public _911053 _91105 { get; set; }
                public _1061203 _106120 { get; set; }
            }

            public class _0153
            {
                public object total { get; set; }
                public object percentage { get; set; }
            }

            public class _16303
            {
                public int total { get; set; }
                public string percentage { get; set; }
            }

            public class _31453
            {
                public object total { get; set; }
                public object percentage { get; set; }
            }

            public class _46603
            {
                public object total { get; set; }
                public object percentage { get; set; }
            }

            public class _61753
            {
                public object total { get; set; }
                public object percentage { get; set; }
            }

            public class _76903
            {
                public object total { get; set; }
                public object percentage { get; set; }
            }

            public class _911053
            {
                public object total { get; set; }
                public object percentage { get; set; }
            }

            public class _1061203
            {
                public object total { get; set; }
                public object percentage { get; set; }
            }*/

        public class Lineup
        {
            public string formation { get; set; }
            public int played { get; set; }
        }
    }
}

