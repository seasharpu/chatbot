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

        public async Task<User> getUser(int userid)
        {
            return await _context.Users.FindAsync(userid);
        }

        //RECENT DTO EDIT
        [HttpGet("{userid}")]
        public async Task<ActionResult<UserDto>> getUserDTO(User UserDTO)
        {
            var user = await _context.Users.FindAsync(UserDTO.Id);

            if (User == null)
            {
                return Challenge();
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
            };

            return Ok(userDto);
        }

        [HttpGet]
        public async Task<List<User>> getAllUsers()
        {
            return await _context.Users.ToListAsync();
        }


        [HttpPost]
        public async Task<IActionResult> newUser(string userName, string password)
        {
            var User = new User() { UserName = userName, Password = password };
            _context.Users.Add(User);
            await _context.SaveChangesAsync();
            return CreatedAtAction("getUser", new { id = User.Id }, User);
        }

        //RECENT DTO EDIT
        [HttpPut("{userid}")]
        public async Task<ActionResult<UserDto>> updateUser(UserDto userDto)
        {
            var user = await getUser(userDto.Id);
           

            user.UserName = userDto.UserName;
            user.Password = userDto.Password;

            await _context.SaveChangesAsync();

            return Ok(User);
        }



        [HttpDelete("{userid}")]
        public async Task<IActionResult> deleteUser(int userid)
        {
            var user = await _context.Users.FindAsync(userid);
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