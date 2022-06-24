using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Entities
{
    public class LeagueDetails
    {
        public int Id { get; set; }
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public List<UserReview> UsersReview { get; set; } = new List<UserReview>();
    }
}
