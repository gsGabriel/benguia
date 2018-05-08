using Benguia.Api.Configuration;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Benguia.Api.Controllers
{
    public class SMS
    {
        public string Name { get; set; }
        public string Number { get; set; }
    }

    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SmsController : Controller
    {
        private readonly TwilioConfiguration twilioConfiguration;

        public SmsController(IOptions<TwilioConfiguration> twilioConfigurationOption)
        {
            this.twilioConfiguration = twilioConfigurationOption.Value;
        }

        [HttpPost, EnableCors("CorsPolicy")]
        public IActionResult Post([FromBody]SMS model)
        {
            // Find your Account Sid and Auth Token at twilio.com/user/account 
            TwilioClient.Init(twilioConfiguration.AccountSid, twilioConfiguration.AuthToken);
            
            var message = MessageResource.Create(new PhoneNumber(model.Number),
            from: new PhoneNumber(twilioConfiguration.PhoneNumber),
            body: $"Olá, meu nome é {model.Name}, sou deficiente visual, estou fazendo uma corrida com você e posso precisar da sua ajuda para embarcar.");

            return new ObjectResult(new { Ok = true });
        }
    }
}