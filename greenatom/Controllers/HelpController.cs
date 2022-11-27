using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace greenatom.Controllers
{
    [ApiController]
    [Route("/about")]
    [Authorize]
    public class HelpController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHtml()
        {
            return Content(System.IO.File.ReadAllText("wwwroot/help.html"), "text/html");
        }
    }
}