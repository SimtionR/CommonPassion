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
    public class GetProfileByUserIdQueryHandler : IRequestHandler<GetProfileByUserIdQuery, Profile>
    {
        private readonly IProfileService _repo;

        public GetProfileByUserIdQueryHandler(IProfileService repo)
        {
            _repo = repo;
        }
        public async Task<Profile> Handle(GetProfileByUserIdQuery request, CancellationToken cancellationToken)
        {
            var profile = await _repo.GetProfileByUserId(request.userId);
            return profile;
        }

       
    }
}
