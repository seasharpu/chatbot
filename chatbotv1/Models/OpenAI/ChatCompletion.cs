namespace chatbotv1.Models.OpenAI {
    public class ChatCompletion
    {
        // A unique identifier for the chat completion.
        public int Id { get; set;}
        // The object type, which is always chat.completion.
        public string Object { get; set; } = "";
        // The Unix timestamp (in seconds) of when the chat completion was created.
        public int Created { get; set; }
        // The model used for the chat completion.
        public string Model { get; set; } = "";
        /*
            This fingerprint represents the backend configuration that the model runs with.
            Can be used in conjunction with the seed request parameter to understand when backend changes have been made that might impact determinism.
        */
        public string System_fingerprint { get; set; } = "";
        // A list of chat completion choices. Can be more than one if n is greater than 1.
        public Choice[] Choices { get; set; } = [];
        // Usage statistics for the completion request.
        public Usage? Usage { get; set; }
    }
}