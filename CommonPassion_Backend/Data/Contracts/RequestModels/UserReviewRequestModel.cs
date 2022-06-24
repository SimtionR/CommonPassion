using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Contracts.RequestModels
{
    public class UserReviewRequestModel
    {
        public int ProfileId { get; set; }
        public string Title { get; set; }
        public int LeagueId { get; set; }
        public string RewiewContent { get; set; }
        public double Rating { get; set; }
    }
}
