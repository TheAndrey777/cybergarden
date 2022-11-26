using Microsoft.AspNetCore.Mvc;

namespace greenatom.Controllers
{
    [ApiController]
    [Route("/recovery")]
    public class RecoveryController : ControllerBase
    {
        private readonly ILogger<RecoveryController> _logger;

        public RecoveryController(ILogger<RecoveryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.Content(System.IO.File.ReadAllText("wwwroot/recovery.html"), "text/html");
        }
    }
}