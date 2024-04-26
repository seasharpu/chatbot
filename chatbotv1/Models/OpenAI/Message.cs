namespace chatbotv1.Models.OpenAI {
    public class Message : IMessage {
        public int? Id { get; set; }
        public string Role { get; set; } = "";
        public string Content { get; set; } = "";
        public string? Name { get; set; }
    }

}