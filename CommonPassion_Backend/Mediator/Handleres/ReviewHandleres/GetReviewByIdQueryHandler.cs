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
    public class GetReiewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, UserReview>
    {
        private readonly IUserReviewService _repo;

        public GetReiewByIdQueryHandler(IUserReviewService repo)
        {
            _repo = repo;
        }
        public async Task<UserReview> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetReviewByIdAsync(request.ReviewId);
        }

        
    }
}
