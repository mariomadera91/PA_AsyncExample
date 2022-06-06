using ApiAsyncExample.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiAsyncExample.Controllers
{
    [ApiController]
    [Route("example")]
    public class ExampleController : Controller
    {
        public string url = "https://swapi.dev/api/films/";

        [HttpGet]
        [Route("async1")]
        public async Task<ActionResult> GetAsync1()
        {
            var exampleAsyncModel = new ExampleAsyncModel();
            exampleAsyncModel.Movies = new List<Movie>();

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var httpClient = new HttpClient();

            var request1 = await httpClient.GetAsync(url + 1);
            var request2 = await httpClient.GetAsync(url + 2);
            var request3 = await httpClient.GetAsync(url + 3);

            var response1 = await request1.Content.ReadAsStringAsync();
            var response2 = await request2.Content.ReadAsStringAsync();
            var response3 = await request3.Content.ReadAsStringAsync();

            var movie1 = JsonConvert.DeserializeObject<Movie>(response1);
            var movie2 = JsonConvert.DeserializeObject<Movie>(response2);
            var movie3 = JsonConvert.DeserializeObject<Movie>(response3);

            exampleAsyncModel.Movies.Add(movie1);
            exampleAsyncModel.Movies.Add(movie2);
            exampleAsyncModel.Movies.Add(movie3);

            stopWatch.Stop();
            exampleAsyncModel.Time = stopWatch.Elapsed.TotalMilliseconds.ToString();

            return Ok(exampleAsyncModel);
        }

        [HttpGet]
        [Route("async2")]
        public async Task<ActionResult> GetAsync2()
        {
            var exampleAsyncModel = new ExampleAsyncModel();
            exampleAsyncModel.Movies = new List<Movie>();

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var httpClient = new HttpClient();

            var request1 = httpClient.GetAsync(url + 1);
            var request2 = httpClient.GetAsync(url + 2);
            var request3 = httpClient.GetAsync(url + 3);

            Task.WaitAll(request1, request2, request3);

            var response1 = request1.Result.Content.ReadAsStringAsync();
            var response2 = request2.Result.Content.ReadAsStringAsync();
            var response3 = request3.Result.Content.ReadAsStringAsync();

            Task.WaitAll(response1, response2, response3);

            var movie1 = JsonConvert.DeserializeObject<Movie>(response1.Result);
            var movie2 = JsonConvert.DeserializeObject<Movie>(response2.Result);
            var movie3 = JsonConvert.DeserializeObject<Movie>(response3.Result);

            exampleAsyncModel.Movies.Add(movie1);
            exampleAsyncModel.Movies.Add(movie2);
            exampleAsyncModel.Movies.Add(movie3);

            stopWatch.Stop();
            exampleAsyncModel.Time = stopWatch.Elapsed.TotalMilliseconds.ToString();

            return Ok(exampleAsyncModel);
        }

    }
}
