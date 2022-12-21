using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace serviceone.Controllers;
[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private HttpClient _client;

    public HomeController()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://servicetwo:80/");
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }
    // GET
    [HttpGet("test")]
    public IActionResult Index()
    {
        return Ok("Single works!");
    }

    [HttpGet("network")]
    public IActionResult NetworkRequest()
    {
        var response = _client.GetAsync("WeatherForecast").Result;
        return Ok(response.Content.ReadAsStreamAsync().Result);
    }
}