using System.Text;
using System.Text.Json;
using Azure.Core;
using Microsoft.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;

namespace chatbotv1.Services
{
    public class OpenAIService(IHttpClientFactory httpClientFactory, IConfiguration config) : iOpenAIService
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly IConfiguration _config = config;
        private const string BASE_URL = "https://api.openai.com/v1/";
        private const string OPENAI_ORGANIZATION_HEADER = "OpenAI-Organization";

        public async Task<HttpResponseMessage> CreateRequest(string url, object content) {
            var contentJson = new StringContent(
                JsonSerializer.Serialize(content),
                Encoding.UTF8,
                Application.Json);
            return await CreateRequest(url, contentJson);
        }

        public async Task<HttpResponseMessage> CreateRequest(string url, StringContent contentJson) {
            string key = _config.GetValue("Chatbot-Key", "") ?? "";
            string orgId = _config.GetValue("OpenAI-OrgId", "") ?? "";
            var httpClient = _httpClientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Post,
                BASE_URL + url
            ) {
                Headers = {
                    { HeaderNames.Authorization, $"Bearer {key}" },
                    { OPENAI_ORGANIZATION_HEADER, orgId },
                    { HeaderNames.Accept, Application.Json }
                },
                Content = contentJson
            };
            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}
