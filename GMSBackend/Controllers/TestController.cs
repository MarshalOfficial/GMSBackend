using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMSBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        [AllowAnonymous]
        [HttpPost("getusertest")]
        public ActionResult GetUser()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            return Ok(new { User.Identity.Name, User.Identity.IsAuthenticated });
        }
    }
}
