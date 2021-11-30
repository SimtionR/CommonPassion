using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.ApiModels
{
    public class ApiPlayerStanding
    {
        public string get { get; set; }
        public Parameters parameters { get; set; }
        public object[] errors { get; set; }
        public int results { get; set; }
        public Paging paging { get; set; }
        public ResponsePlayerStanding[] response { get; set; }
    }

    public class ResponsePlayerStanding
    {
        public Player player { get; set; }
        public Statistic[] statistics { get; set; }
    }

}
