
namespace CommonPassion_Backend.Controllers
{
    using CommonPassion_Backend.Data.Processors;
    using CommonPassion_Backend.Infrastrcture;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class HomeController : ApiController
    {


        [HttpGet]
        [Authorize]
        public ActionResult Get()
        {
         
             

            return Ok("works");
        }
        
    }
}
