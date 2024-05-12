using ForrealServerBL.Models;
using ForrealSever.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Numerics;
using System.Text.Json;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        #region get User ID
        [Route("GetUserID")]
        [HttpPost]
        public async Task<ActionResult> GetUserID([FromBody] string username)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == username);
                if (user != null)
                {
                    return Ok(user.Id);
                }
                else
                {
                    return NotFound(); // Or return a custom error message
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while processing your request."); // Or return a custom error message
            }
        }
        #endregion
        #region get Challange ID
        [Route("GetChallangeID")]
        [HttpPost]
        public async Task<ActionResult> GetChallangeID([FromBody] string challangename)
        {
            try
            {
                var challange = await context.Challenges.FirstOrDefaultAsync(u => u.Text == challangename);
                if (challange != null)
                {
                    return Ok(challange.Id);
                }
                else
                {
                    return NotFound(); // Or return a custom error message
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while processing your request."); // Or return a custom error message
            }
        }
        #endregion
        #region Get Challange name based on ID
        [Route("GetChallangeName")]
        [HttpPost]
        public async Task<ActionResult> GetChallangeName([FromBody] int id)
        {
            try
            {
                var challange = await context.Challenges.FirstOrDefaultAsync(ch => ch.Id == id);
                if (challange != null)
                {
                    return Ok(challange.Text);
                }
                else
                {
                    return NotFound(); // Or return a custom error message
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while processing your request."); // Or return a custom error message
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
            DateTime time = DateTime.Now;
            string day = time.Day.ToString(); string month = time.Month.ToString(); string year=time.Year.ToString();
            string date = day + "_" + month + "_" + year;
            var p = JsonSerializer.Deserialize<PostDto>(post);
            var user = context.Users.Where((u) => u.UserName == p.username).FirstOrDefault();
            var challenge= context.Challenges.Where((ch) => ch.Text== p.challengename).FirstOrDefault();

            if (file.Length > 0&& challenge!=null&&user!=null)
            {
                string FileName = $"{user.Id}_{challenge.Id}_{date}{Path.GetExtension(file.FileName)}";
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
        #region Get Images from the server
        [Route("GetImages")]
        [HttpGet]
        public async Task<ActionResult> GetImages()
        {
            ObservableCollection<string> images = new ObservableCollection<string>();
            var posts = context.UsersChallenges.ToList();
            foreach(var p in posts)
            {
                images.Add(p.Media);
            }
            return Ok(images);
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
        #region get all users with ID
        [Route("GetAllUsersWithID")]
        [HttpGet]
        public async Task<ActionResult> GetAllUsersWithID()
        {
            List<UserNameDto> usernames = new List<UserNameDto>();
            List<User> users = context.Users.ToList();
            foreach (var u in users)
            {
                usernames.Add(new UserNameDto() { id = u.Id, text = u.UserName });
            }
            return Ok(usernames);
        }
         #endregion
        #region get all challnges with ID
        [Route("GetAllChallanges")]
        [HttpGet]
        public async Task<ActionResult> GetAllChallanges()
        {
            List<ChallangeNameDto> challangenames = new List<ChallangeNameDto>();
            List<Challenge> challenges = context.Challenges.ToList();
            foreach (var ch in challenges)
            {
                challangenames.Add(new ChallangeNameDto() { id = ch.Id, text = ch.Text });
            }
            return Ok(challangenames);
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
        #region delete friend request
        [Route("EnemyRequest")]
        [HttpPost]
        public async Task<IActionResult> EnemyRequest([FromBody] FriendDto f)
        {
            try
            {
                var user1 = context.Users.Where((u) => u.UserName == f.username1).FirstOrDefault();
                var user2 = context.Users.Where((u) => u.UserName == f.username2).FirstOrDefault();
                var friend = context.Friends.Where((fr) => fr.User1Id == user1.Id);
                var friend2 = friend.Where((fr)=>fr.User2Id==user2.Id).FirstOrDefault();
                context.Friends.Remove(friend2);
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
            var user = context.Users.Where(u => u.UserName == username).FirstOrDefault();
            ObservableCollection<string> Friends = new ObservableCollection<string>();
            if (user != null)
            {
                var f1 = context.Friends.Where(f => f.User1Id == user.Id).ToList();
                foreach (var friend in f1)
                {
                    int wanted_id = friend.User2Id;
                    var wanted_user = context.Users.Where(u => u.Id == wanted_id).FirstOrDefault();
                    if (wanted_user != null)
                        Friends.Add(wanted_user.UserName);
                }
            }
            return Ok(Friends.ToList());
        }
        #endregion
        #region get Users that sent friend request to the user
        [Route("GetRequestFriends")]
        [HttpPost]
        public async Task<ActionResult> GetRequestFriends([FromBody] string username)
        {
            var user = context.Users.Where((u) => u.UserName == username).FirstOrDefault();
            ObservableCollection<string> Friends = new ObservableCollection<string>();
            if (user != null)
            {
                var f2 = context.Friends.Where((f) => f.User2Id == user.Id).ToList();
                foreach (var friend in f2)
                {
                    int wanted_id = friend.User1Id;
                    var wanted_user = context.Users.Where((u) => u.Id == wanted_id).FirstOrDefault();
                    Friends.Add(wanted_user.UserName);
                }          
            }
            return Ok(Friends.ToList());
        }
        #endregion
        #region add a comment to a post
        [Route("AddComment")]
        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] MessageDto m)
        {
            try
            {
                var user = context.Users.Where((u) => u.UserName == m.username).FirstOrDefault();
                var ch = context.Challenges.Where((ch) => ch.Text == m.challangename).FirstOrDefault();
                var usersent = context.Users.Where((u) => u.UserName == m.usernamesent).FirstOrDefault();
                var posts = context.UsersChallenges;
                
                var time = DateTime.Now;
                string day = time.Day.ToString(); string month = time.Month.ToString(); string Year = time.Year.ToString();
                foreach (var post in posts)
                {
                    var data = CreatePostData(post.Media);
                    if (data.Date == DateTime.Now.Date&& data.ChallengeId==ch.Id&& data.UserId==user.Id)
                    {
                        Message message = new Message() { UserChId = post.Id, UserSentId = usersent.Id, Time = time, Message1 = m.text };
                        context.Messages.Add(message);
                        context.SaveChanges();
                        return Ok();
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return BadRequest();
        }
        #endregion
        #region Get all comments of a post
        [Route("GetPostComments")]
        [HttpPost]
        public async Task<ActionResult> GetPostComments([FromBody] PostDto postdto)
        {
            try
            {
                List<ChatDto> chats = new List<ChatDto>();
                var user = context.Users.Where((u) => u.UserName == postdto.username).FirstOrDefault();
                var ch = context.Challenges.Where((ch) => ch.Text == postdto.challengename).FirstOrDefault();
                var posts = context.UsersChallenges.Where((p) => p.UserId == user.Id && p.ChallengeId == ch.Id);
                foreach (var post in posts)
                {
                    var data = CreatePostData(post.Media);
                    if (data.Date == DateTime.Now.Date)
                    {
                        var messages = context.Messages.Where((msg) => msg.UserChId == post.Id);
                        foreach (var message in messages)
                        {
                            ChatDto chat = new ChatDto() { username = message.UserSent.UserName, text = message.Message1, time = message.Time };
                            chats.Add(chat);
                        }
                        return Ok(chats);
                    }
                }
                return BadRequest();
             }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        #endregion
        #endregion
        private PostData CreatePostData(string name)
        {
            PostData postData = new PostData();
            var infoes = name.Split('_');
            string[] infofoes = null;
            if (infoes.Length > 3)
            {
                infofoes = infoes[4].Split(".");

                postData.UserId = Int32.Parse(infoes[0]);
                postData.Date = new DateTime(Int32.Parse(infofoes[0]), Int32.Parse(infoes[3]), Int32.Parse(infoes[2]));
                postData.ChallengeId = Int32.Parse(infoes[1]);
                postData.FileType = infofoes[1];

            }
            return postData;
        }
    }
}
