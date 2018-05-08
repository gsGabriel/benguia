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
    public class UberEstimativePricesController : Controller
    {
        private readonly UberConfiguration uberConfiguration;

        public UberEstimativePricesController(IOptions<UberConfiguration> uberConfigurationOption)
        {
            this.uberConfiguration = uberConfigurationOption.Value;
        }

        [HttpGet, EnableCors("CorsPolicy")]
        public IActionResult Get(float startLatitude, float startLongitude, float endLatitude, float endLongitude)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uberConfiguration.UrlApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", uberConfiguration.Server);
                client.DefaultRequestHeaders.Add("Accept-Language", "pt_BR");

                HttpResponseMessage response = client.GetAsync($"estimates/price?start_latitude={startLatitude}&start_longitude={startLongitude}&end_latitude={endLatitude}&end_longitude={endLongitude}").Result;

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