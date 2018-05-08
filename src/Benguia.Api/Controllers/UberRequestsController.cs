using Benguia.Api.Configuration;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Benguia.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UberRequestsController : Controller
    {
        private readonly UberConfiguration uberConfiguration;

        public UberRequestsController(IOptions<UberConfiguration> uberConfigurationOption)
        {
            this.uberConfiguration = uberConfigurationOption.Value;
        }

        [HttpPost, EnableCors("CorsPolicy")]
        public IActionResult Post(string productId, float startLatitude, float startLongitude, float endLatitude, float endLongitude, string fareId, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uberConfiguration.UrlApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Add("Accept-Language", "pt_BR");

                HttpResponseMessage response = client.PostAsync($"requests", new StringContent(JsonConvert.SerializeObject(new
                {
                    product_id = productId,
                    start_latitude = startLatitude,
                    start_longitude = startLongitude,
                    end_latitude = endLatitude,
                    end_longitude = endLongitude
                }), Encoding.UTF8, "application/json")).Result;

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