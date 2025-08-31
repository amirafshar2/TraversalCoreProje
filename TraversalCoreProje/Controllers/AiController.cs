using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TraversalCoreProje.Models.AI;
using TraversalCoreProje.Models.PicMethods.AI;

namespace TraversalCoreProje.Controllers
{
    public class AiController : Controller
    {
        private readonly GeminiClient _geminiClient;

        public AiController(GeminiClient geminiClient)
        {
            _geminiClient = geminiClient;
        }

        [HttpGet]
        public IActionResult Chat()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Chat([FromBody] ChatViewModel requestModel)
        {
            // İsteğin boş gelme ihtimaline karşı kontrol
            if (requestModel == null || string.IsNullOrEmpty(requestModel.CityOrRegion))
            {
                return Json(new { success = false, message = "Lütfen bir şehir veya bölge adı girin." });
            }

            var model = requestModel;
            var userMessage = requestModel.CityOrRegion;

            // Kullanıcı mesajını ekle
            model.Messages.Add(new ChatMessage
            {
                Sender = "User",
                Text = userMessage
            });

            // Prompt oluştur
            var fullPrompt = new StringBuilder();
            fullPrompt.AppendLine(@"Sen Traversal adında bir tur asistanısın.
Sana verilen şehir veya bölge hakkında turistik ve tarihi bilgiler vereceksin.
Formatın şu şekilde olmalı:
1. Ünlü bir kişinin o bölge hakkında söylediği etkileyici bir yorumla başla. İsmini belirt.
2. Ardından tur fiyatı ve kaç gece süreceğini yaz.
3. Sonra 5 farklı başlık altında bilgi ver:
   - Her başlık yaklaşık 7 kelimelik olmalı.
   - Her başlığın altında yaklaşık 5 satırlık açıklama olmalı.
   - Konular turistik ve tarihi açıdan çeşitli olmalı (örneğin: doğa, müze, yemek, mimari, gelenek).
Lütfen bu formatta Türkçe olarak yanıt ver.");

            // Sohbet geçmişini ekle
            foreach (var message in model.Messages)
            {
                fullPrompt.AppendLine($"{message.Sender}: {message.Text}");
            }
            fullPrompt.AppendLine("AI:");

            // AI cevabı al
            var aiResponse = await _geminiClient.GenerateTextAsync(fullPrompt.ToString());

            // AI mesajını ekle
            model.Messages.Add(new ChatMessage
            {
                Sender = "AI",
                Text = aiResponse
            });

            // Modeli direkt JSON olarak döndür
            return Json(model);
        }
    }
}