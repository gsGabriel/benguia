using Benguia.Api.Configuration;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Benguia.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UberCurrentRequestsController : Controller
    {
        private readonly UberConfiguration uberConfiguration;

        public UberCurrentRequestsController(IOptions<UberConfiguration> uberConfigurationOption)
        {
            this.uberConfiguration = uberConfigurationOption.Value;
        }

        [HttpGet, EnableCors("CorsPolicy")]
        public IActionResult Get(string token)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uberConfiguration.UrlApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Add("Accept-Language", "pt_BR");

                HttpResponseMessage response = client.GetAsync("requests/current").Result;

                if (response.IsSuccessStatusCode)
                {
                    return new ObjectResult(new { Ok = true, Data = response.Content.ReadAsStringAsync().Result });
                }
                else
                {
                    return new ObjectResult(new { Ok = false });
                }
            }
        }
    }
}