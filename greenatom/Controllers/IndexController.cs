using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace greenatom.Controllers
{
    [ApiController]
    [Route("/")]
    [Authorize]
    public class IndexControler : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public IActionResult GetHtml()
        {
            return Content(System.IO.File.ReadAllText("wwwroot/form.html"), "text/html");
        }
    }
}