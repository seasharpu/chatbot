namespace chatbotv1.Services
{
    public interface iOpenAIService
    {
        public Task<HttpResponseMessage> CreateRequest(string url, object content);
        public Task<HttpResponseMessage> CreateRequest(string url, StringContent contentJson);
    }
}