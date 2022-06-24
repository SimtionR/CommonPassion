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
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, bool>
    {
        private readonly IUserReviewService _repo;
        public DeleteReviewCommandHandler(IUserReviewService repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            return await _repo.DeleteUserReviewAsync(request.ReviewId);
        }

        
    }
}
