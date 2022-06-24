using CommonPassion_Backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.IServicies
{
    public interface IReactionService
    {
        public Task<Reactions> LikeReviewAsync(int reviewId, int profileId);
        public Task<Reactions> DislikeReviewAsync(int reviewId, int profileId);
        public Task<IEnumerable<Reactions>> GetLikesAsync(int reviewId);
        public Task<IEnumerable<Reactions>> GetDislikesAsync(int reviewId);
        public Task<Reactions> GetReactionAsync(int reviewId, int prpfileId);
    }
}
