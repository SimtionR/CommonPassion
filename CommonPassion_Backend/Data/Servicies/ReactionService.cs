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
    public class ReactionService : IReactionService
    {
        private readonly CommonPassionDbContext _ctx;
        private readonly IProfileService _profileRepository;
        private readonly IUserReviewService _userReviewRepository;
        public ReactionService(CommonPassionDbContext ctx, IProfileService profileRepository, IUserReviewService userReviewRepository)
        {
            _ctx = ctx;
            _profileRepository = profileRepository;
            _userReviewRepository = userReviewRepository;
        }

        public async Task<Reactions> DislikeReviewAsync(int reviewId, int profileId)
        {
            var reaction = await GetReactionAsync(reviewId, profileId);
            var userReview = await _userReviewRepository.GetReviewByIdAsync(reviewId);

            if (reaction == null)
            {
                var profile = await _profileRepository.GetProfileByProfileId(profileId);
                var Dislike = new Reactions
                {
                    IsDisliked = true,
                    IsLiked = false,
                    ProfileId = profileId,
                    ReviewId = reviewId,
                    Profile = profile
                };



                _ctx.Reactions.Add(Dislike);
                //_ctx.Update(userReview.NumberOfDislikes++);
                userReview.NumberOfDislikes++;

                await _ctx.SaveChangesAsync();

                return Dislike;
            }

            if (reaction.IsLiked)
            {
                reaction.IsLiked = false;
                reaction.IsDisliked = true;

                //_ctx.Update(userReview.NumberOfDislikes++);

                //_ctx.Update(userReview.NumberOfDislikes--);

                userReview.NumberOfDislikes++;
                userReview.NumberOfLikes--;

                await _ctx.SaveChangesAsync();

                return reaction;
            }

            if (reaction.IsDisliked)
            {
                reaction.IsDisliked = false;
                //_ctx.Update(userReview.NumberOfDislikes--);
                userReview.NumberOfDislikes--;

                await _ctx.SaveChangesAsync();

                return reaction;

            }
            reaction.IsDisliked = true;


            //_ctx.Update(userReview.NumberOfDislikes++);
            userReview.NumberOfDislikes++;

            await _ctx.SaveChangesAsync();

            return reaction;

        }

        public async Task<IEnumerable<Reactions>> GetDislikesAsync(int reviewId)
        {
            var dislikes = await _ctx.Reactions.Include(r => r.Profile).Where(r => r.ReviewId == reviewId).ToListAsync();

            return dislikes;
        }

        public async Task<IEnumerable<Reactions>> GetLikesAsync(int reviewId)
        {
            var likes = await _ctx.Reactions.Include(r => r.Profile).Where(r => r.ReviewId == reviewId).ToListAsync();

            return likes;
        }

        public async Task<Reactions> GetReactionAsync(int reviewId, int profileId)
        {
            var reaction = await _ctx.Reactions.Where(c => c.ReviewId == reviewId && c.ProfileId == profileId).FirstOrDefaultAsync();

            return reaction;
        }

        public async Task<Reactions> LikeReviewAsync(int reviewId, int profileId)
        {
            var reaction = await GetReactionAsync(reviewId, profileId);
            var userReview = await _userReviewRepository.GetReviewByIdAsync(reviewId);

            if (reaction == null)
            {
                var profile = await _profileRepository.GetProfileByProfileId(profileId);
                var Like = new Reactions
                {
                    IsDisliked = false,
                    IsLiked = true,
                    ProfileId = profileId,
                    ReviewId = reviewId,
                    Profile = profile
                };



                _ctx.Reactions.Add(Like);
                //_ctx.Update(userReview.NumberOfLikes++);
                userReview.NumberOfLikes++;

                await _ctx.SaveChangesAsync();

                return Like;
            }

            if (reaction.IsDisliked)
            {
                reaction.IsLiked = true;
                reaction.IsDisliked = false;

                //_ctx.Update(userReview.NumberOfLikes++);

                //_ctx.Update(userReview.NumberOfDislikes--);

                userReview.NumberOfLikes++;
                userReview.NumberOfDislikes--;

                await _ctx.SaveChangesAsync();

                return reaction;
            }

            if (reaction.IsLiked)
            {
                reaction.IsLiked = false;

                //_ctx.Update(userReview.NumberOfLikes--);
                userReview.NumberOfLikes--;


                await _ctx.SaveChangesAsync();

                return reaction;

            }
            reaction.IsLiked = true;

            // _ctx.Update(userReview.NumberOfLikes--);

            userReview.NumberOfLikes++;

            await _ctx.SaveChangesAsync();

            return reaction;
        }
    }
}

