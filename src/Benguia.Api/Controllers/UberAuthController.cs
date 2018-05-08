using Benguia.Api.Configuration;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Benguia.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UberAuthController : Controller
    {
        private readonly UberConfiguration uberConfiguration;

        public UberAuthController(IOptions<UberConfiguration> uberConfigurationOption)
        {
            this.uberConfiguration = uberConfigurationOption.Value;
        }

        [HttpGet, EnableCors("CorsPolicy")]
        public IActionResult Get(string redirectUrl)
        {
            return new ObjectResult(new { Ok = true, Data = $"{uberConfiguration.UrlLogin}authorize?client_id={uberConfiguration.Client}&response_type=code&redirect_uri={redirectUrl}" });
        }
    }
}
