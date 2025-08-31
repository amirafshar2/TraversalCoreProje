using System.Text;
using System.Collections.Generic;
namespace TraversalCoreProje.Models.PicMethods.AI
{

    public class ChatMessage
    {
        public string Sender { get; set; } // "User" veya "AI"
        public string Text { get; set; }
    }

    public class ChatViewModel
    {
        public List<ChatMessage> Messages { get; set; } = new List<ChatMessage>();
        public string CityOrRegion { get; set; }
    }

}


