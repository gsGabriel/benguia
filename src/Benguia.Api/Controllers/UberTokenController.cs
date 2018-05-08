using Benguia.Api.Configuration;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Benguia.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UberTokenController : Controller
    {
        private readonly UberConfiguration uberConfiguration;

        public UberTokenController(IOptions<UberConfiguration> uberConfigurationOption)
        {
            this.uberConfiguration = uberConfigurationOption.Value;
        }

        [HttpGet, EnableCors("CorsPolicy")]
        public IActionResult Get(string token, string redirectUrl)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uberConfiguration.UrlLogin);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                
                HttpResponseMessage response = client.PostAsync("token", new FormUrlEncodedContent(new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("client_secret", uberConfiguration.Secret),
                    new KeyValuePair<string, string>("client_id", uberConfiguration.Client),
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("redirect_uri", redirectUrl),
                    new KeyValuePair<string, string>("code", token),
                })).Result;

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