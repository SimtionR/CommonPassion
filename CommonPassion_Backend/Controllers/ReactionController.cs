using AutoMapper;
using CommonPassion_Backend.Data.Contracts.ResponseModels;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Mediator.Commands.ReactionCommands;
using CommonPassion_Backend.Mediator.Queries.ReactionQueries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ReactionController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IProfileService _profileRepo;

        public ReactionController(IMediator mediator, IMapper mapper, IProfileService profileRepo)
        {
            _mediator = mediator;
            _mapper = mapper;
            _profileRepo = profileRepo;
        }


        [HttpPost]
        [Route("likeReview/{reviewId}")]
        public async Task<ActionResult<ReactionResponseModel>> LikeReview(int reviewId)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);

            var profile = await _profileRepo.GetProfileByUserId(userId);
            var profileId = profile.Id;

            var result = await _mediator.Send(new AddLikeCommand { ProfileId = profileId, ReviewId = reviewId });

            var reactionResponse = _mapper.Map<ReactionResponseModel>(result);
            return reactionResponse;
        }

        [HttpPost]
        [Route("dislikeReview/{reviewId}")]
        public async Task<ActionResult<ReactionResponseModel>> DislikeReview(int reviewId)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);

            var profile = await _profileRepo.GetProfileByUserId(userId);
            var profileId = profile.Id;

            var result = await _mediator.Send(new AddDislikeCommand { ProfileId = profileId, ReviewId = reviewId });

            var reactionResponse = _mapper.Map<ReactionResponseModel>(result);
            return reactionResponse;
        }
        [HttpGet]
        [Route("likes/{reviewId}")]
        public async Task<IEnumerable<ReactionResponseModel>> GetLikesForReview(int reviewId)
        {
            var result = await _mediator.Send(new GetLikesQuery { ReviewId = reviewId });
            var reactionResponseList = new List<ReactionResponseModel>();

            foreach (var reaction in result)
            {
                reactionResponseList.Add(_mapper.Map<ReactionResponseModel>(reaction));
            }

            return reactionResponseList;
        }

        [HttpGet]
        [Route("dislikes/{reviewId}")]
        public async Task<IEnumerable<ReactionResponseModel>> GetDislieksForReview(int reviewId)
        {
            var result = await _mediator.Send(new GetDislikesQuery { ReviewId = reviewId });
            var reactionResponseList = new List<ReactionResponseModel>();

            foreach (var reaction in result)
            {
                reactionResponseList.Add(_mapper.Map<ReactionResponseModel>(reaction));
            }

            return reactionResponseList;
        }

    }
}
