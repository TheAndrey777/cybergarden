using Microsoft.AspNetCore.Mvc;
using greenatom.Models;
using greenatom.Services;

namespace greenatom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DatabaseService _databaseService;

        public WeatherForecastController(DatabaseService DbService)
        {
            _databaseService = DbService;
        }

        [HttpGet("test1")]
        public IActionResult Get()
        {
            //await _databaseService.AddUser(new UserModel { Username = "andreyyyy", Password = "465789" });
            return Ok();
        }
    }
}