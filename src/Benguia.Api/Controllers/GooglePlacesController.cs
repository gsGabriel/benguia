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
    public class GooglePlacesController : Controller
    {
        private readonly GoogleConfiguration googleConfiguration;

        public GooglePlacesController(IOptions<GoogleConfiguration> googleConfigurationOption)
        {
            this.googleConfiguration = googleConfigurationOption.Value;
        }

        [HttpGet, EnableCors("CorsPolicy")]
        public IActionResult Get(string place)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(googleConfiguration.UrlMapsApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("Accept-Language", "pt_BR");

                HttpResponseMessage response = client.GetAsync($"place/textsearch/json?lang‌​uage=pt-BR&query={place}&key={googleConfiguration.MapsKey}").Result;

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