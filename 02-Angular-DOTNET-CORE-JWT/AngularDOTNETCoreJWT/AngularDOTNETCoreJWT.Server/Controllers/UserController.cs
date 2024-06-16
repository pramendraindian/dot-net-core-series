using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AngularDOTNETCoreJWT.Server.Policies;

namespace AngularDOTNETCoreJWT.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("GetUserData")]
        [Authorize(Policy = Policies.User)]
        public IActionResult GetUserData()
        {
            return Ok("I am a customer of this site!!");
        }

        [HttpGet]
        [Route("GetAdminData")]
        [Authorize(Policy = Policies.Admin)]
        public IActionResult GetAdminData()
        {
            return Ok("Heyyyy !! Admin here...");
        }
    }
}
