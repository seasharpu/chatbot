namespace chatbotv1.Models.OpenAI {
    public class Choice
    {
        public int Index { get; set; }
        public IMessage? Message { get; set; }
        public string Finish_reason { get; set; } = "";
    }
}