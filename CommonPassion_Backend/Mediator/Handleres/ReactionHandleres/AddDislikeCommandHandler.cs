using CommonPassion_Backend.Data.Entities;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Mediator.Commands.ReactionCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Mediator.Handleres.ReactionHandleres
{
    public class AddDislikeCommandHandler : IRequestHandler<AddDislikeCommand, Reactions>
    {
        private readonly IReactionService _repo;
        public AddDislikeCommandHandler(IReactionService repo)
        {
            _repo = repo;
        }
        public async Task<Reactions> Handle(AddDislikeCommand request, CancellationToken cancellationToken)
        {
            var reaction = await _repo.DislikeReviewAsync(request.ReviewId, request.ProfileId);
            return reaction;
        }

        
    }
}
