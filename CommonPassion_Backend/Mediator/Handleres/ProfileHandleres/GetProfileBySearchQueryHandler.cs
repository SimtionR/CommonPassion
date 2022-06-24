using CommonPassion_Backend.Data.Entities;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Mediator.Queries.ProfileQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Mediator.Handleres.ProfileHandleres
{
    public class GetProfileBySearchQueryHandler : IRequestHandler<GetProfilesBySearchQuery, IEnumerable<Profile>>
    {
        private readonly IProfileService _repo;
        public GetProfileBySearchQueryHandler(IProfileService repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<Profile>> Handle(GetProfilesBySearchQuery request, CancellationToken cancellationToken)
        {
            var profiles = await _repo.GetProfilesBySearchAsync(request.Search);

            return profiles;
        }

       
    }
}
