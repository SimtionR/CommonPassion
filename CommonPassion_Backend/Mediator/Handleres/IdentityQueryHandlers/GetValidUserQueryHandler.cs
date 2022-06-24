using CommonPassion_Backend.Data.Entities;
using CommonPassion_Backend.IServicies;
using CommonPassion_Backend.Mediator.Queries.IdentityQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Mediator.Handleres.IdentityQueryHandlers
{
    public class GetValidUserQueryHandler : IRequestHandler<GetValidUserQuery, User>
    {
        private readonly IUserService _repo;
        public GetValidUserQueryHandler(IUserService repo)
        {
            _repo = repo;
        }
        public async Task<User> Handle(GetValidUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _repo.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return null;
            }

            var isValidPasasword = await _repo.CheckPasswordAsync(user, request.Password);
            if (!isValidPasasword)
            {
                return null;
            }

            return user;

        }

        
    }
}
