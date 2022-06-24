using CommonPassion_Backend.Data.Contracts.ResponseModels;
using CommonPassion_Backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Profiles
{
    public class ProfileUserProfile : AutoMapper.Profile
    {
        public ProfileUserProfile()
        {
            CreateMap<Profile, ProfileResponseModel>().ReverseMap();
        }




    }
}
