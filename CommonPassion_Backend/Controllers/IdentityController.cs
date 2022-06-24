namespace CommonPassion_Backend.Controllers
{
    using CommonPassion_Backend.Data.Entities;
    using CommonPassion_Backend.Data.IServicies;
    using CommonPassion_Backend.Data.Models.Identity;
    using CommonPassion_Backend.Mediator.Commands;
    using CommonPassion_Backend.Mediator.Queries.IdentityQueries;
    using CommonPassion_Backend.Models;
    using CommonPassion_Backend.Settings;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System.Threading.Tasks;
    public class IdentityController : ApiController
    {
        private readonly UserManager<User> _userMananger;
        private readonly IIdentityService _identityService;
        private readonly AppSettings _appSettings;
        private readonly IMediator _mediator;
        

        public IdentityController(UserManager<User> userManager, IOptions<AppSettings> appSettings, IIdentityService identityService, IMediator mediator)
        {
            this._userMananger = userManager;
            this._identityService = identityService;
            this._appSettings = appSettings.Value;
            this._mediator = mediator;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(AuthRequestModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.Username,

            };
            var result = await this._userMananger.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(AuthResponseModel model)
        {
            //var user = await this._userMananger.FindByNameAsync(model.UserName);
            var user = await _mediator.Send(new GetValidUserQuery { UserName = model.UserName, Password = model.Password });
            if (user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await this._userMananger.CheckPasswordAsync(user, model.Password);
            
            if(!passwordValid)
            {
                return Unauthorized();
            }

            if(user.Profile == null)
            {
                var profile = await _mediator.Send(new AddProfileCommand { User = user });
                if (profile == null)
                    return BadRequest();
            }

            var encryptedToken= this._identityService.GenerateJwtToken(user.Id, user.UserName, this._appSettings.Secret);
      

            return new LoginResponseModel
            {
                Token = encryptedToken
            };

        }
        
    }
}
