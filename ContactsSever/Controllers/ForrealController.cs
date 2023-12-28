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
        ForrealDbContext context;
        public ForrealController(ForrealDbContext context)
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
        [Route("SignUp")]
        [HttpPost]
        public async Task<ActionResult<User>> SignUp([FromBody] SignUpDto usr)
        {
            User user = new User();
            //add user
            var u = context.Users.Any(us => us.UserName == usr.UserName);
            if (!u)
            {
                user.UserName = usr.UserName;
                user.UserPswd = usr.UserPswd;
                user.Email = usr.Email;
                context.Users.Add(user);
                context.SaveChanges();
                return Ok(user);
            }
            else
            {
                return Conflict();
            }
        }
        #endregion
    }
}
