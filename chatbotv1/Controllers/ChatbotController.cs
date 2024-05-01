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
    [Route("chatbot")]
    public class ChatbotController(OpenAIService openAIService, MyDBContext dbContext) : ControllerBase
    {
        private readonly OpenAIService _openAIService = openAIService;
        private readonly MyDBContext _context = dbContext;

        [HttpPost]
        public async Task<IActionResult> NewThread(int userid, string message)
        {
            var user = await _context.Users.FindAsync(userid);
            if (user == null)
            {
                return Challenge();
            }
            History history = new(user) { };
            _context.Conversations.Add(history);
            await _context.SaveChangesAsync();
            return await ContinueThread(userid, message, history.Id);
        }
        [HttpPost]
        public async Task<IActionResult> ContinueThread(int userid, string message, int historyid)
        {
            History? history = await _context.Conversations.FindAsync(historyid);
            if (history == null)
            {
                return BadRequest("Cannot find history");
            }
            var openAIUser = await _context.Users.FindAsync(1);
            var user = await _context.Users.FindAsync(userid);

            if (user == null)
            {
                return Challenge();
            }

            _context.UserQueries.Add(new UserQuery()
            {
                User = user,
                InputText = message,
                Created = DateTime.Now,
                History = history
            });

            var messageObject = new Message()
            {
                Content = message,
                Role = "user"
            };
            var response = await _openAIService.CreateRequest("chat/completions", new OpenAIRequest()
            {
                Messages = history.AddMessage(messageObject)
            });
            await _context.SaveChangesAsync();
            Response? responseObject = JsonSerializer.Deserialize<Response>(response.Content.ToString() ?? "");
            if (responseObject == null)
            {
                return BadRequest("Could not deserialize response object");
            }
            string responseMessage = responseObject.Choices[0].Message?.Content ?? "";

            return Ok(responseMessage);
        }
        [HttpGet("{userid}")]
        public async Task<ActionResult<IEnumerable<History>>> GetThreads(int userid)
        {
            var user = await _context.Users.FindAsync(userid);
            if (user == null)
            {
                return Challenge();
            }
            return _context.Conversations.Include(c => c.User == user).ToList();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteThread(int userid, int threadid)
        {
            var user = await _context.Users.FindAsync(userid);
            if (user == null)
            {
                return Challenge();
            }

            var thread = await _context.Conversations.FindAsync(threadid);
            if (thread == null)
            {
                return BadRequest("Thread not found");
            }

            _context.Conversations.Remove(thread);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}