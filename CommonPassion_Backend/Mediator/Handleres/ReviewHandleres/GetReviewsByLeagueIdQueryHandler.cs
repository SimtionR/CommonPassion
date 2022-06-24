using CommonPassion_Backend.Data.Entities;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Mediator.Queries.ReviewQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Mediator.Handleres.ReviewHandleres
{
    public class GetReviewsByLeagueIdQueryHandler : IRequestHandler<GetReviewsByLeagueIdQuery, IEnumerable<UserReview>>
    {
        private readonly IUserReviewService _repo;
        public GetReviewsByLeagueIdQueryHandler(IUserReviewService repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<UserReview>> Handle(GetReviewsByLeagueIdQuery request, CancellationToken cancellationToken)
        {

            var userReviews = await _repo.GetAllReviewsByLeagueIdAsync(request.LeagueId);
            return userReviews;
        }
    }
}
