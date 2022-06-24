using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Mediator.Commands.ReviewCommands
{
    public class DeleteReviewCommand : IRequest<bool>
    {
        public int ReviewId { get; set; }
    }
}
