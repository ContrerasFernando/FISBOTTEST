using Twilio;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace FISBOTTEST.Controllers
{
    public class WhatsAppService
    {

        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _fromWhatsAppNumber;

        public WhatsAppService(IConfiguration configuration)
        {
            _accountSid = configuration["Twilio:AccountSid"];
            _authToken = configuration["Twilio:AuthToken"];
            _fromWhatsAppNumber = configuration["Twilio:WhatsAppFromNumber"];
            TwilioClient.Init(_accountSid, _authToken);
        }

        public void SendWhatsAppMessage(string to, string message)
        {
            var toWhatsAppNumber = $"whatsapp:{to}";
            MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber(_fromWhatsAppNumber),
                to: new Twilio.Types.PhoneNumber(toWhatsAppNumber)
            );
        }

    }
}
