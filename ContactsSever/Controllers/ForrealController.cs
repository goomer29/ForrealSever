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
        readonly Random random;
        public ForrealController(ForrealDbContext context)
        {
            this.context = context;
            random = new Random();
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
        [Route("GetChallenge")]
        [HttpGet]
        public async Task<ActionResult> GetChallenge([FromQuery]int difficult)
        {
            List<Challenge> challenges = context.Challenges.Where(x => x.Difficult == difficult).ToList();
            if(challenges.Count == 0)   
                return Ok(null);
            int num = random.Next(0, challenges.Count);
            if (challenges[num]!=null)
            return Ok(challenges[num]);
            return Conflict();
        }
        #endregion

    }
}
