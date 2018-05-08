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
    public class GoogleGeocodeController : Controller
    {
        private readonly GoogleConfiguration googleConfiguration;

        public GoogleGeocodeController(IOptions<GoogleConfiguration> googleConfigurationOption)
        {
            this.googleConfiguration = googleConfigurationOption.Value;
        }

        [HttpGet, EnableCors("CorsPolicy")]
        public IActionResult Get(float latitude, float longitude)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(googleConfiguration.UrlMapsApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("Accept-Language", "pt_BR");

                HttpResponseMessage response = client.GetAsync($"geocode/json?latlng={latitude},{longitude}&result_type=street_address&key={googleConfiguration.MapsKey}").Result;

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