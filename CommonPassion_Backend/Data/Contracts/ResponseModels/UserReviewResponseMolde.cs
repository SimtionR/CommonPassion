using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Contracts.ResponseModels
{
    public class UserReviewResponseModel
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public string Title { get; set; }
        public ProfileResponseModel Profile { get; set; }
        public string RewiewContent { get; set; }
        public DateTime CommentDate { get; set; }
        public double Rating { get; set; }
        public int LeagueId { get; set; }
        public int NumberOfLikes { get; set; }
        public List<ReactionResponseModel> Likes { get; set; } = new List<ReactionResponseModel>();
        public int NumberOfDislikes { get; set; }
        public List<ReactionResponseModel> Dislikes { get; set; } = new List<ReactionResponseModel>();
    }
}
