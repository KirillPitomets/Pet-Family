using Microsoft.AspNetCore.Mvc;
using PetFamily.Domain.Volunteer;

namespace PetFamily.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get(string firstName, string lastName)
    {
        return Ok();
    }
}

