using AutoMapper;
using CommonPassion_Backend.Data.Contracts.RequestModels;
using CommonPassion_Backend.Data.Contracts.ResponseModels;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Mediator.Commands.ReviewCommands;
using CommonPassion_Backend.Mediator.Queries.ReviewQueries;
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
    public class ReviewController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IProfileService _repo;
        public ReviewController(IMediator mediator, IMapper mapper, IProfileService repo)
        {
            _mediator = mediator;
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost]
        [Route("createUserReview/{movieId}")]
        public async Task<ActionResult<UserReviewResponseModel>> CreateUserReview(UserReviewRequestModel userReviewModel, int leagueId)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);

            var profile = await _repo.GetProfileByUserId(userId);
            var profileId = profile.Id;

            userReviewModel.ProfileId = profileId;
            userReviewModel.LeagueId = leagueId;

            var userReviewCommand = _mapper.Map<AddReviewCommand>(userReviewModel);

            var result = await _mediator.Send(userReviewCommand);

            if (result == null)
            {
                return BadRequest();
            }

            var reviewResponse = _mapper.Map<UserReviewResponseModel>(result);

            return reviewResponse;
        }

        [HttpGet]
        [Route("getUserReview/{reviewId}")]
        public async Task<ActionResult<UserReviewResponseModel>> GetUserReviewById(int reviewId)
        {
            var command = new GetReviewByIdQuery { ReviewId = reviewId };
            var result = await _mediator.Send(command);

            if (result == null)
            {
                return NotFound();
            }

            return _mapper.Map<UserReviewResponseModel>(result);
        }
        [HttpGet]
        [Route("reviews/{movieId}")]
        public async Task<IEnumerable<UserReviewResponseModel>> GetReviewsByMovieId(int leagueId)
        {
            var command = new GetReviewsByLeagueIdQuery { LeagueId = leagueId };
            var result = await _mediator.Send(command);

            var userReviewList = new List<UserReviewResponseModel>();
            foreach (var review in result)
            {
                var userReviewResponse = _mapper.Map<UserReviewResponseModel>(review);
                userReviewList.Add(userReviewResponse);
            }

            return userReviewList;
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("deleteReview/{reviewId}")]
        public async Task<ActionResult> DeleteReview(int reviewId)
        {
            var isDeleted = await _mediator.Send(new DeleteReviewCommand { ReviewId = reviewId });

            if (isDeleted)
            {
                return Ok();
            }

            return BadRequest();

        }
    }
}
