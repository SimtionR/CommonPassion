
namespace CommonPassion_Backend.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Diagnostics;

    [ApiController]
    public class HomeController : ControllerBase
    {

        [Authorize]
        public IActionResult Get()
        {

            return Ok();
        }
        
    }
}
