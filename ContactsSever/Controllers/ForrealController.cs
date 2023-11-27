using ForrealServerBL.Models;
using ForrealSever.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForrealSever.Controllers
{
    [Route ("ForrealApi")]
    [ApiController]
    public class ForrealController : ControllerBase
    {
        #region Add connection to the db contextt using depency injection
        ForrealDBContext context;
        public ForrealController(ForrealDBContext context)
        {
            this.context = context;
        }
        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<User>> Login([FromBody] LoginDto usr)
        {

            User user = null;
            //Search for user
            //Check user name and password
            user = context.Users.Where((u) => u.UserName == usr.UserName && u.UserPswd == usr.UserPswd).FirstOrDefault();

            if (user != null)
            {
                HttpContext.Session.SetObject("user", user);
                return Ok(user);
            }


            return Forbid();

        }
        #endregion
    }
}
