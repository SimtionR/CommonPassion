using AutoMapper;
using CommonPassion_Backend.Data.Contracts.ResponseModels;
using CommonPassion_Backend.Data.IServicies;
using CommonPassion_Backend.Data.Servicies.BlobService;
using CommonPassion_Backend.Mediator.Queries.ProfileQueries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Controllers
{
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public class ProfileController : ApiController
        {
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IBlobStorageService _blobStorageService;
            private readonly string _blobCotnaienr = "profilepictures";
            private readonly IProfileService _repo;


            public ProfileController(IMediator mediator, IMapper mapper, IBlobStorageService blobStorageService, IProfileService repo)
            {
                _mediator = mediator;
                _mapper = mapper;
                _blobStorageService = blobStorageService;
                _repo = repo;

            }

            [HttpGet]
            [Route("userProfile")]
            public async Task<ActionResult<ProfileResponseModel>> GetProfileByUserId()
            {
                var userId = User.FindFirstValue(ClaimTypes.Name);


                var result = await _mediator.Send(new GetProfileByUserIdQuery { userId = userId });

                if (result == null)
                {
                    return NotFound();
                }

                return _mapper.Map<ProfileResponseModel>(result);

            }

            [HttpGet]
            [Route("profileId/{profileId}")]
            public async Task<ActionResult<ProfileResponseModel>> GetProfileByProfileId(int profileId)
            {
                var result = await _mediator.Send(new GetProfileByProfileIdQuery { profileId = profileId });

                if (result == null)
                {
                    return NotFound();
                }

                return _mapper.Map<ProfileResponseModel>(result);
            }
        }
}
