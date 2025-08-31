using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TraversalCoreProje.Models.AI
{
    public class GeminiClient
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;
        private readonly string _endpoint = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent";

        // Constructor ile IConfiguration alarak API anahtarını okuyoruz
        public GeminiClient(IConfiguration configuration)
        {
            _client = new HttpClient();
            _apiKey = configuration["GeminiSettings:ApiKey"];
        }

        public async Task<string> GenerateTextAsync(string prompt)
        {
            if (string.IsNullOrEmpty(_apiKey))
            {
                return "Hata: API anahtarı yapılandırma dosyasında bulunamadı.";
            }

            var requestBody = new
            {
                contents = new[]
                {
                    new { parts = new[] { new { text = prompt } } }
                }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var fullEndpoint = $"{_endpoint}?key={_apiKey}";
                HttpResponseMessage response = await _client.PostAsync(fullEndpoint, content);

                response.EnsureSuccessStatusCode(); // Hata kodlarını (4xx, 5xx) yakalamak için

                string responseString = await response.Content.ReadAsStringAsync();

                using var doc = JsonDocument.Parse(responseString);
                var candidates = doc.RootElement.GetProperty("candidates");

                if (candidates.ValueKind == JsonValueKind.Array && candidates.GetArrayLength() > 0)
                {
                    var firstCandidate = candidates[0];
                    if (firstCandidate.TryGetProperty("content", out var contentElement) &&
                        contentElement.TryGetProperty("parts", out var partsElement) &&
                        partsElement.ValueKind == JsonValueKind.Array && partsElement.GetArrayLength() > 0)
                    {
                        var firstPart = partsElement[0];
                        if (firstPart.TryGetProperty("text", out var textElement))
                        {
                            return textElement.GetString();
                        }
                    }
                }
                return "Yanıt alınamadı veya yanıt formatı hatalı.";
            }
            catch (HttpRequestException e)
            {
                // API isteği sırasında oluşan ağ veya HTTP hatalarını yakala
                return $"Hata: API'ye bağlanırken sorun oluştu. Detay: {e.Message}";
            }
            catch (JsonException)
            {
                // JSON ayrıştırma hatalarını yakala
                return "Hata: API yanıtı ayrıştırılırken sorun oluştu.";
            }
        }
    }
}