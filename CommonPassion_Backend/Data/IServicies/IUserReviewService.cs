using CommonPassion_Backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.IServicies
{
    public interface IUserReviewService
    {
        Task<UserReview> CreateUserReviewAsync(UserReview userReview);
        Task<bool> DeleteUserReviewAsync(int reviewId);
        Task<bool> EditRatingAsync(double rating);
        Task<bool> EditReviewComment(string comment);
        Task<bool> ReactToReviewe(int reviewId);
        Task<UserReview> GetReviewByIdAsync(int reviewId);
        Task<IEnumerable<UserReview>> GettAllReviewsByUserIdAsync(string userId);
        Task<IEnumerable<UserReview>> GetAllReviewsByLeagueIdAsync(int leagueId);
        Task<IEnumerable<UserReview>> GetAllReviewsByLeagueDetailsIdAsync(int leagueDetailsId);
    }
}
