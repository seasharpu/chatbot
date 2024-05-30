using System.Collections;
using System.Text.Json;
using chatbotv1.Data;
using chatbotv1.Models.OpenAI;
using chatbotv1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace chatbotv1.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController(MyDBContext dbContext) : ControllerBase
    {
        private readonly MyDBContext _context = dbContext;

        [HttpGet("{userid}")]
        public async Task<User> getUser(int userid)
        {
            return await _context.Users.FindAsync(userid);
        }

        //NEWLY ADDED BY ALEX
        [HttpGet]
        public async Task<List<User>> getAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // PROBLEM
        [HttpPost]
        public async Task<IActionResult> newUser(string userName, string password)
        {
            var User = new User() { UserName = userName, Password = password };
            _context.Users.Add(User);
            await _context.SaveChangesAsync();
            return CreatedAtAction("getUser", new { id = User.Id }, User);
        }


        [HttpPut("{userid}")]
        public async Task<User> updateUser(int userid, string userName, string password)
        {
            var User = await getUser(userid);
            User.UserName = userName;
            User.Password = password;
            await _context.SaveChangesAsync();
            return User;
        }


        //NEWLY ADDED BY ALEX
        [HttpDelete("{userid}")]
        public async Task<IActionResult> deleteUser(int userid)
        {
            var user = await _context.Users.FindAsync(userid);
            if (user == null)
            {
                return Challenge();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}