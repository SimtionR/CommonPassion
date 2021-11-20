using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Entities
{
    public class Prediction
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }
        
        public string Description { get; set; }
        public string Result { get; set; }
        public int BettingOdds { get; set; }

    }
}
