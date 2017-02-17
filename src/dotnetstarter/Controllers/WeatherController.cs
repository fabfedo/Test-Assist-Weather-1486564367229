using System.Net;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net.Http.Headers;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Webservice.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        // GET: api/weather
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Vimago", "Assist" };
        }

        // GET api/weather/92300
        [HttpGet("{postalcode}")]
        public async System.Threading.Tasks.Task<string> Get(int postalcode)
        {
            var credentials = new NetworkCredential("bc4424d0-8080-4c06-ac83-0fd95d534fac", "BvHIESO7Tl");
            var handler = new HttpClientHandler { Credentials = credentials };

            using (var client = new HttpClient(handler))
            {
                var baseUri = WeatherService.Url + "/api/weather/v1/location/"+ postalcode +"%3A4%3AFR/observations.json?units=m&language=fr-FR";
                Console.WriteLine("URL: {0}", baseUri);
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(baseUri);
                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    return responseJson;
                }
                else {
                    Console.WriteLine("Error occurred, the status code is: {0}", response.StatusCode);
                    return "error";
                }
            }


            
        }



    }
}
