using CommonPassion_Backend.Data.Entities;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Servicies
{
    public class UserReviewService : IUserReviewService
    {
        private readonly CommonPassionDbContext _ctx;
        private readonly ILeagueDetailsService _leagueDetailsService;

        public UserReviewService(CommonPassionDbContext ctx, ILeagueDetailsService leagueDetailsService)
        {
            _ctx = ctx;
            _leagueDetailsService = leagueDetailsService;
        }
        public async Task<UserReview> CreateUserReviewAsync(UserReview userReview)
        {
            var leagueDetails = await _ctx.LeagueDetails.Where(l => l.LeagueId == userReview.LeagueId).FirstOrDefaultAsync();
            if(leagueDetails == null)
            {
                throw new Exception("Can't be added because leagueDetails details is not ready");
            }
            _ctx.UserReviews.Add(userReview);
            await _ctx.SaveChangesAsync();

            leagueDetails.UsersReview.Add(userReview);
            await _ctx.SaveChangesAsync();

            return userReview;
        }

        public async Task<bool> DeleteUserReviewAsync(int reviewId)
        {

            var review = await GetReviewByIdAsync(reviewId);

            if (review != null)
            {
                _ctx.UserReviews.Remove(review);
                await _ctx.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public Task<bool> EditRatingAsync(double rating)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditReviewComment(string comment)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserReview>> GetAllReviewsByLeagueIdAsync(int leagueId)
        {
            var userReviews = await _ctx.UserReviews.Include(u => u.Profile).Where(u => u.LeagueId == leagueId).ToListAsync();
            return userReviews;
        }

        public Task<IEnumerable<UserReview>> GetAllReviewsByLeagueDetailsIdAsync(int leagueDetailsId)
        {
            throw new NotImplementedException();
        }

        public async Task<UserReview> GetReviewByIdAsync(int reviewId)
        {
            var review = await _ctx.UserReviews.Include(u => u.Profile).Where(r => r.Id == reviewId).FirstOrDefaultAsync();
            return review;
        }

        public Task<IEnumerable<UserReview>> GettAllReviewsByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ReactToReviewe(int reviewId)
        {
            throw new NotImplementedException();
        }
    }
}
