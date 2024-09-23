using Microsoft.AspNetCore.Mvc;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace FISBOTTEST.Controllers
{
    [Route("whatsapp")]
    [ApiController]
    public class WhatsAppController : TwilioController
    {
        [HttpPost("receive")]
        public TwiMLResult ReceiveMessage(SmsRequest incomingMessage)
        {
            var response = new MessagingResponse();
            var incomingText = incomingMessage.Body?.Trim().ToLower();

            if (string.IsNullOrEmpty(incomingText))
            {
                response.Message("Sorry, I didn't understand that. Please try again.");
            }
            else if (incomingText.Contains("hello"))
            {
                response.Message("Hello! How can I assist you today?");
            }
            else
            {
                response.Message($"You said: {incomingMessage.Body}");
            }

            return TwiML(response);
        }
    }
}
