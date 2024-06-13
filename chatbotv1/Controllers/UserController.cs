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


        private async Task<User?> getUserInternal(int userid)
        {
            return await _context.Users.FindAsync(userid);
        }

        //RECENT DTO EDIT
        [HttpGet("{userid}")]
        public async Task<ActionResult<UsernameDto>> getUser(int userid)
        {
            var user = await getUserInternal(userid);

            if (user == null)
            {
                return BadRequest();
            }

            var dto = new UsernameDto()
            {
                Id = user.Id,
                UserName = user.UserName,
            };

            return dto;
        }

        //RECENT DTO EDIT
        [HttpGet]
        public async Task<List<UsernameDto>> getAllUsers()
        {
            var users = await _context.Users.ToListAsync();

            List<UsernameDto> userList = users.ConvertAll(user => new UsernameDto
            {
                Id = user.Id,
                UserName = user.UserName,
            });

            return userList;
        }


        [HttpPost]
        public async Task<IActionResult> newUser(string userName, string password)
        {
            var User = new User() { UserName = userName, Password = password };
            _context.Users.Add(User);
            await _context.SaveChangesAsync();
            return CreatedAtAction("getUserInternal", new { id = User.Id }, User);
        }

        //RECENT DTO EDIT
        [HttpPut("{userid}")]
        public async Task<ActionResult<UsernameDto>> updateUser(UsernameAndPasswordDto usernameAndPasswordDto)
        {
            var user = await getUserInternal(usernameAndPasswordDto.Id);
            if (user == null)
            {
                return BadRequest();
            }
            user.UserName = usernameAndPasswordDto.UserName;
            user.Password = usernameAndPasswordDto.Password;

            await _context.SaveChangesAsync();

            var dto = new UsernameDto()
            {
                Id = user.Id,
                UserName = user.UserName,
            };

            return Ok(dto);
        }



        [HttpDelete("{userid}")]
        public async Task<IActionResult> deleteUser(int userid)
        {
            var user = await getUserInternal(userid);
            
            if (user == null)
            {
                return BadRequest();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}