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

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public IActionResult GetHtml()
        {
            return Content(System.IO.File.ReadAllText("wwwroot/index.html"), "text/html");
        }
    }
}