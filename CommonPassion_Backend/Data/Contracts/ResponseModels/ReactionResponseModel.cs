using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Contracts.ResponseModels
{
    public class ReactionResponseModel
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public int ProfileId { get; set; }
        public ProfileResponseModel Profile { get; set; }
        public bool IsLiked { get; set; }
        public bool IsDisliked { get; set; }
    }
}
