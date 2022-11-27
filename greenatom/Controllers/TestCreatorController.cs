using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace greenatom.Controllers
{
    [ApiController]
    [Route("/creator")]
    [Authorize]
    public class TestCreatorController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHtml()
        {
            return Content(System.IO.File.ReadAllText("wwwroot/test_creator.html"), "text/html");
        }
    }
}