using CommonPassion_Backend.Data.Entities;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Mediator.Queries.ReactionQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Mediator.Handleres.ReactionHandleres
{
    public class GetDislikesQueryHandler : IRequestHandler<GetDislikesQuery, IEnumerable<Reactions>>
    {
        private readonly IReactionService _repo;
        public GetDislikesQueryHandler(IReactionService repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<Reactions>> Handle(GetDislikesQuery request, CancellationToken cancellationToken)
        {
            var reactions = await _repo.GetDislikesAsync(request.ReviewId);
            return reactions;
        }

        
    }
}
