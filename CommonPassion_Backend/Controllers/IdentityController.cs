namespace CommonPassion_Backend.Controllers
{
    using CommonPassion_Backend.Data.IServicies;
    using CommonPassion_Backend.Data.Models.Identity;
    using CommonPassion_Backend.Entities;
    using CommonPassion_Backend.Models;
    using CommonPassion_Backend.Settings;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System.Threading.Tasks;
    public class IdentityController : ApiController
    {
        private readonly UserManager<User> _userMananger;
        private readonly IIdentityService _identityService;
        private readonly AppSettings _appSettings;

        public IdentityController(UserManager<User> userManager, IOptions<AppSettings> appSettings, IIdentityService identityService)
        {
            this._userMananger = userManager;
            this._identityService = identityService;
            this._appSettings = appSettings.Value;
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
            var user = await this._userMananger.FindByNameAsync(model.UserName);
            if(user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await this._userMananger.CheckPasswordAsync(user, model.Password);
            
            if(!passwordValid)
            {
                return Unauthorized();
            }

            var encryptedToken= this._identityService.GenerateJwtToken(user.Id, user.UserName, this._appSettings.Secret);
      

            return new LoginResponseModel
            {
                Token = encryptedToken
            };

        }
        
    }
}
