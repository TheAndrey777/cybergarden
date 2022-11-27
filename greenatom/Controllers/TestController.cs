using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace greenatom.Controllers
{
    [ApiController]
    [Route("/testing")]
    [Authorize]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHtml()
        {
            return Content(System.IO.File.ReadAllText("wwwroot/testing.html"), "text/html");
        }
    }
}