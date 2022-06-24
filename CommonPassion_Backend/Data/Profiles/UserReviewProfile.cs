using CommonPassion_Backend.Data.Contracts.RequestModels;
using CommonPassion_Backend.Data.Contracts.ResponseModels;
using CommonPassion_Backend.Data.Entities;
using CommonPassion_Backend.Mediator.Commands.ReviewCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Profiles
{
    public class UserReviewProfile : AutoMapper.Profile
    {
        public UserReviewProfile()
        {
            CreateMap<UserReviewRequestModel, AddReviewCommand>();
            CreateMap<AddReviewCommand, UserReview>();
            CreateMap<UserReview, UserReviewResponseModel>();

        }
    }
}
