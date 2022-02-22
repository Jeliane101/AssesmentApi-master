using AssesmentApi.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssesmentApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ChuckSwapiController : ControllerBase
    {
        [Route("chuck")]
        [HttpGet]
        public async Task<IActionResult> GetChuckNorrisJokeCatergories()
        {
            var client = new RestClient("https://api.chucknorris.io/");
            var request = new RestRequest("jokes/categories", Method.Get);
            var queryResult = await client.GetAsync<List<string>>(request);
            return Ok(queryResult);
        }
        [Route("swapi")]
        [HttpGet]
        public async Task<IActionResult> GetStarWarsPeopleDetail()
        {
            var client = new RestClient("https://swapi.dev/");
            var request = new RestRequest("api/people/", Method.Get);
            var queryResult = await client.GetAsync<People>(request);
            return Ok(queryResult);
        }
        [Route("search")]
        [HttpGet]
        public async Task<IActionResult> SearchApi([FromQuery]string search)
        {
            // 1. Search Chuck
            var chuckClient = new RestClient("https://api.chucknorris.io/");
            var chuckRequest = new RestRequest($"jokes/search?query={search}%", Method.Get);
            var chuckResult = await chuckClient.GetAsync<Jokes>(chuckRequest);
            // 2. Search Swapi
            var client = new RestClient("https://swapi.dev/");
            var request = new RestRequest($"api/people/?search={search}", Method.Get);
            var queryResult = await client.GetAsync<People>(request);

            var response = new CombinedResult();
            response.Chuck = chuckResult;
            response.Swapi = queryResult;

            return Ok(response);
        }
    }
}
