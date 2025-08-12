using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace BlazorApp3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ArtistController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string artistName)
        {
            var apiKey = "ecf92467c590a9e82ef24e841e4b642e";
            var url = $"https://ws.audioscrobbler.com/2.0/?method=artist.getinfo&artist={Uri.EscapeDataString(artistName)}&api_key={apiKey}&format=json";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            return Content(content, "application/json");
        }
    }
}