using CommonPassion_Backend.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Mediator.Queries.IdentityQueries
{
    public class GetValidUserQuery : IRequest<User>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
