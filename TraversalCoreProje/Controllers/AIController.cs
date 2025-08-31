using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


public class AIController : Controller
{
    [HttpPost]
    public async Task<IActionResult> GetCityInfo([FromBody] CityRequest request)
    {
        if (string.IsNullOrEmpty(request.CityName))
        {
            return BadRequest("Şehir adı boş olamaz.");
        }

        // Gemini API anahtarınızı doğrudan buraya girin
        var apiKey = "AIzaSyB06gpQRI7XxVn6mewGTiHsbDx5tyrADME";

        using var client = new HttpClient();

        // Doğru kullanım
        var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={apiKey}";

        var promptText = $"{request.CityName} Almanca yazacaksin ve altinda Farsca tercumesini her paragraafin altina olacak sekilde ve kesinlikle turkce kullanmiyorsun hakkında 7 madde ve her madde için bir başlık ve kısa bir açıklama olacak şekilde bilgi ver. Cevabın sadece şu JSON formatında olsun: [{{'title': 'Başlık 1', 'description': 'Açıklama 1'}}, ..., {{'title': 'Başlık 7', 'description': 'Açıklama 7'}}]";

        var requestBody = new
        {
            contents = new[]
            {
                new
                {
                    parts = new[]
                    {
                        new { text = promptText }
                    }
                }
            }
        };

        var json = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
        {
            return StatusCode((int)response.StatusCode, "Gemini API'den bilgi alınırken bir hata oluştu.");
        }

        var responseString = await response.Content.ReadAsStringAsync();

        // Gelen JSON'u doğru şekilde işlemek için bir model oluşturun
        var geminiResponse = JsonSerializer.Deserialize<GeminiResponse>(responseString);
        var geminiContent = geminiResponse?.candidates[0].content.parts[0].text;

        // JSON bloğunu temizle ve ayrıştır
        var cleanJson = geminiContent.Replace("```json", "").Replace("```", "").Trim();
        var cityInfos = JsonSerializer.Deserialize<List<CityInfo>>(cleanJson);

        return Ok(cityInfos);
    }
}

// Gelen AJAX isteği için veri modeli
public class CityRequest
{
    public string CityName { get; set; }
}

// Gemini'dan gelen JSON verisini işlemek için modeller
public class GeminiResponse
{
    public List<Candidate> candidates { get; set; }
}

public class Candidate
{
    public Content content { get; set; }
}

public class Content
{
    public List<Part> parts { get; set; }
}

public class Part
{
    public string text { get; set; }
}

// Sonuç olarak döneceğimiz JSON modeli
public class CityInfo
{
    public string title { get; set; }
    public string description { get; set; }
}