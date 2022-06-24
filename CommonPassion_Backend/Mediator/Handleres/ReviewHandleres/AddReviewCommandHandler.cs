using AutoMapper;
using CommonPassion_Backend.Data.Entities;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Mediator.Commands.ReviewCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Mediator.Handleres.ReviewHandleres
{
    public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, UserReview>
    {
        private readonly IUserReviewService _repo;
        private readonly IMapper _mapper;
        public AddReviewCommandHandler(IUserReviewService repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<UserReview> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var userReview = _mapper.Map<UserReview>(request);
            userReview.CommentDate = DateTime.Now;
            userReview.NumberOfDislikes = 0;
            userReview.NumberOfLikes = 0;
            return await _repo.CreateUserReviewAsync(userReview);
        }

       
    }
}
