using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace greenatom.Controllers
{
    [ApiController]
    [Route("/")]
    [Authorize]
    public class IndexControler : ControllerBase
    {
        private readonly ILogger<IndexControler> _logger;

        public IndexControler(ILogger<IndexControler> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetHtml()
        {
            return Content(System.IO.File.ReadAllText("wwwroot/form.html"), "text/html");
        }
    }
}