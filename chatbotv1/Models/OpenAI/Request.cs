using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace chatbotv1.Models.OpenAI {
    public class OpenAIRequest
    {
        public string Model { get; set; } = "gpt-3.5-turbo";
        public History Messages { get; set; } = new History();
        //public float? Frequency_penalty { get; set; } = 0;
    }
}