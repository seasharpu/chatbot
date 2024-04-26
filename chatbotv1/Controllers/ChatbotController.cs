using System.Text.Json;
using chatbotv1.Data;
using chatbotv1.Models.OpenAI;
using chatbotv1.Services;
using Microsoft.AspNetCore.Mvc;

namespace chatbotv1.Controllers {
    [ApiController]
    [Route("chatbot")]
    public class ChatbotController(OpenAIService openAIService, MyDBContext dbContext) : ControllerBase {
        private readonly OpenAIService _openAIService = openAIService;
        private readonly MyDBContext _context = dbContext;

        [HttpPost]
        public async Task<IActionResult> NewThread(int userid, string message) {
            var openAIUser = await _context.Users.FindAsync(1);
            var user = await _context.Users.FindAsync(userid);
            _context.UserQueries.Add(new UserQuery() {
                User = user,
                inputText = message,
                created = DateTime.Now
            });
            await _context.SaveChangesAsync();

            var messageObject = new Message() {
                    Content = message,
                    Role = "user"
                };
            var response = await _openAIService.CreateRequest("chat/completions", new OpenAIRequest() {
                Messages = new History().AddMessage(messageObject)
            });
            Response? responseObject = JsonSerializer.Deserialize<Response>(response.Content.ToString() ?? "");
            if(responseObject == null) {
                return BadRequest("Could not deserialize response object");
            }
            string responseMessage = responseObject.Choices[0].Message?.Content ?? "";

            return Ok(responseMessage);
        }
    }
}