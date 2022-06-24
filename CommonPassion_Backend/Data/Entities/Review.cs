using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Entities
{
    public abstract class Review
    {
        public string Title { get; set; }
        public string RewiewContent { get; set; }
        public double Rating { get; set; }
        public DateTime CommentDate { get; set; }
        public int LeagueId { get; set; }
        public LeagueDetails LeagueReviewd { get; set; }
        public int NumberOfLikes { get; set; }
        public List<Reactions> Likes { get; set; } = new List<Reactions>();
        public int NumberOfDislikes { get; set; }
        public List<Reactions> Dislikes { get; set; } = new List<Reactions>();
    }
}
