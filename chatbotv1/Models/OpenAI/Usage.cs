namespace chatbotv1.Models.OpenAI
{
    public class Usage
    {
        // Number of tokens in the generated completion.
        public int Completion_tokens { get; set; }

        // Number of tokens in the prompt.
        public int Prompt_tokens { get; set; }
        
        // Total number of tokens used in the request (prompt + completion).
        public int Total_tokens { get; set; }
    }
}