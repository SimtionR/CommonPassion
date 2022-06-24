using CommonPassion_Backend.Data.Entities;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Mediator.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Mediator.Handleres
{
    public class AddProfileCommandHandler : IRequestHandler<AddProfileCommand, Profile>
    {
        private readonly IProfileService _repo;
        public AddProfileCommandHandler(IProfileService repo)
        {
            _repo = repo;
        }
        public async Task<Profile> Handle(AddProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = await _repo.CreateProfileAsync(request.User);
            return profile;
        }

       
    }
}
