using CommonPassion_Backend.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Mediator.Queries.ProfileQueries
{
    public class GetProfileByUserIdQuery : IRequest<Profile>
    {
        public string userId { get; set; }
    }
}
