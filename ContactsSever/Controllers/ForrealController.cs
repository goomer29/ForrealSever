﻿using ForrealServerBL.Models;
using ForrealSever.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.RegularExpressions;

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
        
        #region Login
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
        #region SignUp
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
        #region Get Challenges for dialy challenges
        [Route("GetChallenge")]
        [HttpGet]
        public async Task<ActionResult> GetChallenge()
        {
            Challenge[] ch=new Challenge[6];
            for(int i=1;i< 6; i++)
            {
                List<Challenge> challenges = context.Challenges.Where(x => x.Difficult == i).ToList();
                if (challenges.Count == 0 && i==1)
                    return Ok(null);
                if (challenges.Count != 0)
                {
                    int num = random.Next(0, challenges.Count);
                    if (challenges[num] != null)
                        ch[i] = challenges[num];
                }            
            }            
            return Ok(ch);
        }
        #endregion
        #region Upload Image to the server
        [Route("UploadImage")]
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file, [FromForm] string post)
        {
            var p = JsonSerializer.Deserialize<PostDto>(post);
            var user = context.Users.Where((u) => u.UserName == p.username).FirstOrDefault();
            var challenge= context.Challenges.Where((ch) => ch.Text== p.challengename).FirstOrDefault();

            if (file.Length > 0&& challenge!=null&&user!=null)
            {
                string FileName = $"{user.Id}-{challenge.Id}{Path.GetExtension(file.FileName)}";
                string path=Path.Combine(Directory.GetCurrentDirectory(), "Wwwroot/images", FileName);
                try
                {
                    using(var fileStream= new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    var user_challenge = new UsersChallenge();
                    user_challenge.Challenge = challenge; user_challenge.User = user; user_challenge.Media = FileName;
                    context.UsersChallenges.Add(user_challenge);
                    context.SaveChanges();
                    return Ok();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            return BadRequest();
        }
        #endregion
        #region get all users
        [Route("GetAllUsers")]
        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            List<User> users = context.Users.ToList();
            return Ok(users);
        }
        #endregion
        #region make freind request
        [Route("FriendRequest")]
        [HttpPost]
        public async Task<IActionResult> FreindRequest([FromBody] FriendDto f)
          {
            try
            {
                var user1 = context.Users.Where((u) => u.UserName == f.username1).FirstOrDefault();
                var user2 = context.Users.Where((u) => u.UserName == f.username2).FirstOrDefault();
                Friend friend = new Friend();
                friend.User1Id = user1.Id; friend.User2Id = user2.Id;
                context.Friends.Add(friend);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return BadRequest();
        }
        #endregion
        #region get Users which recived friend request by the user
        [Route("GetWantedFriends")]
        [HttpPost]
        public async Task<ActionResult> GetWantedFriends([FromBody] string username)
        {
            var user = context.Users.Where((u) => u.UserName == username).FirstOrDefault();
           List<User> Friends = new List<User>();
            List<User> Users = context.Users.ToList();
            var f1 = context.Friends.Where((f) => f.User1Id == user.Id).ToList();
            foreach (var friend in f1)
            {
                int wanted_id = friend.User2Id;
                var wanted_user = context.Users.Where((u) => u.Id == wanted_id).FirstOrDefault();
                Friends.Add(wanted_user);
            }
            return Ok(Friends);
        }
        #endregion
        #region get Users that sent friend request to the user
        [Route("GetRequestFriends")]
        [HttpGet]
        public async Task<ActionResult> GetRequestFriends(string username)
        {
            var user = context.Users.Where((u) => u.UserName == username).FirstOrDefault();
            List<User> Friends = new List<User>();
            List<User> Users = context.Users.ToList();
            var f2 = context.Friends.Where((f) => f.User2Id == user.Id).ToList();
            foreach (var friend in f2)
            {
                int wanted_id = friend.User1Id;
                var wanted_user = context.Users.Where((u) => u.Id == wanted_id).FirstOrDefault();
                Friends.Add(wanted_user);
            } 
            return Ok(Friends);
        }
        #endregion
        #endregion

    }
}
